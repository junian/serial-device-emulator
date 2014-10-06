using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using Net.Junian.SDEmu.Properties;
using System.IO.Ports;
using Net.Junian.SDEmu.Lib;

namespace Net.Junian.SDEmu
{
    public partial class MainForm : Form
    {
        #region Private Attributes

        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private delegate void DataReceived(byte[] message);
        private DataReceived dataReceived;

        #endregion

        #region Properties
        
        public SDEmuScript AutoResponderScript { get; set; }
        
        public int SerialBaudRate
        {
        	get
        	{
        		return int.Parse(comboBoxBaudRate.Text);
        	}
        }
        
        #endregion

        #region Private Methods

        private void SetSelectedPortLabel(string label)
        {
        	labelSelectedPort.Text = string.Format(
        		"Connected Port:{0}{1}", 
        		Environment.NewLine, 
        		//Environment.NewLine,
        		label);
        }
        
        /// <summary>
        /// save app settings
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                Settings.Default.MainFormTopMost = this.TopMost;
                Settings.Default.Save();
                
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Load app settings
        /// </summary>
        private void LoadSettings()
        {
            alwaysOnTopToolStripMenuItem.Checked = Settings.Default.MainFormTopMost;
            this.TopMost = Settings.Default.MainFormTopMost;
            
            if (Settings.Default.DeviceBotEnabled)
            {
                AutoResponderScript = new SDEmuScript();
                AutoResponderScript.Compile(Settings.Default.CurrentBotScript);
            }
        }

        /// <summary>
        /// Exit Application
        /// </summary>
        private void ExitApplication()
        {
            this.Close();
        }

        /// <summary>
        /// Open serial port connection
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        private Boolean OpenSerialPort(string portName)
        {
            try
            {
                CloseSerialPort();
                serialPort.PortName = portName;
                serialPort.Open();
            }
            catch (Exception ex)
            {
                ViewError(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// close serial port connection
        /// </summary>
        private void CloseSerialPort()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {
                ViewError(ex);
            }
        }

        /// <summary>
        /// control state in running mode
        /// </summary>
        private void RunModeControlState()
        {
            groupBoxDeviceSettings.Enabled = false;
            groupBoxDeviceActivities.Enabled = true;
        }

        /// <summary>
        /// control state in idle mode
        /// </summary>
        private void IdleModeControlState()
        {
            textSendMessage.Text = "";
            groupBoxDeviceSettings.Enabled = true;
            groupBoxDeviceActivities.Enabled = false;
        }

        /// <summary>
        /// load all available ports
        /// </summary>
        private void LoadPortNames()
        {
            String[] portNames = SerialPort.GetPortNames();
            Array.Sort(portNames);
            comboBoxPortNames.Items.Clear();
            comboBoxPortNames.Items.AddRange(portNames);
            if (comboBoxPortNames.Items.Count > 0)
            {
                comboBoxPortNames.SelectedIndex = 0;
                buttonRun.Enabled = true;
            }
            else
                buttonRun.Enabled = false;
            string jumlah = comboBoxPortNames.Items.Count > 0 ? comboBoxPortNames.Items.Count.ToString() : "No";
            ShowBallon(jumlah + " port(s) detected.");
        }

        private void ShowBallon(string message)
        {
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(250);
        }

        private void ViewReceivedMessage(byte[] msgBytes)
        {
        	var message = radioStringMessage.Checked ? ComDataConverter.BytesToString(msgBytes) : ComDataConverter.BytesToHexString(msgBytes);
            Log.Warn("[RECEIVED] " + message);
            textLog.AppendText(FormatLogMessage("RECEIVED", message));
            if (Settings.Default.DeviceBotEnabled)
            {
                string response = AutoResponderScript.GetResponse(message);
                Log.Debug(response);
                if (response != "")
                    SendMessage(response);
            }
        }

        public void SendMessage(String message)
        {
            try
            {
            	if(radioStringMessage.Checked)
            		serialPort.Write(
            			string.Format(
            				"{0}{1}{2}",
            				message,
            				checkBoxCR.Checked == true ? "\r" : string.Empty,
            				checkBoxLF.Checked == true ? "\n" : string.Empty));
            	else if(radioHexMessage.Checked)
            	{
            		var byteArr = ComDataConverter.HexStringToBytes(message);
            		
            		var listOfBytes = new List<byte>();
            		listOfBytes.AddRange(byteArr);
            		if(checkBoxCR.Checked == true)
            			listOfBytes.Add(0x0D);
            		if(checkBoxLF.Checked == true)
            			listOfBytes.Add(0x0A);
            		byteArr = listOfBytes.ToArray();
            		
            		message = ComDataConverter.BytesToHexString(byteArr);
            		serialPort.Write(byteArr, 0, byteArr.Length);
            	}
                Log.Warn("[SEND] " + message);
                textLog.AppendText(FormatLogMessage("SEND", message));
            }
            catch (Exception ex)
            {
                ViewError(ex);
            }
        }

        /// <summary>
        /// view error exception
        /// </summary>
        /// <param name="ex"></param>
        private void ViewError(Exception ex)
        {
            Log.Error("[ERROR] " + ex);
            textLog.AppendText(FormatLogMessage("ERROR", ex.Message));
        }

        /// <summary>
        /// Format log message
        /// </summary>
        /// <param name="header"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private String FormatLogMessage(String header, String content)
        {
            return String.Format("[{0}] {1}\r\n{2}\r\n\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff"), header, content);
        }

        #endregion

        /// <summary>
        /// main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadPortNames();
            textLog.AppendText(FormatLogMessage("INFO", "application started"));
            comboBoxHandshake.SelectedIndex = 0;
            SetSelectedPortLabel("-");
            dataReceived = new DataReceived(ViewReceivedMessage);
        }

        private void alwaysOnTopToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (alwaysOnTopToolStripMenuItem.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            CloseSerialPort();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPortNames();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                String portName = (String)comboBoxPortNames.SelectedItem;
                if (buttonRun.Text == "&Run")
                {
                    if (OpenSerialPort(portName))
                    {
                        textLog.AppendText(FormatLogMessage("INFO", portName + " opened"));
                        SetSelectedPortLabel(portName);
                        buttonRun.Text = "&Stop";
                        buttonRun.Image = Resources.IconStop;
                        RunModeControlState();
                    }
                }
                else
                {
                    CloseSerialPort();
                    textLog.AppendText(FormatLogMessage("INFO", labelSelectedPort.Text + " closed"));
                    SetSelectedPortLabel("-");
                    buttonRun.Text = "&Run";
                    buttonRun.Image = Resources.IconPlay;
                    IdleModeControlState();
                }
            }
            catch (Exception ex)
            {
                ViewError(ex);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(textSendMessage.Text);
            textSendMessage.Focus();
            textSendMessage.SelectAll();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        	byte[] message = new byte[serialPort.BytesToRead];
        	int i=0;
        	int j=serialPort.BytesToRead;
        	while(i<j)
        		message[i++] = (byte) serialPort.ReadByte();
            this.Invoke(dataReceived, message);
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Log.Error(e.EventType);
        }

        private void deviceBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DeviceBot().ShowDialog(this);
        }
        
        void BtnTestBotClick(object sender, EventArgs e)
        {
        	if(!Settings.Default.DeviceBotEnabled)
        		return;
        	var message = ComDataConverter.StringToBytes(textSendMessage.Text);
			this.Invoke(dataReceived, message);        	
        }
        
    }
}
