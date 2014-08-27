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
        private delegate void DataReceived(String message);
        private DataReceived dataReceived;

        #endregion

        #region Properties
        public SDEmuScript AutoResponderScript { get; set; }
        #endregion

        #region Private Methods

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
        /// open serial port connection
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
            txtMessage.Enabled = true;
            btnSend.Enabled = true;
            cmbPortNames.Enabled = false;
            btnRefresh.Enabled = false;
        }

        /// <summary>
        /// control state in idle mode
        /// </summary>
        private void IdleModeControlState()
        {
            txtMessage.Text = "";
            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            cmbPortNames.Enabled = true;
            btnRefresh.Enabled = true;
        }

        /// <summary>
        /// load all available ports
        /// </summary>
        private void LoadPortNames()
        {
            String[] portNames = SerialPort.GetPortNames();
            Array.Sort(portNames);
            cmbPortNames.Items.Clear();
            cmbPortNames.Items.AddRange(portNames);
            if (cmbPortNames.Items.Count > 0)
            {
                cmbPortNames.SelectedIndex = 0;
                btnRun.Enabled = true;
            }
            else
                btnRun.Enabled = false;
            string jumlah = cmbPortNames.Items.Count > 0 ? cmbPortNames.Items.Count.ToString() : "No";
            ShowBallon(jumlah + " port(s) detected.");
        }

        private void ShowBallon(string message)
        {
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(250);
        }

        private void ViewReceivedMessage(String message)
        {
            Log.Warn("[RECEIVED] " + message);
            txtLog.AppendText(FormatLogMessage("RECEIVED", message));
            if (Settings.Default.DeviceBotEnabled)
            {
                string response = AutoResponderScript.GetResponse(message);
                Log.Debug(response);
                if (response != "")
                    SendMessage(response);
            }
        }

        private void SendMessage(String message)
        {
            try
            {
            	if(radString.Checked)
            		serialPort.Write(
            			string.Format(
            				"{0}{1}",
            				message,
            				chkNewLine.Checked == true ? Environment.NewLine : string.Empty));
            	else if(radHexadecimal.Checked)
            	{
            		string[] hexValues = txtMessage.Text.Split(' ');
            		var bytes = new List<byte>();
            		foreach(var hex in hexValues)
            		{
            			var hexClean = hex.Trim();
            			if(!string.IsNullOrEmpty(hexClean))
            			{
            				byte byteValue = Convert.ToByte(hexClean, 16);
            				bytes.Add(byteValue);
            			}
            		}
            		var byteArr = bytes.ToArray();
            		serialPort.Write(byteArr, 0, byteArr.Length);
            	}
                Log.Warn("[SEND] " + message);
                txtLog.AppendText(FormatLogMessage("SEND", message));
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
            txtLog.AppendText(FormatLogMessage("ERROR", ex.Message));
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
            txtLog.AppendText(FormatLogMessage("INFO", "application started"));
            lblComRun.Text = "";
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
                String portName = (String)cmbPortNames.SelectedItem;
                if (btnRun.Text == "&Run")
                {
                    if (OpenSerialPort(portName))
                    {
                        txtLog.AppendText(FormatLogMessage("INFO", portName + " opened"));
                        lblComRun.Text = portName;
                        btnRun.Text = "&Stop";
                        RunModeControlState();
                    }
                }
                else
                {
                    CloseSerialPort();
                    txtLog.AppendText(FormatLogMessage("INFO", lblComRun.Text + " closed"));
                    lblComRun.Text = "";
                    btnRun.Text = "&Run";
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
            SendMessage(txtMessage.Text);
            txtMessage.Focus();
            txtMessage.SelectAll();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String message = serialPort.ReadExisting();
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

    }
}
