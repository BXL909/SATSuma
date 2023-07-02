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
        public Color TextColor { get; set; }
        public Color HeadingTextColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor2 { get; set; }
        public Color ButtonBackColor2 { get; set; }
        public Color TextBoxBackColor { get; set; }
        public Color TextBoxForeColor { get; set; }
        public Image WindowBackgroundImage { get; set; }
        public Color WindowBackgroundColor { get; set; }

        public HelpScreen()
        {
            InitializeComponent();
        }

        private bool isButtonPressed = false;
        private bool downButtonPressed = false;
        private bool upButtonPressed = false;

        readonly string blockHelpText = "Shows all transactions for the provided block. Displays the transaction ID, fee paid, number of transaction inputs and outputs and the amount of bitcoin moved in the transaction.\r\n\r\nPress the ▶ button on a selected transaction/row to view more detail about that individual transaction.\r\n\r\nFurther information related to the selected block (left-hand column) includes the block time, count of all transactions included in the block, the block size and weight, the total amount of fees across all transactions in the block, the total block rewards, the minimum, maximum, median fee rate, average fee, the block hash, nonce and the name of the mining pool that mined the block.\r\n\r\nDefinitions\r\nHash – the block hash.\r\n\r\nBlock time – date and time that the block was mined.\r\n\r\nTransaction count – the number of transactions within the block.\r\n\r\nBlock size – size of the block in megabytes (MB).\r\n\r\nBlock weight – measures the size of a block in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nTotal fees – the total amount of fees paid by all transactions in the block.\r\n\r\nReward – the total reward received by the miner (sum of the reward and the total fees)\r\n\r\nFee range – Minimum, maximum and median fees for the block (sat/vB)\r\n\r\nAverage fee – the average transaction fee paid within the block (in sats).\r\n\r\nNonce – the nonce is used during the mining process to try to find a valid block hash.\r\n\r\nMiner/Pool – the mining pool or miner that mined the block.\r\n\r\nTransaction ID – a unique identifier for the transaction.\r\n\r\nFee – the fee paid to include the transaction in the block.\r\n\r\nInputs (I/P) – the number of inputs in the transaction.\r\n\r\nOutput (O/P) – the number of outputs in the transaction.\r\n\r\nAmount – the amount of bitcoin transacted.";
        readonly string blockListHelpText = "Displays 15 blocks starting from the current block height. Enter a block number between 0 (Genesis Block) and the current block height to jump to that point in time or page through the list.\r\n\r\nSelect a row on the list to view further information about that block, or press the ▶️ button on the selected row to view all the transactions contained in that block.\r\n\r\nDefinitions\r\nDate/time (table) – date and time that the block was mined.\r\n\r\nHeight (table) – the block height/number of the block.\r\n\r\nTX count (table) – the number of transactions that are included within the block.\r\n\r\nSize (table) – the size of the block in MB.\r\n\r\nFee range (table) – the range of transaction fees within the block (sat/vB)\r\n\r\nMed. (table) – median fee.\r\n\r\nReward(BTC) (table) – the miner reward comprising the block subsidy plus all transaction fees for the block.\r\n\r\nHash – the block hash.\r\n\r\nBlock weight – measures the size of a block in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nNonce – the nonce is used during the mining process to try to find a valid block hash.\r\n\r\nMiner/Pool – the mining pool or miner that mined the block.\r\n\r\nVersion – represents the current version of the block structure and associated rules being used in the network.\r\n\r\nTotal fees – the total amount of fees paid by all transactions in the block.\r\n\r\nAverage fee – the average transaction fee paid within the block (in sats).\r\n\r\nTotal inputs – the number of inputs in all transactions in the block.\r\n\r\nTotal outputs – the number of outputs in all transactions in the block.\r\n\r\nAverage TX size – the average size of a transaction in bytes.\r\n\r\nTransactions in Mempool – the number of transactions currently in the mempool waiting to be included in a newly mined block.\r\n\r\nTransactions in next block – the anticipated amount of transactions to be included in the next block.\r\n\r\nMin/Max fee in next block – the anticipated minimum and maximum fee that will be included in the next block.\r\n\r\nTotal fees in next block – the anticipated total amount of fees to be included in the next block.\r\n\r\nAvg attempts to solve block – the average number of attempts made by the collective work of all miners to solve a block.\r\n\r\nNext difficulty adjustment block – the block height at which the next difficulty adjustment will occur. This happens every 2016 blocks which is approximately every two weeks.\r\n\r\nAvg time between blocks – the average time between blocks being mined. This should average 10 minutes, influenced by periodical mining difficullty adjustments.\r\n\r\nNext difficulty adjustment – the anticipated change to the current mining difficulty, expressed as a percentage.\r\n\r\nEst. hashrate – an estimate of the total computational power currently being used in the mining process.\r\n\r\nBlock reward – the current amount of the reward paid by the protocol for newly mined blocks, in the form of newly issued bitcoin.\r\n\r\nHalving block/remaining – the block height at which the next ‘halving’ will occur, and the number of blocks remaining until that time. The halving is when the block reward is cut in half until the next halving occurs. A halving occurs every 210,000 blocks, approximately every four years.";
        readonly string addressHelpText = "The address screen shows all transactions for the provided Bitcoin address. It will accept a user inputted address or can be passed an address from the transaction or xpub screens. Supported address formats are P2PKH (legacy), P2SH, P2WPKH (segwit), P2WSH and P2TT (taproot). A valid address will return all transactions associated with that address showing the transaction ID, the block in which the transaction was added to the blockchain, the net change to the balance of that address and the number of confirmations that have occurred for that transaction. Select a row to be able to view either the associated transaction or block number.\r\n\r\nBy default, only confirmed transactions are displayed. Selecting ‘show all TX’ will show both confirmed and unconfirmed transactions, while ‘unconfirmed TX’ will only show unconfirmed transactions. The address summary and balance will also reflect this selection.\r\n\r\nDefinitions\r\nConfirmed unspent (balance) – Unspent bitcoin.\r\n\r\nConfirmed transaction count – The total number of confirmed transactions that have taken place for this address.\r\n\r\nConfirmed received – the total amount of bitcoin received by this address.\r\n\r\nConfirmed spent – the total amount of bitcoin spent by this address.\r\n\r\nUnconfirmed unspent (balance) – unspent bitcoin that has yet to be confirmed.\r\n\r\nUnconfirmed transaction count – the number of unconfirmed transactions for this address.\r\n\r\nUnconfirmed received – the amount of bitcoin received by this address that is yet to be confirmed.\r\n\r\nUnconfirmed spent – the amount of bitcoin spent by this address that is yet to be confirmed.\r\n\r\nTransaction ID (table) – a unique identifier for the transaction.\r\n\r\nBlock (table) – the height of the block that contains the transaction.\r\n\r\nAmount (table) – the amount by which the balance of unspent bitcoin was increased or decreased by the transaction.\r\n\r\nConfs (table) – the amount of confirmations that have occurred on this transaction.";
        readonly string bitcoinDashboardHelpText = "Displays an overview of a variety of market, usage, mining, etc metrics. The frequency at which the data is refreshed can be altered in the settings.\r\n\r\nThe default currency can be changed to USD, EUR, GBP or XAU from the currency menu.\r\n\r\nDefinitions\r\n1 BTC / USD – the current value of 1 bitcoin denominated in the selected currency.\r\n\r\nMarket cap (USD) – Bitcoin’s market capitalisation i.e the total value of all issued bitcoin.\r\n\r\n1 USD / Sats – the value of 1 US dollar ($) denominated in satoshis.\r\n\r\nTotal BTC in circulation – the total amount of bitcoin issued so far. This number will increase with each newly mined block until it reaches the hard cap of 21,000,000.\r\n\r\nNumber of holding addresses – the number of unique addresses currently holding an amount of bitcoin.\r\n\r\nAvg transactions per block – the average number of transactions included in a block, calculated over the previous 100 blocks.\r\n\r\n24 hour number of blocks mined – the number of blocks mined in the preceding 24 hours. This number should target 144 (a block every 10 minutes) and will be influenced towards that target by periodical mining difficulty adjustments.\r\n\r\n24 hour transaction count – the total number of transactions that were included in all blocks mined over the previous 24 hours.\r\n\r\n24 hour number of bitcoin sent – the total amount of all bitcoin sent (on-chain) over the previous 24 hours.\r\n\r\nTransactions in Mempool – the number of transactions currently in the mempool waiting to be included in a newly mined block.\r\n\r\nMin/Max fee in next block – the anticipated minimum and maximum fee that will be included in the next block.\r\n\r\nTotal fees in next block – the anticipated total amount of fees to be included in the next block.\r\n\r\nTransactions in next block – the anticipated amount of transactions to be included in the next block.\r\n\r\nAvg no. of attempts to solve block – the average number of attempts made by the collective work of all miners to solve a block.\r\n\r\nAverage time between blocks – the average time between blocks being mined. This should average 10 minutes, influenced by periodical mining difficullty adjustments.\r\n\r\nEst. hashrate – an estimate of the total computational power currently being used in the mining process.\r\n\r\nBlock of next difficulty adjustment – the block height at which the next difficulty adjustment will occur. This happens every 2016 blocks which is approximately every two weeks.\r\n\r\nNext difficulty adjustment – the anticipated change to the current mining difficulty, expressed as a percentage.\r\n\r\nBlock reward – the current amount of the reward paid by the protocol for newly mined blocks, in the form of newly issued bitcoin.\r\n\r\nNumber of discoverable nodes – the number of currently discoverable Bitcoin nodes. This number is not representative of the total number of nodes, which will be much higher.\r\n\r\nBlockchain size – the current size of the entire blockchain/ledger in gigabytes (GB).\r\n\r\nHalving block / blocks remaining – the block height at which the next ‘halving’ will occur, and the number of blocks remaining until that time. The halving is when the block reward is cut in half until the next halving occurs. A halving occurs every 210,000 blocks, approximately every four years.\r\n\r\nHalving date / secs remaining – the date at which the next halving will occur, along with a countdown timer.\r\n\r\nBlock reward after halving – the value of the block reward once the next halving has taken place.";
        readonly string lightningDashboardHelpText = "Shows an overview of the capacity, channels and nodes on the Lightning network. The frequency at which the data is refreshed can be altered in the settings.\r\n\r\nDefinitions\r\nTotal capacity – the total bitcoin capacity of the Lightning network, split by Clearnet, Tor and ‘unknown’ nodes.\r\n\r\nNodes – the number of nodes on the Lightning network, split by Tor, Clearnet, Clearnet Tor and unannounced nodes.\r\n\r\nChannels – the number of open channels on the Lightning network and their average capacities and fees.";
        readonly string transactionHelpText = "Shows all inputs and outputs for the provided transaction ID. Press the ▶️ button on a selected input or output to view that address.\r\n\r\nDefinitions\r\nIncluded in block – The block number in which this transaction was added to the blockchain.\r\n\r\nBlock time – the tme and date that the block containing the transaction was mined.\r\n\r\nLock time – the lock time sets the earliest time at which a transaction can be mined into a block.\r\n\r\nVersion – Each transaction is prefixed by a four-byte transaction version number which tells Bitcoin peers and miners which set of rules to use to validate it.\r\n\r\nInputs – the total number of inputs in the transaction and their total value.\r\n\r\nOutputs – the total number of outputs in the transaction and their total value.\r\n\r\nFee – the miner fee paid for this transaction.\r\n\r\nSize – the size of the transaction in bytes.\r\n\r\nWeight – measures the size of a transaction in terms of the resources required to propagate and validate it. Measured in Million Weight Units (MWU).\r\n\r\nTransaction inputs (table) – List all the inputs to a transaction, showing the sending addresses and amounts.\r\n\r\nTransaction outputs (table) – List all the outputs to a transaction, showing the receiving addresses and amounts.";
        readonly string xpubHelpText = "Shows all used addresses associated with a provided Xpub. Generates the first 500 addresses for Segwit, Legacy and Segwit P2SH address types, then checks each in turn to find all used addresses, along with their total amounts received, spent and unspent. After 20 consecutive unused addresses it is assumed that all used addresses have been found. All unused addresses that were scanned are also displayed.\r\n\r\nThis feature is only available by connecting to your own full node running a local installation of mempool.space. The most recent valid/connected node url is automatically saved for next time. The Xpub you provide is not sent or stored anywhere other than your own node, unless you choose to bookmark it, in which case all that is stored is a SHA-256 hash of the password on your local machine in the installation directory. Because you are only connecting to your own node, no third-party is involved when using the Xpub screen, giving you complete privacy.\r\n\r\nDefinitions\r\nStatus – shows the progress of the scan for all used addresses associated with the Xpub. The upper progress bar indicates the number of consecutive unused addresses for the address type being scanned, and the lower progress bar indicates the total progress of all address type scans.\r\n\r\nUsed addresses – summarizes the number of used addresses identified for each address type and their total amounts received, spent and unspent.\r\n\r\nTotals – the total amounts received, spent and unspent across all address types.\r\n\r\nTX’s (table) – the number of transactions associated with that address.\r\n\r\nReceived (table) – the total amount received by that address.\r\n\r\nSpent (table) – the total amount spent by that address.\r\n\r\nUnspent (table) – the total amount unspent (balance) held by that address.";
        readonly string chartsHelpText = "Chart data is pulled directly from your full node, or via public API’s, depending on your settings. When connected to your own node, queries will likely take longer and the history of some queries may not be so extensive. Disabling all public API’s will result in a small number of charts being disabled.\r\n\r\nControls – most charts will allow you to use the mousewheel to zoom in and out of the chart. Right-clicking while vertically dragging the mouse will shrink and expand the Y axis, and horizontally dragging will shrink and expand the X axis. Below each chart you can select a time period for the chart to represent, from 24 hours through to all time.\r\n\r\nSelecting the 💾 button will open a save file dialog to save the current chart as an image file.\r\n\r\nAvailable charts:\r\nBlock fee rates\r\nAverage total fees per block\r\nBlock rewards (block subsidy plus fees)\r\nBlock size\r\nHashrate\r\nDifficulty\r\nBitcoin in circulation\r\nUnique addresses (linear and logarithmic)\r\nUTXO’s (linear and logarithmic)\r\nMining pool rankings\r\nNumber of lightning nodes by network\r\nLightning nodes per country (exc. Darknet)\r\nLightning network capacity\r\nLightning network channels\r\nAverage USD market price across major bitcoin exchanges (linear and logarithmic)\r\nMarket capitalization in USD (linear and logarithmic)";
        readonly string appearanceHelpText = "The appearance screen lets you customise the colours of every part of SATSuma.\r\n\r\nColours\r\nThe left-hand column lets you change the colour of all the elements that make up the UI. The coloured buttons open a standard colour-picker to set custom colours.\r\n\r\nLocal time\r\nDisplays/hides the local time (only applies to the default ‘Genesis’ theme).\r\n\r\nChart backgrounds\r\nSets the background colour of all charts to either light or dark.\r\n\r\nLoading animation\r\nSelect between two loading animations, displayed in the lower-right of the screen and while charts are generated..\r\n\r\nHeading backgrounds\r\nSelect between the default heading background, no background or a custom colour.\r\n\r\nBackground image\r\nEnables you to select a background image. The background images used by the preset themes can be selected, as well as a flat background colour or a background image of your own.\r\n\r\nSave theme\r\nNone of the above selections are saved until you choose to give your theme a name and save it. If you are using a custom background image, you will need to provide the filepath to the file. Saving the theme will also set it to be your theme at next start up. Theme data is stored in the SATSuma_themes.json file, which can be found in your user application data directory (e.g. C:\\Users\\yourusername\\AppData\\Roaming\\SATSuma).\r\n\r\nLoad theme\r\nSelect from the preset themes or from your own creations. Loading a theme will also set it to be your theme at next start up.";
        readonly string bookmarksHelpText = "Adding a bookmark\r\nAny address, xpub, block or transaction can be bookmarked. The \U0001f9e1 button will open a tab to add the currently viewed item as a bookmark.\r\n\r\nAn optional note or description can also be added. Bookmarks are stored in a bookmarks.json file in the SATSuma installation directory. This file can be accessed by anyone who has access to your computer. You can encrypt your bookmarks and notes using SHA-256 by supplying an optional encryption key/password. This key is not stored anywhere and there is no way to recover it. Each bookmark has its own individual key, so you need to provide a key for every bookmark you want encrypted, although you can re-use the same key multiple times if you wish.\r\n\r\nViewing a bookmark\r\nThe bookmarks screen shows all currently saved bookmarks, along with the time and date they were created. A red 🔒 means that the bookmark is encrypted and will need the key provided (press the unlock button after selecting the row) before it can be viewed properly.\r\n\r\nPress the ‘view’ button to go to the appropriate screen to see that bookmark or press ‘delete’ button to instantly delete it.\r\n\r\nWhere are my bookmarks stored?\r\nYour bookmarks are saved in the SATSuma_bookmarks.json file, which can be found in your user application data directory (e.g. C:\\Users\\yourusername\\AppData\\Roaming\\SATSuma).";
        readonly string settingsHelpText = "All settings are automatically saved.\r\n\r\nNetwork – on-chain queries (exc. Xpub)\r\nThis setting affects all queries on the address, block, block list and transaction screens, as well as a subset of the data shown on the Bitcoin Dashboard. The options in the ‘mempool.space’ panel will connect SATSuma to the public mempool.space API on either the mainnet or testnet network.\r\n\r\nSelecting ‘custom’ requires you to have your own installation of mempool.space on your own Bitcoin full node, running either Electrs or Fulcrum. Provide the full path to your mempool.space api.\r\n\r\nNetwork – Xpub queries only\r\nThe Xpub screen can ONLY be used with your own Bitcoin full node, running either Electrs or Fulcrum. This ensures total privacy, avoiding the need to send your Xpub to any third-party. If you are already using your own node for all other on-chain queries, then this would normally be set to the same URL, although it doesn’t have to be.\r\n\r\nWallet balance\r\nWhen scanning an Xpub to determine the balance of a wallet, SATSuma determines that it has found all non-zero balance addresses by assuming that after 20 consecutive non-zero balance addresses that there are no more to be found. 20 is the number commonly used by many wallets to make this assumption, but you can override this number with this setting.\r\n\r\nOther API’s\r\nThe majority of the data that SATSuma draws on can be found on-chain and is accessible either with the public mempool.space API or by connecting to your own full node, as described above. SATSuma also makes use of three other public API’s to fetch data relating to metrics such as price, mining, etc. No personal data is sent or stored but you can disable any/all of these API’s if you prefer. Doing so will disable a few of the charts that relied on these API’s, as well as some of the data on the Bitcoin Dashboard and price information on the header.\r\n\r\nRefresh frequency\r\nThe refresh frequency dictates how often the dashboard data and header data (price, block height, etc) gets updated. The address, block, block list, transaction and Xpub screens are not affected by this setting. The refresh frequency is measured in minutes and can be set anywhere between 1 minute and 1440 minutes (24 hours).\r\n\r\nWhere are my settings stored?\r\nYour settings are saved in the SATSuma_bookmarks.json file, which can be found in your user application data directory (e.g. C:\\Users\\yourusername\\AppData\\Roaming\\SATSuma). SATSuma continually saves your settings so you shouldn’t need to manually edit this file. If you do need to edit it, open it in a text editor (e.g Notepad) and search for “settings” you should find something resembling this:\r\n\r\n1st character – currency (P = GBP, D = USD, E = EUR, G = XAU).\r\n2nd character – network (M = MainNet, T = TestNet, C = own node).\r\n3rd character – blockchair API (boolean 1 or 0).\r\n4th character – bitcoinexplorer API (boolean 1 or 0).\r\n5th character – blockchain.info API (boolean 1 or 0).\r\n6th character – privacy mode (boolean 1 or 0).\r\n7th character – currently unused (boolean 1 or 0).\r\n8th character – currently unused (boolean 1 or 0).\r\nCharacters 9-12 – refresh frequency.\r\nCharacters 13-14 – max number of non-zero balance addresses on Xpub scan.\r\nCharacters 15-17 – number of derivation paths to check on Xpub scan.\r\n\r\nYour node and Xpub node settings are also stored in the SATSuma_bookmarks.json file, as well as your default theme.\r\n\r\nPrivacy Mode\r\nPrivacy mode is essentially a shortcut to disabling all API’s and ensuring that SATSuma communicates with nothing other than your own full node.";

        private void HelpScreen_Load(object sender, EventArgs e)
        {
            comboBoxSelectHelp.SelectedIndex = 0;
            textBoxHelpText.ForeColor = TextColor;
            textBoxHelpText.BackColor = TextBoxBackColor;
            panel1.BackColor = TextBoxBackColor;
            lblHelpHeading.ForeColor = HeadingTextColor;
            btnExit.ForeColor = ButtonTextColor;
            btnHelpTextUp.ForeColor = ButtonTextColor2;
            btnHelpTextDown.ForeColor = ButtonTextColor2;
            btnExit.BackColor = ButtonBackColor;
            btnHelpTextUp.BackColor = ButtonBackColor2;
            btnHelpTextDown.BackColor = ButtonBackColor2;
            comboBoxSelectHelp.BackColor = TextBoxBackColor;
            comboBoxSelectHelp.ForeColor = TextBoxForeColor;
            if (WindowBackgroundColor != null)
            {
                this.BackColor = WindowBackgroundColor;
            }
            if (WindowBackgroundImage != null)
            {
                this.BackgroundImage = WindowBackgroundImage;
            }

            panel1.VerticalScroll.Visible = false;
            if (((SATSuma)this.Owner).GetPanelMenu().Visible == true && ((SATSuma)this.Owner).GetPanelMenu().Height > 24) // menu is open so main help page has been requested
            {
                ((SATSuma)this.Owner).GetPanelMenu().Height = 24; // close menu on calling window
                lblHelpHeading.Text = "Documentation";
                textBoxHelpText.Text = "🍊 SATSuma - overview" + "\r\n\r\nSATSuma is a Bitcoin explorer, Xpub viewer, Bitcoin & Lightning dashboard, with the option to create encrypted bookmarks and notes for addresses, blocks, xpubs and transactions, view network, on-chain and market charts or use as a ‘watch-only’ wallet.\r\n\r\nSATSuma can connect to either your own full node (running Electrs/Fulcrum and mempool.space) or to the public mempool.space API. Xpub queries are restricted to the user’s own node only, to maximise privacy. Keys to unlock encrypted bookmarks are not stored anywhere and are unrecoverable.\r\n\r\nSATSuma comes with a handful of themes but it is also possible to create your own, by customising the colours of all elements and applying your own ‘skin’ or background image.\r\n\r\nAll user data is stored in two files (SATSuma_bookmarks.json & SATSuma_themes.json) stored in your user application data folder (e.g. C:\\Users\\yourusername\\AppData\\Roaming\\SATSuma).\r\n\r\nSATSuma is completely free and open source. If you like it and want to support the project it would be hugely appreciated \U0001f9e1";
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelBlock().Visible == true)
            {
                lblHelpHeading.Text = "Block";
                textBoxHelpText.Text = blockHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelCharts().Visible == true)
            {
                lblHelpHeading.Text = "Charts";
                textBoxHelpText.Text = chartsHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelBlockList().Visible == true)
            {
                lblHelpHeading.Text = "Blocks";
                textBoxHelpText.Text = blockListHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelAddress().Visible == true)
            {
                lblHelpHeading.Text = "Address";
                textBoxHelpText.Text = addressHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelBitcoinDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                textBoxHelpText.Text = bitcoinDashboardHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelLightningDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Lightning dashboard";
                textBoxHelpText.Text = lightningDashboardHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelTransaction().Visible == true)
            {
                lblHelpHeading.Text = "Transaction";
                textBoxHelpText.Text = transactionHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelXpub().Visible == true)
            {
                lblHelpHeading.Text = "Xpub";
                textBoxHelpText.Text = xpubHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelBookmarks().Visible == true)
            {
                lblHelpHeading.Text = "Bookmarks";
                textBoxHelpText.Text = bookmarksHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelSettings().Visible == true)
            {
                lblHelpHeading.Text = "Settings";
                textBoxHelpText.Text = settingsHelpText;
                btnExit.Focus();
            }
            else
            if (((SATSuma)this.Owner).GetPanelAppearance().Visible == true)
            {
                lblHelpHeading.Text = "Appearance";
                textBoxHelpText.Text = appearanceHelpText;
                btnExit.Focus();
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

        private void ComboBoxSelectHelp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectHelp.SelectedIndex == 1)
            {
                lblHelpHeading.Text = "Blocks";
                textBoxHelpText.Text = blockListHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 2)
            {
                lblHelpHeading.Text = "Block";
                textBoxHelpText.Text = blockHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 3)
            {
                lblHelpHeading.Text = "Address";
                textBoxHelpText.Text = addressHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 4)
            {
                lblHelpHeading.Text = "Transaction";
                textBoxHelpText.Text = transactionHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 5)
            {
                lblHelpHeading.Text = "Xpub";
                textBoxHelpText.Text = xpubHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 6)
            {
                lblHelpHeading.Text = "Charts";
                textBoxHelpText.Text = chartsHelpText;
            }

            if (comboBoxSelectHelp.SelectedIndex == 7)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                textBoxHelpText.Text = bitcoinDashboardHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 8)
            {
                lblHelpHeading.Text = "Lightning dashboard"; 
                textBoxHelpText.Text = lightningDashboardHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 9)
            {
                lblHelpHeading.Text = "Bookmarks";
                textBoxHelpText.Text = bookmarksHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 10)
            {
                lblHelpHeading.Text = "Settings";
                textBoxHelpText.Text = settingsHelpText;
            }
            if (comboBoxSelectHelp.SelectedIndex == 11)
            {
                lblHelpHeading.Text = "Appearance";
                textBoxHelpText.Text = appearanceHelpText;
            }
            btnHelpTextDown.Focus();
        }
    }
}
