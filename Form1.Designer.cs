
namespace AudioVolumeNormalizer {
    partial class Form1 {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupStatus;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label7;
            this.lblStat = new System.Windows.Forms.Label();
            this.groupSetup = new System.Windows.Forms.GroupBox();
            this.numMaxVolume = new System.Windows.Forms.NumericUpDown();
            this.numWantedVolume = new System.Windows.Forms.NumericUpDown();
            this.numRaisePatience = new System.Windows.Forms.NumericUpDown();
            this.numLowerPatience = new System.Windows.Forms.NumericUpDown();
            this.numTickDuration = new System.Windows.Forms.NumericUpDown();
            this.ddlDevice = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            label1 = new System.Windows.Forms.Label();
            groupStatus = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            groupStatus.SuspendLayout();
            groupBox1.SuspendLayout();
            this.groupSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWantedVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaisePatience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowerPatience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTickDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(110, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 13);
            label1.TabIndex = 0;
            label1.Text = "Device";
            // 
            // groupStatus
            // 
            groupStatus.Controls.Add(this.lblStat);
            groupStatus.Location = new System.Drawing.Point(297, 12);
            groupStatus.Name = "groupStatus";
            groupStatus.Size = new System.Drawing.Size(200, 176);
            groupStatus.TabIndex = 2;
            groupStatus.TabStop = false;
            groupStatus.Text = "Run && status";
            // 
            // lblStat
            // 
            this.lblStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStat.Location = new System.Drawing.Point(3, 16);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(194, 157);
            this.lblStat.TabIndex = 5;
            this.lblStat.Text = "Initializing.\r\nIf you actually have the time to read this, something is probably " +
    "going wrong.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(67, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 13);
            label2.TabIndex = 3;
            label2.Text = "Update tick (ms)";
            // 
            // label3
            // 
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(479, 146);
            label3.TabIndex = 4;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 74);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(145, 13);
            label4.TabIndex = 5;
            label4.Text = "Ticks before lowering volume";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 100);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(136, 13);
            label5.TabIndex = 7;
            label5.Text = "Ticks before raising volume";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(52, 126);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(99, 13);
            label6.TabIndex = 9;
            label6.Text = "Wanted volume (%)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(12, 194);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(485, 165);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Help";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(70, 152);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(81, 13);
            label7.TabIndex = 11;
            label7.Text = "Max volume (%)";
            // 
            // groupSetup
            // 
            this.groupSetup.Controls.Add(label7);
            this.groupSetup.Controls.Add(this.numMaxVolume);
            this.groupSetup.Controls.Add(label6);
            this.groupSetup.Controls.Add(this.numWantedVolume);
            this.groupSetup.Controls.Add(label5);
            this.groupSetup.Controls.Add(this.numRaisePatience);
            this.groupSetup.Controls.Add(label4);
            this.groupSetup.Controls.Add(this.numLowerPatience);
            this.groupSetup.Controls.Add(label2);
            this.groupSetup.Controls.Add(this.numTickDuration);
            this.groupSetup.Controls.Add(this.ddlDevice);
            this.groupSetup.Controls.Add(label1);
            this.groupSetup.Location = new System.Drawing.Point(12, 12);
            this.groupSetup.Name = "groupSetup";
            this.groupSetup.Size = new System.Drawing.Size(283, 176);
            this.groupSetup.TabIndex = 1;
            this.groupSetup.TabStop = false;
            this.groupSetup.Text = "Setup";
            // 
            // numMaxVolume
            // 
            this.numMaxVolume.Location = new System.Drawing.Point(157, 150);
            this.numMaxVolume.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxVolume.Name = "numMaxVolume";
            this.numMaxVolume.Size = new System.Drawing.Size(120, 20);
            this.numMaxVolume.TabIndex = 6;
            this.numMaxVolume.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numWantedVolume
            // 
            this.numWantedVolume.Location = new System.Drawing.Point(157, 124);
            this.numWantedVolume.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWantedVolume.Name = "numWantedVolume";
            this.numWantedVolume.Size = new System.Drawing.Size(120, 20);
            this.numWantedVolume.TabIndex = 5;
            this.numWantedVolume.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numRaisePatience
            // 
            this.numRaisePatience.Location = new System.Drawing.Point(157, 98);
            this.numRaisePatience.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRaisePatience.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRaisePatience.Name = "numRaisePatience";
            this.numRaisePatience.Size = new System.Drawing.Size(120, 20);
            this.numRaisePatience.TabIndex = 4;
            this.numRaisePatience.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numLowerPatience
            // 
            this.numLowerPatience.Location = new System.Drawing.Point(157, 72);
            this.numLowerPatience.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLowerPatience.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowerPatience.Name = "numLowerPatience";
            this.numLowerPatience.Size = new System.Drawing.Size(120, 20);
            this.numLowerPatience.TabIndex = 3;
            this.numLowerPatience.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowerPatience.ValueChanged += new System.EventHandler(this.numLowerPatience_ValueChanged);
            // 
            // numTickDuration
            // 
            this.numTickDuration.Location = new System.Drawing.Point(157, 46);
            this.numTickDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTickDuration.Name = "numTickDuration";
            this.numTickDuration.Size = new System.Drawing.Size(120, 20);
            this.numTickDuration.TabIndex = 2;
            this.numTickDuration.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numTickDuration.ValueChanged += new System.EventHandler(this.numTickDuration_ValueChanged);
            // 
            // ddlDevice
            // 
            this.ddlDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDevice.FormattingEnabled = true;
            this.ddlDevice.Location = new System.Drawing.Point(157, 19);
            this.ddlDevice.Name = "ddlDevice";
            this.ddlDevice.Size = new System.Drawing.Size(120, 21);
            this.ddlDevice.TabIndex = 1;
            this.ddlDevice.DropDown += new System.EventHandler(this.ddlDevice_DropDown);
            this.ddlDevice.SelectedIndexChanged += new System.EventHandler(this.ddlDevice_SelectedIndexChanged);
            // 
            // timer
            // 
            this.timer.Interval = 16;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 371);
            this.Controls.Add(groupBox1);
            this.Controls.Add(groupStatus);
            this.Controls.Add(this.groupSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AudioVolumeNormalizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            groupStatus.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            this.groupSetup.ResumeLayout(false);
            this.groupSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWantedVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaisePatience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowerPatience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTickDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSetup;
        private System.Windows.Forms.NumericUpDown numTickDuration;
        private System.Windows.Forms.ComboBox ddlDevice;
        private System.Windows.Forms.NumericUpDown numWantedVolume;
        private System.Windows.Forms.NumericUpDown numRaisePatience;
        private System.Windows.Forms.NumericUpDown numLowerPatience;
        private System.Windows.Forms.NumericUpDown numMaxVolume;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Timer timer;
    }
}

