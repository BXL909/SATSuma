namespace SATSuma
{
    partial class settingsScreen
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
            this.btnExitSettings = new System.Windows.Forms.Button();
            this.lblWhatever = new System.Windows.Forms.Label();
            this.lblBitcoinExplorerEndpoints = new System.Windows.Forms.Label();
            this.lblBlockchainInfoEndpoints = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBlockchainExplorerJSON = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBlockchainInfoJSON = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCoingeckoComJSON = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBlockchairComJSON = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAPIGroup1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMempoolLightningJSON = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownAPIGroup2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboAPISelectorForQueries = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNodeStatusLight = new System.Windows.Forms.Label();
            this.lblActiveNode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPIGroup1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPIGroup2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExitSettings
            // 
            this.btnExitSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnExitSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnExitSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(36)))), ((int)(((byte)(4)))));
            this.btnExitSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitSettings.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitSettings.ForeColor = System.Drawing.Color.Gray;
            this.btnExitSettings.Location = new System.Drawing.Point(299, 543);
            this.btnExitSettings.Name = "btnExitSettings";
            this.btnExitSettings.Size = new System.Drawing.Size(66, 30);
            this.btnExitSettings.TabIndex = 2;
            this.btnExitSettings.TabStop = false;
            this.btnExitSettings.Text = "close";
            this.btnExitSettings.UseVisualStyleBackColor = false;
            this.btnExitSettings.Click += new System.EventHandler(this.BtnExitSettings_Click);
            // 
            // lblWhatever
            // 
            this.lblWhatever.AutoSize = true;
            this.lblWhatever.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblWhatever.ForeColor = System.Drawing.Color.Silver;
            this.lblWhatever.Location = new System.Drawing.Point(46, 8);
            this.lblWhatever.Name = "lblWhatever";
            this.lblWhatever.Size = new System.Drawing.Size(240, 18);
            this.lblWhatever.TabIndex = 4;
            this.lblWhatever.Text = "bitcoinexplorer.org endpoints";
            // 
            // lblBitcoinExplorerEndpoints
            // 
            this.lblBitcoinExplorerEndpoints.AutoSize = true;
            this.lblBitcoinExplorerEndpoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitcoinExplorerEndpoints.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBitcoinExplorerEndpoints.ForeColor = System.Drawing.Color.Green;
            this.lblBitcoinExplorerEndpoints.Location = new System.Drawing.Point(18, 7);
            this.lblBitcoinExplorerEndpoints.Name = "lblBitcoinExplorerEndpoints";
            this.lblBitcoinExplorerEndpoints.Size = new System.Drawing.Size(23, 18);
            this.lblBitcoinExplorerEndpoints.TabIndex = 6;
            this.lblBitcoinExplorerEndpoints.Text = "✔️";
            this.lblBitcoinExplorerEndpoints.Click += new System.EventHandler(this.LblBitcoinExplorerEndpoints_Click);
            // 
            // lblBlockchainInfoEndpoints
            // 
            this.lblBlockchainInfoEndpoints.AutoSize = true;
            this.lblBlockchainInfoEndpoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchainInfoEndpoints.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchainInfoEndpoints.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchainInfoEndpoints.Location = new System.Drawing.Point(18, 32);
            this.lblBlockchainInfoEndpoints.Name = "lblBlockchainInfoEndpoints";
            this.lblBlockchainInfoEndpoints.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchainInfoEndpoints.TabIndex = 8;
            this.lblBlockchainInfoEndpoints.Text = "✔️";
            this.lblBlockchainInfoEndpoints.Click += new System.EventHandler(this.LblBlockchainInfoEndpoints_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(46, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "blockchain.info endpoints";
            // 
            // lblBlockchainExplorerJSON
            // 
            this.lblBlockchainExplorerJSON.AutoSize = true;
            this.lblBlockchainExplorerJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchainExplorerJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchainExplorerJSON.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchainExplorerJSON.Location = new System.Drawing.Point(18, 57);
            this.lblBlockchainExplorerJSON.Name = "lblBlockchainExplorerJSON";
            this.lblBlockchainExplorerJSON.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchainExplorerJSON.TabIndex = 10;
            this.lblBlockchainExplorerJSON.Text = "✔️";
            this.lblBlockchainExplorerJSON.Click += new System.EventHandler(this.LblBlockchainExplorerJSON_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(46, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "bitcoinexplorer.org JSON";
            // 
            // lblBlockchainInfoJSON
            // 
            this.lblBlockchainInfoJSON.AutoSize = true;
            this.lblBlockchainInfoJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchainInfoJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchainInfoJSON.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchainInfoJSON.Location = new System.Drawing.Point(18, 82);
            this.lblBlockchainInfoJSON.Name = "lblBlockchainInfoJSON";
            this.lblBlockchainInfoJSON.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchainInfoJSON.TabIndex = 12;
            this.lblBlockchainInfoJSON.Text = "✔️";
            this.lblBlockchainInfoJSON.Click += new System.EventHandler(this.LblBlockchainInfoJSON_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F);
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(46, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "blockchain.info JSON";
            // 
            // lblCoingeckoComJSON
            // 
            this.lblCoingeckoComJSON.AutoSize = true;
            this.lblCoingeckoComJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCoingeckoComJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblCoingeckoComJSON.ForeColor = System.Drawing.Color.Green;
            this.lblCoingeckoComJSON.Location = new System.Drawing.Point(18, 107);
            this.lblCoingeckoComJSON.Name = "lblCoingeckoComJSON";
            this.lblCoingeckoComJSON.Size = new System.Drawing.Size(23, 18);
            this.lblCoingeckoComJSON.TabIndex = 14;
            this.lblCoingeckoComJSON.Text = "✔️";
            this.lblCoingeckoComJSON.Click += new System.EventHandler(this.LblCoingeckoComJSON_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F);
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(46, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 18);
            this.label10.TabIndex = 13;
            this.label10.Text = "coingecko.com JSON";
            // 
            // lblBlockchairComJSON
            // 
            this.lblBlockchairComJSON.AutoSize = true;
            this.lblBlockchairComJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchairComJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchairComJSON.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchairComJSON.Location = new System.Drawing.Point(18, 10);
            this.lblBlockchairComJSON.Name = "lblBlockchairComJSON";
            this.lblBlockchairComJSON.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchairComJSON.TabIndex = 17;
            this.lblBlockchairComJSON.Text = "✔️";
            this.lblBlockchairComJSON.Click += new System.EventHandler(this.LblBlockchairComJSON_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(46, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "blockchair.com JSON";
            // 
            // numericUpDownAPIGroup1
            // 
            this.numericUpDownAPIGroup1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownAPIGroup1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownAPIGroup1.Font = new System.Drawing.Font("Consolas", 9F);
            this.numericUpDownAPIGroup1.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownAPIGroup1.Location = new System.Drawing.Point(18, 157);
            this.numericUpDownAPIGroup1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAPIGroup1.Name = "numericUpDownAPIGroup1";
            this.numericUpDownAPIGroup1.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownAPIGroup1.TabIndex = 18;
            this.numericUpDownAPIGroup1.TabStop = false;
            this.numericUpDownAPIGroup1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAPIGroup1.ValueChanged += new System.EventHandler(this.NumericUpDownAPIGroup1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(87, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Refresh freq. (mins)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMempoolLightningJSON);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericUpDownAPIGroup1);
            this.panel1.Controls.Add(this.lblWhatever);
            this.panel1.Controls.Add(this.lblBitcoinExplorerEndpoints);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblBlockchainInfoEndpoints);
            this.panel1.Controls.Add(this.lblCoingeckoComJSON);
            this.panel1.Controls.Add(this.lblBlockchainExplorerJSON);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblBlockchainInfoJSON);
            this.panel1.ForeColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(18, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 204);
            this.panel1.TabIndex = 20;
            // 
            // lblMempoolLightningJSON
            // 
            this.lblMempoolLightningJSON.AutoSize = true;
            this.lblMempoolLightningJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMempoolLightningJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblMempoolLightningJSON.ForeColor = System.Drawing.Color.Green;
            this.lblMempoolLightningJSON.Location = new System.Drawing.Point(18, 132);
            this.lblMempoolLightningJSON.Name = "lblMempoolLightningJSON";
            this.lblMempoolLightningJSON.Size = new System.Drawing.Size(23, 18);
            this.lblMempoolLightningJSON.TabIndex = 21;
            this.lblMempoolLightningJSON.Text = "✔️";
            this.lblMempoolLightningJSON.Click += new System.EventHandler(this.LblMempoolLightningJSON_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F);
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(46, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "mempool.space⚡JSON";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblBlockchairComJSON);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.numericUpDownAPIGroup2);
            this.panel2.ForeColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(18, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 68);
            this.panel2.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(87, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Refresh freq. (hours)";
            // 
            // numericUpDownAPIGroup2
            // 
            this.numericUpDownAPIGroup2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownAPIGroup2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownAPIGroup2.Font = new System.Drawing.Font("Consolas", 9F);
            this.numericUpDownAPIGroup2.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownAPIGroup2.Location = new System.Drawing.Point(18, 35);
            this.numericUpDownAPIGroup2.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownAPIGroup2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAPIGroup2.Name = "numericUpDownAPIGroup2";
            this.numericUpDownAPIGroup2.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownAPIGroup2.TabIndex = 22;
            this.numericUpDownAPIGroup2.TabStop = false;
            this.numericUpDownAPIGroup2.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownAPIGroup2.ValueChanged += new System.EventHandler(this.NumericUpDownAPIGroup2_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 62);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enable/disable data sources for the Bitcoin/Lightning stats and change their refr" +
    "esh frequencies";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 371);
            this.panel3.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblNodeStatusLight);
            this.panel4.Controls.Add(this.comboAPISelectorForQueries);
            this.panel4.Controls.Add(this.lblActiveNode);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(12, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(353, 128);
            this.panel4.TabIndex = 24;
            // 
            // comboAPISelectorForQueries
            // 
            this.comboAPISelectorForQueries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboAPISelectorForQueries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAPISelectorForQueries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboAPISelectorForQueries.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAPISelectorForQueries.ForeColor = System.Drawing.Color.Silver;
            this.comboAPISelectorForQueries.FormattingEnabled = true;
            this.comboAPISelectorForQueries.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.comboAPISelectorForQueries.Items.AddRange(new object[] {
            "blockstream.info",
            "mempool.space"});
            this.comboAPISelectorForQueries.Location = new System.Drawing.Point(18, 63);
            this.comboAPISelectorForQueries.Name = "comboAPISelectorForQueries";
            this.comboAPISelectorForQueries.Size = new System.Drawing.Size(319, 26);
            this.comboAPISelectorForQueries.TabIndex = 23;
            this.comboAPISelectorForQueries.TabStop = false;
            this.comboAPISelectorForQueries.SelectedIndexChanged += new System.EventHandler(this.ComboAPISelectorForQueries_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(18, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 44);
            this.label7.TabIndex = 22;
            this.label7.Text = "Select API to use for address, transaction and block queries";
            // 
            // lblNodeStatusLight
            // 
            this.lblNodeStatusLight.AutoSize = true;
            this.lblNodeStatusLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNodeStatusLight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodeStatusLight.ForeColor = System.Drawing.Color.Silver;
            this.lblNodeStatusLight.Location = new System.Drawing.Point(97, 99);
            this.lblNodeStatusLight.Name = "lblNodeStatusLight";
            this.lblNodeStatusLight.Size = new System.Drawing.Size(23, 18);
            this.lblNodeStatusLight.TabIndex = 138;
            this.lblNodeStatusLight.Text = "🟢";
            // 
            // lblActiveNode
            // 
            this.lblActiveNode.AutoSize = true;
            this.lblActiveNode.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveNode.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveNode.ForeColor = System.Drawing.Color.Gray;
            this.lblActiveNode.Location = new System.Drawing.Point(18, 101);
            this.lblActiveNode.Name = "lblActiveNode";
            this.lblActiveNode.Size = new System.Drawing.Size(84, 15);
            this.lblActiveNode.TabIndex = 139;
            this.lblActiveNode.Text = "Node status";
            // 
            // settingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CancelButton = this.btnExitSettings;
            this.ClientSize = new System.Drawing.Size(377, 585);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnExitSettings);
            this.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "settingsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "settingsScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsScreen_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Settings_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPIGroup1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPIGroup2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExitSettings;
        private System.Windows.Forms.Label lblWhatever;
        private System.Windows.Forms.Label lblBitcoinExplorerEndpoints;
        private System.Windows.Forms.Label lblBlockchainInfoEndpoints;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBlockchainExplorerJSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBlockchainInfoJSON;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCoingeckoComJSON;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBlockchairComJSON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAPIGroup1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownAPIGroup2;
        private System.Windows.Forms.Label lblMempoolLightningJSON;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboAPISelectorForQueries;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNodeStatusLight;
        private System.Windows.Forms.Label lblActiveNode;
    }
}