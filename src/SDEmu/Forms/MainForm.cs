using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Juniansoft.SDEmu.Configs;
using Juniansoft.SDEmu.Properties;
using Juniansoft.SDEmu.Services;
using Juniansoft.SDEmu.Utilities;

namespace Juniansoft.SDEmu.Forms
{
    public partial class MainForm : Form
    {
    	public const int DefaultSerialDataBits = 8;
    	public const StopBits DefaultSerialStopBits = StopBits.One;
    	
        #region Private Attributes

        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private delegate void DataReceived(byte[] message);
        private DataReceived dataReceived;
        private BindingSource bindingSource;
        private BindingSource serialSettingBindingSource;

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
        
        public Handshake SerialHandshake
        {
        	get
        	{
        		return (Handshake) comboBoxHandshake.SelectedItem;
        	}
        }
        
        public Parity SerialParity
        {
        	get
        	{
        		return (Parity) comboBoxParity.SelectedItem;
        	}
        }
        
        public int SerialDataBits
        {
        	get
        	{
        		foreach(var control in panelDataBits.Controls)
        		{
        			if(control is RadioButton)
        			{
        				var radioButton = (RadioButton) control;
        				if(radioButton.Checked)
        					return int.Parse(radioButton.Text);
        			}
        		}
        		return DefaultSerialDataBits;
        	}
        	set
        	{
        		foreach(var control in panelDataBits.Controls)
        		{
        			if(control is RadioButton)
        			{
        				var radioButton = (RadioButton) control;
        				if(int.Parse(radioButton.Text) == value)
        				{
        					radioButton.Checked = true;
        					return;
        				}
        			}
        		}
        	}
        }
        
