using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATSuma
{
    public partial class helpScreen : Form
    {
        public helpScreen()
        {
            InitializeComponent();
        }

        private void helpScreen_Load(object sender, EventArgs e)
        {

            if (((SATSuma)this.Owner).GetPanelBlock().Visible == true)
            {
                lblHelpHeading.Text = "Block";
                textBoxHelpText.Text = "Shows all transactions for the provided block. Displays the transaction ID, fee paid, number of transaction inputs and outputs and the amount of bitcoin moved in the transaction. Select a row in the list to view a transaction.\r\n\r\nFurther information related to the selected block includes the block time, count of all transactions included in the block, the block size and weight, the total amount of fees across all transactions in the block, the total block rewards, the minimum, maximum, median fee rate, average fee, the block hash, nonce and the name of the mining pool that mined the block.\r\n\r\nDefinitions:\r\n\r\nHash - \r\nBlock time - \r\nTransaction count - \r\nBlock size - \r\nBlock weight - \r\nTotal fees - \r\nReward - \r\nFee range - \r\nAverage fee - \r\nNonce - \r\nMiner/Pool - \r\nTransaction ID - \r\nFee - \r\nInputs (I/P) - \r\nOutput (O/P) - \r\nAmount - \r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBlockList().Visible == true)
            {
                lblHelpHeading.Text = "Blocks";
            }
            if (((SATSuma)this.Owner).GetPanelAddress().Visible == true)
            {
                lblHelpHeading.Text = "Address";
                textBoxHelpText.Text = "Shows all transactions for the provided Bitcoin address. Supported address formats are P2PKH (legacy), P2SH, P2WPKH (segwit), P2WSH and P2TT (taproot). A valid address will return transactions associated with that address showing the transaction ID, the block in which the transaction was added to the blockchain, the net change to the balance of that address and the number of confirmations that have occurred for that transaction. Select a row to be able to view either the associated transaction or block number.\r\n\r\nBy default, only confirmed transactions are displayed. Selecting 'show all TX' will show both confirmed and unconfirmed transactions, while 'unconfirmed TX' will only show unconfirmed transactions. The address summary and balance will also reflect this selection.\r\n\r\nDefinitions:\r\n\r\nConfirmed unspent (balance) - \r\nConfirmed transaction count - \r\nConfirmed received - \r\nConfirmed spent - \r\nUnconfirmed unspent (balance) - \r\nUnconfirmed transaction count - \r\nUnconfirmed received - \r\nUnconfirmed spent - \r\nTransaction ID - \r\nBlock - \r\nAmount - \r\nConfs - \r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBitcoinDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
            }
            if (((SATSuma)this.Owner).GetPanelLightningDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Lightning dashboard";
            }
        }

        private void helpScreen_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }
    }
}
