namespace Juniansoft.SDEmu
{
    partial class DeviceBot
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceBot));
        	this.chkEnableBot = new System.Windows.Forms.CheckBox();
        	this.btnCompile = new System.Windows.Forms.Button();
        	this.lblCompiled = new System.Windows.Forms.Label();
        	this.txtBotEditor = new FastColoredTextBoxNS.FastColoredTextBox();
        	((System.ComponentModel.ISupportInitialize)(this.txtBotEditor)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// chkEnableBot
        	// 
        	this.chkEnableBot.AutoSize = true;
        	this.chkEnableBot.Location = new System.Drawing.Point(12, 10);
        	this.chkEnableBot.Name = "chkEnableBot";
        	this.chkEnableBot.Size = new System.Drawing.Size(78, 17);
        	this.chkEnableBot.TabIndex = 1;
        	this.chkEnableBot.Text = "Enable Bot";
        	this.chkEnableBot.UseVisualStyleBackColor = true;
        	this.chkEnableBot.CheckedChanged += new System.EventHandler(this.chkEnableBot_CheckedChanged);
        	// 
        	// btnCompile
        	// 
        	this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCompile.Location = new System.Drawing.Point(466, 384);
        	this.btnCompile.Name = "btnCompile";
        	this.btnCompile.Size = new System.Drawing.Size(75, 23);
        	this.btnCompile.TabIndex = 2;
        	this.btnCompile.Text = "&Compile";
        	this.btnCompile.UseVisualStyleBackColor = true;
        	this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
        	// 
        	// lblCompiled
        	// 
        	this.lblCompiled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.lblCompiled.AutoSize = true;
        	this.lblCompiled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblCompiled.ForeColor = System.Drawing.Color.LimeGreen;
        	this.lblCompiled.Location = new System.Drawing.Point(403, 389);
        	this.lblCompiled.Name = "lblCompiled";
        	this.lblCompiled.Size = new System.Drawing.Size(57, 13);
        	this.lblCompiled.TabIndex = 3;
        	this.lblCompiled.Text = "compiled";
        	this.lblCompiled.Visible = false;
        	// 
        	// txtBotEditor
        	// 
        	this.txtBotEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtBotEditor.AutoCompleteBracketsList = new char[] {
        	        	'(',
        	        	')',
        	        	'{',
        	        	'}',
        	        	'[',
        	        	']',
        	        	'\"',
        	        	'\"',
        	        	'\'',
        	        	'\''};
        	this.txtBotEditor.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
        	"*(?<range>:)\\s*(?<range>[^;]+);\r\n";
        	this.txtBotEditor.AutoScrollMinSize = new System.Drawing.Size(227, 70);
        	this.txtBotEditor.BackBrush = null;
        	this.txtBotEditor.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
        	this.txtBotEditor.CharHeight = 14;
        	this.txtBotEditor.CharWidth = 8;
        	this.txtBotEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.txtBotEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
        	this.txtBotEditor.Enabled = false;
        	this.txtBotEditor.Font = new System.Drawing.Font("Courier New", 9.75F);
        	this.txtBotEditor.IsReplaceMode = false;
        	this.txtBotEditor.Language = FastColoredTextBoxNS.Language.CSharp;
        	this.txtBotEditor.LeftBracket = '(';
        	this.txtBotEditor.LeftBracket2 = '{';
        	this.txtBotEditor.Location = new System.Drawing.Point(12, 33);
        	this.txtBotEditor.Name = "txtBotEditor";
        	this.txtBotEditor.Paddings = new System.Windows.Forms.Padding(0);
        	this.txtBotEditor.RightBracket = ')';
        	this.txtBotEditor.RightBracket2 = '}';
        	this.txtBotEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
        	this.txtBotEditor.Size = new System.Drawing.Size(529, 345);
        	this.txtBotEditor.TabIndex = 4;
        	this.txtBotEditor.Text = "//use message as variable\r\n//sample use:\r\n//if(message == \"OK\")\r\n//    return \"YE" +
        	"S\";\r\n";
        	this.txtBotEditor.Zoom = 100;
        	// 
        	// DeviceBot
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(553, 414);
        	this.Controls.Add(this.txtBotEditor);
        	this.Controls.Add(this.lblCompiled);
        	this.Controls.Add(this.btnCompile);
        	this.Controls.Add(this.chkEnableBot);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "DeviceBot";
        	this.Text = "DeviceBot";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceBot_FormClosing);
        	this.Load += new System.EventHandler(this.DeviceBot_Load);
        	((System.ComponentModel.ISupportInitialize)(this.txtBotEditor)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txtBotEditor;
        private System.Windows.Forms.CheckBox chkEnableBot;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Label lblCompiled;
    }
}