namespace SATSuma
{
    partial class helpScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpScreen));
            this.panel22 = new System.Windows.Forms.Panel();
            this.lblHelpHeading = new System.Windows.Forms.Label();
            this.textBoxHelpText = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel22.BackgroundImage")));
            this.panel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel22.Controls.Add(this.lblHelpHeading);
            this.panel22.Location = new System.Drawing.Point(10, 10);
            this.panel22.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(443, 23);
            this.panel22.TabIndex = 198;
            // 
            // lblHelpHeading
            // 
            this.lblHelpHeading.AutoSize = true;
            this.lblHelpHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpHeading.ForeColor = System.Drawing.Color.Silver;
            this.lblHelpHeading.Location = new System.Drawing.Point(1, 0);
            this.lblHelpHeading.Name = "lblHelpHeading";
            this.lblHelpHeading.Size = new System.Drawing.Size(181, 19);
            this.lblHelpHeading.TabIndex = 36;
            this.lblHelpHeading.Text = "Help screen heading";
            // 
            // textBoxHelpText
            // 
            this.textBoxHelpText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBoxHelpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelpText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHelpText.ForeColor = System.Drawing.Color.Silver;
            this.textBoxHelpText.Location = new System.Drawing.Point(10, 54);
            this.textBoxHelpText.Multiline = true;
            this.textBoxHelpText.Name = "textBoxHelpText";
            this.textBoxHelpText.ReadOnly = true;
            this.textBoxHelpText.Size = new System.Drawing.Size(560, 721);
            this.textBoxHelpText.TabIndex = 201;
            this.textBoxHelpText.TabStop = false;
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
            this.btnExit.Location = new System.Drawing.Point(542, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 202;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "❌";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // helpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(581, 784);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.textBoxHelpText);
            this.Controls.Add(this.panel22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "helpScreen";
            this.Text = "helpScreen";
            this.Load += new System.EventHandler(this.helpScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.helpScreen_Paint);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label lblHelpHeading;
        private System.Windows.Forms.TextBox textBoxHelpText;
        private System.Windows.Forms.Button btnExit;
    }
}