        public StopBits SerialStopBits
        {
        	get
        	{
        		foreach(var control in panelStopBits.Controls)
        		{
        			if(control is RadioButton)
        			{
        				var radioButton = (RadioButton) control;
        				if(radioButton.Checked)
        					return (StopBits) radioButton.Tag;
        			}
        		}
        		return DefaultSerialStopBits;
        	}
        	set
        	{
        		foreach(var control in panelStopBits.Controls)
        		{
        			if(control is RadioButton)
        			{
        				var radioButton = (RadioButton) control;
        				if(value == (StopBits) radioButton.Tag)
        				{
        					radioButton.Checked = true;
        					return;
        				}
        			}
        		}
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
				if(serialPort.IsOpen)
				{
					serialPort.DiscardOutBuffer();
					serialPort.DiscardInBuffer();
					serialPort.Close();
				}
			}
			catch(Exception ex)
			{
				ViewError(ex);
				return;
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
            notifyIcon.Icon = Resources.Favicon;
            notifyIcon.BalloonTipTitle = AssemblyService.Current.Product;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;

            notifyIcon.ShowBalloonTip(250);
        }

        private void ViewReceivedMessage(byte[] msgBytes)
        {
        	var message = radioStringMessage.Checked ? SerialDataConverter.BytesToString(msgBytes) : SerialDataConverter.BytesToHexString(msgBytes);
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
            		var byteArr = SerialDataConverter.HexStringToBytes(message);
            		
            		var listOfBytes = new List<byte>();
            		listOfBytes.AddRange(byteArr);
            		if(checkBoxCR.Checked == true)
            			listOfBytes.Add(0x0D);
            		if(checkBoxLF.Checked == true)
            			listOfBytes.Add(0x0A);
            		byteArr = listOfBytes.ToArray();
            		
            		message = SerialDataConverter.BytesToHexString(byteArr);
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

        private readonly AssemblyService _assemblyService;

        /// <summary>
        /// main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _assemblyService = AssemblyService.Current;

            this.Icon = Resources.Favicon;
            this.notifyIcon.Icon = Resources.Favicon;
            this.Text = $"{_assemblyService.Product} v{_assemblyService.Version.ToString(3)}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadPortNames();
            
            textLog.AppendText(FormatLogMessage("INFO", "application started"));
            SetSelectedPortLabel("-");
            dataReceived = new DataReceived(ViewReceivedMessage);
            
            comboBoxPortNames.DataBindings.Add("Enabled", groupBoxDeviceSettings, "Enabled");
            buttonRefresh.DataBindings.Add("Enabled", groupBoxDeviceSettings, "Enabled");
            comboBoxParity.DataSource = (Parity[]) Enum.GetValues(typeof(Parity));
            comboBoxHandshake.DataSource = (Handshake[]) Enum.GetValues(typeof(Handshake));
            
            //initialize StopBits inside radioButton Tag
            radioButtonStopBits1.Tag = StopBits.One;
            radioButtonStopBits15.Tag = StopBits.OnePointFive;
            radioButtonStopBits2.Tag = StopBits.Two;
            
            AppSettings.Instance.LoadCurrentAppSettings();
            
            bindingSource = new BindingSource();
            bindingSource.DataSource = AppSettings.Instance.SDEmuSetting;
            serialSettingBindingSource = new BindingSource();
            serialSettingBindingSource.DataSource = AppSettings.Instance.SDEmuSetting.SerialSetting;
            
            this.DataBindings.Add("SerialStopBits", serialSettingBindingSource, "StopBits");
            this.DataBindings.Add("SerialDataBits", serialSettingBindingSource, "DataBits");
            
            comboBoxBaudRate.DataBindings.Add("Text", serialSettingBindingSource, "BaudRate");
            comboBoxParity.DataBindings.Add("SelectedItem", serialSettingBindingSource, "Parity");
            comboBoxHandshake.DataBindings.Add("SelectedItem", serialSettingBindingSource, "Handshake");
            
            radioStringMessage.DataBindings.Add("Checked", bindingSource, "IsStringMode");
            radioHexMessage.DataBindings.Add("Checked", bindingSource, "IsHexMode");
            
            checkBoxCR.DataBindings.Add("Checked", bindingSource, "IsEndedWithCR");
            checkBoxLF.DataBindings.Add("Checked", bindingSource, "IsEndedWithLF");
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
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
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
                	serialPort.BaudRate = SerialBaudRate;
                	serialPort.Handshake = SerialHandshake;
                	serialPort.Parity = SerialParity;
                	serialPort.DataBits = SerialDataBits;
                	serialPort.StopBits = SerialStopBits;
                	
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
                	var thread = new Thread(delegate()
                    {
	                    CloseSerialPort();
	                    this.Invoke((MethodInvoker) delegate()
                     	{
		                    textLog.AppendText(FormatLogMessage("INFO", labelSelectedPort.Text + " closed"));
		                    SetSelectedPortLabel("-");
		                    buttonRun.Text = "&Run";
		                    buttonRun.Image = Resources.IconPlay;
		                    IdleModeControlState();
                        });
                	});
                	thread.Start();
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
            new DeviceBotForm().ShowDialog(this);
        }
        
        void BtnTestBotClick(object sender, EventArgs e)
        {
        	if(!Settings.Default.DeviceBotEnabled)
        		return;
        	var message = SerialDataConverter.StringToBytes(textSendMessage.Text);
			this.Invoke(dataReceived, message);        	
        }
        
        void ComboBoxBaudRateKeyPress(object sender, KeyPressEventArgs e)
        {
        	if(!char.IsControl(e.KeyChar) 
		        && !char.IsDigit(e.KeyChar))
		    {
		        e.Handled = true;
		    }
        }
        
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
        	AppSettings.Instance.SDEmuSetting.SerialSetting.DataBits = SerialDataBits;
        	AppSettings.Instance.SDEmuSetting.SerialSetting.StopBits = SerialStopBits;
        	AppSettings.Instance.SaveCurrentAppSettings();
        	var thr = new Thread(CloseSerialPort);
			thr.Start();
        }
        
    }
}
