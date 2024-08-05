namespace SATSuma
{
    partial class LoadingScreen
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblLoadingStatusHeadline);
            this.panel1.Controls.Add(this.lblLoadingStatus);
            this.panel1.Location = new System.Drawing.Point(0, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 100);
            this.panel1.TabIndex = 2;
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
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SATSuma.Properties.Resources.LoadingBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 754);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoadingScreen";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "overlayForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLoadingStatusHeadline;
        private System.Windows.Forms.Label lblLoadingStatus;
    }
}