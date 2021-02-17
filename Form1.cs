/* Copyright (C) 2021 Ludovico Massaccesi
 * 
 * This file is part of AudioVolumeNormalizer.
 * 
 * AudioVolumeNormalizer is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * AudioVolumeNormalizer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with AudioVolumeNormalizer.
 * If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using Settings = AudioVolumeNormalizer.Properties.Settings;

namespace AudioVolumeNormalizer {
    public partial class Form1 : Form {

        #region Initialization and Exiting

        public Form1() {
            InitializeComponent();
            UpdateDevicesList();
        }

        private void Form1_Load(object sender, EventArgs e) {
            numTickDuration.Value = timer.Interval = Settings.Default.tickDuration;
            numLowerPatience.Value = Settings.Default.lowerPatience;
            numRaisePatience.Value = Settings.Default.raisePatience;
            numWantedVolume.Value = Settings.Default.wantedVolume;
            numMaxVolume.Value = Settings.Default.maxVolume;

            foreach (MMDevice device in ddlDevice.Items) {
                if (device.FriendlyName == Settings.Default.device) {
                    ddlDevice.SelectedItem = device;
                    break;
                }
            }
            if (ddlDevice.SelectedItem == null)
                ddlDevice.SelectedIndex = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Settings.Default.device = ddlDevice.Text;
            Settings.Default.tickDuration = (int)numTickDuration.Value;
            Settings.Default.lowerPatience = (int)numLowerPatience.Value;
            Settings.Default.raisePatience = (int)numRaisePatience.Value;
            Settings.Default.wantedVolume = (int)numWantedVolume.Value;
            Settings.Default.maxVolume = (int)numMaxVolume.Value;
            Settings.Default.Save();
        }

        #endregion

        #region Core Audio

        private class RingBuffer {
            private float[] buffer = null;
            private int nextIdx = 0; // Index of the next element to write

            public RingBuffer(int length = 128) {
                if (length > (int.MaxValue >> 1))
                    length = int.MaxValue >> 1;
                int realLength = 1;
                while (realLength < length)
                    realLength <<= 1;
                buffer = new float[length];
                for (int i = 0; i < length; i++)
                    buffer[i] = -1.0f;
            }

            public int Size { get { return buffer.Length; } }

            public void PushBack(float value) {
                buffer[nextIdx] = value;
                nextIdx = (nextIdx + 1) & (buffer.Length - 1);
            }

            public float GetMaxOfLastN(int n) {
                float res = 0.0f;
                for (int i = 0; i < n; i++) {
                    int idx = (nextIdx - i) & (buffer.Length - 1);
                    if (res < buffer[idx])
                        res = buffer[idx];
                }
                return res;
            }

            public float GetMinOfLastN(int n) {
                float res = 1.0f;
                for (int i = 0; i < n; i++) {
                    int idx = (nextIdx - i) & (buffer.Length - 1);
                    if (buffer[idx] >= 0.0f && res > buffer[idx])
                        res = buffer[idx];
                }
                return res;
            }
        }

        private MMDevice currentDevice = null;
        private RingBuffer currentPeaks = null;

        private MMDevice CurrentDevice {
            get { return currentDevice; }
            set {
                if (value == null) {
                    timer.Stop();
                    currentDevice = null;
                } else if (value.FriendlyName != currentDevice?.FriendlyName) {
                    currentDevice = value;
                    currentPeaks = new RingBuffer();
                    timer.Start();
                }
                SetStatus();
            }
        }

        private void UpdateDevicesList() {
            ddlDevice.Items.Clear();
            using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                    ddlDevice.Items.Add(device);
        }

        private float vol {
            get { return currentDevice.AudioEndpointVolume.MasterVolumeLevelScalar; }
            set { currentDevice.AudioEndpointVolume.MasterVolumeLevelScalar = value; }
        }
        private float wVol { get { return (float)numWantedVolume.Value / 100.0f; } }
        private float mVol { get { return (float)numMaxVolume.Value / 100.0f; } }
        private float lPeak { 
            get { return currentPeaks.GetMinOfLastN((int)numLowerPatience.Value); }
        }
        private float rPeak { 
            get { return currentPeaks.GetMaxOfLastN((int)numRaisePatience.Value); } 
        }

        //private DateTime lastTick = DateTime.Now;

        private void timer_Tick(object sender, EventArgs e) {
            try {
                currentPeaks.PushBack(currentDevice.AudioMeterInformation.MasterPeakValue);
                float newvol = vol;
                if (lPeak * vol > wVol)
                    newvol = wVol / lPeak;
                else if (rPeak * vol < 0.75f * wVol)
                    newvol = rPeak > 0.02f ? Math.Min(wVol * 0.75f / rPeak, wVol / lPeak) : wVol;
                if (newvol != vol)
                    vol = Math.Min(mVol, newvol);
            } catch (Exception ex) {
                SetStatusError(ex);
            }
        }

        #endregion

        #region Status update

        private DateTime lastStatusUpdate = DateTime.Now;
        private static readonly TimeSpan statusUpdateInterval = new TimeSpan(TimeSpan.TicksPerSecond / 2);

        private void SetStatus() {
            lastStatusUpdate = DateTime.Now;
            lblStat.Text = currentDevice == null ? "Not running." : $"Running on {currentDevice}";
        }

        private void SetStatus(string status) {
            if (currentDevice == null || DateTime.Now < lastStatusUpdate + statusUpdateInterval)
                return;
            lblStat.Text = $"Running on {currentDevice}{Environment.NewLine}{status}";
            lastStatusUpdate = DateTime.Now;
        }

        private void SetStatusError(Exception ex) {
            if (currentDevice == null)
                return;
            string name = currentDevice.FriendlyName;
            CurrentDevice = null;
            lblStat.Text = $"Error while running on {name}:{Environment.NewLine}{ex.Message}";
        }

        #endregion

        private void ddlDevice_DropDown(object sender, EventArgs e) {
            UpdateDevicesList();
        }

        private void ddlDevice_SelectedIndexChanged(object sender, EventArgs e) {
            CurrentDevice = ddlDevice.SelectedItem as MMDevice;
        }

        private void numTickDuration_ValueChanged(object sender, EventArgs e) {
            timer.Interval = (int)numTickDuration.Value;
        }

        private void numLowerPatience_ValueChanged(object sender, EventArgs e) {
            numRaisePatience.Minimum = numLowerPatience.Value + 1;
        }
    }
}
