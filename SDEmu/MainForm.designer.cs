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
        	this.panelStopBits = new System.Windows.Forms.Panel();
        	this.radioButtonStopBits2 = new System.Windows.Forms.RadioButton();
        	this.radioButtonStopBits15 = new System.Windows.Forms.RadioButton();
        	this.radioButtonStopBits1 = new System.Windows.Forms.RadioButton();
        	this.label5 = new System.Windows.Forms.Label();
        	this.panelDataBits = new System.Windows.Forms.Panel();
        	this.radioButtonDataBits8 = new System.Windows.Forms.RadioButton();
        	this.radioButtonDataBits7 = new System.Windows.Forms.RadioButton();
        	this.radioButtonDataBits6 = new System.Windows.Forms.RadioButton();
        	this.radioButtonDataBits5 = new System.Windows.Forms.RadioButton();
        	this.label3 = new System.Windows.Forms.Label();
        	this.panel3 = new System.Windows.Forms.Panel();
        	this.label4 = new System.Windows.Forms.Label();
        	this.comboBoxParity = new System.Windows.Forms.ComboBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
        	this.comboBoxPortNames = new System.Windows.Forms.ComboBox();
        	this.buttonRefresh = new System.Windows.Forms.Button();
        	this.labelSelectedPort = new System.Windows.Forms.Label();
        	this.buttonRun = new System.Windows.Forms.Button();
        	this.serialPort = new System.IO.Ports.SerialPort(this.components);
        	this.groupBoxDeviceActivities = new System.Windows.Forms.GroupBox();
        	this.textLog = new System.Windows.Forms.TextBox();
        	this.panel6 = new System.Windows.Forms.Panel();
        	this.checkBoxLF = new System.Windows.Forms.CheckBox();
        	this.checkBoxCR = new System.Windows.Forms.CheckBox();
        	this.radioStringMessage = new System.Windows.Forms.RadioButton();
        	this.buttonTestBot = new System.Windows.Forms.Button();
        	this.textSendMessage = new System.Windows.Forms.TextBox();
        	this.radioHexMessage = new System.Windows.Forms.RadioButton();
        	this.buttonSend = new System.Windows.Forms.Button();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.mnuMain.SuspendLayout();
        	this.groupBoxDeviceSettings.SuspendLayout();
        	this.panelStopBits.SuspendLayout();
        	this.panelDataBits.SuspendLayout();
        	this.panel3.SuspendLayout();
        	this.groupBoxDeviceActivities.SuspendLayout();
        	this.panel6.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mnuMain
        	// 
        	this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.viewToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.mnuMain.Location = new System.Drawing.Point(3, 3);
        	this.mnuMain.Name = "mnuMain";
        	this.mnuMain.Size = new System.Drawing.Size(618, 24);
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
        	this.groupBoxDeviceSettings.Controls.Add(this.panelStopBits);
        	this.groupBoxDeviceSettings.Controls.Add(this.panelDataBits);
        	this.groupBoxDeviceSettings.Controls.Add(this.panel3);
        	this.groupBoxDeviceSettings.Dock = System.Windows.Forms.DockStyle.Top;
        	this.groupBoxDeviceSettings.Location = new System.Drawing.Point(0, 106);
        	this.groupBoxDeviceSettings.Name = "groupBoxDeviceSettings";
        	this.groupBoxDeviceSettings.Size = new System.Drawing.Size(233, 149);
        	this.groupBoxDeviceSettings.TabIndex = 8;
        	this.groupBoxDeviceSettings.TabStop = false;
        	this.groupBoxDeviceSettings.Text = "Device Settings";
        	// 
        	// panelStopBits
        	// 
        	this.panelStopBits.Controls.Add(this.radioButtonStopBits2);
        	this.panelStopBits.Controls.Add(this.radioButtonStopBits15);
        	this.panelStopBits.Controls.Add(this.radioButtonStopBits1);
        	this.panelStopBits.Controls.Add(this.label5);
        	this.panelStopBits.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelStopBits.Location = new System.Drawing.Point(3, 121);
        	this.panelStopBits.Name = "panelStopBits";
        	this.panelStopBits.Size = new System.Drawing.Size(227, 24);
        	this.panelStopBits.TabIndex = 16;
        	// 
        	// radioButtonStopBits2
        	// 
        	this.radioButtonStopBits2.AutoSize = true;
        	this.radioButtonStopBits2.Location = new System.Drawing.Point(157, 3);
        	this.radioButtonStopBits2.Name = "radioButtonStopBits2";
        	this.radioButtonStopBits2.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonStopBits2.TabIndex = 16;
        	this.radioButtonStopBits2.Text = "2";
        	this.radioButtonStopBits2.UseVisualStyleBackColor = true;
        	// 
        	// radioButtonStopBits15
        	// 
        	this.radioButtonStopBits15.AutoSize = true;
        	this.radioButtonStopBits15.Location = new System.Drawing.Point(112, 3);
        	this.radioButtonStopBits15.Name = "radioButtonStopBits15";
        	this.radioButtonStopBits15.Size = new System.Drawing.Size(40, 17);
        	this.radioButtonStopBits15.TabIndex = 15;
        	this.radioButtonStopBits15.Text = "1.5";
        	this.radioButtonStopBits15.UseVisualStyleBackColor = true;
        	// 
        	// radioButtonStopBits1
        	// 
        	this.radioButtonStopBits1.AutoSize = true;
        	this.radioButtonStopBits1.Checked = true;
        	this.radioButtonStopBits1.Location = new System.Drawing.Point(76, 3);
        	this.radioButtonStopBits1.Name = "radioButtonStopBits1";
        	this.radioButtonStopBits1.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonStopBits1.TabIndex = 14;
        	this.radioButtonStopBits1.TabStop = true;
        	this.radioButtonStopBits1.Text = "1";
        	this.radioButtonStopBits1.UseVisualStyleBackColor = true;
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(9, 3);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(52, 13);
        	this.label5.TabIndex = 13;
        	this.label5.Text = "Stop Bits:";
        	// 
        	// panelDataBits
        	// 
        	this.panelDataBits.Controls.Add(this.radioButtonDataBits8);
        	this.panelDataBits.Controls.Add(this.radioButtonDataBits7);
        	this.panelDataBits.Controls.Add(this.radioButtonDataBits6);
        	this.panelDataBits.Controls.Add(this.radioButtonDataBits5);
        	this.panelDataBits.Controls.Add(this.label3);
        	this.panelDataBits.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelDataBits.Location = new System.Drawing.Point(3, 97);
        	this.panelDataBits.Name = "panelDataBits";
        	this.panelDataBits.Size = new System.Drawing.Size(227, 24);
        	this.panelDataBits.TabIndex = 13;
        	// 
        	// radioButtonDataBits8
        	// 
        	this.radioButtonDataBits8.AutoSize = true;
        	this.radioButtonDataBits8.Checked = true;
        	this.radioButtonDataBits8.Location = new System.Drawing.Point(187, 3);
        	this.radioButtonDataBits8.Name = "radioButtonDataBits8";
        	this.radioButtonDataBits8.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonDataBits8.TabIndex = 17;
        	this.radioButtonDataBits8.TabStop = true;
        	this.radioButtonDataBits8.Text = "8";
        	this.radioButtonDataBits8.UseVisualStyleBackColor = true;
        	// 
        	// radioButtonDataBits7
        	// 
        	this.radioButtonDataBits7.AutoSize = true;
        	this.radioButtonDataBits7.Location = new System.Drawing.Point(150, 3);
        	this.radioButtonDataBits7.Name = "radioButtonDataBits7";
        	this.radioButtonDataBits7.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonDataBits7.TabIndex = 16;
        	this.radioButtonDataBits7.Text = "7";
        	this.radioButtonDataBits7.UseVisualStyleBackColor = true;
        	// 
        	// radioButtonDataBits6
        	// 
        	this.radioButtonDataBits6.AutoSize = true;
        	this.radioButtonDataBits6.Location = new System.Drawing.Point(113, 3);
        	this.radioButtonDataBits6.Name = "radioButtonDataBits6";
        	this.radioButtonDataBits6.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonDataBits6.TabIndex = 15;
        	this.radioButtonDataBits6.Text = "6";
        	this.radioButtonDataBits6.UseVisualStyleBackColor = true;
        	// 
        	// radioButtonDataBits5
        	// 
        	this.radioButtonDataBits5.AutoSize = true;
        	this.radioButtonDataBits5.Location = new System.Drawing.Point(76, 3);
        	this.radioButtonDataBits5.Name = "radioButtonDataBits5";
        	this.radioButtonDataBits5.Size = new System.Drawing.Size(31, 17);
        	this.radioButtonDataBits5.TabIndex = 14;
        	this.radioButtonDataBits5.Text = "5";
        	this.radioButtonDataBits5.UseVisualStyleBackColor = true;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(9, 3);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(53, 13);
        	this.label3.TabIndex = 13;
        	this.label3.Text = "Data Bits:";
        	// 
        	// panel3
        	// 
        	this.panel3.Controls.Add(this.label4);
        	this.panel3.Controls.Add(this.comboBoxParity);
        	this.panel3.Controls.Add(this.label6);
        	this.panel3.Controls.Add(this.comboBoxHandshake);
        	this.panel3.Controls.Add(this.label2);
        	this.panel3.Controls.Add(this.comboBoxBaudRate);
        	this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel3.Location = new System.Drawing.Point(3, 16);
        	this.panel3.Name = "panel3";
        	this.panel3.Size = new System.Drawing.Size(227, 81);
        	this.panel3.TabIndex = 14;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(9, 57);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(36, 13);
        	this.label4.TabIndex = 16;
        	this.label4.Text = "Parity:";
        	// 
        	// comboBoxParity
        	// 
        	this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxParity.FormattingEnabled = true;
        	this.comboBoxParity.Items.AddRange(new object[] {
        	        	        	"None",
        	        	        	"RTS/CTS",
        	        	        	"XON/XOFF",
        	        	        	"RTS/CTS+XON/XOFF"});
        	this.comboBoxParity.Location = new System.Drawing.Point(76, 54);
        	this.comboBoxParity.Name = "comboBoxParity";
        	this.comboBoxParity.Size = new System.Drawing.Size(142, 21);
        	this.comboBoxParity.TabIndex = 15;
        	this.toolTip.SetToolTip(this.comboBoxParity, "Port names");
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(9, 34);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(65, 13);
        	this.label6.TabIndex = 14;
        	this.label6.Text = "Handshake:";
        	// 
        	// comboBoxHandshake
        	// 
        	this.comboBoxHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxHandshake.FormattingEnabled = true;
        	this.comboBoxHandshake.Items.AddRange(new object[] {
        	        	        	"None",
        	        	        	"RTS/CTS",
        	        	        	"XON/XOFF",
        	        	        	"RTS/CTS+XON/XOFF"});
        	this.comboBoxHandshake.Location = new System.Drawing.Point(76, 31);
        	this.comboBoxHandshake.Name = "comboBoxHandshake";
        	this.comboBoxHandshake.Size = new System.Drawing.Size(142, 21);
        	this.comboBoxHandshake.TabIndex = 13;
        	this.toolTip.SetToolTip(this.comboBoxHandshake, "Port names");
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(9, 9);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(61, 13);
        	this.label2.TabIndex = 12;
        	this.label2.Text = "Baud Rate:";
        	// 
        	// comboBoxBaudRate
        	// 
        	this.comboBoxBaudRate.FormattingEnabled = true;
        	this.comboBoxBaudRate.Items.AddRange(new object[] {
        	        	        	"600",
        	        	        	"1200",
        	        	        	"2400",
        	        	        	"4800",
        	        	        	"9600",
        	        	        	"14400",
        	        	        	"19200",
        	        	        	"28800",
        	        	        	"38400",
        	        	        	"56000",
        	        	        	"57600",
        	        	        	"115200",
        	        	        	"128000",
        	        	        	"256000"});
        	this.comboBoxBaudRate.Location = new System.Drawing.Point(76, 6);
        	this.comboBoxBaudRate.Name = "comboBoxBaudRate";
        	this.comboBoxBaudRate.Size = new System.Drawing.Size(142, 21);
        	this.comboBoxBaudRate.TabIndex = 11;
        	this.comboBoxBaudRate.Text = "19200";
        	this.toolTip.SetToolTip(this.comboBoxBaudRate, "Port names");
        	this.comboBoxBaudRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBoxBaudRateKeyPress);
        	// 
        	// comboBoxPortNames
        	// 
        	this.comboBoxPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxPortNames.FormattingEnabled = true;
        	this.comboBoxPortNames.Location = new System.Drawing.Point(6, 19);
        	this.comboBoxPortNames.Name = "comboBoxPortNames";
        	this.comboBoxPortNames.Size = new System.Drawing.Size(190, 21);
        	this.comboBoxPortNames.TabIndex = 8;
        	this.toolTip.SetToolTip(this.comboBoxPortNames, "Port names");
        	// 
        	// buttonRefresh
        	// 
        	this.buttonRefresh.Image = global::Net.Junian.SDEmu.Properties.Resources.IconRefresh;
        	this.buttonRefresh.Location = new System.Drawing.Point(202, 16);
        	this.buttonRefresh.Name = "buttonRefresh";
        	this.buttonRefresh.Size = new System.Drawing.Size(26, 26);
        	this.buttonRefresh.TabIndex = 10;
        	this.toolTip.SetToolTip(this.buttonRefresh, "Refresh port names");
        	this.buttonRefresh.UseVisualStyleBackColor = true;
        	this.buttonRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        	// 
        	// labelSelectedPort
        	// 
        	this.labelSelectedPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.labelSelectedPort.Location = new System.Drawing.Point(104, 47);
        	this.labelSelectedPort.Name = "labelSelectedPort";
        	this.labelSelectedPort.Size = new System.Drawing.Size(123, 52);
        	this.labelSelectedPort.TabIndex = 12;
        	this.labelSelectedPort.Text = "Connected Port:";
        	this.labelSelectedPort.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        	// 
        	// buttonRun
        	// 
        	this.buttonRun.Image = global::Net.Junian.SDEmu.Properties.Resources.IconPlay;
        	this.buttonRun.Location = new System.Drawing.Point(6, 46);
        	this.buttonRun.Name = "buttonRun";
        	this.buttonRun.Size = new System.Drawing.Size(92, 53);
        	this.buttonRun.TabIndex = 11;
        	this.buttonRun.Text = "&Run";
        	this.buttonRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.buttonRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        	this.buttonRun.UseVisualStyleBackColor = true;
        	this.buttonRun.Click += new System.EventHandler(this.btnRun_Click);
        	// 
        	// serialPort
        	// 
        	this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
        	this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
        	// 
        	// groupBoxDeviceActivities
        	// 
        	this.groupBoxDeviceActivities.Controls.Add(this.textLog);
        	this.groupBoxDeviceActivities.Controls.Add(this.panel6);
        	this.groupBoxDeviceActivities.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBoxDeviceActivities.Enabled = false;
        	this.groupBoxDeviceActivities.Location = new System.Drawing.Point(236, 27);
        	this.groupBoxDeviceActivities.Name = "groupBoxDeviceActivities";
        	this.groupBoxDeviceActivities.Size = new System.Drawing.Size(385, 411);
        	this.groupBoxDeviceActivities.TabIndex = 9;
        	this.groupBoxDeviceActivities.TabStop = false;
        	this.groupBoxDeviceActivities.Text = "Device Activities";
        	// 
        	// textLog
        	// 
        	this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textLog.Location = new System.Drawing.Point(3, 106);
        	this.textLog.Multiline = true;
        	this.textLog.Name = "textLog";
        	this.textLog.ReadOnly = true;
        	this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.textLog.Size = new System.Drawing.Size(379, 302);
        	this.textLog.TabIndex = 14;
        	this.toolTip.SetToolTip(this.textLog, "COM Device Activites Log");
        	// 
        	// panel6
        	// 
        	this.panel6.Controls.Add(this.checkBoxLF);
        	this.panel6.Controls.Add(this.checkBoxCR);
        	this.panel6.Controls.Add(this.radioStringMessage);
        	this.panel6.Controls.Add(this.buttonTestBot);
        	this.panel6.Controls.Add(this.textSendMessage);
        	this.panel6.Controls.Add(this.radioHexMessage);
        	this.panel6.Controls.Add(this.buttonSend);
        	this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel6.Location = new System.Drawing.Point(3, 16);
        	this.panel6.Name = "panel6";
        	this.panel6.Size = new System.Drawing.Size(379, 90);
        	this.panel6.TabIndex = 20;
        	// 
        	// checkBoxLF
        	// 
        	this.checkBoxLF.AutoSize = true;
        	this.checkBoxLF.Location = new System.Drawing.Point(255, 9);
        	this.checkBoxLF.Name = "checkBoxLF";
        	this.checkBoxLF.Size = new System.Drawing.Size(89, 17);
        	this.checkBoxLF.TabIndex = 21;
        	this.checkBoxLF.Text = "LF | 0x0A | \\n";
        	this.checkBoxLF.UseVisualStyleBackColor = true;
        	// 
        	// checkBoxCR
        	// 
        	this.checkBoxCR.AutoSize = true;
        	this.checkBoxCR.Location = new System.Drawing.Point(158, 9);
        	this.checkBoxCR.Name = "checkBoxCR";
        	this.checkBoxCR.Size = new System.Drawing.Size(90, 17);
        	this.checkBoxCR.TabIndex = 20;
        	this.checkBoxCR.Text = "CR | 0x0D | \\r";
        	this.checkBoxCR.UseVisualStyleBackColor = true;
        	// 
        	// radioStringMessage
        	// 
        	this.radioStringMessage.AutoSize = true;
        	this.radioStringMessage.Location = new System.Drawing.Point(6, 9);
        	this.radioStringMessage.Name = "radioStringMessage";
        	this.radioStringMessage.Size = new System.Drawing.Size(52, 17);
        	this.radioStringMessage.TabIndex = 16;
        	this.radioStringMessage.Text = "String";
        	this.radioStringMessage.UseVisualStyleBackColor = true;
        	// 
        	// buttonTestBot
        	// 
        	this.buttonTestBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonTestBot.Location = new System.Drawing.Point(299, 60);
        	this.buttonTestBot.Name = "buttonTestBot";
        	this.buttonTestBot.Size = new System.Drawing.Size(75, 23);
        	this.buttonTestBot.TabIndex = 19;
        	this.buttonTestBot.Text = "Test &Bot";
        	this.toolTip.SetToolTip(this.buttonTestBot, "Click to send message");
        	this.buttonTestBot.UseVisualStyleBackColor = true;
        	this.buttonTestBot.Click += new System.EventHandler(this.BtnTestBotClick);
        	// 
        	// textSendMessage
        	// 
        	this.textSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.textSendMessage.Location = new System.Drawing.Point(6, 31);
        	this.textSendMessage.Multiline = true;
        	this.textSendMessage.Name = "textSendMessage";
        	this.textSendMessage.Size = new System.Drawing.Size(287, 52);
        	this.textSendMessage.TabIndex = 12;
        	this.toolTip.SetToolTip(this.textSendMessage, "Message to send");
        	// 
        	// radioHexMessage
        	// 
        	this.radioHexMessage.AutoSize = true;
        	this.radioHexMessage.Checked = true;
        	this.radioHexMessage.Location = new System.Drawing.Point(65, 9);
        	this.radioHexMessage.Name = "radioHexMessage";
        	this.radioHexMessage.Size = new System.Drawing.Size(86, 17);
        	this.radioHexMessage.TabIndex = 18;
        	this.radioHexMessage.TabStop = true;
        	this.radioHexMessage.Text = "Hexadecimal";
        	this.radioHexMessage.UseVisualStyleBackColor = true;
        	// 
        	// buttonSend
        	// 
        	this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonSend.Location = new System.Drawing.Point(299, 31);
        	this.buttonSend.Name = "buttonSend";
        	this.buttonSend.Size = new System.Drawing.Size(75, 23);
        	this.buttonSend.TabIndex = 13;
        	this.buttonSend.Text = "&Send";
        	this.toolTip.SetToolTip(this.buttonSend, "Click to send message");
        	this.buttonSend.UseVisualStyleBackColor = true;
        	this.buttonSend.Click += new System.EventHandler(this.btnSend_Click);
        	// 
        	// notifyIcon
        	// 
        	this.notifyIcon.BalloonTipTitle = "SDEmu";
        	this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        	this.notifyIcon.Text = "SDEmu";
        	this.notifyIcon.Visible = true;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.groupBoxDeviceSettings);
        	this.panel1.Controls.Add(this.groupBox1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
        	this.panel1.Location = new System.Drawing.Point(3, 27);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(233, 411);
        	this.panel1.TabIndex = 13;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.comboBoxPortNames);
        	this.groupBox1.Controls.Add(this.buttonRun);
        	this.groupBox1.Controls.Add(this.labelSelectedPort);
        	this.groupBox1.Controls.Add(this.buttonRefresh);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.groupBox1.Location = new System.Drawing.Point(0, 0);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(233, 106);
        	this.groupBox1.TabIndex = 13;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Device Selection";
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(624, 441);
        	this.Controls.Add(this.groupBoxDeviceActivities);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.mnuMain);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Location = new System.Drawing.Point(-1, -1);
        	this.MainMenuStrip = this.mnuMain;
        	this.MinimumSize = new System.Drawing.Size(640, 480);
        	this.Name = "MainForm";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Serial Device Emulator";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
        	this.Load += new System.EventHandler(this.MainForm_Load);
        	this.mnuMain.ResumeLayout(false);
        	this.mnuMain.PerformLayout();
        	this.groupBoxDeviceSettings.ResumeLayout(false);
        	this.panelStopBits.ResumeLayout(false);
        	this.panelStopBits.PerformLayout();
        	this.panelDataBits.ResumeLayout(false);
        	this.panelDataBits.PerformLayout();
        	this.panel3.ResumeLayout(false);
        	this.panel3.PerformLayout();
        	this.groupBoxDeviceActivities.ResumeLayout(false);
        	this.groupBoxDeviceActivities.PerformLayout();
        	this.panel6.ResumeLayout(false);
        	this.panel6.PerformLayout();
        	this.panel1.ResumeLayout(false);
        	this.groupBox1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.CheckBox checkBoxCR;
        private System.Windows.Forms.CheckBox checkBoxLF;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonStopBits1;
        private System.Windows.Forms.RadioButton radioButtonStopBits15;
        private System.Windows.Forms.RadioButton radioButtonStopBits2;
        private System.Windows.Forms.Panel panelStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonDataBits5;
        private System.Windows.Forms.RadioButton radioButtonDataBits6;
        private System.Windows.Forms.RadioButton radioButtonDataBits7;
        private System.Windows.Forms.RadioButton radioButtonDataBits8;
        private System.Windows.Forms.Panel panelDataBits;
        private System.Windows.Forms.Button buttonTestBot;
        private System.Windows.Forms.RadioButton radioStringMessage;
        private System.Windows.Forms.RadioButton radioHexMessage;

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
        private System.Windows.Forms.Label labelSelectedPort;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxPortNames;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBoxDeviceActivities;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textSendMessage;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem deviceBotToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;


    }
}