namespace SATSuma
{
    partial class FullSizeLoadingScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoadingStatusHeadline = new System.Windows.Forms.Label();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblSatsumaTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxLoadingAnimation = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblLoadingStatusHeadline);
            this.panel1.Controls.Add(this.lblLoadingStatus);
            this.panel1.Location = new System.Drawing.Point(0, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 100);
            this.panel1.TabIndex = 1;
            // 
            // lblLoadingStatusHeadline
            // 
            this.lblLoadingStatusHeadline.AutoSize = true;
            this.lblLoadingStatusHeadline.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingStatusHeadline.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingStatusHeadline.ForeColor = System.Drawing.Color.White;
            this.lblLoadingStatusHeadline.Location = new System.Drawing.Point(20, 59);
            this.lblLoadingStatusHeadline.Name = "lblLoadingStatusHeadline";
            this.lblLoadingStatusHeadline.Size = new System.Drawing.Size(0, 24);
            this.lblLoadingStatusHeadline.TabIndex = 1;
            // 
            // lblLoadingStatus
            // 
            this.lblLoadingStatus.AutoSize = true;
            this.lblLoadingStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.White;
            this.lblLoadingStatus.Location = new System.Drawing.Point(21, 83);
            this.lblLoadingStatus.Name = "lblLoadingStatus";
            this.lblLoadingStatus.Size = new System.Drawing.Size(0, 17);
            this.lblLoadingStatus.TabIndex = 0;
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentVersion.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentVersion.Location = new System.Drawing.Point(112, 0);
            this.lblCurrentVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(40, 17);
            this.lblCurrentVersion.TabIndex = 260;
            this.lblCurrentVersion.Text = "vn.nn";
            this.lblCurrentVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSatsumaTitle
            // 
            this.lblSatsumaTitle.AutoSize = true;
            this.lblSatsumaTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSatsumaTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsumaTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSatsumaTitle.Location = new System.Drawing.Point(26, 4);
            this.lblSatsumaTitle.Name = "lblSatsumaTitle";
            this.lblSatsumaTitle.Size = new System.Drawing.Size(94, 23);
            this.lblSatsumaTitle.TabIndex = 261;
            this.lblSatsumaTitle.Text = "SATSuma";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBoxLoadingAnimation);
            this.panel2.Controls.Add(this.lblCurrentVersion);
            this.panel2.Controls.Add(this.lblSatsumaTitle);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 43);
            this.panel2.TabIndex = 264;
            // 
            // pictureBoxLoadingAnimation
            // 
            this.pictureBoxLoadingAnimation.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLoadingAnimation.BackgroundImage = global::SATSuma.Properties.Resources.logoNoText;
            this.pictureBoxLoadingAnimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLoadingAnimation.Enabled = false;
            this.pictureBoxLoadingAnimation.InitialImage = global::SATSuma.Properties.Resources.logoNoText;
            this.pictureBoxLoadingAnimation.Location = new System.Drawing.Point(4, 3);
            this.pictureBoxLoadingAnimation.Name = "pictureBoxLoadingAnimation";
            this.pictureBoxLoadingAnimation.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxLoadingAnimation.TabIndex = 148;
            this.pictureBoxLoadingAnimation.TabStop = false;
            // 
            // FullSizeLoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SATSuma.Properties.Resources.FullScreenLoadingBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 754);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FullSizeLoadingScreen";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "overlayForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingAnimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLoadingStatusHeadline;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.PictureBox pictureBoxLoadingAnimation;
        private System.Windows.Forms.Label lblSatsumaTitle;
        private System.Windows.Forms.Panel panel2;
    }
}