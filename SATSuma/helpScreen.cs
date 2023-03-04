using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            panel1.VerticalScroll.Visible = false;
            if (((SATSuma)this.Owner).GetPanelBlock().Visible == true)
            {
                lblHelpHeading.Text = "Block";
                textBoxHelpText.Text = "Shows all transactions for the provided block. Displays the transaction ID, fee paid, number of transaction inputs and outputs and the amount of bitcoin moved in the transaction. Select a row in the list to view a transaction.\r\n\r\nFurther information related to the selected block includes the block time, count of all transactions included in the block, the block size and weight, the total amount of fees across all transactions in the block, the total block rewards, the minimum, maximum, median fee rate, average fee, the block hash, nonce and the name of the mining pool that mined the block.\r\n\r\nDefinitions:\r\n\r\nHash - \r\nBlock time - \r\nTransaction count - \r\nBlock size - \r\nBlock weight - \r\nTotal fees - \r\nReward - \r\nFee range - \r\nAverage fee - \r\nNonce - \r\nMiner/Pool - \r\nTransaction ID - \r\nFee - \r\nInputs (I/P) - \r\nOutput (O/P) - \r\nAmount - \r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBlockList().Visible == true)
            {
                lblHelpHeading.Text = "Blocks";
                textBoxHelpText.Text = "Displays 15 blocks starting from the current block height. Enter a block number between 0 (Genesis Block) and the current block height to jump to that point in time or page through the list. Select a row on the list to view the transactions within that block.\r\n\r\nDefinitions:\r\n\r\nDate/time (table) - \r\nHeight (table) - the block height/number of the block. \r\nTX count (table) - the number of transactions that are included within the block.\r\nSize (table) - the size of the block in MB.\r\nFee range (table) - the range of transaction fees within the block (sat/vB)\r\nMed. (table) - median fee.\r\nReward(BTC) (table) - the miner reward comprising the block subsidy plus all transaction fees for the block.\r\nHash - \r\nBlock weight - \r\nNonce - \r\nMiner/Pool - \r\nVersion - \r\nTotal fees - \r\nAverage fee - \r\nTotal inputs - \r\nTotal outputs - \r\nAverage TX size - \r\nTransactions in Mempool - \r\nTransactions in next block - \r\nMin/Max fee in next block - \r\nTotal fees in next block - \r\nAvg attempts to solve block - \r\nNext difficulty adjustment block - \r\nAvg time between blocks - \r\nNext difficulty adjustment - \r\nEst. hashrate - \r\nBlock reward - \r\nHalving block/remaining - \r\n";
            }
            if (((SATSuma)this.Owner).GetPanelAddress().Visible == true)
            {
                lblHelpHeading.Text = "Address";
                textBoxHelpText.Text = "Shows all transactions for the provided Bitcoin address. Supported address formats are P2PKH (legacy), P2SH, P2WPKH (segwit), P2WSH and P2TT (taproot). A valid address will return transactions associated with that address showing the transaction ID, the block in which the transaction was added to the blockchain, the net change to the balance of that address and the number of confirmations that have occurred for that transaction. Select a row to be able to view either the associated transaction or block number.\r\n\r\nBy default, only confirmed transactions are displayed. Selecting 'show all TX' will show both confirmed and unconfirmed transactions, while 'unconfirmed TX' will only show unconfirmed transactions. The address summary and balance will also reflect this selection.\r\n\r\nDefinitions:\r\n\r\nConfirmed unspent (balance) - \r\nConfirmed transaction count - \r\nConfirmed received - \r\nConfirmed spent - \r\nUnconfirmed unspent (balance) - \r\nUnconfirmed transaction count - \r\nUnconfirmed received - \r\nUnconfirmed spent - \r\nTransaction ID - \r\nBlock - \r\nAmount - \r\nConfs - \r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBitcoinDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                textBoxHelpText.Text = "Displays an overview of a variety of key market, usage, mining, etc metrics. The data is refreshed every minute by default. This can be altered in the settings.\r\n\r\nDefinitions:\r\n\r\n1 BTC / USD - the current value of 1 bitcoin denominated in US dollars ($).\r\n\r\nMarket cap (USD) - Bitcoin's market capitalisation i.e the total value of all issued bitcoin.\r\n\r\nChange from ATH - The percentage difference between the current value of bitcoin and its all time high (ATH) value.\r\n\r\n1 USD / Sats - the value of 1 US dollar ($) denominated in sats/satoshis.\r\n\r\nAll time high (USD) - the highest value, denominated in US dollars ($), that bitcoin has reached, along with the date that it occurred.\r\n\r\n24hr high/ 24hr low (USD) - the highest and lowest values of 1 bitcoin over a 24 hour period, denominated in US dollars ($).\r\n\r\nTotal BTC in circulation - the total amount of bitcoin issued so far. This number will increase with each newly mined block until it reaches the hard cap of 21,000,000.\r\n\r\nNumber of holding addresses - the number of unique addresses currently holding an amount of bitcoin.\r\n\r\nAvg transactions per block - the average number of transactions included in a block, calculated over the previous 100 blocks.\r\n\r\n24 hour number of blocks mined - the number of blocks mined in the preceding 24 hours. This number should target 144 (a block every 10 minutes) and will be influenced towards that target by periodical mining difficulty adjustments. \r\n\r\n24 hour transaction count - the total number of transactions that were included in all blocks mined over the previous 24 hours.\r\n\r\n24 hour number of bitcoin sent - the total amount of all bitcoin sent (on-chain) over the previous 24 hours.\r\n\r\nTransactions in Mempool - the number of transactions currently in the mempool waiting to be included in a newly mined block.\r\n\r\nMin / max fee in next block - the anticipated minimum and maximum fee that will be included in the next block.\r\n\r\nTotal fees in next block - the anticipated total amount of fees to be included in the next block.\r\n\r\nTransactions in next block - the anticipated amount of transactions to be included in the next block.\r\n\r\nAvg no. of attempts to solve block - the average number of attempts made by the collective work of all miners to solve a block.\r\n\r\nAverage time between blocks - the average time between blocks being mined. This should average 10 minutes, influenced by periodical mining difficullty adjustments.\r\n\r\nEst. hashrate - an estimate of the total computational power currently being used in the mining process.\r\n\r\nBlock of next difficulty adjustment - the block height at which the next difficulty adjustment will occur. This happens every 2016 blocks which is approximately every two weeks.\r\n\r\nNext difficulty adjustment - the anticipated change to the current mining difficulty, expressed as a percentage.\r\n\r\nBlock reward - the current amount of the reward paid by the protocol for newly mined blocks, in the form of newly issued bitcoin. \r\n\r\nNumber of discoverable nodes - the number of currently discoverable Bitcoin nodes. This number is not representative of the total number of nodes, which will be much higher.\r\n\r\nBlockchain size - the current size of the entire blockchain/ledger in gigabytes (GB).\r\n\r\nHalving block / blocks remaining - the block height at which the next 'halving' will occur, and the number of blocks remaining until that time. The halving is when the block reward is cut in half until the next halving occurs. A halving occurs every 210,000 blocks, approximately every four years. \r\n\r\nHalving date / secs remaining - the date at which the next halving will occur, along with a countdown timer. \r\n\r\nBlock reward after halving - the value of the block reward once the next halving has taken place.";
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

        private void ResizeTextBox(TextBox textBox)
        {
            Size textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak);
            textBox.Height = textSize.Height;
        }

        private void textBoxHelpText_TextChanged(object sender, EventArgs e)
        {
            ResizeTextBox(textBoxHelpText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set the focus to the TextBox control
            textBoxHelpText.Focus();

            // Simulate pressing the Up arrow key
            SendKeys.Send("{UP}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the focus to the TextBox control
            textBoxHelpText.Focus();

            // Simulate pressing the Up arrow key
            SendKeys.Send("{DOWN}");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Set the focus to the TextBox control
            //textBoxHelpText.Focus();

            // Simulate pressing the Up arrow key
            //SendKeys.Send("{DOWN}");

            panel1.VerticalScroll.Value++;
        }
        private bool isButtonPressed = false;
        private bool downButtonPressed = false;
        private bool upButtonPressed = false;

        private void btnHelpTextDown_MouseDown(object sender, MouseEventArgs e)
        {

            isButtonPressed = true;
            downButtonPressed = true;
            timer1.Start();
        }

        private void btnHelpTextUp_MouseDown(object sender, MouseEventArgs e)
        {

            isButtonPressed = true;
            upButtonPressed = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isButtonPressed)
            {   if (downButtonPressed)
                {
                    if (panel1.VerticalScroll.Value < panel1.VerticalScroll.Maximum - 4)
                    {
                        panel1.VerticalScroll.Value = panel1.VerticalScroll.Value + 4;
                    }
                    timer1.Interval = 2; // set a faster interval while the button is held down
                }
                else if (upButtonPressed)
                {
                    if (panel1.VerticalScroll.Value > panel1.VerticalScroll.Minimum + 4)
                    {
                        panel1.VerticalScroll.Value = panel1.VerticalScroll.Value - 4;
                    }
                    timer1.Interval = 2; // set a faster interval while the button is held down
                }
            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnHelpTextDown_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonPressed = false;
            downButtonPressed = false;
            timer1.Stop();
            timer1.Interval = 50; // reset the interval to its original value
        }

        private void btnHelpTextUp_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonPressed = false;
            upButtonPressed = false;
            timer1.Stop();
            timer1.Interval = 50; // reset the interval to its original value
        }
    }
}
