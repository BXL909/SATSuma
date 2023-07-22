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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpScreen));
            this.panel22 = new System.Windows.Forms.Panel();
            this.lblHelpHeading = new System.Windows.Forms.Label();
            this.textBoxHelpText = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelpTextDown = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelpTextUp = new System.Windows.Forms.Button();
            this.comboBoxSelectHelp = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel22.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel22.Controls.Add(this.lblHelpHeading);
            this.panel22.Location = new System.Drawing.Point(8, 8);
            this.panel22.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(394, 19);
            this.panel22.TabIndex = 198;
            // 
            // lblHelpHeading
            // 
            this.lblHelpHeading.AutoSize = true;
            this.lblHelpHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpHeading.ForeColor = System.Drawing.Color.Silver;
            this.lblHelpHeading.Location = new System.Drawing.Point(1, 0);
            this.lblHelpHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHelpHeading.Name = "lblHelpHeading";
            this.lblHelpHeading.Size = new System.Drawing.Size(149, 17);
            this.lblHelpHeading.TabIndex = 36;
            this.lblHelpHeading.Text = "Help screen heading";
            // 
            // textBoxHelpText
            // 
            this.textBoxHelpText.BackColor = System.Drawing.Color.Black;
            this.textBoxHelpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelpText.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxHelpText.Enabled = false;
            this.textBoxHelpText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHelpText.ForeColor = System.Drawing.Color.Silver;
            this.textBoxHelpText.Location = new System.Drawing.Point(0, 4);
            this.textBoxHelpText.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHelpText.Multiline = true;
            this.textBoxHelpText.Name = "textBoxHelpText";
            this.textBoxHelpText.ReadOnly = true;
            this.textBoxHelpText.Size = new System.Drawing.Size(398, 548);
            this.textBoxHelpText.TabIndex = 201;
            this.textBoxHelpText.TabStop = false;
            this.textBoxHelpText.TextChanged += new System.EventHandler(this.TextBoxHelpText_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(406, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(22, 24);
            this.btnExit.TabIndex = 202;
            this.btnExit.Text = "❌";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textBoxHelpText);
            this.panel1.Location = new System.Drawing.Point(8, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 563);
            this.panel1.TabIndex = 204;
            // 
            // btnHelpTextDown
            // 
            this.btnHelpTextDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnHelpTextDown.FlatAppearance.BorderSize = 0;
            this.btnHelpTextDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelpTextDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelpTextDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpTextDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpTextDown.ForeColor = System.Drawing.Color.White;
            this.btnHelpTextDown.Location = new System.Drawing.Point(0, 554);
            this.btnHelpTextDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelpTextDown.Name = "btnHelpTextDown";
            this.btnHelpTextDown.Size = new System.Drawing.Size(22, 24);
            this.btnHelpTextDown.TabIndex = 207;
            this.btnHelpTextDown.TabStop = false;
            this.btnHelpTextDown.Text = "▼";
            this.btnHelpTextDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelpTextDown.UseVisualStyleBackColor = false;
            this.btnHelpTextDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextDown_MouseDown);
            this.btnHelpTextDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextDown_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnHelpTextUp);
            this.panel2.Controls.Add(this.btnHelpTextDown);
            this.panel2.Location = new System.Drawing.Point(406, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 584);
            this.panel2.TabIndex = 208;
            // 
            // btnHelpTextUp
            // 
            this.btnHelpTextUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelpTextUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnHelpTextUp.FlatAppearance.BorderSize = 0;
            this.btnHelpTextUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelpTextUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelpTextUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpTextUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpTextUp.ForeColor = System.Drawing.Color.White;
            this.btnHelpTextUp.Location = new System.Drawing.Point(0, 17);
            this.btnHelpTextUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelpTextUp.Name = "btnHelpTextUp";
            this.btnHelpTextUp.Size = new System.Drawing.Size(22, 24);
            this.btnHelpTextUp.TabIndex = 209;
            this.btnHelpTextUp.TabStop = false;
            this.btnHelpTextUp.Text = "▲";
            this.btnHelpTextUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelpTextUp.UseVisualStyleBackColor = false;
            this.btnHelpTextUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextUp_MouseDown);
            this.btnHelpTextUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnHelpTextUp_MouseUp);
            // 
            // comboBoxSelectHelp
            // 
            this.comboBoxSelectHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxSelectHelp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSelectHelp.ForeColor = System.Drawing.Color.Silver;
            this.comboBoxSelectHelp.FormattingEnabled = true;
            this.comboBoxSelectHelp.Items.AddRange(new object[] {
            "Select...",
            "Recent blocks",
            "Block",
            "Address",
            "Transaction",
            "Xpub",
            "Charts",
            "Bitcoin dashboard",
            "Lightning dashboard",
            "Bookmarks",
            "Directory",
            "Settings",
            "Themes"});
            this.comboBoxSelectHelp.Location = new System.Drawing.Point(11, 630);
            this.comboBoxSelectHelp.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSelectHelp.Name = "comboBoxSelectHelp";
            this.comboBoxSelectHelp.Size = new System.Drawing.Size(128, 21);
            this.comboBoxSelectHelp.TabIndex = 210;
            this.comboBoxSelectHelp.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectHelp_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(8, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 2);
            this.pictureBox1.TabIndex = 219;
            this.pictureBox1.TabStop = false;
            // 
            // HelpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(438, 659);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxSelectHelp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "HelpScreen";
            this.Text = "helpScreen";
            this.Load += new System.EventHandler(this.HelpScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HelpScreen_Paint);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label lblHelpHeading;
        private System.Windows.Forms.TextBox textBoxHelpText;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHelpTextDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHelpTextUp;
        private System.Windows.Forms.ComboBox comboBoxSelectHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}