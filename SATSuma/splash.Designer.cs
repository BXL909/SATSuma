namespace SATSuma
{
    partial class Splash
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkLabelDownloadUpdate = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.linkLabelSupportProject = new System.Windows.Forms.LinkLabel();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblUpToDate = new System.Windows.Forms.Label();
            this.lblVersionAvailable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SATSuma.Properties.Resources.PnVlfRPD_400x400;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersion.Font = new System.Drawing.Font("Consolas", 6F);
            this.lblVersion.ForeColor = System.Drawing.Color.Silver;
            this.lblVersion.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblVersion.Location = new System.Drawing.Point(149, 28);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(9, 9);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "v";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelDownloadUpdate
            // 
            this.linkLabelDownloadUpdate.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelDownloadUpdate.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.linkLabelDownloadUpdate.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelDownloadUpdate.Location = new System.Drawing.Point(146, 64);
            this.linkLabelDownloadUpdate.Name = "linkLabelDownloadUpdate";
            this.linkLabelDownloadUpdate.Size = new System.Drawing.Size(115, 14);
            this.linkLabelDownloadUpdate.TabIndex = 11;
            this.linkLabelDownloadUpdate.TabStop = true;
            this.linkLabelDownloadUpdate.Text = "DOWNLOAD UPDATE";
            this.linkLabelDownloadUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelDownloadUpdate.Visible = false;
            this.linkLabelDownloadUpdate.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelDownloadUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelDownloadUpdate_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SATSuma.Properties.Resources.SatsumaButton_4;
            this.pictureBox2.Location = new System.Drawing.Point(147, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 150;
            this.pictureBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnExit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnExit.BorderColor = System.Drawing.Color.Empty;
            this.btnExit.BorderRadius = 0;
            this.btnExit.BorderSize = 0;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 5F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(283, 4);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(16, 16);
            this.btnExit.TabIndex = 151;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "❌";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // linkLabelSupportProject
            // 
            this.linkLabelSupportProject.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelSupportProject.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.linkLabelSupportProject.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelSupportProject.Location = new System.Drawing.Point(146, 78);
            this.linkLabelSupportProject.Name = "linkLabelSupportProject";
            this.linkLabelSupportProject.Size = new System.Drawing.Size(115, 14);
            this.linkLabelSupportProject.TabIndex = 152;
            this.linkLabelSupportProject.TabStop = true;
            this.linkLabelSupportProject.Text = "TIPS / DONATE";
            this.linkLabelSupportProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelSupportProject.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabelSupportProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSupportProject_LinkClicked);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErrorMessage.Font = new System.Drawing.Font("Consolas", 6F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorMessage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblErrorMessage.Location = new System.Drawing.Point(149, 41);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(73, 9);
            this.lblErrorMessage.TabIndex = 154;
            this.lblErrorMessage.Text = "An error occurred";
            this.lblErrorMessage.Visible = false;
            // 
            // lblUpToDate
            // 
            this.lblUpToDate.AutoSize = true;
            this.lblUpToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUpToDate.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.lblUpToDate.ForeColor = System.Drawing.Color.Silver;
            this.lblUpToDate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblUpToDate.Location = new System.Drawing.Point(146, 50);
            this.lblUpToDate.Name = "lblUpToDate";
            this.lblUpToDate.Size = new System.Drawing.Size(72, 15);
            this.lblUpToDate.TabIndex = 155;
            this.lblUpToDate.Text = "(UP TO DATE)";
            this.lblUpToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUpToDate.Visible = false;
            // 
            // lblVersionAvailable
            // 
            this.lblVersionAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersionAvailable.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.lblVersionAvailable.ForeColor = System.Drawing.Color.Silver;
            this.lblVersionAvailable.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblVersionAvailable.Location = new System.Drawing.Point(146, 50);
            this.lblVersionAvailable.Name = "lblVersionAvailable";
            this.lblVersionAvailable.Size = new System.Drawing.Size(115, 14);
            this.lblVersionAvailable.TabIndex = 156;
            this.lblVersionAvailable.Text = "vn.nn available";
            this.lblVersionAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersionAvailable.Visible = false;
            // 
            // splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(303, 152);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblVersionAvailable);
            this.Controls.Add(this.lblUpToDate);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.linkLabelSupportProject);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabelDownloadUpdate);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Splash_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel linkLabelDownloadUpdate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabelSupportProject;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblUpToDate;
        private System.Windows.Forms.Label lblVersionAvailable;
        private CustomControls.RJControls.RJButton btnExit;
    }
}