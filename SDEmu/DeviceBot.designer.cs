namespace Net.Junian.SDEmu
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
            this.txtBotEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.chkEnableBot = new System.Windows.Forms.CheckBox();
            this.btnCompile = new System.Windows.Forms.Button();
            this.lblCompiled = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBotEditor
            // 
            this.txtBotEditor.Enabled = false;
            this.txtBotEditor.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Auto;
            this.txtBotEditor.IsReadOnly = false;
            this.txtBotEditor.Location = new System.Drawing.Point(12, 33);
            this.txtBotEditor.Name = "txtBotEditor";
            this.txtBotEditor.Size = new System.Drawing.Size(529, 345);
            this.txtBotEditor.TabIndex = 0;
            this.txtBotEditor.Text = "//use message as variable\r\n//sample use:\r\n//if(message == \"OK\")\r\n//    return \"YE" +
                "S\";";
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
            // DeviceBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 414);
            this.Controls.Add(this.lblCompiled);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.chkEnableBot);
            this.Controls.Add(this.txtBotEditor);
            this.Name = "DeviceBot";
            this.Text = "DeviceBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceBot_FormClosing);
            this.Load += new System.EventHandler(this.DeviceBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl txtBotEditor;
        private System.Windows.Forms.CheckBox chkEnableBot;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Label lblCompiled;
    }
}