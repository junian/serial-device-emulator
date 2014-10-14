using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.CodeDom.Compiler;
using Net.Junian.SDEmu.Properties;

namespace Net.Junian.SDEmu
{
    public partial class DeviceBot : Form
    {
        #region Private Variables

        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SDEmuScript sdemuScript;
        private bool compiled = false;

        #endregion

        #region Private Method

        private bool Compile()
        {
            if (!compiled)
            {
                if (sdemuScript.Compile(txtBotEditor.Text))
                {
                    compiled = true;
                    lblCompiled.Visible = true;
                }
                else
                {
                    String s = "\n";
                    foreach (CompilerError ce in sdemuScript.Errors)
                    {
                        s += ce.Line + ". " + ce.ErrorText + "\n";
                    }
                    Log.Error(s);
                }
            }
            return compiled;
        }

        private void LoadData()
        {
            chkEnableBot.Checked = Settings.Default.DeviceBotEnabled;
            txtBotEditor.Text = Settings.Default.CurrentBotScript;
        }

        private void SaveData()
        {
            Settings.Default.DeviceBotEnabled = chkEnableBot.Checked;
            Settings.Default.CurrentBotScript = txtBotEditor.Text;
            Settings.Default.Save();
        }
        #endregion

        public DeviceBot()
        {
            InitializeComponent();
        }

        private void chkEnableBot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableBot.Checked)
            {
                txtBotEditor.Enabled = true;
                btnCompile.Enabled = true;
            }
            else
            {
                txtBotEditor.Enabled = false;
                btnCompile.Enabled = false;
            }
        }

        private void DeviceBot_Load(object sender, EventArgs e)
        {
            LoadData();
            txtBotEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            txtBotEditor.TextChanged += new EventHandler(txtBotEditor_TextChanged);
            
            sdemuScript = new SDEmuScript();
        }

        void txtBotEditor_TextChanged(object sender, EventArgs e)
        {
            compiled = false;
            lblCompiled.Visible = false;
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            if (!Compile())
                MessageBox.Show("compile error!!!");
            else
                MessageBox.Show(sdemuScript.GetResponse("great"));
        }

        private void DeviceBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkEnableBot.Checked)
            {
                if (Compile())
                {
                    MainForm mf = (MainForm)this.Owner;
                    mf.AutoResponderScript = sdemuScript;
                }
                else
                {
                    MessageBox.Show("compile error!!!");
                    e.Cancel = true;
                    return;
                }
            }
            SaveData();
        }
    }
}
