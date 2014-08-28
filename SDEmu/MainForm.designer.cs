namespace Net.Junian.SDEmu
{
    partial class MainForm
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
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.mnuMain = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.deviceBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.groupBoxDeviceSettings = new System.Windows.Forms.GroupBox();
        	this.btnRefresh = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.cmbPortNames = new System.Windows.Forms.ComboBox();
        	this.lblComRun = new System.Windows.Forms.Label();
        	this.btnRun = new System.Windows.Forms.Button();
        	this.serialPort = new System.IO.Ports.SerialPort(this.components);
        	this.groupBoxDeviceActivities = new System.Windows.Forms.GroupBox();
        	this.btnTestBot = new System.Windows.Forms.Button();
        	this.radHexadecimal = new System.Windows.Forms.RadioButton();
        	this.radString = new System.Windows.Forms.RadioButton();
        	this.chkNewLine = new System.Windows.Forms.CheckBox();
        	this.txtLog = new System.Windows.Forms.TextBox();
        	this.btnSend = new System.Windows.Forms.Button();
        	this.txtMessage = new System.Windows.Forms.TextBox();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.mnuMain.SuspendLayout();
        	this.groupBoxDeviceSettings.SuspendLayout();
        	this.groupBoxDeviceActivities.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mnuMain
        	// 
        	this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.viewToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.mnuMain.Location = new System.Drawing.Point(0, 0);
        	this.mnuMain.Name = "mnuMain";
        	this.mnuMain.Size = new System.Drawing.Size(494, 24);
        	this.mnuMain.TabIndex = 0;
        	this.mnuMain.Text = "menuStrip1";
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newToolStripMenuItem,
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "&File";
        	// 
        	// newToolStripMenuItem
        	// 
        	this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        	this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        	this.newToolStripMenuItem.Text = "&New...";
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        	this.exitToolStripMenuItem.Text = "E&xit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
        	// 
        	// viewToolStripMenuItem
        	// 
        	this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.deviceBotToolStripMenuItem,
        	        	        	this.alwaysOnTopToolStripMenuItem});
        	this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        	this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.viewToolStripMenuItem.Text = "&View";
        	// 
        	// deviceBotToolStripMenuItem
        	// 
        	this.deviceBotToolStripMenuItem.Name = "deviceBotToolStripMenuItem";
        	this.deviceBotToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.deviceBotToolStripMenuItem.Text = "Device Bot";
        	this.deviceBotToolStripMenuItem.Click += new System.EventHandler(this.deviceBotToolStripMenuItem_Click);
        	// 
        	// alwaysOnTopToolStripMenuItem
        	// 
        	this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
        	this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
        	this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.alwaysOnTopToolStripMenuItem.Text = "Always On &Top";
        	this.alwaysOnTopToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_CheckStateChanged);
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        	this.aboutToolStripMenuItem.Text = "&About";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
        	// 
        	// groupBoxDeviceSettings
        	// 
        	this.groupBoxDeviceSettings.Controls.Add(this.btnRefresh);
        	this.groupBoxDeviceSettings.Controls.Add(this.label1);
        	this.groupBoxDeviceSettings.Controls.Add(this.cmbPortNames);
        	this.groupBoxDeviceSettings.Location = new System.Drawing.Point(12, 36);
        	this.groupBoxDeviceSettings.Name = "groupBoxDeviceSettings";
        	this.groupBoxDeviceSettings.Size = new System.Drawing.Size(292, 64);
        	this.groupBoxDeviceSettings.TabIndex = 8;
        	this.groupBoxDeviceSettings.TabStop = false;
        	this.groupBoxDeviceSettings.Text = "Device Settings";
        	// 
        	// btnRefresh
        	// 
        	this.btnRefresh.Location = new System.Drawing.Point(197, 21);
        	this.btnRefresh.Name = "btnRefresh";
        	this.btnRefresh.Size = new System.Drawing.Size(75, 23);
        	this.btnRefresh.TabIndex = 10;
        	this.btnRefresh.Text = "Refresh";
        	this.toolTip.SetToolTip(this.btnRefresh, "Refresh port names");
        	this.btnRefresh.UseVisualStyleBackColor = true;
        	this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 26);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(65, 13);
        	this.label1.TabIndex = 9;
        	this.label1.Text = "Port Names:";
        	// 
        	// cmbPortNames
        	// 
        	this.cmbPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cmbPortNames.FormattingEnabled = true;
        	this.cmbPortNames.Location = new System.Drawing.Point(83, 23);
        	this.cmbPortNames.Name = "cmbPortNames";
        	this.cmbPortNames.Size = new System.Drawing.Size(108, 21);
        	this.cmbPortNames.TabIndex = 8;
        	this.toolTip.SetToolTip(this.cmbPortNames, "Port names");
        	// 
        	// lblComRun
        	// 
        	this.lblComRun.AutoSize = true;
        	this.lblComRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblComRun.Location = new System.Drawing.Point(391, 57);
        	this.lblComRun.Name = "lblComRun";
        	this.lblComRun.Size = new System.Drawing.Size(85, 16);
        	this.lblComRun.TabIndex = 12;
        	this.lblComRun.Text = "Serial Port:";
        	this.lblComRun.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        	// 
        	// btnRun
        	// 
        	this.btnRun.Location = new System.Drawing.Point(310, 36);
        	this.btnRun.Name = "btnRun";
        	this.btnRun.Size = new System.Drawing.Size(75, 64);
        	this.btnRun.TabIndex = 11;
        	this.btnRun.Text = "&Run";
        	this.btnRun.UseVisualStyleBackColor = true;
        	this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
        	// 
        	// serialPort
        	// 
        	this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
        	this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
        	// 
        	// groupBoxDeviceActivities
        	// 
        	this.groupBoxDeviceActivities.Controls.Add(this.btnTestBot);
        	this.groupBoxDeviceActivities.Controls.Add(this.radHexadecimal);
        	this.groupBoxDeviceActivities.Controls.Add(this.radString);
        	this.groupBoxDeviceActivities.Controls.Add(this.chkNewLine);
        	this.groupBoxDeviceActivities.Controls.Add(this.txtLog);
        	this.groupBoxDeviceActivities.Controls.Add(this.btnSend);
        	this.groupBoxDeviceActivities.Controls.Add(this.txtMessage);
        	this.groupBoxDeviceActivities.Enabled = false;
        	this.groupBoxDeviceActivities.Location = new System.Drawing.Point(12, 106);
        	this.groupBoxDeviceActivities.Name = "groupBoxDeviceActivities";
        	this.groupBoxDeviceActivities.Size = new System.Drawing.Size(470, 353);
        	this.groupBoxDeviceActivities.TabIndex = 9;
        	this.groupBoxDeviceActivities.TabStop = false;
        	this.groupBoxDeviceActivities.Text = "Device Activities";
        	// 
        	// btnTestBot
        	// 
        	this.btnTestBot.Location = new System.Drawing.Point(389, 46);
        	this.btnTestBot.Name = "btnTestBot";
        	this.btnTestBot.Size = new System.Drawing.Size(75, 23);
        	this.btnTestBot.TabIndex = 19;
        	this.btnTestBot.Text = "Test &Bot";
        	this.toolTip.SetToolTip(this.btnTestBot, "Click to send message");
        	this.btnTestBot.UseVisualStyleBackColor = true;
        	this.btnTestBot.Click += new System.EventHandler(this.BtnTestBotClick);
        	// 
        	// radHexadecimal
        	// 
        	this.radHexadecimal.Location = new System.Drawing.Point(58, 18);
        	this.radHexadecimal.Name = "radHexadecimal";
        	this.radHexadecimal.Size = new System.Drawing.Size(88, 24);
        	this.radHexadecimal.TabIndex = 18;
        	this.radHexadecimal.Text = "Hexadecimal";
        	this.radHexadecimal.UseVisualStyleBackColor = true;
        	// 
        	// radString
        	// 
        	this.radString.Checked = true;
        	this.radString.Location = new System.Drawing.Point(6, 18);
        	this.radString.Name = "radString";
        	this.radString.Size = new System.Drawing.Size(57, 24);
        	this.radString.TabIndex = 16;
        	this.radString.TabStop = true;
        	this.radString.Text = "String";
        	this.radString.UseVisualStyleBackColor = true;
        	// 
        	// chkNewLine
        	// 
        	this.chkNewLine.BackColor = System.Drawing.Color.Transparent;
        	this.chkNewLine.Location = new System.Drawing.Point(152, 18);
        	this.chkNewLine.Name = "chkNewLine";
        	this.chkNewLine.Size = new System.Drawing.Size(199, 24);
        	this.chkNewLine.TabIndex = 15;
        	this.chkNewLine.Text = "Add new line at the end of message";
        	this.chkNewLine.UseVisualStyleBackColor = false;
        	// 
        	// txtLog
        	// 
        	this.txtLog.Location = new System.Drawing.Point(6, 75);
        	this.txtLog.Multiline = true;
        	this.txtLog.Name = "txtLog";
        	this.txtLog.ReadOnly = true;
        	this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.txtLog.Size = new System.Drawing.Size(458, 272);
        	this.txtLog.TabIndex = 14;
        	this.toolTip.SetToolTip(this.txtLog, "COM Device Activites Log");
        	// 
        	// btnSend
        	// 
        	this.btnSend.Location = new System.Drawing.Point(308, 46);
        	this.btnSend.Name = "btnSend";
        	this.btnSend.Size = new System.Drawing.Size(75, 23);
        	this.btnSend.TabIndex = 13;
        	this.btnSend.Text = "&Send";
        	this.toolTip.SetToolTip(this.btnSend, "Click to send message");
        	this.btnSend.UseVisualStyleBackColor = true;
        	this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
        	// 
        	// txtMessage
        	// 
        	this.txtMessage.Location = new System.Drawing.Point(6, 48);
        	this.txtMessage.Name = "txtMessage";
        	this.txtMessage.Size = new System.Drawing.Size(292, 20);
        	this.txtMessage.TabIndex = 12;
        	this.toolTip.SetToolTip(this.txtMessage, "Message to send");
        	// 
        	// notifyIcon
        	// 
        	this.notifyIcon.BalloonTipTitle = "SDEmu";
        	this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        	this.notifyIcon.Text = "SDEmu";
        	this.notifyIcon.Visible = true;
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(494, 471);
        	this.Controls.Add(this.lblComRun);
        	this.Controls.Add(this.groupBoxDeviceActivities);
        	this.Controls.Add(this.btnRun);
        	this.Controls.Add(this.groupBoxDeviceSettings);
        	this.Controls.Add(this.mnuMain);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Location = new System.Drawing.Point(-1, -1);
        	this.MainMenuStrip = this.mnuMain;
        	this.MaximizeBox = false;
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "SDEmu";
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
        	this.Load += new System.EventHandler(this.MainForm_Load);
        	this.mnuMain.ResumeLayout(false);
        	this.mnuMain.PerformLayout();
        	this.groupBoxDeviceSettings.ResumeLayout(false);
        	this.groupBoxDeviceSettings.PerformLayout();
        	this.groupBoxDeviceActivities.ResumeLayout(false);
        	this.groupBoxDeviceActivities.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button btnTestBot;
        private System.Windows.Forms.RadioButton radString;
        private System.Windows.Forms.RadioButton radHexadecimal;
        private System.Windows.Forms.CheckBox chkNewLine;

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxDeviceSettings;
        private System.Windows.Forms.Label lblComRun;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortNames;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBoxDeviceActivities;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem deviceBotToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;


    }
}