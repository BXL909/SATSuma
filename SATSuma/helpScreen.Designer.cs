namespace SATSuma
{
    partial class HelpScreen
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
            this.lblHelpHeading = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelpTextUp = new CustomControls.RJControls.RJButton();
            this.btnHelpTextDown = new CustomControls.RJControls.RJButton();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.webBrowserDocumentation = new System.Windows.Forms.WebBrowser();
            this.pictureBoxSatsumaLogo = new System.Windows.Forms.PictureBox();
            this.panelComboBoxDocumentationContainer = new System.Windows.Forms.Panel();
            this.comboBoxDocumentation = new CustomControls.RJControls.RJComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.externalLinksTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSatsumaLogo)).BeginInit();
            this.panelComboBoxDocumentationContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHelpHeading
            // 
            this.lblHelpHeading.AutoSize = true;
            this.lblHelpHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpHeading.ForeColor = System.Drawing.Color.Silver;
            this.lblHelpHeading.Location = new System.Drawing.Point(38, 15);
            this.lblHelpHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHelpHeading.Name = "lblHelpHeading";
            this.lblHelpHeading.Size = new System.Drawing.Size(149, 17);
            this.lblHelpHeading.TabIndex = 36;
            this.lblHelpHeading.Text = "Help screen heading";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnHelpTextUp);
            this.panel2.Controls.Add(this.btnHelpTextDown);
            this.panel2.Location = new System.Drawing.Point(428, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 527);
            this.panel2.TabIndex = 208;
            // 
            // btnHelpTextUp
            // 
            this.btnHelpTextUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextUp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextUp.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnHelpTextUp.BorderRadius = 0;
            this.btnHelpTextUp.BorderSize = 0;
            this.btnHelpTextUp.FlatAppearance.BorderSize = 0;
            this.btnHelpTextUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpTextUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpTextUp.ForeColor = System.Drawing.Color.White;
            this.btnHelpTextUp.Location = new System.Drawing.Point(4, 0);
            this.btnHelpTextUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelpTextUp.Name = "btnHelpTextUp";
            this.btnHelpTextUp.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnHelpTextUp.Size = new System.Drawing.Size(24, 24);
            this.btnHelpTextUp.TabIndex = 209;
            this.btnHelpTextUp.TabStop = false;
            this.btnHelpTextUp.Text = "▲";
            this.btnHelpTextUp.TextColor = System.Drawing.Color.White;
            this.btnHelpTextUp.UseVisualStyleBackColor = false;
            this.btnHelpTextUp.Click += new System.EventHandler(this.BtnHelpTextUp_Click);
            this.btnHelpTextUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextUp_MouseDown);
            this.btnHelpTextUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextUp_MouseUp);
            // 
            // btnHelpTextDown
            // 
            this.btnHelpTextDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextDown.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextDown.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnHelpTextDown.BorderRadius = 0;
            this.btnHelpTextDown.BorderSize = 0;
            this.btnHelpTextDown.FlatAppearance.BorderSize = 0;
            this.btnHelpTextDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpTextDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpTextDown.ForeColor = System.Drawing.Color.White;
            this.btnHelpTextDown.Location = new System.Drawing.Point(4, 500);
            this.btnHelpTextDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelpTextDown.Name = "btnHelpTextDown";
            this.btnHelpTextDown.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnHelpTextDown.Size = new System.Drawing.Size(24, 24);
            this.btnHelpTextDown.TabIndex = 207;
            this.btnHelpTextDown.TabStop = false;
            this.btnHelpTextDown.Text = "▼";
            this.btnHelpTextDown.TextColor = System.Drawing.Color.White;
            this.btnHelpTextDown.UseVisualStyleBackColor = false;
            this.btnHelpTextDown.Click += new System.EventHandler(this.BtnHelpTextDown_Click);
            this.btnHelpTextDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextDown_MouseDown);
            this.btnHelpTextDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextDown_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnExit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnExit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExit.BorderRadius = 0;
            this.btnExit.BorderSize = 0;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(195, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(24, 24);
            this.btnExit.TabIndex = 202;
            this.btnExit.Text = "❌";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // webBrowserDocumentation
            // 
            this.webBrowserDocumentation.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserDocumentation.Location = new System.Drawing.Point(-2, 0);
            this.webBrowserDocumentation.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserDocumentation.Name = "webBrowserDocumentation";
            this.webBrowserDocumentation.ScriptErrorsSuppressed = true;
            this.webBrowserDocumentation.Size = new System.Drawing.Size(455, 548);
            this.webBrowserDocumentation.TabIndex = 209;
            this.webBrowserDocumentation.Url = new System.Uri("https://satsuma.btcdir.org/help-introduction/", System.UriKind.Absolute);
            this.webBrowserDocumentation.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowserDocumentation_DocumentCompleted);
            // 
            // pictureBoxSatsumaLogo
            // 
            this.pictureBoxSatsumaLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSatsumaLogo.Image = global::SATSuma.Properties.Resources.tinylogo1;
            this.pictureBoxSatsumaLogo.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxSatsumaLogo.Name = "pictureBoxSatsumaLogo";
            this.pictureBoxSatsumaLogo.Size = new System.Drawing.Size(20, 22);
            this.pictureBoxSatsumaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSatsumaLogo.TabIndex = 255;
            this.pictureBoxSatsumaLogo.TabStop = false;
            // 
            // panelComboBoxDocumentationContainer
            // 
            this.panelComboBoxDocumentationContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelComboBoxDocumentationContainer.Controls.Add(this.comboBoxDocumentation);
            this.panelComboBoxDocumentationContainer.Location = new System.Drawing.Point(39, 0);
            this.panelComboBoxDocumentationContainer.Name = "panelComboBoxDocumentationContainer";
            this.panelComboBoxDocumentationContainer.Size = new System.Drawing.Size(152, 24);
            this.panelComboBoxDocumentationContainer.TabIndex = 256;
            // 
            // comboBoxDocumentation
            // 
            this.comboBoxDocumentation.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxDocumentation.BackgroundImage = global::SATSuma.Properties.Resources.helpselectDropdown;
            this.comboBoxDocumentation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comboBoxDocumentation.BorderColor = System.Drawing.Color.Transparent;
            this.comboBoxDocumentation.BorderSize = 0;
            this.comboBoxDocumentation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocumentation.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDocumentation.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxDocumentation.IconColor = System.Drawing.Color.White;
            this.comboBoxDocumentation.Items.AddRange(new object[] {
            "blocks",
            "block",
            "address transactions",
            "address utxo\'s",
            "transaction",
            "xpub",
            "charts",
            "bitcoin dashboard",
            "lightning dashboard",
            "bookmarks",
            "dca calculator",
            "btc/fiat converter",
            "directory",
            "settings",
            "themes",
            "──────────────────",
            "release notes",
            "faq",
            "source code",
            "support SATSuma"});
            this.comboBoxDocumentation.ListBackColor = System.Drawing.Color.Black;
            this.comboBoxDocumentation.ListTextColor = System.Drawing.Color.DimGray;
            this.comboBoxDocumentation.Location = new System.Drawing.Point(6, 0);
            this.comboBoxDocumentation.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxDocumentation.MinimumSize = new System.Drawing.Size(96, 24);
            this.comboBoxDocumentation.Name = "comboBoxDocumentation";
            this.comboBoxDocumentation.Size = new System.Drawing.Size(140, 24);
            this.comboBoxDocumentation.TabIndex = 254;
            this.comboBoxDocumentation.Texts = "Select topic";
            this.comboBoxDocumentation.OnSelectedIndexChanged += new System.EventHandler(this.ComboBoxDocumentation_OnSelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.webBrowserDocumentation);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 526);
            this.panel1.TabIndex = 257;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel5.Location = new System.Drawing.Point(0, 528);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 20);
            this.panel5.TabIndex = 258;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(10, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 554);
            this.panel3.TabIndex = 258;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.panelComboBoxDocumentationContainer);
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Location = new System.Drawing.Point(246, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 24);
            this.panel4.TabIndex = 259;
            // 
            // externalLinksTimer
            // 
            this.externalLinksTimer.Interval = 1000;
            this.externalLinksTimer.Tick += new System.EventHandler(this.ExternalLinksTimer_Tick);
            // 
            // HelpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(474, 588);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxSatsumaLogo);
            this.Controls.Add(this.lblHelpHeading);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "HelpScreen";
            this.Text = "helpScreen";
            this.Load += new System.EventHandler(this.HelpScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HelpScreen_Paint);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSatsumaLogo)).EndInit();
            this.panelComboBoxDocumentationContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHelpHeading;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.RJControls.RJButton btnExit;
        private CustomControls.RJControls.RJButton btnHelpTextDown;
        private CustomControls.RJControls.RJButton btnHelpTextUp;
        private System.Windows.Forms.PictureBox pictureBoxSatsumaLogo;
        private System.Windows.Forms.WebBrowser webBrowserDocumentation;
        private System.Windows.Forms.Panel panelComboBoxDocumentationContainer;
        private CustomControls.RJControls.RJComboBox comboBoxDocumentation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer externalLinksTimer;
        private System.Windows.Forms.Panel panel5;
    }
}