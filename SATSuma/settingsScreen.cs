using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATSuma
{
    public partial class SettingsScreen : Form
    {
        private bool hasAPISelectorComboBoxJustBeenPainted = true;
        public bool BitcoinExplorerEndpointsEnabled { get; set; }
        public bool BlockchainInfoEndpointsEnabled { get; set; }
        public bool BitcoinExplorerOrgJSONEnabled { get; set; }
        public bool BlockchainInfoJSONEnabled { get; set; }
        public bool CoingeckoComJSONEnabled { get; set; }
        public bool BlockchairComJSONEnabled { get; set; }
        public bool MempoolSpaceLightningJSONEnabled { get; set; }
        public string NodeURL { get; set; }
        public int APIGroup1RefreshInMinsSelection { get; set; } = 1;
        public int APIGroup2RefreshInHoursSelection { get; set; } = 24;
        public static SettingsScreen Instance { get; private set; }
        
        public static void CreateInstance()
        {
            Instance ??= new SettingsScreen();
        }

        public SettingsScreen()
        {
            InitializeComponent();
            comboAPISelectorForQueries.SelectedIndex = 1;
            
        }

        private void Settings_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            CheckBlockchainExplorerApiStatus();
        }

        private void LblBitcoinExplorerEndpoints_Click(object sender, EventArgs e)
          {
              if (lblBitcoinExplorerEndpoints.Text == "✔️")
              {
                  lblBitcoinExplorerEndpoints.ForeColor= Color.Red;
                  lblBitcoinExplorerEndpoints.Text = "❌";
              }
              else
              {
                  lblBitcoinExplorerEndpoints.ForeColor = Color.Green;
                  lblBitcoinExplorerEndpoints.Text = "✔️";
              }
         }

        private void LblBlockchainInfoEndpoints_Click(object sender, EventArgs e)
        {
            if (lblBlockchainInfoEndpoints.Text == "✔️")
            {
                lblBlockchainInfoEndpoints.ForeColor = Color.Red;
                lblBlockchainInfoEndpoints.Text = "❌";
            }
            else
            {
                lblBlockchainInfoEndpoints.ForeColor = Color.Green;
                lblBlockchainInfoEndpoints.Text = "✔️";
            }
        }

        private void LblBlockchainExplorerJSON_Click(object sender, EventArgs e)
        {
            if (lblBlockchainExplorerJSON.Text == "✔️")
            {
                lblBlockchainExplorerJSON.ForeColor = Color.Red;
                lblBlockchainExplorerJSON.Text = "❌";
            }
            else
            {
                lblBlockchainExplorerJSON.ForeColor = Color.Green;
                lblBlockchainExplorerJSON.Text = "✔️";
            }
        }

        private void LblBlockchainInfoJSON_Click(object sender, EventArgs e)
        {
            if (lblBlockchainInfoJSON.Text == "✔️")
            {
                lblBlockchainInfoJSON.ForeColor = Color.Red;
                lblBlockchainInfoJSON.Text = "❌";
            }
            else
            {
                lblBlockchainInfoJSON.ForeColor = Color.Green;
                lblBlockchainInfoJSON.Text = "✔️";
            }
        }

        private void LblCoingeckoComJSON_Click(object sender, EventArgs e)
        {
            if (lblCoingeckoComJSON.Text == "✔️")
            {
                lblCoingeckoComJSON.ForeColor = Color.Red;
                lblCoingeckoComJSON.Text = "❌";
            }
            else
            {
                lblCoingeckoComJSON.ForeColor = Color.Green;
                lblCoingeckoComJSON.Text = "✔️";
            }
        }

        private void LblBlockchairComJSON_Click(object sender, EventArgs e)
        {
            if (lblBlockchairComJSON.Text == "✔️")
            {
                lblBlockchairComJSON.ForeColor = Color.Red;
                lblBlockchairComJSON.Text = "❌";
            }
            else
            {
                lblBlockchairComJSON.ForeColor = Color.Green;
                lblBlockchairComJSON.Text = "✔️";
            }
        }

        private void LblMempoolLightningJSON_Click(object sender, EventArgs e)
        {
            if (lblMempoolLightningJSON.Text == "✔️")
            {
                lblMempoolLightningJSON.ForeColor = Color.Red;
                lblMempoolLightningJSON.Text = "❌";
            }
            else
            {
                lblMempoolLightningJSON.ForeColor = Color.Green;
                lblMempoolLightningJSON.Text = "✔️";
            }
        }

        private void SettingsScreen_FormClosing(object sender, FormClosingEventArgs e)  // make sure all values are passed back to calling screen
        {
            if (lblBitcoinExplorerEndpoints.Text == "✔️")
            {
                BitcoinExplorerEndpointsEnabled = true;
            }
            else
            {
                BitcoinExplorerEndpointsEnabled = false;
            }
            if (lblBlockchainInfoEndpoints.Text == "✔️")
            {
                BlockchainInfoEndpointsEnabled = true;
            }
            else
            {
                BlockchainInfoEndpointsEnabled = false;
            }
            if (lblBlockchainExplorerJSON.Text == "✔️")
            {
                BitcoinExplorerOrgJSONEnabled = true;
            }
            else
            {
                BitcoinExplorerOrgJSONEnabled = false;
            }
            if (lblBlockchainInfoJSON.Text == "✔️")
            {
                BlockchainInfoJSONEnabled = true;
            }
            else
            {
                BlockchainInfoJSONEnabled = false;
            }
            if (lblCoingeckoComJSON.Text == "✔️")
            {
                CoingeckoComJSONEnabled = true;
            }
            else
            {
                CoingeckoComJSONEnabled = false;
            }
            if (lblBlockchairComJSON.Text == "✔️")
            {
                BlockchairComJSONEnabled = true;
            }
            else
            {
                BlockchairComJSONEnabled = false;
            }
            if (lblMempoolLightningJSON.Text == "✔️")
            {
                MempoolSpaceLightningJSONEnabled = true;
            }
            else
            {
                MempoolSpaceLightningJSONEnabled = false;
            }
            if (comboAPISelectorForQueries.SelectedIndex == 0)
            {
                NodeURL = "https://blockstream.info/api/";
            }
            if (comboAPISelectorForQueries.SelectedIndex == 1)
            {
                NodeURL = "https://mempool.space/api/";
            }
        }

        private void NumericUpDownAPIGroup1_ValueChanged(object sender, EventArgs e) // number of mins between refreshes for API group 1 has been changed
        {
            APIGroup1RefreshInMinsSelection = (int)numericUpDownAPIGroup1.Value;
        }

        private void ComboAPISelectorForQueries_SelectedIndexChanged(object sender, EventArgs e) // set the node to be used for user queries
        {
            if (!hasAPISelectorComboBoxJustBeenPainted) // ignore the selectedindexchanged event that occurs during form paint
            {
                if (comboAPISelectorForQueries.SelectedIndex == 0)
                {
                    NodeURL = "https://blockstream.info/api/";
                }
                if (comboAPISelectorForQueries.SelectedIndex == 1)
                {
                NodeURL = "https://mempool.space/api/";
                }
                CheckBlockchainExplorerApiStatus();
            }
            hasAPISelectorComboBoxJustBeenPainted = false; // ignored first event now
        }

        private async void CheckBlockchainExplorerApiStatus()
        {
            using var client = new HttpClient();
            try
            {
                Ping pingSender = new Ping();
                string pingAddress = null;
                if (NodeURL == "https://blockstream.info/api/")
                {
                    pingAddress = "blockstream.info";
                }
                if (NodeURL == "https://mempool.space/api/")
                {
                    pingAddress = "mempool.space";
                }
                if (NodeURL == null)
                {
                    pingAddress = "mempool.space";
                    NodeURL = "https://mempool.space/api/";

                }
                PingReply reply = await pingSender.SendPingAsync(pingAddress);
                if (reply.Status == IPStatus.Success)
                {
                    lblNodeStatusLight.ForeColor = Color.Lime;
                    var displayNodeName = "";
                    if (NodeURL == "https://blockstream.info/api/")
                    {
                        displayNodeName = "Blockstream";
                    }
                    if (NodeURL == "https://mempool.space/api/")
                    {
                        displayNodeName = "Mempool.space";
                    }
                    lblActiveNode.Text = displayNodeName + " status";
                }
                else
                {
                    // API is not online
                    lblNodeStatusLight.ForeColor = Color.Red;
                    var displayNodeName = "";
                    if (NodeURL == "https://blockstream.info/api/")
                    {
                        displayNodeName = "Blockstream";
                    }
                    if (NodeURL == "https://mempool.space/api/")
                    {
                        displayNodeName = "Mempool.space";
                    }
                    lblActiveNode.Text = displayNodeName + " status";
                }
            }
            catch (HttpRequestException)
            {
                // API is not online
                lblNodeStatusLight.ForeColor = Color.Red;
                var displayNodeName = "";
                if (NodeURL == "https://blockstream.info/api/")
                {
                    displayNodeName = "Blockstream";
                }
                if (NodeURL == "https://mempool.space/api/")
                {
                    displayNodeName = "Mempool.space";
                }
                lblActiveNode.Text = displayNodeName + " status";
            }
            lblNodeStatusLight.Location = new Point(lblActiveNode.Location.X + lblActiveNode.Width, lblActiveNode.Location.Y);
        }

    }
}
