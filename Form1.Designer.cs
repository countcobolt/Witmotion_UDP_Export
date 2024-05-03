namespace Motion_Sim
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CMB_Serial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CNT_Button = new System.Windows.Forms.Button();
            this.baudComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.deadzone = new System.Windows.Forms.TrackBar();
            this.txtDeadZone = new System.Windows.Forms.TextBox();
            this.Recalibate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CalAmount = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.NUP_refresh = new System.Windows.Forms.NumericUpDown();
            this.CMB_RELOAD = new System.Windows.Forms.Button();
            this.CHK_MMF = new System.Windows.Forms.CheckBox();
            this.CHK_SWP_X = new System.Windows.Forms.CheckBox();
            this.CHK_SWP_Y = new System.Windows.Forms.CheckBox();
            this.CHK_SWP = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CHK_UDP = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UDPPort = new System.Windows.Forms.NumericUpDown();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CHK_YAW = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deadzone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalAmount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_refresh)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDPPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMB_Serial
            // 
            this.CMB_Serial.FormattingEnabled = true;
            this.CMB_Serial.Location = new System.Drawing.Point(108, 18);
            this.CMB_Serial.Name = "CMB_Serial";
            this.CMB_Serial.Size = new System.Drawing.Size(139, 21);
            this.CMB_Serial.TabIndex = 0;
            this.CMB_Serial.SelectedIndexChanged += new System.EventHandler(this.CMD_Serial_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrate";
            // 
            // CNT_Button
            // 
            this.CNT_Button.Location = new System.Drawing.Point(71, 451);
            this.CNT_Button.Name = "CNT_Button";
            this.CNT_Button.Size = new System.Drawing.Size(188, 32);
            this.CNT_Button.TabIndex = 4;
            this.CNT_Button.Text = "Connect and Broadcast";
            this.CNT_Button.UseVisualStyleBackColor = true;
            this.CNT_Button.Click += new System.EventHandler(this.CNT_Button_Click);
            // 
            // baudComboBox
            // 
            this.baudComboBox.FormattingEnabled = true;
            this.baudComboBox.Location = new System.Drawing.Point(108, 43);
            this.baudComboBox.Name = "baudComboBox";
            this.baudComboBox.Size = new System.Drawing.Size(171, 21);
            this.baudComboBox.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(329, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "Loading...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(255, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Deadzone";
            // 
            // deadzone
            // 
            this.deadzone.Location = new System.Drawing.Point(110, 95);
            this.deadzone.Maximum = 40;
            this.deadzone.Name = "deadzone";
            this.deadzone.Size = new System.Drawing.Size(104, 45);
            this.deadzone.TabIndex = 11;
            this.deadzone.Value = 10;
            this.deadzone.Scroll += new System.EventHandler(this.deadzone_Scroll);
            // 
            // txtDeadZone
            // 
            this.txtDeadZone.Location = new System.Drawing.Point(231, 95);
            this.txtDeadZone.Name = "txtDeadZone";
            this.txtDeadZone.Size = new System.Drawing.Size(49, 20);
            this.txtDeadZone.TabIndex = 12;
            this.txtDeadZone.Text = "0.5";
            // 
            // Recalibate
            // 
            this.Recalibate.Location = new System.Drawing.Point(71, 489);
            this.Recalibate.Name = "Recalibate";
            this.Recalibate.Size = new System.Drawing.Size(188, 32);
            this.Recalibate.TabIndex = 13;
            this.Recalibate.Text = "Recalibrate";
            this.Recalibate.UseVisualStyleBackColor = true;
            this.Recalibate.Click += new System.EventHandler(this.Recalibate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Calibration amount";
            // 
            // CalAmount
            // 
            this.CalAmount.Location = new System.Drawing.Point(111, 45);
            this.CalAmount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.CalAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CalAmount.Name = "CalAmount";
            this.CalAmount.Size = new System.Drawing.Size(170, 20);
            this.CalAmount.TabIndex = 14;
            this.CalAmount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(329, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Refresh time";
            // 
            // NUP_refresh
            // 
            this.NUP_refresh.Location = new System.Drawing.Point(110, 71);
            this.NUP_refresh.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUP_refresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUP_refresh.Name = "NUP_refresh";
            this.NUP_refresh.Size = new System.Drawing.Size(170, 20);
            this.NUP_refresh.TabIndex = 18;
            this.NUP_refresh.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CMB_RELOAD
            // 
            this.CMB_RELOAD.Location = new System.Drawing.Point(253, 18);
            this.CMB_RELOAD.Name = "CMB_RELOAD";
            this.CMB_RELOAD.Size = new System.Drawing.Size(26, 21);
            this.CMB_RELOAD.TabIndex = 19;
            this.CMB_RELOAD.Text = "RELOAD";
            this.CMB_RELOAD.UseVisualStyleBackColor = true;
            this.CMB_RELOAD.Click += new System.EventHandler(this.CMB_RELOAD_Click_1);
            // 
            // CHK_MMF
            // 
            this.CHK_MMF.AutoSize = true;
            this.CHK_MMF.Location = new System.Drawing.Point(15, 19);
            this.CHK_MMF.Name = "CHK_MMF";
            this.CHK_MMF.Size = new System.Drawing.Size(86, 17);
            this.CHK_MMF.TabIndex = 22;
            this.CHK_MMF.Text = "Enable MMF";
            this.CHK_MMF.UseVisualStyleBackColor = true;
            // 
            // CHK_SWP_X
            // 
            this.CHK_SWP_X.AutoSize = true;
            this.CHK_SWP_X.Location = new System.Drawing.Point(159, 19);
            this.CHK_SWP_X.Name = "CHK_SWP_X";
            this.CHK_SWP_X.Size = new System.Drawing.Size(80, 17);
            this.CHK_SWP_X.TabIndex = 23;
            this.CHK_SWP_X.Text = "Invert Pitch";
            this.CHK_SWP_X.UseVisualStyleBackColor = true;
            // 
            // CHK_SWP_Y
            // 
            this.CHK_SWP_Y.AutoSize = true;
            this.CHK_SWP_Y.Location = new System.Drawing.Point(159, 42);
            this.CHK_SWP_Y.Name = "CHK_SWP_Y";
            this.CHK_SWP_Y.Size = new System.Drawing.Size(74, 17);
            this.CHK_SWP_Y.TabIndex = 24;
            this.CHK_SWP_Y.Text = "Invert Roll";
            this.CHK_SWP_Y.UseVisualStyleBackColor = true;
            // 
            // CHK_SWP
            // 
            this.CHK_SWP.AutoSize = true;
            this.CHK_SWP.Location = new System.Drawing.Point(159, 65);
            this.CHK_SWP.Name = "CHK_SWP";
            this.CHK_SWP.Size = new System.Drawing.Size(77, 17);
            this.CHK_SWP.TabIndex = 25;
            this.CHK_SWP.Text = "Invert Yaw";
            this.CHK_SWP.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHK_UDP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.UDPPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 100);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UDP Configuration";
            // 
            // CHK_UDP
            // 
            this.CHK_UDP.AutoSize = true;
            this.CHK_UDP.Location = new System.Drawing.Point(14, 22);
            this.CHK_UDP.Name = "CHK_UDP";
            this.CHK_UDP.Size = new System.Drawing.Size(85, 17);
            this.CHK_UDP.TabIndex = 23;
            this.CHK_UDP.Text = "Enable UDP";
            this.CHK_UDP.UseVisualStyleBackColor = true;
            this.CHK_UDP.CheckedChanged += new System.EventHandler(this.CHK_UDP_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "UDP Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Broadcast IP";
            // 
            // UDPPort
            // 
            this.UDPPort.Enabled = false;
            this.UDPPort.Location = new System.Drawing.Point(113, 46);
            this.UDPPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.UDPPort.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.UDPPort.Name = "UDPPort";
            this.UDPPort.Size = new System.Drawing.Size(170, 20);
            this.UDPPort.TabIndex = 8;
            this.UDPPort.Value = new decimal(new int[] {
            20789,
            0,
            0,
            0});
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(113, 72);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(171, 20);
            this.txtIP.TabIndex = 21;
            this.txtIP.Text = "127.0.0.1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CHK_SWP);
            this.groupBox2.Controls.Add(this.CHK_MMF);
            this.groupBox2.Controls.Add(this.CHK_SWP_Y);
            this.groupBox2.Controls.Add(this.CHK_SWP_X);
            this.groupBox2.Location = new System.Drawing.Point(12, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 88);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MMF Configuration";
            // 
            // CHK_YAW
            // 
            this.CHK_YAW.AutoSize = true;
            this.CHK_YAW.Location = new System.Drawing.Point(12, 22);
            this.CHK_YAW.Name = "CHK_YAW";
            this.CHK_YAW.Size = new System.Drawing.Size(83, 17);
            this.CHK_YAW.TabIndex = 26;
            this.CHK_YAW.Text = "Enable Yaw";
            this.CHK_YAW.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CHK_YAW);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.CalAmount);
            this.groupBox3.Controls.Add(this.NUP_refresh);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDeadZone);
            this.groupBox3.Controls.Add(this.deadzone);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 142);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.CMB_Serial);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.baudComboBox);
            this.groupBox4.Controls.Add(this.CMB_RELOAD);
            this.groupBox4.Location = new System.Drawing.Point(12, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 75);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Device Connection";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 549);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Recalibate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CNT_Button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Witmotion UDP and MMF Tool";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deadzone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalAmount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_refresh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDPPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMB_Serial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CNT_Button;
        private System.Windows.Forms.ComboBox baudComboBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar deadzone;
        private System.Windows.Forms.TextBox txtDeadZone;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button Recalibate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown CalAmount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NUP_refresh;
        private System.Windows.Forms.Button CMB_RELOAD;
        private System.Windows.Forms.CheckBox CHK_MMF;
        private System.Windows.Forms.CheckBox CHK_SWP_Y;
        private System.Windows.Forms.CheckBox CHK_SWP_X;
        private System.Windows.Forms.CheckBox CHK_SWP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHK_UDP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown UDPPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CHK_YAW;
    }
}

