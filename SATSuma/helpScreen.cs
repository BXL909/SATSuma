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
    public partial class HelpScreen : Form
    {
        public HelpScreen()
        {
            InitializeComponent();
        }

        private void HelpScreen_Load(object sender, EventArgs e)
        {
            panel1.VerticalScroll.Visible = false;
            if (((SATSuma)this.Owner).GetPanelBlock().Visible == true)
            {
                lblHelpHeading.Text = "Block";
                textBoxHelpText.Text = "Shows all transactions for the provided block. Displays the transaction ID, fee paid, number of transaction inputs and outputs and the amount of bitcoin moved in the transaction. Select a row in the list to view a transaction.\r\n\r\nFurther information related to the selected block includes the block time, count of all transactions included in the block, the block size and weight, the total amount of fees across all transactions in the block, the total block rewards, the minimum, maximum, median fee rate, average fee, the block hash, nonce and the name of the mining pool that mined the block.\r\n\r\nDefinitions:\r\n\r\nHash - the block hash.\r\n\r\nBlock time - date and time that the block was mined.\r\n\r\nTransaction count - the number of transactions within the block.\r\n\r\nBlock size - size of the block in megabytes (MB).\r\n\r\nBlock weight - measures the size of a block in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nTotal fees - the total amount of fees paid by all transactions in the block.\r\n\r\nReward - the total reward received by the miner (sum of the reward and the total fees)\r\n\r\nFee range - Minimum, maximum and median fees for the block (sat/vB)\r\n\r\nAverage fee - the average transaction fee paid within the block (in sats).\r\n\r\nNonce - the nonce is used during the mining process to try to find a valid block hash.\r\n\r\nMiner/Pool - the mining pool or miner that mined the block.\r\n\r\nTransaction ID - a unique identifier for the transaction.\r\n\r\nFee - the fee paid to include the transaction in the block.\r\n\r\nInputs (I/P) - the number of inputs in the transaction.\r\n\r\nOutput (O/P) - the number of outputs in the transaction.\r\n\r\nAmount - the amount of bitcoin transacted.\r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBlockList().Visible == true)
            {
                lblHelpHeading.Text = "Blocks";
                textBoxHelpText.Text = "Displays 15 blocks starting from the current block height. Enter a block number between 0 (Genesis Block) and the current block height to jump to that point in time or page through the list. Select a row on the list to view the transactions within that block.\r\n\r\nDefinitions:\r\n\r\nDate/time (table) - date and time that the block was mined.\r\n\r\nHeight (table) - the block height/number of the block. \r\n\r\nTX count (table) - the number of transactions that are included within the block.\r\n\r\nSize (table) - the size of the block in MB.\r\n\r\nFee range (table) - the range of transaction fees within the block (sat/vB)\r\n\r\nMed. (table) - median fee.\r\n\r\nReward(BTC) (table) - the miner reward comprising the block subsidy plus all transaction fees for the block.\r\n\r\nHash - the block hash.\r\n\r\nBlock weight - measures the size of a block in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nNonce - the nonce is used during the mining process to try to find a valid block hash.\r\n\r\nMiner/Pool - the mining pool or miner that mined the block.\r\n\r\nVersion - represents the current version of the block structure and associated rules being used in the network.\r\n\r\nTotal fees - the total amount of fees paid by all transactions in the block.\r\n\r\nAverage fee - the average transaction fee paid within the block (in sats).\r\n\r\nTotal inputs - the number of inputs in all transactions in the block.\r\n\r\nTotal outputs - the number of outputs in all transactions in the block.\r\n\r\nAverage TX size - the average size of a transaction in bytes.\r\n\r\nTransactions in Mempool - the number of transactions currently in the mempool waiting to be included in a newly mined block.\r\n\r\nTransactions in next block - the anticipated amount of transactions to be included in the next block.\r\n\r\nMin/Max fee in next block - the anticipated minimum and maximum fee that will be included in the next block.\r\n\r\nTotal fees in next block - the anticipated total amount of fees to be included in the next block.\r\n\r\nAvg attempts to solve block - the average number of attempts made by the collective work of all miners to solve a block.\r\n\r\nNext difficulty adjustment block - the block height at which the next difficulty adjustment will occur. This happens every 2016 blocks which is approximately every two weeks.\r\n\r\nAvg time between blocks - the average time between blocks being mined. This should average 10 minutes, influenced by periodical mining difficullty adjustments.\r\n\r\nNext difficulty adjustment - the anticipated change to the current mining difficulty, expressed as a percentage.\r\n\r\nEst. hashrate - an estimate of the total computational power currently being used in the mining process.\r\n\r\nBlock reward - the current amount of the reward paid by the protocol for newly mined blocks, in the form of newly issued bitcoin.\r\n\r\nHalving block/remaining - the block height at which the next 'halving' will occur, and the number of blocks remaining until that time. The halving is when the block reward is cut in half until the next halving occurs. A halving occurs every 210,000 blocks, approximately every four years.\r\n";
            }
            if (((SATSuma)this.Owner).GetPanelAddress().Visible == true)
            {
                lblHelpHeading.Text = "Address";
                textBoxHelpText.Text = "Shows all transactions for the provided Bitcoin address. Supported address formats are P2PKH (legacy), P2SH, P2WPKH (segwit), P2WSH and P2TT (taproot). A valid address will return transactions associated with that address showing the transaction ID, the block in which the transaction was added to the blockchain, the net change to the balance of that address and the number of confirmations that have occurred for that transaction. Select a row to be able to view either the associated transaction or block number.\r\n\r\nBy default, only confirmed transactions are displayed. Selecting 'show all TX' will show both confirmed and unconfirmed transactions, while 'unconfirmed TX' will only show unconfirmed transactions. The address summary and balance will also reflect this selection.\r\n\r\nDefinitions:\r\n\r\nConfirmed unspent (balance) - Unspent bitcoin. This can be regarded as the balance for this address.\r\n\r\nConfirmed transaction count - The total number of confirmed transactions that have taken place for this address.\r\n\r\nConfirmed received - the total amount of bitcoin received by this address.\r\n\r\nConfirmed spent - the total amount of bitcoin spent by this address.\r\n\r\nUnconfirmed unspent (balance) - unspent bitcoin that has yet to be confirmed.\r\n\r\nUnconfirmed transaction count - the number of unconfirmed transactions for this address.\r\n\r\nUnconfirmed received - the amount of bitcoin received by this address that is yet to be confirmed.\r\n\r\nUnconfirmed spent - the amount of bitcoin spent by this address that is yet to be confirmed.\r\n\r\nTransaction ID (table) - a unique identifier for the transaction.\r\n\r\nBlock (table) - the height of the block that contains the transaction.\r\n\r\nAmount (table) - the amount by which the balance of unspent bitcoin was increased or decreased by the transaction.\r\n\r\nConfs (table) - the amount of confirmations that have occurred on this transaction.\r\n";
            }
            if (((SATSuma)this.Owner).GetPanelBitcoinDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                textBoxHelpText.Text = "Displays an overview of a variety of key market, usage, mining, etc metrics. The data is refreshed every minute by default. This can be altered in the settings.\r\n\r\nDefinitions:\r\n\r\n1 BTC / USD - the current value of 1 bitcoin denominated in US dollars ($).\r\n\r\nMarket cap (USD) - Bitcoin's market capitalisation i.e the total value of all issued bitcoin.\r\n\r\nChange from ATH - The percentage difference between the current value of bitcoin and its all time high (ATH) value.\r\n\r\n1 USD / Sats - the value of 1 US dollar ($) denominated in sats/satoshis.\r\n\r\nAll time high (USD) - the highest value, denominated in US dollars ($), that bitcoin has reached, along with the date that it occurred.\r\n\r\n24hr high/ 24hr low (USD) - the highest and lowest values of 1 bitcoin over a 24 hour period, denominated in US dollars ($).\r\n\r\nTotal BTC in circulation - the total amount of bitcoin issued so far. This number will increase with each newly mined block until it reaches the hard cap of 21,000,000.\r\n\r\nNumber of holding addresses - the number of unique addresses currently holding an amount of bitcoin.\r\n\r\nAvg transactions per block - the average number of transactions included in a block, calculated over the previous 100 blocks.\r\n\r\n24 hour number of blocks mined - the number of blocks mined in the preceding 24 hours. This number should target 144 (a block every 10 minutes) and will be influenced towards that target by periodical mining difficulty adjustments. \r\n\r\n24 hour transaction count - the total number of transactions that were included in all blocks mined over the previous 24 hours.\r\n\r\n24 hour number of bitcoin sent - the total amount of all bitcoin sent (on-chain) over the previous 24 hours.\r\n\r\nTransactions in Mempool - the number of transactions currently in the mempool waiting to be included in a newly mined block.\r\n\r\nMin/Max fee in next block - the anticipated minimum and maximum fee that will be included in the next block.\r\n\r\nTotal fees in next block - the anticipated total amount of fees to be included in the next block.\r\n\r\nTransactions in next block - the anticipated amount of transactions to be included in the next block.\r\n\r\nAvg no. of attempts to solve block - the average number of attempts made by the collective work of all miners to solve a block.\r\n\r\nAverage time between blocks - the average time between blocks being mined. This should average 10 minutes, influenced by periodical mining difficullty adjustments.\r\n\r\nEst. hashrate - an estimate of the total computational power currently being used in the mining process.\r\n\r\nBlock of next difficulty adjustment - the block height at which the next difficulty adjustment will occur. This happens every 2016 blocks which is approximately every two weeks.\r\n\r\nNext difficulty adjustment - the anticipated change to the current mining difficulty, expressed as a percentage.\r\n\r\nBlock reward - the current amount of the reward paid by the protocol for newly mined blocks, in the form of newly issued bitcoin.\r\n\r\nNumber of discoverable nodes - the number of currently discoverable Bitcoin nodes. This number is not representative of the total number of nodes, which will be much higher.\r\n\r\nBlockchain size - the current size of the entire blockchain/ledger in gigabytes (GB).\r\n\r\nHalving block / blocks remaining - the block height at which the next 'halving' will occur, and the number of blocks remaining until that time. The halving is when the block reward is cut in half until the next halving occurs. A halving occurs every 210,000 blocks, approximately every four years.\r\n\r\nHalving date / secs remaining - the date at which the next halving will occur, along with a countdown timer. \r\n\r\nBlock reward after halving - the value of the block reward once the next halving has taken place.";
            }
            if (((SATSuma)this.Owner).GetPanelLightningDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Lightning dashboard";
                textBoxHelpText.Text = "Shows an overview of the capacity, channels and nodes on the Lightning network. The data is refreshed every minute by default. This can be altered in the settings.\r\n\r\nDefinitions:\r\n\r\nTotal capacity - the total bitcoin capacity of the Lightning network, split by Clearnet, Tor and 'unknown' nodes.\r\n\r\nNodes - the number of nodes on the Lightning network, split by Tor, Clearnet, Clearnet Tor and unannounced nodes.\r\n\r\nChannels - the number of open channels on the Lightning network and their average capacities and fees.\r\n\r\n";
            }
            if (((SATSuma)this.Owner).GetPanelTransaction().Visible == true)
            {
                lblHelpHeading.Text = "Transaction";
                textBoxHelpText.Text = "Shows all inputs and outputs for the provided transaction ID. \r\n\r\nDefinitions:\r\n\r\nIncluded in block - The block number in which this transaction was added to the blockchain.\r\n\r\nBlock time - the tme and date that the block containing the transaction was mined.\r\n\r\nLock time - the lock time sets the earliest time at which a transaction can be mined into a block.\r\n\r\nVersion - Each transaction is prefixed by a four-byte transaction version number which tells Bitcoin peers and miners which set of rules to use to validate it.\r\n\r\nInputs - the total number of inputs in the transaction and their total value.\r\n\r\nOutputs - the total number of outputs in the transaction and their total value.\r\n\r\nFee - the miner fee paid for this transaction.\r\n\r\nSize - the size of the transaction in bytes.\r\n\r\nWeight - measures the size of a transaction in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nTransaction inputs (table) - List all the inputs to a transaction, showing the sending addresses and amounts.\r\n\r\nTransaction outputs (table) - List all the outputs to a transaction, showing the receiving addresses and amounts.";
            }
        }

        private void HelpScreen_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void ResizeTextBox(TextBox textBox)
        {
            Size textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak);
            textBox.Height = textSize.Height;
        }

        private void TextBoxHelpText_TextChanged(object sender, EventArgs e)
        {
            ResizeTextBox(textBoxHelpText);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Set the focus to the TextBox control
            textBoxHelpText.Focus();

            // Simulate pressing the Up arrow key
            SendKeys.Send("{UP}");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Set the focus to the TextBox control
            textBoxHelpText.Focus();

            // Simulate pressing the Up arrow key
            SendKeys.Send("{DOWN}");
        }

        private void BtnHelp_Click(object sender, EventArgs e)
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

        private void BtnHelpTextDown_MouseDown(object sender, MouseEventArgs e)
        {

            isButtonPressed = true;
            downButtonPressed = true;
            timer1.Start();
        }

        private void BtnHelpTextUp_MouseDown(object sender, MouseEventArgs e)
        {

            isButtonPressed = true;
            upButtonPressed = true;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
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

        private void BtnHelpTextDown_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonPressed = false;
            downButtonPressed = false;
            timer1.Stop();
            timer1.Interval = 50; // reset the interval to its original value
        }

        private void BtnHelpTextUp_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonPressed = false;
            upButtonPressed = false;
            timer1.Stop();
            timer1.Interval = 50; // reset the interval to its original value
        }
    }
}
