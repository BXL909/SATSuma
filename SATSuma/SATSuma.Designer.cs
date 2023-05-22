namespace SATSuma
{
    partial class SATSuma
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SATSuma));
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1Sec = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBlockNumber = new System.Windows.Forms.Label();
            this.timerAPIRefreshPeriod = new System.Windows.Forms.Timer(this.components);
            this.btnMinimise = new System.Windows.Forms.Button();
            this.btnMoveWindow = new System.Windows.Forms.Button();
            this.lblRefreshSuccessOrFailMessage = new System.Windows.Forms.Label();
            this.lblStatusLight = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblNodes = new System.Windows.Forms.Label();
            this.lblNextBlockTotalFees = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblNextBlockMinMaxFee = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTransInNextBlock = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblEstimatedHalvingDate = new System.Windows.Forms.Label();
            this.lblHalvingSecondsRemaining = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAvgNoTransactions = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDifficultyAdjEst = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.lblBlockListTXInNextBlock = new System.Windows.Forms.Label();
            this.lblBlockListMinMaxInFeeNextBlock = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.lblBlockListTotalFeesInNextBlock = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.lblBlockListNextDifficultyAdjustment = new System.Windows.Forms.Label();
            this.lblSegwitP2SHSummary = new System.Windows.Forms.Label();
            this.lblLegacySummary = new System.Windows.Forms.Label();
            this.lblSegwitSummary = new System.Windows.Forms.Label();
            this.lblP2SHSummary = new System.Windows.Forms.Label();
            this.BtnViewBlockFromAddress = new System.Windows.Forms.Button();
            this.BtnViewTransactionFromAddress = new System.Windows.Forms.Button();
            this.btnViewTransactionFromBlock = new System.Windows.Forms.Button();
            this.btnViewBlockFromBlockList = new System.Windows.Forms.Button();
            this.btnViewAddressFromTXOutput = new System.Windows.Forms.Button();
            this.btnViewAddressFromTXInput = new System.Windows.Forms.Button();
            this.btnViewAddressFromXpub = new System.Windows.Forms.Button();
            this.pictureBoxHashrateChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxDifficultyChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeaderHashrateChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlockListDifficultyChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlockListHashrateChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeaderPriceChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxPriceChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeaderFeeRatesChart = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlockScreenChartFeeRange = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlockScreenChartReward = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlockScreenChartBlockSize = new System.Windows.Forms.PictureBox();
            this.pictureBoxChartCirculation = new System.Windows.Forms.PictureBox();
            this.label134 = new System.Windows.Forms.Label();
            this.lblBlocksUntilDiffAdj = new System.Windows.Forms.Label();
            this.lblHeaderPrice = new System.Windows.Forms.Label();
            this.lblBlockchainSize = new System.Windows.Forms.Label();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.lblElapsedSinceUpdate = new System.Windows.Forms.Label();
            this.panelBitcoinDashboard = new System.Windows.Forms.Panel();
            this.progressBarProgressToHalving = new ColorProgressBar.ColorProgressBar();
            this.progressBarNextDiffAdj = new ColorProgressBar.ColorProgressBar();
            this.label23 = new System.Windows.Forms.Label();
            this.lblProgressNextDiffAdjPercentage = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.lblEstDiffAdjDate = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label86 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label84 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label83 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblHodlingAddresses = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label79 = new System.Windows.Forms.Label();
            this.lblAvgTimeBetweenBlocks = new System.Windows.Forms.Label();
            this.lblBlockRewardAfterHalving = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label81 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label80 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNextDiffAdjBlock = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHashesToSolve = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBTCInCirc = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblEstHashrate = new System.Windows.Forms.Label();
            this.lbl24HourTransCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl24HourBTCSent = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBlocksIn24Hours = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblHalveningBlock = new System.Windows.Forms.Label();
            this.lblBlockReward = new System.Windows.Forms.Label();
            this.lblMarketCapUSD = new System.Windows.Forms.Label();
            this.lblMoscowTimeLabel = new System.Windows.Forms.Label();
            this.lblMarketCapLabel = new System.Windows.Forms.Label();
            this.lblMoscowTime = new System.Windows.Forms.Label();
            this.lblPriceLabel = new System.Windows.Forms.Label();
            this.lblPriceUSD = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTXInMempool = new System.Windows.Forms.Label();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.panelLightningDashboard = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label78 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label75 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lblMedBaseFeeTokens = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lblMedFeeRate = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lblMedCapacity = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lblAverageBaseFeeMtokens = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lblAverageFeeRate = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblAverageCapacity = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblChannelCount = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblUnannouncedNodes = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lblClearnetTorNodes = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblClearnetNodes = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblNodeCount = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTorNodes = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.channelLabel9 = new System.Windows.Forms.Label();
            this.channelLabel10 = new System.Windows.Forms.Label();
            this.aliasConnLabel10 = new System.Windows.Forms.Label();
            this.aliasConnLabel9 = new System.Windows.Forms.Label();
            this.channelLabel7 = new System.Windows.Forms.Label();
            this.channelLabel8 = new System.Windows.Forms.Label();
            this.aliasConnLabel8 = new System.Windows.Forms.Label();
            this.aliasConnLabel7 = new System.Windows.Forms.Label();
            this.channelLabel5 = new System.Windows.Forms.Label();
            this.channelLabel6 = new System.Windows.Forms.Label();
            this.aliasConnLabel6 = new System.Windows.Forms.Label();
            this.aliasConnLabel5 = new System.Windows.Forms.Label();
            this.channelLabel3 = new System.Windows.Forms.Label();
            this.channelLabel4 = new System.Windows.Forms.Label();
            this.aliasConnLabel4 = new System.Windows.Forms.Label();
            this.aliasConnLabel3 = new System.Windows.Forms.Label();
            this.channelLabel1 = new System.Windows.Forms.Label();
            this.channelLabel2 = new System.Windows.Forms.Label();
            this.aliasConnLabel2 = new System.Windows.Forms.Label();
            this.aliasConnLabel1 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.capacityLabel9 = new System.Windows.Forms.Label();
            this.capacityLabel10 = new System.Windows.Forms.Label();
            this.aliasLabel10 = new System.Windows.Forms.Label();
            this.aliasLabel9 = new System.Windows.Forms.Label();
            this.capacityLabel7 = new System.Windows.Forms.Label();
            this.capacityLabel8 = new System.Windows.Forms.Label();
            this.aliasLabel8 = new System.Windows.Forms.Label();
            this.aliasLabel7 = new System.Windows.Forms.Label();
            this.capacityLabel5 = new System.Windows.Forms.Label();
            this.capacityLabel6 = new System.Windows.Forms.Label();
            this.aliasLabel6 = new System.Windows.Forms.Label();
            this.aliasLabel5 = new System.Windows.Forms.Label();
            this.capacityLabel3 = new System.Windows.Forms.Label();
            this.capacityLabel4 = new System.Windows.Forms.Label();
            this.aliasLabel4 = new System.Windows.Forms.Label();
            this.aliasLabel3 = new System.Windows.Forms.Label();
            this.capacityLabel1 = new System.Windows.Forms.Label();
            this.capacityLabel2 = new System.Windows.Forms.Label();
            this.aliasLabel2 = new System.Windows.Forms.Label();
            this.aliasLabel1 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lblUnknownCapacity = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.lblTorCapacity = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lblClearnetCapacity = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblTotalCapacity = new System.Windows.Forms.Label();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.panelOwnNodeAddressTXInfo = new System.Windows.Forms.Panel();
            this.label164 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.label63 = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.label67 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.label59 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.label58 = new System.Windows.Forms.Label();
            this.textboxSubmittedAddress = new System.Windows.Forms.TextBox();
            this.btnShowAllTX = new System.Windows.Forms.Button();
            this.btnShowConfirmedTX = new System.Windows.Forms.Button();
            this.btnShowUnconfirmedTX = new System.Windows.Forms.Button();
            this.lblAddressTXPositionInList = new System.Windows.Forms.Label();
            this.btnFirstAddressTransaction = new System.Windows.Forms.Button();
            this.btnNextAddressTransactions = new System.Windows.Forms.Button();
            this.listViewAddressTransactions = new System.Windows.Forms.ListView();
            this.imageListUpDownArrows = new System.Windows.Forms.ImageList(this.components);
            this.lblAddressConfirmedUnspentOutputs = new System.Windows.Forms.Label();
            this.lblAddressConfirmedSpentOutputs = new System.Windows.Forms.Label();
            this.lblAddressConfirmedReceivedOutputs = new System.Windows.Forms.Label();
            this.AddressQRCodePicturebox = new System.Windows.Forms.PictureBox();
            this.lblAddressConfirmedUnspent = new System.Windows.Forms.Label();
            this.lblAddressConfirmedSpent = new System.Windows.Forms.Label();
            this.lblAddressConfirmedReceived = new System.Windows.Forms.Label();
            this.lblAddressConfirmedTransactionCount = new System.Windows.Forms.Label();
            this.lblAddressType = new System.Windows.Forms.Label();
            this.pictureBoxLoadingAnimation = new System.Windows.Forms.PictureBox();
            this.panelBlock = new System.Windows.Forms.Panel();
            this.panelOwnNodeBlockTXInfo = new System.Windows.Forms.Panel();
            this.label160 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.lblBlockHash = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.label71 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.label62 = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.label65 = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.panel51 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.label72 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.label74 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.label68 = new System.Windows.Forms.Label();
            this.panel47 = new System.Windows.Forms.Panel();
            this.label69 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.label145 = new System.Windows.Forms.Label();
            this.btnPreviousBlock = new System.Windows.Forms.Button();
            this.btnNextBlock = new System.Windows.Forms.Button();
            this.lblNonce = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.listViewBlockTransactions = new System.Windows.Forms.ListView();
            this.lblBlockTXPositionInList = new System.Windows.Forms.Label();
            this.btnPreviousBlockTransactions = new System.Windows.Forms.Button();
            this.btnNextBlockTransactions = new System.Windows.Forms.Button();
            this.lblBlockTime = new System.Windows.Forms.Label();
            this.lblBlockFeeRangeAndMedianFee = new System.Windows.Forms.Label();
            this.lblMiner = new System.Windows.Forms.Label();
            this.lblBlockAverageFee = new System.Windows.Forms.Label();
            this.lblNumberOfTXInBlock = new System.Windows.Forms.Label();
            this.lblReward = new System.Windows.Forms.Label();
            this.lblBlockWeight = new System.Windows.Forms.Label();
            this.lblSizeOfBlock = new System.Windows.Forms.Label();
            this.textBoxSubmittedBlockNumber = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.pictureBoxSatsumaLogo = new System.Windows.Forms.PictureBox();
            this.lblSatsumaTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenuCharts = new System.Windows.Forms.Button();
            this.btnMenuAppearance = new System.Windows.Forms.Button();
            this.btnMenuSettings2 = new System.Windows.Forms.Button();
            this.btnMenuHelp = new System.Windows.Forms.Button();
            this.btnMenuBookmarks = new System.Windows.Forms.Button();
            this.btnMenuXpub = new System.Windows.Forms.Button();
            this.btnMenuTransaction = new System.Windows.Forms.Button();
            this.btnMenuBlockList = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnMenuSplash = new System.Windows.Forms.Button();
            this.btnMenuBlock = new System.Windows.Forms.Button();
            this.btnMenuAddress = new System.Windows.Forms.Button();
            this.btnMenuBitcoinDashboard = new System.Windows.Forms.Button();
            this.btnMenuLightningDashboard = new System.Windows.Forms.Button();
            this.panelBlockList = new System.Windows.Forms.Panel();
            this.panel45 = new System.Windows.Forms.Panel();
            this.label143 = new System.Windows.Forms.Label();
            this.progressBarBlockListHalvingProgress = new ColorProgressBar.ColorProgressBar();
            this.progressBarBlockListNextDiffAdj = new ColorProgressBar.ColorProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.lblBlockListProgressNextDiffAdjPercentage = new System.Windows.Forms.Label();
            this.lblBlockListHalvingBlockAndRemaining = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.lblBlockListBlockReward = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.lblBlockListEstHashRate = new System.Windows.Forms.Label();
            this.lblBlockListAvgTimeBetweenBlocks = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.lblBlockListNextDiffAdjBlock = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.lblBlockListAttemptsToSolveBlock = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.lblBlockListTXInMempool = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblBlockListBlockHeight = new System.Windows.Forms.Label();
            this.listViewBlockList = new System.Windows.Forms.ListView();
            this.lblBlockListPositionInList = new System.Windows.Forms.Label();
            this.btnNewer15Blocks = new System.Windows.Forms.Button();
            this.btnOlder15Blocks = new System.Windows.Forms.Button();
            this.textBoxBlockHeightToStartListFrom = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label90 = new System.Windows.Forms.Label();
            this.lblBlockListBlockSize = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.lblBlockListBlockWeight = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.lblBlockListReward = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.lblBlockListTransactionCount = new System.Windows.Forms.Label();
            this.lblBlockListVersion = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.lblBlockListAverageFee = new System.Windows.Forms.Label();
            this.lblBlockListAverageTransactionSize = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.lblBlockListMiner = new System.Windows.Forms.Label();
            this.lblBlockListTotalOutputs = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.lblBlockListBlockFeeRangeAndMedianFee = new System.Windows.Forms.Label();
            this.lblBlockListTotalInputs = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.lblBlockListBlockTime = new System.Windows.Forms.Label();
            this.lblBlockListBlockHash = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.lblBlockListTotalFees = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.lblBlockListNonce = new System.Windows.Forms.Label();
            this.panelRefreshStatusBar = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.panelTransaction = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.label102 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.label107 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btnTransactionOutputsUp = new System.Windows.Forms.Button();
            this.btnTransactionOutputsDown = new System.Windows.Forms.Button();
            this.panel24 = new System.Windows.Forms.Panel();
            this.btnTransactionInputsUp = new System.Windows.Forms.Button();
            this.btnTransactionInputDown = new System.Windows.Forms.Button();
            this.panelTransactionOutputs = new System.Windows.Forms.Panel();
            this.listViewTransactionOutputs = new System.Windows.Forms.ListView();
            this.panelTransactionInputs = new System.Windows.Forms.Panel();
            this.listViewTransactionInputs = new System.Windows.Forms.ListView();
            this.lblInvalidTransaction = new System.Windows.Forms.Label();
            this.panelTransactionHeadline = new System.Windows.Forms.Panel();
            this.lblTransactionConfirmations = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.lblTransactionVersion = new System.Windows.Forms.Label();
            this.lblTransactionBlockHeight = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.lblTransactionBlockTime = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.lblTransactionLockTime = new System.Windows.Forms.Label();
            this.panelTransactionDiagram = new System.Windows.Forms.Panel();
            this.lblTotalOutputValue = new System.Windows.Forms.Label();
            this.lblTotalInputValue = new System.Windows.Forms.Label();
            this.lblCoinbase = new System.Windows.Forms.Label();
            this.panelTransactionMiddle = new System.Windows.Forms.Panel();
            this.label132 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.lblTransactionSize = new System.Windows.Forms.Label();
            this.lblTransactionWeight = new System.Windows.Forms.Label();
            this.lblTransactionFee = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.lblTransactionInputCount = new System.Windows.Forms.Label();
            this.lblTransactionOutputCount = new System.Windows.Forms.Label();
            this.textBoxTransactionID = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.TXInScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.TXOutScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.panelXpub = new System.Windows.Forms.Panel();
            this.label141 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.numberUpDownDerivationPathsToCheck = new System.Windows.Forms.NumericUpDown();
            this.label139 = new System.Windows.Forms.Label();
            this.lblP2SHUsedAddresses = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.lblCheckAllAddressTypesCount = new System.Windows.Forms.Label();
            this.lblCheckEachAddressTypeCount = new System.Windows.Forms.Label();
            this.progressBarCheckAllAddressTypes = new ColorProgressBar.ColorProgressBar();
            this.progressBarCheckEachAddressType = new ColorProgressBar.ColorProgressBar();
            this.label18 = new System.Windows.Forms.Label();
            this.lblXpubNodeStatusLight = new System.Windows.Forms.Label();
            this.lblValidXpubIndicator = new System.Windows.Forms.Label();
            this.textBoxXpubNodeURL = new System.Windows.Forms.TextBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.btnXpubAddressesDown = new System.Windows.Forms.Button();
            this.btnXpubAddressUp = new System.Windows.Forms.Button();
            this.panelXpubContainer = new System.Windows.Forms.Panel();
            this.listViewXpubAddresses = new System.Windows.Forms.ListView();
            this.lblLegacyUsedAddresses = new System.Windows.Forms.Label();
            this.lblSegwitP2SHUsedAddresses = new System.Windows.Forms.Label();
            this.lblSegwitUsedAddresses = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.lblXpubConfirmedUnspent = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.label127 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.lblXpubConfirmedSpent = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.lblXpubConfirmedReceived = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label124 = new System.Windows.Forms.Label();
            this.lblXpubStatus = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label117 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.textBoxSubmittedXpub = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.timerHideProgressBars = new System.Windows.Forms.Timer(this.components);
            this.XpubScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.btnAddToBookmarks = new System.Windows.Forms.Button();
            this.panelAddToBookmarks = new System.Windows.Forms.Panel();
            this.lblBookmarkSavedSuccess = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label131 = new System.Windows.Forms.Label();
            this.lblBookmarkProposalType = new System.Windows.Forms.Label();
            this.lblBookmarkProposalData = new System.Windows.Forms.Label();
            this.textBoxBookmarkEncryptionKey = new System.Windows.Forms.TextBox();
            this.textBoxBookmarkProposedNote = new System.Windows.Forms.TextBox();
            this.btnCancelAddToBookmarks = new System.Windows.Forms.Button();
            this.btnCommitToBookmarks = new System.Windows.Forms.Button();
            this.panelFees = new System.Windows.Forms.Panel();
            this.lblHeaderHashrate = new System.Windows.Forms.Label();
            this.panel57 = new System.Windows.Forms.Panel();
            this.label150 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblFeesNoPriority = new System.Windows.Forms.Label();
            this.lblFeesLowPriority = new System.Windows.Forms.Label();
            this.lblfeesHighPriority = new System.Windows.Forms.Label();
            this.lblFeesMediumPriority = new System.Windows.Forms.Label();
            this.panelBookmarks = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.btnDecryptBookmark = new System.Windows.Forms.Button();
            this.lblBookmarkStatusMessage = new System.Windows.Forms.Label();
            this.textBoxBookmarkKey = new System.Windows.Forms.TextBox();
            this.btnBookmarkUnlock = new System.Windows.Forms.Button();
            this.btnDeleteBookmark = new System.Windows.Forms.Button();
            this.btnViewBookmark = new System.Windows.Forms.Button();
            this.label138 = new System.Windows.Forms.Label();
            this.lblBookmarkNoteInFull = new System.Windows.Forms.Label();
            this.lblSelectedBookmarkType = new System.Windows.Forms.Label();
            this.lblBookmarkDataInFull = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.btnBookmarksListDown = new System.Windows.Forms.Button();
            this.btnBookmarksListUp = new System.Windows.Forms.Button();
            this.panelBookmarksContainer = new System.Windows.Forms.Panel();
            this.listViewBookmarks = new System.Windows.Forms.ListView();
            this.panel36 = new System.Windows.Forms.Panel();
            this.lblBookmarkTotalCount = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.lblBookmarkBlocksCount = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.lblBookmarkTransactionsCount = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.lblBookmarkAddressCount = new System.Windows.Forms.Label();
            this.lblBookmarkXpubsCount = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.BookmarksScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.panelHeaderPrice = new System.Windows.Forms.Panel();
            this.lblHeaderMoscowTimeLabel = new System.Windows.Forms.Label();
            this.lblHeaderMarketCap = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.lblHeaderMoscowTime = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.hideAddToBookmarksTimer = new System.Windows.Forms.Timer(this.components);
            this.hideBookmarkStatusMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.lblNowViewing = new System.Windows.Forms.Label();
            this.panelHeaderBlockHeight = new System.Windows.Forms.Panel();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.panelCurrency = new System.Windows.Forms.Panel();
            this.btnXAU = new System.Windows.Forms.Button();
            this.btnUSD = new System.Windows.Forms.Button();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.btnEUR = new System.Windows.Forms.Button();
            this.btnGBP = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.panel77 = new System.Windows.Forms.Panel();
            this.lblBitcoinDashboard = new System.Windows.Forms.Label();
            this.numericUpDownDashboardRefresh = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWhatever = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.lblBitcoinExplorerEndpoints = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.lblLightningDashboard = new System.Windows.Forms.Label();
            this.lblBlockchainInfoEndpoints = new System.Windows.Forms.Label();
            this.lblBlockchairComJSON = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.lblMempoolLightningJSON = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.label201 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.textBoxSettingsXpubMempoolURL = new System.Windows.Forms.TextBox();
            this.panel74 = new System.Windows.Forms.Panel();
            this.label199 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.lblSettingsNodeMainnet = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.lblSettingsNodeTestnet = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.label200 = new System.Windows.Forms.Label();
            this.lblSettingsNodeCustom = new System.Windows.Forms.Label();
            this.textBoxSettingsCustomMempoolURL = new System.Windows.Forms.TextBox();
            this.label174 = new System.Windows.Forms.Label();
            this.lblURLWarning = new System.Windows.Forms.Label();
            this.lblSettingsCustomNodeStatus = new System.Windows.Forms.Label();
            this.lblSettingsCustomNodeStatusLight = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label163 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label162 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.lblSettingsXpubNodeStatusLight = new System.Windows.Forms.Label();
            this.lblSettingsXpubNodeStatus = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.label155 = new System.Windows.Forms.Label();
            this.btnColorLabels = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.btnColorDataFields = new System.Windows.Forms.Button();
            this.label154 = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel59 = new System.Windows.Forms.Panel();
            this.label156 = new System.Windows.Forms.Label();
            this.btnColorHeadings = new System.Windows.Forms.Button();
            this.colorProgressBar1 = new ColorProgressBar.ColorProgressBar();
            this.label161 = new System.Windows.Forms.Label();
            this.btnColorProgressBars = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnColorButtons = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnColorButtonText = new System.Windows.Forms.Button();
            this.panelAppearance = new System.Windows.Forms.Panel();
            this.panel73 = new System.Windows.Forms.Panel();
            this.label197 = new System.Windows.Forms.Label();
            this.btnColorPanels = new System.Windows.Forms.Button();
            this.panel71 = new System.Windows.Forms.Panel();
            this.lblThemeDeleted = new System.Windows.Forms.Label();
            this.btnDeleteTheme = new System.Windows.Forms.Button();
            this.comboBoxThemeList = new System.Windows.Forms.ComboBox();
            this.panel72 = new System.Windows.Forms.Panel();
            this.label195 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.btnLoadTheme = new System.Windows.Forms.Button();
            this.panel70 = new System.Windows.Forms.Panel();
            this.lblThemeSaved = new System.Windows.Forms.Label();
            this.panel69 = new System.Windows.Forms.Panel();
            this.label192 = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.textBoxThemeName = new System.Windows.Forms.TextBox();
            this.btnSaveTheme = new System.Windows.Forms.Button();
            this.label194 = new System.Windows.Forms.Label();
            this.textBoxThemeImage = new System.Windows.Forms.TextBox();
            this.lblBackgroundBTCdirSelected = new System.Windows.Forms.Label();
            this.lblBackgroundCustomColorSelected = new System.Windows.Forms.Label();
            this.lblBackgroundCustomImageSelected = new System.Windows.Forms.Label();
            this.lblBackgroundGenesisSelected = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.pictureBoxCustomImage = new System.Windows.Forms.PictureBox();
            this.panel68 = new System.Windows.Forms.Panel();
            this.label190 = new System.Windows.Forms.Label();
            this.btnListViewHeadingColor = new System.Windows.Forms.Button();
            this.panel67 = new System.Windows.Forms.Panel();
            this.label188 = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.label186 = new System.Windows.Forms.Label();
            this.btnColorTableTitleBar = new System.Windows.Forms.Button();
            this.btnColorTableBackground = new System.Windows.Forms.Button();
            this.panel65 = new System.Windows.Forms.Panel();
            this.label184 = new System.Windows.Forms.Label();
            this.btnColorTitleBackgrounds = new System.Windows.Forms.Button();
            this.lblTitleBackgroundCustom = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.lblTitleBackgroundNone = new System.Windows.Forms.Label();
            this.label187 = new System.Windows.Forms.Label();
            this.lblTitleBackgroundDefault = new System.Windows.Forms.Label();
            this.label185 = new System.Windows.Forms.Label();
            this.panel64 = new System.Windows.Forms.Panel();
            this.label183 = new System.Windows.Forms.Label();
            this.panel63 = new System.Windows.Forms.Panel();
            this.label182 = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.label181 = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.pictureBoxCustomColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxBTCDir = new System.Windows.Forms.PictureBox();
            this.pictureBoxGenesis = new System.Windows.Forms.PictureBox();
            this.lblShowClock = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.btnColorStatusError = new System.Windows.Forms.Button();
            this.label176 = new System.Windows.Forms.Label();
            this.btnColorPriceBlock = new System.Windows.Forms.Button();
            this.label175 = new System.Windows.Forms.Label();
            this.btnColorTextBox = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnColorOtherText = new System.Windows.Forms.Button();
            this.label173 = new System.Windows.Forms.Label();
            this.btnColorTableText = new System.Windows.Forms.Button();
            this.label170 = new System.Windows.Forms.Label();
            this.btnColorLines = new System.Windows.Forms.Button();
            this.label168 = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.panel60 = new System.Windows.Forms.Panel();
            this.label166 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.headerNetworkName = new System.Windows.Forms.Label();
            this.headerNetworkStatusLight = new System.Windows.Forms.Label();
            this.hideThemeSavedTimer = new System.Windows.Forms.Timer(this.components);
            this.hideThemeDeletedTimer = new System.Windows.Forms.Timer(this.components);
            this.panelCharts = new System.Windows.Forms.Panel();
            this.panel81 = new System.Windows.Forms.Panel();
            this.label231 = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.label228 = new System.Windows.Forms.Label();
            this.formsPlot3 = new ScottPlot.FormsPlot();
            this.btnChartNodesByCountry = new System.Windows.Forms.Button();
            this.panelLightningNodeNetwork = new System.Windows.Forms.Panel();
            this.label226 = new System.Windows.Forms.Label();
            this.label225 = new System.Windows.Forms.Label();
            this.label224 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.label227 = new System.Windows.Forms.Label();
            this.label236 = new System.Windows.Forms.Label();
            this.panel79 = new System.Windows.Forms.Panel();
            this.label218 = new System.Windows.Forms.Label();
            this.btnChartNodesByNetwork = new System.Windows.Forms.Button();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.btnChartPoolsRanking = new System.Windows.Forms.Button();
            this.panelChartUTXOScaleButtons = new System.Windows.Forms.Panel();
            this.btnChartUTXOScaleLog = new System.Windows.Forms.Button();
            this.btnChartUTXOScaleLinear = new System.Windows.Forms.Button();
            this.btnChartUTXO = new System.Windows.Forms.Button();
            this.panelPriceScaleButtons = new System.Windows.Forms.Panel();
            this.btnPriceChartScaleLog = new System.Windows.Forms.Button();
            this.btnPriceChartScaleLinear = new System.Windows.Forms.Button();
            this.panelUniqueAddressesScaleButtons = new System.Windows.Forms.Panel();
            this.btnChartAddressScaleLog = new System.Windows.Forms.Button();
            this.btnChartAddressScaleLinear = new System.Windows.Forms.Button();
            this.btnChartUniqueAddresses = new System.Windows.Forms.Button();
            this.lblChartMousePositionData = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.label217 = new System.Windows.Forms.Label();
            this.btnChartBlockSize = new System.Windows.Forms.Button();
            this.panelCirculationKey = new System.Windows.Forms.Panel();
            this.label222 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.label229 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.panelFeeRatesKey = new System.Windows.Forms.Panel();
            this.label216 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.label206 = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.btnChartCirculation = new System.Windows.Forms.Button();
            this.btnChartFeeRates = new System.Windows.Forms.Button();
            this.btnChartPeriodAll = new System.Windows.Forms.Button();
            this.btnChartPeriod3y = new System.Windows.Forms.Button();
            this.btnChartPeriod2y = new System.Windows.Forms.Button();
            this.btnChartPeriod1y = new System.Windows.Forms.Button();
            this.btnChartPeriod6m = new System.Windows.Forms.Button();
            this.btnChartPeriod3m = new System.Windows.Forms.Button();
            this.btnChartPeriod1m = new System.Windows.Forms.Button();
            this.btnChartPeriod1w = new System.Windows.Forms.Button();
            this.btnChartPeriod3d = new System.Windows.Forms.Button();
            this.btnChartPeriod24h = new System.Windows.Forms.Button();
            this.btnChartBlockFees = new System.Windows.Forms.Button();
            this.btnChartReward = new System.Windows.Forms.Button();
            this.btnChartPrice = new System.Windows.Forms.Button();
            this.btnChartDifficulty = new System.Windows.Forms.Button();
            this.btnChartHashrate = new System.Windows.Forms.Button();
            this.btnChartLightningCapacity = new System.Windows.Forms.Button();
            this.btnChartLightningChannels = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHashrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDifficultyChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderHashrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockListDifficultyChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockListHashrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderPriceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPriceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderFeeRatesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartFeeRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChartCirculation)).BeginInit();
            this.panelBitcoinDashboard.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelLightningDashboard.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAddress.SuspendLayout();
            this.panelOwnNodeAddressTXInfo.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddressQRCodePicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingAnimation)).BeginInit();
            this.panelBlock.SuspendLayout();
            this.panelOwnNodeBlockTXInfo.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel55.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSatsumaLogo)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelBlockList.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panelRefreshStatusBar.SuspendLayout();
            this.panelTransaction.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panelTransactionOutputs.SuspendLayout();
            this.panelTransactionInputs.SuspendLayout();
            this.panelTransactionHeadline.SuspendLayout();
            this.panelTransactionDiagram.SuspendLayout();
            this.panelTransactionMiddle.SuspendLayout();
            this.panelXpub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUpDownDerivationPathsToCheck)).BeginInit();
            this.panel30.SuspendLayout();
            this.panelXpubContainer.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panelAddToBookmarks.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panelFees.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panelBookmarks.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panelBookmarksContainer.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panelHeaderPrice.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panelHeaderBlockHeight.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panelCurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.panel77.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDashboardRefresh)).BeginInit();
            this.panel76.SuspendLayout();
            this.panel74.SuspendLayout();
            this.panel75.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel59.SuspendLayout();
            this.panelAppearance.SuspendLayout();
            this.panel73.SuspendLayout();
            this.panel71.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panel70.SuspendLayout();
            this.panel69.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomImage)).BeginInit();
            this.panel68.SuspendLayout();
            this.panel67.SuspendLayout();
            this.panel66.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panel64.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel62.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBTCDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenesis)).BeginInit();
            this.panel60.SuspendLayout();
            this.panelCharts.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel80.SuspendLayout();
            this.panelLightningNodeNetwork.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panelChartUTXOScaleButtons.SuspendLayout();
            this.panelPriceScaleButtons.SuspendLayout();
            this.panelUniqueAddressesScaleButtons.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panelCirculationKey.SuspendLayout();
            this.panelFeeRatesKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblTime.Location = new System.Drawing.Point(695, 91);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTime.Size = new System.Drawing.Size(116, 27);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "88:88:88";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1Sec
            // 
            this.timer1Sec.Interval = 1000;
            this.timer1Sec.Tick += new System.EventHandler(this.Timer1Sec_Tick);
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
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(765, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 24);
            this.btnExit.TabIndex = 6;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "❌";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblBlockNumber
            // 
            this.lblBlockNumber.AutoSize = true;
            this.lblBlockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockNumber.Font = new System.Drawing.Font("Myriad Pro Cond", 28.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockNumber.ForeColor = System.Drawing.Color.DimGray;
            this.lblBlockNumber.Location = new System.Drawing.Point(0, 20);
            this.lblBlockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlockNumber.Name = "lblBlockNumber";
            this.lblBlockNumber.Size = new System.Drawing.Size(145, 58);
            this.lblBlockNumber.TabIndex = 5;
            this.lblBlockNumber.Text = "000000";
            // 
            // timerAPIRefreshPeriod
            // 
            this.timerAPIRefreshPeriod.Interval = 60000;
            this.timerAPIRefreshPeriod.Tick += new System.EventHandler(this.TimerAPIRefreshPeriod_Tick);
            // 
            // btnMinimise
            // 
            this.btnMinimise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnMinimise.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMinimise.FlatAppearance.BorderSize = 0;
            this.btnMinimise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMinimise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimise.ForeColor = System.Drawing.Color.White;
            this.btnMinimise.Location = new System.Drawing.Point(736, 11);
            this.btnMinimise.Name = "btnMinimise";
            this.btnMinimise.Size = new System.Drawing.Size(24, 24);
            this.btnMinimise.TabIndex = 5;
            this.btnMinimise.TabStop = false;
            this.btnMinimise.Text = "➖";
            this.btnMinimise.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimise.UseVisualStyleBackColor = false;
            this.btnMinimise.Click += new System.EventHandler(this.BtnMinimise_Click);
            // 
            // btnMoveWindow
            // 
            this.btnMoveWindow.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveWindow.FlatAppearance.BorderSize = 0;
            this.btnMoveWindow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMoveWindow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMoveWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveWindow.Font = new System.Drawing.Font("Consolas", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveWindow.ForeColor = System.Drawing.Color.Transparent;
            this.btnMoveWindow.Location = new System.Drawing.Point(-9, -3);
            this.btnMoveWindow.Name = "btnMoveWindow";
            this.btnMoveWindow.Size = new System.Drawing.Size(824, 805);
            this.btnMoveWindow.TabIndex = 33;
            this.btnMoveWindow.TabStop = false;
            this.btnMoveWindow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveWindow.UseVisualStyleBackColor = false;
            this.btnMoveWindow.Click += new System.EventHandler(this.BtnMoveWindow_Click);
            this.btnMoveWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMoveWindow_MouseDown);
            this.btnMoveWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMoveWindow_MouseUp);
            // 
            // lblRefreshSuccessOrFailMessage
            // 
            this.lblRefreshSuccessOrFailMessage.AutoSize = true;
            this.lblRefreshSuccessOrFailMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblRefreshSuccessOrFailMessage.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshSuccessOrFailMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblRefreshSuccessOrFailMessage.Location = new System.Drawing.Point(26, 2);
            this.lblRefreshSuccessOrFailMessage.Name = "lblRefreshSuccessOrFailMessage";
            this.lblRefreshSuccessOrFailMessage.Size = new System.Drawing.Size(181, 17);
            this.lblRefreshSuccessOrFailMessage.TabIndex = 36;
            this.lblRefreshSuccessOrFailMessage.Text = "Data updated successfully.";
            // 
            // lblStatusLight
            // 
            this.lblStatusLight.AutoSize = true;
            this.lblStatusLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatusLight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLight.ForeColor = System.Drawing.Color.Silver;
            this.lblStatusLight.Location = new System.Drawing.Point(5, 2);
            this.lblStatusLight.Name = "lblStatusLight";
            this.lblStatusLight.Size = new System.Drawing.Size(23, 18);
            this.lblStatusLight.TabIndex = 37;
            this.lblStatusLight.Text = "🟢";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErrorMessage.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblErrorMessage.Location = new System.Drawing.Point(28, 743);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 15);
            this.lblErrorMessage.TabIndex = 40;
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAlert.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.ForeColor = System.Drawing.Color.Gold;
            this.lblAlert.Location = new System.Drawing.Point(6, 739);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(0, 22);
            this.lblAlert.TabIndex = 41;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 750;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label33.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Silver;
            this.label33.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label33.Location = new System.Drawing.Point(272, 454);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(155, 20);
            this.label33.TabIndex = 135;
            this.label33.Text = "Blockchain size (GB)";
            this.toolTip1.SetToolTip(this.label33, "(estimated)");
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label32.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Silver;
            this.label32.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label32.Location = new System.Drawing.Point(3, 454);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(242, 20);
            this.label32.TabIndex = 133;
            this.label32.Text = "Number of discoverable nodes*";
            this.toolTip1.SetToolTip(this.label32, "(estimated)");
            // 
            // lblNodes
            // 
            this.lblNodes.AutoSize = true;
            this.lblNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNodes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodes.Location = new System.Drawing.Point(3, 469);
            this.lblNodes.Name = "lblNodes";
            this.lblNodes.Size = new System.Drawing.Size(80, 22);
            this.lblNodes.TabIndex = 132;
            this.lblNodes.Text = "no data";
            this.toolTip1.SetToolTip(this.lblNodes, "(estimated)");
            // 
            // lblNextBlockTotalFees
            // 
            this.lblNextBlockTotalFees.AutoSize = true;
            this.lblNextBlockTotalFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNextBlockTotalFees.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextBlockTotalFees.Location = new System.Drawing.Point(549, 230);
            this.lblNextBlockTotalFees.Name = "lblNextBlockTotalFees";
            this.lblNextBlockTotalFees.Size = new System.Drawing.Size(80, 22);
            this.lblNextBlockTotalFees.TabIndex = 116;
            this.lblNextBlockTotalFees.Text = "no data";
            this.toolTip1.SetToolTip(this.lblNextBlockTotalFees, "(estimated)");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Silver;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label20.Location = new System.Drawing.Point(549, 215);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(219, 20);
            this.label20.TabIndex = 115;
            this.label20.Text = "Total fees in next block (BTC)*";
            this.toolTip1.SetToolTip(this.label20, "(estimated)");
            // 
            // lblNextBlockMinMaxFee
            // 
            this.lblNextBlockMinMaxFee.AutoSize = true;
            this.lblNextBlockMinMaxFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNextBlockMinMaxFee.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextBlockMinMaxFee.Location = new System.Drawing.Point(272, 230);
            this.lblNextBlockMinMaxFee.Name = "lblNextBlockMinMaxFee";
            this.lblNextBlockMinMaxFee.Size = new System.Drawing.Size(80, 22);
            this.lblNextBlockMinMaxFee.TabIndex = 114;
            this.lblNextBlockMinMaxFee.Text = "no data";
            this.toolTip1.SetToolTip(this.lblNextBlockMinMaxFee, "(estimated)");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Silver;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label21.Location = new System.Drawing.Point(272, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(212, 20);
            this.label21.TabIndex = 113;
            this.label21.Text = "Min / max fee in next block*";
            this.toolTip1.SetToolTip(this.label21, "(estimated)");
            // 
            // lblTransInNextBlock
            // 
            this.lblTransInNextBlock.AutoSize = true;
            this.lblTransInNextBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransInNextBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransInNextBlock.Location = new System.Drawing.Point(3, 267);
            this.lblTransInNextBlock.Name = "lblTransInNextBlock";
            this.lblTransInNextBlock.Size = new System.Drawing.Size(80, 22);
            this.lblTransInNextBlock.TabIndex = 110;
            this.lblTransInNextBlock.Text = "no data";
            this.toolTip1.SetToolTip(this.lblTransInNextBlock, "(estimated)");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Silver;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label17.Location = new System.Drawing.Point(3, 252);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(199, 20);
            this.label17.TabIndex = 109;
            this.label17.Text = "Transactions in next block*";
            this.toolTip1.SetToolTip(this.label17, "(estimated)");
            // 
            // lblEstimatedHalvingDate
            // 
            this.lblEstimatedHalvingDate.AutoSize = true;
            this.lblEstimatedHalvingDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstimatedHalvingDate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedHalvingDate.Location = new System.Drawing.Point(272, 533);
            this.lblEstimatedHalvingDate.Name = "lblEstimatedHalvingDate";
            this.lblEstimatedHalvingDate.Size = new System.Drawing.Size(80, 22);
            this.lblEstimatedHalvingDate.TabIndex = 139;
            this.lblEstimatedHalvingDate.Text = "no data";
            this.toolTip1.SetToolTip(this.lblEstimatedHalvingDate, "(estimated)");
            // 
            // lblHalvingSecondsRemaining
            // 
            this.lblHalvingSecondsRemaining.AutoSize = true;
            this.lblHalvingSecondsRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHalvingSecondsRemaining.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalvingSecondsRemaining.Location = new System.Drawing.Point(371, 533);
            this.lblHalvingSecondsRemaining.Name = "lblHalvingSecondsRemaining";
            this.lblHalvingSecondsRemaining.Size = new System.Drawing.Size(80, 22);
            this.lblHalvingSecondsRemaining.TabIndex = 140;
            this.lblHalvingSecondsRemaining.Text = "no data";
            this.toolTip1.SetToolTip(this.lblHalvingSecondsRemaining, "(estimated)");
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Silver;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label19.Location = new System.Drawing.Point(272, 518);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(232, 20);
            this.label19.TabIndex = 138;
            this.label19.Text = "Halving date / secs remaining*";
            this.toolTip1.SetToolTip(this.label19, "(estimated)");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label27.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Silver;
            this.label27.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label27.Location = new System.Drawing.Point(272, 316);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(233, 20);
            this.label27.TabIndex = 216;
            this.label27.Text = "Average time between blocks";
            this.toolTip1.SetToolTip(this.label27, "(estimated)");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label14.Location = new System.Drawing.Point(550, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(212, 20);
            this.label14.TabIndex = 215;
            this.label14.Text = "Avg transactions per block*";
            this.toolTip1.SetToolTip(this.label14, "calculated over the\r\nlast 100 blocks");
            // 
            // lblAvgNoTransactions
            // 
            this.lblAvgNoTransactions.AutoSize = true;
            this.lblAvgNoTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAvgNoTransactions.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgNoTransactions.Location = new System.Drawing.Point(550, 104);
            this.lblAvgNoTransactions.Name = "lblAvgNoTransactions";
            this.lblAvgNoTransactions.Size = new System.Drawing.Size(80, 22);
            this.lblAvgNoTransactions.TabIndex = 214;
            this.lblAvgNoTransactions.Text = "no data";
            this.toolTip1.SetToolTip(this.lblAvgNoTransactions, "calculated over the\r\nlast 100 blocks");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(272, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 205;
            this.label3.Text = "Next difficulty adjustment*";
            this.toolTip1.SetToolTip(this.label3, "(estimated)");
            // 
            // lblDifficultyAdjEst
            // 
            this.lblDifficultyAdjEst.AutoSize = true;
            this.lblDifficultyAdjEst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDifficultyAdjEst.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficultyAdjEst.Location = new System.Drawing.Point(272, 368);
            this.lblDifficultyAdjEst.Name = "lblDifficultyAdjEst";
            this.lblDifficultyAdjEst.Size = new System.Drawing.Size(80, 22);
            this.lblDifficultyAdjEst.TabIndex = 204;
            this.lblDifficultyAdjEst.Text = "no data";
            this.toolTip1.SetToolTip(this.lblDifficultyAdjEst, "(estimated)");
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label100.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.Color.Silver;
            this.label100.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label100.Location = new System.Drawing.Point(0, 72);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(199, 20);
            this.label100.TabIndex = 205;
            this.label100.Text = "Transactions in next block*";
            this.toolTip1.SetToolTip(this.label100, "(estimated)");
            // 
            // lblBlockListTXInNextBlock
            // 
            this.lblBlockListTXInNextBlock.AutoSize = true;
            this.lblBlockListTXInNextBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTXInNextBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListTXInNextBlock.Location = new System.Drawing.Point(0, 87);
            this.lblBlockListTXInNextBlock.Name = "lblBlockListTXInNextBlock";
            this.lblBlockListTXInNextBlock.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListTXInNextBlock.TabIndex = 206;
            this.lblBlockListTXInNextBlock.Text = "no data";
            this.toolTip1.SetToolTip(this.lblBlockListTXInNextBlock, "(estimated)");
            // 
            // lblBlockListMinMaxInFeeNextBlock
            // 
            this.lblBlockListMinMaxInFeeNextBlock.AutoSize = true;
            this.lblBlockListMinMaxInFeeNextBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListMinMaxInFeeNextBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListMinMaxInFeeNextBlock.Location = new System.Drawing.Point(0, 123);
            this.lblBlockListMinMaxInFeeNextBlock.Name = "lblBlockListMinMaxInFeeNextBlock";
            this.lblBlockListMinMaxInFeeNextBlock.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListMinMaxInFeeNextBlock.TabIndex = 208;
            this.lblBlockListMinMaxInFeeNextBlock.Text = "no data";
            this.toolTip1.SetToolTip(this.lblBlockListMinMaxInFeeNextBlock, "(estimated)");
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label106.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.ForeColor = System.Drawing.Color.Silver;
            this.label106.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label106.Location = new System.Drawing.Point(0, 108);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(212, 20);
            this.label106.TabIndex = 207;
            this.label106.Text = "Min / max fee in next block*";
            this.toolTip1.SetToolTip(this.label106, "(estimated)");
            // 
            // lblBlockListTotalFeesInNextBlock
            // 
            this.lblBlockListTotalFeesInNextBlock.AutoSize = true;
            this.lblBlockListTotalFeesInNextBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTotalFeesInNextBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListTotalFeesInNextBlock.Location = new System.Drawing.Point(0, 159);
            this.lblBlockListTotalFeesInNextBlock.Name = "lblBlockListTotalFeesInNextBlock";
            this.lblBlockListTotalFeesInNextBlock.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListTotalFeesInNextBlock.TabIndex = 210;
            this.lblBlockListTotalFeesInNextBlock.Text = "no data";
            this.toolTip1.SetToolTip(this.lblBlockListTotalFeesInNextBlock, "(estimated)");
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label108.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label108.ForeColor = System.Drawing.Color.Silver;
            this.label108.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label108.Location = new System.Drawing.Point(0, 144);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(219, 20);
            this.label108.TabIndex = 209;
            this.label108.Text = "Total fees in next block (BTC)*";
            this.toolTip1.SetToolTip(this.label108, "(estimated)");
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label115.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.Color.Silver;
            this.label115.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label115.Location = new System.Drawing.Point(0, 252);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(198, 20);
            this.label115.TabIndex = 218;
            this.label115.Text = "Avg time between blocks";
            this.toolTip1.SetToolTip(this.label115, "(estimated)");
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label116.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.ForeColor = System.Drawing.Color.Silver;
            this.label116.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label116.Location = new System.Drawing.Point(0, 288);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(197, 20);
            this.label116.TabIndex = 221;
            this.label116.Text = "Next difficulty adjustment*";
            this.toolTip1.SetToolTip(this.label116, "(estimated)");
            // 
            // lblBlockListNextDifficultyAdjustment
            // 
            this.lblBlockListNextDifficultyAdjustment.AutoSize = true;
            this.lblBlockListNextDifficultyAdjustment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListNextDifficultyAdjustment.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListNextDifficultyAdjustment.Location = new System.Drawing.Point(0, 303);
            this.lblBlockListNextDifficultyAdjustment.Name = "lblBlockListNextDifficultyAdjustment";
            this.lblBlockListNextDifficultyAdjustment.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListNextDifficultyAdjustment.TabIndex = 220;
            this.lblBlockListNextDifficultyAdjustment.Text = "no data";
            this.toolTip1.SetToolTip(this.lblBlockListNextDifficultyAdjustment, "(estimated)");
            // 
            // lblSegwitP2SHSummary
            // 
            this.lblSegwitP2SHSummary.AutoSize = true;
            this.lblSegwitP2SHSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSegwitP2SHSummary.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegwitP2SHSummary.Location = new System.Drawing.Point(0, 328);
            this.lblSegwitP2SHSummary.Name = "lblSegwitP2SHSummary";
            this.lblSegwitP2SHSummary.Size = new System.Drawing.Size(16, 18);
            this.lblSegwitP2SHSummary.TabIndex = 199;
            this.lblSegwitP2SHSummary.Text = "0";
            this.toolTip1.SetToolTip(this.lblSegwitP2SHSummary, "Conf.received, Conf.spent, Conf.unspent");
            this.lblSegwitP2SHSummary.Visible = false;
            // 
            // lblLegacySummary
            // 
            this.lblLegacySummary.AutoSize = true;
            this.lblLegacySummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLegacySummary.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegacySummary.Location = new System.Drawing.Point(0, 288);
            this.lblLegacySummary.Name = "lblLegacySummary";
            this.lblLegacySummary.Size = new System.Drawing.Size(16, 18);
            this.lblLegacySummary.TabIndex = 166;
            this.lblLegacySummary.Text = "0";
            this.toolTip1.SetToolTip(this.lblLegacySummary, "Conf.received, Conf.spent, Conf.unspent");
            this.lblLegacySummary.Visible = false;
            // 
            // lblSegwitSummary
            // 
            this.lblSegwitSummary.AutoSize = true;
            this.lblSegwitSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSegwitSummary.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegwitSummary.Location = new System.Drawing.Point(0, 250);
            this.lblSegwitSummary.Name = "lblSegwitSummary";
            this.lblSegwitSummary.Size = new System.Drawing.Size(16, 18);
            this.lblSegwitSummary.TabIndex = 152;
            this.lblSegwitSummary.Text = "0";
            this.toolTip1.SetToolTip(this.lblSegwitSummary, "Conf.received, Conf.spent, Conf.unspent");
            this.lblSegwitSummary.Visible = false;
            // 
            // lblP2SHSummary
            // 
            this.lblP2SHSummary.AutoSize = true;
            this.lblP2SHSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblP2SHSummary.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2SHSummary.Location = new System.Drawing.Point(0, 366);
            this.lblP2SHSummary.Name = "lblP2SHSummary";
            this.lblP2SHSummary.Size = new System.Drawing.Size(16, 18);
            this.lblP2SHSummary.TabIndex = 234;
            this.lblP2SHSummary.Text = "0";
            this.toolTip1.SetToolTip(this.lblP2SHSummary, "Conf.received, Conf.spent, Conf.unspent");
            this.lblP2SHSummary.Visible = false;
            // 
            // BtnViewBlockFromAddress
            // 
            this.BtnViewBlockFromAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.BtnViewBlockFromAddress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.BtnViewBlockFromAddress.FlatAppearance.BorderSize = 0;
            this.BtnViewBlockFromAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.BtnViewBlockFromAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.BtnViewBlockFromAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewBlockFromAddress.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnViewBlockFromAddress.ForeColor = System.Drawing.Color.White;
            this.BtnViewBlockFromAddress.Location = new System.Drawing.Point(497, 85);
            this.BtnViewBlockFromAddress.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.BtnViewBlockFromAddress.Name = "BtnViewBlockFromAddress";
            this.BtnViewBlockFromAddress.Size = new System.Drawing.Size(20, 15);
            this.BtnViewBlockFromAddress.TabIndex = 144;
            this.BtnViewBlockFromAddress.Text = "▶️";
            this.toolTip1.SetToolTip(this.BtnViewBlockFromAddress, "View block");
            this.BtnViewBlockFromAddress.UseVisualStyleBackColor = false;
            this.BtnViewBlockFromAddress.Visible = false;
            this.BtnViewBlockFromAddress.Click += new System.EventHandler(this.BtnViewBlockFromAddress_Click);
            // 
            // BtnViewTransactionFromAddress
            // 
            this.BtnViewTransactionFromAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.BtnViewTransactionFromAddress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.BtnViewTransactionFromAddress.FlatAppearance.BorderSize = 0;
            this.BtnViewTransactionFromAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.BtnViewTransactionFromAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.BtnViewTransactionFromAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewTransactionFromAddress.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnViewTransactionFromAddress.ForeColor = System.Drawing.Color.White;
            this.BtnViewTransactionFromAddress.Location = new System.Drawing.Point(465, 85);
            this.BtnViewTransactionFromAddress.Margin = new System.Windows.Forms.Padding(0);
            this.BtnViewTransactionFromAddress.Name = "BtnViewTransactionFromAddress";
            this.BtnViewTransactionFromAddress.Size = new System.Drawing.Size(20, 15);
            this.BtnViewTransactionFromAddress.TabIndex = 143;
            this.BtnViewTransactionFromAddress.Text = "▶️";
            this.toolTip1.SetToolTip(this.BtnViewTransactionFromAddress, "View transaction");
            this.BtnViewTransactionFromAddress.UseVisualStyleBackColor = false;
            this.BtnViewTransactionFromAddress.Visible = false;
            this.BtnViewTransactionFromAddress.Click += new System.EventHandler(this.BtnViewTransactionFromAddress_Click);
            // 
            // btnViewTransactionFromBlock
            // 
            this.btnViewTransactionFromBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewTransactionFromBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnViewTransactionFromBlock.FlatAppearance.BorderSize = 0;
            this.btnViewTransactionFromBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewTransactionFromBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewTransactionFromBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTransactionFromBlock.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTransactionFromBlock.ForeColor = System.Drawing.Color.White;
            this.btnViewTransactionFromBlock.Location = new System.Drawing.Point(376, 178);
            this.btnViewTransactionFromBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewTransactionFromBlock.Name = "btnViewTransactionFromBlock";
            this.btnViewTransactionFromBlock.Size = new System.Drawing.Size(20, 15);
            this.btnViewTransactionFromBlock.TabIndex = 165;
            this.btnViewTransactionFromBlock.TabStop = false;
            this.btnViewTransactionFromBlock.Text = "▶️";
            this.toolTip1.SetToolTip(this.btnViewTransactionFromBlock, "View transaction");
            this.btnViewTransactionFromBlock.UseVisualStyleBackColor = false;
            this.btnViewTransactionFromBlock.Visible = false;
            this.btnViewTransactionFromBlock.Click += new System.EventHandler(this.BtnViewTransactionFromBlock_Click);
            // 
            // btnViewBlockFromBlockList
            // 
            this.btnViewBlockFromBlockList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewBlockFromBlockList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnViewBlockFromBlockList.FlatAppearance.BorderSize = 0;
            this.btnViewBlockFromBlockList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewBlockFromBlockList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewBlockFromBlockList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBlockFromBlockList.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBlockFromBlockList.ForeColor = System.Drawing.Color.White;
            this.btnViewBlockFromBlockList.Location = new System.Drawing.Point(430, 145);
            this.btnViewBlockFromBlockList.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewBlockFromBlockList.Name = "btnViewBlockFromBlockList";
            this.btnViewBlockFromBlockList.Size = new System.Drawing.Size(18, 15);
            this.btnViewBlockFromBlockList.TabIndex = 165;
            this.btnViewBlockFromBlockList.TabStop = false;
            this.btnViewBlockFromBlockList.Text = "▶️";
            this.toolTip1.SetToolTip(this.btnViewBlockFromBlockList, "View block");
            this.btnViewBlockFromBlockList.UseVisualStyleBackColor = false;
            this.btnViewBlockFromBlockList.Visible = false;
            this.btnViewBlockFromBlockList.Click += new System.EventHandler(this.BtnViewBlockFromBlockList_Click);
            // 
            // btnViewAddressFromTXOutput
            // 
            this.btnViewAddressFromTXOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewAddressFromTXOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnViewAddressFromTXOutput.FlatAppearance.BorderSize = 0;
            this.btnViewAddressFromTXOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromTXOutput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromTXOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAddressFromTXOutput.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAddressFromTXOutput.ForeColor = System.Drawing.Color.White;
            this.btnViewAddressFromTXOutput.Location = new System.Drawing.Point(98, 20);
            this.btnViewAddressFromTXOutput.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewAddressFromTXOutput.Name = "btnViewAddressFromTXOutput";
            this.btnViewAddressFromTXOutput.Size = new System.Drawing.Size(20, 15);
            this.btnViewAddressFromTXOutput.TabIndex = 217;
            this.btnViewAddressFromTXOutput.Text = "▶️";
            this.toolTip1.SetToolTip(this.btnViewAddressFromTXOutput, "View address");
            this.btnViewAddressFromTXOutput.UseVisualStyleBackColor = false;
            this.btnViewAddressFromTXOutput.Visible = false;
            this.btnViewAddressFromTXOutput.Click += new System.EventHandler(this.BtnViewAddressFromTXOutput_Click);
            // 
            // btnViewAddressFromTXInput
            // 
            this.btnViewAddressFromTXInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewAddressFromTXInput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnViewAddressFromTXInput.FlatAppearance.BorderSize = 0;
            this.btnViewAddressFromTXInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromTXInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromTXInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAddressFromTXInput.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAddressFromTXInput.ForeColor = System.Drawing.Color.White;
            this.btnViewAddressFromTXInput.Location = new System.Drawing.Point(66, 28);
            this.btnViewAddressFromTXInput.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewAddressFromTXInput.Name = "btnViewAddressFromTXInput";
            this.btnViewAddressFromTXInput.Size = new System.Drawing.Size(20, 15);
            this.btnViewAddressFromTXInput.TabIndex = 216;
            this.btnViewAddressFromTXInput.Text = "▶️";
            this.toolTip1.SetToolTip(this.btnViewAddressFromTXInput, "View address");
            this.btnViewAddressFromTXInput.UseVisualStyleBackColor = false;
            this.btnViewAddressFromTXInput.Visible = false;
            this.btnViewAddressFromTXInput.Click += new System.EventHandler(this.BtnViewAddressFromTXInput_Click);
            // 
            // btnViewAddressFromXpub
            // 
            this.btnViewAddressFromXpub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewAddressFromXpub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnViewAddressFromXpub.FlatAppearance.BorderSize = 0;
            this.btnViewAddressFromXpub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromXpub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewAddressFromXpub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAddressFromXpub.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAddressFromXpub.ForeColor = System.Drawing.Color.White;
            this.btnViewAddressFromXpub.Location = new System.Drawing.Point(116, 36);
            this.btnViewAddressFromXpub.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewAddressFromXpub.Name = "btnViewAddressFromXpub";
            this.btnViewAddressFromXpub.Size = new System.Drawing.Size(20, 15);
            this.btnViewAddressFromXpub.TabIndex = 165;
            this.btnViewAddressFromXpub.Text = "▶️";
            this.toolTip1.SetToolTip(this.btnViewAddressFromXpub, "View address");
            this.btnViewAddressFromXpub.UseVisualStyleBackColor = false;
            this.btnViewAddressFromXpub.Visible = false;
            this.btnViewAddressFromXpub.Click += new System.EventHandler(this.BtnViewAddressFromXpub_Click);
            // 
            // pictureBoxHashrateChart
            // 
            this.pictureBoxHashrateChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHashrateChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxHashrateChart.Location = new System.Drawing.Point(640, 334);
            this.pictureBoxHashrateChart.Name = "pictureBoxHashrateChart";
            this.pictureBoxHashrateChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxHashrateChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHashrateChart.TabIndex = 231;
            this.pictureBoxHashrateChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxHashrateChart, "view chart");
            this.pictureBoxHashrateChart.Click += new System.EventHandler(this.PictureBoxHashrateChart_Click);
            // 
            // pictureBoxDifficultyChart
            // 
            this.pictureBoxDifficultyChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxDifficultyChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxDifficultyChart.Location = new System.Drawing.Point(366, 372);
            this.pictureBoxDifficultyChart.Name = "pictureBoxDifficultyChart";
            this.pictureBoxDifficultyChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxDifficultyChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDifficultyChart.TabIndex = 232;
            this.pictureBoxDifficultyChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxDifficultyChart, "view chart");
            this.pictureBoxDifficultyChart.Click += new System.EventHandler(this.PictureBoxDifficultyChart_Click);
            // 
            // pictureBoxHeaderHashrateChart
            // 
            this.pictureBoxHeaderHashrateChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHeaderHashrateChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxHeaderHashrateChart.Location = new System.Drawing.Point(69, 87);
            this.pictureBoxHeaderHashrateChart.Name = "pictureBoxHeaderHashrateChart";
            this.pictureBoxHeaderHashrateChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxHeaderHashrateChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHeaderHashrateChart.TabIndex = 233;
            this.pictureBoxHeaderHashrateChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxHeaderHashrateChart, "view chart");
            this.pictureBoxHeaderHashrateChart.Click += new System.EventHandler(this.PictureBoxHeaderHashrateChart_Click);
            // 
            // pictureBoxBlockListDifficultyChart
            // 
            this.pictureBoxBlockListDifficultyChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlockListDifficultyChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxBlockListDifficultyChart.Location = new System.Drawing.Point(84, 305);
            this.pictureBoxBlockListDifficultyChart.Name = "pictureBoxBlockListDifficultyChart";
            this.pictureBoxBlockListDifficultyChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxBlockListDifficultyChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlockListDifficultyChart.TabIndex = 234;
            this.pictureBoxBlockListDifficultyChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBlockListDifficultyChart, "view chart");
            this.pictureBoxBlockListDifficultyChart.Click += new System.EventHandler(this.PictureBoxBlockListDifficultyChart_Click);
            // 
            // pictureBoxBlockListHashrateChart
            // 
            this.pictureBoxBlockListHashrateChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlockListHashrateChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxBlockListHashrateChart.Location = new System.Drawing.Point(84, 377);
            this.pictureBoxBlockListHashrateChart.Name = "pictureBoxBlockListHashrateChart";
            this.pictureBoxBlockListHashrateChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxBlockListHashrateChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlockListHashrateChart.TabIndex = 237;
            this.pictureBoxBlockListHashrateChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBlockListHashrateChart, "view chart");
            this.pictureBoxBlockListHashrateChart.Click += new System.EventHandler(this.PictureBoxBlockListHashrateChart_Click);
            // 
            // pictureBoxHeaderPriceChart
            // 
            this.pictureBoxHeaderPriceChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHeaderPriceChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxHeaderPriceChart.Location = new System.Drawing.Point(110, 32);
            this.pictureBoxHeaderPriceChart.Name = "pictureBoxHeaderPriceChart";
            this.pictureBoxHeaderPriceChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxHeaderPriceChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHeaderPriceChart.TabIndex = 234;
            this.pictureBoxHeaderPriceChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxHeaderPriceChart, "view chart");
            this.pictureBoxHeaderPriceChart.Click += new System.EventHandler(this.PictureBoxHeaderPriceChart_Click);
            // 
            // pictureBoxPriceChart
            // 
            this.pictureBoxPriceChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPriceChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxPriceChart.Location = new System.Drawing.Point(88, 43);
            this.pictureBoxPriceChart.Name = "pictureBoxPriceChart";
            this.pictureBoxPriceChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxPriceChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPriceChart.TabIndex = 235;
            this.pictureBoxPriceChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxPriceChart, "view chart");
            this.pictureBoxPriceChart.Click += new System.EventHandler(this.PictureBoxPriceChart_Click);
            // 
            // pictureBoxHeaderFeeRatesChart
            // 
            this.pictureBoxHeaderFeeRatesChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHeaderFeeRatesChart.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxHeaderFeeRatesChart.Location = new System.Drawing.Point(210, 43);
            this.pictureBoxHeaderFeeRatesChart.Name = "pictureBoxHeaderFeeRatesChart";
            this.pictureBoxHeaderFeeRatesChart.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxHeaderFeeRatesChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHeaderFeeRatesChart.TabIndex = 235;
            this.pictureBoxHeaderFeeRatesChart.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxHeaderFeeRatesChart, "view chart");
            this.pictureBoxHeaderFeeRatesChart.Click += new System.EventHandler(this.PictureBoxHeaderFeeRatesChart_Click);
            // 
            // pictureBoxBlockScreenChartFeeRange
            // 
            this.pictureBoxBlockScreenChartFeeRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlockScreenChartFeeRange.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxBlockScreenChartFeeRange.Location = new System.Drawing.Point(137, 354);
            this.pictureBoxBlockScreenChartFeeRange.Name = "pictureBoxBlockScreenChartFeeRange";
            this.pictureBoxBlockScreenChartFeeRange.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxBlockScreenChartFeeRange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlockScreenChartFeeRange.TabIndex = 236;
            this.pictureBoxBlockScreenChartFeeRange.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBlockScreenChartFeeRange, "view chart");
            this.pictureBoxBlockScreenChartFeeRange.Click += new System.EventHandler(this.PictureBoxBlockScreenChartFeeRange_Click);
            // 
            // pictureBoxBlockScreenChartReward
            // 
            this.pictureBoxBlockScreenChartReward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlockScreenChartReward.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxBlockScreenChartReward.Location = new System.Drawing.Point(137, 306);
            this.pictureBoxBlockScreenChartReward.Name = "pictureBoxBlockScreenChartReward";
            this.pictureBoxBlockScreenChartReward.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxBlockScreenChartReward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlockScreenChartReward.TabIndex = 237;
            this.pictureBoxBlockScreenChartReward.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBlockScreenChartReward, "view chart");
            this.pictureBoxBlockScreenChartReward.Click += new System.EventHandler(this.PictureBoxBlockScreenChartReward_Click);
            // 
            // pictureBoxBlockScreenChartBlockSize
            // 
            this.pictureBoxBlockScreenChartBlockSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlockScreenChartBlockSize.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxBlockScreenChartBlockSize.Location = new System.Drawing.Point(137, 163);
            this.pictureBoxBlockScreenChartBlockSize.Name = "pictureBoxBlockScreenChartBlockSize";
            this.pictureBoxBlockScreenChartBlockSize.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxBlockScreenChartBlockSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlockScreenChartBlockSize.TabIndex = 238;
            this.pictureBoxBlockScreenChartBlockSize.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBlockScreenChartBlockSize, "view chart");
            this.pictureBoxBlockScreenChartBlockSize.Click += new System.EventHandler(this.PictureBoxBlockScreenChartBlockSize_Click);
            // 
            // pictureBoxChartCirculation
            // 
            this.pictureBoxChartCirculation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxChartCirculation.Image = global::SATSuma.Properties.Resources.graphIcon1;
            this.pictureBoxChartCirculation.Location = new System.Drawing.Point(176, 107);
            this.pictureBoxChartCirculation.Name = "pictureBoxChartCirculation";
            this.pictureBoxChartCirculation.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxChartCirculation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChartCirculation.TabIndex = 238;
            this.pictureBoxChartCirculation.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxChartCirculation, "view chart");
            this.pictureBoxChartCirculation.Click += new System.EventHandler(this.PictureBoxChartCirculation_Click);
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label134.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.ForeColor = System.Drawing.Color.Silver;
            this.label134.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label134.Location = new System.Drawing.Point(272, 390);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(272, 20);
            this.label134.TabIndex = 226;
            this.label134.Text = "Blocks until next difficulty adjustment";
            // 
            // lblBlocksUntilDiffAdj
            // 
            this.lblBlocksUntilDiffAdj.AutoSize = true;
            this.lblBlocksUntilDiffAdj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlocksUntilDiffAdj.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocksUntilDiffAdj.Location = new System.Drawing.Point(272, 405);
            this.lblBlocksUntilDiffAdj.Name = "lblBlocksUntilDiffAdj";
            this.lblBlocksUntilDiffAdj.Size = new System.Drawing.Size(80, 22);
            this.lblBlocksUntilDiffAdj.TabIndex = 225;
            this.lblBlocksUntilDiffAdj.Text = "no data";
            // 
            // lblHeaderPrice
            // 
            this.lblHeaderPrice.AutoSize = true;
            this.lblHeaderPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderPrice.Font = new System.Drawing.Font("Myriad Pro Cond", 28.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblHeaderPrice.Location = new System.Drawing.Point(0, 20);
            this.lblHeaderPrice.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeaderPrice.Name = "lblHeaderPrice";
            this.lblHeaderPrice.Size = new System.Drawing.Size(116, 58);
            this.lblHeaderPrice.TabIndex = 209;
            this.lblHeaderPrice.Text = "$0.00";
            // 
            // lblBlockchainSize
            // 
            this.lblBlockchainSize.AutoSize = true;
            this.lblBlockchainSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockchainSize.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockchainSize.Location = new System.Drawing.Point(272, 469);
            this.lblBlockchainSize.Name = "lblBlockchainSize";
            this.lblBlockchainSize.Size = new System.Drawing.Size(80, 22);
            this.lblBlockchainSize.TabIndex = 134;
            this.lblBlockchainSize.Text = "no data";
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactions.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblTransactions.Location = new System.Drawing.Point(88, 66);
            this.lblTransactions.Margin = new System.Windows.Forms.Padding(0);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(67, 20);
            this.lblTransactions.TabIndex = 59;
            this.lblTransactions.Text = "no data";
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockSize.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBlockSize.Location = new System.Drawing.Point(68, 85);
            this.lblBlockSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(67, 20);
            this.lblBlockSize.TabIndex = 60;
            this.lblBlockSize.Text = "no data";
            // 
            // lblElapsedSinceUpdate
            // 
            this.lblElapsedSinceUpdate.AutoSize = true;
            this.lblElapsedSinceUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblElapsedSinceUpdate.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedSinceUpdate.ForeColor = System.Drawing.Color.Gray;
            this.lblElapsedSinceUpdate.Location = new System.Drawing.Point(222, 2);
            this.lblElapsedSinceUpdate.Name = "lblElapsedSinceUpdate";
            this.lblElapsedSinceUpdate.Size = new System.Drawing.Size(203, 17);
            this.lblElapsedSinceUpdate.TabIndex = 84;
            this.lblElapsedSinceUpdate.Text = "Last updated xxx seconds ago";
            // 
            // panelBitcoinDashboard
            // 
            this.panelBitcoinDashboard.BackColor = System.Drawing.Color.Transparent;
            this.panelBitcoinDashboard.Controls.Add(this.pictureBoxChartCirculation);
            this.panelBitcoinDashboard.Controls.Add(this.pictureBoxPriceChart);
            this.panelBitcoinDashboard.Controls.Add(this.pictureBoxDifficultyChart);
            this.panelBitcoinDashboard.Controls.Add(this.pictureBoxHashrateChart);
            this.panelBitcoinDashboard.Controls.Add(this.progressBarProgressToHalving);
            this.panelBitcoinDashboard.Controls.Add(this.progressBarNextDiffAdj);
            this.panelBitcoinDashboard.Controls.Add(this.label23);
            this.panelBitcoinDashboard.Controls.Add(this.lblProgressNextDiffAdjPercentage);
            this.panelBitcoinDashboard.Controls.Add(this.label134);
            this.panelBitcoinDashboard.Controls.Add(this.lblBlocksUntilDiffAdj);
            this.panelBitcoinDashboard.Controls.Add(this.label137);
            this.panelBitcoinDashboard.Controls.Add(this.lblEstDiffAdjDate);
            this.panelBitcoinDashboard.Controls.Add(this.panel12);
            this.panelBitcoinDashboard.Controls.Add(this.panel11);
            this.panelBitcoinDashboard.Controls.Add(this.panel10);
            this.panelBitcoinDashboard.Controls.Add(this.label85);
            this.panelBitcoinDashboard.Controls.Add(this.label30);
            this.panelBitcoinDashboard.Controls.Add(this.lblHodlingAddresses);
            this.panelBitcoinDashboard.Controls.Add(this.panel6);
            this.panelBitcoinDashboard.Controls.Add(this.lblAvgTimeBetweenBlocks);
            this.panelBitcoinDashboard.Controls.Add(this.lblBlockRewardAfterHalving);
            this.panelBitcoinDashboard.Controls.Add(this.label27);
            this.panelBitcoinDashboard.Controls.Add(this.label14);
            this.panelBitcoinDashboard.Controls.Add(this.label33);
            this.panelBitcoinDashboard.Controls.Add(this.panel8);
            this.panelBitcoinDashboard.Controls.Add(this.lblAvgNoTransactions);
            this.panelBitcoinDashboard.Controls.Add(this.panel9);
            this.panelBitcoinDashboard.Controls.Add(this.lblBlockchainSize);
            this.panelBitcoinDashboard.Controls.Add(this.label32);
            this.panelBitcoinDashboard.Controls.Add(this.panel7);
            this.panelBitcoinDashboard.Controls.Add(this.label9);
            this.panelBitcoinDashboard.Controls.Add(this.lblNodes);
            this.panelBitcoinDashboard.Controls.Add(this.lblNextDiffAdjBlock);
            this.panelBitcoinDashboard.Controls.Add(this.label8);
            this.panelBitcoinDashboard.Controls.Add(this.lblHashesToSolve);
            this.panelBitcoinDashboard.Controls.Add(this.lblHalvingSecondsRemaining);
            this.panelBitcoinDashboard.Controls.Add(this.label7);
            this.panelBitcoinDashboard.Controls.Add(this.lblBTCInCirc);
            this.panelBitcoinDashboard.Controls.Add(this.lblEstimatedHalvingDate);
            this.panelBitcoinDashboard.Controls.Add(this.label13);
            this.panelBitcoinDashboard.Controls.Add(this.lblEstHashrate);
            this.panelBitcoinDashboard.Controls.Add(this.lbl24HourTransCount);
            this.panelBitcoinDashboard.Controls.Add(this.label19);
            this.panelBitcoinDashboard.Controls.Add(this.label10);
            this.panelBitcoinDashboard.Controls.Add(this.label3);
            this.panelBitcoinDashboard.Controls.Add(this.lbl24HourBTCSent);
            this.panelBitcoinDashboard.Controls.Add(this.lblDifficultyAdjEst);
            this.panelBitcoinDashboard.Controls.Add(this.label57);
            this.panelBitcoinDashboard.Controls.Add(this.label12);
            this.panelBitcoinDashboard.Controls.Add(this.lblBlocksIn24Hours);
            this.panelBitcoinDashboard.Controls.Add(this.label2);
            this.panelBitcoinDashboard.Controls.Add(this.label31);
            this.panelBitcoinDashboard.Controls.Add(this.lblHalveningBlock);
            this.panelBitcoinDashboard.Controls.Add(this.lblBlockReward);
            this.panelBitcoinDashboard.Controls.Add(this.lblMarketCapUSD);
            this.panelBitcoinDashboard.Controls.Add(this.lblMoscowTimeLabel);
            this.panelBitcoinDashboard.Controls.Add(this.lblMarketCapLabel);
            this.panelBitcoinDashboard.Controls.Add(this.lblMoscowTime);
            this.panelBitcoinDashboard.Controls.Add(this.lblPriceLabel);
            this.panelBitcoinDashboard.Controls.Add(this.lblNextBlockTotalFees);
            this.panelBitcoinDashboard.Controls.Add(this.lblPriceUSD);
            this.panelBitcoinDashboard.Controls.Add(this.label20);
            this.panelBitcoinDashboard.Controls.Add(this.label17);
            this.panelBitcoinDashboard.Controls.Add(this.lblTransInNextBlock);
            this.panelBitcoinDashboard.Controls.Add(this.lblNextBlockMinMaxFee);
            this.panelBitcoinDashboard.Controls.Add(this.label11);
            this.panelBitcoinDashboard.Controls.Add(this.lblTXInMempool);
            this.panelBitcoinDashboard.Controls.Add(this.label21);
            this.panelBitcoinDashboard.Location = new System.Drawing.Point(21, 188);
            this.panelBitcoinDashboard.Name = "panelBitcoinDashboard";
            this.panelBitcoinDashboard.Size = new System.Drawing.Size(773, 556);
            this.panelBitcoinDashboard.TabIndex = 87;
            this.panelBitcoinDashboard.Visible = false;
            this.panelBitcoinDashboard.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            // 
            // progressBarProgressToHalving
            // 
            this.progressBarProgressToHalving.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarProgressToHalving.BorderColor = System.Drawing.Color.Transparent;
            this.progressBarProgressToHalving.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarProgressToHalving.ForeColor = System.Drawing.Color.Black;
            this.progressBarProgressToHalving.Location = new System.Drawing.Point(6, 540);
            this.progressBarProgressToHalving.Maximum = 210000;
            this.progressBarProgressToHalving.Minimum = 0;
            this.progressBarProgressToHalving.Name = "progressBarProgressToHalving";
            this.progressBarProgressToHalving.Size = new System.Drawing.Size(150, 8);
            this.progressBarProgressToHalving.Step = 10;
            this.progressBarProgressToHalving.TabIndex = 230;
            this.progressBarProgressToHalving.Value = 0;
            // 
            // progressBarNextDiffAdj
            // 
            this.progressBarNextDiffAdj.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarNextDiffAdj.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.progressBarNextDiffAdj.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarNextDiffAdj.ForeColor = System.Drawing.Color.Black;
            this.progressBarNextDiffAdj.Location = new System.Drawing.Point(6, 412);
            this.progressBarNextDiffAdj.Maximum = 100;
            this.progressBarNextDiffAdj.Minimum = 0;
            this.progressBarNextDiffAdj.Name = "progressBarNextDiffAdj";
            this.progressBarNextDiffAdj.Size = new System.Drawing.Size(150, 8);
            this.progressBarNextDiffAdj.Step = 10;
            this.progressBarNextDiffAdj.TabIndex = 229;
            this.progressBarNextDiffAdj.Value = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label23.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Silver;
            this.label23.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label23.Location = new System.Drawing.Point(3, 390);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(273, 20);
            this.label23.TabIndex = 228;
            this.label23.Text = "Progress to next difficulty adjustment";
            // 
            // lblProgressNextDiffAdjPercentage
            // 
            this.lblProgressNextDiffAdjPercentage.AutoSize = true;
            this.lblProgressNextDiffAdjPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProgressNextDiffAdjPercentage.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressNextDiffAdjPercentage.Location = new System.Drawing.Point(158, 408);
            this.lblProgressNextDiffAdjPercentage.Name = "lblProgressNextDiffAdjPercentage";
            this.lblProgressNextDiffAdjPercentage.Size = new System.Drawing.Size(56, 15);
            this.lblProgressNextDiffAdjPercentage.TabIndex = 227;
            this.lblProgressNextDiffAdjPercentage.Text = "no data";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label137.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.ForeColor = System.Drawing.Color.Silver;
            this.label137.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label137.Location = new System.Drawing.Point(549, 390);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(239, 20);
            this.label137.TabIndex = 224;
            this.label137.Text = "Est. date of difficulty adjustment";
            // 
            // lblEstDiffAdjDate
            // 
            this.lblEstDiffAdjDate.AutoSize = true;
            this.lblEstDiffAdjDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstDiffAdjDate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstDiffAdjDate.Location = new System.Drawing.Point(549, 405);
            this.lblEstDiffAdjDate.Name = "lblEstDiffAdjDate";
            this.lblEstDiffAdjDate.Size = new System.Drawing.Size(80, 22);
            this.lblEstDiffAdjDate.TabIndex = 223;
            this.lblEstDiffAdjDate.Text = "no data";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel12.Controls.Add(this.label86);
            this.panel12.Location = new System.Drawing.Point(0, 429);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(250, 23);
            this.panel12.TabIndex = 198;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.Gray;
            this.label86.Location = new System.Drawing.Point(3, 1);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(143, 20);
            this.label86.TabIndex = 193;
            this.label86.Text = "Nodes / Chain size";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel11.Controls.Add(this.label84);
            this.panel11.Location = new System.Drawing.Point(0, 64);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(250, 23);
            this.panel11.TabIndex = 221;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Gray;
            this.label84.Location = new System.Drawing.Point(3, 1);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(150, 20);
            this.label84.TabIndex = 193;
            this.label84.Text = "Circulation / Usage";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Controls.Add(this.label83);
            this.panel10.Location = new System.Drawing.Point(0, 291);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(250, 23);
            this.panel10.TabIndex = 220;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Gray;
            this.label83.Location = new System.Drawing.Point(3, 1);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(151, 20);
            this.label83.TabIndex = 193;
            this.label83.Text = "Difficulty / Hashrate";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label85.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.Color.Silver;
            this.label85.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label85.Location = new System.Drawing.Point(549, 518);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(202, 20);
            this.label85.TabIndex = 201;
            this.label85.Text = "Block subsidy after halving";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label30.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Silver;
            this.label30.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label30.Location = new System.Drawing.Point(272, 89);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(221, 20);
            this.label30.TabIndex = 219;
            this.label30.Text = "Number of holding addresses";
            // 
            // lblHodlingAddresses
            // 
            this.lblHodlingAddresses.AutoSize = true;
            this.lblHodlingAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHodlingAddresses.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHodlingAddresses.Location = new System.Drawing.Point(272, 104);
            this.lblHodlingAddresses.Name = "lblHodlingAddresses";
            this.lblHodlingAddresses.Size = new System.Drawing.Size(80, 22);
            this.lblHodlingAddresses.TabIndex = 218;
            this.lblHodlingAddresses.Text = "no data";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.label79);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(250, 23);
            this.panel6.TabIndex = 195;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.Gray;
            this.label79.Location = new System.Drawing.Point(3, 1);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(153, 20);
            this.label79.TabIndex = 193;
            this.label79.Text = "Price / Market data";
            // 
            // lblAvgTimeBetweenBlocks
            // 
            this.lblAvgTimeBetweenBlocks.AutoSize = true;
            this.lblAvgTimeBetweenBlocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAvgTimeBetweenBlocks.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgTimeBetweenBlocks.Location = new System.Drawing.Point(272, 331);
            this.lblAvgTimeBetweenBlocks.Name = "lblAvgTimeBetweenBlocks";
            this.lblAvgTimeBetweenBlocks.Size = new System.Drawing.Size(80, 22);
            this.lblAvgTimeBetweenBlocks.TabIndex = 217;
            this.lblAvgTimeBetweenBlocks.Text = "no data";
            // 
            // lblBlockRewardAfterHalving
            // 
            this.lblBlockRewardAfterHalving.AutoSize = true;
            this.lblBlockRewardAfterHalving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockRewardAfterHalving.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockRewardAfterHalving.Location = new System.Drawing.Point(549, 533);
            this.lblBlockRewardAfterHalving.Name = "lblBlockRewardAfterHalving";
            this.lblBlockRewardAfterHalving.Size = new System.Drawing.Size(80, 22);
            this.lblBlockRewardAfterHalving.TabIndex = 200;
            this.lblBlockRewardAfterHalving.Text = "no data";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.label81);
            this.panel8.Location = new System.Drawing.Point(0, 190);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(250, 23);
            this.panel8.TabIndex = 196;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.Gray;
            this.label81.Location = new System.Drawing.Point(3, 1);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(80, 20);
            this.label81.TabIndex = 193;
            this.label81.Text = "Mempool";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Controls.Add(this.label82);
            this.panel9.Location = new System.Drawing.Point(0, 493);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(250, 23);
            this.panel9.TabIndex = 197;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Gray;
            this.label82.Location = new System.Drawing.Point(3, 1);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(64, 20);
            this.label82.TabIndex = 193;
            this.label82.Text = "Halving";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Controls.Add(this.label80);
            this.panel7.Location = new System.Drawing.Point(0, 128);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(250, 23);
            this.panel7.TabIndex = 196;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.Gray;
            this.label80.Location = new System.Drawing.Point(3, 1);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(100, 20);
            this.label80.TabIndex = 193;
            this.label80.Text = "Last 24 hours";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label9.Location = new System.Drawing.Point(3, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 20);
            this.label9.TabIndex = 213;
            this.label9.Text = "Block of next difficulty adjustment";
            // 
            // lblNextDiffAdjBlock
            // 
            this.lblNextDiffAdjBlock.AutoSize = true;
            this.lblNextDiffAdjBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNextDiffAdjBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDiffAdjBlock.Location = new System.Drawing.Point(3, 368);
            this.lblNextDiffAdjBlock.Name = "lblNextDiffAdjBlock";
            this.lblNextDiffAdjBlock.Size = new System.Drawing.Size(80, 22);
            this.lblNextDiffAdjBlock.TabIndex = 212;
            this.lblNextDiffAdjBlock.Text = "no data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(3, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(261, 20);
            this.label8.TabIndex = 211;
            this.label8.Text = "Avg no. of attempts to solve block";
            // 
            // lblHashesToSolve
            // 
            this.lblHashesToSolve.AutoSize = true;
            this.lblHashesToSolve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHashesToSolve.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHashesToSolve.Location = new System.Drawing.Point(3, 331);
            this.lblHashesToSolve.Name = "lblHashesToSolve";
            this.lblHashesToSolve.Size = new System.Drawing.Size(80, 22);
            this.lblHashesToSolve.TabIndex = 210;
            this.lblHashesToSolve.Text = "no data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(3, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 209;
            this.label7.Text = "Total BTC in circulation";
            // 
            // lblBTCInCirc
            // 
            this.lblBTCInCirc.AutoSize = true;
            this.lblBTCInCirc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBTCInCirc.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTCInCirc.Location = new System.Drawing.Point(3, 104);
            this.lblBTCInCirc.Name = "lblBTCInCirc";
            this.lblBTCInCirc.Size = new System.Drawing.Size(80, 22);
            this.lblBTCInCirc.TabIndex = 208;
            this.lblBTCInCirc.Text = "no data";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label13.Location = new System.Drawing.Point(549, 316);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 20);
            this.label13.TabIndex = 207;
            this.label13.Text = "Est. hashrate (hashes/sec)";
            // 
            // lblEstHashrate
            // 
            this.lblEstHashrate.AutoSize = true;
            this.lblEstHashrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstHashrate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstHashrate.Location = new System.Drawing.Point(549, 331);
            this.lblEstHashrate.Name = "lblEstHashrate";
            this.lblEstHashrate.Size = new System.Drawing.Size(80, 22);
            this.lblEstHashrate.TabIndex = 206;
            this.lblEstHashrate.Text = "no data";
            // 
            // lbl24HourTransCount
            // 
            this.lbl24HourTransCount.AutoSize = true;
            this.lbl24HourTransCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl24HourTransCount.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl24HourTransCount.Location = new System.Drawing.Point(272, 168);
            this.lbl24HourTransCount.Name = "lbl24HourTransCount";
            this.lbl24HourTransCount.Size = new System.Drawing.Size(80, 22);
            this.lbl24HourTransCount.TabIndex = 103;
            this.lbl24HourTransCount.Text = "no data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label10.Location = new System.Drawing.Point(272, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 20);
            this.label10.TabIndex = 104;
            this.label10.Text = "24 hour transaction count";
            // 
            // lbl24HourBTCSent
            // 
            this.lbl24HourBTCSent.AutoSize = true;
            this.lbl24HourBTCSent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl24HourBTCSent.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl24HourBTCSent.Location = new System.Drawing.Point(548, 168);
            this.lbl24HourBTCSent.Name = "lbl24HourBTCSent";
            this.lbl24HourBTCSent.Size = new System.Drawing.Size(80, 22);
            this.lbl24HourBTCSent.TabIndex = 105;
            this.lbl24HourBTCSent.Text = "no data";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label57.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Silver;
            this.label57.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label57.Location = new System.Drawing.Point(3, 518);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(247, 20);
            this.label57.TabIndex = 137;
            this.label57.Text = "Halving block / blocks remaining";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label12.Location = new System.Drawing.Point(549, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(229, 20);
            this.label12.TabIndex = 106;
            this.label12.Text = "24 hour number of bitcoin sent";
            // 
            // lblBlocksIn24Hours
            // 
            this.lblBlocksIn24Hours.AutoSize = true;
            this.lblBlocksIn24Hours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlocksIn24Hours.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlocksIn24Hours.Location = new System.Drawing.Point(3, 168);
            this.lblBlocksIn24Hours.Name = "lblBlocksIn24Hours";
            this.lblBlocksIn24Hours.Size = new System.Drawing.Size(80, 22);
            this.lblBlocksIn24Hours.TabIndex = 130;
            this.lblBlocksIn24Hours.Text = "no data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(549, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 203;
            this.label2.Text = "Block subsidy (BTC)";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label31.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Silver;
            this.label31.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label31.Location = new System.Drawing.Point(3, 153);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(241, 20);
            this.label31.TabIndex = 131;
            this.label31.Text = "24 hour number of blocks mined";
            // 
            // lblHalveningBlock
            // 
            this.lblHalveningBlock.AutoSize = true;
            this.lblHalveningBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHalveningBlock.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalveningBlock.Location = new System.Drawing.Point(158, 536);
            this.lblHalveningBlock.Name = "lblHalveningBlock";
            this.lblHalveningBlock.Size = new System.Drawing.Size(56, 15);
            this.lblHalveningBlock.TabIndex = 136;
            this.lblHalveningBlock.Text = "no data";
            // 
            // lblBlockReward
            // 
            this.lblBlockReward.AutoSize = true;
            this.lblBlockReward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockReward.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockReward.Location = new System.Drawing.Point(549, 368);
            this.lblBlockReward.Name = "lblBlockReward";
            this.lblBlockReward.Size = new System.Drawing.Size(80, 22);
            this.lblBlockReward.TabIndex = 202;
            this.lblBlockReward.Text = "no data";
            // 
            // lblMarketCapUSD
            // 
            this.lblMarketCapUSD.AutoSize = true;
            this.lblMarketCapUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMarketCapUSD.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketCapUSD.Location = new System.Drawing.Point(550, 40);
            this.lblMarketCapUSD.Name = "lblMarketCapUSD";
            this.lblMarketCapUSD.Size = new System.Drawing.Size(80, 22);
            this.lblMarketCapUSD.TabIndex = 89;
            this.lblMarketCapUSD.Text = "no data";
            // 
            // lblMoscowTimeLabel
            // 
            this.lblMoscowTimeLabel.AutoSize = true;
            this.lblMoscowTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMoscowTimeLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoscowTimeLabel.ForeColor = System.Drawing.Color.Silver;
            this.lblMoscowTimeLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMoscowTimeLabel.Location = new System.Drawing.Point(272, 25);
            this.lblMoscowTimeLabel.Name = "lblMoscowTimeLabel";
            this.lblMoscowTimeLabel.Size = new System.Drawing.Size(93, 20);
            this.lblMoscowTimeLabel.TabIndex = 88;
            this.lblMoscowTimeLabel.Text = "1 USD / Sats";
            // 
            // lblMarketCapLabel
            // 
            this.lblMarketCapLabel.AutoSize = true;
            this.lblMarketCapLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMarketCapLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketCapLabel.ForeColor = System.Drawing.Color.Silver;
            this.lblMarketCapLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMarketCapLabel.Location = new System.Drawing.Point(550, 25);
            this.lblMarketCapLabel.Name = "lblMarketCapLabel";
            this.lblMarketCapLabel.Size = new System.Drawing.Size(139, 20);
            this.lblMarketCapLabel.TabIndex = 90;
            this.lblMarketCapLabel.Text = "Market cap (USD)";
            // 
            // lblMoscowTime
            // 
            this.lblMoscowTime.AutoSize = true;
            this.lblMoscowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMoscowTime.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoscowTime.Location = new System.Drawing.Point(272, 40);
            this.lblMoscowTime.Name = "lblMoscowTime";
            this.lblMoscowTime.Size = new System.Drawing.Size(80, 22);
            this.lblMoscowTime.TabIndex = 87;
            this.lblMoscowTime.Text = "no data";
            // 
            // lblPriceLabel
            // 
            this.lblPriceLabel.AutoSize = true;
            this.lblPriceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPriceLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceLabel.ForeColor = System.Drawing.Color.Silver;
            this.lblPriceLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblPriceLabel.Location = new System.Drawing.Point(3, 25);
            this.lblPriceLabel.Name = "lblPriceLabel";
            this.lblPriceLabel.Size = new System.Drawing.Size(91, 20);
            this.lblPriceLabel.TabIndex = 86;
            this.lblPriceLabel.Text = "1 BTC / USD";
            // 
            // lblPriceUSD
            // 
            this.lblPriceUSD.AutoSize = true;
            this.lblPriceUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPriceUSD.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceUSD.Location = new System.Drawing.Point(3, 40);
            this.lblPriceUSD.Name = "lblPriceUSD";
            this.lblPriceUSD.Size = new System.Drawing.Size(80, 22);
            this.lblPriceUSD.TabIndex = 85;
            this.lblPriceUSD.Text = "no data";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label11.Location = new System.Drawing.Point(3, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 20);
            this.label11.TabIndex = 94;
            this.label11.Text = "Transactions in Mempool";
            // 
            // lblTXInMempool
            // 
            this.lblTXInMempool.AutoSize = true;
            this.lblTXInMempool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTXInMempool.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTXInMempool.Location = new System.Drawing.Point(3, 230);
            this.lblTXInMempool.Name = "lblTXInMempool";
            this.lblTXInMempool.Size = new System.Drawing.Size(80, 22);
            this.lblTXInMempool.TabIndex = 93;
            this.lblTXInMempool.Text = "no data";
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(100, 0);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(682, 521);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormsPlot1_MouseMove);
            // 
            // panelLightningDashboard
            // 
            this.panelLightningDashboard.BackColor = System.Drawing.Color.Transparent;
            this.panelLightningDashboard.Controls.Add(this.panel5);
            this.panelLightningDashboard.Controls.Add(this.panel4);
            this.panelLightningDashboard.Controls.Add(this.panel3);
            this.panelLightningDashboard.Controls.Add(this.panel2);
            this.panelLightningDashboard.Controls.Add(this.panel1);
            this.panelLightningDashboard.Controls.Add(this.label43);
            this.panelLightningDashboard.Controls.Add(this.lblMedBaseFeeTokens);
            this.panelLightningDashboard.Controls.Add(this.label44);
            this.panelLightningDashboard.Controls.Add(this.lblMedFeeRate);
            this.panelLightningDashboard.Controls.Add(this.label42);
            this.panelLightningDashboard.Controls.Add(this.lblMedCapacity);
            this.panelLightningDashboard.Controls.Add(this.label41);
            this.panelLightningDashboard.Controls.Add(this.lblAverageBaseFeeMtokens);
            this.panelLightningDashboard.Controls.Add(this.label39);
            this.panelLightningDashboard.Controls.Add(this.lblAverageFeeRate);
            this.panelLightningDashboard.Controls.Add(this.label37);
            this.panelLightningDashboard.Controls.Add(this.lblAverageCapacity);
            this.panelLightningDashboard.Controls.Add(this.label34);
            this.panelLightningDashboard.Controls.Add(this.lblChannelCount);
            this.panelLightningDashboard.Controls.Add(this.label46);
            this.panelLightningDashboard.Controls.Add(this.lblUnannouncedNodes);
            this.panelLightningDashboard.Controls.Add(this.label45);
            this.panelLightningDashboard.Controls.Add(this.lblClearnetTorNodes);
            this.panelLightningDashboard.Controls.Add(this.label35);
            this.panelLightningDashboard.Controls.Add(this.lblClearnetNodes);
            this.panelLightningDashboard.Controls.Add(this.label40);
            this.panelLightningDashboard.Controls.Add(this.lblNodeCount);
            this.panelLightningDashboard.Controls.Add(this.label36);
            this.panelLightningDashboard.Controls.Add(this.lblTorNodes);
            this.panelLightningDashboard.Controls.Add(this.label55);
            this.panelLightningDashboard.Controls.Add(this.label56);
            this.panelLightningDashboard.Controls.Add(this.channelLabel9);
            this.panelLightningDashboard.Controls.Add(this.channelLabel10);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel10);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel9);
            this.panelLightningDashboard.Controls.Add(this.channelLabel7);
            this.panelLightningDashboard.Controls.Add(this.channelLabel8);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel8);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel7);
            this.panelLightningDashboard.Controls.Add(this.channelLabel5);
            this.panelLightningDashboard.Controls.Add(this.channelLabel6);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel6);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel5);
            this.panelLightningDashboard.Controls.Add(this.channelLabel3);
            this.panelLightningDashboard.Controls.Add(this.channelLabel4);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel4);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel3);
            this.panelLightningDashboard.Controls.Add(this.channelLabel1);
            this.panelLightningDashboard.Controls.Add(this.channelLabel2);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel2);
            this.panelLightningDashboard.Controls.Add(this.aliasConnLabel1);
            this.panelLightningDashboard.Controls.Add(this.label52);
            this.panelLightningDashboard.Controls.Add(this.label51);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel9);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel10);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel10);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel9);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel7);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel8);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel8);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel7);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel5);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel6);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel6);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel5);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel3);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel4);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel4);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel3);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel1);
            this.panelLightningDashboard.Controls.Add(this.capacityLabel2);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel2);
            this.panelLightningDashboard.Controls.Add(this.aliasLabel1);
            this.panelLightningDashboard.Controls.Add(this.label50);
            this.panelLightningDashboard.Controls.Add(this.label49);
            this.panelLightningDashboard.Controls.Add(this.lblUnknownCapacity);
            this.panelLightningDashboard.Controls.Add(this.label48);
            this.panelLightningDashboard.Controls.Add(this.lblTorCapacity);
            this.panelLightningDashboard.Controls.Add(this.label47);
            this.panelLightningDashboard.Controls.Add(this.lblClearnetCapacity);
            this.panelLightningDashboard.Controls.Add(this.label38);
            this.panelLightningDashboard.Controls.Add(this.lblTotalCapacity);
            this.panelLightningDashboard.Location = new System.Drawing.Point(21, 188);
            this.panelLightningDashboard.Name = "panelLightningDashboard";
            this.panelLightningDashboard.Size = new System.Drawing.Size(773, 556);
            this.panelLightningDashboard.TabIndex = 88;
            this.panelLightningDashboard.Visible = false;
            this.panelLightningDashboard.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            this.panelLightningDashboard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLightningDashboard_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.label78);
            this.panel5.Location = new System.Drawing.Point(385, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(359, 23);
            this.panel5.TabIndex = 197;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Gray;
            this.label78.Location = new System.Drawing.Point(3, 1);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(77, 20);
            this.label78.TabIndex = 193;
            this.label78.Text = "Channels";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label76);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(359, 23);
            this.panel4.TabIndex = 196;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.Gray;
            this.label76.Location = new System.Drawing.Point(3, 1);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(77, 20);
            this.label76.TabIndex = 193;
            this.label76.Text = "Capacity";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label75);
            this.panel3.Location = new System.Drawing.Point(0, 138);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 23);
            this.panel3.TabIndex = 195;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.Gray;
            this.label75.Location = new System.Drawing.Point(3, 1);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(56, 20);
            this.label75.TabIndex = 193;
            this.label75.Text = "Nodes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label53);
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 23);
            this.panel2.TabIndex = 194;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Gray;
            this.label53.Location = new System.Drawing.Point(3, 1);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(169, 20);
            this.label53.TabIndex = 193;
            this.label53.Text = "Highest liquidity nodes";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label54);
            this.panel1.Location = new System.Drawing.Point(385, 312);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 23);
            this.panel1.TabIndex = 192;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Gray;
            this.label54.Location = new System.Drawing.Point(3, 1);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(207, 20);
            this.label54.TabIndex = 193;
            this.label54.Text = "Highest connectivity nodes";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label43.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Silver;
            this.label43.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label43.Location = new System.Drawing.Point(576, 209);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(202, 20);
            this.label43.TabIndex = 189;
            this.label43.Text = "Med base fee rate (mSats)";
            // 
            // lblMedBaseFeeTokens
            // 
            this.lblMedBaseFeeTokens.AutoSize = true;
            this.lblMedBaseFeeTokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMedBaseFeeTokens.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedBaseFeeTokens.Location = new System.Drawing.Point(576, 224);
            this.lblMedBaseFeeTokens.Name = "lblMedBaseFeeTokens";
            this.lblMedBaseFeeTokens.Size = new System.Drawing.Size(80, 22);
            this.lblMedBaseFeeTokens.TabIndex = 188;
            this.lblMedBaseFeeTokens.Text = "no data";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label44.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Silver;
            this.label44.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label44.Location = new System.Drawing.Point(576, 172);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(154, 20);
            this.label44.TabIndex = 187;
            this.label44.Text = "Med fee rate (ppm)";
            // 
            // lblMedFeeRate
            // 
            this.lblMedFeeRate.AutoSize = true;
            this.lblMedFeeRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMedFeeRate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedFeeRate.Location = new System.Drawing.Point(576, 187);
            this.lblMedFeeRate.Name = "lblMedFeeRate";
            this.lblMedFeeRate.Size = new System.Drawing.Size(80, 22);
            this.lblMedFeeRate.TabIndex = 186;
            this.lblMedFeeRate.Text = "no data";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label42.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Silver;
            this.label42.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label42.Location = new System.Drawing.Point(576, 135);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(155, 20);
            this.label42.TabIndex = 185;
            this.label42.Text = "Med capacity (sats)";
            // 
            // lblMedCapacity
            // 
            this.lblMedCapacity.AutoSize = true;
            this.lblMedCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMedCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedCapacity.Location = new System.Drawing.Point(576, 150);
            this.lblMedCapacity.Name = "lblMedCapacity";
            this.lblMedCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblMedCapacity.TabIndex = 184;
            this.lblMedCapacity.Text = "no data";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Silver;
            this.label41.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label41.Location = new System.Drawing.Point(576, 98);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(198, 20);
            this.label41.TabIndex = 183;
            this.label41.Text = "Avg base fee rate (mSats)";
            // 
            // lblAverageBaseFeeMtokens
            // 
            this.lblAverageBaseFeeMtokens.AutoSize = true;
            this.lblAverageBaseFeeMtokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAverageBaseFeeMtokens.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageBaseFeeMtokens.Location = new System.Drawing.Point(576, 113);
            this.lblAverageBaseFeeMtokens.Name = "lblAverageBaseFeeMtokens";
            this.lblAverageBaseFeeMtokens.Size = new System.Drawing.Size(80, 22);
            this.lblAverageBaseFeeMtokens.TabIndex = 182;
            this.lblAverageBaseFeeMtokens.Text = "no data";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label39.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Silver;
            this.label39.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label39.Location = new System.Drawing.Point(576, 61);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(150, 20);
            this.label39.TabIndex = 181;
            this.label39.Text = "Avg fee rate (ppm)";
            // 
            // lblAverageFeeRate
            // 
            this.lblAverageFeeRate.AutoSize = true;
            this.lblAverageFeeRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAverageFeeRate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageFeeRate.Location = new System.Drawing.Point(576, 76);
            this.lblAverageFeeRate.Name = "lblAverageFeeRate";
            this.lblAverageFeeRate.Size = new System.Drawing.Size(80, 22);
            this.lblAverageFeeRate.TabIndex = 180;
            this.lblAverageFeeRate.Text = "no data";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label37.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Silver;
            this.label37.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label37.Location = new System.Drawing.Point(576, 24);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(151, 20);
            this.label37.TabIndex = 179;
            this.label37.Text = "Avg capacity (sats)";
            // 
            // lblAverageCapacity
            // 
            this.lblAverageCapacity.AutoSize = true;
            this.lblAverageCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAverageCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageCapacity.Location = new System.Drawing.Point(576, 39);
            this.lblAverageCapacity.Name = "lblAverageCapacity";
            this.lblAverageCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblAverageCapacity.TabIndex = 178;
            this.lblAverageCapacity.Text = "no data";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label34.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Silver;
            this.label34.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label34.Location = new System.Drawing.Point(388, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(118, 20);
            this.label34.TabIndex = 177;
            this.label34.Text = "Channel count";
            // 
            // lblChannelCount
            // 
            this.lblChannelCount.AutoSize = true;
            this.lblChannelCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChannelCount.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannelCount.Location = new System.Drawing.Point(388, 39);
            this.lblChannelCount.Name = "lblChannelCount";
            this.lblChannelCount.Size = new System.Drawing.Size(80, 22);
            this.lblChannelCount.TabIndex = 176;
            this.lblChannelCount.Text = "no data";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label46.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Silver;
            this.label46.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label46.Location = new System.Drawing.Point(188, 274);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(164, 20);
            this.label46.TabIndex = 175;
            this.label46.Text = "Unannounced nodes";
            // 
            // lblUnannouncedNodes
            // 
            this.lblUnannouncedNodes.AutoSize = true;
            this.lblUnannouncedNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnannouncedNodes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnannouncedNodes.Location = new System.Drawing.Point(188, 289);
            this.lblUnannouncedNodes.Name = "lblUnannouncedNodes";
            this.lblUnannouncedNodes.Size = new System.Drawing.Size(80, 22);
            this.lblUnannouncedNodes.TabIndex = 174;
            this.lblUnannouncedNodes.Text = "no data";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label45.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Silver;
            this.label45.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label45.Location = new System.Drawing.Point(188, 237);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(148, 20);
            this.label45.TabIndex = 173;
            this.label45.Text = "Clearnet Tor Nodes";
            // 
            // lblClearnetTorNodes
            // 
            this.lblClearnetTorNodes.AutoSize = true;
            this.lblClearnetTorNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClearnetTorNodes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearnetTorNodes.Location = new System.Drawing.Point(188, 252);
            this.lblClearnetTorNodes.Name = "lblClearnetTorNodes";
            this.lblClearnetTorNodes.Size = new System.Drawing.Size(80, 22);
            this.lblClearnetTorNodes.TabIndex = 172;
            this.lblClearnetTorNodes.Text = "no data";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label35.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Silver;
            this.label35.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label35.Location = new System.Drawing.Point(188, 200);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(122, 20);
            this.label35.TabIndex = 171;
            this.label35.Text = "Clearnet nodes";
            // 
            // lblClearnetNodes
            // 
            this.lblClearnetNodes.AutoSize = true;
            this.lblClearnetNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClearnetNodes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearnetNodes.Location = new System.Drawing.Point(188, 215);
            this.lblClearnetNodes.Name = "lblClearnetNodes";
            this.lblClearnetNodes.Size = new System.Drawing.Size(80, 22);
            this.lblClearnetNodes.TabIndex = 170;
            this.lblClearnetNodes.Text = "no data";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label40.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Silver;
            this.label40.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label40.Location = new System.Drawing.Point(3, 163);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(97, 20);
            this.label40.TabIndex = 169;
            this.label40.Text = "Node count";
            // 
            // lblNodeCount
            // 
            this.lblNodeCount.AutoSize = true;
            this.lblNodeCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNodeCount.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodeCount.Location = new System.Drawing.Point(3, 178);
            this.lblNodeCount.Name = "lblNodeCount";
            this.lblNodeCount.Size = new System.Drawing.Size(80, 22);
            this.lblNodeCount.TabIndex = 168;
            this.lblNodeCount.Text = "no data";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label36.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Silver;
            this.label36.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label36.Location = new System.Drawing.Point(188, 163);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(78, 20);
            this.label36.TabIndex = 167;
            this.label36.Text = "Tor nodes";
            // 
            // lblTorNodes
            // 
            this.lblTorNodes.AutoSize = true;
            this.lblTorNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTorNodes.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTorNodes.Location = new System.Drawing.Point(188, 178);
            this.lblTorNodes.Name = "lblTorNodes";
            this.lblTorNodes.Size = new System.Drawing.Size(80, 22);
            this.lblTorNodes.TabIndex = 166;
            this.lblTorNodes.Text = "no data";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label55.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Silver;
            this.label55.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label55.Location = new System.Drawing.Point(576, 336);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(77, 20);
            this.label55.TabIndex = 164;
            this.label55.Text = "Channels";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label56.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Silver;
            this.label56.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label56.Location = new System.Drawing.Point(388, 336);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(42, 20);
            this.label56.TabIndex = 163;
            this.label56.Text = "Alias";
            // 
            // channelLabel9
            // 
            this.channelLabel9.AutoSize = true;
            this.channelLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel9.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel9.Location = new System.Drawing.Point(576, 511);
            this.channelLabel9.Name = "channelLabel9";
            this.channelLabel9.Size = new System.Drawing.Size(80, 22);
            this.channelLabel9.TabIndex = 162;
            this.channelLabel9.Text = "no data";
            // 
            // channelLabel10
            // 
            this.channelLabel10.AutoSize = true;
            this.channelLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel10.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel10.Location = new System.Drawing.Point(576, 531);
            this.channelLabel10.Name = "channelLabel10";
            this.channelLabel10.Size = new System.Drawing.Size(80, 22);
            this.channelLabel10.TabIndex = 161;
            this.channelLabel10.Text = "no data";
            // 
            // aliasConnLabel10
            // 
            this.aliasConnLabel10.AutoSize = true;
            this.aliasConnLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel10.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel10.Location = new System.Drawing.Point(388, 531);
            this.aliasConnLabel10.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel10.Name = "aliasConnLabel10";
            this.aliasConnLabel10.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel10.TabIndex = 160;
            this.aliasConnLabel10.Text = "no data";
            // 
            // aliasConnLabel9
            // 
            this.aliasConnLabel9.AutoSize = true;
            this.aliasConnLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel9.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel9.Location = new System.Drawing.Point(388, 511);
            this.aliasConnLabel9.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel9.Name = "aliasConnLabel9";
            this.aliasConnLabel9.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel9.TabIndex = 159;
            this.aliasConnLabel9.Text = "no data";
            // 
            // channelLabel7
            // 
            this.channelLabel7.AutoSize = true;
            this.channelLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel7.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel7.Location = new System.Drawing.Point(576, 471);
            this.channelLabel7.Name = "channelLabel7";
            this.channelLabel7.Size = new System.Drawing.Size(80, 22);
            this.channelLabel7.TabIndex = 158;
            this.channelLabel7.Text = "no data";
            // 
            // channelLabel8
            // 
            this.channelLabel8.AutoSize = true;
            this.channelLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel8.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel8.Location = new System.Drawing.Point(576, 491);
            this.channelLabel8.Name = "channelLabel8";
            this.channelLabel8.Size = new System.Drawing.Size(80, 22);
            this.channelLabel8.TabIndex = 157;
            this.channelLabel8.Text = "no data";
            // 
            // aliasConnLabel8
            // 
            this.aliasConnLabel8.AutoSize = true;
            this.aliasConnLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel8.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel8.Location = new System.Drawing.Point(388, 491);
            this.aliasConnLabel8.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel8.Name = "aliasConnLabel8";
            this.aliasConnLabel8.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel8.TabIndex = 156;
            this.aliasConnLabel8.Text = "no data";
            // 
            // aliasConnLabel7
            // 
            this.aliasConnLabel7.AutoSize = true;
            this.aliasConnLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel7.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel7.Location = new System.Drawing.Point(388, 471);
            this.aliasConnLabel7.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel7.Name = "aliasConnLabel7";
            this.aliasConnLabel7.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel7.TabIndex = 155;
            this.aliasConnLabel7.Text = "no data";
            // 
            // channelLabel5
            // 
            this.channelLabel5.AutoSize = true;
            this.channelLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel5.Location = new System.Drawing.Point(576, 431);
            this.channelLabel5.Name = "channelLabel5";
            this.channelLabel5.Size = new System.Drawing.Size(80, 22);
            this.channelLabel5.TabIndex = 154;
            this.channelLabel5.Text = "no data";
            // 
            // channelLabel6
            // 
            this.channelLabel6.AutoSize = true;
            this.channelLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel6.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel6.Location = new System.Drawing.Point(576, 451);
            this.channelLabel6.Name = "channelLabel6";
            this.channelLabel6.Size = new System.Drawing.Size(80, 22);
            this.channelLabel6.TabIndex = 153;
            this.channelLabel6.Text = "no data";
            // 
            // aliasConnLabel6
            // 
            this.aliasConnLabel6.AutoSize = true;
            this.aliasConnLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel6.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel6.Location = new System.Drawing.Point(388, 451);
            this.aliasConnLabel6.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel6.Name = "aliasConnLabel6";
            this.aliasConnLabel6.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel6.TabIndex = 152;
            this.aliasConnLabel6.Text = "no data";
            // 
            // aliasConnLabel5
            // 
            this.aliasConnLabel5.AutoSize = true;
            this.aliasConnLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel5.Location = new System.Drawing.Point(388, 431);
            this.aliasConnLabel5.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel5.Name = "aliasConnLabel5";
            this.aliasConnLabel5.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel5.TabIndex = 151;
            this.aliasConnLabel5.Text = "no data";
            // 
            // channelLabel3
            // 
            this.channelLabel3.AutoSize = true;
            this.channelLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel3.Location = new System.Drawing.Point(576, 391);
            this.channelLabel3.Name = "channelLabel3";
            this.channelLabel3.Size = new System.Drawing.Size(80, 22);
            this.channelLabel3.TabIndex = 150;
            this.channelLabel3.Text = "no data";
            // 
            // channelLabel4
            // 
            this.channelLabel4.AutoSize = true;
            this.channelLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel4.Location = new System.Drawing.Point(576, 411);
            this.channelLabel4.Name = "channelLabel4";
            this.channelLabel4.Size = new System.Drawing.Size(80, 22);
            this.channelLabel4.TabIndex = 149;
            this.channelLabel4.Text = "no data";
            // 
            // aliasConnLabel4
            // 
            this.aliasConnLabel4.AutoSize = true;
            this.aliasConnLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel4.Location = new System.Drawing.Point(388, 411);
            this.aliasConnLabel4.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel4.Name = "aliasConnLabel4";
            this.aliasConnLabel4.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel4.TabIndex = 148;
            this.aliasConnLabel4.Text = "no data";
            // 
            // aliasConnLabel3
            // 
            this.aliasConnLabel3.AutoSize = true;
            this.aliasConnLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel3.Location = new System.Drawing.Point(388, 391);
            this.aliasConnLabel3.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel3.Name = "aliasConnLabel3";
            this.aliasConnLabel3.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel3.TabIndex = 147;
            this.aliasConnLabel3.Text = "no data";
            // 
            // channelLabel1
            // 
            this.channelLabel1.AutoSize = true;
            this.channelLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel1.Location = new System.Drawing.Point(576, 351);
            this.channelLabel1.Name = "channelLabel1";
            this.channelLabel1.Size = new System.Drawing.Size(80, 22);
            this.channelLabel1.TabIndex = 146;
            this.channelLabel1.Text = "no data";
            // 
            // channelLabel2
            // 
            this.channelLabel2.AutoSize = true;
            this.channelLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.channelLabel2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.channelLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channelLabel2.Location = new System.Drawing.Point(576, 371);
            this.channelLabel2.Name = "channelLabel2";
            this.channelLabel2.Size = new System.Drawing.Size(80, 22);
            this.channelLabel2.TabIndex = 145;
            this.channelLabel2.Text = "no data";
            // 
            // aliasConnLabel2
            // 
            this.aliasConnLabel2.AutoSize = true;
            this.aliasConnLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel2.Location = new System.Drawing.Point(388, 371);
            this.aliasConnLabel2.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel2.Name = "aliasConnLabel2";
            this.aliasConnLabel2.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel2.TabIndex = 144;
            this.aliasConnLabel2.Text = "no data";
            // 
            // aliasConnLabel1
            // 
            this.aliasConnLabel1.AutoSize = true;
            this.aliasConnLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasConnLabel1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasConnLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasConnLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasConnLabel1.Location = new System.Drawing.Point(388, 351);
            this.aliasConnLabel1.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasConnLabel1.Name = "aliasConnLabel1";
            this.aliasConnLabel1.Size = new System.Drawing.Size(80, 15);
            this.aliasConnLabel1.TabIndex = 143;
            this.aliasConnLabel1.Text = "no data";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label52.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Silver;
            this.label52.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label52.Location = new System.Drawing.Point(188, 336);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(77, 20);
            this.label52.TabIndex = 141;
            this.label52.Text = "Capacity";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label51.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Silver;
            this.label51.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label51.Location = new System.Drawing.Point(3, 336);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(42, 20);
            this.label51.TabIndex = 140;
            this.label51.Text = "Alias";
            // 
            // capacityLabel9
            // 
            this.capacityLabel9.AutoSize = true;
            this.capacityLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel9.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel9.Location = new System.Drawing.Point(188, 511);
            this.capacityLabel9.Name = "capacityLabel9";
            this.capacityLabel9.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel9.TabIndex = 139;
            this.capacityLabel9.Text = "no data";
            // 
            // capacityLabel10
            // 
            this.capacityLabel10.AutoSize = true;
            this.capacityLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel10.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel10.Location = new System.Drawing.Point(188, 531);
            this.capacityLabel10.Name = "capacityLabel10";
            this.capacityLabel10.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel10.TabIndex = 138;
            this.capacityLabel10.Text = "no data";
            // 
            // aliasLabel10
            // 
            this.aliasLabel10.AutoSize = true;
            this.aliasLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel10.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel10.Location = new System.Drawing.Point(3, 531);
            this.aliasLabel10.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel10.Name = "aliasLabel10";
            this.aliasLabel10.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel10.TabIndex = 137;
            this.aliasLabel10.Text = "no data";
            // 
            // aliasLabel9
            // 
            this.aliasLabel9.AutoSize = true;
            this.aliasLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel9.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel9.Location = new System.Drawing.Point(3, 511);
            this.aliasLabel9.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel9.Name = "aliasLabel9";
            this.aliasLabel9.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel9.TabIndex = 136;
            this.aliasLabel9.Text = "no data";
            // 
            // capacityLabel7
            // 
            this.capacityLabel7.AutoSize = true;
            this.capacityLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel7.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel7.Location = new System.Drawing.Point(188, 471);
            this.capacityLabel7.Name = "capacityLabel7";
            this.capacityLabel7.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel7.TabIndex = 135;
            this.capacityLabel7.Text = "no data";
            // 
            // capacityLabel8
            // 
            this.capacityLabel8.AutoSize = true;
            this.capacityLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel8.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel8.Location = new System.Drawing.Point(188, 491);
            this.capacityLabel8.Name = "capacityLabel8";
            this.capacityLabel8.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel8.TabIndex = 134;
            this.capacityLabel8.Text = "no data";
            // 
            // aliasLabel8
            // 
            this.aliasLabel8.AutoSize = true;
            this.aliasLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel8.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel8.Location = new System.Drawing.Point(3, 491);
            this.aliasLabel8.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel8.Name = "aliasLabel8";
            this.aliasLabel8.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel8.TabIndex = 133;
            this.aliasLabel8.Text = "no data";
            // 
            // aliasLabel7
            // 
            this.aliasLabel7.AutoSize = true;
            this.aliasLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel7.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel7.Location = new System.Drawing.Point(3, 471);
            this.aliasLabel7.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel7.Name = "aliasLabel7";
            this.aliasLabel7.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel7.TabIndex = 132;
            this.aliasLabel7.Text = "no data";
            // 
            // capacityLabel5
            // 
            this.capacityLabel5.AutoSize = true;
            this.capacityLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel5.Location = new System.Drawing.Point(188, 431);
            this.capacityLabel5.Name = "capacityLabel5";
            this.capacityLabel5.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel5.TabIndex = 131;
            this.capacityLabel5.Text = "no data";
            // 
            // capacityLabel6
            // 
            this.capacityLabel6.AutoSize = true;
            this.capacityLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel6.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel6.Location = new System.Drawing.Point(188, 451);
            this.capacityLabel6.Name = "capacityLabel6";
            this.capacityLabel6.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel6.TabIndex = 130;
            this.capacityLabel6.Text = "no data";
            // 
            // aliasLabel6
            // 
            this.aliasLabel6.AutoSize = true;
            this.aliasLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel6.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel6.Location = new System.Drawing.Point(3, 451);
            this.aliasLabel6.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel6.Name = "aliasLabel6";
            this.aliasLabel6.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel6.TabIndex = 129;
            this.aliasLabel6.Text = "no data";
            // 
            // aliasLabel5
            // 
            this.aliasLabel5.AutoSize = true;
            this.aliasLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel5.Location = new System.Drawing.Point(3, 431);
            this.aliasLabel5.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel5.Name = "aliasLabel5";
            this.aliasLabel5.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel5.TabIndex = 128;
            this.aliasLabel5.Text = "no data";
            // 
            // capacityLabel3
            // 
            this.capacityLabel3.AutoSize = true;
            this.capacityLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel3.Location = new System.Drawing.Point(188, 391);
            this.capacityLabel3.Name = "capacityLabel3";
            this.capacityLabel3.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel3.TabIndex = 127;
            this.capacityLabel3.Text = "no data";
            // 
            // capacityLabel4
            // 
            this.capacityLabel4.AutoSize = true;
            this.capacityLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel4.Location = new System.Drawing.Point(188, 411);
            this.capacityLabel4.Name = "capacityLabel4";
            this.capacityLabel4.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel4.TabIndex = 126;
            this.capacityLabel4.Text = "no data";
            // 
            // aliasLabel4
            // 
            this.aliasLabel4.AutoSize = true;
            this.aliasLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel4.Location = new System.Drawing.Point(3, 411);
            this.aliasLabel4.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel4.Name = "aliasLabel4";
            this.aliasLabel4.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel4.TabIndex = 125;
            this.aliasLabel4.Text = "no data";
            // 
            // aliasLabel3
            // 
            this.aliasLabel3.AutoSize = true;
            this.aliasLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel3.Location = new System.Drawing.Point(3, 391);
            this.aliasLabel3.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel3.Name = "aliasLabel3";
            this.aliasLabel3.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel3.TabIndex = 124;
            this.aliasLabel3.Text = "no data";
            // 
            // capacityLabel1
            // 
            this.capacityLabel1.AutoSize = true;
            this.capacityLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel1.Location = new System.Drawing.Point(188, 351);
            this.capacityLabel1.Name = "capacityLabel1";
            this.capacityLabel1.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel1.TabIndex = 123;
            this.capacityLabel1.Text = "no data";
            // 
            // capacityLabel2
            // 
            this.capacityLabel2.AutoSize = true;
            this.capacityLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.capacityLabel2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.capacityLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capacityLabel2.Location = new System.Drawing.Point(188, 371);
            this.capacityLabel2.Name = "capacityLabel2";
            this.capacityLabel2.Size = new System.Drawing.Size(80, 22);
            this.capacityLabel2.TabIndex = 122;
            this.capacityLabel2.Text = "no data";
            // 
            // aliasLabel2
            // 
            this.aliasLabel2.AutoSize = true;
            this.aliasLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel2.Location = new System.Drawing.Point(3, 371);
            this.aliasLabel2.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel2.Name = "aliasLabel2";
            this.aliasLabel2.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel2.TabIndex = 121;
            this.aliasLabel2.Text = "no data";
            // 
            // aliasLabel1
            // 
            this.aliasLabel1.AutoSize = true;
            this.aliasLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aliasLabel1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.aliasLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aliasLabel1.Location = new System.Drawing.Point(3, 351);
            this.aliasLabel1.MaximumSize = new System.Drawing.Size(125, 15);
            this.aliasLabel1.Name = "aliasLabel1";
            this.aliasLabel1.Size = new System.Drawing.Size(80, 15);
            this.aliasLabel1.TabIndex = 120;
            this.aliasLabel1.Text = "no data";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label50.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Silver;
            this.label50.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label50.Location = new System.Drawing.Point(3, 64);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(40, 17);
            this.label50.TabIndex = 119;
            this.label50.Text = "(BTC)";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label49.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Silver;
            this.label49.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label49.Location = new System.Drawing.Point(188, 98);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(149, 20);
            this.label49.TabIndex = 118;
            this.label49.Text = "Unknown capacity";
            // 
            // lblUnknownCapacity
            // 
            this.lblUnknownCapacity.AutoSize = true;
            this.lblUnknownCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnknownCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnknownCapacity.Location = new System.Drawing.Point(188, 113);
            this.lblUnknownCapacity.Name = "lblUnknownCapacity";
            this.lblUnknownCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblUnknownCapacity.TabIndex = 117;
            this.lblUnknownCapacity.Text = "no data";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label48.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Silver;
            this.label48.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label48.Location = new System.Drawing.Point(188, 61);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(99, 20);
            this.label48.TabIndex = 116;
            this.label48.Text = "Tor capacity";
            // 
            // lblTorCapacity
            // 
            this.lblTorCapacity.AutoSize = true;
            this.lblTorCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTorCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTorCapacity.Location = new System.Drawing.Point(188, 76);
            this.lblTorCapacity.Name = "lblTorCapacity";
            this.lblTorCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblTorCapacity.TabIndex = 115;
            this.lblTorCapacity.Text = "no data";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label47.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Silver;
            this.label47.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label47.Location = new System.Drawing.Point(188, 24);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(143, 20);
            this.label47.TabIndex = 114;
            this.label47.Text = "Clearnet capacity";
            // 
            // lblClearnetCapacity
            // 
            this.lblClearnetCapacity.AutoSize = true;
            this.lblClearnetCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClearnetCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearnetCapacity.Location = new System.Drawing.Point(188, 39);
            this.lblClearnetCapacity.Name = "lblClearnetCapacity";
            this.lblClearnetCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblClearnetCapacity.TabIndex = 113;
            this.lblClearnetCapacity.Text = "no data";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label38.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Silver;
            this.label38.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label38.Location = new System.Drawing.Point(3, 24);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(112, 20);
            this.label38.TabIndex = 92;
            this.label38.Text = "Total capacity";
            // 
            // lblTotalCapacity
            // 
            this.lblTotalCapacity.AutoSize = true;
            this.lblTotalCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalCapacity.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCapacity.Location = new System.Drawing.Point(3, 39);
            this.lblTotalCapacity.Name = "lblTotalCapacity";
            this.lblTotalCapacity.Size = new System.Drawing.Size(80, 22);
            this.lblTotalCapacity.TabIndex = 91;
            this.lblTotalCapacity.Text = "no data";
            // 
            // panelAddress
            // 
            this.panelAddress.BackColor = System.Drawing.Color.Transparent;
            this.panelAddress.Controls.Add(this.panelOwnNodeAddressTXInfo);
            this.panelAddress.Controls.Add(this.panel44);
            this.panelAddress.Controls.Add(this.panel43);
            this.panelAddress.Controls.Add(this.panel42);
            this.panelAddress.Controls.Add(this.panel41);
            this.panelAddress.Controls.Add(this.panel35);
            this.panelAddress.Controls.Add(this.btnShowAllTX);
            this.panelAddress.Controls.Add(this.btnShowConfirmedTX);
            this.panelAddress.Controls.Add(this.btnShowUnconfirmedTX);
            this.panelAddress.Controls.Add(this.BtnViewBlockFromAddress);
            this.panelAddress.Controls.Add(this.BtnViewTransactionFromAddress);
            this.panelAddress.Controls.Add(this.lblAddressTXPositionInList);
            this.panelAddress.Controls.Add(this.btnFirstAddressTransaction);
            this.panelAddress.Controls.Add(this.btnNextAddressTransactions);
            this.panelAddress.Controls.Add(this.listViewAddressTransactions);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedUnspentOutputs);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedSpentOutputs);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedReceivedOutputs);
            this.panelAddress.Controls.Add(this.AddressQRCodePicturebox);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedUnspent);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedSpent);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedReceived);
            this.panelAddress.Controls.Add(this.lblAddressConfirmedTransactionCount);
            this.panelAddress.Controls.Add(this.lblAddressType);
            this.panelAddress.Location = new System.Drawing.Point(21, 188);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(773, 556);
            this.panelAddress.TabIndex = 90;
            this.panelAddress.Visible = false;
            this.panelAddress.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            this.panelAddress.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAddress_Paint);
            // 
            // panelOwnNodeAddressTXInfo
            // 
            this.panelOwnNodeAddressTXInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panelOwnNodeAddressTXInfo.Controls.Add(this.label164);
            this.panelOwnNodeAddressTXInfo.Location = new System.Drawing.Point(251, 452);
            this.panelOwnNodeAddressTXInfo.Name = "panelOwnNodeAddressTXInfo";
            this.panelOwnNodeAddressTXInfo.Size = new System.Drawing.Size(499, 41);
            this.panelOwnNodeAddressTXInfo.TabIndex = 213;
            this.panelOwnNodeAddressTXInfo.Visible = false;
            // 
            // label164
            // 
            this.label164.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label164.ForeColor = System.Drawing.Color.Gray;
            this.label164.Location = new System.Drawing.Point(9, 3);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(482, 51);
            this.label164.TabIndex = 144;
            this.label164.Text = "When connected to your own full node, a maximum of 10 transactions are displayed " +
    "at a time.";
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.Color.Transparent;
            this.panel44.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel44.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel44.Controls.Add(this.label63);
            this.panel44.Location = new System.Drawing.Point(0, 383);
            this.panel44.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(232, 23);
            this.panel44.TabIndex = 211;
            this.panel44.Visible = false;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label63.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label63.ForeColor = System.Drawing.Color.Gray;
            this.label63.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label63.Location = new System.Drawing.Point(3, 2);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(130, 20);
            this.label63.TabIndex = 128;
            this.label63.Text = "Confirmed spent";
            this.label63.Visible = false;
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.Color.Transparent;
            this.panel43.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel43.Controls.Add(this.label67);
            this.panel43.Location = new System.Drawing.Point(0, 332);
            this.panel43.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(232, 23);
            this.panel43.TabIndex = 210;
            this.panel43.Visible = false;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label67.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label67.ForeColor = System.Drawing.Color.Gray;
            this.label67.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label67.Location = new System.Drawing.Point(3, 2);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(158, 20);
            this.label67.TabIndex = 126;
            this.label67.Text = "Confirmed received";
            this.label67.Visible = false;
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.Color.Transparent;
            this.panel42.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel42.Controls.Add(this.label59);
            this.panel42.Location = new System.Drawing.Point(0, 281);
            this.panel42.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(232, 23);
            this.panel42.TabIndex = 209;
            this.panel42.Visible = false;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label59.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label59.ForeColor = System.Drawing.Color.Gray;
            this.label59.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label59.Location = new System.Drawing.Point(3, 2);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(219, 20);
            this.label59.TabIndex = 118;
            this.label59.Text = "Confirmed transaction count";
            this.label59.Visible = false;
            // 
            // panel41
            // 
            this.panel41.BackColor = System.Drawing.Color.Transparent;
            this.panel41.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel41.Controls.Add(this.label61);
            this.panel41.Location = new System.Drawing.Point(0, 230);
            this.panel41.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(232, 23);
            this.panel41.TabIndex = 208;
            this.panel41.Visible = false;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label61.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label61.ForeColor = System.Drawing.Color.Gray;
            this.label61.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label61.Location = new System.Drawing.Point(3, 2);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(224, 20);
            this.label61.TabIndex = 130;
            this.label61.Text = "Confirmed unspent (balance)";
            this.label61.Visible = false;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.label58);
            this.panel35.Controls.Add(this.textboxSubmittedAddress);
            this.panel35.Location = new System.Drawing.Point(1, 3);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(750, 30);
            this.panel35.TabIndex = 148;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Silver;
            this.label58.Location = new System.Drawing.Point(0, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(160, 20);
            this.label58.TabIndex = 5;
            this.label58.Text = "Enter Bitcoin address";
            // 
            // textboxSubmittedAddress
            // 
            this.textboxSubmittedAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textboxSubmittedAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxSubmittedAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxSubmittedAddress.ForeColor = System.Drawing.Color.White;
            this.textboxSubmittedAddress.Location = new System.Drawing.Point(177, 0);
            this.textboxSubmittedAddress.MaxLength = 80;
            this.textboxSubmittedAddress.Name = "textboxSubmittedAddress";
            this.textboxSubmittedAddress.Size = new System.Drawing.Size(573, 25);
            this.textboxSubmittedAddress.TabIndex = 2;
            this.textboxSubmittedAddress.TextChanged += new System.EventHandler(this.TboxSubmittedAddress_TextChanged);
            // 
            // btnShowAllTX
            // 
            this.btnShowAllTX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnShowAllTX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnShowAllTX.FlatAppearance.BorderSize = 0;
            this.btnShowAllTX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowAllTX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowAllTX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllTX.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllTX.ForeColor = System.Drawing.Color.White;
            this.btnShowAllTX.Location = new System.Drawing.Point(251, 533);
            this.btnShowAllTX.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowAllTX.Name = "btnShowAllTX";
            this.btnShowAllTX.Size = new System.Drawing.Size(101, 22);
            this.btnShowAllTX.TabIndex = 147;
            this.btnShowAllTX.Text = "show all TX";
            this.btnShowAllTX.UseVisualStyleBackColor = false;
            this.btnShowAllTX.Visible = false;
            this.btnShowAllTX.Click += new System.EventHandler(this.BtnShowAllTXForAddress_Click);
            // 
            // btnShowConfirmedTX
            // 
            this.btnShowConfirmedTX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnShowConfirmedTX.Enabled = false;
            this.btnShowConfirmedTX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnShowConfirmedTX.FlatAppearance.BorderSize = 0;
            this.btnShowConfirmedTX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowConfirmedTX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowConfirmedTX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowConfirmedTX.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowConfirmedTX.ForeColor = System.Drawing.Color.White;
            this.btnShowConfirmedTX.Location = new System.Drawing.Point(358, 533);
            this.btnShowConfirmedTX.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowConfirmedTX.Name = "btnShowConfirmedTX";
            this.btnShowConfirmedTX.Size = new System.Drawing.Size(101, 22);
            this.btnShowConfirmedTX.TabIndex = 146;
            this.btnShowConfirmedTX.Text = "confirmed TX";
            this.btnShowConfirmedTX.UseVisualStyleBackColor = false;
            this.btnShowConfirmedTX.Visible = false;
            this.btnShowConfirmedTX.Click += new System.EventHandler(this.BtnShowConfirmedTXForAddress_Click);
            // 
            // btnShowUnconfirmedTX
            // 
            this.btnShowUnconfirmedTX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnShowUnconfirmedTX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnShowUnconfirmedTX.FlatAppearance.BorderSize = 0;
            this.btnShowUnconfirmedTX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowUnconfirmedTX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnShowUnconfirmedTX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowUnconfirmedTX.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUnconfirmedTX.ForeColor = System.Drawing.Color.White;
            this.btnShowUnconfirmedTX.Location = new System.Drawing.Point(465, 533);
            this.btnShowUnconfirmedTX.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowUnconfirmedTX.Name = "btnShowUnconfirmedTX";
            this.btnShowUnconfirmedTX.Size = new System.Drawing.Size(101, 22);
            this.btnShowUnconfirmedTX.TabIndex = 145;
            this.btnShowUnconfirmedTX.Text = "unconfirmed TX";
            this.btnShowUnconfirmedTX.UseVisualStyleBackColor = false;
            this.btnShowUnconfirmedTX.Visible = false;
            this.btnShowUnconfirmedTX.Click += new System.EventHandler(this.BtnShowUnconfirmedTXForAddress_Click);
            // 
            // lblAddressTXPositionInList
            // 
            this.lblAddressTXPositionInList.AutoSize = true;
            this.lblAddressTXPositionInList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddressTXPositionInList.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressTXPositionInList.ForeColor = System.Drawing.Color.Silver;
            this.lblAddressTXPositionInList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAddressTXPositionInList.Location = new System.Drawing.Point(248, 512);
            this.lblAddressTXPositionInList.Name = "lblAddressTXPositionInList";
            this.lblAddressTXPositionInList.Size = new System.Drawing.Size(139, 17);
            this.lblAddressTXPositionInList.TabIndex = 142;
            this.lblAddressTXPositionInList.Text = "Transactions n-n of n";
            this.lblAddressTXPositionInList.Visible = false;
            // 
            // btnFirstAddressTransaction
            // 
            this.btnFirstAddressTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnFirstAddressTransaction.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnFirstAddressTransaction.FlatAppearance.BorderSize = 0;
            this.btnFirstAddressTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnFirstAddressTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnFirstAddressTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstAddressTransaction.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirstAddressTransaction.ForeColor = System.Drawing.Color.White;
            this.btnFirstAddressTransaction.Location = new System.Drawing.Point(614, 533);
            this.btnFirstAddressTransaction.Margin = new System.Windows.Forms.Padding(1);
            this.btnFirstAddressTransaction.Name = "btnFirstAddressTransaction";
            this.btnFirstAddressTransaction.Size = new System.Drawing.Size(68, 22);
            this.btnFirstAddressTransaction.TabIndex = 141;
            this.btnFirstAddressTransaction.Text = "◀ newest";
            this.btnFirstAddressTransaction.UseVisualStyleBackColor = false;
            this.btnFirstAddressTransaction.Visible = false;
            this.btnFirstAddressTransaction.Click += new System.EventHandler(this.BtnFirstTransactionForAddress_Click);
            // 
            // btnNextAddressTransactions
            // 
            this.btnNextAddressTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnNextAddressTransactions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnNextAddressTransactions.FlatAppearance.BorderSize = 0;
            this.btnNextAddressTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextAddressTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextAddressTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextAddressTransactions.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextAddressTransactions.ForeColor = System.Drawing.Color.White;
            this.btnNextAddressTransactions.Location = new System.Drawing.Point(689, 533);
            this.btnNextAddressTransactions.Margin = new System.Windows.Forms.Padding(1);
            this.btnNextAddressTransactions.Name = "btnNextAddressTransactions";
            this.btnNextAddressTransactions.Size = new System.Drawing.Size(60, 22);
            this.btnNextAddressTransactions.TabIndex = 140;
            this.btnNextAddressTransactions.Text = "▷ next";
            this.btnNextAddressTransactions.UseVisualStyleBackColor = false;
            this.btnNextAddressTransactions.Visible = false;
            this.btnNextAddressTransactions.Click += new System.EventHandler(this.BtnGetNextTransactionsForAddress);
            // 
            // listViewAddressTransactions
            // 
            this.listViewAddressTransactions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewAddressTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewAddressTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAddressTransactions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewAddressTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewAddressTransactions.FullRowSelect = true;
            this.listViewAddressTransactions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAddressTransactions.HideSelection = false;
            this.listViewAddressTransactions.LabelWrap = false;
            this.listViewAddressTransactions.Location = new System.Drawing.Point(250, 36);
            this.listViewAddressTransactions.MultiSelect = false;
            this.listViewAddressTransactions.Name = "listViewAddressTransactions";
            this.listViewAddressTransactions.OwnerDraw = true;
            this.listViewAddressTransactions.Scrollable = false;
            this.listViewAddressTransactions.ShowGroups = false;
            this.listViewAddressTransactions.Size = new System.Drawing.Size(499, 476);
            this.listViewAddressTransactions.SmallImageList = this.imageListUpDownArrows;
            this.listViewAddressTransactions.TabIndex = 139;
            this.listViewAddressTransactions.TabStop = false;
            this.listViewAddressTransactions.UseCompatibleStateImageBehavior = false;
            this.listViewAddressTransactions.View = System.Windows.Forms.View.Details;
            this.listViewAddressTransactions.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewAddressTransactions_ColumnWidthChanging);
            this.listViewAddressTransactions.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewAddressTransactions.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewAddressTransactions_DrawSubItem);
            this.listViewAddressTransactions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewAddressTransactions_ItemSelectionChanged);
            // 
            // imageListUpDownArrows
            // 
            this.imageListUpDownArrows.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListUpDownArrows.ImageStream")));
            this.imageListUpDownArrows.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListUpDownArrows.Images.SetKeyName(0, "greentriangle.png");
            this.imageListUpDownArrows.Images.SetKeyName(1, "redtriangle.png");
            // 
            // lblAddressConfirmedUnspentOutputs
            // 
            this.lblAddressConfirmedUnspentOutputs.AutoSize = true;
            this.lblAddressConfirmedUnspentOutputs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedUnspentOutputs.Location = new System.Drawing.Point(103, 260);
            this.lblAddressConfirmedUnspentOutputs.Name = "lblAddressConfirmedUnspentOutputs";
            this.lblAddressConfirmedUnspentOutputs.Size = new System.Drawing.Size(80, 18);
            this.lblAddressConfirmedUnspentOutputs.TabIndex = 135;
            this.lblAddressConfirmedUnspentOutputs.Text = "(no data)";
            this.lblAddressConfirmedUnspentOutputs.Visible = false;
            // 
            // lblAddressConfirmedSpentOutputs
            // 
            this.lblAddressConfirmedSpentOutputs.AutoSize = true;
            this.lblAddressConfirmedSpentOutputs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedSpentOutputs.Location = new System.Drawing.Point(106, 413);
            this.lblAddressConfirmedSpentOutputs.Name = "lblAddressConfirmedSpentOutputs";
            this.lblAddressConfirmedSpentOutputs.Size = new System.Drawing.Size(80, 18);
            this.lblAddressConfirmedSpentOutputs.TabIndex = 134;
            this.lblAddressConfirmedSpentOutputs.Text = "(no data)";
            this.lblAddressConfirmedSpentOutputs.Visible = false;
            // 
            // lblAddressConfirmedReceivedOutputs
            // 
            this.lblAddressConfirmedReceivedOutputs.AutoSize = true;
            this.lblAddressConfirmedReceivedOutputs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedReceivedOutputs.Location = new System.Drawing.Point(108, 362);
            this.lblAddressConfirmedReceivedOutputs.Name = "lblAddressConfirmedReceivedOutputs";
            this.lblAddressConfirmedReceivedOutputs.Size = new System.Drawing.Size(80, 18);
            this.lblAddressConfirmedReceivedOutputs.TabIndex = 133;
            this.lblAddressConfirmedReceivedOutputs.Text = "(no data)";
            this.lblAddressConfirmedReceivedOutputs.Visible = false;
            // 
            // AddressQRCodePicturebox
            // 
            this.AddressQRCodePicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddressQRCodePicturebox.Location = new System.Drawing.Point(0, 36);
            this.AddressQRCodePicturebox.Name = "AddressQRCodePicturebox";
            this.AddressQRCodePicturebox.Size = new System.Drawing.Size(120, 120);
            this.AddressQRCodePicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddressQRCodePicturebox.TabIndex = 131;
            this.AddressQRCodePicturebox.TabStop = false;
            // 
            // lblAddressConfirmedUnspent
            // 
            this.lblAddressConfirmedUnspent.AutoSize = true;
            this.lblAddressConfirmedUnspent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddressConfirmedUnspent.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedUnspent.Location = new System.Drawing.Point(0, 255);
            this.lblAddressConfirmedUnspent.Name = "lblAddressConfirmedUnspent";
            this.lblAddressConfirmedUnspent.Size = new System.Drawing.Size(87, 23);
            this.lblAddressConfirmedUnspent.TabIndex = 129;
            this.lblAddressConfirmedUnspent.Text = "no data";
            this.lblAddressConfirmedUnspent.Visible = false;
            // 
            // lblAddressConfirmedSpent
            // 
            this.lblAddressConfirmedSpent.AutoSize = true;
            this.lblAddressConfirmedSpent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddressConfirmedSpent.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedSpent.Location = new System.Drawing.Point(0, 408);
            this.lblAddressConfirmedSpent.Name = "lblAddressConfirmedSpent";
            this.lblAddressConfirmedSpent.Size = new System.Drawing.Size(87, 23);
            this.lblAddressConfirmedSpent.TabIndex = 127;
            this.lblAddressConfirmedSpent.Text = "no data";
            this.lblAddressConfirmedSpent.Visible = false;
            // 
            // lblAddressConfirmedReceived
            // 
            this.lblAddressConfirmedReceived.AutoSize = true;
            this.lblAddressConfirmedReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddressConfirmedReceived.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedReceived.Location = new System.Drawing.Point(0, 357);
            this.lblAddressConfirmedReceived.Name = "lblAddressConfirmedReceived";
            this.lblAddressConfirmedReceived.Size = new System.Drawing.Size(87, 23);
            this.lblAddressConfirmedReceived.TabIndex = 125;
            this.lblAddressConfirmedReceived.Text = "no data";
            this.lblAddressConfirmedReceived.Visible = false;
            // 
            // lblAddressConfirmedTransactionCount
            // 
            this.lblAddressConfirmedTransactionCount.AutoSize = true;
            this.lblAddressConfirmedTransactionCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddressConfirmedTransactionCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressConfirmedTransactionCount.Location = new System.Drawing.Point(0, 306);
            this.lblAddressConfirmedTransactionCount.Name = "lblAddressConfirmedTransactionCount";
            this.lblAddressConfirmedTransactionCount.Size = new System.Drawing.Size(87, 23);
            this.lblAddressConfirmedTransactionCount.TabIndex = 117;
            this.lblAddressConfirmedTransactionCount.Text = "no data";
            this.lblAddressConfirmedTransactionCount.Visible = false;
            // 
            // lblAddressType
            // 
            this.lblAddressType.AutoSize = true;
            this.lblAddressType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressType.Location = new System.Drawing.Point(-1, 163);
            this.lblAddressType.Name = "lblAddressType";
            this.lblAddressType.Size = new System.Drawing.Size(64, 18);
            this.lblAddressType.TabIndex = 3;
            this.lblAddressType.Text = "no data";
            this.lblAddressType.Visible = false;
            // 
            // pictureBoxLoadingAnimation
            // 
            this.pictureBoxLoadingAnimation.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLoadingAnimation.Enabled = false;
            this.pictureBoxLoadingAnimation.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoadingAnimation.Image")));
            this.pictureBoxLoadingAnimation.Location = new System.Drawing.Point(754, 756);
            this.pictureBoxLoadingAnimation.Name = "pictureBoxLoadingAnimation";
            this.pictureBoxLoadingAnimation.Size = new System.Drawing.Size(40, 20);
            this.pictureBoxLoadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoadingAnimation.TabIndex = 148;
            this.pictureBoxLoadingAnimation.TabStop = false;
            // 
            // panelBlock
            // 
            this.panelBlock.BackColor = System.Drawing.Color.Transparent;
            this.panelBlock.Controls.Add(this.pictureBoxBlockScreenChartFeeRange);
            this.panelBlock.Controls.Add(this.pictureBoxBlockScreenChartReward);
            this.panelBlock.Controls.Add(this.pictureBoxBlockScreenChartBlockSize);
            this.panelBlock.Controls.Add(this.panelOwnNodeBlockTXInfo);
            this.panelBlock.Controls.Add(this.panel56);
            this.panelBlock.Controls.Add(this.panel55);
            this.panelBlock.Controls.Add(this.panel54);
            this.panelBlock.Controls.Add(this.panel53);
            this.panelBlock.Controls.Add(this.panel52);
            this.panelBlock.Controls.Add(this.panel51);
            this.panelBlock.Controls.Add(this.panel50);
            this.panelBlock.Controls.Add(this.panel49);
            this.panelBlock.Controls.Add(this.panel48);
            this.panelBlock.Controls.Add(this.panel47);
            this.panelBlock.Controls.Add(this.panel46);
            this.panelBlock.Controls.Add(this.btnPreviousBlock);
            this.panelBlock.Controls.Add(this.btnNextBlock);
            this.panelBlock.Controls.Add(this.lblNonce);
            this.panelBlock.Controls.Add(this.lblTotalFees);
            this.panelBlock.Controls.Add(this.btnViewTransactionFromBlock);
            this.panelBlock.Controls.Add(this.listViewBlockTransactions);
            this.panelBlock.Controls.Add(this.lblBlockTXPositionInList);
            this.panelBlock.Controls.Add(this.btnPreviousBlockTransactions);
            this.panelBlock.Controls.Add(this.btnNextBlockTransactions);
            this.panelBlock.Controls.Add(this.lblBlockTime);
            this.panelBlock.Controls.Add(this.lblBlockFeeRangeAndMedianFee);
            this.panelBlock.Controls.Add(this.lblMiner);
            this.panelBlock.Controls.Add(this.lblBlockAverageFee);
            this.panelBlock.Controls.Add(this.lblNumberOfTXInBlock);
            this.panelBlock.Controls.Add(this.lblReward);
            this.panelBlock.Controls.Add(this.lblBlockWeight);
            this.panelBlock.Controls.Add(this.lblSizeOfBlock);
            this.panelBlock.Controls.Add(this.textBoxSubmittedBlockNumber);
            this.panelBlock.Controls.Add(this.label60);
            this.panelBlock.Location = new System.Drawing.Point(21, 188);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(773, 556);
            this.panelBlock.TabIndex = 141;
            this.panelBlock.Visible = false;
            this.panelBlock.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            // 
            // panelOwnNodeBlockTXInfo
            // 
            this.panelOwnNodeBlockTXInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panelOwnNodeBlockTXInfo.Controls.Add(this.label160);
            this.panelOwnNodeBlockTXInfo.Location = new System.Drawing.Point(250, 465);
            this.panelOwnNodeBlockTXInfo.Name = "panelOwnNodeBlockTXInfo";
            this.panelOwnNodeBlockTXInfo.Size = new System.Drawing.Size(499, 41);
            this.panelOwnNodeBlockTXInfo.TabIndex = 212;
            // 
            // label160
            // 
            this.label160.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.ForeColor = System.Drawing.Color.Gray;
            this.label160.Location = new System.Drawing.Point(9, 3);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(482, 51);
            this.label160.TabIndex = 144;
            this.label160.Text = "When connected to your own full node, a maximum of 10 transactions are displayed " +
    "at a time.";
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.Transparent;
            this.panel56.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel56.Controls.Add(this.label64);
            this.panel56.Controls.Add(this.lblBlockHash);
            this.panel56.Location = new System.Drawing.Point(252, 3);
            this.panel56.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(501, 23);
            this.panel56.TabIndex = 208;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.Gray;
            this.label64.Location = new System.Drawing.Point(3, 1);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(44, 20);
            this.label64.TabIndex = 9;
            this.label64.Text = "Hash";
            // 
            // lblBlockHash
            // 
            this.lblBlockHash.AutoSize = true;
            this.lblBlockHash.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockHash.Location = new System.Drawing.Point(43, 3);
            this.lblBlockHash.Name = "lblBlockHash";
            this.lblBlockHash.Size = new System.Drawing.Size(64, 18);
            this.lblBlockHash.TabIndex = 8;
            this.lblBlockHash.Text = "no data";
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.Color.Transparent;
            this.panel55.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel55.BackgroundImage")));
            this.panel55.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel55.Controls.Add(this.label71);
            this.panel55.Location = new System.Drawing.Point(0, 467);
            this.panel55.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(196, 23);
            this.panel55.TabIndex = 211;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label71.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.Gray;
            this.label71.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label71.Location = new System.Drawing.Point(3, 2);
            this.label71.Margin = new System.Windows.Forms.Padding(0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(98, 20);
            this.label71.TabIndex = 153;
            this.label71.Text = "Miner / Pool";
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.Color.Transparent;
            this.panel54.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel54.BackgroundImage")));
            this.panel54.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel54.Controls.Add(this.label62);
            this.panel54.Location = new System.Drawing.Point(0, 419);
            this.panel54.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(196, 23);
            this.panel54.TabIndex = 210;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label62.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.Color.Gray;
            this.label62.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label62.Location = new System.Drawing.Point(3, 2);
            this.label62.Margin = new System.Windows.Forms.Padding(0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(59, 20);
            this.label62.TabIndex = 153;
            this.label62.Text = "Nonce";
            // 
            // panel53
            // 
            this.panel53.BackColor = System.Drawing.Color.Transparent;
            this.panel53.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel53.BackgroundImage")));
            this.panel53.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel53.Controls.Add(this.label65);
            this.panel53.Location = new System.Drawing.Point(0, 371);
            this.panel53.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(196, 23);
            this.panel53.TabIndex = 209;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label65.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.Gray;
            this.label65.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label65.Location = new System.Drawing.Point(3, 2);
            this.label65.Margin = new System.Windows.Forms.Padding(0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(145, 20);
            this.label65.TabIndex = 153;
            this.label65.Text = "Average fee (sats)";
            // 
            // panel52
            // 
            this.panel52.BackColor = System.Drawing.Color.Transparent;
            this.panel52.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel52.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel52.Controls.Add(this.label70);
            this.panel52.Location = new System.Drawing.Point(0, 323);
            this.panel52.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(196, 23);
            this.panel52.TabIndex = 209;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label70.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Gray;
            this.label70.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label70.Location = new System.Drawing.Point(3, 2);
            this.label70.Margin = new System.Windows.Forms.Padding(0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(224, 20);
            this.label70.TabIndex = 153;
            this.label70.Text = "Fee range / Med fee (sat/vB)";
            // 
            // panel51
            // 
            this.panel51.BackColor = System.Drawing.Color.Transparent;
            this.panel51.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel51.BackgroundImage")));
            this.panel51.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel51.Controls.Add(this.label66);
            this.panel51.Location = new System.Drawing.Point(0, 275);
            this.panel51.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(196, 23);
            this.panel51.TabIndex = 209;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label66.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Gray;
            this.label66.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label66.Location = new System.Drawing.Point(3, 2);
            this.label66.Margin = new System.Windows.Forms.Padding(0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(181, 20);
            this.label66.TabIndex = 153;
            this.label66.Text = "Reward (subsidy + fees)";
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.Color.Transparent;
            this.panel50.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel50.BackgroundImage")));
            this.panel50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel50.Controls.Add(this.label72);
            this.panel50.Location = new System.Drawing.Point(0, 227);
            this.panel50.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(196, 23);
            this.panel50.TabIndex = 209;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label72.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.Gray;
            this.label72.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label72.Location = new System.Drawing.Point(3, 2);
            this.label72.Margin = new System.Windows.Forms.Padding(0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(77, 20);
            this.label72.TabIndex = 153;
            this.label72.Text = "Total fees";
            // 
            // panel49
            // 
            this.panel49.BackColor = System.Drawing.Color.Transparent;
            this.panel49.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel49.BackgroundImage")));
            this.panel49.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel49.Controls.Add(this.label74);
            this.panel49.Location = new System.Drawing.Point(0, 179);
            this.panel49.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(196, 23);
            this.panel49.TabIndex = 209;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label74.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Gray;
            this.label74.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label74.Location = new System.Drawing.Point(3, 2);
            this.label74.Margin = new System.Windows.Forms.Padding(0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(159, 20);
            this.label74.TabIndex = 153;
            this.label74.Text = "Block weight (MWU)";
            // 
            // panel48
            // 
            this.panel48.BackColor = System.Drawing.Color.Transparent;
            this.panel48.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel48.BackgroundImage")));
            this.panel48.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel48.Controls.Add(this.label68);
            this.panel48.Location = new System.Drawing.Point(0, 131);
            this.panel48.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(196, 23);
            this.panel48.TabIndex = 209;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label68.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Gray;
            this.label68.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label68.Location = new System.Drawing.Point(3, 2);
            this.label68.Margin = new System.Windows.Forms.Padding(0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(78, 20);
            this.label68.TabIndex = 153;
            this.label68.Text = "Block size";
            // 
            // panel47
            // 
            this.panel47.BackColor = System.Drawing.Color.Transparent;
            this.panel47.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel47.BackgroundImage")));
            this.panel47.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel47.Controls.Add(this.label69);
            this.panel47.Location = new System.Drawing.Point(0, 85);
            this.panel47.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(196, 23);
            this.panel47.TabIndex = 209;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label69.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Gray;
            this.label69.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label69.Location = new System.Drawing.Point(3, 2);
            this.label69.Margin = new System.Windows.Forms.Padding(0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(138, 20);
            this.label69.TabIndex = 153;
            this.label69.Text = "Transaction count";
            // 
            // panel46
            // 
            this.panel46.BackColor = System.Drawing.Color.Transparent;
            this.panel46.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel46.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel46.Controls.Add(this.label145);
            this.panel46.Location = new System.Drawing.Point(0, 37);
            this.panel46.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(196, 23);
            this.panel46.TabIndex = 208;
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label145.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.ForeColor = System.Drawing.Color.Gray;
            this.label145.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label145.Location = new System.Drawing.Point(3, 2);
            this.label145.Margin = new System.Windows.Forms.Padding(0);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(84, 20);
            this.label145.TabIndex = 153;
            this.label145.Text = "Block time";
            // 
            // btnPreviousBlock
            // 
            this.btnPreviousBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnPreviousBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnPreviousBlock.FlatAppearance.BorderSize = 0;
            this.btnPreviousBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPreviousBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPreviousBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousBlock.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousBlock.ForeColor = System.Drawing.Color.White;
            this.btnPreviousBlock.Location = new System.Drawing.Point(125, 3);
            this.btnPreviousBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreviousBlock.Name = "btnPreviousBlock";
            this.btnPreviousBlock.Size = new System.Drawing.Size(23, 23);
            this.btnPreviousBlock.TabIndex = 171;
            this.btnPreviousBlock.TabStop = false;
            this.btnPreviousBlock.Text = "◁";
            this.btnPreviousBlock.UseVisualStyleBackColor = false;
            this.btnPreviousBlock.Click += new System.EventHandler(this.BtnPreviousBlock_Click);
            // 
            // btnNextBlock
            // 
            this.btnNextBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnNextBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnNextBlock.FlatAppearance.BorderSize = 0;
            this.btnNextBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextBlock.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextBlock.ForeColor = System.Drawing.Color.White;
            this.btnNextBlock.Location = new System.Drawing.Point(220, 3);
            this.btnNextBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextBlock.Name = "btnNextBlock";
            this.btnNextBlock.Size = new System.Drawing.Size(23, 23);
            this.btnNextBlock.TabIndex = 170;
            this.btnNextBlock.TabStop = false;
            this.btnNextBlock.Text = "▷";
            this.btnNextBlock.UseVisualStyleBackColor = false;
            this.btnNextBlock.Click += new System.EventHandler(this.BtnNextBlock_Click);
            // 
            // lblNonce
            // 
            this.lblNonce.AutoSize = true;
            this.lblNonce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNonce.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonce.Location = new System.Drawing.Point(0, 445);
            this.lblNonce.Name = "lblNonce";
            this.lblNonce.Size = new System.Drawing.Size(87, 23);
            this.lblNonce.TabIndex = 168;
            this.lblNonce.Text = "no data";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalFees.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(0, 253);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(87, 23);
            this.lblTotalFees.TabIndex = 166;
            this.lblTotalFees.Text = "no data";
            // 
            // listViewBlockTransactions
            // 
            this.listViewBlockTransactions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewBlockTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewBlockTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBlockTransactions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBlockTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewBlockTransactions.FullRowSelect = true;
            this.listViewBlockTransactions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBlockTransactions.HideSelection = false;
            this.listViewBlockTransactions.LabelWrap = false;
            this.listViewBlockTransactions.Location = new System.Drawing.Point(250, 36);
            this.listViewBlockTransactions.Margin = new System.Windows.Forms.Padding(0);
            this.listViewBlockTransactions.MultiSelect = false;
            this.listViewBlockTransactions.Name = "listViewBlockTransactions";
            this.listViewBlockTransactions.OwnerDraw = true;
            this.listViewBlockTransactions.Scrollable = false;
            this.listViewBlockTransactions.ShowGroups = false;
            this.listViewBlockTransactions.Size = new System.Drawing.Size(499, 476);
            this.listViewBlockTransactions.SmallImageList = this.imageListUpDownArrows;
            this.listViewBlockTransactions.TabIndex = 164;
            this.listViewBlockTransactions.TabStop = false;
            this.listViewBlockTransactions.UseCompatibleStateImageBehavior = false;
            this.listViewBlockTransactions.View = System.Windows.Forms.View.Details;
            this.listViewBlockTransactions.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewBlockTransactions_ColumnWidthChanging);
            this.listViewBlockTransactions.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewBlockTransactions.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewBlockTransactions_DrawSubItem);
            this.listViewBlockTransactions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewBlockTransactions_ItemSelectionChanged);
            // 
            // lblBlockTXPositionInList
            // 
            this.lblBlockTXPositionInList.AutoSize = true;
            this.lblBlockTXPositionInList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockTXPositionInList.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockTXPositionInList.ForeColor = System.Drawing.Color.Silver;
            this.lblBlockTXPositionInList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblBlockTXPositionInList.Location = new System.Drawing.Point(248, 512);
            this.lblBlockTXPositionInList.Name = "lblBlockTXPositionInList";
            this.lblBlockTXPositionInList.Size = new System.Drawing.Size(139, 17);
            this.lblBlockTXPositionInList.TabIndex = 157;
            this.lblBlockTXPositionInList.Text = "Transactions n-n of n";
            // 
            // btnPreviousBlockTransactions
            // 
            this.btnPreviousBlockTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnPreviousBlockTransactions.Enabled = false;
            this.btnPreviousBlockTransactions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnPreviousBlockTransactions.FlatAppearance.BorderSize = 0;
            this.btnPreviousBlockTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPreviousBlockTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPreviousBlockTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousBlockTransactions.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousBlockTransactions.ForeColor = System.Drawing.Color.White;
            this.btnPreviousBlockTransactions.Location = new System.Drawing.Point(616, 533);
            this.btnPreviousBlockTransactions.Margin = new System.Windows.Forms.Padding(1);
            this.btnPreviousBlockTransactions.Name = "btnPreviousBlockTransactions";
            this.btnPreviousBlockTransactions.Size = new System.Drawing.Size(68, 22);
            this.btnPreviousBlockTransactions.TabIndex = 156;
            this.btnPreviousBlockTransactions.TabStop = false;
            this.btnPreviousBlockTransactions.Text = "◁ prev";
            this.btnPreviousBlockTransactions.UseVisualStyleBackColor = false;
            this.btnPreviousBlockTransactions.Click += new System.EventHandler(this.BtnPreviousBlockTransactions_Click);
            // 
            // btnNextBlockTransactions
            // 
            this.btnNextBlockTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnNextBlockTransactions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnNextBlockTransactions.FlatAppearance.BorderSize = 0;
            this.btnNextBlockTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextBlockTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNextBlockTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextBlockTransactions.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextBlockTransactions.ForeColor = System.Drawing.Color.White;
            this.btnNextBlockTransactions.Location = new System.Drawing.Point(691, 533);
            this.btnNextBlockTransactions.Margin = new System.Windows.Forms.Padding(1);
            this.btnNextBlockTransactions.Name = "btnNextBlockTransactions";
            this.btnNextBlockTransactions.Size = new System.Drawing.Size(60, 22);
            this.btnNextBlockTransactions.TabIndex = 155;
            this.btnNextBlockTransactions.TabStop = false;
            this.btnNextBlockTransactions.Text = "▷ next";
            this.btnNextBlockTransactions.UseVisualStyleBackColor = false;
            this.btnNextBlockTransactions.Click += new System.EventHandler(this.BtnNextBlockTransactions_Click);
            // 
            // lblBlockTime
            // 
            this.lblBlockTime.AutoSize = true;
            this.lblBlockTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockTime.Location = new System.Drawing.Point(0, 61);
            this.lblBlockTime.Name = "lblBlockTime";
            this.lblBlockTime.Size = new System.Drawing.Size(87, 23);
            this.lblBlockTime.TabIndex = 152;
            this.lblBlockTime.Text = "no data";
            // 
            // lblBlockFeeRangeAndMedianFee
            // 
            this.lblBlockFeeRangeAndMedianFee.AutoSize = true;
            this.lblBlockFeeRangeAndMedianFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockFeeRangeAndMedianFee.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockFeeRangeAndMedianFee.Location = new System.Drawing.Point(0, 349);
            this.lblBlockFeeRangeAndMedianFee.Name = "lblBlockFeeRangeAndMedianFee";
            this.lblBlockFeeRangeAndMedianFee.Size = new System.Drawing.Size(87, 23);
            this.lblBlockFeeRangeAndMedianFee.TabIndex = 150;
            this.lblBlockFeeRangeAndMedianFee.Text = "no data";
            // 
            // lblMiner
            // 
            this.lblMiner.AutoSize = true;
            this.lblMiner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMiner.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiner.Location = new System.Drawing.Point(0, 493);
            this.lblMiner.Name = "lblMiner";
            this.lblMiner.Size = new System.Drawing.Size(87, 23);
            this.lblMiner.TabIndex = 148;
            this.lblMiner.Text = "no data";
            // 
            // lblBlockAverageFee
            // 
            this.lblBlockAverageFee.AutoSize = true;
            this.lblBlockAverageFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockAverageFee.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockAverageFee.Location = new System.Drawing.Point(0, 397);
            this.lblBlockAverageFee.Name = "lblBlockAverageFee";
            this.lblBlockAverageFee.Size = new System.Drawing.Size(87, 23);
            this.lblBlockAverageFee.TabIndex = 144;
            this.lblBlockAverageFee.Text = "no data";
            // 
            // lblNumberOfTXInBlock
            // 
            this.lblNumberOfTXInBlock.AutoSize = true;
            this.lblNumberOfTXInBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumberOfTXInBlock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfTXInBlock.Location = new System.Drawing.Point(0, 109);
            this.lblNumberOfTXInBlock.Name = "lblNumberOfTXInBlock";
            this.lblNumberOfTXInBlock.Size = new System.Drawing.Size(87, 23);
            this.lblNumberOfTXInBlock.TabIndex = 142;
            this.lblNumberOfTXInBlock.Text = "no data";
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReward.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReward.Location = new System.Drawing.Point(0, 301);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(87, 23);
            this.lblReward.TabIndex = 140;
            this.lblReward.Text = "no data";
            // 
            // lblBlockWeight
            // 
            this.lblBlockWeight.AutoSize = true;
            this.lblBlockWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockWeight.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockWeight.Location = new System.Drawing.Point(0, 205);
            this.lblBlockWeight.Name = "lblBlockWeight";
            this.lblBlockWeight.Size = new System.Drawing.Size(87, 23);
            this.lblBlockWeight.TabIndex = 138;
            this.lblBlockWeight.Text = "no data";
            // 
            // lblSizeOfBlock
            // 
            this.lblSizeOfBlock.AutoSize = true;
            this.lblSizeOfBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSizeOfBlock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeOfBlock.Location = new System.Drawing.Point(0, 157);
            this.lblSizeOfBlock.Name = "lblSizeOfBlock";
            this.lblSizeOfBlock.Size = new System.Drawing.Size(87, 23);
            this.lblSizeOfBlock.TabIndex = 136;
            this.lblSizeOfBlock.Text = "no data";
            // 
            // textBoxSubmittedBlockNumber
            // 
            this.textBoxSubmittedBlockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSubmittedBlockNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSubmittedBlockNumber.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubmittedBlockNumber.ForeColor = System.Drawing.Color.White;
            this.textBoxSubmittedBlockNumber.Location = new System.Drawing.Point(154, 3);
            this.textBoxSubmittedBlockNumber.MaxLength = 80;
            this.textBoxSubmittedBlockNumber.Name = "textBoxSubmittedBlockNumber";
            this.textBoxSubmittedBlockNumber.Size = new System.Drawing.Size(60, 25);
            this.textBoxSubmittedBlockNumber.TabIndex = 7;
            this.textBoxSubmittedBlockNumber.TabStop = false;
            this.textBoxSubmittedBlockNumber.TextChanged += new System.EventHandler(this.TextBoxSubmittedBlockNumber_TextChanged);
            this.textBoxSubmittedBlockNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSubmittedBlockNumber_KeyPress);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Silver;
            this.label60.Location = new System.Drawing.Point(-3, 5);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(151, 20);
            this.label60.TabIndex = 6;
            this.label60.Text = "Enter block number";
            // 
            // pictureBoxSatsumaLogo
            // 
            this.pictureBoxSatsumaLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSatsumaLogo.Image = global::SATSuma.Properties.Resources.logoNoText;
            this.pictureBoxSatsumaLogo.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxSatsumaLogo.Name = "pictureBoxSatsumaLogo";
            this.pictureBoxSatsumaLogo.Size = new System.Drawing.Size(20, 22);
            this.pictureBoxSatsumaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSatsumaLogo.TabIndex = 150;
            this.pictureBoxSatsumaLogo.TabStop = false;
            // 
            // lblSatsumaTitle
            // 
            this.lblSatsumaTitle.AutoSize = true;
            this.lblSatsumaTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSatsumaTitle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsumaTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSatsumaTitle.Location = new System.Drawing.Point(34, 11);
            this.lblSatsumaTitle.Name = "lblSatsumaTitle";
            this.lblSatsumaTitle.Size = new System.Drawing.Size(84, 19);
            this.lblSatsumaTitle.TabIndex = 151;
            this.lblSatsumaTitle.Text = "SATSuma";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.panelMenu.Controls.Add(this.btnMenuCharts);
            this.panelMenu.Controls.Add(this.btnMenuAppearance);
            this.panelMenu.Controls.Add(this.btnMenuSettings2);
            this.panelMenu.Controls.Add(this.btnMenuHelp);
            this.panelMenu.Controls.Add(this.btnMenuBookmarks);
            this.panelMenu.Controls.Add(this.btnMenuXpub);
            this.panelMenu.Controls.Add(this.btnMenuTransaction);
            this.panelMenu.Controls.Add(this.btnMenuBlockList);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.btnMenuSplash);
            this.panelMenu.Controls.Add(this.btnMenuBlock);
            this.panelMenu.Controls.Add(this.btnMenuAddress);
            this.panelMenu.Controls.Add(this.btnMenuBitcoinDashboard);
            this.panelMenu.Controls.Add(this.btnMenuLightningDashboard);
            this.panelMenu.Location = new System.Drawing.Point(587, 11);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(114, 24);
            this.panelMenu.TabIndex = 152;
            // 
            // btnMenuCharts
            // 
            this.btnMenuCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuCharts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuCharts.FlatAppearance.BorderSize = 0;
            this.btnMenuCharts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuCharts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCharts.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCharts.ForeColor = System.Drawing.Color.White;
            this.btnMenuCharts.Location = new System.Drawing.Point(0, 312);
            this.btnMenuCharts.Name = "btnMenuCharts";
            this.btnMenuCharts.Size = new System.Drawing.Size(114, 24);
            this.btnMenuCharts.TabIndex = 161;
            this.btnMenuCharts.TabStop = false;
            this.btnMenuCharts.Text = "charts";
            this.btnMenuCharts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuCharts.UseVisualStyleBackColor = false;
            this.btnMenuCharts.Click += new System.EventHandler(this.BtnMenuCharts_Click);
            // 
            // btnMenuAppearance
            // 
            this.btnMenuAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuAppearance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuAppearance.FlatAppearance.BorderSize = 0;
            this.btnMenuAppearance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuAppearance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuAppearance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAppearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAppearance.ForeColor = System.Drawing.Color.White;
            this.btnMenuAppearance.Location = new System.Drawing.Point(0, 240);
            this.btnMenuAppearance.Name = "btnMenuAppearance";
            this.btnMenuAppearance.Size = new System.Drawing.Size(114, 24);
            this.btnMenuAppearance.TabIndex = 160;
            this.btnMenuAppearance.TabStop = false;
            this.btnMenuAppearance.Text = "appearance";
            this.btnMenuAppearance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuAppearance.UseVisualStyleBackColor = false;
            this.btnMenuAppearance.Click += new System.EventHandler(this.BtnAppearance_Click);
            // 
            // btnMenuSettings2
            // 
            this.btnMenuSettings2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuSettings2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuSettings2.FlatAppearance.BorderSize = 0;
            this.btnMenuSettings2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuSettings2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuSettings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSettings2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSettings2.ForeColor = System.Drawing.Color.White;
            this.btnMenuSettings2.Location = new System.Drawing.Point(0, 216);
            this.btnMenuSettings2.Name = "btnMenuSettings2";
            this.btnMenuSettings2.Size = new System.Drawing.Size(114, 24);
            this.btnMenuSettings2.TabIndex = 159;
            this.btnMenuSettings2.TabStop = false;
            this.btnMenuSettings2.Text = "settings";
            this.btnMenuSettings2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSettings2.UseVisualStyleBackColor = false;
            this.btnMenuSettings2.Click += new System.EventHandler(this.BtnMenuSettings2_Click);
            // 
            // btnMenuHelp
            // 
            this.btnMenuHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuHelp.FlatAppearance.BorderSize = 0;
            this.btnMenuHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHelp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHelp.ForeColor = System.Drawing.Color.White;
            this.btnMenuHelp.Location = new System.Drawing.Point(0, 288);
            this.btnMenuHelp.Name = "btnMenuHelp";
            this.btnMenuHelp.Size = new System.Drawing.Size(114, 24);
            this.btnMenuHelp.TabIndex = 158;
            this.btnMenuHelp.TabStop = false;
            this.btnMenuHelp.Text = "help";
            this.btnMenuHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuHelp.UseVisualStyleBackColor = false;
            this.btnMenuHelp.Click += new System.EventHandler(this.BtnMenuHelp_Click);
            // 
            // btnMenuBookmarks
            // 
            this.btnMenuBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuBookmarks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuBookmarks.FlatAppearance.BorderSize = 0;
            this.btnMenuBookmarks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBookmarks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBookmarks.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBookmarks.ForeColor = System.Drawing.Color.White;
            this.btnMenuBookmarks.Location = new System.Drawing.Point(0, 192);
            this.btnMenuBookmarks.Name = "btnMenuBookmarks";
            this.btnMenuBookmarks.Size = new System.Drawing.Size(114, 24);
            this.btnMenuBookmarks.TabIndex = 157;
            this.btnMenuBookmarks.TabStop = false;
            this.btnMenuBookmarks.Text = "bookmarks";
            this.btnMenuBookmarks.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuBookmarks.UseVisualStyleBackColor = false;
            this.btnMenuBookmarks.Click += new System.EventHandler(this.BtnMenuBookmarks_Click);
            // 
            // btnMenuXpub
            // 
            this.btnMenuXpub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuXpub.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuXpub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuXpub.FlatAppearance.BorderSize = 0;
            this.btnMenuXpub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuXpub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuXpub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuXpub.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuXpub.ForeColor = System.Drawing.Color.White;
            this.btnMenuXpub.Location = new System.Drawing.Point(0, 120);
            this.btnMenuXpub.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuXpub.Name = "btnMenuXpub";
            this.btnMenuXpub.Size = new System.Drawing.Size(114, 24);
            this.btnMenuXpub.TabIndex = 156;
            this.btnMenuXpub.TabStop = false;
            this.btnMenuXpub.Text = "xpub";
            this.btnMenuXpub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuXpub.UseVisualStyleBackColor = false;
            this.btnMenuXpub.Click += new System.EventHandler(this.BtnMenuXpub_Click);
            // 
            // btnMenuTransaction
            // 
            this.btnMenuTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuTransaction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuTransaction.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuTransaction.FlatAppearance.BorderSize = 0;
            this.btnMenuTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTransaction.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTransaction.ForeColor = System.Drawing.Color.White;
            this.btnMenuTransaction.Location = new System.Drawing.Point(0, 96);
            this.btnMenuTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuTransaction.Name = "btnMenuTransaction";
            this.btnMenuTransaction.Size = new System.Drawing.Size(114, 24);
            this.btnMenuTransaction.TabIndex = 155;
            this.btnMenuTransaction.TabStop = false;
            this.btnMenuTransaction.Text = "transaction";
            this.btnMenuTransaction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuTransaction.UseVisualStyleBackColor = false;
            this.btnMenuTransaction.Click += new System.EventHandler(this.BtnMenuTransaction_Click);
            // 
            // btnMenuBlockList
            // 
            this.btnMenuBlockList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuBlockList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuBlockList.Enabled = false;
            this.btnMenuBlockList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuBlockList.FlatAppearance.BorderSize = 0;
            this.btnMenuBlockList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBlockList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBlockList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBlockList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBlockList.ForeColor = System.Drawing.Color.White;
            this.btnMenuBlockList.Location = new System.Drawing.Point(0, 24);
            this.btnMenuBlockList.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuBlockList.Name = "btnMenuBlockList";
            this.btnMenuBlockList.Size = new System.Drawing.Size(114, 24);
            this.btnMenuBlockList.TabIndex = 154;
            this.btnMenuBlockList.TabStop = false;
            this.btnMenuBlockList.Text = "blocks";
            this.btnMenuBlockList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuBlockList.UseVisualStyleBackColor = false;
            this.btnMenuBlockList.Click += new System.EventHandler(this.BtnMenuBlockList_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(114, 24);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.TabStop = false;
            this.btnMenu.Text = "MENU";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnMenuSplash
            // 
            this.btnMenuSplash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuSplash.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuSplash.FlatAppearance.BorderSize = 0;
            this.btnMenuSplash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuSplash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuSplash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSplash.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSplash.ForeColor = System.Drawing.Color.White;
            this.btnMenuSplash.Location = new System.Drawing.Point(0, 264);
            this.btnMenuSplash.Name = "btnMenuSplash";
            this.btnMenuSplash.Size = new System.Drawing.Size(114, 24);
            this.btnMenuSplash.TabIndex = 151;
            this.btnMenuSplash.TabStop = false;
            this.btnMenuSplash.Text = "about";
            this.btnMenuSplash.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSplash.UseVisualStyleBackColor = false;
            this.btnMenuSplash.Click += new System.EventHandler(this.BtnMenuSplash_Click);
            // 
            // btnMenuBlock
            // 
            this.btnMenuBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuBlock.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuBlock.FlatAppearance.BorderSize = 0;
            this.btnMenuBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBlock.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBlock.ForeColor = System.Drawing.Color.White;
            this.btnMenuBlock.Location = new System.Drawing.Point(0, 48);
            this.btnMenuBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuBlock.Name = "btnMenuBlock";
            this.btnMenuBlock.Size = new System.Drawing.Size(114, 24);
            this.btnMenuBlock.TabIndex = 150;
            this.btnMenuBlock.TabStop = false;
            this.btnMenuBlock.Text = "block";
            this.btnMenuBlock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuBlock.UseVisualStyleBackColor = false;
            this.btnMenuBlock.Click += new System.EventHandler(this.BtnMenuBlock_Click);
            // 
            // btnMenuAddress
            // 
            this.btnMenuAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuAddress.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuAddress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuAddress.FlatAppearance.BorderSize = 0;
            this.btnMenuAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAddress.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAddress.ForeColor = System.Drawing.Color.White;
            this.btnMenuAddress.Location = new System.Drawing.Point(0, 72);
            this.btnMenuAddress.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuAddress.Name = "btnMenuAddress";
            this.btnMenuAddress.Size = new System.Drawing.Size(114, 24);
            this.btnMenuAddress.TabIndex = 92;
            this.btnMenuAddress.TabStop = false;
            this.btnMenuAddress.Text = "address";
            this.btnMenuAddress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuAddress.UseVisualStyleBackColor = false;
            this.btnMenuAddress.Click += new System.EventHandler(this.BtnMenuAddress_Click);
            // 
            // btnMenuBitcoinDashboard
            // 
            this.btnMenuBitcoinDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuBitcoinDashboard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuBitcoinDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuBitcoinDashboard.FlatAppearance.BorderSize = 0;
            this.btnMenuBitcoinDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBitcoinDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuBitcoinDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBitcoinDashboard.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBitcoinDashboard.ForeColor = System.Drawing.Color.White;
            this.btnMenuBitcoinDashboard.Location = new System.Drawing.Point(0, 144);
            this.btnMenuBitcoinDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuBitcoinDashboard.Name = "btnMenuBitcoinDashboard";
            this.btnMenuBitcoinDashboard.Size = new System.Drawing.Size(114, 24);
            this.btnMenuBitcoinDashboard.TabIndex = 88;
            this.btnMenuBitcoinDashboard.TabStop = false;
            this.btnMenuBitcoinDashboard.Text = "₿ dashboard";
            this.btnMenuBitcoinDashboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuBitcoinDashboard.UseVisualStyleBackColor = false;
            this.btnMenuBitcoinDashboard.Click += new System.EventHandler(this.BtnMenuBitcoinDashboard_Click);
            // 
            // btnMenuLightningDashboard
            // 
            this.btnMenuLightningDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMenuLightningDashboard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuLightningDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnMenuLightningDashboard.FlatAppearance.BorderSize = 0;
            this.btnMenuLightningDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuLightningDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnMenuLightningDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLightningDashboard.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuLightningDashboard.ForeColor = System.Drawing.Color.White;
            this.btnMenuLightningDashboard.Location = new System.Drawing.Point(0, 168);
            this.btnMenuLightningDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuLightningDashboard.Name = "btnMenuLightningDashboard";
            this.btnMenuLightningDashboard.Size = new System.Drawing.Size(114, 24);
            this.btnMenuLightningDashboard.TabIndex = 87;
            this.btnMenuLightningDashboard.TabStop = false;
            this.btnMenuLightningDashboard.Text = "⚡dashboard";
            this.btnMenuLightningDashboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuLightningDashboard.UseVisualStyleBackColor = false;
            this.btnMenuLightningDashboard.Click += new System.EventHandler(this.BtnMenuLightningDashboard_Click);
            // 
            // panelBlockList
            // 
            this.panelBlockList.BackColor = System.Drawing.Color.Transparent;
            this.panelBlockList.Controls.Add(this.pictureBoxBlockListHashrateChart);
            this.panelBlockList.Controls.Add(this.pictureBoxBlockListDifficultyChart);
            this.panelBlockList.Controls.Add(this.panel45);
            this.panelBlockList.Controls.Add(this.progressBarBlockListHalvingProgress);
            this.panelBlockList.Controls.Add(this.progressBarBlockListNextDiffAdj);
            this.panelBlockList.Controls.Add(this.label16);
            this.panelBlockList.Controls.Add(this.lblBlockListProgressNextDiffAdjPercentage);
            this.panelBlockList.Controls.Add(this.lblBlockListHalvingBlockAndRemaining);
            this.panelBlockList.Controls.Add(this.label122);
            this.panelBlockList.Controls.Add(this.label120);
            this.panelBlockList.Controls.Add(this.lblBlockListBlockReward);
            this.panelBlockList.Controls.Add(this.label118);
            this.panelBlockList.Controls.Add(this.lblBlockListEstHashRate);
            this.panelBlockList.Controls.Add(this.label116);
            this.panelBlockList.Controls.Add(this.lblBlockListNextDifficultyAdjustment);
            this.panelBlockList.Controls.Add(this.lblBlockListAvgTimeBetweenBlocks);
            this.panelBlockList.Controls.Add(this.label115);
            this.panelBlockList.Controls.Add(this.label112);
            this.panelBlockList.Controls.Add(this.lblBlockListNextDiffAdjBlock);
            this.panelBlockList.Controls.Add(this.label110);
            this.panelBlockList.Controls.Add(this.lblBlockListAttemptsToSolveBlock);
            this.panelBlockList.Controls.Add(this.lblBlockListTotalFeesInNextBlock);
            this.panelBlockList.Controls.Add(this.label108);
            this.panelBlockList.Controls.Add(this.lblBlockListMinMaxInFeeNextBlock);
            this.panelBlockList.Controls.Add(this.label106);
            this.panelBlockList.Controls.Add(this.label100);
            this.panelBlockList.Controls.Add(this.lblBlockListTXInNextBlock);
            this.panelBlockList.Controls.Add(this.label87);
            this.panelBlockList.Controls.Add(this.lblBlockListTXInMempool);
            this.panelBlockList.Controls.Add(this.panel21);
            this.panelBlockList.Controls.Add(this.panel16);
            this.panelBlockList.Controls.Add(this.panel15);
            this.panelBlockList.Controls.Add(this.panel19);
            this.panelBlockList.Controls.Add(this.panel18);
            this.panelBlockList.Controls.Add(this.panel17);
            this.panelBlockList.Controls.Add(this.panel14);
            this.panelBlockList.Controls.Add(this.panel13);
            this.panelBlockList.Controls.Add(this.btnViewBlockFromBlockList);
            this.panelBlockList.Controls.Add(this.listViewBlockList);
            this.panelBlockList.Controls.Add(this.lblBlockListPositionInList);
            this.panelBlockList.Controls.Add(this.btnNewer15Blocks);
            this.panelBlockList.Controls.Add(this.btnOlder15Blocks);
            this.panelBlockList.Controls.Add(this.textBoxBlockHeightToStartListFrom);
            this.panelBlockList.Controls.Add(this.label109);
            this.panelBlockList.Controls.Add(this.panel20);
            this.panelBlockList.Location = new System.Drawing.Point(21, 188);
            this.panelBlockList.Name = "panelBlockList";
            this.panelBlockList.Size = new System.Drawing.Size(773, 556);
            this.panelBlockList.TabIndex = 172;
            this.panelBlockList.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.Transparent;
            this.panel45.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel45.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel45.Controls.Add(this.label143);
            this.panel45.Location = new System.Drawing.Point(0, 2);
            this.panel45.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(215, 23);
            this.panel45.TabIndex = 208;
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label143.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.ForeColor = System.Drawing.Color.Gray;
            this.label143.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label143.Location = new System.Drawing.Point(3, 2);
            this.label143.Margin = new System.Windows.Forms.Padding(0);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(221, 20);
            this.label143.TabIndex = 153;
            this.label143.Text = "Mempool, difficulty, hashrate";
            // 
            // progressBarBlockListHalvingProgress
            // 
            this.progressBarBlockListHalvingProgress.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarBlockListHalvingProgress.BorderColor = System.Drawing.Color.Transparent;
            this.progressBarBlockListHalvingProgress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarBlockListHalvingProgress.ForeColor = System.Drawing.Color.Black;
            this.progressBarBlockListHalvingProgress.Location = new System.Drawing.Point(3, 452);
            this.progressBarBlockListHalvingProgress.Maximum = 210000;
            this.progressBarBlockListHalvingProgress.Minimum = 0;
            this.progressBarBlockListHalvingProgress.Name = "progressBarBlockListHalvingProgress";
            this.progressBarBlockListHalvingProgress.Size = new System.Drawing.Size(100, 8);
            this.progressBarBlockListHalvingProgress.Step = 10;
            this.progressBarBlockListHalvingProgress.TabIndex = 236;
            this.progressBarBlockListHalvingProgress.Value = 0;
            // 
            // progressBarBlockListNextDiffAdj
            // 
            this.progressBarBlockListNextDiffAdj.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarBlockListNextDiffAdj.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.progressBarBlockListNextDiffAdj.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarBlockListNextDiffAdj.ForeColor = System.Drawing.Color.Black;
            this.progressBarBlockListNextDiffAdj.Location = new System.Drawing.Point(3, 344);
            this.progressBarBlockListNextDiffAdj.Maximum = 100;
            this.progressBarBlockListNextDiffAdj.Minimum = 0;
            this.progressBarBlockListNextDiffAdj.Name = "progressBarBlockListNextDiffAdj";
            this.progressBarBlockListNextDiffAdj.Size = new System.Drawing.Size(100, 8);
            this.progressBarBlockListNextDiffAdj.Step = 10;
            this.progressBarBlockListNextDiffAdj.TabIndex = 235;
            this.progressBarBlockListNextDiffAdj.Value = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Silver;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label16.Location = new System.Drawing.Point(0, 324);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(238, 20);
            this.label16.TabIndex = 234;
            this.label16.Text = "Progress to difficulty adjustment";
            // 
            // lblBlockListProgressNextDiffAdjPercentage
            // 
            this.lblBlockListProgressNextDiffAdjPercentage.AutoSize = true;
            this.lblBlockListProgressNextDiffAdjPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListProgressNextDiffAdjPercentage.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListProgressNextDiffAdjPercentage.Location = new System.Drawing.Point(107, 342);
            this.lblBlockListProgressNextDiffAdjPercentage.Name = "lblBlockListProgressNextDiffAdjPercentage";
            this.lblBlockListProgressNextDiffAdjPercentage.Size = new System.Drawing.Size(56, 15);
            this.lblBlockListProgressNextDiffAdjPercentage.TabIndex = 233;
            this.lblBlockListProgressNextDiffAdjPercentage.Text = "no data";
            // 
            // lblBlockListHalvingBlockAndRemaining
            // 
            this.lblBlockListHalvingBlockAndRemaining.AutoSize = true;
            this.lblBlockListHalvingBlockAndRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListHalvingBlockAndRemaining.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListHalvingBlockAndRemaining.Location = new System.Drawing.Point(109, 449);
            this.lblBlockListHalvingBlockAndRemaining.Name = "lblBlockListHalvingBlockAndRemaining";
            this.lblBlockListHalvingBlockAndRemaining.Size = new System.Drawing.Size(56, 15);
            this.lblBlockListHalvingBlockAndRemaining.TabIndex = 231;
            this.lblBlockListHalvingBlockAndRemaining.Text = "no data";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label122.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.ForeColor = System.Drawing.Color.Silver;
            this.label122.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label122.Location = new System.Drawing.Point(0, 432);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(196, 20);
            this.label122.TabIndex = 227;
            this.label122.Text = "Halving block / remaining";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label120.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.ForeColor = System.Drawing.Color.Silver;
            this.label120.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label120.Location = new System.Drawing.Point(0, 396);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(145, 20);
            this.label120.TabIndex = 225;
            this.label120.Text = "Block subsidy (BTC)";
            // 
            // lblBlockListBlockReward
            // 
            this.lblBlockListBlockReward.AutoSize = true;
            this.lblBlockListBlockReward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListBlockReward.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListBlockReward.Location = new System.Drawing.Point(0, 411);
            this.lblBlockListBlockReward.Name = "lblBlockListBlockReward";
            this.lblBlockListBlockReward.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListBlockReward.TabIndex = 224;
            this.lblBlockListBlockReward.Text = "no data";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label118.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.ForeColor = System.Drawing.Color.Silver;
            this.label118.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label118.Location = new System.Drawing.Point(0, 360);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(197, 20);
            this.label118.TabIndex = 223;
            this.label118.Text = "Est. hashrate (hashes/sec)";
            // 
            // lblBlockListEstHashRate
            // 
            this.lblBlockListEstHashRate.AutoSize = true;
            this.lblBlockListEstHashRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListEstHashRate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListEstHashRate.Location = new System.Drawing.Point(0, 375);
            this.lblBlockListEstHashRate.Name = "lblBlockListEstHashRate";
            this.lblBlockListEstHashRate.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListEstHashRate.TabIndex = 222;
            this.lblBlockListEstHashRate.Text = "no data";
            // 
            // lblBlockListAvgTimeBetweenBlocks
            // 
            this.lblBlockListAvgTimeBetweenBlocks.AutoSize = true;
            this.lblBlockListAvgTimeBetweenBlocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListAvgTimeBetweenBlocks.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListAvgTimeBetweenBlocks.Location = new System.Drawing.Point(0, 267);
            this.lblBlockListAvgTimeBetweenBlocks.Name = "lblBlockListAvgTimeBetweenBlocks";
            this.lblBlockListAvgTimeBetweenBlocks.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListAvgTimeBetweenBlocks.TabIndex = 219;
            this.lblBlockListAvgTimeBetweenBlocks.Text = "no data";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label112.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.Color.Silver;
            this.label112.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label112.Location = new System.Drawing.Point(0, 216);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(236, 20);
            this.label112.TabIndex = 215;
            this.label112.Text = "Next difficulty adjustment block";
            // 
            // lblBlockListNextDiffAdjBlock
            // 
            this.lblBlockListNextDiffAdjBlock.AutoSize = true;
            this.lblBlockListNextDiffAdjBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListNextDiffAdjBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListNextDiffAdjBlock.Location = new System.Drawing.Point(0, 231);
            this.lblBlockListNextDiffAdjBlock.Name = "lblBlockListNextDiffAdjBlock";
            this.lblBlockListNextDiffAdjBlock.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListNextDiffAdjBlock.TabIndex = 214;
            this.lblBlockListNextDiffAdjBlock.Text = "no data";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label110.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.ForeColor = System.Drawing.Color.Silver;
            this.label110.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label110.Location = new System.Drawing.Point(0, 180);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(215, 20);
            this.label110.TabIndex = 213;
            this.label110.Text = "Avg attempts to solve block";
            // 
            // lblBlockListAttemptsToSolveBlock
            // 
            this.lblBlockListAttemptsToSolveBlock.AutoSize = true;
            this.lblBlockListAttemptsToSolveBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListAttemptsToSolveBlock.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListAttemptsToSolveBlock.Location = new System.Drawing.Point(0, 195);
            this.lblBlockListAttemptsToSolveBlock.Name = "lblBlockListAttemptsToSolveBlock";
            this.lblBlockListAttemptsToSolveBlock.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListAttemptsToSolveBlock.TabIndex = 212;
            this.lblBlockListAttemptsToSolveBlock.Text = "no data";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label87.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Silver;
            this.label87.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label87.Location = new System.Drawing.Point(0, 36);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(188, 20);
            this.label87.TabIndex = 204;
            this.label87.Text = "Transactions in Mempool";
            // 
            // lblBlockListTXInMempool
            // 
            this.lblBlockListTXInMempool.AutoSize = true;
            this.lblBlockListTXInMempool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTXInMempool.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListTXInMempool.Location = new System.Drawing.Point(0, 51);
            this.lblBlockListTXInMempool.Name = "lblBlockListTXInMempool";
            this.lblBlockListTXInMempool.Size = new System.Drawing.Size(80, 22);
            this.lblBlockListTXInMempool.TabIndex = 203;
            this.lblBlockListTXInMempool.Text = "no data";
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel21.Location = new System.Drawing.Point(250, 534);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(500, 1);
            this.panel21.TabIndex = 201;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel16.Location = new System.Drawing.Point(250, 355);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(500, 1);
            this.panel16.TabIndex = 200;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel15.Location = new System.Drawing.Point(750, 355);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1, 179);
            this.panel15.TabIndex = 201;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel19.Location = new System.Drawing.Point(225, 241);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(1, 176);
            this.panel19.TabIndex = 201;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel18.Location = new System.Drawing.Point(250, 355);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(1, 179);
            this.panel18.TabIndex = 200;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel17.Location = new System.Drawing.Point(225, 443);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(25, 1);
            this.panel17.TabIndex = 199;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel14.Location = new System.Drawing.Point(225, 163);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(25, 1);
            this.panel14.TabIndex = 197;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel13.Controls.Add(this.lblBlockListBlockHeight);
            this.panel13.Location = new System.Drawing.Point(250, 355);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(500, 23);
            this.panel13.TabIndex = 196;
            // 
            // lblBlockListBlockHeight
            // 
            this.lblBlockListBlockHeight.AutoSize = true;
            this.lblBlockListBlockHeight.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListBlockHeight.ForeColor = System.Drawing.Color.Gray;
            this.lblBlockListBlockHeight.Location = new System.Drawing.Point(3, 1);
            this.lblBlockListBlockHeight.Name = "lblBlockListBlockHeight";
            this.lblBlockListBlockHeight.Size = new System.Drawing.Size(67, 20);
            this.lblBlockListBlockHeight.TabIndex = 193;
            this.lblBlockListBlockHeight.Text = "no data";
            // 
            // listViewBlockList
            // 
            this.listViewBlockList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewBlockList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewBlockList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBlockList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBlockList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewBlockList.FullRowSelect = true;
            this.listViewBlockList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBlockList.HideSelection = false;
            this.listViewBlockList.LabelWrap = false;
            this.listViewBlockList.Location = new System.Drawing.Point(250, 3);
            this.listViewBlockList.Margin = new System.Windows.Forms.Padding(0);
            this.listViewBlockList.MultiSelect = false;
            this.listViewBlockList.Name = "listViewBlockList";
            this.listViewBlockList.OwnerDraw = true;
            this.listViewBlockList.Scrollable = false;
            this.listViewBlockList.ShowGroups = false;
            this.listViewBlockList.Size = new System.Drawing.Size(499, 287);
            this.listViewBlockList.SmallImageList = this.imageListUpDownArrows;
            this.listViewBlockList.TabIndex = 164;
            this.listViewBlockList.TabStop = false;
            this.listViewBlockList.UseCompatibleStateImageBehavior = false;
            this.listViewBlockList.View = System.Windows.Forms.View.Details;
            this.listViewBlockList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewBlockList_ColumnWidthChanging);
            this.listViewBlockList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewBlockList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewBlockList_DrawSubItem);
            this.listViewBlockList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewBlockList_ItemSelectionChanged);
            this.listViewBlockList.SelectedIndexChanged += new System.EventHandler(this.ListViewBlockList_SelectedIndexChanged);
            // 
            // lblBlockListPositionInList
            // 
            this.lblBlockListPositionInList.AutoSize = true;
            this.lblBlockListPositionInList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListPositionInList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListPositionInList.ForeColor = System.Drawing.Color.Silver;
            this.lblBlockListPositionInList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblBlockListPositionInList.Location = new System.Drawing.Point(248, 303);
            this.lblBlockListPositionInList.Name = "lblBlockListPositionInList";
            this.lblBlockListPositionInList.Size = new System.Drawing.Size(114, 20);
            this.lblBlockListPositionInList.TabIndex = 157;
            this.lblBlockListPositionInList.Text = "Blocks n-n of n";
            // 
            // btnNewer15Blocks
            // 
            this.btnNewer15Blocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnNewer15Blocks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnNewer15Blocks.FlatAppearance.BorderSize = 0;
            this.btnNewer15Blocks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNewer15Blocks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnNewer15Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewer15Blocks.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewer15Blocks.ForeColor = System.Drawing.Color.White;
            this.btnNewer15Blocks.Location = new System.Drawing.Point(598, 299);
            this.btnNewer15Blocks.Margin = new System.Windows.Forms.Padding(1);
            this.btnNewer15Blocks.Name = "btnNewer15Blocks";
            this.btnNewer15Blocks.Size = new System.Drawing.Size(78, 22);
            this.btnNewer15Blocks.TabIndex = 156;
            this.btnNewer15Blocks.TabStop = false;
            this.btnNewer15Blocks.Text = "◁ newer";
            this.btnNewer15Blocks.UseVisualStyleBackColor = false;
            this.btnNewer15Blocks.Click += new System.EventHandler(this.BtnNewer15Blocks_Click);
            // 
            // btnOlder15Blocks
            // 
            this.btnOlder15Blocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnOlder15Blocks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnOlder15Blocks.FlatAppearance.BorderSize = 0;
            this.btnOlder15Blocks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnOlder15Blocks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnOlder15Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOlder15Blocks.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOlder15Blocks.ForeColor = System.Drawing.Color.White;
            this.btnOlder15Blocks.Location = new System.Drawing.Point(681, 299);
            this.btnOlder15Blocks.Margin = new System.Windows.Forms.Padding(1);
            this.btnOlder15Blocks.Name = "btnOlder15Blocks";
            this.btnOlder15Blocks.Size = new System.Drawing.Size(70, 22);
            this.btnOlder15Blocks.TabIndex = 155;
            this.btnOlder15Blocks.TabStop = false;
            this.btnOlder15Blocks.Text = "▷ older";
            this.btnOlder15Blocks.UseVisualStyleBackColor = false;
            this.btnOlder15Blocks.Click += new System.EventHandler(this.BtnOlder15Blocks_Click);
            // 
            // textBoxBlockHeightToStartListFrom
            // 
            this.textBoxBlockHeightToStartListFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxBlockHeightToStartListFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBlockHeightToStartListFrom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBlockHeightToStartListFrom.ForeColor = System.Drawing.Color.White;
            this.textBoxBlockHeightToStartListFrom.Location = new System.Drawing.Point(691, 327);
            this.textBoxBlockHeightToStartListFrom.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBlockHeightToStartListFrom.MaxLength = 80;
            this.textBoxBlockHeightToStartListFrom.Name = "textBoxBlockHeightToStartListFrom";
            this.textBoxBlockHeightToStartListFrom.Size = new System.Drawing.Size(60, 25);
            this.textBoxBlockHeightToStartListFrom.TabIndex = 7;
            this.textBoxBlockHeightToStartListFrom.TabStop = false;
            this.textBoxBlockHeightToStartListFrom.TextChanged += new System.EventHandler(this.TextBoxBlockHeightToStartListFrom_TextChanged);
            this.textBoxBlockHeightToStartListFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxBlockHeightToStartListFrom_KeyPress);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.ForeColor = System.Drawing.Color.Silver;
            this.label109.Location = new System.Drawing.Point(557, 327);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(162, 20);
            this.label109.TabIndex = 6;
            this.label109.Text = "Jump to block height";
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel20.Controls.Add(this.label90);
            this.panel20.Controls.Add(this.lblBlockListBlockSize);
            this.panel20.Controls.Add(this.label105);
            this.panel20.Controls.Add(this.lblBlockListBlockWeight);
            this.panel20.Controls.Add(this.label103);
            this.panel20.Controls.Add(this.lblBlockListReward);
            this.panel20.Controls.Add(this.label101);
            this.panel20.Controls.Add(this.label96);
            this.panel20.Controls.Add(this.lblBlockListTransactionCount);
            this.panel20.Controls.Add(this.lblBlockListVersion);
            this.panel20.Controls.Add(this.label99);
            this.panel20.Controls.Add(this.label92);
            this.panel20.Controls.Add(this.lblBlockListAverageFee);
            this.panel20.Controls.Add(this.lblBlockListAverageTransactionSize);
            this.panel20.Controls.Add(this.label97);
            this.panel20.Controls.Add(this.label94);
            this.panel20.Controls.Add(this.lblBlockListMiner);
            this.panel20.Controls.Add(this.lblBlockListTotalOutputs);
            this.panel20.Controls.Add(this.label95);
            this.panel20.Controls.Add(this.label89);
            this.panel20.Controls.Add(this.lblBlockListBlockFeeRangeAndMedianFee);
            this.panel20.Controls.Add(this.lblBlockListTotalInputs);
            this.panel20.Controls.Add(this.label93);
            this.panel20.Controls.Add(this.lblBlockListBlockTime);
            this.panel20.Controls.Add(this.lblBlockListBlockHash);
            this.panel20.Controls.Add(this.label91);
            this.panel20.Controls.Add(this.lblBlockListTotalFees);
            this.panel20.Controls.Add(this.label24);
            this.panel20.Controls.Add(this.label88);
            this.panel20.Controls.Add(this.lblBlockListNonce);
            this.panel20.Location = new System.Drawing.Point(250, 355);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(500, 179);
            this.panel20.TabIndex = 202;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.Color.Silver;
            this.label90.Location = new System.Drawing.Point(3, 28);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(44, 20);
            this.label90.TabIndex = 172;
            this.label90.Text = "Hash";
            // 
            // lblBlockListBlockSize
            // 
            this.lblBlockListBlockSize.AutoSize = true;
            this.lblBlockListBlockSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListBlockSize.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListBlockSize.Location = new System.Drawing.Point(88, 66);
            this.lblBlockListBlockSize.Name = "lblBlockListBlockSize";
            this.lblBlockListBlockSize.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListBlockSize.TabIndex = 136;
            this.lblBlockListBlockSize.Text = "no data";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label105.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.ForeColor = System.Drawing.Color.Silver;
            this.label105.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label105.Location = new System.Drawing.Point(4, 64);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(78, 20);
            this.label105.TabIndex = 137;
            this.label105.Text = "Block size";
            // 
            // lblBlockListBlockWeight
            // 
            this.lblBlockListBlockWeight.AutoSize = true;
            this.lblBlockListBlockWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListBlockWeight.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListBlockWeight.Location = new System.Drawing.Point(129, 84);
            this.lblBlockListBlockWeight.Name = "lblBlockListBlockWeight";
            this.lblBlockListBlockWeight.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListBlockWeight.TabIndex = 138;
            this.lblBlockListBlockWeight.Text = "no data";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label103.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label103.ForeColor = System.Drawing.Color.Silver;
            this.label103.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label103.Location = new System.Drawing.Point(4, 82);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(159, 20);
            this.label103.TabIndex = 139;
            this.label103.Text = "Block weight (MWU)";
            // 
            // lblBlockListReward
            // 
            this.lblBlockListReward.AutoSize = true;
            this.lblBlockListReward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListReward.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListReward.Location = new System.Drawing.Point(403, 66);
            this.lblBlockListReward.Name = "lblBlockListReward";
            this.lblBlockListReward.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListReward.TabIndex = 140;
            this.lblBlockListReward.Text = "no data";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label101.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Silver;
            this.label101.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label101.Location = new System.Drawing.Point(262, 64);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(181, 20);
            this.label101.TabIndex = 141;
            this.label101.Text = "Reward (subsidy + fees)";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.Silver;
            this.label96.Location = new System.Drawing.Point(3, 154);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(63, 20);
            this.label96.TabIndex = 182;
            this.label96.Text = "Version";
            // 
            // lblBlockListTransactionCount
            // 
            this.lblBlockListTransactionCount.AutoSize = true;
            this.lblBlockListTransactionCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTransactionCount.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListTransactionCount.Location = new System.Drawing.Point(130, 138);
            this.lblBlockListTransactionCount.Name = "lblBlockListTransactionCount";
            this.lblBlockListTransactionCount.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListTransactionCount.TabIndex = 142;
            this.lblBlockListTransactionCount.Text = "no data";
            // 
            // lblBlockListVersion
            // 
            this.lblBlockListVersion.AutoSize = true;
            this.lblBlockListVersion.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListVersion.Location = new System.Drawing.Point(71, 156);
            this.lblBlockListVersion.Name = "lblBlockListVersion";
            this.lblBlockListVersion.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListVersion.TabIndex = 181;
            this.lblBlockListVersion.Text = "no data";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label99.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.Color.Silver;
            this.label99.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label99.Location = new System.Drawing.Point(3, 136);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(138, 20);
            this.label99.TabIndex = 143;
            this.label99.Text = "Transaction count";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label92.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.ForeColor = System.Drawing.Color.Silver;
            this.label92.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label92.Location = new System.Drawing.Point(262, 154);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(175, 20);
            this.label92.TabIndex = 180;
            this.label92.Text = "Average TX size (bytes)";
            // 
            // lblBlockListAverageFee
            // 
            this.lblBlockListAverageFee.AutoSize = true;
            this.lblBlockListAverageFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListAverageFee.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListAverageFee.Location = new System.Drawing.Point(387, 102);
            this.lblBlockListAverageFee.Name = "lblBlockListAverageFee";
            this.lblBlockListAverageFee.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListAverageFee.TabIndex = 144;
            this.lblBlockListAverageFee.Text = "no data";
            // 
            // lblBlockListAverageTransactionSize
            // 
            this.lblBlockListAverageTransactionSize.AutoSize = true;
            this.lblBlockListAverageTransactionSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListAverageTransactionSize.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListAverageTransactionSize.Location = new System.Drawing.Point(431, 156);
            this.lblBlockListAverageTransactionSize.Name = "lblBlockListAverageTransactionSize";
            this.lblBlockListAverageTransactionSize.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListAverageTransactionSize.TabIndex = 179;
            this.lblBlockListAverageTransactionSize.Text = "no data";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label97.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.Color.Silver;
            this.label97.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label97.Location = new System.Drawing.Point(262, 100);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(145, 20);
            this.label97.TabIndex = 145;
            this.label97.Text = "Average fee (sats)";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label94.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.Color.Silver;
            this.label94.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label94.Location = new System.Drawing.Point(262, 136);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(100, 20);
            this.label94.TabIndex = 178;
            this.label94.Text = "Total outputs";
            // 
            // lblBlockListMiner
            // 
            this.lblBlockListMiner.AutoSize = true;
            this.lblBlockListMiner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListMiner.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListMiner.Location = new System.Drawing.Point(88, 120);
            this.lblBlockListMiner.Name = "lblBlockListMiner";
            this.lblBlockListMiner.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListMiner.TabIndex = 148;
            this.lblBlockListMiner.Text = "no data";
            // 
            // lblBlockListTotalOutputs
            // 
            this.lblBlockListTotalOutputs.AutoSize = true;
            this.lblBlockListTotalOutputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTotalOutputs.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListTotalOutputs.Location = new System.Drawing.Point(359, 138);
            this.lblBlockListTotalOutputs.Name = "lblBlockListTotalOutputs";
            this.lblBlockListTotalOutputs.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListTotalOutputs.TabIndex = 177;
            this.lblBlockListTotalOutputs.Text = "no data";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label95.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.Silver;
            this.label95.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label95.Location = new System.Drawing.Point(4, 118);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(98, 20);
            this.label95.TabIndex = 149;
            this.label95.Text = "Miner / Pool";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label89.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.Silver;
            this.label89.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label89.Location = new System.Drawing.Point(262, 118);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(88, 20);
            this.label89.TabIndex = 176;
            this.label89.Text = "Total inputs";
            // 
            // lblBlockListBlockFeeRangeAndMedianFee
            // 
            this.lblBlockListBlockFeeRangeAndMedianFee.AutoSize = true;
            this.lblBlockListBlockFeeRangeAndMedianFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListBlockFeeRangeAndMedianFee.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListBlockFeeRangeAndMedianFee.Location = new System.Drawing.Point(392, 84);
            this.lblBlockListBlockFeeRangeAndMedianFee.Name = "lblBlockListBlockFeeRangeAndMedianFee";
            this.lblBlockListBlockFeeRangeAndMedianFee.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListBlockFeeRangeAndMedianFee.TabIndex = 150;
            this.lblBlockListBlockFeeRangeAndMedianFee.Text = "no data";
            // 
            // lblBlockListTotalInputs
            // 
            this.lblBlockListTotalInputs.AutoSize = true;
            this.lblBlockListTotalInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTotalInputs.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListTotalInputs.Location = new System.Drawing.Point(336, 120);
            this.lblBlockListTotalInputs.Name = "lblBlockListTotalInputs";
            this.lblBlockListTotalInputs.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListTotalInputs.TabIndex = 175;
            this.lblBlockListTotalInputs.Text = "no data";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label93.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.Color.Silver;
            this.label93.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label93.Location = new System.Drawing.Point(262, 82);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(163, 20);
            this.label93.TabIndex = 151;
            this.label93.Text = "Fee range / Med fee";
            // 
            // lblBlockListBlockTime
            // 
            this.lblBlockListBlockTime.AutoSize = true;
            this.lblBlockListBlockTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListBlockTime.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListBlockTime.Location = new System.Drawing.Point(77, 48);
            this.lblBlockListBlockTime.Name = "lblBlockListBlockTime";
            this.lblBlockListBlockTime.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListBlockTime.TabIndex = 152;
            this.lblBlockListBlockTime.Text = "no data";
            // 
            // lblBlockListBlockHash
            // 
            this.lblBlockListBlockHash.AutoSize = true;
            this.lblBlockListBlockHash.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockListBlockHash.Location = new System.Drawing.Point(41, 30);
            this.lblBlockListBlockHash.Name = "lblBlockListBlockHash";
            this.lblBlockListBlockHash.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListBlockHash.TabIndex = 171;
            this.lblBlockListBlockHash.Text = "no data";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label91.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.Color.Silver;
            this.label91.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label91.Location = new System.Drawing.Point(4, 46);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(84, 20);
            this.label91.TabIndex = 153;
            this.label91.Text = "Block time";
            // 
            // lblBlockListTotalFees
            // 
            this.lblBlockListTotalFees.AutoSize = true;
            this.lblBlockListTotalFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListTotalFees.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListTotalFees.Location = new System.Drawing.Point(329, 48);
            this.lblBlockListTotalFees.Name = "lblBlockListTotalFees";
            this.lblBlockListTotalFees.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListTotalFees.TabIndex = 166;
            this.lblBlockListTotalFees.Text = "no data";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label24.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Silver;
            this.label24.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label24.Location = new System.Drawing.Point(4, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 20);
            this.label24.TabIndex = 169;
            this.label24.Text = "Nonce";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label88.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.Silver;
            this.label88.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label88.Location = new System.Drawing.Point(262, 46);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(77, 20);
            this.label88.TabIndex = 167;
            this.label88.Text = "Total fees";
            // 
            // lblBlockListNonce
            // 
            this.lblBlockListNonce.AutoSize = true;
            this.lblBlockListNonce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBlockListNonce.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockListNonce.Location = new System.Drawing.Point(51, 102);
            this.lblBlockListNonce.Name = "lblBlockListNonce";
            this.lblBlockListNonce.Size = new System.Drawing.Size(64, 18);
            this.lblBlockListNonce.TabIndex = 168;
            this.lblBlockListNonce.Text = "no data";
            // 
            // panelRefreshStatusBar
            // 
            this.panelRefreshStatusBar.BackColor = System.Drawing.Color.Transparent;
            this.panelRefreshStatusBar.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panelRefreshStatusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRefreshStatusBar.Controls.Add(this.lblStatusLight);
            this.panelRefreshStatusBar.Controls.Add(this.lblRefreshSuccessOrFailMessage);
            this.panelRefreshStatusBar.Controls.Add(this.lblElapsedSinceUpdate);
            this.panelRefreshStatusBar.Location = new System.Drawing.Point(1, 758);
            this.panelRefreshStatusBar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panelRefreshStatusBar.Name = "panelRefreshStatusBar";
            this.panelRefreshStatusBar.Size = new System.Drawing.Size(500, 23);
            this.panelRefreshStatusBar.TabIndex = 197;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(707, 11);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 24);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "❔";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // panelTransaction
            // 
            this.panelTransaction.BackColor = System.Drawing.Color.Transparent;
            this.panelTransaction.Controls.Add(this.panel27);
            this.panelTransaction.Controls.Add(this.panel28);
            this.panelTransaction.Controls.Add(this.panel25);
            this.panelTransaction.Controls.Add(this.panel24);
            this.panelTransaction.Controls.Add(this.panelTransactionOutputs);
            this.panelTransaction.Controls.Add(this.panelTransactionInputs);
            this.panelTransaction.Controls.Add(this.lblInvalidTransaction);
            this.panelTransaction.Controls.Add(this.panelTransactionHeadline);
            this.panelTransaction.Controls.Add(this.panelTransactionDiagram);
            this.panelTransaction.Controls.Add(this.textBoxTransactionID);
            this.panelTransaction.Controls.Add(this.label136);
            this.panelTransaction.Location = new System.Drawing.Point(21, 188);
            this.panelTransaction.Name = "panelTransaction";
            this.panelTransaction.Size = new System.Drawing.Size(773, 556);
            this.panelTransaction.TabIndex = 172;
            this.panelTransaction.Visible = false;
            this.panelTransaction.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.Transparent;
            this.panel27.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel27.BackgroundImage")));
            this.panel27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel27.Controls.Add(this.label102);
            this.panel27.Location = new System.Drawing.Point(7, 420);
            this.panel27.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(370, 23);
            this.panel27.TabIndex = 197;
            this.panel27.Visible = false;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label102.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.ForeColor = System.Drawing.Color.Gray;
            this.label102.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label102.Location = new System.Drawing.Point(3, 2);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(123, 17);
            this.label102.TabIndex = 153;
            this.label102.Text = "Transaction inputs";
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.Transparent;
            this.panel28.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel28.BackgroundImage")));
            this.panel28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel28.Controls.Add(this.label107);
            this.panel28.Location = new System.Drawing.Point(388, 420);
            this.panel28.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(370, 23);
            this.panel28.TabIndex = 198;
            this.panel28.Visible = false;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label107.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.ForeColor = System.Drawing.Color.Gray;
            this.label107.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label107.Location = new System.Drawing.Point(3, 2);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(134, 17);
            this.label107.TabIndex = 153;
            this.label107.Text = "Transaction outputs";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel25.Controls.Add(this.btnTransactionOutputsUp);
            this.panel25.Controls.Add(this.btnTransactionOutputsDown);
            this.panel25.Location = new System.Drawing.Point(734, 451);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(26, 105);
            this.panel25.TabIndex = 215;
            // 
            // btnTransactionOutputsUp
            // 
            this.btnTransactionOutputsUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnTransactionOutputsUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnTransactionOutputsUp.FlatAppearance.BorderSize = 0;
            this.btnTransactionOutputsUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionOutputsUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionOutputsUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionOutputsUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionOutputsUp.ForeColor = System.Drawing.Color.White;
            this.btnTransactionOutputsUp.Location = new System.Drawing.Point(5, 1);
            this.btnTransactionOutputsUp.Name = "btnTransactionOutputsUp";
            this.btnTransactionOutputsUp.Size = new System.Drawing.Size(20, 20);
            this.btnTransactionOutputsUp.TabIndex = 210;
            this.btnTransactionOutputsUp.TabStop = false;
            this.btnTransactionOutputsUp.Text = "▲";
            this.btnTransactionOutputsUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTransactionOutputsUp.UseVisualStyleBackColor = false;
            this.btnTransactionOutputsUp.Visible = false;
            this.btnTransactionOutputsUp.Click += new System.EventHandler(this.BtnTransactionOutputsUp_Click);
            this.btnTransactionOutputsUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionOutputsUp_MouseDown);
            this.btnTransactionOutputsUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionOutputsUp_MouseUp);
            // 
            // btnTransactionOutputsDown
            // 
            this.btnTransactionOutputsDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnTransactionOutputsDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnTransactionOutputsDown.FlatAppearance.BorderSize = 0;
            this.btnTransactionOutputsDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionOutputsDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionOutputsDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionOutputsDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionOutputsDown.ForeColor = System.Drawing.Color.White;
            this.btnTransactionOutputsDown.Location = new System.Drawing.Point(5, 84);
            this.btnTransactionOutputsDown.Name = "btnTransactionOutputsDown";
            this.btnTransactionOutputsDown.Size = new System.Drawing.Size(20, 20);
            this.btnTransactionOutputsDown.TabIndex = 211;
            this.btnTransactionOutputsDown.TabStop = false;
            this.btnTransactionOutputsDown.Text = "▼";
            this.btnTransactionOutputsDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTransactionOutputsDown.UseVisualStyleBackColor = false;
            this.btnTransactionOutputsDown.Visible = false;
            this.btnTransactionOutputsDown.Click += new System.EventHandler(this.BtnTransactionOutputsDown_Click);
            this.btnTransactionOutputsDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionOutputsDown_MouseDown);
            this.btnTransactionOutputsDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionOutputsDown_MouseUp);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel24.Controls.Add(this.btnTransactionInputsUp);
            this.panel24.Controls.Add(this.btnTransactionInputDown);
            this.panel24.Location = new System.Drawing.Point(356, 451);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(26, 105);
            this.panel24.TabIndex = 213;
            // 
            // btnTransactionInputsUp
            // 
            this.btnTransactionInputsUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnTransactionInputsUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnTransactionInputsUp.FlatAppearance.BorderSize = 0;
            this.btnTransactionInputsUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionInputsUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionInputsUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionInputsUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionInputsUp.ForeColor = System.Drawing.Color.White;
            this.btnTransactionInputsUp.Location = new System.Drawing.Point(5, 1);
            this.btnTransactionInputsUp.Name = "btnTransactionInputsUp";
            this.btnTransactionInputsUp.Size = new System.Drawing.Size(20, 20);
            this.btnTransactionInputsUp.TabIndex = 210;
            this.btnTransactionInputsUp.TabStop = false;
            this.btnTransactionInputsUp.Text = "▲";
            this.btnTransactionInputsUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTransactionInputsUp.UseVisualStyleBackColor = false;
            this.btnTransactionInputsUp.Visible = false;
            this.btnTransactionInputsUp.Click += new System.EventHandler(this.BtnTransactionInputsUp_Click);
            this.btnTransactionInputsUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionInputsUp_MouseDown);
            this.btnTransactionInputsUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionInputsUp_MouseUp);
            // 
            // btnTransactionInputDown
            // 
            this.btnTransactionInputDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnTransactionInputDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnTransactionInputDown.FlatAppearance.BorderSize = 0;
            this.btnTransactionInputDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionInputDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnTransactionInputDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionInputDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionInputDown.ForeColor = System.Drawing.Color.White;
            this.btnTransactionInputDown.Location = new System.Drawing.Point(5, 84);
            this.btnTransactionInputDown.Name = "btnTransactionInputDown";
            this.btnTransactionInputDown.Size = new System.Drawing.Size(20, 20);
            this.btnTransactionInputDown.TabIndex = 211;
            this.btnTransactionInputDown.TabStop = false;
            this.btnTransactionInputDown.Text = "▼";
            this.btnTransactionInputDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTransactionInputDown.UseVisualStyleBackColor = false;
            this.btnTransactionInputDown.Visible = false;
            this.btnTransactionInputDown.Click += new System.EventHandler(this.BtnTransactionInputsDown_Click);
            this.btnTransactionInputDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionInputsDown_MouseDown);
            this.btnTransactionInputDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnTransactionInputsDown_MouseUp);
            // 
            // panelTransactionOutputs
            // 
            this.panelTransactionOutputs.AutoScroll = true;
            this.panelTransactionOutputs.Controls.Add(this.btnViewAddressFromTXOutput);
            this.panelTransactionOutputs.Controls.Add(this.listViewTransactionOutputs);
            this.panelTransactionOutputs.Location = new System.Drawing.Point(388, 451);
            this.panelTransactionOutputs.Name = "panelTransactionOutputs";
            this.panelTransactionOutputs.Size = new System.Drawing.Size(363, 104);
            this.panelTransactionOutputs.TabIndex = 214;
            this.panelTransactionOutputs.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTransactionOutputs_Paint);
            // 
            // listViewTransactionOutputs
            // 
            this.listViewTransactionOutputs.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewTransactionOutputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewTransactionOutputs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTransactionOutputs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTransactionOutputs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewTransactionOutputs.FullRowSelect = true;
            this.listViewTransactionOutputs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTransactionOutputs.HideSelection = false;
            this.listViewTransactionOutputs.LabelWrap = false;
            this.listViewTransactionOutputs.Location = new System.Drawing.Point(0, 0);
            this.listViewTransactionOutputs.Margin = new System.Windows.Forms.Padding(0);
            this.listViewTransactionOutputs.MultiSelect = false;
            this.listViewTransactionOutputs.Name = "listViewTransactionOutputs";
            this.listViewTransactionOutputs.OwnerDraw = true;
            this.listViewTransactionOutputs.Scrollable = false;
            this.listViewTransactionOutputs.ShowGroups = false;
            this.listViewTransactionOutputs.Size = new System.Drawing.Size(345, 88);
            this.listViewTransactionOutputs.SmallImageList = this.imageListUpDownArrows;
            this.listViewTransactionOutputs.TabIndex = 165;
            this.listViewTransactionOutputs.TabStop = false;
            this.listViewTransactionOutputs.UseCompatibleStateImageBehavior = false;
            this.listViewTransactionOutputs.View = System.Windows.Forms.View.Details;
            this.listViewTransactionOutputs.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewTransactionOutputs_ColumnWidthChanging);
            this.listViewTransactionOutputs.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewTransactionOutputs.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewTransactionOutputs_DrawSubItem);
            this.listViewTransactionOutputs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewTransactionOutputs_ItemSelectionChanged);
            // 
            // panelTransactionInputs
            // 
            this.panelTransactionInputs.AutoScroll = true;
            this.panelTransactionInputs.Controls.Add(this.btnViewAddressFromTXInput);
            this.panelTransactionInputs.Controls.Add(this.listViewTransactionInputs);
            this.panelTransactionInputs.Location = new System.Drawing.Point(10, 451);
            this.panelTransactionInputs.Name = "panelTransactionInputs";
            this.panelTransactionInputs.Size = new System.Drawing.Size(363, 104);
            this.panelTransactionInputs.TabIndex = 212;
            this.panelTransactionInputs.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTransactionInputs_Paint);
            // 
            // listViewTransactionInputs
            // 
            this.listViewTransactionInputs.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewTransactionInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewTransactionInputs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTransactionInputs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTransactionInputs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewTransactionInputs.FullRowSelect = true;
            this.listViewTransactionInputs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTransactionInputs.HideSelection = false;
            this.listViewTransactionInputs.LabelWrap = false;
            this.listViewTransactionInputs.Location = new System.Drawing.Point(0, 0);
            this.listViewTransactionInputs.Margin = new System.Windows.Forms.Padding(0);
            this.listViewTransactionInputs.MultiSelect = false;
            this.listViewTransactionInputs.Name = "listViewTransactionInputs";
            this.listViewTransactionInputs.OwnerDraw = true;
            this.listViewTransactionInputs.Scrollable = false;
            this.listViewTransactionInputs.ShowGroups = false;
            this.listViewTransactionInputs.Size = new System.Drawing.Size(345, 88);
            this.listViewTransactionInputs.SmallImageList = this.imageListUpDownArrows;
            this.listViewTransactionInputs.TabIndex = 165;
            this.listViewTransactionInputs.TabStop = false;
            this.listViewTransactionInputs.UseCompatibleStateImageBehavior = false;
            this.listViewTransactionInputs.View = System.Windows.Forms.View.Details;
            this.listViewTransactionInputs.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewTransactionInputs_ColumnWidthChanging);
            this.listViewTransactionInputs.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewTransactionInputs.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewTransactionInputs_DrawSubItem);
            this.listViewTransactionInputs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewTransactionInputs_ItemSelectionChanged);
            // 
            // lblInvalidTransaction
            // 
            this.lblInvalidTransaction.AutoSize = true;
            this.lblInvalidTransaction.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidTransaction.ForeColor = System.Drawing.Color.IndianRed;
            this.lblInvalidTransaction.Location = new System.Drawing.Point(606, 6);
            this.lblInvalidTransaction.Name = "lblInvalidTransaction";
            this.lblInvalidTransaction.Size = new System.Drawing.Size(190, 20);
            this.lblInvalidTransaction.TabIndex = 198;
            this.lblInvalidTransaction.Text = "❌ Invalid transaction ID";
            this.lblInvalidTransaction.Visible = false;
            // 
            // panelTransactionHeadline
            // 
            this.panelTransactionHeadline.BackColor = System.Drawing.Color.Transparent;
            this.panelTransactionHeadline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTransactionHeadline.Controls.Add(this.lblTransactionConfirmations);
            this.panelTransactionHeadline.Controls.Add(this.label125);
            this.panelTransactionHeadline.Controls.Add(this.label113);
            this.panelTransactionHeadline.Controls.Add(this.label98);
            this.panelTransactionHeadline.Controls.Add(this.lblTransactionVersion);
            this.panelTransactionHeadline.Controls.Add(this.lblTransactionBlockHeight);
            this.panelTransactionHeadline.Controls.Add(this.label126);
            this.panelTransactionHeadline.Controls.Add(this.lblTransactionBlockTime);
            this.panelTransactionHeadline.Controls.Add(this.label128);
            this.panelTransactionHeadline.Controls.Add(this.lblTransactionLockTime);
            this.panelTransactionHeadline.Location = new System.Drawing.Point(7, 35);
            this.panelTransactionHeadline.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panelTransactionHeadline.Name = "panelTransactionHeadline";
            this.panelTransactionHeadline.Size = new System.Drawing.Size(710, 23);
            this.panelTransactionHeadline.TabIndex = 196;
            this.panelTransactionHeadline.Visible = false;
            // 
            // lblTransactionConfirmations
            // 
            this.lblTransactionConfirmations.AutoSize = true;
            this.lblTransactionConfirmations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionConfirmations.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionConfirmations.Location = new System.Drawing.Point(388, -1);
            this.lblTransactionConfirmations.Name = "lblTransactionConfirmations";
            this.lblTransactionConfirmations.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionConfirmations.TabIndex = 171;
            this.lblTransactionConfirmations.Text = "no data";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label125.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.ForeColor = System.Drawing.Color.Silver;
            this.label125.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label125.Location = new System.Drawing.Point(291, 1);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(99, 17);
            this.label125.TabIndex = 170;
            this.label125.Text = "Confirmations";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label113.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.ForeColor = System.Drawing.Color.Silver;
            this.label113.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label113.Location = new System.Drawing.Point(3, 2);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(119, 17);
            this.label113.TabIndex = 153;
            this.label113.Text = "Included in block";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label98.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.Silver;
            this.label98.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label98.Location = new System.Drawing.Point(585, 1);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(54, 17);
            this.label98.TabIndex = 169;
            this.label98.Text = "Version";
            // 
            // lblTransactionVersion
            // 
            this.lblTransactionVersion.AutoSize = true;
            this.lblTransactionVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionVersion.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionVersion.Location = new System.Drawing.Point(628, 2);
            this.lblTransactionVersion.Name = "lblTransactionVersion";
            this.lblTransactionVersion.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionVersion.TabIndex = 168;
            this.lblTransactionVersion.Text = "no data";
            // 
            // lblTransactionBlockHeight
            // 
            this.lblTransactionBlockHeight.AutoSize = true;
            this.lblTransactionBlockHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionBlockHeight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionBlockHeight.Location = new System.Drawing.Point(102, 3);
            this.lblTransactionBlockHeight.Name = "lblTransactionBlockHeight";
            this.lblTransactionBlockHeight.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionBlockHeight.TabIndex = 152;
            this.lblTransactionBlockHeight.Text = "no data";
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label126.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.ForeColor = System.Drawing.Color.Silver;
            this.label126.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label126.Location = new System.Drawing.Point(163, 2);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(75, 17);
            this.label126.TabIndex = 143;
            this.label126.Text = "Block time";
            // 
            // lblTransactionBlockTime
            // 
            this.lblTransactionBlockTime.AutoSize = true;
            this.lblTransactionBlockTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionBlockTime.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionBlockTime.Location = new System.Drawing.Point(221, 3);
            this.lblTransactionBlockTime.Name = "lblTransactionBlockTime";
            this.lblTransactionBlockTime.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionBlockTime.TabIndex = 142;
            this.lblTransactionBlockTime.Text = "no data";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label128.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.ForeColor = System.Drawing.Color.Silver;
            this.label128.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label128.Location = new System.Drawing.Point(468, 1);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(71, 17);
            this.label128.TabIndex = 141;
            this.label128.Text = "Lock time";
            // 
            // lblTransactionLockTime
            // 
            this.lblTransactionLockTime.AutoSize = true;
            this.lblTransactionLockTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionLockTime.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionLockTime.Location = new System.Drawing.Point(526, 2);
            this.lblTransactionLockTime.Name = "lblTransactionLockTime";
            this.lblTransactionLockTime.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionLockTime.TabIndex = 140;
            this.lblTransactionLockTime.Text = "no data";
            // 
            // panelTransactionDiagram
            // 
            this.panelTransactionDiagram.BackColor = System.Drawing.Color.Transparent;
            this.panelTransactionDiagram.Controls.Add(this.lblTotalOutputValue);
            this.panelTransactionDiagram.Controls.Add(this.lblTotalInputValue);
            this.panelTransactionDiagram.Controls.Add(this.lblCoinbase);
            this.panelTransactionDiagram.Controls.Add(this.panelTransactionMiddle);
            this.panelTransactionDiagram.Controls.Add(this.lblTransactionFee);
            this.panelTransactionDiagram.Controls.Add(this.label104);
            this.panelTransactionDiagram.Controls.Add(this.lblTransactionInputCount);
            this.panelTransactionDiagram.Controls.Add(this.lblTransactionOutputCount);
            this.panelTransactionDiagram.Location = new System.Drawing.Point(9, 64);
            this.panelTransactionDiagram.Name = "panelTransactionDiagram";
            this.panelTransactionDiagram.Size = new System.Drawing.Size(753, 350);
            this.panelTransactionDiagram.TabIndex = 170;
            this.panelTransactionDiagram.Visible = false;
            this.panelTransactionDiagram.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTransactionDiagram_Paint);
            // 
            // lblTotalOutputValue
            // 
            this.lblTotalOutputValue.AutoSize = true;
            this.lblTotalOutputValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOutputValue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOutputValue.Location = new System.Drawing.Point(318, 264);
            this.lblTotalOutputValue.Name = "lblTotalOutputValue";
            this.lblTotalOutputValue.Size = new System.Drawing.Size(136, 18);
            this.lblTotalOutputValue.TabIndex = 170;
            this.lblTotalOutputValue.Text = "totalOutputValue";
            // 
            // lblTotalInputValue
            // 
            this.lblTotalInputValue.AutoSize = true;
            this.lblTotalInputValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalInputValue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInputValue.Location = new System.Drawing.Point(314, 242);
            this.lblTotalInputValue.Name = "lblTotalInputValue";
            this.lblTotalInputValue.Size = new System.Drawing.Size(128, 18);
            this.lblTotalInputValue.TabIndex = 169;
            this.lblTotalInputValue.Text = "totalInputValue";
            // 
            // lblCoinbase
            // 
            this.lblCoinbase.AutoSize = true;
            this.lblCoinbase.BackColor = System.Drawing.Color.Transparent;
            this.lblCoinbase.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinbase.Location = new System.Drawing.Point(243, 34);
            this.lblCoinbase.Name = "lblCoinbase";
            this.lblCoinbase.Size = new System.Drawing.Size(96, 18);
            this.lblCoinbase.TabIndex = 168;
            this.lblCoinbase.Text = "Is_coinbase";
            // 
            // panelTransactionMiddle
            // 
            this.panelTransactionMiddle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTransactionMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelTransactionMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransactionMiddle.Controls.Add(this.label132);
            this.panelTransactionMiddle.Controls.Add(this.label130);
            this.panelTransactionMiddle.Controls.Add(this.lblTransactionSize);
            this.panelTransactionMiddle.Controls.Add(this.lblTransactionWeight);
            this.panelTransactionMiddle.Location = new System.Drawing.Point(336, 135);
            this.panelTransactionMiddle.Name = "panelTransactionMiddle";
            this.panelTransactionMiddle.Size = new System.Drawing.Size(80, 80);
            this.panelTransactionMiddle.TabIndex = 0;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label132.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.ForeColor = System.Drawing.Color.Silver;
            this.label132.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label132.Location = new System.Drawing.Point(0, 2);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(80, 17);
            this.label132.TabIndex = 137;
            this.label132.Text = "size";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label130.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.ForeColor = System.Drawing.Color.Silver;
            this.label130.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label130.Location = new System.Drawing.Point(0, 37);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(80, 17);
            this.label130.TabIndex = 139;
            this.label130.Text = "weight";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransactionSize
            // 
            this.lblTransactionSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionSize.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionSize.Location = new System.Drawing.Point(0, 16);
            this.lblTransactionSize.Name = "lblTransactionSize";
            this.lblTransactionSize.Size = new System.Drawing.Size(80, 18);
            this.lblTransactionSize.TabIndex = 136;
            this.lblTransactionSize.Text = "no data";
            this.lblTransactionSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransactionWeight
            // 
            this.lblTransactionWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTransactionWeight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionWeight.Location = new System.Drawing.Point(0, 53);
            this.lblTransactionWeight.Name = "lblTransactionWeight";
            this.lblTransactionWeight.Size = new System.Drawing.Size(80, 23);
            this.lblTransactionWeight.TabIndex = 138;
            this.lblTransactionWeight.Text = "no data";
            this.lblTransactionWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransactionFee
            // 
            this.lblTransactionFee.AutoSize = true;
            this.lblTransactionFee.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionFee.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionFee.Location = new System.Drawing.Point(340, 31);
            this.lblTransactionFee.Name = "lblTransactionFee";
            this.lblTransactionFee.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionFee.TabIndex = 166;
            this.lblTransactionFee.Text = "no data";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label104.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.ForeColor = System.Drawing.Color.Silver;
            this.label104.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label104.Location = new System.Drawing.Point(357, 14);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(30, 17);
            this.label104.TabIndex = 167;
            this.label104.Text = "Fee";
            // 
            // lblTransactionInputCount
            // 
            this.lblTransactionInputCount.AutoSize = true;
            this.lblTransactionInputCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionInputCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionInputCount.Location = new System.Drawing.Point(251, 15);
            this.lblTransactionInputCount.Name = "lblTransactionInputCount";
            this.lblTransactionInputCount.Size = new System.Drawing.Size(56, 18);
            this.lblTransactionInputCount.TabIndex = 150;
            this.lblTransactionInputCount.Text = "inputs";
            // 
            // lblTransactionOutputCount
            // 
            this.lblTransactionOutputCount.AutoSize = true;
            this.lblTransactionOutputCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionOutputCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionOutputCount.Location = new System.Drawing.Point(418, 16);
            this.lblTransactionOutputCount.Name = "lblTransactionOutputCount";
            this.lblTransactionOutputCount.Size = new System.Drawing.Size(64, 18);
            this.lblTransactionOutputCount.TabIndex = 144;
            this.lblTransactionOutputCount.Text = "outputs";
            // 
            // textBoxTransactionID
            // 
            this.textBoxTransactionID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxTransactionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTransactionID.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTransactionID.ForeColor = System.Drawing.Color.White;
            this.textBoxTransactionID.Location = new System.Drawing.Point(121, 3);
            this.textBoxTransactionID.MaxLength = 80;
            this.textBoxTransactionID.Name = "textBoxTransactionID";
            this.textBoxTransactionID.Size = new System.Drawing.Size(479, 25);
            this.textBoxTransactionID.TabIndex = 7;
            this.textBoxTransactionID.TextChanged += new System.EventHandler(this.TextBoxTransactionID_TextChanged);
            this.textBoxTransactionID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTransactionID_KeyPress);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.ForeColor = System.Drawing.Color.Silver;
            this.label136.Location = new System.Drawing.Point(-3, 5);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(152, 20);
            this.label136.TabIndex = 6;
            this.label136.Text = "Enter transaction ID";
            // 
            // TXInScrollTimer
            // 
            this.TXInScrollTimer.Interval = 50;
            this.TXInScrollTimer.Tick += new System.EventHandler(this.TXInTimer_Tick);
            // 
            // TXOutScrollTimer
            // 
            this.TXOutScrollTimer.Interval = 50;
            this.TXOutScrollTimer.Tick += new System.EventHandler(this.TXOutTimer_Tick);
            // 
            // panelXpub
            // 
            this.panelXpub.BackColor = System.Drawing.Color.Transparent;
            this.panelXpub.Controls.Add(this.label141);
            this.panelXpub.Controls.Add(this.label140);
            this.panelXpub.Controls.Add(this.numberUpDownDerivationPathsToCheck);
            this.panelXpub.Controls.Add(this.label139);
            this.panelXpub.Controls.Add(this.lblP2SHUsedAddresses);
            this.panelXpub.Controls.Add(this.label135);
            this.panelXpub.Controls.Add(this.lblP2SHSummary);
            this.panelXpub.Controls.Add(this.lblCheckAllAddressTypesCount);
            this.panelXpub.Controls.Add(this.lblCheckEachAddressTypeCount);
            this.panelXpub.Controls.Add(this.progressBarCheckAllAddressTypes);
            this.panelXpub.Controls.Add(this.progressBarCheckEachAddressType);
            this.panelXpub.Controls.Add(this.label18);
            this.panelXpub.Controls.Add(this.lblXpubNodeStatusLight);
            this.panelXpub.Controls.Add(this.lblValidXpubIndicator);
            this.panelXpub.Controls.Add(this.textBoxXpubNodeURL);
            this.panelXpub.Controls.Add(this.panel30);
            this.panelXpub.Controls.Add(this.panelXpubContainer);
            this.panelXpub.Controls.Add(this.lblLegacyUsedAddresses);
            this.panelXpub.Controls.Add(this.lblSegwitP2SHUsedAddresses);
            this.panelXpub.Controls.Add(this.lblSegwitUsedAddresses);
            this.panelXpub.Controls.Add(this.label121);
            this.panelXpub.Controls.Add(this.lblXpubConfirmedUnspent);
            this.panelXpub.Controls.Add(this.panel29);
            this.panelXpub.Controls.Add(this.label129);
            this.panelXpub.Controls.Add(this.lblXpubConfirmedSpent);
            this.panelXpub.Controls.Add(this.label133);
            this.panelXpub.Controls.Add(this.lblXpubConfirmedReceived);
            this.panelXpub.Controls.Add(this.panel26);
            this.panelXpub.Controls.Add(this.lblXpubStatus);
            this.panelXpub.Controls.Add(this.label119);
            this.panelXpub.Controls.Add(this.lblSegwitP2SHSummary);
            this.panelXpub.Controls.Add(this.panel23);
            this.panelXpub.Controls.Add(this.label114);
            this.panelXpub.Controls.Add(this.label111);
            this.panelXpub.Controls.Add(this.lblLegacySummary);
            this.panelXpub.Controls.Add(this.label123);
            this.panelXpub.Controls.Add(this.lblSegwitSummary);
            this.panelXpub.Controls.Add(this.textBoxSubmittedXpub);
            this.panelXpub.Controls.Add(this.label146);
            this.panelXpub.Location = new System.Drawing.Point(21, 188);
            this.panelXpub.Name = "panelXpub";
            this.panelXpub.Size = new System.Drawing.Size(773, 556);
            this.panelXpub.TabIndex = 199;
            this.panelXpub.Visible = false;
            this.panelXpub.VisibleChanged += new System.EventHandler(this.HideBookmarksShowFees);
            this.panelXpub.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelXpub_Paint);
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label141.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.ForeColor = System.Drawing.Color.Silver;
            this.label141.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label141.Location = new System.Drawing.Point(0, 179);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(109, 17);
            this.label141.TabIndex = 238;
            this.label141.Text = "overall progress";
            this.label141.Visible = false;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label140.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.ForeColor = System.Drawing.Color.Silver;
            this.label140.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label140.Location = new System.Drawing.Point(0, 165);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(109, 17);
            this.label140.TabIndex = 154;
            this.label140.Text = "derivation path";
            this.label140.Visible = false;
            // 
            // numberUpDownDerivationPathsToCheck
            // 
            this.numberUpDownDerivationPathsToCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numberUpDownDerivationPathsToCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberUpDownDerivationPathsToCheck.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberUpDownDerivationPathsToCheck.ForeColor = System.Drawing.Color.White;
            this.numberUpDownDerivationPathsToCheck.Location = new System.Drawing.Point(691, 0);
            this.numberUpDownDerivationPathsToCheck.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberUpDownDerivationPathsToCheck.Name = "numberUpDownDerivationPathsToCheck";
            this.numberUpDownDerivationPathsToCheck.Size = new System.Drawing.Size(57, 25);
            this.numberUpDownDerivationPathsToCheck.TabIndex = 218;
            this.numberUpDownDerivationPathsToCheck.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberUpDownDerivationPathsToCheck.Validating += new System.ComponentModel.CancelEventHandler(this.NumberUpDownDerivationPathsToCheck_Validating);
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.ForeColor = System.Drawing.Color.Silver;
            this.label139.Location = new System.Drawing.Point(578, 0);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(129, 20);
            this.label139.TabIndex = 237;
            this.label139.Text = "Derivation paths";
            // 
            // lblP2SHUsedAddresses
            // 
            this.lblP2SHUsedAddresses.AutoSize = true;
            this.lblP2SHUsedAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblP2SHUsedAddresses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2SHUsedAddresses.Location = new System.Drawing.Point(40, 347);
            this.lblP2SHUsedAddresses.Name = "lblP2SHUsedAddresses";
            this.lblP2SHUsedAddresses.Size = new System.Drawing.Size(16, 18);
            this.lblP2SHUsedAddresses.TabIndex = 236;
            this.lblP2SHUsedAddresses.Text = "0";
            this.lblP2SHUsedAddresses.Visible = false;
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label135.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label135.ForeColor = System.Drawing.Color.Silver;
            this.label135.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label135.Location = new System.Drawing.Point(0, 347);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(38, 17);
            this.label135.TabIndex = 235;
            this.label135.Text = "P2SH";
            this.label135.Visible = false;
            // 
            // lblCheckAllAddressTypesCount
            // 
            this.lblCheckAllAddressTypesCount.AutoSize = true;
            this.lblCheckAllAddressTypesCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCheckAllAddressTypesCount.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckAllAddressTypesCount.Location = new System.Drawing.Point(185, 179);
            this.lblCheckAllAddressTypesCount.Name = "lblCheckAllAddressTypesCount";
            this.lblCheckAllAddressTypesCount.Size = new System.Drawing.Size(14, 15);
            this.lblCheckAllAddressTypesCount.TabIndex = 233;
            this.lblCheckAllAddressTypesCount.Text = "0";
            this.lblCheckAllAddressTypesCount.Visible = false;
            // 
            // lblCheckEachAddressTypeCount
            // 
            this.lblCheckEachAddressTypeCount.AutoSize = true;
            this.lblCheckEachAddressTypeCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCheckEachAddressTypeCount.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckEachAddressTypeCount.Location = new System.Drawing.Point(185, 165);
            this.lblCheckEachAddressTypeCount.Name = "lblCheckEachAddressTypeCount";
            this.lblCheckEachAddressTypeCount.Size = new System.Drawing.Size(14, 15);
            this.lblCheckEachAddressTypeCount.TabIndex = 232;
            this.lblCheckEachAddressTypeCount.Text = "0";
            this.lblCheckEachAddressTypeCount.Visible = false;
            // 
            // progressBarCheckAllAddressTypes
            // 
            this.progressBarCheckAllAddressTypes.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarCheckAllAddressTypes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.progressBarCheckAllAddressTypes.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarCheckAllAddressTypes.ForeColor = System.Drawing.Color.Black;
            this.progressBarCheckAllAddressTypes.Location = new System.Drawing.Point(115, 183);
            this.progressBarCheckAllAddressTypes.Maximum = 100;
            this.progressBarCheckAllAddressTypes.Minimum = 0;
            this.progressBarCheckAllAddressTypes.Name = "progressBarCheckAllAddressTypes";
            this.progressBarCheckAllAddressTypes.Size = new System.Drawing.Size(68, 8);
            this.progressBarCheckAllAddressTypes.Step = 10;
            this.progressBarCheckAllAddressTypes.TabIndex = 231;
            this.progressBarCheckAllAddressTypes.Value = 0;
            this.progressBarCheckAllAddressTypes.Visible = false;
            // 
            // progressBarCheckEachAddressType
            // 
            this.progressBarCheckEachAddressType.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.progressBarCheckEachAddressType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.progressBarCheckEachAddressType.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressBarCheckEachAddressType.ForeColor = System.Drawing.Color.Black;
            this.progressBarCheckEachAddressType.Location = new System.Drawing.Point(115, 169);
            this.progressBarCheckEachAddressType.Maximum = 100;
            this.progressBarCheckEachAddressType.Minimum = 0;
            this.progressBarCheckEachAddressType.Name = "progressBarCheckEachAddressType";
            this.progressBarCheckEachAddressType.Size = new System.Drawing.Size(68, 8);
            this.progressBarCheckEachAddressType.Step = 10;
            this.progressBarCheckEachAddressType.TabIndex = 230;
            this.progressBarCheckEachAddressType.Value = 0;
            this.progressBarCheckEachAddressType.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Silver;
            this.label18.Location = new System.Drawing.Point(678, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(160, 20);
            this.label18.TabIndex = 220;
            this.label18.Text = "invalid / node offline";
            // 
            // lblXpubNodeStatusLight
            // 
            this.lblXpubNodeStatusLight.AutoSize = true;
            this.lblXpubNodeStatusLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblXpubNodeStatusLight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXpubNodeStatusLight.ForeColor = System.Drawing.Color.IndianRed;
            this.lblXpubNodeStatusLight.Location = new System.Drawing.Point(649, 33);
            this.lblXpubNodeStatusLight.Name = "lblXpubNodeStatusLight";
            this.lblXpubNodeStatusLight.Size = new System.Drawing.Size(23, 18);
            this.lblXpubNodeStatusLight.TabIndex = 219;
            this.lblXpubNodeStatusLight.Text = "🟢";
            // 
            // lblValidXpubIndicator
            // 
            this.lblValidXpubIndicator.AutoSize = true;
            this.lblValidXpubIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblValidXpubIndicator.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidXpubIndicator.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblValidXpubIndicator.Location = new System.Drawing.Point(648, 33);
            this.lblValidXpubIndicator.Name = "lblValidXpubIndicator";
            this.lblValidXpubIndicator.Size = new System.Drawing.Size(0, 20);
            this.lblValidXpubIndicator.TabIndex = 218;
            // 
            // textBoxXpubNodeURL
            // 
            this.textBoxXpubNodeURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxXpubNodeURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxXpubNodeURL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXpubNodeURL.ForeColor = System.Drawing.Color.Gray;
            this.textBoxXpubNodeURL.Location = new System.Drawing.Point(200, 0);
            this.textBoxXpubNodeURL.Name = "textBoxXpubNodeURL";
            this.textBoxXpubNodeURL.Size = new System.Drawing.Size(213, 25);
            this.textBoxXpubNodeURL.TabIndex = 200;
            this.textBoxXpubNodeURL.Text = "e.g http://umbrel.local:3006/api/";
            this.textBoxXpubNodeURL.TextChanged += new System.EventHandler(this.TextBoxMempoolURL_TextChanged);
            this.textBoxXpubNodeURL.Enter += new System.EventHandler(this.TextBoxMempoolURL_Enter);
            this.textBoxXpubNodeURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxMempoolURL_KeyPress);
            this.textBoxXpubNodeURL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxMempoolURL_KeyUp);
            this.textBoxXpubNodeURL.Leave += new System.EventHandler(this.TextBoxMempoolURL_Leave);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel30.Controls.Add(this.btnXpubAddressesDown);
            this.panel30.Controls.Add(this.btnXpubAddressUp);
            this.panel30.Location = new System.Drawing.Point(713, 68);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(37, 456);
            this.panel30.TabIndex = 214;
            // 
            // btnXpubAddressesDown
            // 
            this.btnXpubAddressesDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnXpubAddressesDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnXpubAddressesDown.FlatAppearance.BorderSize = 0;
            this.btnXpubAddressesDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXpubAddressesDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXpubAddressesDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXpubAddressesDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXpubAddressesDown.ForeColor = System.Drawing.Color.White;
            this.btnXpubAddressesDown.Location = new System.Drawing.Point(10, 432);
            this.btnXpubAddressesDown.Name = "btnXpubAddressesDown";
            this.btnXpubAddressesDown.Size = new System.Drawing.Size(24, 24);
            this.btnXpubAddressesDown.TabIndex = 212;
            this.btnXpubAddressesDown.TabStop = false;
            this.btnXpubAddressesDown.Text = "▼";
            this.btnXpubAddressesDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXpubAddressesDown.UseVisualStyleBackColor = false;
            this.btnXpubAddressesDown.Visible = false;
            this.btnXpubAddressesDown.Click += new System.EventHandler(this.BtnXpubAddressesDown_Click);
            this.btnXpubAddressesDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnXpubAddressesDown_MouseDown);
            this.btnXpubAddressesDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnXpubAddressesDown_MouseUp);
            // 
            // btnXpubAddressUp
            // 
            this.btnXpubAddressUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnXpubAddressUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnXpubAddressUp.FlatAppearance.BorderSize = 0;
            this.btnXpubAddressUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXpubAddressUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXpubAddressUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXpubAddressUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXpubAddressUp.ForeColor = System.Drawing.Color.White;
            this.btnXpubAddressUp.Location = new System.Drawing.Point(10, 9);
            this.btnXpubAddressUp.Name = "btnXpubAddressUp";
            this.btnXpubAddressUp.Size = new System.Drawing.Size(24, 24);
            this.btnXpubAddressUp.TabIndex = 214;
            this.btnXpubAddressUp.TabStop = false;
            this.btnXpubAddressUp.Text = "▲";
            this.btnXpubAddressUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXpubAddressUp.UseVisualStyleBackColor = false;
            this.btnXpubAddressUp.Visible = false;
            this.btnXpubAddressUp.Click += new System.EventHandler(this.BtnXpubAddressUp_Click);
            this.btnXpubAddressUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnXpubAddressUp_MouseDown);
            this.btnXpubAddressUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnXpubAddressUp_MouseUp);
            // 
            // panelXpubContainer
            // 
            this.panelXpubContainer.AutoScroll = true;
            this.panelXpubContainer.Controls.Add(this.btnViewAddressFromXpub);
            this.panelXpubContainer.Controls.Add(this.listViewXpubAddresses);
            this.panelXpubContainer.Location = new System.Drawing.Point(250, 78);
            this.panelXpubContainer.Name = "panelXpubContainer";
            this.panelXpubContainer.Size = new System.Drawing.Size(500, 446);
            this.panelXpubContainer.TabIndex = 213;
            this.panelXpubContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelXpubContainer_Paint);
            // 
            // listViewXpubAddresses
            // 
            this.listViewXpubAddresses.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewXpubAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewXpubAddresses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewXpubAddresses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewXpubAddresses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewXpubAddresses.FullRowSelect = true;
            this.listViewXpubAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewXpubAddresses.HideSelection = false;
            this.listViewXpubAddresses.LabelWrap = false;
            this.listViewXpubAddresses.Location = new System.Drawing.Point(1, 1);
            this.listViewXpubAddresses.Margin = new System.Windows.Forms.Padding(0);
            this.listViewXpubAddresses.MultiSelect = false;
            this.listViewXpubAddresses.Name = "listViewXpubAddresses";
            this.listViewXpubAddresses.OwnerDraw = true;
            this.listViewXpubAddresses.Scrollable = false;
            this.listViewXpubAddresses.ShowGroups = false;
            this.listViewXpubAddresses.Size = new System.Drawing.Size(466, 438);
            this.listViewXpubAddresses.SmallImageList = this.imageListUpDownArrows;
            this.listViewXpubAddresses.TabIndex = 164;
            this.listViewXpubAddresses.TabStop = false;
            this.listViewXpubAddresses.UseCompatibleStateImageBehavior = false;
            this.listViewXpubAddresses.View = System.Windows.Forms.View.Details;
            this.listViewXpubAddresses.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewXpubAddresses_ColumnWidthChanging);
            this.listViewXpubAddresses.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewXpubAddresses.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewXpubAddresses_DrawSubItem);
            this.listViewXpubAddresses.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewXpubAddresses_ItemSelectionChanged);
            // 
            // lblLegacyUsedAddresses
            // 
            this.lblLegacyUsedAddresses.AutoSize = true;
            this.lblLegacyUsedAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLegacyUsedAddresses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegacyUsedAddresses.Location = new System.Drawing.Point(57, 270);
            this.lblLegacyUsedAddresses.Name = "lblLegacyUsedAddresses";
            this.lblLegacyUsedAddresses.Size = new System.Drawing.Size(16, 18);
            this.lblLegacyUsedAddresses.TabIndex = 213;
            this.lblLegacyUsedAddresses.Text = "0";
            this.lblLegacyUsedAddresses.Visible = false;
            this.lblLegacyUsedAddresses.Paint += new System.Windows.Forms.PaintEventHandler(this.LblLegacyUsedAddresses_Paint);
            // 
            // lblSegwitP2SHUsedAddresses
            // 
            this.lblSegwitP2SHUsedAddresses.AutoSize = true;
            this.lblSegwitP2SHUsedAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSegwitP2SHUsedAddresses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegwitP2SHUsedAddresses.Location = new System.Drawing.Point(95, 309);
            this.lblSegwitP2SHUsedAddresses.Name = "lblSegwitP2SHUsedAddresses";
            this.lblSegwitP2SHUsedAddresses.Size = new System.Drawing.Size(16, 18);
            this.lblSegwitP2SHUsedAddresses.TabIndex = 212;
            this.lblSegwitP2SHUsedAddresses.Text = "0";
            this.lblSegwitP2SHUsedAddresses.Visible = false;
            this.lblSegwitP2SHUsedAddresses.Paint += new System.Windows.Forms.PaintEventHandler(this.LblSegwitP2SHUsedAddresses_Paint);
            // 
            // lblSegwitUsedAddresses
            // 
            this.lblSegwitUsedAddresses.AutoSize = true;
            this.lblSegwitUsedAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSegwitUsedAddresses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegwitUsedAddresses.Location = new System.Drawing.Point(57, 231);
            this.lblSegwitUsedAddresses.Name = "lblSegwitUsedAddresses";
            this.lblSegwitUsedAddresses.Size = new System.Drawing.Size(16, 18);
            this.lblSegwitUsedAddresses.TabIndex = 211;
            this.lblSegwitUsedAddresses.Text = "0";
            this.lblSegwitUsedAddresses.Visible = false;
            this.lblSegwitUsedAddresses.Paint += new System.Windows.Forms.PaintEventHandler(this.LblSegwitUsedAddresses_Paint);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label121.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label121.ForeColor = System.Drawing.Color.Silver;
            this.label121.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label121.Location = new System.Drawing.Point(0, 493);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(199, 17);
            this.label121.TabIndex = 208;
            this.label121.Text = "Confirmed unspent (balance)";
            this.label121.Visible = false;
            // 
            // lblXpubConfirmedUnspent
            // 
            this.lblXpubConfirmedUnspent.AutoSize = true;
            this.lblXpubConfirmedUnspent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblXpubConfirmedUnspent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXpubConfirmedUnspent.Location = new System.Drawing.Point(0, 512);
            this.lblXpubConfirmedUnspent.Name = "lblXpubConfirmedUnspent";
            this.lblXpubConfirmedUnspent.Size = new System.Drawing.Size(16, 18);
            this.lblXpubConfirmedUnspent.TabIndex = 207;
            this.lblXpubConfirmedUnspent.Text = "0";
            this.lblXpubConfirmedUnspent.Visible = false;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.Transparent;
            this.panel29.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel29.BackgroundImage")));
            this.panel29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel29.Controls.Add(this.label127);
            this.panel29.Location = new System.Drawing.Point(0, 385);
            this.panel29.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(242, 23);
            this.panel29.TabIndex = 206;
            this.panel29.Visible = false;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label127.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.ForeColor = System.Drawing.Color.Gray;
            this.label127.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label127.Location = new System.Drawing.Point(3, 2);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(44, 17);
            this.label127.TabIndex = 153;
            this.label127.Text = "Totals";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label129.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label129.ForeColor = System.Drawing.Color.Silver;
            this.label129.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label129.Location = new System.Drawing.Point(0, 453);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(116, 17);
            this.label129.TabIndex = 205;
            this.label129.Text = "Confirmed spent";
            this.label129.Visible = false;
            // 
            // lblXpubConfirmedSpent
            // 
            this.lblXpubConfirmedSpent.AutoSize = true;
            this.lblXpubConfirmedSpent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblXpubConfirmedSpent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXpubConfirmedSpent.Location = new System.Drawing.Point(0, 472);
            this.lblXpubConfirmedSpent.Name = "lblXpubConfirmedSpent";
            this.lblXpubConfirmedSpent.Size = new System.Drawing.Size(16, 18);
            this.lblXpubConfirmedSpent.TabIndex = 204;
            this.lblXpubConfirmedSpent.Text = "0";
            this.lblXpubConfirmedSpent.Visible = false;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label133.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label133.ForeColor = System.Drawing.Color.Silver;
            this.label133.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label133.Location = new System.Drawing.Point(0, 415);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(137, 17);
            this.label133.TabIndex = 203;
            this.label133.Text = "Confirmed received";
            this.label133.Visible = false;
            // 
            // lblXpubConfirmedReceived
            // 
            this.lblXpubConfirmedReceived.AutoSize = true;
            this.lblXpubConfirmedReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblXpubConfirmedReceived.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXpubConfirmedReceived.Location = new System.Drawing.Point(0, 434);
            this.lblXpubConfirmedReceived.Name = "lblXpubConfirmedReceived";
            this.lblXpubConfirmedReceived.Size = new System.Drawing.Size(16, 18);
            this.lblXpubConfirmedReceived.TabIndex = 202;
            this.lblXpubConfirmedReceived.Text = "0";
            this.lblXpubConfirmedReceived.Visible = false;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Transparent;
            this.panel26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel26.BackgroundImage")));
            this.panel26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel26.Controls.Add(this.label124);
            this.panel26.Location = new System.Drawing.Point(1, 78);
            this.panel26.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(242, 23);
            this.panel26.TabIndex = 199;
            this.panel26.Visible = false;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label124.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.ForeColor = System.Drawing.Color.Gray;
            this.label124.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label124.Location = new System.Drawing.Point(3, 2);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(46, 17);
            this.label124.TabIndex = 153;
            this.label124.Text = "Status";
            // 
            // lblXpubStatus
            // 
            this.lblXpubStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXpubStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblXpubStatus.Location = new System.Drawing.Point(0, 110);
            this.lblXpubStatus.Name = "lblXpubStatus";
            this.lblXpubStatus.Size = new System.Drawing.Size(243, 92);
            this.lblXpubStatus.TabIndex = 201;
            this.lblXpubStatus.Visible = false;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label119.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label119.ForeColor = System.Drawing.Color.Silver;
            this.label119.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label119.Location = new System.Drawing.Point(0, 309);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(95, 17);
            this.label119.TabIndex = 200;
            this.label119.Text = "P2SH-P2WPKH";
            this.label119.Visible = false;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Transparent;
            this.panel23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel23.BackgroundImage")));
            this.panel23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel23.Controls.Add(this.label117);
            this.panel23.Location = new System.Drawing.Point(0, 201);
            this.panel23.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(242, 23);
            this.panel23.TabIndex = 198;
            this.panel23.Visible = false;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label117.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.Color.Gray;
            this.label117.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label117.Location = new System.Drawing.Point(3, 2);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(108, 17);
            this.label117.TabIndex = 153;
            this.label117.Text = "Used addresses ";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.ForeColor = System.Drawing.Color.Silver;
            this.label114.Location = new System.Drawing.Point(0, 1);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(213, 20);
            this.label114.TabIndex = 168;
            this.label114.Text = "Path to mempool.space API";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label111.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label111.ForeColor = System.Drawing.Color.Silver;
            this.label111.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label111.Location = new System.Drawing.Point(0, 269);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(95, 17);
            this.label111.TabIndex = 167;
            this.label111.Text = "P2PKH legacy";
            this.label111.Visible = false;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label123.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label123.ForeColor = System.Drawing.Color.Silver;
            this.label123.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label123.Location = new System.Drawing.Point(0, 231);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(158, 17);
            this.label123.TabIndex = 153;
            this.label123.Text = "P2WPKH Bech32 SegWit";
            this.label123.Visible = false;
            // 
            // textBoxSubmittedXpub
            // 
            this.textBoxSubmittedXpub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSubmittedXpub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSubmittedXpub.Enabled = false;
            this.textBoxSubmittedXpub.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubmittedXpub.ForeColor = System.Drawing.Color.White;
            this.textBoxSubmittedXpub.Location = new System.Drawing.Point(63, 31);
            this.textBoxSubmittedXpub.MaxLength = 200;
            this.textBoxSubmittedXpub.Name = "textBoxSubmittedXpub";
            this.textBoxSubmittedXpub.Size = new System.Drawing.Size(580, 25);
            this.textBoxSubmittedXpub.TabIndex = 7;
            this.textBoxSubmittedXpub.TextChanged += new System.EventHandler(this.TextBoxSubmittedXpub_TextChanged);
            this.textBoxSubmittedXpub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSubmittedXpub_KeyPress);
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.ForeColor = System.Drawing.Color.Silver;
            this.label146.Location = new System.Drawing.Point(0, 33);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(47, 20);
            this.label146.TabIndex = 6;
            this.label146.Text = "Xpub";
            // 
            // timerHideProgressBars
            // 
            this.timerHideProgressBars.Interval = 2000;
            this.timerHideProgressBars.Tick += new System.EventHandler(this.TimerHideProgressBars_Tick);
            // 
            // XpubScrollTimer
            // 
            this.XpubScrollTimer.Interval = 50;
            this.XpubScrollTimer.Tick += new System.EventHandler(this.XpubScrollTimer_Tick);
            // 
            // btnAddToBookmarks
            // 
            this.btnAddToBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnAddToBookmarks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnAddToBookmarks.FlatAppearance.BorderSize = 0;
            this.btnAddToBookmarks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnAddToBookmarks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnAddToBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToBookmarks.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToBookmarks.ForeColor = System.Drawing.Color.White;
            this.btnAddToBookmarks.Location = new System.Drawing.Point(557, 11);
            this.btnAddToBookmarks.Name = "btnAddToBookmarks";
            this.btnAddToBookmarks.Size = new System.Drawing.Size(24, 24);
            this.btnAddToBookmarks.TabIndex = 2;
            this.btnAddToBookmarks.TabStop = false;
            this.btnAddToBookmarks.Text = "🧡";
            this.btnAddToBookmarks.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddToBookmarks.UseVisualStyleBackColor = false;
            this.btnAddToBookmarks.Click += new System.EventHandler(this.BtnAddToBookmarks_Click);
            // 
            // panelAddToBookmarks
            // 
            this.panelAddToBookmarks.BackColor = System.Drawing.Color.Transparent;
            this.panelAddToBookmarks.Controls.Add(this.lblBookmarkSavedSuccess);
            this.panelAddToBookmarks.Controls.Add(this.panel31);
            this.panelAddToBookmarks.Controls.Add(this.textBoxBookmarkEncryptionKey);
            this.panelAddToBookmarks.Controls.Add(this.textBoxBookmarkProposedNote);
            this.panelAddToBookmarks.Controls.Add(this.btnCancelAddToBookmarks);
            this.panelAddToBookmarks.Controls.Add(this.btnCommitToBookmarks);
            this.panelAddToBookmarks.Location = new System.Drawing.Point(501, 40);
            this.panelAddToBookmarks.Name = "panelAddToBookmarks";
            this.panelAddToBookmarks.Size = new System.Drawing.Size(261, 122);
            this.panelAddToBookmarks.TabIndex = 201;
            this.panelAddToBookmarks.Visible = false;
            this.panelAddToBookmarks.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAddToBookmarks_Paint);
            // 
            // lblBookmarkSavedSuccess
            // 
            this.lblBookmarkSavedSuccess.AutoSize = true;
            this.lblBookmarkSavedSuccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkSavedSuccess.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkSavedSuccess.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblBookmarkSavedSuccess.Location = new System.Drawing.Point(8, 94);
            this.lblBookmarkSavedSuccess.Name = "lblBookmarkSavedSuccess";
            this.lblBookmarkSavedSuccess.Size = new System.Drawing.Size(76, 20);
            this.lblBookmarkSavedSuccess.TabIndex = 217;
            this.lblBookmarkSavedSuccess.Text = "✔️saved";
            this.lblBookmarkSavedSuccess.Visible = false;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.Transparent;
            this.panel31.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel31.Controls.Add(this.label131);
            this.panel31.Controls.Add(this.lblBookmarkProposalType);
            this.panel31.Controls.Add(this.lblBookmarkProposalData);
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(252, 23);
            this.panel31.TabIndex = 200;
            // 
            // label131
            // 
            this.label131.AutoEllipsis = true;
            this.label131.AutoSize = true;
            this.label131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label131.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.ForeColor = System.Drawing.Color.Gray;
            this.label131.Location = new System.Drawing.Point(0, 0);
            this.label131.Margin = new System.Windows.Forms.Padding(0);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(82, 20);
            this.label131.TabIndex = 161;
            this.label131.Text = "Bookmark";
            // 
            // lblBookmarkProposalType
            // 
            this.lblBookmarkProposalType.AutoEllipsis = true;
            this.lblBookmarkProposalType.AutoSize = true;
            this.lblBookmarkProposalType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkProposalType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkProposalType.ForeColor = System.Drawing.Color.Silver;
            this.lblBookmarkProposalType.Location = new System.Drawing.Point(35, 0);
            this.lblBookmarkProposalType.Margin = new System.Windows.Forms.Padding(0);
            this.lblBookmarkProposalType.Name = "lblBookmarkProposalType";
            this.lblBookmarkProposalType.Size = new System.Drawing.Size(42, 20);
            this.lblBookmarkProposalType.TabIndex = 48;
            this.lblBookmarkProposalType.Text = "type";
            // 
            // lblBookmarkProposalData
            // 
            this.lblBookmarkProposalData.AutoEllipsis = true;
            this.lblBookmarkProposalData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkProposalData.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkProposalData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBookmarkProposalData.Location = new System.Drawing.Point(78, 0);
            this.lblBookmarkProposalData.Margin = new System.Windows.Forms.Padding(0);
            this.lblBookmarkProposalData.Name = "lblBookmarkProposalData";
            this.lblBookmarkProposalData.Size = new System.Drawing.Size(44, 20);
            this.lblBookmarkProposalData.TabIndex = 51;
            this.lblBookmarkProposalData.Text = "data";
            // 
            // textBoxBookmarkEncryptionKey
            // 
            this.textBoxBookmarkEncryptionKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxBookmarkEncryptionKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBookmarkEncryptionKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBookmarkEncryptionKey.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBookmarkEncryptionKey.Location = new System.Drawing.Point(9, 61);
            this.textBoxBookmarkEncryptionKey.Name = "textBoxBookmarkEncryptionKey";
            this.textBoxBookmarkEncryptionKey.Size = new System.Drawing.Size(252, 25);
            this.textBoxBookmarkEncryptionKey.TabIndex = 216;
            this.textBoxBookmarkEncryptionKey.TabStop = false;
            this.textBoxBookmarkEncryptionKey.Text = "optional encryption key";
            this.textBoxBookmarkEncryptionKey.TextChanged += new System.EventHandler(this.TextBoxBookmarkEncryptionKey_TextChanged);
            this.textBoxBookmarkEncryptionKey.Enter += new System.EventHandler(this.TextBoxBookmarkEncryptionKey_Enter);
            this.textBoxBookmarkEncryptionKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxBookmarkEncryptionKey_KeyPress);
            this.textBoxBookmarkEncryptionKey.Leave += new System.EventHandler(this.TextBoxBookmarkEncryptionKey_Leave);
            // 
            // textBoxBookmarkProposedNote
            // 
            this.textBoxBookmarkProposedNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxBookmarkProposedNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBookmarkProposedNote.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBookmarkProposedNote.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBookmarkProposedNote.Location = new System.Drawing.Point(9, 30);
            this.textBoxBookmarkProposedNote.MaxLength = 165;
            this.textBoxBookmarkProposedNote.Name = "textBoxBookmarkProposedNote";
            this.textBoxBookmarkProposedNote.Size = new System.Drawing.Size(252, 25);
            this.textBoxBookmarkProposedNote.TabIndex = 215;
            this.textBoxBookmarkProposedNote.TabStop = false;
            this.textBoxBookmarkProposedNote.Text = "optional notes";
            this.textBoxBookmarkProposedNote.TextChanged += new System.EventHandler(this.TextBoxBookmarkProposedNote_TextChanged);
            this.textBoxBookmarkProposedNote.Enter += new System.EventHandler(this.TextBoxBookmarkProposedNote_Enter);
            this.textBoxBookmarkProposedNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxBookmarkProposedNote_KeyPress);
            this.textBoxBookmarkProposedNote.Leave += new System.EventHandler(this.TextBoxBookmarkProposedNote_Leave);
            // 
            // btnCancelAddToBookmarks
            // 
            this.btnCancelAddToBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnCancelAddToBookmarks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnCancelAddToBookmarks.FlatAppearance.BorderSize = 0;
            this.btnCancelAddToBookmarks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCancelAddToBookmarks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCancelAddToBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAddToBookmarks.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddToBookmarks.ForeColor = System.Drawing.Color.White;
            this.btnCancelAddToBookmarks.Location = new System.Drawing.Point(172, 94);
            this.btnCancelAddToBookmarks.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelAddToBookmarks.Name = "btnCancelAddToBookmarks";
            this.btnCancelAddToBookmarks.Size = new System.Drawing.Size(88, 22);
            this.btnCancelAddToBookmarks.TabIndex = 158;
            this.btnCancelAddToBookmarks.TabStop = false;
            this.btnCancelAddToBookmarks.Text = "✖️ cancel";
            this.btnCancelAddToBookmarks.UseVisualStyleBackColor = false;
            this.btnCancelAddToBookmarks.Click += new System.EventHandler(this.BtnCancelAddToBookmarks_Click);
            // 
            // btnCommitToBookmarks
            // 
            this.btnCommitToBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnCommitToBookmarks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnCommitToBookmarks.FlatAppearance.BorderSize = 0;
            this.btnCommitToBookmarks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCommitToBookmarks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCommitToBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommitToBookmarks.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommitToBookmarks.ForeColor = System.Drawing.Color.White;
            this.btnCommitToBookmarks.Location = new System.Drawing.Point(79, 94);
            this.btnCommitToBookmarks.Margin = new System.Windows.Forms.Padding(1);
            this.btnCommitToBookmarks.Name = "btnCommitToBookmarks";
            this.btnCommitToBookmarks.Size = new System.Drawing.Size(88, 22);
            this.btnCommitToBookmarks.TabIndex = 157;
            this.btnCommitToBookmarks.TabStop = false;
            this.btnCommitToBookmarks.Text = "➕ add";
            this.btnCommitToBookmarks.UseVisualStyleBackColor = false;
            this.btnCommitToBookmarks.Click += new System.EventHandler(this.BtnCommitToBookmarks_Click);
            // 
            // panelFees
            // 
            this.panelFees.BackColor = System.Drawing.Color.Transparent;
            this.panelFees.Controls.Add(this.pictureBoxHeaderFeeRatesChart);
            this.panelFees.Controls.Add(this.pictureBoxHeaderHashrateChart);
            this.panelFees.Controls.Add(this.lblHeaderHashrate);
            this.panelFees.Controls.Add(this.panel57);
            this.panelFees.Controls.Add(this.panel40);
            this.panelFees.Controls.Add(this.label29);
            this.panelFees.Controls.Add(this.label28);
            this.panelFees.Controls.Add(this.label25);
            this.panelFees.Controls.Add(this.label15);
            this.panelFees.Controls.Add(this.lblFeesNoPriority);
            this.panelFees.Controls.Add(this.lblFeesLowPriority);
            this.panelFees.Controls.Add(this.lblfeesHighPriority);
            this.panelFees.Controls.Add(this.lblFeesMediumPriority);
            this.panelFees.Location = new System.Drawing.Point(501, 40);
            this.panelFees.Name = "panelFees";
            this.panelFees.Size = new System.Drawing.Size(280, 114);
            this.panelFees.TabIndex = 202;
            // 
            // lblHeaderHashrate
            // 
            this.lblHeaderHashrate.AutoSize = true;
            this.lblHeaderHashrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderHashrate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderHashrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblHeaderHashrate.Location = new System.Drawing.Point(2, 85);
            this.lblHeaderHashrate.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeaderHashrate.Name = "lblHeaderHashrate";
            this.lblHeaderHashrate.Size = new System.Drawing.Size(67, 20);
            this.lblHeaderHashrate.TabIndex = 211;
            this.lblHeaderHashrate.Text = "no data";
            // 
            // panel57
            // 
            this.panel57.BackColor = System.Drawing.Color.Transparent;
            this.panel57.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel57.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel57.Controls.Add(this.label150);
            this.panel57.Location = new System.Drawing.Point(0, 60);
            this.panel57.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(202, 23);
            this.panel57.TabIndex = 209;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label150.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.ForeColor = System.Drawing.Color.Gray;
            this.label150.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label150.Location = new System.Drawing.Point(3, 2);
            this.label150.Margin = new System.Windows.Forms.Padding(0);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(171, 20);
            this.label150.TabIndex = 153;
            this.label150.Text = "Hashrate (hashes/sec)";
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.Color.Transparent;
            this.panel40.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel40.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel40.Controls.Add(this.label1);
            this.panel40.Location = new System.Drawing.Point(0, 0);
            this.panel40.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(202, 23);
            this.panel40.TabIndex = 208;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 153;
            this.label1.Text = "On-chain fees (sats/vB)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label29.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Silver;
            this.label29.Location = new System.Drawing.Point(152, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 20);
            this.label29.TabIndex = 83;
            this.label29.Text = "1day";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label28.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Silver;
            this.label28.Location = new System.Drawing.Point(102, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 20);
            this.label28.TabIndex = 82;
            this.label28.Text = "60m";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label25.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Silver;
            this.label25.Location = new System.Drawing.Point(52, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 20);
            this.label25.TabIndex = 81;
            this.label25.Text = "30m";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(2, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 20);
            this.label15.TabIndex = 79;
            this.label15.Text = "10m";
            // 
            // lblFeesNoPriority
            // 
            this.lblFeesNoPriority.AutoSize = true;
            this.lblFeesNoPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFeesNoPriority.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesNoPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblFeesNoPriority.Location = new System.Drawing.Point(160, 41);
            this.lblFeesNoPriority.Name = "lblFeesNoPriority";
            this.lblFeesNoPriority.Size = new System.Drawing.Size(18, 20);
            this.lblFeesNoPriority.TabIndex = 78;
            this.lblFeesNoPriority.Text = "?";
            // 
            // lblFeesLowPriority
            // 
            this.lblFeesLowPriority.AutoSize = true;
            this.lblFeesLowPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFeesLowPriority.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesLowPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblFeesLowPriority.Location = new System.Drawing.Point(106, 41);
            this.lblFeesLowPriority.Name = "lblFeesLowPriority";
            this.lblFeesLowPriority.Size = new System.Drawing.Size(18, 20);
            this.lblFeesLowPriority.TabIndex = 77;
            this.lblFeesLowPriority.Text = "?";
            // 
            // lblfeesHighPriority
            // 
            this.lblfeesHighPriority.AutoSize = true;
            this.lblfeesHighPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblfeesHighPriority.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfeesHighPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblfeesHighPriority.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblfeesHighPriority.Location = new System.Drawing.Point(6, 41);
            this.lblfeesHighPriority.Name = "lblfeesHighPriority";
            this.lblfeesHighPriority.Size = new System.Drawing.Size(18, 20);
            this.lblfeesHighPriority.TabIndex = 76;
            this.lblfeesHighPriority.Text = "?";
            // 
            // lblFeesMediumPriority
            // 
            this.lblFeesMediumPriority.AutoSize = true;
            this.lblFeesMediumPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFeesMediumPriority.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesMediumPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblFeesMediumPriority.Location = new System.Drawing.Point(58, 41);
            this.lblFeesMediumPriority.Name = "lblFeesMediumPriority";
            this.lblFeesMediumPriority.Size = new System.Drawing.Size(18, 20);
            this.lblFeesMediumPriority.TabIndex = 75;
            this.lblFeesMediumPriority.Text = "?";
            // 
            // panelBookmarks
            // 
            this.panelBookmarks.BackColor = System.Drawing.Color.Transparent;
            this.panelBookmarks.Controls.Add(this.panel32);
            this.panelBookmarks.Controls.Add(this.panel33);
            this.panelBookmarks.Controls.Add(this.panelBookmarksContainer);
            this.panelBookmarks.Controls.Add(this.panel36);
            this.panelBookmarks.Location = new System.Drawing.Point(21, 188);
            this.panelBookmarks.Name = "panelBookmarks";
            this.panelBookmarks.Size = new System.Drawing.Size(773, 556);
            this.panelBookmarks.TabIndex = 215;
            this.panelBookmarks.Visible = false;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel32.Controls.Add(this.btnDecryptBookmark);
            this.panel32.Controls.Add(this.lblBookmarkStatusMessage);
            this.panel32.Controls.Add(this.textBoxBookmarkKey);
            this.panel32.Controls.Add(this.btnBookmarkUnlock);
            this.panel32.Controls.Add(this.btnDeleteBookmark);
            this.panel32.Controls.Add(this.btnViewBookmark);
            this.panel32.Controls.Add(this.label138);
            this.panel32.Controls.Add(this.lblBookmarkNoteInFull);
            this.panel32.Controls.Add(this.lblSelectedBookmarkType);
            this.panel32.Controls.Add(this.lblBookmarkDataInFull);
            this.panel32.Location = new System.Drawing.Point(0, 450);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(748, 100);
            this.panel32.TabIndex = 215;
            // 
            // btnDecryptBookmark
            // 
            this.btnDecryptBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnDecryptBookmark.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnDecryptBookmark.FlatAppearance.BorderSize = 0;
            this.btnDecryptBookmark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDecryptBookmark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDecryptBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecryptBookmark.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecryptBookmark.ForeColor = System.Drawing.Color.White;
            this.btnDecryptBookmark.Location = new System.Drawing.Point(362, 69);
            this.btnDecryptBookmark.Margin = new System.Windows.Forms.Padding(1);
            this.btnDecryptBookmark.Name = "btnDecryptBookmark";
            this.btnDecryptBookmark.Size = new System.Drawing.Size(42, 24);
            this.btnDecryptBookmark.TabIndex = 228;
            this.btnDecryptBookmark.Text = "🔓";
            this.btnDecryptBookmark.UseVisualStyleBackColor = false;
            this.btnDecryptBookmark.Visible = false;
            this.btnDecryptBookmark.Click += new System.EventHandler(this.BtnDecryptBookmark_Click);
            // 
            // lblBookmarkStatusMessage
            // 
            this.lblBookmarkStatusMessage.AutoSize = true;
            this.lblBookmarkStatusMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkStatusMessage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkStatusMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.lblBookmarkStatusMessage.Location = new System.Drawing.Point(424, 73);
            this.lblBookmarkStatusMessage.Name = "lblBookmarkStatusMessage";
            this.lblBookmarkStatusMessage.Size = new System.Drawing.Size(145, 20);
            this.lblBookmarkStatusMessage.TabIndex = 217;
            this.lblBookmarkStatusMessage.Text = "bookmark deleted";
            this.lblBookmarkStatusMessage.Visible = false;
            // 
            // textBoxBookmarkKey
            // 
            this.textBoxBookmarkKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxBookmarkKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBookmarkKey.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBookmarkKey.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBookmarkKey.Location = new System.Drawing.Point(105, 69);
            this.textBoxBookmarkKey.MaxLength = 165;
            this.textBoxBookmarkKey.Name = "textBoxBookmarkKey";
            this.textBoxBookmarkKey.Size = new System.Drawing.Size(252, 27);
            this.textBoxBookmarkKey.TabIndex = 217;
            this.textBoxBookmarkKey.Text = "enter key to unlock";
            this.textBoxBookmarkKey.Visible = false;
            this.textBoxBookmarkKey.TextChanged += new System.EventHandler(this.TextBoxBookmarkKey_TextChanged);
            this.textBoxBookmarkKey.Enter += new System.EventHandler(this.TextBoxBookmarkKey_Enter);
            this.textBoxBookmarkKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxBookmarkKey_KeyPress);
            this.textBoxBookmarkKey.Leave += new System.EventHandler(this.TextBoxBookmarkKey_Leave);
            // 
            // btnBookmarkUnlock
            // 
            this.btnBookmarkUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnBookmarkUnlock.Enabled = false;
            this.btnBookmarkUnlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnBookmarkUnlock.FlatAppearance.BorderSize = 0;
            this.btnBookmarkUnlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarkUnlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarkUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookmarkUnlock.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookmarkUnlock.ForeColor = System.Drawing.Color.White;
            this.btnBookmarkUnlock.Location = new System.Drawing.Point(8, 69);
            this.btnBookmarkUnlock.Margin = new System.Windows.Forms.Padding(1);
            this.btnBookmarkUnlock.Name = "btnBookmarkUnlock";
            this.btnBookmarkUnlock.Size = new System.Drawing.Size(88, 24);
            this.btnBookmarkUnlock.TabIndex = 227;
            this.btnBookmarkUnlock.Text = "🔒 unlock";
            this.btnBookmarkUnlock.UseVisualStyleBackColor = false;
            this.btnBookmarkUnlock.Click += new System.EventHandler(this.BtnBookmarkUnlock_Click);
            // 
            // btnDeleteBookmark
            // 
            this.btnDeleteBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnDeleteBookmark.Enabled = false;
            this.btnDeleteBookmark.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnDeleteBookmark.FlatAppearance.BorderSize = 0;
            this.btnDeleteBookmark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDeleteBookmark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDeleteBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBookmark.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBookmark.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBookmark.Location = new System.Drawing.Point(557, 69);
            this.btnDeleteBookmark.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeleteBookmark.Name = "btnDeleteBookmark";
            this.btnDeleteBookmark.Size = new System.Drawing.Size(88, 24);
            this.btnDeleteBookmark.TabIndex = 226;
            this.btnDeleteBookmark.Text = "✖️ delete";
            this.btnDeleteBookmark.UseVisualStyleBackColor = false;
            this.btnDeleteBookmark.Click += new System.EventHandler(this.BtnDeleteBoookmark_Click);
            // 
            // btnViewBookmark
            // 
            this.btnViewBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnViewBookmark.Enabled = false;
            this.btnViewBookmark.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnViewBookmark.FlatAppearance.BorderSize = 0;
            this.btnViewBookmark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewBookmark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnViewBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBookmark.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBookmark.ForeColor = System.Drawing.Color.White;
            this.btnViewBookmark.Location = new System.Drawing.Point(651, 69);
            this.btnViewBookmark.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewBookmark.Name = "btnViewBookmark";
            this.btnViewBookmark.Size = new System.Drawing.Size(88, 24);
            this.btnViewBookmark.TabIndex = 225;
            this.btnViewBookmark.Text = "▶ view";
            this.btnViewBookmark.UseVisualStyleBackColor = false;
            this.btnViewBookmark.Click += new System.EventHandler(this.BtnViewBookmark_Click);
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label138.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.ForeColor = System.Drawing.Color.Silver;
            this.label138.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label138.Location = new System.Drawing.Point(2, 24);
            this.label138.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(43, 20);
            this.label138.TabIndex = 224;
            this.label138.Text = "note";
            // 
            // lblBookmarkNoteInFull
            // 
            this.lblBookmarkNoteInFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkNoteInFull.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkNoteInFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBookmarkNoteInFull.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblBookmarkNoteInFull.Location = new System.Drawing.Point(42, 24);
            this.lblBookmarkNoteInFull.Name = "lblBookmarkNoteInFull";
            this.lblBookmarkNoteInFull.Size = new System.Drawing.Size(708, 46);
            this.lblBookmarkNoteInFull.TabIndex = 223;
            this.lblBookmarkNoteInFull.Text = "123451234567890abcdefghijklmnopqrstuvwxyabcdefghijklmnopqrstuvwxyabcdefghijklmnop" +
    "qrstuvwxyabcdefghijklmnopqrstuvwxyabcdefghijklmnopqrstuvwxyabcdefghijklmnopqrstu" +
    "vwxy";
            // 
            // lblSelectedBookmarkType
            // 
            this.lblSelectedBookmarkType.AutoSize = true;
            this.lblSelectedBookmarkType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSelectedBookmarkType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedBookmarkType.ForeColor = System.Drawing.Color.Silver;
            this.lblSelectedBookmarkType.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSelectedBookmarkType.Location = new System.Drawing.Point(2, 4);
            this.lblSelectedBookmarkType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSelectedBookmarkType.Name = "lblSelectedBookmarkType";
            this.lblSelectedBookmarkType.Size = new System.Drawing.Size(42, 20);
            this.lblSelectedBookmarkType.TabIndex = 221;
            this.lblSelectedBookmarkType.Text = "Type";
            // 
            // lblBookmarkDataInFull
            // 
            this.lblBookmarkDataInFull.AutoSize = true;
            this.lblBookmarkDataInFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkDataInFull.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkDataInFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBookmarkDataInFull.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblBookmarkDataInFull.Location = new System.Drawing.Point(42, 5);
            this.lblBookmarkDataInFull.Name = "lblBookmarkDataInFull";
            this.lblBookmarkDataInFull.Size = new System.Drawing.Size(17, 20);
            this.lblBookmarkDataInFull.TabIndex = 222;
            this.lblBookmarkDataInFull.Text = "0";
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel33.Controls.Add(this.btnBookmarksListDown);
            this.panel33.Controls.Add(this.btnBookmarksListUp);
            this.panel33.Location = new System.Drawing.Point(712, 27);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(36, 419);
            this.panel33.TabIndex = 214;
            // 
            // btnBookmarksListDown
            // 
            this.btnBookmarksListDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnBookmarksListDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnBookmarksListDown.FlatAppearance.BorderSize = 0;
            this.btnBookmarksListDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarksListDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarksListDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookmarksListDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookmarksListDown.ForeColor = System.Drawing.Color.White;
            this.btnBookmarksListDown.Location = new System.Drawing.Point(10, 393);
            this.btnBookmarksListDown.Name = "btnBookmarksListDown";
            this.btnBookmarksListDown.Size = new System.Drawing.Size(24, 24);
            this.btnBookmarksListDown.TabIndex = 212;
            this.btnBookmarksListDown.TabStop = false;
            this.btnBookmarksListDown.Text = "▼";
            this.btnBookmarksListDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBookmarksListDown.UseVisualStyleBackColor = false;
            this.btnBookmarksListDown.Click += new System.EventHandler(this.BtnBookmarksListDown_Click);
            this.btnBookmarksListDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnBookmarksListDown_MouseDown);
            this.btnBookmarksListDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnBookmarksListDown_MouseUp);
            // 
            // btnBookmarksListUp
            // 
            this.btnBookmarksListUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnBookmarksListUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnBookmarksListUp.FlatAppearance.BorderSize = 0;
            this.btnBookmarksListUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarksListUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnBookmarksListUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookmarksListUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookmarksListUp.ForeColor = System.Drawing.Color.White;
            this.btnBookmarksListUp.Location = new System.Drawing.Point(10, 9);
            this.btnBookmarksListUp.Name = "btnBookmarksListUp";
            this.btnBookmarksListUp.Size = new System.Drawing.Size(24, 24);
            this.btnBookmarksListUp.TabIndex = 214;
            this.btnBookmarksListUp.TabStop = false;
            this.btnBookmarksListUp.Text = "▲";
            this.btnBookmarksListUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBookmarksListUp.UseVisualStyleBackColor = false;
            this.btnBookmarksListUp.Click += new System.EventHandler(this.BtnBookmarksListUp_Click);
            this.btnBookmarksListUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnBookmarksListUp_MouseDown);
            this.btnBookmarksListUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnBookmarksListUp_MouseUp);
            // 
            // panelBookmarksContainer
            // 
            this.panelBookmarksContainer.AutoScroll = true;
            this.panelBookmarksContainer.Controls.Add(this.listViewBookmarks);
            this.panelBookmarksContainer.Location = new System.Drawing.Point(0, 37);
            this.panelBookmarksContainer.Name = "panelBookmarksContainer";
            this.panelBookmarksContainer.Size = new System.Drawing.Size(747, 408);
            this.panelBookmarksContainer.TabIndex = 213;
            this.panelBookmarksContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBookmarksContainer_Paint);
            // 
            // listViewBookmarks
            // 
            this.listViewBookmarks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listViewBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBookmarks.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBookmarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.listViewBookmarks.FullRowSelect = true;
            this.listViewBookmarks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBookmarks.HideSelection = false;
            this.listViewBookmarks.LabelWrap = false;
            this.listViewBookmarks.Location = new System.Drawing.Point(7, 0);
            this.listViewBookmarks.Margin = new System.Windows.Forms.Padding(0);
            this.listViewBookmarks.MultiSelect = false;
            this.listViewBookmarks.Name = "listViewBookmarks";
            this.listViewBookmarks.OwnerDraw = true;
            this.listViewBookmarks.Scrollable = false;
            this.listViewBookmarks.ShowGroups = false;
            this.listViewBookmarks.Size = new System.Drawing.Size(703, 409);
            this.listViewBookmarks.SmallImageList = this.imageListUpDownArrows;
            this.listViewBookmarks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewBookmarks.TabIndex = 164;
            this.listViewBookmarks.TabStop = false;
            this.listViewBookmarks.UseCompatibleStateImageBehavior = false;
            this.listViewBookmarks.View = System.Windows.Forms.View.Details;
            this.listViewBookmarks.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListViewBookmarks_ColumnWidthChanging);
            this.listViewBookmarks.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AllListViews_DrawColumnHeader);
            this.listViewBookmarks.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewBookmarks_DrawSubItem);
            this.listViewBookmarks.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewBookmarks_ItemSelectionChanged);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.Transparent;
            this.panel36.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel36.Controls.Add(this.lblBookmarkTotalCount);
            this.panel36.Controls.Add(this.label144);
            this.panel36.Controls.Add(this.label153);
            this.panel36.Controls.Add(this.lblBookmarkBlocksCount);
            this.panel36.Controls.Add(this.label151);
            this.panel36.Controls.Add(this.lblBookmarkTransactionsCount);
            this.panel36.Controls.Add(this.label147);
            this.panel36.Controls.Add(this.lblBookmarkAddressCount);
            this.panel36.Controls.Add(this.lblBookmarkXpubsCount);
            this.panel36.Controls.Add(this.label142);
            this.panel36.Location = new System.Drawing.Point(0, 0);
            this.panel36.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(751, 26);
            this.panel36.TabIndex = 199;
            // 
            // lblBookmarkTotalCount
            // 
            this.lblBookmarkTotalCount.AutoSize = true;
            this.lblBookmarkTotalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkTotalCount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBookmarkTotalCount.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblBookmarkTotalCount.Location = new System.Drawing.Point(3, 2);
            this.lblBookmarkTotalCount.Name = "lblBookmarkTotalCount";
            this.lblBookmarkTotalCount.Size = new System.Drawing.Size(17, 20);
            this.lblBookmarkTotalCount.TabIndex = 214;
            this.lblBookmarkTotalCount.Text = "0";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label144.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.ForeColor = System.Drawing.Color.Silver;
            this.label144.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label144.Location = new System.Drawing.Point(3, 2);
            this.label144.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(89, 20);
            this.label144.TabIndex = 153;
            this.label144.Text = "bookmarks";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label153.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label153.ForeColor = System.Drawing.Color.Silver;
            this.label153.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label153.Location = new System.Drawing.Point(455, 3);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(70, 17);
            this.label153.TabIndex = 153;
            this.label153.Text = "Addresses";
            // 
            // lblBookmarkBlocksCount
            // 
            this.lblBookmarkBlocksCount.AutoSize = true;
            this.lblBookmarkBlocksCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkBlocksCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkBlocksCount.Location = new System.Drawing.Point(529, 2);
            this.lblBookmarkBlocksCount.Name = "lblBookmarkBlocksCount";
            this.lblBookmarkBlocksCount.Size = new System.Drawing.Size(16, 18);
            this.lblBookmarkBlocksCount.TabIndex = 213;
            this.lblBookmarkBlocksCount.Text = "0";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label151.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label151.ForeColor = System.Drawing.Color.Silver;
            this.label151.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label151.Location = new System.Drawing.Point(546, 3);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(47, 17);
            this.label151.TabIndex = 167;
            this.label151.Text = "Blocks";
            // 
            // lblBookmarkTransactionsCount
            // 
            this.lblBookmarkTransactionsCount.AutoSize = true;
            this.lblBookmarkTransactionsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkTransactionsCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkTransactionsCount.Location = new System.Drawing.Point(593, 2);
            this.lblBookmarkTransactionsCount.Name = "lblBookmarkTransactionsCount";
            this.lblBookmarkTransactionsCount.Size = new System.Drawing.Size(16, 18);
            this.lblBookmarkTransactionsCount.TabIndex = 212;
            this.lblBookmarkTransactionsCount.Text = "0";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label147.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label147.ForeColor = System.Drawing.Color.Silver;
            this.label147.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label147.Location = new System.Drawing.Point(608, 4);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(86, 17);
            this.label147.TabIndex = 200;
            this.label147.Text = "Transactions";
            // 
            // lblBookmarkAddressCount
            // 
            this.lblBookmarkAddressCount.AutoSize = true;
            this.lblBookmarkAddressCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkAddressCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkAddressCount.Location = new System.Drawing.Point(441, 3);
            this.lblBookmarkAddressCount.Name = "lblBookmarkAddressCount";
            this.lblBookmarkAddressCount.Size = new System.Drawing.Size(16, 18);
            this.lblBookmarkAddressCount.TabIndex = 211;
            this.lblBookmarkAddressCount.Text = "0";
            // 
            // lblBookmarkXpubsCount
            // 
            this.lblBookmarkXpubsCount.AutoSize = true;
            this.lblBookmarkXpubsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookmarkXpubsCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarkXpubsCount.Location = new System.Drawing.Point(691, 2);
            this.lblBookmarkXpubsCount.Name = "lblBookmarkXpubsCount";
            this.lblBookmarkXpubsCount.Size = new System.Drawing.Size(16, 18);
            this.lblBookmarkXpubsCount.TabIndex = 202;
            this.lblBookmarkXpubsCount.Text = "0";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label142.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label142.ForeColor = System.Drawing.Color.Silver;
            this.label142.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label142.Location = new System.Drawing.Point(702, 4);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(47, 17);
            this.label142.TabIndex = 203;
            this.label142.Text = "Xpubs";
            // 
            // BookmarksScrollTimer
            // 
            this.BookmarksScrollTimer.Interval = 50;
            this.BookmarksScrollTimer.Tick += new System.EventHandler(this.BookmarksScrollTimer_Tick);
            // 
            // panelHeaderPrice
            // 
            this.panelHeaderPrice.BackColor = System.Drawing.Color.Transparent;
            this.panelHeaderPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeaderPrice.Controls.Add(this.pictureBoxHeaderPriceChart);
            this.panelHeaderPrice.Controls.Add(this.lblHeaderMoscowTimeLabel);
            this.panelHeaderPrice.Controls.Add(this.lblHeaderMarketCap);
            this.panelHeaderPrice.Controls.Add(this.label77);
            this.panelHeaderPrice.Controls.Add(this.lblHeaderMoscowTime);
            this.panelHeaderPrice.Controls.Add(this.panel38);
            this.panelHeaderPrice.Controls.Add(this.lblHeaderPrice);
            this.panelHeaderPrice.Location = new System.Drawing.Point(21, 40);
            this.panelHeaderPrice.Name = "panelHeaderPrice";
            this.panelHeaderPrice.Size = new System.Drawing.Size(202, 114);
            this.panelHeaderPrice.TabIndex = 216;
            // 
            // lblHeaderMoscowTimeLabel
            // 
            this.lblHeaderMoscowTimeLabel.AutoSize = true;
            this.lblHeaderMoscowTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderMoscowTimeLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderMoscowTimeLabel.ForeColor = System.Drawing.Color.Silver;
            this.lblHeaderMoscowTimeLabel.Location = new System.Drawing.Point(6, 85);
            this.lblHeaderMoscowTimeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeaderMoscowTimeLabel.Name = "lblHeaderMoscowTimeLabel";
            this.lblHeaderMoscowTimeLabel.Size = new System.Drawing.Size(67, 20);
            this.lblHeaderMoscowTimeLabel.TabIndex = 212;
            this.lblHeaderMoscowTimeLabel.Text = "1$ / sats";
            // 
            // lblHeaderMarketCap
            // 
            this.lblHeaderMarketCap.AutoSize = true;
            this.lblHeaderMarketCap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderMarketCap.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderMarketCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblHeaderMarketCap.Location = new System.Drawing.Point(84, 66);
            this.lblHeaderMarketCap.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeaderMarketCap.Name = "lblHeaderMarketCap";
            this.lblHeaderMarketCap.Size = new System.Drawing.Size(25, 20);
            this.lblHeaderMarketCap.TabIndex = 209;
            this.lblHeaderMarketCap.Text = "$0";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label77.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.Silver;
            this.label77.Location = new System.Drawing.Point(6, 66);
            this.label77.Margin = new System.Windows.Forms.Padding(0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(100, 20);
            this.label77.TabIndex = 211;
            this.label77.Text = "Market cap.";
            // 
            // lblHeaderMoscowTime
            // 
            this.lblHeaderMoscowTime.AutoSize = true;
            this.lblHeaderMoscowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderMoscowTime.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderMoscowTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblHeaderMoscowTime.Location = new System.Drawing.Point(75, 85);
            this.lblHeaderMoscowTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeaderMoscowTime.Name = "lblHeaderMoscowTime";
            this.lblHeaderMoscowTime.Size = new System.Drawing.Size(25, 20);
            this.lblHeaderMoscowTime.TabIndex = 210;
            this.lblHeaderMoscowTime.Text = "$0";
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.Transparent;
            this.panel38.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel38.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel38.Controls.Add(this.label26);
            this.panel38.Location = new System.Drawing.Point(0, 0);
            this.panel38.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(202, 23);
            this.panel38.TabIndex = 207;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label26.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label26.Location = new System.Drawing.Point(3, 2);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 20);
            this.label26.TabIndex = 153;
            this.label26.Text = "Price";
            // 
            // hideAddToBookmarksTimer
            // 
            this.hideAddToBookmarksTimer.Interval = 2000;
            this.hideAddToBookmarksTimer.Tick += new System.EventHandler(this.HideAddToBookmarks_Tick);
            // 
            // hideBookmarkStatusMessageTimer
            // 
            this.hideBookmarkStatusMessageTimer.Interval = 2000;
            this.hideBookmarkStatusMessageTimer.Tick += new System.EventHandler(this.HideDeletedBookmarkMessageTimer_Tick);
            // 
            // lblNowViewing
            // 
            this.lblNowViewing.AutoSize = true;
            this.lblNowViewing.BackColor = System.Drawing.Color.Transparent;
            this.lblNowViewing.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowViewing.ForeColor = System.Drawing.Color.Silver;
            this.lblNowViewing.Location = new System.Drawing.Point(21, 159);
            this.lblNowViewing.Name = "lblNowViewing";
            this.lblNowViewing.Size = new System.Drawing.Size(125, 19);
            this.lblNowViewing.TabIndex = 217;
            this.lblNowViewing.Text = "- now viewing";
            // 
            // panelHeaderBlockHeight
            // 
            this.panelHeaderBlockHeight.BackColor = System.Drawing.Color.Transparent;
            this.panelHeaderBlockHeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeaderBlockHeight.Controls.Add(this.lblTransactions);
            this.panelHeaderBlockHeight.Controls.Add(this.label148);
            this.panelHeaderBlockHeight.Controls.Add(this.label149);
            this.panelHeaderBlockHeight.Controls.Add(this.panel39);
            this.panelHeaderBlockHeight.Controls.Add(this.lblBlockNumber);
            this.panelHeaderBlockHeight.Controls.Add(this.lblBlockSize);
            this.panelHeaderBlockHeight.Location = new System.Drawing.Point(261, 40);
            this.panelHeaderBlockHeight.Name = "panelHeaderBlockHeight";
            this.panelHeaderBlockHeight.Size = new System.Drawing.Size(202, 114);
            this.panelHeaderBlockHeight.TabIndex = 217;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label148.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.ForeColor = System.Drawing.Color.Silver;
            this.label148.Location = new System.Drawing.Point(6, 66);
            this.label148.Margin = new System.Windows.Forms.Padding(0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(97, 20);
            this.label148.TabIndex = 209;
            this.label148.Text = "Transactions";
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label149.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.ForeColor = System.Drawing.Color.Silver;
            this.label149.Location = new System.Drawing.Point(6, 85);
            this.label149.Margin = new System.Windows.Forms.Padding(0);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(78, 20);
            this.label149.TabIndex = 210;
            this.label149.Text = "Block size";
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.Color.Transparent;
            this.panel39.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel39.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel39.Controls.Add(this.label22);
            this.panel39.Location = new System.Drawing.Point(0, 0);
            this.panel39.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(202, 23);
            this.panel39.TabIndex = 208;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label22.Location = new System.Drawing.Point(3, 2);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(159, 20);
            this.label22.TabIndex = 153;
            this.label22.Text = "Current block height";
            // 
            // panelCurrency
            // 
            this.panelCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.panelCurrency.Controls.Add(this.btnXAU);
            this.panelCurrency.Controls.Add(this.btnUSD);
            this.panelCurrency.Controls.Add(this.btnCurrency);
            this.panelCurrency.Controls.Add(this.btnEUR);
            this.panelCurrency.Controls.Add(this.btnGBP);
            this.panelCurrency.Location = new System.Drawing.Point(456, 11);
            this.panelCurrency.Name = "panelCurrency";
            this.panelCurrency.Size = new System.Drawing.Size(96, 24);
            this.panelCurrency.TabIndex = 159;
            // 
            // btnXAU
            // 
            this.btnXAU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXAU.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnXAU.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnXAU.FlatAppearance.BorderSize = 0;
            this.btnXAU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXAU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnXAU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXAU.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXAU.ForeColor = System.Drawing.Color.White;
            this.btnXAU.Location = new System.Drawing.Point(0, 96);
            this.btnXAU.Margin = new System.Windows.Forms.Padding(0);
            this.btnXAU.Name = "btnXAU";
            this.btnXAU.Size = new System.Drawing.Size(96, 24);
            this.btnXAU.TabIndex = 155;
            this.btnXAU.TabStop = false;
            this.btnXAU.Text = "XAU🪙";
            this.btnXAU.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXAU.UseVisualStyleBackColor = false;
            this.btnXAU.Click += new System.EventHandler(this.BtnXAU_Click);
            // 
            // btnUSD
            // 
            this.btnUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUSD.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUSD.Enabled = false;
            this.btnUSD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnUSD.FlatAppearance.BorderSize = 0;
            this.btnUSD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnUSD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnUSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUSD.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUSD.ForeColor = System.Drawing.Color.White;
            this.btnUSD.Location = new System.Drawing.Point(0, 24);
            this.btnUSD.Margin = new System.Windows.Forms.Padding(0);
            this.btnUSD.Name = "btnUSD";
            this.btnUSD.Size = new System.Drawing.Size(96, 24);
            this.btnUSD.TabIndex = 154;
            this.btnUSD.TabStop = false;
            this.btnUSD.Text = "USD $";
            this.btnUSD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUSD.UseVisualStyleBackColor = false;
            this.btnUSD.Click += new System.EventHandler(this.BtnUSD_Click);
            // 
            // btnCurrency
            // 
            this.btnCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnCurrency.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCurrency.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnCurrency.FlatAppearance.BorderSize = 0;
            this.btnCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrency.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrency.ForeColor = System.Drawing.Color.White;
            this.btnCurrency.Location = new System.Drawing.Point(0, 0);
            this.btnCurrency.Margin = new System.Windows.Forms.Padding(0);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(96, 24);
            this.btnCurrency.TabIndex = 1;
            this.btnCurrency.TabStop = false;
            this.btnCurrency.Text = "CURRENCY";
            this.btnCurrency.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCurrency.UseVisualStyleBackColor = false;
            this.btnCurrency.Click += new System.EventHandler(this.BtnCurrency_Click);
            // 
            // btnEUR
            // 
            this.btnEUR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEUR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEUR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnEUR.FlatAppearance.BorderSize = 0;
            this.btnEUR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnEUR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnEUR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEUR.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEUR.ForeColor = System.Drawing.Color.White;
            this.btnEUR.Location = new System.Drawing.Point(0, 48);
            this.btnEUR.Margin = new System.Windows.Forms.Padding(0);
            this.btnEUR.Name = "btnEUR";
            this.btnEUR.Size = new System.Drawing.Size(96, 24);
            this.btnEUR.TabIndex = 150;
            this.btnEUR.TabStop = false;
            this.btnEUR.Text = "EUR €";
            this.btnEUR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEUR.UseVisualStyleBackColor = false;
            this.btnEUR.Click += new System.EventHandler(this.BtnEUR_Click);
            // 
            // btnGBP
            // 
            this.btnGBP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGBP.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGBP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnGBP.FlatAppearance.BorderSize = 0;
            this.btnGBP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnGBP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnGBP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGBP.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGBP.ForeColor = System.Drawing.Color.White;
            this.btnGBP.Location = new System.Drawing.Point(0, 72);
            this.btnGBP.Margin = new System.Windows.Forms.Padding(0);
            this.btnGBP.Name = "btnGBP";
            this.btnGBP.Size = new System.Drawing.Size(96, 24);
            this.btnGBP.TabIndex = 92;
            this.btnGBP.TabStop = false;
            this.btnGBP.Text = "GBP £";
            this.btnGBP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGBP.UseVisualStyleBackColor = false;
            this.btnGBP.Click += new System.EventHandler(this.BtnGBP_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(21, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 2);
            this.pictureBox1.TabIndex = 218;
            this.pictureBox1.TabStop = false;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.Controls.Add(this.panel77);
            this.panelSettings.Controls.Add(this.panel76);
            this.panelSettings.Controls.Add(this.panel74);
            this.panelSettings.Controls.Add(this.panel75);
            this.panelSettings.Controls.Add(this.lblSettingsCustomNodeStatus);
            this.panelSettings.Controls.Add(this.lblSettingsCustomNodeStatusLight);
            this.panelSettings.Controls.Add(this.panel34);
            this.panelSettings.Controls.Add(this.label158);
            this.panelSettings.Controls.Add(this.panel22);
            this.panelSettings.Controls.Add(this.label159);
            this.panelSettings.Controls.Add(this.lblSettingsXpubNodeStatusLight);
            this.panelSettings.Controls.Add(this.lblSettingsXpubNodeStatus);
            this.panelSettings.Controls.Add(this.label165);
            this.panelSettings.Controls.Add(this.panel37);
            this.panelSettings.Location = new System.Drawing.Point(21, 188);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(773, 556);
            this.panelSettings.TabIndex = 237;
            this.panelSettings.Visible = false;
            // 
            // panel77
            // 
            this.panel77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel77.Controls.Add(this.lblBitcoinDashboard);
            this.panel77.Controls.Add(this.numericUpDownDashboardRefresh);
            this.panel77.Controls.Add(this.label6);
            this.panel77.Controls.Add(this.lblWhatever);
            this.panel77.Controls.Add(this.label198);
            this.panel77.Controls.Add(this.lblBitcoinExplorerEndpoints);
            this.panel77.Controls.Add(this.label4);
            this.panel77.Controls.Add(this.label152);
            this.panel77.Controls.Add(this.lblLightningDashboard);
            this.panel77.Controls.Add(this.lblBlockchainInfoEndpoints);
            this.panel77.Controls.Add(this.lblBlockchairComJSON);
            this.panel77.Controls.Add(this.label169);
            this.panel77.Controls.Add(this.label167);
            this.panel77.Controls.Add(this.label171);
            this.panel77.Controls.Add(this.lblMempoolLightningJSON);
            this.panel77.Location = new System.Drawing.Point(0, 443);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(755, 91);
            this.panel77.TabIndex = 244;
            // 
            // lblBitcoinDashboard
            // 
            this.lblBitcoinDashboard.AutoSize = true;
            this.lblBitcoinDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitcoinDashboard.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBitcoinDashboard.ForeColor = System.Drawing.Color.Green;
            this.lblBitcoinDashboard.Location = new System.Drawing.Point(6, 7);
            this.lblBitcoinDashboard.Name = "lblBitcoinDashboard";
            this.lblBitcoinDashboard.Size = new System.Drawing.Size(23, 18);
            this.lblBitcoinDashboard.TabIndex = 225;
            this.lblBitcoinDashboard.Text = "✔️";
            this.lblBitcoinDashboard.Click += new System.EventHandler(this.LblBitcoinDashboard_Click);
            // 
            // numericUpDownDashboardRefresh
            // 
            this.numericUpDownDashboardRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownDashboardRefresh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownDashboardRefresh.Font = new System.Drawing.Font("Consolas", 9F);
            this.numericUpDownDashboardRefresh.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownDashboardRefresh.Location = new System.Drawing.Point(689, 9);
            this.numericUpDownDashboardRefresh.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownDashboardRefresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDashboardRefresh.Name = "numericUpDownDashboardRefresh";
            this.numericUpDownDashboardRefresh.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownDashboardRefresh.TabIndex = 47;
            this.numericUpDownDashboardRefresh.TabStop = false;
            this.numericUpDownDashboardRefresh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDashboardRefresh.ValueChanged += new System.EventHandler(this.NumericUpDownDashboardRefresh_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(542, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Refresh frequency";
            // 
            // lblWhatever
            // 
            this.lblWhatever.AutoSize = true;
            this.lblWhatever.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhatever.ForeColor = System.Drawing.Color.Silver;
            this.lblWhatever.Location = new System.Drawing.Point(54, 48);
            this.lblWhatever.Name = "lblWhatever";
            this.lblWhatever.Size = new System.Drawing.Size(177, 20);
            this.lblWhatever.TabIndex = 41;
            this.lblWhatever.Text = "bitcoinexplorer.org API";
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label198.ForeColor = System.Drawing.Color.Silver;
            this.label198.Location = new System.Drawing.Point(542, 28);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(107, 20);
            this.label198.TabIndex = 240;
            this.label198.Text = "(1 - 1440 mins)";
            // 
            // lblBitcoinExplorerEndpoints
            // 
            this.lblBitcoinExplorerEndpoints.AutoSize = true;
            this.lblBitcoinExplorerEndpoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitcoinExplorerEndpoints.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBitcoinExplorerEndpoints.ForeColor = System.Drawing.Color.Green;
            this.lblBitcoinExplorerEndpoints.Location = new System.Drawing.Point(32, 47);
            this.lblBitcoinExplorerEndpoints.Name = "lblBitcoinExplorerEndpoints";
            this.lblBitcoinExplorerEndpoints.Size = new System.Drawing.Size(23, 18);
            this.lblBitcoinExplorerEndpoints.TabIndex = 42;
            this.lblBitcoinExplorerEndpoints.Text = "✔️";
            this.lblBitcoinExplorerEndpoints.Click += new System.EventHandler(this.LblBitcoinExplorerEndpoints_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(54, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "blockchair.com API";
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.ForeColor = System.Drawing.Color.Silver;
            this.label152.Location = new System.Drawing.Point(54, 68);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(151, 20);
            this.label152.TabIndex = 43;
            this.label152.Text = "blockchain.info API";
            // 
            // lblLightningDashboard
            // 
            this.lblLightningDashboard.AutoSize = true;
            this.lblLightningDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLightningDashboard.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLightningDashboard.ForeColor = System.Drawing.Color.Green;
            this.lblLightningDashboard.Location = new System.Drawing.Point(285, 7);
            this.lblLightningDashboard.Name = "lblLightningDashboard";
            this.lblLightningDashboard.Size = new System.Drawing.Size(23, 18);
            this.lblLightningDashboard.TabIndex = 229;
            this.lblLightningDashboard.Text = "✔️";
            this.lblLightningDashboard.Click += new System.EventHandler(this.LblLightningDashboard_Click);
            // 
            // lblBlockchainInfoEndpoints
            // 
            this.lblBlockchainInfoEndpoints.AutoSize = true;
            this.lblBlockchainInfoEndpoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchainInfoEndpoints.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchainInfoEndpoints.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchainInfoEndpoints.Location = new System.Drawing.Point(32, 67);
            this.lblBlockchainInfoEndpoints.Name = "lblBlockchainInfoEndpoints";
            this.lblBlockchainInfoEndpoints.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchainInfoEndpoints.TabIndex = 44;
            this.lblBlockchainInfoEndpoints.Text = "✔️";
            this.lblBlockchainInfoEndpoints.Click += new System.EventHandler(this.LblBlockchainInfoEndpoints_Click);
            // 
            // lblBlockchairComJSON
            // 
            this.lblBlockchairComJSON.AutoSize = true;
            this.lblBlockchairComJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBlockchairComJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBlockchairComJSON.ForeColor = System.Drawing.Color.Green;
            this.lblBlockchairComJSON.Location = new System.Drawing.Point(32, 27);
            this.lblBlockchairComJSON.Name = "lblBlockchairComJSON";
            this.lblBlockchairComJSON.Size = new System.Drawing.Size(23, 18);
            this.lblBlockchairComJSON.TabIndex = 52;
            this.lblBlockchairComJSON.Text = "✔️";
            this.lblBlockchairComJSON.Click += new System.EventHandler(this.LblBlockchairComJSON_Click);
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.ForeColor = System.Drawing.Color.Silver;
            this.label169.Location = new System.Drawing.Point(307, 8);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(208, 20);
            this.label169.TabIndex = 228;
            this.label169.Text = "Enable lightning dashboard";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.ForeColor = System.Drawing.Color.Silver;
            this.label167.Location = new System.Drawing.Point(28, 8);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(197, 20);
            this.label167.TabIndex = 224;
            this.label167.Text = "Enable bitcoin dashboard";
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label171.ForeColor = System.Drawing.Color.Silver;
            this.label171.Location = new System.Drawing.Point(333, 28);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(157, 20);
            this.label171.TabIndex = 226;
            this.label171.Text = "mempool.space API";
            // 
            // lblMempoolLightningJSON
            // 
            this.lblMempoolLightningJSON.AutoSize = true;
            this.lblMempoolLightningJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMempoolLightningJSON.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblMempoolLightningJSON.ForeColor = System.Drawing.Color.Green;
            this.lblMempoolLightningJSON.Location = new System.Drawing.Point(311, 27);
            this.lblMempoolLightningJSON.Name = "lblMempoolLightningJSON";
            this.lblMempoolLightningJSON.Size = new System.Drawing.Size(23, 18);
            this.lblMempoolLightningJSON.TabIndex = 227;
            this.lblMempoolLightningJSON.Text = "✔️";
            this.lblMempoolLightningJSON.Click += new System.EventHandler(this.LblMempoolLightningJSON_Click);
            // 
            // panel76
            // 
            this.panel76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel76.Controls.Add(this.label201);
            this.panel76.Controls.Add(this.label204);
            this.panel76.Controls.Add(this.textBoxSettingsXpubMempoolURL);
            this.panel76.Location = new System.Drawing.Point(0, 272);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(290, 77);
            this.panel76.TabIndex = 243;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label201.ForeColor = System.Drawing.Color.Gray;
            this.label201.Location = new System.Drawing.Point(5, 3);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(255, 20);
            this.label201.TabIndex = 241;
            this.label201.Text = "mempool.space on own full node";
            // 
            // label204
            // 
            this.label204.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label204.ForeColor = System.Drawing.Color.Gray;
            this.label204.Location = new System.Drawing.Point(7, 56);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(280, 21);
            this.label204.TabIndex = 149;
            this.label204.Text = "Must be in format \"http(s)://xxxxxx.xxx/api/";
            // 
            // textBoxSettingsXpubMempoolURL
            // 
            this.textBoxSettingsXpubMempoolURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSettingsXpubMempoolURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettingsXpubMempoolURL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettingsXpubMempoolURL.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSettingsXpubMempoolURL.Location = new System.Drawing.Point(10, 28);
            this.textBoxSettingsXpubMempoolURL.Name = "textBoxSettingsXpubMempoolURL";
            this.textBoxSettingsXpubMempoolURL.Size = new System.Drawing.Size(213, 25);
            this.textBoxSettingsXpubMempoolURL.TabIndex = 202;
            this.textBoxSettingsXpubMempoolURL.Text = "e.g http://umbrel.local:3006/api/";
            this.textBoxSettingsXpubMempoolURL.TextChanged += new System.EventHandler(this.TextBoxSettingsXpubMempoolURL_TextChanged);
            this.textBoxSettingsXpubMempoolURL.Enter += new System.EventHandler(this.TextBoxSettingsXpubMempoolURL_Enter);
            this.textBoxSettingsXpubMempoolURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSettingsXpubMempoolURL_KeyPress);
            this.textBoxSettingsXpubMempoolURL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSettingsXpubMempoolURL_KeyUp);
            this.textBoxSettingsXpubMempoolURL.Leave += new System.EventHandler(this.TextBoxSettingsXpubMempoolURL_Leave);
            // 
            // panel74
            // 
            this.panel74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel74.Controls.Add(this.label199);
            this.panel74.Controls.Add(this.label157);
            this.panel74.Controls.Add(this.lblSettingsNodeMainnet);
            this.panel74.Controls.Add(this.label172);
            this.panel74.Controls.Add(this.lblSettingsNodeTestnet);
            this.panel74.Location = new System.Drawing.Point(0, 98);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(203, 77);
            this.panel74.TabIndex = 241;
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.ForeColor = System.Drawing.Color.Gray;
            this.label199.Location = new System.Drawing.Point(5, 3);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(128, 20);
            this.label199.TabIndex = 241;
            this.label199.Text = "mempool.space";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.ForeColor = System.Drawing.Color.Silver;
            this.label157.Location = new System.Drawing.Point(36, 30);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(70, 20);
            this.label157.TabIndex = 233;
            this.label157.Text = "Mainnet";
            // 
            // lblSettingsNodeMainnet
            // 
            this.lblSettingsNodeMainnet.AutoSize = true;
            this.lblSettingsNodeMainnet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSettingsNodeMainnet.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSettingsNodeMainnet.ForeColor = System.Drawing.Color.Green;
            this.lblSettingsNodeMainnet.Location = new System.Drawing.Point(15, 29);
            this.lblSettingsNodeMainnet.Name = "lblSettingsNodeMainnet";
            this.lblSettingsNodeMainnet.Size = new System.Drawing.Size(23, 18);
            this.lblSettingsNodeMainnet.TabIndex = 234;
            this.lblSettingsNodeMainnet.Text = "✔️";
            this.lblSettingsNodeMainnet.Click += new System.EventHandler(this.LblSettingsNodeMainnet_Click);
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label172.ForeColor = System.Drawing.Color.Silver;
            this.label172.Location = new System.Drawing.Point(134, 30);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(59, 20);
            this.label172.TabIndex = 235;
            this.label172.Text = "Testnet";
            // 
            // lblSettingsNodeTestnet
            // 
            this.lblSettingsNodeTestnet.AutoSize = true;
            this.lblSettingsNodeTestnet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSettingsNodeTestnet.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSettingsNodeTestnet.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSettingsNodeTestnet.Location = new System.Drawing.Point(112, 29);
            this.lblSettingsNodeTestnet.Name = "lblSettingsNodeTestnet";
            this.lblSettingsNodeTestnet.Size = new System.Drawing.Size(23, 18);
            this.lblSettingsNodeTestnet.TabIndex = 236;
            this.lblSettingsNodeTestnet.Text = "❌";
            this.lblSettingsNodeTestnet.Click += new System.EventHandler(this.LblSettingsNodeTestnet_Click);
            // 
            // panel75
            // 
            this.panel75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel75.Controls.Add(this.label200);
            this.panel75.Controls.Add(this.lblSettingsNodeCustom);
            this.panel75.Controls.Add(this.textBoxSettingsCustomMempoolURL);
            this.panel75.Controls.Add(this.label174);
            this.panel75.Controls.Add(this.lblURLWarning);
            this.panel75.Location = new System.Drawing.Point(210, 98);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(330, 77);
            this.panel75.TabIndex = 242;
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label200.ForeColor = System.Drawing.Color.Gray;
            this.label200.Location = new System.Drawing.Point(5, 3);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(255, 20);
            this.label200.TabIndex = 241;
            this.label200.Text = "mempool.space on own full node";
            // 
            // lblSettingsNodeCustom
            // 
            this.lblSettingsNodeCustom.AutoSize = true;
            this.lblSettingsNodeCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSettingsNodeCustom.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSettingsNodeCustom.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSettingsNodeCustom.Location = new System.Drawing.Point(6, 29);
            this.lblSettingsNodeCustom.Name = "lblSettingsNodeCustom";
            this.lblSettingsNodeCustom.Size = new System.Drawing.Size(23, 18);
            this.lblSettingsNodeCustom.TabIndex = 238;
            this.lblSettingsNodeCustom.Text = "❌";
            this.lblSettingsNodeCustom.Click += new System.EventHandler(this.LblSettingsNodeCustom_Click);
            // 
            // textBoxSettingsCustomMempoolURL
            // 
            this.textBoxSettingsCustomMempoolURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSettingsCustomMempoolURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettingsCustomMempoolURL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettingsCustomMempoolURL.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSettingsCustomMempoolURL.Location = new System.Drawing.Point(91, 25);
            this.textBoxSettingsCustomMempoolURL.Name = "textBoxSettingsCustomMempoolURL";
            this.textBoxSettingsCustomMempoolURL.Size = new System.Drawing.Size(213, 25);
            this.textBoxSettingsCustomMempoolURL.TabIndex = 239;
            this.textBoxSettingsCustomMempoolURL.Text = "e.g http://umbrel.local:3006/api/";
            this.textBoxSettingsCustomMempoolURL.TextChanged += new System.EventHandler(this.TextBoxSettingsCustomMempoolURL_TextChanged);
            this.textBoxSettingsCustomMempoolURL.Enter += new System.EventHandler(this.TextBoxSettingsCustomMempoolURL_Enter);
            this.textBoxSettingsCustomMempoolURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSettingsCustomMempoolURL_KeyPress);
            this.textBoxSettingsCustomMempoolURL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSettingsCustomMempoolURL_KeyUp);
            this.textBoxSettingsCustomMempoolURL.Leave += new System.EventHandler(this.TextBoxSettingsCustomMempoolURL_Leave);
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label174.ForeColor = System.Drawing.Color.Silver;
            this.label174.Location = new System.Drawing.Point(28, 30);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(64, 20);
            this.label174.TabIndex = 237;
            this.label174.Text = "Custom";
            // 
            // lblURLWarning
            // 
            this.lblURLWarning.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURLWarning.ForeColor = System.Drawing.Color.Gray;
            this.lblURLWarning.Location = new System.Drawing.Point(50, 56);
            this.lblURLWarning.Name = "lblURLWarning";
            this.lblURLWarning.Size = new System.Drawing.Size(280, 21);
            this.lblURLWarning.TabIndex = 149;
            this.lblURLWarning.Text = "Must be in format \"http(s)://xxxxxx.xxx/api/";
            // 
            // lblSettingsCustomNodeStatus
            // 
            this.lblSettingsCustomNodeStatus.AutoSize = true;
            this.lblSettingsCustomNodeStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsCustomNodeStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblSettingsCustomNodeStatus.Location = new System.Drawing.Point(585, 127);
            this.lblSettingsCustomNodeStatus.Name = "lblSettingsCustomNodeStatus";
            this.lblSettingsCustomNodeStatus.Size = new System.Drawing.Size(160, 20);
            this.lblSettingsCustomNodeStatus.TabIndex = 232;
            this.lblSettingsCustomNodeStatus.Text = "invalid / node offline";
            // 
            // lblSettingsCustomNodeStatusLight
            // 
            this.lblSettingsCustomNodeStatusLight.AutoSize = true;
            this.lblSettingsCustomNodeStatusLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSettingsCustomNodeStatusLight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsCustomNodeStatusLight.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSettingsCustomNodeStatusLight.Location = new System.Drawing.Point(556, 130);
            this.lblSettingsCustomNodeStatusLight.Name = "lblSettingsCustomNodeStatusLight";
            this.lblSettingsCustomNodeStatusLight.Size = new System.Drawing.Size(23, 18);
            this.lblSettingsCustomNodeStatusLight.TabIndex = 231;
            this.lblSettingsCustomNodeStatusLight.Text = "🟢";
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.Transparent;
            this.panel34.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel34.BackgroundImage")));
            this.panel34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel34.Controls.Add(this.label163);
            this.panel34.Location = new System.Drawing.Point(0, 15);
            this.panel34.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(375, 23);
            this.panel34.TabIndex = 209;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label163.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label163.ForeColor = System.Drawing.Color.Gray;
            this.label163.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label163.Location = new System.Drawing.Point(0, 2);
            this.label163.Margin = new System.Windows.Forms.Padding(0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(294, 20);
            this.label163.TabIndex = 153;
            this.label163.Text = "Network - on-chain queries (exc. Xpub)";
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.ForeColor = System.Drawing.Color.Gray;
            this.label158.Location = new System.Drawing.Point(0, 41);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(760, 64);
            this.label158.TabIndex = 143;
            this.label158.Text = resources.GetString("label158.Text");
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel22.BackgroundImage")));
            this.panel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel22.Controls.Add(this.label162);
            this.panel22.Location = new System.Drawing.Point(0, 190);
            this.panel22.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(375, 23);
            this.panel22.TabIndex = 208;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label162.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label162.ForeColor = System.Drawing.Color.Gray;
            this.label162.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label162.Location = new System.Drawing.Point(0, 2);
            this.label162.Margin = new System.Windows.Forms.Padding(0);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(214, 20);
            this.label162.TabIndex = 153;
            this.label162.Text = "Network - Xpub queries only";
            // 
            // label159
            // 
            this.label159.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label159.ForeColor = System.Drawing.Color.Gray;
            this.label159.Location = new System.Drawing.Point(0, 216);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(760, 62);
            this.label159.TabIndex = 150;
            this.label159.Text = resources.GetString("label159.Text");
            // 
            // lblSettingsXpubNodeStatusLight
            // 
            this.lblSettingsXpubNodeStatusLight.AutoSize = true;
            this.lblSettingsXpubNodeStatusLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSettingsXpubNodeStatusLight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsXpubNodeStatusLight.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSettingsXpubNodeStatusLight.Location = new System.Drawing.Point(305, 304);
            this.lblSettingsXpubNodeStatusLight.Name = "lblSettingsXpubNodeStatusLight";
            this.lblSettingsXpubNodeStatusLight.Size = new System.Drawing.Size(23, 18);
            this.lblSettingsXpubNodeStatusLight.TabIndex = 221;
            this.lblSettingsXpubNodeStatusLight.Text = "🟢";
            // 
            // lblSettingsXpubNodeStatus
            // 
            this.lblSettingsXpubNodeStatus.AutoSize = true;
            this.lblSettingsXpubNodeStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsXpubNodeStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblSettingsXpubNodeStatus.Location = new System.Drawing.Point(326, 301);
            this.lblSettingsXpubNodeStatus.Name = "lblSettingsXpubNodeStatus";
            this.lblSettingsXpubNodeStatus.Size = new System.Drawing.Size(160, 20);
            this.lblSettingsXpubNodeStatus.TabIndex = 222;
            this.lblSettingsXpubNodeStatus.Text = "invalid / node offline";
            // 
            // label165
            // 
            this.label165.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label165.ForeColor = System.Drawing.Color.Gray;
            this.label165.Location = new System.Drawing.Point(0, 386);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(760, 63);
            this.label165.TabIndex = 210;
            this.label165.Text = resources.GetString("label165.Text");
            // 
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.Color.Transparent;
            this.panel37.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel37.BackgroundImage")));
            this.panel37.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel37.Controls.Add(this.label155);
            this.panel37.Location = new System.Drawing.Point(0, 360);
            this.panel37.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(375, 23);
            this.panel37.TabIndex = 211;
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label155.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.ForeColor = System.Drawing.Color.Gray;
            this.label155.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label155.Location = new System.Drawing.Point(0, 2);
            this.label155.Margin = new System.Windows.Forms.Padding(0);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(96, 20);
            this.label155.TabIndex = 153;
            this.label155.Text = "Dashboards";
            // 
            // btnColorLabels
            // 
            this.btnColorLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorLabels.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorLabels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorLabels.FlatAppearance.BorderSize = 0;
            this.btnColorLabels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorLabels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorLabels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorLabels.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorLabels.ForeColor = System.Drawing.Color.White;
            this.btnColorLabels.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorLabels.Location = new System.Drawing.Point(124, 61);
            this.btnColorLabels.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorLabels.Name = "btnColorLabels";
            this.btnColorLabels.Size = new System.Drawing.Size(55, 18);
            this.btnColorLabels.TabIndex = 240;
            this.btnColorLabels.TabStop = false;
            this.btnColorLabels.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorLabels.UseVisualStyleBackColor = false;
            this.btnColorLabels.Click += new System.EventHandler(this.BtnColorLabels_Click);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Silver;
            this.label73.Location = new System.Drawing.Point(0, 61);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(55, 20);
            this.label73.TabIndex = 241;
            this.label73.Text = "Labels";
            // 
            // btnColorDataFields
            // 
            this.btnColorDataFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorDataFields.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorDataFields.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorDataFields.FlatAppearance.BorderSize = 0;
            this.btnColorDataFields.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorDataFields.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorDataFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorDataFields.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDataFields.ForeColor = System.Drawing.Color.White;
            this.btnColorDataFields.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorDataFields.Location = new System.Drawing.Point(124, 36);
            this.btnColorDataFields.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorDataFields.Name = "btnColorDataFields";
            this.btnColorDataFields.Size = new System.Drawing.Size(55, 18);
            this.btnColorDataFields.TabIndex = 156;
            this.btnColorDataFields.TabStop = false;
            this.btnColorDataFields.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorDataFields.UseVisualStyleBackColor = false;
            this.btnColorDataFields.Click += new System.EventHandler(this.BtnColorDataFields_Click);
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.label154.Location = new System.Drawing.Point(0, 36);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(86, 20);
            this.label154.TabIndex = 230;
            this.label154.Text = "Data fields";
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.Color.Transparent;
            this.panel58.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel58.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel58.Controls.Add(this.label5);
            this.panel58.Location = new System.Drawing.Point(0, 0);
            this.panel58.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(224, 23);
            this.panel58.TabIndex = 212;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(0, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 153;
            this.label5.Text = "Text colours";
            // 
            // panel59
            // 
            this.panel59.BackColor = System.Drawing.Color.Transparent;
            this.panel59.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel59.BackgroundImage")));
            this.panel59.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel59.Controls.Add(this.label156);
            this.panel59.Location = new System.Drawing.Point(0, 86);
            this.panel59.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(82, 23);
            this.panel59.TabIndex = 208;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label156.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.ForeColor = System.Drawing.Color.Gray;
            this.label156.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label156.Location = new System.Drawing.Point(3, 2);
            this.label156.Margin = new System.Windows.Forms.Padding(0);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(77, 20);
            this.label156.TabIndex = 153;
            this.label156.Text = "Headings";
            // 
            // btnColorHeadings
            // 
            this.btnColorHeadings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorHeadings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorHeadings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorHeadings.FlatAppearance.BorderSize = 0;
            this.btnColorHeadings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorHeadings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorHeadings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorHeadings.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorHeadings.ForeColor = System.Drawing.Color.White;
            this.btnColorHeadings.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorHeadings.Location = new System.Drawing.Point(124, 86);
            this.btnColorHeadings.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorHeadings.Name = "btnColorHeadings";
            this.btnColorHeadings.Size = new System.Drawing.Size(55, 18);
            this.btnColorHeadings.TabIndex = 242;
            this.btnColorHeadings.TabStop = false;
            this.btnColorHeadings.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorHeadings.UseVisualStyleBackColor = false;
            this.btnColorHeadings.Click += new System.EventHandler(this.BtnColorHeadings_Click);
            // 
            // colorProgressBar1
            // 
            this.colorProgressBar1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.colorProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.colorProgressBar1.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.colorProgressBar1.ForeColor = System.Drawing.Color.Black;
            this.colorProgressBar1.Location = new System.Drawing.Point(0, 429);
            this.colorProgressBar1.Maximum = 100;
            this.colorProgressBar1.Minimum = 0;
            this.colorProgressBar1.Name = "colorProgressBar1";
            this.colorProgressBar1.Size = new System.Drawing.Size(100, 8);
            this.colorProgressBar1.Step = 10;
            this.colorProgressBar1.TabIndex = 243;
            this.colorProgressBar1.Value = 60;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.ForeColor = System.Drawing.Color.Silver;
            this.label161.Location = new System.Drawing.Point(0, 409);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(105, 20);
            this.label161.TabIndex = 244;
            this.label161.Text = "Progress bars";
            // 
            // btnColorProgressBars
            // 
            this.btnColorProgressBars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorProgressBars.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorProgressBars.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorProgressBars.FlatAppearance.BorderSize = 0;
            this.btnColorProgressBars.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorProgressBars.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorProgressBars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorProgressBars.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorProgressBars.ForeColor = System.Drawing.Color.White;
            this.btnColorProgressBars.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorProgressBars.Location = new System.Drawing.Point(124, 409);
            this.btnColorProgressBars.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorProgressBars.Name = "btnColorProgressBars";
            this.btnColorProgressBars.Size = new System.Drawing.Size(55, 18);
            this.btnColorProgressBars.TabIndex = 245;
            this.btnColorProgressBars.TabStop = false;
            this.btnColorProgressBars.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorProgressBars.UseVisualStyleBackColor = false;
            this.btnColorProgressBars.Click += new System.EventHandler(this.BtnColorProgressBars_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 308);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 20);
            this.button1.TabIndex = 160;
            this.button1.TabStop = false;
            this.button1.Text = "Buttons";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnColorButtons
            // 
            this.btnColorButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorButtons.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorButtons.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorButtons.FlatAppearance.BorderSize = 0;
            this.btnColorButtons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorButtons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorButtons.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorButtons.ForeColor = System.Drawing.Color.White;
            this.btnColorButtons.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorButtons.Location = new System.Drawing.Point(124, 308);
            this.btnColorButtons.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorButtons.Name = "btnColorButtons";
            this.btnColorButtons.Size = new System.Drawing.Size(55, 18);
            this.btnColorButtons.TabIndex = 246;
            this.btnColorButtons.TabStop = false;
            this.btnColorButtons.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorButtons.UseVisualStyleBackColor = false;
            this.btnColorButtons.Click += new System.EventHandler(this.BtnColorButtons_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 236);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 20);
            this.button2.TabIndex = 247;
            this.button2.TabStop = false;
            this.button2.Text = "Button text";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnColorButtonText
            // 
            this.btnColorButtonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorButtonText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorButtonText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorButtonText.FlatAppearance.BorderSize = 0;
            this.btnColorButtonText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorButtonText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorButtonText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorButtonText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorButtonText.ForeColor = System.Drawing.Color.White;
            this.btnColorButtonText.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorButtonText.Location = new System.Drawing.Point(124, 236);
            this.btnColorButtonText.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorButtonText.Name = "btnColorButtonText";
            this.btnColorButtonText.Size = new System.Drawing.Size(55, 18);
            this.btnColorButtonText.TabIndex = 248;
            this.btnColorButtonText.TabStop = false;
            this.btnColorButtonText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorButtonText.UseVisualStyleBackColor = false;
            this.btnColorButtonText.Click += new System.EventHandler(this.BtnColorButtonText_Click);
            // 
            // panelAppearance
            // 
            this.panelAppearance.BackColor = System.Drawing.Color.Transparent;
            this.panelAppearance.Controls.Add(this.panel73);
            this.panelAppearance.Controls.Add(this.btnColorPanels);
            this.panelAppearance.Controls.Add(this.panel71);
            this.panelAppearance.Controls.Add(this.panel70);
            this.panelAppearance.Controls.Add(this.lblBackgroundBTCdirSelected);
            this.panelAppearance.Controls.Add(this.lblBackgroundCustomColorSelected);
            this.panelAppearance.Controls.Add(this.lblBackgroundCustomImageSelected);
            this.panelAppearance.Controls.Add(this.lblBackgroundGenesisSelected);
            this.panelAppearance.Controls.Add(this.label191);
            this.panelAppearance.Controls.Add(this.pictureBoxCustomImage);
            this.panelAppearance.Controls.Add(this.panel68);
            this.panelAppearance.Controls.Add(this.btnListViewHeadingColor);
            this.panelAppearance.Controls.Add(this.panel67);
            this.panelAppearance.Controls.Add(this.panel66);
            this.panelAppearance.Controls.Add(this.btnColorTableTitleBar);
            this.panelAppearance.Controls.Add(this.btnColorTableBackground);
            this.panelAppearance.Controls.Add(this.panel65);
            this.panelAppearance.Controls.Add(this.btnColorTitleBackgrounds);
            this.panelAppearance.Controls.Add(this.lblTitleBackgroundCustom);
            this.panelAppearance.Controls.Add(this.label189);
            this.panelAppearance.Controls.Add(this.lblTitleBackgroundNone);
            this.panelAppearance.Controls.Add(this.label187);
            this.panelAppearance.Controls.Add(this.lblTitleBackgroundDefault);
            this.panelAppearance.Controls.Add(this.label185);
            this.panelAppearance.Controls.Add(this.panel64);
            this.panelAppearance.Controls.Add(this.panel63);
            this.panelAppearance.Controls.Add(this.panel62);
            this.panelAppearance.Controls.Add(this.label180);
            this.panelAppearance.Controls.Add(this.label179);
            this.panelAppearance.Controls.Add(this.label177);
            this.panelAppearance.Controls.Add(this.pictureBoxCustomColor);
            this.panelAppearance.Controls.Add(this.pictureBoxBTCDir);
            this.panelAppearance.Controls.Add(this.pictureBoxGenesis);
            this.panelAppearance.Controls.Add(this.lblShowClock);
            this.panelAppearance.Controls.Add(this.label178);
            this.panelAppearance.Controls.Add(this.btnColorStatusError);
            this.panelAppearance.Controls.Add(this.label176);
            this.panelAppearance.Controls.Add(this.btnColorPriceBlock);
            this.panelAppearance.Controls.Add(this.label175);
            this.panelAppearance.Controls.Add(this.btnColorTextBox);
            this.panelAppearance.Controls.Add(this.textBox1);
            this.panelAppearance.Controls.Add(this.btnColorOtherText);
            this.panelAppearance.Controls.Add(this.label173);
            this.panelAppearance.Controls.Add(this.btnColorTableText);
            this.panelAppearance.Controls.Add(this.label170);
            this.panelAppearance.Controls.Add(this.btnColorLines);
            this.panelAppearance.Controls.Add(this.label168);
            this.panelAppearance.Controls.Add(this.panel61);
            this.panelAppearance.Controls.Add(this.panel60);
            this.panelAppearance.Controls.Add(this.btnColorButtonText);
            this.panelAppearance.Controls.Add(this.panel58);
            this.panelAppearance.Controls.Add(this.button2);
            this.panelAppearance.Controls.Add(this.label154);
            this.panelAppearance.Controls.Add(this.btnColorButtons);
            this.panelAppearance.Controls.Add(this.btnColorDataFields);
            this.panelAppearance.Controls.Add(this.button1);
            this.panelAppearance.Controls.Add(this.label73);
            this.panelAppearance.Controls.Add(this.btnColorProgressBars);
            this.panelAppearance.Controls.Add(this.btnColorLabels);
            this.panelAppearance.Controls.Add(this.label161);
            this.panelAppearance.Controls.Add(this.panel59);
            this.panelAppearance.Controls.Add(this.colorProgressBar1);
            this.panelAppearance.Controls.Add(this.btnColorHeadings);
            this.panelAppearance.Location = new System.Drawing.Point(21, 188);
            this.panelAppearance.Name = "panelAppearance";
            this.panelAppearance.Size = new System.Drawing.Size(773, 556);
            this.panelAppearance.TabIndex = 249;
            this.panelAppearance.Visible = false;
            // 
            // panel73
            // 
            this.panel73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel73.Controls.Add(this.label197);
            this.panel73.Location = new System.Drawing.Point(0, 384);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(100, 20);
            this.panel73.TabIndex = 295;
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label197.ForeColor = System.Drawing.Color.Silver;
            this.label197.Location = new System.Drawing.Point(1, 1);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(56, 20);
            this.label197.TabIndex = 245;
            this.label197.Text = "Panels";
            // 
            // btnColorPanels
            // 
            this.btnColorPanels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorPanels.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorPanels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorPanels.FlatAppearance.BorderSize = 0;
            this.btnColorPanels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorPanels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorPanels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorPanels.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorPanels.ForeColor = System.Drawing.Color.White;
            this.btnColorPanels.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorPanels.Location = new System.Drawing.Point(124, 383);
            this.btnColorPanels.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorPanels.Name = "btnColorPanels";
            this.btnColorPanels.Size = new System.Drawing.Size(55, 18);
            this.btnColorPanels.TabIndex = 294;
            this.btnColorPanels.TabStop = false;
            this.btnColorPanels.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorPanels.UseVisualStyleBackColor = false;
            this.btnColorPanels.Click += new System.EventHandler(this.BtnColorPanels_Click);
            // 
            // panel71
            // 
            this.panel71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel71.Controls.Add(this.lblThemeDeleted);
            this.panel71.Controls.Add(this.btnDeleteTheme);
            this.panel71.Controls.Add(this.comboBoxThemeList);
            this.panel71.Controls.Add(this.panel72);
            this.panel71.Controls.Add(this.label196);
            this.panel71.Controls.Add(this.btnLoadTheme);
            this.panel71.Location = new System.Drawing.Point(250, 466);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(505, 80);
            this.panel71.TabIndex = 293;
            // 
            // lblThemeDeleted
            // 
            this.lblThemeDeleted.AutoSize = true;
            this.lblThemeDeleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblThemeDeleted.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemeDeleted.ForeColor = System.Drawing.Color.IndianRed;
            this.lblThemeDeleted.Location = new System.Drawing.Point(403, 4);
            this.lblThemeDeleted.Name = "lblThemeDeleted";
            this.lblThemeDeleted.Size = new System.Drawing.Size(118, 20);
            this.lblThemeDeleted.TabIndex = 288;
            this.lblThemeDeleted.Text = "theme deleted";
            this.lblThemeDeleted.Visible = false;
            // 
            // btnDeleteTheme
            // 
            this.btnDeleteTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnDeleteTheme.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteTheme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnDeleteTheme.FlatAppearance.BorderSize = 0;
            this.btnDeleteTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDeleteTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnDeleteTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTheme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTheme.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTheme.Location = new System.Drawing.Point(407, 40);
            this.btnDeleteTheme.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTheme.Name = "btnDeleteTheme";
            this.btnDeleteTheme.Size = new System.Drawing.Size(91, 24);
            this.btnDeleteTheme.TabIndex = 287;
            this.btnDeleteTheme.TabStop = false;
            this.btnDeleteTheme.Text = "delete";
            this.btnDeleteTheme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteTheme.UseVisualStyleBackColor = false;
            this.btnDeleteTheme.Click += new System.EventHandler(this.BtnDeleteTheme_Click);
            // 
            // comboBoxThemeList
            // 
            this.comboBoxThemeList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxThemeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemeList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxThemeList.ForeColor = System.Drawing.Color.Silver;
            this.comboBoxThemeList.FormattingEnabled = true;
            this.comboBoxThemeList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxThemeList.Location = new System.Drawing.Point(125, 40);
            this.comboBoxThemeList.Name = "comboBoxThemeList";
            this.comboBoxThemeList.Size = new System.Drawing.Size(167, 23);
            this.comboBoxThemeList.TabIndex = 286;
            this.comboBoxThemeList.SelectedValueChanged += new System.EventHandler(this.ComboBoxThemeList_SelectedValueChanged);
            // 
            // panel72
            // 
            this.panel72.BackColor = System.Drawing.Color.Transparent;
            this.panel72.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel72.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel72.Controls.Add(this.label195);
            this.panel72.Location = new System.Drawing.Point(0, 0);
            this.panel72.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(224, 23);
            this.panel72.TabIndex = 215;
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label195.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label195.ForeColor = System.Drawing.Color.Gray;
            this.label195.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label195.Location = new System.Drawing.Point(0, 2);
            this.label195.Margin = new System.Windows.Forms.Padding(0);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(97, 20);
            this.label195.TabIndex = 153;
            this.label195.Text = "Load theme";
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label196.ForeColor = System.Drawing.Color.Silver;
            this.label196.Location = new System.Drawing.Point(7, 40);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(102, 20);
            this.label196.TabIndex = 285;
            this.label196.Text = "Theme name";
            // 
            // btnLoadTheme
            // 
            this.btnLoadTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnLoadTheme.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLoadTheme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnLoadTheme.FlatAppearance.BorderSize = 0;
            this.btnLoadTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnLoadTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnLoadTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTheme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTheme.ForeColor = System.Drawing.Color.White;
            this.btnLoadTheme.Location = new System.Drawing.Point(307, 40);
            this.btnLoadTheme.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadTheme.Name = "btnLoadTheme";
            this.btnLoadTheme.Size = new System.Drawing.Size(91, 24);
            this.btnLoadTheme.TabIndex = 161;
            this.btnLoadTheme.TabStop = false;
            this.btnLoadTheme.Text = "open";
            this.btnLoadTheme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadTheme.UseVisualStyleBackColor = false;
            this.btnLoadTheme.Click += new System.EventHandler(this.BtnLoadTheme_Click);
            // 
            // panel70
            // 
            this.panel70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel70.Controls.Add(this.lblThemeSaved);
            this.panel70.Controls.Add(this.panel69);
            this.panel70.Controls.Add(this.label193);
            this.panel70.Controls.Add(this.textBoxThemeName);
            this.panel70.Controls.Add(this.btnSaveTheme);
            this.panel70.Controls.Add(this.label194);
            this.panel70.Controls.Add(this.textBoxThemeImage);
            this.panel70.Location = new System.Drawing.Point(250, 350);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(505, 104);
            this.panel70.TabIndex = 292;
            // 
            // lblThemeSaved
            // 
            this.lblThemeSaved.AutoSize = true;
            this.lblThemeSaved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblThemeSaved.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemeSaved.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblThemeSaved.Location = new System.Drawing.Point(417, 5);
            this.lblThemeSaved.Name = "lblThemeSaved";
            this.lblThemeSaved.Size = new System.Drawing.Size(106, 20);
            this.lblThemeSaved.TabIndex = 289;
            this.lblThemeSaved.Text = "theme saved";
            this.lblThemeSaved.Visible = false;
            // 
            // panel69
            // 
            this.panel69.BackColor = System.Drawing.Color.Transparent;
            this.panel69.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel69.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel69.Controls.Add(this.label192);
            this.panel69.Location = new System.Drawing.Point(0, 0);
            this.panel69.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(224, 23);
            this.panel69.TabIndex = 215;
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label192.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label192.ForeColor = System.Drawing.Color.Gray;
            this.label192.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label192.Location = new System.Drawing.Point(0, 2);
            this.label192.Margin = new System.Windows.Forms.Padding(0);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(97, 20);
            this.label192.TabIndex = 153;
            this.label192.Text = "Save theme";
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label193.ForeColor = System.Drawing.Color.Silver;
            this.label193.Location = new System.Drawing.Point(7, 35);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(102, 20);
            this.label193.TabIndex = 285;
            this.label193.Text = "Theme name";
            // 
            // textBoxThemeName
            // 
            this.textBoxThemeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxThemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThemeName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxThemeName.ForeColor = System.Drawing.Color.Silver;
            this.textBoxThemeName.Location = new System.Drawing.Point(231, 35);
            this.textBoxThemeName.MaxLength = 20;
            this.textBoxThemeName.Name = "textBoxThemeName";
            this.textBoxThemeName.Size = new System.Drawing.Size(167, 25);
            this.textBoxThemeName.TabIndex = 218;
            this.textBoxThemeName.TextChanged += new System.EventHandler(this.TextBoxThemeName_TextChanged);
            // 
            // btnSaveTheme
            // 
            this.btnSaveTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnSaveTheme.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveTheme.Enabled = false;
            this.btnSaveTheme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnSaveTheme.FlatAppearance.BorderSize = 0;
            this.btnSaveTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnSaveTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnSaveTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTheme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTheme.ForeColor = System.Drawing.Color.White;
            this.btnSaveTheme.Location = new System.Drawing.Point(407, 69);
            this.btnSaveTheme.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveTheme.Name = "btnSaveTheme";
            this.btnSaveTheme.Size = new System.Drawing.Size(91, 24);
            this.btnSaveTheme.TabIndex = 161;
            this.btnSaveTheme.TabStop = false;
            this.btnSaveTheme.Text = "save";
            this.btnSaveTheme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveTheme.UseVisualStyleBackColor = false;
            this.btnSaveTheme.Click += new System.EventHandler(this.BtnSaveTheme_Click);
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Enabled = false;
            this.label194.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label194.ForeColor = System.Drawing.Color.Silver;
            this.label194.Location = new System.Drawing.Point(7, 72);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(136, 20);
            this.label194.TabIndex = 286;
            this.label194.Text = "Path to image file";
            // 
            // textBoxThemeImage
            // 
            this.textBoxThemeImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxThemeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThemeImage.Enabled = false;
            this.textBoxThemeImage.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxThemeImage.ForeColor = System.Drawing.Color.Silver;
            this.textBoxThemeImage.Location = new System.Drawing.Point(232, 69);
            this.textBoxThemeImage.MaxLength = 200;
            this.textBoxThemeImage.Name = "textBoxThemeImage";
            this.textBoxThemeImage.Size = new System.Drawing.Size(166, 25);
            this.textBoxThemeImage.TabIndex = 287;
            // 
            // lblBackgroundBTCdirSelected
            // 
            this.lblBackgroundBTCdirSelected.AutoSize = true;
            this.lblBackgroundBTCdirSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblBackgroundBTCdirSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackgroundBTCdirSelected.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBackgroundBTCdirSelected.ForeColor = System.Drawing.Color.Green;
            this.lblBackgroundBTCdirSelected.Location = new System.Drawing.Point(381, 196);
            this.lblBackgroundBTCdirSelected.Name = "lblBackgroundBTCdirSelected";
            this.lblBackgroundBTCdirSelected.Size = new System.Drawing.Size(25, 20);
            this.lblBackgroundBTCdirSelected.TabIndex = 291;
            this.lblBackgroundBTCdirSelected.Text = "✔️";
            this.lblBackgroundBTCdirSelected.Visible = false;
            // 
            // lblBackgroundCustomColorSelected
            // 
            this.lblBackgroundCustomColorSelected.AutoSize = true;
            this.lblBackgroundCustomColorSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblBackgroundCustomColorSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackgroundCustomColorSelected.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBackgroundCustomColorSelected.ForeColor = System.Drawing.Color.Green;
            this.lblBackgroundCustomColorSelected.Location = new System.Drawing.Point(509, 196);
            this.lblBackgroundCustomColorSelected.Name = "lblBackgroundCustomColorSelected";
            this.lblBackgroundCustomColorSelected.Size = new System.Drawing.Size(25, 20);
            this.lblBackgroundCustomColorSelected.TabIndex = 290;
            this.lblBackgroundCustomColorSelected.Text = "✔️";
            this.lblBackgroundCustomColorSelected.Visible = false;
            // 
            // lblBackgroundCustomImageSelected
            // 
            this.lblBackgroundCustomImageSelected.AutoSize = true;
            this.lblBackgroundCustomImageSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblBackgroundCustomImageSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackgroundCustomImageSelected.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBackgroundCustomImageSelected.ForeColor = System.Drawing.Color.Green;
            this.lblBackgroundCustomImageSelected.Location = new System.Drawing.Point(637, 196);
            this.lblBackgroundCustomImageSelected.Name = "lblBackgroundCustomImageSelected";
            this.lblBackgroundCustomImageSelected.Size = new System.Drawing.Size(25, 20);
            this.lblBackgroundCustomImageSelected.TabIndex = 289;
            this.lblBackgroundCustomImageSelected.Text = "✔️";
            this.lblBackgroundCustomImageSelected.Visible = false;
            // 
            // lblBackgroundGenesisSelected
            // 
            this.lblBackgroundGenesisSelected.AutoSize = true;
            this.lblBackgroundGenesisSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblBackgroundGenesisSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackgroundGenesisSelected.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBackgroundGenesisSelected.ForeColor = System.Drawing.Color.Green;
            this.lblBackgroundGenesisSelected.Location = new System.Drawing.Point(253, 196);
            this.lblBackgroundGenesisSelected.Name = "lblBackgroundGenesisSelected";
            this.lblBackgroundGenesisSelected.Size = new System.Drawing.Size(25, 20);
            this.lblBackgroundGenesisSelected.TabIndex = 288;
            this.lblBackgroundGenesisSelected.Text = "✔️";
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label191.ForeColor = System.Drawing.Color.Silver;
            this.label191.Location = new System.Drawing.Point(634, 316);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(114, 20);
            this.label191.TabIndex = 284;
            this.label191.Text = "Custom image";
            // 
            // pictureBoxCustomImage
            // 
            this.pictureBoxCustomImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCustomImage.Image = global::SATSuma.Properties.Resources.CustomImage;
            this.pictureBoxCustomImage.Location = new System.Drawing.Point(634, 193);
            this.pictureBoxCustomImage.Name = "pictureBoxCustomImage";
            this.pictureBoxCustomImage.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxCustomImage.TabIndex = 283;
            this.pictureBoxCustomImage.TabStop = false;
            this.pictureBoxCustomImage.Click += new System.EventHandler(this.PictureBoxCustomImage_Click);
            // 
            // panel68
            // 
            this.panel68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel68.Controls.Add(this.label190);
            this.panel68.Location = new System.Drawing.Point(0, 136);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(100, 20);
            this.panel68.TabIndex = 282;
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.BackColor = System.Drawing.Color.Transparent;
            this.label190.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label190.ForeColor = System.Drawing.Color.Silver;
            this.label190.Location = new System.Drawing.Point(0, 0);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(118, 20);
            this.label190.TabIndex = 279;
            this.label190.Text = "Table headings";
            // 
            // btnListViewHeadingColor
            // 
            this.btnListViewHeadingColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnListViewHeadingColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnListViewHeadingColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnListViewHeadingColor.FlatAppearance.BorderSize = 0;
            this.btnListViewHeadingColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnListViewHeadingColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnListViewHeadingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListViewHeadingColor.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListViewHeadingColor.ForeColor = System.Drawing.Color.White;
            this.btnListViewHeadingColor.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnListViewHeadingColor.Location = new System.Drawing.Point(124, 136);
            this.btnListViewHeadingColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnListViewHeadingColor.Name = "btnListViewHeadingColor";
            this.btnListViewHeadingColor.Size = new System.Drawing.Size(55, 18);
            this.btnListViewHeadingColor.TabIndex = 282;
            this.btnListViewHeadingColor.TabStop = false;
            this.btnListViewHeadingColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListViewHeadingColor.UseVisualStyleBackColor = false;
            this.btnListViewHeadingColor.Click += new System.EventHandler(this.BtnListViewHeadingColor_Click);
            // 
            // panel67
            // 
            this.panel67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel67.Controls.Add(this.label188);
            this.panel67.Location = new System.Drawing.Point(0, 491);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(100, 20);
            this.panel67.TabIndex = 281;
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.BackColor = System.Drawing.Color.Transparent;
            this.label188.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label188.ForeColor = System.Drawing.Color.Silver;
            this.label188.Location = new System.Drawing.Point(0, 0);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(77, 20);
            this.label188.TabIndex = 279;
            this.label188.Text = "Headings";
            // 
            // panel66
            // 
            this.panel66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel66.Controls.Add(this.label186);
            this.panel66.Location = new System.Drawing.Point(0, 516);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(100, 20);
            this.panel66.TabIndex = 280;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.BackColor = System.Drawing.Color.Transparent;
            this.label186.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label186.ForeColor = System.Drawing.Color.Silver;
            this.label186.Location = new System.Drawing.Point(0, 0);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(45, 20);
            this.label186.TabIndex = 277;
            this.label186.Text = "Data";
            // 
            // btnColorTableTitleBar
            // 
            this.btnColorTableTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorTableTitleBar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorTableTitleBar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorTableTitleBar.FlatAppearance.BorderSize = 0;
            this.btnColorTableTitleBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableTitleBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableTitleBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTableTitleBar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTableTitleBar.ForeColor = System.Drawing.Color.White;
            this.btnColorTableTitleBar.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorTableTitleBar.Location = new System.Drawing.Point(124, 491);
            this.btnColorTableTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorTableTitleBar.Name = "btnColorTableTitleBar";
            this.btnColorTableTitleBar.Size = new System.Drawing.Size(55, 18);
            this.btnColorTableTitleBar.TabIndex = 278;
            this.btnColorTableTitleBar.TabStop = false;
            this.btnColorTableTitleBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorTableTitleBar.UseVisualStyleBackColor = false;
            this.btnColorTableTitleBar.Click += new System.EventHandler(this.BtnColorTableTitleBar_Click);
            // 
            // btnColorTableBackground
            // 
            this.btnColorTableBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorTableBackground.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorTableBackground.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorTableBackground.FlatAppearance.BorderSize = 0;
            this.btnColorTableBackground.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableBackground.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTableBackground.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTableBackground.ForeColor = System.Drawing.Color.White;
            this.btnColorTableBackground.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorTableBackground.Location = new System.Drawing.Point(124, 516);
            this.btnColorTableBackground.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorTableBackground.Name = "btnColorTableBackground";
            this.btnColorTableBackground.Size = new System.Drawing.Size(55, 18);
            this.btnColorTableBackground.TabIndex = 276;
            this.btnColorTableBackground.TabStop = false;
            this.btnColorTableBackground.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorTableBackground.UseVisualStyleBackColor = false;
            this.btnColorTableBackground.Click += new System.EventHandler(this.BtnColorTableBackground_Click);
            // 
            // panel65
            // 
            this.panel65.BackColor = System.Drawing.Color.Transparent;
            this.panel65.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel65.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel65.Controls.Add(this.label184);
            this.panel65.Location = new System.Drawing.Point(0, 449);
            this.panel65.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(224, 23);
            this.panel65.TabIndex = 214;
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label184.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label184.ForeColor = System.Drawing.Color.Gray;
            this.label184.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label184.Location = new System.Drawing.Point(0, 2);
            this.label184.Margin = new System.Windows.Forms.Padding(0);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(148, 20);
            this.label184.TabIndex = 153;
            this.label184.Text = "Table backgrounds";
            // 
            // btnColorTitleBackgrounds
            // 
            this.btnColorTitleBackgrounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorTitleBackgrounds.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorTitleBackgrounds.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorTitleBackgrounds.FlatAppearance.BorderSize = 0;
            this.btnColorTitleBackgrounds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTitleBackgrounds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTitleBackgrounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTitleBackgrounds.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTitleBackgrounds.ForeColor = System.Drawing.Color.White;
            this.btnColorTitleBackgrounds.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorTitleBackgrounds.Location = new System.Drawing.Point(653, 113);
            this.btnColorTitleBackgrounds.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorTitleBackgrounds.Name = "btnColorTitleBackgrounds";
            this.btnColorTitleBackgrounds.Size = new System.Drawing.Size(55, 18);
            this.btnColorTitleBackgrounds.TabIndex = 275;
            this.btnColorTitleBackgrounds.TabStop = false;
            this.btnColorTitleBackgrounds.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorTitleBackgrounds.UseVisualStyleBackColor = false;
            this.btnColorTitleBackgrounds.Click += new System.EventHandler(this.BtnColorTitleBackgrounds_Click);
            // 
            // lblTitleBackgroundCustom
            // 
            this.lblTitleBackgroundCustom.AutoSize = true;
            this.lblTitleBackgroundCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleBackgroundCustom.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTitleBackgroundCustom.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitleBackgroundCustom.Location = new System.Drawing.Point(570, 113);
            this.lblTitleBackgroundCustom.Name = "lblTitleBackgroundCustom";
            this.lblTitleBackgroundCustom.Size = new System.Drawing.Size(23, 18);
            this.lblTitleBackgroundCustom.TabIndex = 274;
            this.lblTitleBackgroundCustom.Text = "❌";
            this.lblTitleBackgroundCustom.Click += new System.EventHandler(this.LblTitleBackgroundCustom_Click);
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label189.ForeColor = System.Drawing.Color.Silver;
            this.label189.Location = new System.Drawing.Point(589, 113);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(64, 20);
            this.label189.TabIndex = 273;
            this.label189.Text = "Custom";
            // 
            // lblTitleBackgroundNone
            // 
            this.lblTitleBackgroundNone.AutoSize = true;
            this.lblTitleBackgroundNone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleBackgroundNone.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTitleBackgroundNone.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitleBackgroundNone.Location = new System.Drawing.Point(410, 113);
            this.lblTitleBackgroundNone.Name = "lblTitleBackgroundNone";
            this.lblTitleBackgroundNone.Size = new System.Drawing.Size(23, 18);
            this.lblTitleBackgroundNone.TabIndex = 272;
            this.lblTitleBackgroundNone.Text = "❌";
            this.lblTitleBackgroundNone.Click += new System.EventHandler(this.LblTitleBackgroundNone_Click);
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label187.ForeColor = System.Drawing.Color.Silver;
            this.label187.Location = new System.Drawing.Point(429, 113);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(49, 20);
            this.label187.TabIndex = 271;
            this.label187.Text = "None";
            // 
            // lblTitleBackgroundDefault
            // 
            this.lblTitleBackgroundDefault.AutoSize = true;
            this.lblTitleBackgroundDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleBackgroundDefault.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTitleBackgroundDefault.ForeColor = System.Drawing.Color.Green;
            this.lblTitleBackgroundDefault.Location = new System.Drawing.Point(250, 113);
            this.lblTitleBackgroundDefault.Name = "lblTitleBackgroundDefault";
            this.lblTitleBackgroundDefault.Size = new System.Drawing.Size(23, 18);
            this.lblTitleBackgroundDefault.TabIndex = 270;
            this.lblTitleBackgroundDefault.Text = "✔️";
            this.lblTitleBackgroundDefault.Click += new System.EventHandler(this.LblTitleBackgroundDefault_Click);
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label185.ForeColor = System.Drawing.Color.Silver;
            this.label185.Location = new System.Drawing.Point(269, 113);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(62, 20);
            this.label185.TabIndex = 269;
            this.label185.Text = "Default";
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.Color.Transparent;
            this.panel64.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel64.Controls.Add(this.label183);
            this.panel64.Location = new System.Drawing.Point(250, 73);
            this.panel64.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(224, 23);
            this.panel64.TabIndex = 215;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label183.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label183.ForeColor = System.Drawing.Color.Gray;
            this.label183.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label183.Location = new System.Drawing.Point(0, 2);
            this.label183.Margin = new System.Windows.Forms.Padding(0);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(172, 20);
            this.label183.TabIndex = 153;
            this.label183.Text = "Heading backgrounds";
            // 
            // panel63
            // 
            this.panel63.BackColor = System.Drawing.Color.Transparent;
            this.panel63.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel63.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel63.Controls.Add(this.label182);
            this.panel63.Location = new System.Drawing.Point(250, 153);
            this.panel63.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(224, 23);
            this.panel63.TabIndex = 214;
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label182.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label182.ForeColor = System.Drawing.Color.Gray;
            this.label182.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label182.Location = new System.Drawing.Point(0, 2);
            this.label182.Margin = new System.Windows.Forms.Padding(0);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(149, 20);
            this.label182.TabIndex = 153;
            this.label182.Text = "Background image";
            // 
            // panel62
            // 
            this.panel62.BackColor = System.Drawing.Color.Transparent;
            this.panel62.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel62.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel62.Controls.Add(this.label181);
            this.panel62.Location = new System.Drawing.Point(250, 0);
            this.panel62.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(224, 23);
            this.panel62.TabIndex = 213;
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label181.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label181.ForeColor = System.Drawing.Color.Gray;
            this.label181.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label181.Location = new System.Drawing.Point(0, 2);
            this.label181.Margin = new System.Windows.Forms.Padding(0);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(84, 20);
            this.label181.TabIndex = 153;
            this.label181.Text = "Local time";
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label180.ForeColor = System.Drawing.Color.Silver;
            this.label180.Location = new System.Drawing.Point(506, 316);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(115, 20);
            this.label180.TabIndex = 268;
            this.label180.Text = "Custom colour";
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label179.ForeColor = System.Drawing.Color.Silver;
            this.label179.Location = new System.Drawing.Point(378, 316);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(88, 20);
            this.label179.TabIndex = 267;
            this.label179.Text = "\'BTCdir.org\'";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label177.ForeColor = System.Drawing.Color.Silver;
            this.label177.Location = new System.Drawing.Point(250, 316);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(72, 20);
            this.label177.TabIndex = 266;
            this.label177.Text = "\'Genesis\'";
            // 
            // pictureBoxCustomColor
            // 
            this.pictureBoxCustomColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCustomColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxCustomColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCustomColor.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.pictureBoxCustomColor.Location = new System.Drawing.Point(506, 193);
            this.pictureBoxCustomColor.Name = "pictureBoxCustomColor";
            this.pictureBoxCustomColor.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxCustomColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCustomColor.TabIndex = 265;
            this.pictureBoxCustomColor.TabStop = false;
            this.pictureBoxCustomColor.Click += new System.EventHandler(this.PictureBoxCustomColor_Click);
            // 
            // pictureBoxBTCDir
            // 
            this.pictureBoxBTCDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBTCDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBTCDir.Image = global::SATSuma.Properties.Resources.SatsumaBTCdir1;
            this.pictureBoxBTCDir.Location = new System.Drawing.Point(378, 193);
            this.pictureBoxBTCDir.Name = "pictureBoxBTCDir";
            this.pictureBoxBTCDir.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxBTCDir.TabIndex = 264;
            this.pictureBoxBTCDir.TabStop = false;
            this.pictureBoxBTCDir.Click += new System.EventHandler(this.PictureBoxBTCDir_Click);
            // 
            // pictureBoxGenesis
            // 
            this.pictureBoxGenesis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGenesis.Image = global::SATSuma.Properties.Resources.AppBackground2;
            this.pictureBoxGenesis.Location = new System.Drawing.Point(250, 193);
            this.pictureBoxGenesis.Name = "pictureBoxGenesis";
            this.pictureBoxGenesis.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxGenesis.TabIndex = 263;
            this.pictureBoxGenesis.TabStop = false;
            this.pictureBoxGenesis.Click += new System.EventHandler(this.PictureBoxGenesis_Click);
            // 
            // lblShowClock
            // 
            this.lblShowClock.AutoSize = true;
            this.lblShowClock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShowClock.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblShowClock.ForeColor = System.Drawing.Color.Green;
            this.lblShowClock.Location = new System.Drawing.Point(251, 40);
            this.lblShowClock.Name = "lblShowClock";
            this.lblShowClock.Size = new System.Drawing.Size(23, 18);
            this.lblShowClock.TabIndex = 262;
            this.lblShowClock.Text = "✔️";
            this.lblShowClock.Click += new System.EventHandler(this.LblShowClock_Click);
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label178.ForeColor = System.Drawing.Color.Silver;
            this.label178.Location = new System.Drawing.Point(273, 40);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(330, 20);
            this.label178.TabIndex = 261;
            this.label178.Text = "Show local time (\'Genesis\' background only)";
            // 
            // btnColorStatusError
            // 
            this.btnColorStatusError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorStatusError.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorStatusError.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorStatusError.FlatAppearance.BorderSize = 0;
            this.btnColorStatusError.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorStatusError.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorStatusError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorStatusError.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorStatusError.ForeColor = System.Drawing.Color.White;
            this.btnColorStatusError.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorStatusError.Location = new System.Drawing.Point(124, 211);
            this.btnColorStatusError.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorStatusError.Name = "btnColorStatusError";
            this.btnColorStatusError.Size = new System.Drawing.Size(55, 18);
            this.btnColorStatusError.TabIndex = 260;
            this.btnColorStatusError.TabStop = false;
            this.btnColorStatusError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorStatusError.UseVisualStyleBackColor = false;
            this.btnColorStatusError.Click += new System.EventHandler(this.BtnColorStatusError_Click);
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label176.ForeColor = System.Drawing.Color.Gray;
            this.label176.Location = new System.Drawing.Point(0, 211);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(98, 20);
            this.label176.TabIndex = 259;
            this.label176.Text = "Status, Errors";
            // 
            // btnColorPriceBlock
            // 
            this.btnColorPriceBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorPriceBlock.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorPriceBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorPriceBlock.FlatAppearance.BorderSize = 0;
            this.btnColorPriceBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorPriceBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorPriceBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorPriceBlock.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorPriceBlock.ForeColor = System.Drawing.Color.White;
            this.btnColorPriceBlock.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorPriceBlock.Location = new System.Drawing.Point(124, 186);
            this.btnColorPriceBlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorPriceBlock.Name = "btnColorPriceBlock";
            this.btnColorPriceBlock.Size = new System.Drawing.Size(55, 18);
            this.btnColorPriceBlock.TabIndex = 258;
            this.btnColorPriceBlock.TabStop = false;
            this.btnColorPriceBlock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorPriceBlock.UseVisualStyleBackColor = false;
            this.btnColorPriceBlock.Click += new System.EventHandler(this.BtnColorPriceBlock_Click);
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label175.ForeColor = System.Drawing.Color.DimGray;
            this.label175.Location = new System.Drawing.Point(0, 186);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(94, 20);
            this.label175.TabIndex = 257;
            this.label175.Text = "Price, Block";
            // 
            // btnColorTextBox
            // 
            this.btnColorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorTextBox.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorTextBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorTextBox.FlatAppearance.BorderSize = 0;
            this.btnColorTextBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTextBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTextBox.ForeColor = System.Drawing.Color.White;
            this.btnColorTextBox.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorTextBox.Location = new System.Drawing.Point(124, 358);
            this.btnColorTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorTextBox.Name = "btnColorTextBox";
            this.btnColorTextBox.Size = new System.Drawing.Size(55, 18);
            this.btnColorTextBox.TabIndex = 256;
            this.btnColorTextBox.TabStop = false;
            this.btnColorTextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorTextBox.UseVisualStyleBackColor = false;
            this.btnColorTextBox.Click += new System.EventHandler(this.BtnColorTextBox_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(0, 357);
            this.textBox1.MaxLength = 165;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 218;
            this.textBox1.Text = "Textboxes";
            // 
            // btnColorOtherText
            // 
            this.btnColorOtherText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorOtherText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorOtherText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorOtherText.FlatAppearance.BorderSize = 0;
            this.btnColorOtherText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorOtherText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorOtherText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorOtherText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorOtherText.ForeColor = System.Drawing.Color.White;
            this.btnColorOtherText.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorOtherText.Location = new System.Drawing.Point(124, 161);
            this.btnColorOtherText.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorOtherText.Name = "btnColorOtherText";
            this.btnColorOtherText.Size = new System.Drawing.Size(55, 18);
            this.btnColorOtherText.TabIndex = 255;
            this.btnColorOtherText.TabStop = false;
            this.btnColorOtherText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorOtherText.UseVisualStyleBackColor = false;
            this.btnColorOtherText.Click += new System.EventHandler(this.BtnColorOtherText_Click);
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label173.ForeColor = System.Drawing.Color.Gray;
            this.label173.Location = new System.Drawing.Point(0, 161);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(82, 20);
            this.label173.TabIndex = 254;
            this.label173.Text = "Other text";
            // 
            // btnColorTableText
            // 
            this.btnColorTableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorTableText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorTableText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorTableText.FlatAppearance.BorderSize = 0;
            this.btnColorTableText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorTableText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTableText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTableText.ForeColor = System.Drawing.Color.White;
            this.btnColorTableText.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorTableText.Location = new System.Drawing.Point(124, 111);
            this.btnColorTableText.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorTableText.Name = "btnColorTableText";
            this.btnColorTableText.Size = new System.Drawing.Size(55, 18);
            this.btnColorTableText.TabIndex = 253;
            this.btnColorTableText.TabStop = false;
            this.btnColorTableText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorTableText.UseVisualStyleBackColor = false;
            this.btnColorTableText.Click += new System.EventHandler(this.BtnColorTableText_Click);
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.label170.Location = new System.Drawing.Point(0, 111);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(86, 20);
            this.label170.TabIndex = 252;
            this.label170.Text = "Table data";
            // 
            // btnColorLines
            // 
            this.btnColorLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnColorLines.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColorLines.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnColorLines.FlatAppearance.BorderSize = 0;
            this.btnColorLines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorLines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnColorLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorLines.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorLines.ForeColor = System.Drawing.Color.White;
            this.btnColorLines.Image = global::SATSuma.Properties.Resources.spectrum2;
            this.btnColorLines.Location = new System.Drawing.Point(124, 333);
            this.btnColorLines.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorLines.Name = "btnColorLines";
            this.btnColorLines.Size = new System.Drawing.Size(55, 18);
            this.btnColorLines.TabIndex = 251;
            this.btnColorLines.TabStop = false;
            this.btnColorLines.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColorLines.UseVisualStyleBackColor = false;
            this.btnColorLines.Click += new System.EventHandler(this.BtnColorLines_Click);
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.ForeColor = System.Drawing.Color.Silver;
            this.label168.Location = new System.Drawing.Point(0, 333);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(44, 20);
            this.label168.TabIndex = 250;
            this.label168.Text = "Lines";
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.panel61.Location = new System.Drawing.Point(46, 343);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(56, 2);
            this.panel61.TabIndex = 249;
            // 
            // panel60
            // 
            this.panel60.BackColor = System.Drawing.Color.Transparent;
            this.panel60.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel60.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel60.Controls.Add(this.label166);
            this.panel60.Location = new System.Drawing.Point(0, 271);
            this.panel60.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(224, 23);
            this.panel60.TabIndex = 213;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label166.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.ForeColor = System.Drawing.Color.Gray;
            this.label166.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label166.Location = new System.Drawing.Point(0, 2);
            this.label166.Margin = new System.Windows.Forms.Padding(0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(141, 20);
            this.label166.TabIndex = 153;
            this.label166.Text = "Controls, lines, etc";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // headerNetworkName
            // 
            this.headerNetworkName.AutoSize = true;
            this.headerNetworkName.BackColor = System.Drawing.Color.Transparent;
            this.headerNetworkName.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.headerNetworkName.ForeColor = System.Drawing.Color.Silver;
            this.headerNetworkName.Location = new System.Drawing.Point(633, 162);
            this.headerNetworkName.Name = "headerNetworkName";
            this.headerNetworkName.Size = new System.Drawing.Size(169, 17);
            this.headerNetworkName.TabIndex = 241;
            this.headerNetworkName.Text = "MAINNET (mempool.space)";
            // 
            // headerNetworkStatusLight
            // 
            this.headerNetworkStatusLight.AutoSize = true;
            this.headerNetworkStatusLight.BackColor = System.Drawing.Color.Transparent;
            this.headerNetworkStatusLight.Font = new System.Drawing.Font("Consolas", 6F);
            this.headerNetworkStatusLight.ForeColor = System.Drawing.Color.IndianRed;
            this.headerNetworkStatusLight.Location = new System.Drawing.Point(620, 166);
            this.headerNetworkStatusLight.Name = "headerNetworkStatusLight";
            this.headerNetworkStatusLight.Size = new System.Drawing.Size(15, 12);
            this.headerNetworkStatusLight.TabIndex = 240;
            this.headerNetworkStatusLight.Text = "🟢";
            // 
            // hideThemeSavedTimer
            // 
            this.hideThemeSavedTimer.Interval = 2000;
            this.hideThemeSavedTimer.Tick += new System.EventHandler(this.HideThemeSavedTimer_Tick);
            // 
            // hideThemeDeletedTimer
            // 
            this.hideThemeDeletedTimer.Interval = 2000;
            this.hideThemeDeletedTimer.Tick += new System.EventHandler(this.HideThemeDeletedTimer_Tick);
            // 
            // panelCharts
            // 
            this.panelCharts.BackColor = System.Drawing.Color.Transparent;
            this.panelCharts.Controls.Add(this.btnChartLightningChannels);
            this.panelCharts.Controls.Add(this.btnChartLightningCapacity);
            this.panelCharts.Controls.Add(this.panel81);
            this.panelCharts.Controls.Add(this.panel80);
            this.panelCharts.Controls.Add(this.formsPlot3);
            this.panelCharts.Controls.Add(this.btnChartNodesByCountry);
            this.panelCharts.Controls.Add(this.panelLightningNodeNetwork);
            this.panelCharts.Controls.Add(this.panel79);
            this.panelCharts.Controls.Add(this.btnChartNodesByNetwork);
            this.panelCharts.Controls.Add(this.formsPlot2);
            this.panelCharts.Controls.Add(this.btnChartPoolsRanking);
            this.panelCharts.Controls.Add(this.panelChartUTXOScaleButtons);
            this.panelCharts.Controls.Add(this.btnChartUTXO);
            this.panelCharts.Controls.Add(this.panelPriceScaleButtons);
            this.panelCharts.Controls.Add(this.panelUniqueAddressesScaleButtons);
            this.panelCharts.Controls.Add(this.btnChartUniqueAddresses);
            this.panelCharts.Controls.Add(this.lblChartMousePositionData);
            this.panelCharts.Controls.Add(this.panel78);
            this.panelCharts.Controls.Add(this.btnChartBlockSize);
            this.panelCharts.Controls.Add(this.panelCirculationKey);
            this.panelCharts.Controls.Add(this.panelFeeRatesKey);
            this.panelCharts.Controls.Add(this.btnChartCirculation);
            this.panelCharts.Controls.Add(this.btnChartFeeRates);
            this.panelCharts.Controls.Add(this.btnChartPeriodAll);
            this.panelCharts.Controls.Add(this.btnChartPeriod3y);
            this.panelCharts.Controls.Add(this.btnChartPeriod2y);
            this.panelCharts.Controls.Add(this.btnChartPeriod1y);
            this.panelCharts.Controls.Add(this.btnChartPeriod6m);
            this.panelCharts.Controls.Add(this.btnChartPeriod3m);
            this.panelCharts.Controls.Add(this.btnChartPeriod1m);
            this.panelCharts.Controls.Add(this.btnChartPeriod1w);
            this.panelCharts.Controls.Add(this.btnChartPeriod3d);
            this.panelCharts.Controls.Add(this.btnChartPeriod24h);
            this.panelCharts.Controls.Add(this.btnChartBlockFees);
            this.panelCharts.Controls.Add(this.btnChartReward);
            this.panelCharts.Controls.Add(this.btnChartPrice);
            this.panelCharts.Controls.Add(this.btnChartDifficulty);
            this.panelCharts.Controls.Add(this.btnChartHashrate);
            this.panelCharts.Controls.Add(this.formsPlot1);
            this.panelCharts.Location = new System.Drawing.Point(21, 188);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Size = new System.Drawing.Size(773, 556);
            this.panelCharts.TabIndex = 231;
            this.panelCharts.Visible = false;
            // 
            // panel81
            // 
            this.panel81.BackColor = System.Drawing.Color.Transparent;
            this.panel81.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel81.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel81.Controls.Add(this.label231);
            this.panel81.Location = new System.Drawing.Point(0, 472);
            this.panel81.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(116, 23);
            this.panel81.TabIndex = 209;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label231.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label231.ForeColor = System.Drawing.Color.Gray;
            this.label231.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label231.Location = new System.Drawing.Point(3, 2);
            this.label231.Margin = new System.Windows.Forms.Padding(0);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(60, 20);
            this.label231.TabIndex = 153;
            this.label231.Text = "market";
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.Color.Transparent;
            this.panel80.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel80.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel80.Controls.Add(this.label228);
            this.panel80.Location = new System.Drawing.Point(0, 0);
            this.panel80.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(116, 23);
            this.panel80.TabIndex = 209;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label228.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label228.ForeColor = System.Drawing.Color.Gray;
            this.label228.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label228.Location = new System.Drawing.Point(3, 2);
            this.label228.Margin = new System.Windows.Forms.Padding(0);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(74, 20);
            this.label228.TabIndex = 153;
            this.label228.Text = "on-chain";
            // 
            // formsPlot3
            // 
            this.formsPlot3.Location = new System.Drawing.Point(100, 0);
            this.formsPlot3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(682, 521);
            this.formsPlot3.TabIndex = 270;
            this.formsPlot3.Visible = false;
            // 
            // btnChartNodesByCountry
            // 
            this.btnChartNodesByCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartNodesByCountry.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartNodesByCountry.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartNodesByCountry.FlatAppearance.BorderSize = 0;
            this.btnChartNodesByCountry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartNodesByCountry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartNodesByCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartNodesByCountry.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartNodesByCountry.ForeColor = System.Drawing.Color.White;
            this.btnChartNodesByCountry.Location = new System.Drawing.Point(0, 376);
            this.btnChartNodesByCountry.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartNodesByCountry.Name = "btnChartNodesByCountry";
            this.btnChartNodesByCountry.Size = new System.Drawing.Size(100, 24);
            this.btnChartNodesByCountry.TabIndex = 269;
            this.btnChartNodesByCountry.TabStop = false;
            this.btnChartNodesByCountry.Text = "countries";
            this.btnChartNodesByCountry.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartNodesByCountry.UseVisualStyleBackColor = false;
            this.btnChartNodesByCountry.Click += new System.EventHandler(this.btnChartNodesByCountry_Click);
            // 
            // panelLightningNodeNetwork
            // 
            this.panelLightningNodeNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panelLightningNodeNetwork.Controls.Add(this.label226);
            this.panelLightningNodeNetwork.Controls.Add(this.label225);
            this.panelLightningNodeNetwork.Controls.Add(this.label224);
            this.panelLightningNodeNetwork.Controls.Add(this.label221);
            this.panelLightningNodeNetwork.Controls.Add(this.label219);
            this.panelLightningNodeNetwork.Controls.Add(this.label220);
            this.panelLightningNodeNetwork.Controls.Add(this.label227);
            this.panelLightningNodeNetwork.Controls.Add(this.label236);
            this.panelLightningNodeNetwork.Location = new System.Drawing.Point(185, 32);
            this.panelLightningNodeNetwork.Name = "panelLightningNodeNetwork";
            this.panelLightningNodeNetwork.Size = new System.Drawing.Size(190, 89);
            this.panelLightningNodeNetwork.TabIndex = 268;
            this.panelLightningNodeNetwork.Visible = false;
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label226.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label226.ForeColor = System.Drawing.Color.Silver;
            this.label226.Location = new System.Drawing.Point(22, 66);
            this.label226.Margin = new System.Windows.Forms.Padding(0);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(79, 20);
            this.label226.TabIndex = 256;
            this.label226.Text = "Unknown";
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label225.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label225.ForeColor = System.Drawing.Color.Silver;
            this.label225.Location = new System.Drawing.Point(22, 44);
            this.label225.Margin = new System.Windows.Forms.Padding(0);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(168, 20);
            this.label225.TabIndex = 255;
            this.label225.Text = "Clearnet and Darknet";
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.BackColor = System.Drawing.Color.Transparent;
            this.label224.Font = new System.Drawing.Font("Consolas", 9F);
            this.label224.ForeColor = System.Drawing.Color.Gold;
            this.label224.Location = new System.Drawing.Point(0, 69);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(23, 18);
            this.label224.TabIndex = 254;
            this.label224.Text = "🟢";
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.BackColor = System.Drawing.Color.Transparent;
            this.label221.Font = new System.Drawing.Font("Consolas", 9F);
            this.label221.ForeColor = System.Drawing.Color.SteelBlue;
            this.label221.Location = new System.Drawing.Point(0, 47);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(23, 18);
            this.label221.TabIndex = 253;
            this.label221.Text = "🟢";
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.BackColor = System.Drawing.Color.Transparent;
            this.label219.Font = new System.Drawing.Font("Consolas", 9F);
            this.label219.ForeColor = System.Drawing.Color.OliveDrab;
            this.label219.Location = new System.Drawing.Point(0, 25);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(23, 18);
            this.label219.TabIndex = 252;
            this.label219.Text = "🟢";
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label220.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label220.ForeColor = System.Drawing.Color.Silver;
            this.label220.Location = new System.Drawing.Point(22, 22);
            this.label220.Margin = new System.Windows.Forms.Padding(0);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(193, 20);
            this.label220.TabIndex = 251;
            this.label220.Text = "Clearnet only (IPv4, IPv6)";
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.BackColor = System.Drawing.Color.Transparent;
            this.label227.Font = new System.Drawing.Font("Consolas", 9F);
            this.label227.ForeColor = System.Drawing.Color.IndianRed;
            this.label227.Location = new System.Drawing.Point(0, 3);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(23, 18);
            this.label227.TabIndex = 250;
            this.label227.Text = "🟢";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label236.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label236.ForeColor = System.Drawing.Color.Silver;
            this.label236.Location = new System.Drawing.Point(22, 0);
            this.label236.Margin = new System.Windows.Forms.Padding(0);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(211, 20);
            this.label236.TabIndex = 211;
            this.label236.Text = "Darknet only (Tor, I2P, cjdns)";
            // 
            // panel79
            // 
            this.panel79.BackColor = System.Drawing.Color.Transparent;
            this.panel79.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel79.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel79.Controls.Add(this.label218);
            this.panel79.Location = new System.Drawing.Point(0, 320);
            this.panel79.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(116, 23);
            this.panel79.TabIndex = 208;
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label218.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label218.ForeColor = System.Drawing.Color.Gray;
            this.label218.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label218.Location = new System.Drawing.Point(3, 2);
            this.label218.Margin = new System.Windows.Forms.Padding(0);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(119, 20);
            this.label218.TabIndex = 153;
            this.label218.Text = "lightning nodes";
            // 
            // btnChartNodesByNetwork
            // 
            this.btnChartNodesByNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartNodesByNetwork.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartNodesByNetwork.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartNodesByNetwork.FlatAppearance.BorderSize = 0;
            this.btnChartNodesByNetwork.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartNodesByNetwork.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartNodesByNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartNodesByNetwork.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartNodesByNetwork.ForeColor = System.Drawing.Color.White;
            this.btnChartNodesByNetwork.Location = new System.Drawing.Point(0, 348);
            this.btnChartNodesByNetwork.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartNodesByNetwork.Name = "btnChartNodesByNetwork";
            this.btnChartNodesByNetwork.Size = new System.Drawing.Size(100, 24);
            this.btnChartNodesByNetwork.TabIndex = 267;
            this.btnChartNodesByNetwork.TabStop = false;
            this.btnChartNodesByNetwork.Text = "networks";
            this.btnChartNodesByNetwork.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartNodesByNetwork.UseVisualStyleBackColor = false;
            this.btnChartNodesByNetwork.Click += new System.EventHandler(this.btnChartNodesByNetwork_Click);
            // 
            // formsPlot2
            // 
            this.formsPlot2.Location = new System.Drawing.Point(100, 0);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(682, 521);
            this.formsPlot2.TabIndex = 266;
            this.formsPlot2.Visible = false;
            // 
            // btnChartPoolsRanking
            // 
            this.btnChartPoolsRanking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPoolsRanking.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPoolsRanking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPoolsRanking.FlatAppearance.BorderSize = 0;
            this.btnChartPoolsRanking.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPoolsRanking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPoolsRanking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPoolsRanking.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPoolsRanking.ForeColor = System.Drawing.Color.White;
            this.btnChartPoolsRanking.Location = new System.Drawing.Point(0, 280);
            this.btnChartPoolsRanking.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPoolsRanking.Name = "btnChartPoolsRanking";
            this.btnChartPoolsRanking.Size = new System.Drawing.Size(100, 24);
            this.btnChartPoolsRanking.TabIndex = 265;
            this.btnChartPoolsRanking.TabStop = false;
            this.btnChartPoolsRanking.Text = "pools ranking";
            this.btnChartPoolsRanking.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPoolsRanking.UseVisualStyleBackColor = false;
            this.btnChartPoolsRanking.Click += new System.EventHandler(this.BtnChartPoolsRanking_Click);
            // 
            // panelChartUTXOScaleButtons
            // 
            this.panelChartUTXOScaleButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelChartUTXOScaleButtons.Controls.Add(this.btnChartUTXOScaleLog);
            this.panelChartUTXOScaleButtons.Controls.Add(this.btnChartUTXOScaleLinear);
            this.panelChartUTXOScaleButtons.Location = new System.Drawing.Point(217, 32);
            this.panelChartUTXOScaleButtons.Name = "panelChartUTXOScaleButtons";
            this.panelChartUTXOScaleButtons.Size = new System.Drawing.Size(175, 24);
            this.panelChartUTXOScaleButtons.TabIndex = 264;
            // 
            // btnChartUTXOScaleLog
            // 
            this.btnChartUTXOScaleLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartUTXOScaleLog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartUTXOScaleLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartUTXOScaleLog.FlatAppearance.BorderSize = 0;
            this.btnChartUTXOScaleLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXOScaleLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXOScaleLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartUTXOScaleLog.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartUTXOScaleLog.ForeColor = System.Drawing.Color.White;
            this.btnChartUTXOScaleLog.Location = new System.Drawing.Point(90, 0);
            this.btnChartUTXOScaleLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartUTXOScaleLog.Name = "btnChartUTXOScaleLog";
            this.btnChartUTXOScaleLog.Size = new System.Drawing.Size(85, 24);
            this.btnChartUTXOScaleLog.TabIndex = 262;
            this.btnChartUTXOScaleLog.TabStop = false;
            this.btnChartUTXOScaleLog.Text = "logarithmic";
            this.btnChartUTXOScaleLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartUTXOScaleLog.UseVisualStyleBackColor = false;
            this.btnChartUTXOScaleLog.Click += new System.EventHandler(this.BtnChartUTXOScaleLog_Click);
            // 
            // btnChartUTXOScaleLinear
            // 
            this.btnChartUTXOScaleLinear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartUTXOScaleLinear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartUTXOScaleLinear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartUTXOScaleLinear.FlatAppearance.BorderSize = 0;
            this.btnChartUTXOScaleLinear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXOScaleLinear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXOScaleLinear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartUTXOScaleLinear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartUTXOScaleLinear.ForeColor = System.Drawing.Color.White;
            this.btnChartUTXOScaleLinear.Location = new System.Drawing.Point(0, 0);
            this.btnChartUTXOScaleLinear.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartUTXOScaleLinear.Name = "btnChartUTXOScaleLinear";
            this.btnChartUTXOScaleLinear.Size = new System.Drawing.Size(85, 24);
            this.btnChartUTXOScaleLinear.TabIndex = 261;
            this.btnChartUTXOScaleLinear.TabStop = false;
            this.btnChartUTXOScaleLinear.Text = "linear";
            this.btnChartUTXOScaleLinear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartUTXOScaleLinear.UseVisualStyleBackColor = false;
            this.btnChartUTXOScaleLinear.Click += new System.EventHandler(this.BtnChartUTXO_Click);
            // 
            // btnChartUTXO
            // 
            this.btnChartUTXO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartUTXO.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartUTXO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartUTXO.FlatAppearance.BorderSize = 0;
            this.btnChartUTXO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUTXO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartUTXO.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartUTXO.ForeColor = System.Drawing.Color.White;
            this.btnChartUTXO.Location = new System.Drawing.Point(0, 252);
            this.btnChartUTXO.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartUTXO.Name = "btnChartUTXO";
            this.btnChartUTXO.Size = new System.Drawing.Size(100, 24);
            this.btnChartUTXO.TabIndex = 264;
            this.btnChartUTXO.TabStop = false;
            this.btnChartUTXO.Text = "UTXO\'s";
            this.btnChartUTXO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartUTXO.UseVisualStyleBackColor = false;
            this.btnChartUTXO.Click += new System.EventHandler(this.BtnChartUTXO_Click);
            // 
            // panelPriceScaleButtons
            // 
            this.panelPriceScaleButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelPriceScaleButtons.Controls.Add(this.btnPriceChartScaleLog);
            this.panelPriceScaleButtons.Controls.Add(this.btnPriceChartScaleLinear);
            this.panelPriceScaleButtons.Location = new System.Drawing.Point(185, 32);
            this.panelPriceScaleButtons.Name = "panelPriceScaleButtons";
            this.panelPriceScaleButtons.Size = new System.Drawing.Size(175, 24);
            this.panelPriceScaleButtons.TabIndex = 263;
            // 
            // btnPriceChartScaleLog
            // 
            this.btnPriceChartScaleLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnPriceChartScaleLog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPriceChartScaleLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnPriceChartScaleLog.FlatAppearance.BorderSize = 0;
            this.btnPriceChartScaleLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPriceChartScaleLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPriceChartScaleLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceChartScaleLog.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceChartScaleLog.ForeColor = System.Drawing.Color.White;
            this.btnPriceChartScaleLog.Location = new System.Drawing.Point(90, 0);
            this.btnPriceChartScaleLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnPriceChartScaleLog.Name = "btnPriceChartScaleLog";
            this.btnPriceChartScaleLog.Size = new System.Drawing.Size(85, 24);
            this.btnPriceChartScaleLog.TabIndex = 262;
            this.btnPriceChartScaleLog.TabStop = false;
            this.btnPriceChartScaleLog.Text = "logarithmic";
            this.btnPriceChartScaleLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPriceChartScaleLog.UseVisualStyleBackColor = false;
            this.btnPriceChartScaleLog.Click += new System.EventHandler(this.BtnChartPriceLog_Click);
            // 
            // btnPriceChartScaleLinear
            // 
            this.btnPriceChartScaleLinear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnPriceChartScaleLinear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPriceChartScaleLinear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnPriceChartScaleLinear.FlatAppearance.BorderSize = 0;
            this.btnPriceChartScaleLinear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPriceChartScaleLinear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnPriceChartScaleLinear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceChartScaleLinear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceChartScaleLinear.ForeColor = System.Drawing.Color.White;
            this.btnPriceChartScaleLinear.Location = new System.Drawing.Point(0, 0);
            this.btnPriceChartScaleLinear.Margin = new System.Windows.Forms.Padding(0);
            this.btnPriceChartScaleLinear.Name = "btnPriceChartScaleLinear";
            this.btnPriceChartScaleLinear.Size = new System.Drawing.Size(85, 24);
            this.btnPriceChartScaleLinear.TabIndex = 261;
            this.btnPriceChartScaleLinear.TabStop = false;
            this.btnPriceChartScaleLinear.Text = "linear";
            this.btnPriceChartScaleLinear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPriceChartScaleLinear.UseVisualStyleBackColor = false;
            this.btnPriceChartScaleLinear.Click += new System.EventHandler(this.BtnChartPrice_Click);
            // 
            // panelUniqueAddressesScaleButtons
            // 
            this.panelUniqueAddressesScaleButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelUniqueAddressesScaleButtons.Controls.Add(this.btnChartAddressScaleLog);
            this.panelUniqueAddressesScaleButtons.Controls.Add(this.btnChartAddressScaleLinear);
            this.panelUniqueAddressesScaleButtons.Location = new System.Drawing.Point(203, 32);
            this.panelUniqueAddressesScaleButtons.Name = "panelUniqueAddressesScaleButtons";
            this.panelUniqueAddressesScaleButtons.Size = new System.Drawing.Size(175, 24);
            this.panelUniqueAddressesScaleButtons.TabIndex = 258;
            // 
            // btnChartAddressScaleLog
            // 
            this.btnChartAddressScaleLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartAddressScaleLog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartAddressScaleLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartAddressScaleLog.FlatAppearance.BorderSize = 0;
            this.btnChartAddressScaleLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartAddressScaleLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartAddressScaleLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartAddressScaleLog.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnChartAddressScaleLog.ForeColor = System.Drawing.Color.White;
            this.btnChartAddressScaleLog.Location = new System.Drawing.Point(90, 0);
            this.btnChartAddressScaleLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartAddressScaleLog.Name = "btnChartAddressScaleLog";
            this.btnChartAddressScaleLog.Size = new System.Drawing.Size(85, 24);
            this.btnChartAddressScaleLog.TabIndex = 262;
            this.btnChartAddressScaleLog.TabStop = false;
            this.btnChartAddressScaleLog.Text = "logarithmic";
            this.btnChartAddressScaleLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartAddressScaleLog.UseVisualStyleBackColor = false;
            this.btnChartAddressScaleLog.Click += new System.EventHandler(this.BtnChartUniqueAddressesLog_Click);
            // 
            // btnChartAddressScaleLinear
            // 
            this.btnChartAddressScaleLinear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartAddressScaleLinear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartAddressScaleLinear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartAddressScaleLinear.FlatAppearance.BorderSize = 0;
            this.btnChartAddressScaleLinear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartAddressScaleLinear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartAddressScaleLinear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartAddressScaleLinear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartAddressScaleLinear.ForeColor = System.Drawing.Color.White;
            this.btnChartAddressScaleLinear.Location = new System.Drawing.Point(0, 0);
            this.btnChartAddressScaleLinear.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartAddressScaleLinear.Name = "btnChartAddressScaleLinear";
            this.btnChartAddressScaleLinear.Size = new System.Drawing.Size(85, 24);
            this.btnChartAddressScaleLinear.TabIndex = 261;
            this.btnChartAddressScaleLinear.TabStop = false;
            this.btnChartAddressScaleLinear.Text = "linear";
            this.btnChartAddressScaleLinear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartAddressScaleLinear.UseVisualStyleBackColor = false;
            this.btnChartAddressScaleLinear.Click += new System.EventHandler(this.BtnChartUniqueAddresses_Click);
            // 
            // btnChartUniqueAddresses
            // 
            this.btnChartUniqueAddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartUniqueAddresses.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartUniqueAddresses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartUniqueAddresses.FlatAppearance.BorderSize = 0;
            this.btnChartUniqueAddresses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUniqueAddresses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartUniqueAddresses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartUniqueAddresses.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartUniqueAddresses.ForeColor = System.Drawing.Color.White;
            this.btnChartUniqueAddresses.Location = new System.Drawing.Point(0, 224);
            this.btnChartUniqueAddresses.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartUniqueAddresses.Name = "btnChartUniqueAddresses";
            this.btnChartUniqueAddresses.Size = new System.Drawing.Size(100, 24);
            this.btnChartUniqueAddresses.TabIndex = 259;
            this.btnChartUniqueAddresses.TabStop = false;
            this.btnChartUniqueAddresses.Text = "addresses";
            this.btnChartUniqueAddresses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartUniqueAddresses.UseVisualStyleBackColor = false;
            this.btnChartUniqueAddresses.Click += new System.EventHandler(this.BtnChartUniqueAddresses_Click);
            // 
            // lblChartMousePositionData
            // 
            this.lblChartMousePositionData.AutoSize = true;
            this.lblChartMousePositionData.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartMousePositionData.Location = new System.Drawing.Point(713, 504);
            this.lblChartMousePositionData.Name = "lblChartMousePositionData";
            this.lblChartMousePositionData.Size = new System.Drawing.Size(81, 20);
            this.lblChartMousePositionData.TabIndex = 177;
            this.lblChartMousePositionData.Text = "label202";
            // 
            // panel78
            // 
            this.panel78.BackColor = System.Drawing.Color.Transparent;
            this.panel78.BackgroundImage = global::SATSuma.Properties.Resources.titleBGLongerOrange;
            this.panel78.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel78.Controls.Add(this.label217);
            this.panel78.Location = new System.Drawing.Point(146, 503);
            this.panel78.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(564, 23);
            this.panel78.TabIndex = 208;
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label217.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label217.ForeColor = System.Drawing.Color.Gray;
            this.label217.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label217.Location = new System.Drawing.Point(3, 2);
            this.label217.Margin = new System.Windows.Forms.Padding(0);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(102, 20);
            this.label217.TabIndex = 153;
            this.label217.Text = "Chart period";
            // 
            // btnChartBlockSize
            // 
            this.btnChartBlockSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartBlockSize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartBlockSize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartBlockSize.FlatAppearance.BorderSize = 0;
            this.btnChartBlockSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartBlockSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartBlockSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartBlockSize.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartBlockSize.ForeColor = System.Drawing.Color.White;
            this.btnChartBlockSize.Location = new System.Drawing.Point(0, 112);
            this.btnChartBlockSize.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartBlockSize.Name = "btnChartBlockSize";
            this.btnChartBlockSize.Size = new System.Drawing.Size(100, 24);
            this.btnChartBlockSize.TabIndex = 258;
            this.btnChartBlockSize.TabStop = false;
            this.btnChartBlockSize.Text = "block size";
            this.btnChartBlockSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartBlockSize.UseVisualStyleBackColor = false;
            this.btnChartBlockSize.Click += new System.EventHandler(this.BtnChartBlockSize_Click);
            // 
            // panelCirculationKey
            // 
            this.panelCirculationKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panelCirculationKey.Controls.Add(this.label222);
            this.panelCirculationKey.Controls.Add(this.label223);
            this.panelCirculationKey.Controls.Add(this.label229);
            this.panelCirculationKey.Controls.Add(this.label230);
            this.panelCirculationKey.Location = new System.Drawing.Point(494, 27);
            this.panelCirculationKey.Name = "panelCirculationKey";
            this.panelCirculationKey.Size = new System.Drawing.Size(252, 25);
            this.panelCirculationKey.TabIndex = 257;
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.BackColor = System.Drawing.Color.Transparent;
            this.label222.Font = new System.Drawing.Font("Consolas", 9F);
            this.label222.ForeColor = System.Drawing.Color.Orange;
            this.label222.Location = new System.Drawing.Point(130, 3);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(23, 18);
            this.label222.TabIndex = 251;
            this.label222.Text = "🟢";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.BackColor = System.Drawing.Color.Transparent;
            this.label223.Font = new System.Drawing.Font("Consolas", 9F);
            this.label223.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(38)))), ((int)(((byte)(19)))));
            this.label223.Location = new System.Drawing.Point(2, 3);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(23, 18);
            this.label223.TabIndex = 250;
            this.label223.Text = "🟢";
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label229.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label229.ForeColor = System.Drawing.Color.Silver;
            this.label229.Location = new System.Drawing.Point(150, 0);
            this.label229.Margin = new System.Windows.Forms.Padding(0);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(115, 20);
            this.label229.TabIndex = 212;
            this.label229.Text = "Already mined";
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label230.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label230.ForeColor = System.Drawing.Color.Silver;
            this.label230.Location = new System.Drawing.Point(22, 0);
            this.label230.Margin = new System.Windows.Forms.Padding(0);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(97, 20);
            this.label230.TabIndex = 211;
            this.label230.Text = "To be mined";
            // 
            // panelFeeRatesKey
            // 
            this.panelFeeRatesKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panelFeeRatesKey.Controls.Add(this.label216);
            this.panelFeeRatesKey.Controls.Add(this.label215);
            this.panelFeeRatesKey.Controls.Add(this.label214);
            this.panelFeeRatesKey.Controls.Add(this.label213);
            this.panelFeeRatesKey.Controls.Add(this.label212);
            this.panelFeeRatesKey.Controls.Add(this.label211);
            this.panelFeeRatesKey.Controls.Add(this.label210);
            this.panelFeeRatesKey.Controls.Add(this.label209);
            this.panelFeeRatesKey.Controls.Add(this.label208);
            this.panelFeeRatesKey.Controls.Add(this.label207);
            this.panelFeeRatesKey.Controls.Add(this.label206);
            this.panelFeeRatesKey.Controls.Add(this.label205);
            this.panelFeeRatesKey.Controls.Add(this.label203);
            this.panelFeeRatesKey.Controls.Add(this.label202);
            this.panelFeeRatesKey.Location = new System.Drawing.Point(180, 27);
            this.panelFeeRatesKey.Name = "panelFeeRatesKey";
            this.panelFeeRatesKey.Size = new System.Drawing.Size(539, 25);
            this.panelFeeRatesKey.TabIndex = 181;
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.BackColor = System.Drawing.Color.Transparent;
            this.label216.Font = new System.Drawing.Font("Consolas", 9F);
            this.label216.ForeColor = System.Drawing.Color.DarkGray;
            this.label216.Location = new System.Drawing.Point(399, 3);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(23, 18);
            this.label216.TabIndex = 256;
            this.label216.Text = "🟢";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.BackColor = System.Drawing.Color.Transparent;
            this.label215.Font = new System.Drawing.Font("Consolas", 9F);
            this.label215.ForeColor = System.Drawing.Color.Red;
            this.label215.Location = new System.Drawing.Point(343, 3);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(23, 18);
            this.label215.TabIndex = 255;
            this.label215.Text = "🟢";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.BackColor = System.Drawing.Color.Transparent;
            this.label214.Font = new System.Drawing.Font("Consolas", 9F);
            this.label214.ForeColor = System.Drawing.Color.Orange;
            this.label214.Location = new System.Drawing.Point(285, 3);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(23, 18);
            this.label214.TabIndex = 254;
            this.label214.Text = "🟢";
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.BackColor = System.Drawing.Color.Transparent;
            this.label213.Font = new System.Drawing.Font("Consolas", 9F);
            this.label213.ForeColor = System.Drawing.Color.Yellow;
            this.label213.Location = new System.Drawing.Point(207, 3);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(23, 18);
            this.label213.TabIndex = 253;
            this.label213.Text = "🟢";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.BackColor = System.Drawing.Color.Transparent;
            this.label212.Font = new System.Drawing.Font("Consolas", 9F);
            this.label212.ForeColor = System.Drawing.Color.LimeGreen;
            this.label212.Location = new System.Drawing.Point(147, 3);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(23, 18);
            this.label212.TabIndex = 252;
            this.label212.Text = "🟢";
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.BackColor = System.Drawing.Color.Transparent;
            this.label211.Font = new System.Drawing.Font("Consolas", 9F);
            this.label211.ForeColor = System.Drawing.Color.Blue;
            this.label211.Location = new System.Drawing.Point(89, 3);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(23, 18);
            this.label211.TabIndex = 251;
            this.label211.Text = "🟢";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.BackColor = System.Drawing.Color.Transparent;
            this.label210.Font = new System.Drawing.Font("Consolas", 9F);
            this.label210.ForeColor = System.Drawing.Color.Indigo;
            this.label210.Location = new System.Drawing.Point(0, 3);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(23, 18);
            this.label210.TabIndex = 250;
            this.label210.Text = "🟢";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label209.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label209.ForeColor = System.Drawing.Color.Silver;
            this.label209.Location = new System.Drawing.Point(363, 0);
            this.label209.Margin = new System.Windows.Forms.Padding(0);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(39, 20);
            this.label209.TabIndex = 217;
            this.label209.Text = "90th";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label208.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label208.ForeColor = System.Drawing.Color.Silver;
            this.label208.Location = new System.Drawing.Point(419, 0);
            this.label208.Margin = new System.Windows.Forms.Padding(0);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(77, 20);
            this.label208.TabIndex = 216;
            this.label208.Text = "maximum";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label207.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label207.ForeColor = System.Drawing.Color.Silver;
            this.label207.Location = new System.Drawing.Point(305, 0);
            this.label207.Margin = new System.Windows.Forms.Padding(0);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(39, 20);
            this.label207.TabIndex = 215;
            this.label207.Text = "75th";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label206.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label206.ForeColor = System.Drawing.Color.Silver;
            this.label206.Location = new System.Drawing.Point(227, 0);
            this.label206.Margin = new System.Windows.Forms.Padding(0);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(64, 20);
            this.label206.TabIndex = 214;
            this.label206.Text = "median";
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label205.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label205.ForeColor = System.Drawing.Color.Silver;
            this.label205.Location = new System.Drawing.Point(167, 0);
            this.label205.Margin = new System.Windows.Forms.Padding(0);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(39, 20);
            this.label205.TabIndex = 213;
            this.label205.Text = "25th";
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label203.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label203.ForeColor = System.Drawing.Color.Silver;
            this.label203.Location = new System.Drawing.Point(109, 0);
            this.label203.Margin = new System.Windows.Forms.Padding(0);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(39, 20);
            this.label203.TabIndex = 212;
            this.label203.Text = "10th";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label202.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label202.ForeColor = System.Drawing.Color.Silver;
            this.label202.Location = new System.Drawing.Point(22, 0);
            this.label202.Margin = new System.Windows.Forms.Padding(0);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(72, 20);
            this.label202.TabIndex = 211;
            this.label202.Text = "minimum";
            // 
            // btnChartCirculation
            // 
            this.btnChartCirculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartCirculation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartCirculation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartCirculation.FlatAppearance.BorderSize = 0;
            this.btnChartCirculation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartCirculation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartCirculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartCirculation.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartCirculation.ForeColor = System.Drawing.Color.White;
            this.btnChartCirculation.Location = new System.Drawing.Point(0, 196);
            this.btnChartCirculation.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartCirculation.Name = "btnChartCirculation";
            this.btnChartCirculation.Size = new System.Drawing.Size(100, 24);
            this.btnChartCirculation.TabIndex = 179;
            this.btnChartCirculation.TabStop = false;
            this.btnChartCirculation.Text = "circulation";
            this.btnChartCirculation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartCirculation.UseVisualStyleBackColor = false;
            this.btnChartCirculation.Click += new System.EventHandler(this.BtnChartCirculation_Click);
            // 
            // btnChartFeeRates
            // 
            this.btnChartFeeRates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartFeeRates.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartFeeRates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartFeeRates.FlatAppearance.BorderSize = 0;
            this.btnChartFeeRates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartFeeRates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartFeeRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartFeeRates.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartFeeRates.ForeColor = System.Drawing.Color.White;
            this.btnChartFeeRates.Location = new System.Drawing.Point(0, 28);
            this.btnChartFeeRates.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartFeeRates.Name = "btnChartFeeRates";
            this.btnChartFeeRates.Size = new System.Drawing.Size(100, 24);
            this.btnChartFeeRates.TabIndex = 178;
            this.btnChartFeeRates.TabStop = false;
            this.btnChartFeeRates.Text = "fee rates";
            this.btnChartFeeRates.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartFeeRates.UseVisualStyleBackColor = false;
            this.btnChartFeeRates.Click += new System.EventHandler(this.BtnChartFeeRates_Click);
            // 
            // btnChartPeriodAll
            // 
            this.btnChartPeriodAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriodAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriodAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriodAll.FlatAppearance.BorderSize = 0;
            this.btnChartPeriodAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriodAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriodAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriodAll.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriodAll.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriodAll.Location = new System.Drawing.Point(704, 531);
            this.btnChartPeriodAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriodAll.Name = "btnChartPeriodAll";
            this.btnChartPeriodAll.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriodAll.TabIndex = 176;
            this.btnChartPeriodAll.TabStop = false;
            this.btnChartPeriodAll.Text = "all";
            this.btnChartPeriodAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriodAll.UseVisualStyleBackColor = false;
            this.btnChartPeriodAll.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod3y
            // 
            this.btnChartPeriod3y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod3y.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod3y.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod3y.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod3y.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3y.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod3y.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod3y.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod3y.Location = new System.Drawing.Point(642, 531);
            this.btnChartPeriod3y.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod3y.Name = "btnChartPeriod3y";
            this.btnChartPeriod3y.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod3y.TabIndex = 175;
            this.btnChartPeriod3y.TabStop = false;
            this.btnChartPeriod3y.Text = "3y";
            this.btnChartPeriod3y.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod3y.UseVisualStyleBackColor = false;
            this.btnChartPeriod3y.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod2y
            // 
            this.btnChartPeriod2y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod2y.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod2y.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod2y.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod2y.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod2y.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod2y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod2y.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod2y.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod2y.Location = new System.Drawing.Point(580, 531);
            this.btnChartPeriod2y.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod2y.Name = "btnChartPeriod2y";
            this.btnChartPeriod2y.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod2y.TabIndex = 174;
            this.btnChartPeriod2y.TabStop = false;
            this.btnChartPeriod2y.Text = "2y";
            this.btnChartPeriod2y.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod2y.UseVisualStyleBackColor = false;
            this.btnChartPeriod2y.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod1y
            // 
            this.btnChartPeriod1y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod1y.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod1y.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod1y.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod1y.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1y.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod1y.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod1y.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod1y.Location = new System.Drawing.Point(518, 531);
            this.btnChartPeriod1y.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod1y.Name = "btnChartPeriod1y";
            this.btnChartPeriod1y.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod1y.TabIndex = 173;
            this.btnChartPeriod1y.TabStop = false;
            this.btnChartPeriod1y.Text = "1y";
            this.btnChartPeriod1y.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod1y.UseVisualStyleBackColor = false;
            this.btnChartPeriod1y.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod6m
            // 
            this.btnChartPeriod6m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod6m.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod6m.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod6m.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod6m.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod6m.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod6m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod6m.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod6m.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod6m.Location = new System.Drawing.Point(456, 531);
            this.btnChartPeriod6m.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod6m.Name = "btnChartPeriod6m";
            this.btnChartPeriod6m.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod6m.TabIndex = 172;
            this.btnChartPeriod6m.TabStop = false;
            this.btnChartPeriod6m.Text = "6m";
            this.btnChartPeriod6m.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod6m.UseVisualStyleBackColor = false;
            this.btnChartPeriod6m.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod3m
            // 
            this.btnChartPeriod3m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod3m.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod3m.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod3m.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod3m.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3m.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod3m.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod3m.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod3m.Location = new System.Drawing.Point(394, 531);
            this.btnChartPeriod3m.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod3m.Name = "btnChartPeriod3m";
            this.btnChartPeriod3m.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod3m.TabIndex = 171;
            this.btnChartPeriod3m.TabStop = false;
            this.btnChartPeriod3m.Text = "3m";
            this.btnChartPeriod3m.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod3m.UseVisualStyleBackColor = false;
            this.btnChartPeriod3m.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod1m
            // 
            this.btnChartPeriod1m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod1m.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod1m.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod1m.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod1m.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1m.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod1m.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod1m.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod1m.Location = new System.Drawing.Point(332, 531);
            this.btnChartPeriod1m.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod1m.Name = "btnChartPeriod1m";
            this.btnChartPeriod1m.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod1m.TabIndex = 170;
            this.btnChartPeriod1m.TabStop = false;
            this.btnChartPeriod1m.Text = "1m";
            this.btnChartPeriod1m.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod1m.UseVisualStyleBackColor = false;
            this.btnChartPeriod1m.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod1w
            // 
            this.btnChartPeriod1w.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod1w.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod1w.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod1w.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod1w.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1w.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod1w.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod1w.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod1w.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod1w.Location = new System.Drawing.Point(270, 531);
            this.btnChartPeriod1w.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod1w.Name = "btnChartPeriod1w";
            this.btnChartPeriod1w.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod1w.TabIndex = 169;
            this.btnChartPeriod1w.TabStop = false;
            this.btnChartPeriod1w.Text = "1w";
            this.btnChartPeriod1w.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod1w.UseVisualStyleBackColor = false;
            this.btnChartPeriod1w.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod3d
            // 
            this.btnChartPeriod3d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod3d.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod3d.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod3d.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod3d.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3d.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod3d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod3d.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod3d.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod3d.Location = new System.Drawing.Point(208, 531);
            this.btnChartPeriod3d.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod3d.Name = "btnChartPeriod3d";
            this.btnChartPeriod3d.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod3d.TabIndex = 168;
            this.btnChartPeriod3d.TabStop = false;
            this.btnChartPeriod3d.Text = "3d";
            this.btnChartPeriod3d.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod3d.UseVisualStyleBackColor = false;
            this.btnChartPeriod3d.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartPeriod24h
            // 
            this.btnChartPeriod24h.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPeriod24h.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPeriod24h.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPeriod24h.FlatAppearance.BorderSize = 0;
            this.btnChartPeriod24h.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod24h.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPeriod24h.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPeriod24h.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPeriod24h.ForeColor = System.Drawing.Color.White;
            this.btnChartPeriod24h.Location = new System.Drawing.Point(146, 531);
            this.btnChartPeriod24h.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPeriod24h.Name = "btnChartPeriod24h";
            this.btnChartPeriod24h.Size = new System.Drawing.Size(58, 24);
            this.btnChartPeriod24h.TabIndex = 167;
            this.btnChartPeriod24h.TabStop = false;
            this.btnChartPeriod24h.Text = "24h";
            this.btnChartPeriod24h.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPeriod24h.UseVisualStyleBackColor = false;
            this.btnChartPeriod24h.Click += new System.EventHandler(this.BtnChartPeriod_Click);
            // 
            // btnChartBlockFees
            // 
            this.btnChartBlockFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartBlockFees.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartBlockFees.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartBlockFees.FlatAppearance.BorderSize = 0;
            this.btnChartBlockFees.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartBlockFees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartBlockFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartBlockFees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartBlockFees.ForeColor = System.Drawing.Color.White;
            this.btnChartBlockFees.Location = new System.Drawing.Point(0, 56);
            this.btnChartBlockFees.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartBlockFees.Name = "btnChartBlockFees";
            this.btnChartBlockFees.Size = new System.Drawing.Size(100, 24);
            this.btnChartBlockFees.TabIndex = 166;
            this.btnChartBlockFees.TabStop = false;
            this.btnChartBlockFees.Text = "block fees";
            this.btnChartBlockFees.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartBlockFees.UseVisualStyleBackColor = false;
            this.btnChartBlockFees.Click += new System.EventHandler(this.BtnChartBlockFees_Click);
            // 
            // btnChartReward
            // 
            this.btnChartReward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartReward.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartReward.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartReward.FlatAppearance.BorderSize = 0;
            this.btnChartReward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartReward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartReward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartReward.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartReward.ForeColor = System.Drawing.Color.White;
            this.btnChartReward.Location = new System.Drawing.Point(0, 84);
            this.btnChartReward.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartReward.Name = "btnChartReward";
            this.btnChartReward.Size = new System.Drawing.Size(100, 24);
            this.btnChartReward.TabIndex = 165;
            this.btnChartReward.TabStop = false;
            this.btnChartReward.Text = "block reward";
            this.btnChartReward.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartReward.UseVisualStyleBackColor = false;
            this.btnChartReward.Click += new System.EventHandler(this.BtnChartReward_Click);
            // 
            // btnChartPrice
            // 
            this.btnChartPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartPrice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartPrice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartPrice.FlatAppearance.BorderSize = 0;
            this.btnChartPrice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPrice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartPrice.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartPrice.ForeColor = System.Drawing.Color.White;
            this.btnChartPrice.Location = new System.Drawing.Point(0, 500);
            this.btnChartPrice.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPrice.Name = "btnChartPrice";
            this.btnChartPrice.Size = new System.Drawing.Size(100, 24);
            this.btnChartPrice.TabIndex = 164;
            this.btnChartPrice.TabStop = false;
            this.btnChartPrice.Text = "price";
            this.btnChartPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartPrice.UseVisualStyleBackColor = false;
            this.btnChartPrice.Click += new System.EventHandler(this.BtnChartPrice_Click);
            // 
            // btnChartDifficulty
            // 
            this.btnChartDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartDifficulty.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartDifficulty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartDifficulty.FlatAppearance.BorderSize = 0;
            this.btnChartDifficulty.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartDifficulty.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartDifficulty.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartDifficulty.ForeColor = System.Drawing.Color.White;
            this.btnChartDifficulty.Location = new System.Drawing.Point(0, 168);
            this.btnChartDifficulty.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartDifficulty.Name = "btnChartDifficulty";
            this.btnChartDifficulty.Size = new System.Drawing.Size(100, 24);
            this.btnChartDifficulty.TabIndex = 163;
            this.btnChartDifficulty.TabStop = false;
            this.btnChartDifficulty.Text = "difficulty";
            this.btnChartDifficulty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartDifficulty.UseVisualStyleBackColor = false;
            this.btnChartDifficulty.Click += new System.EventHandler(this.BtnChartDifficulty_Click);
            // 
            // btnChartHashrate
            // 
            this.btnChartHashrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartHashrate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartHashrate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartHashrate.FlatAppearance.BorderSize = 0;
            this.btnChartHashrate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartHashrate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartHashrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartHashrate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartHashrate.ForeColor = System.Drawing.Color.White;
            this.btnChartHashrate.Location = new System.Drawing.Point(0, 140);
            this.btnChartHashrate.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartHashrate.Name = "btnChartHashrate";
            this.btnChartHashrate.Size = new System.Drawing.Size(100, 24);
            this.btnChartHashrate.TabIndex = 162;
            this.btnChartHashrate.TabStop = false;
            this.btnChartHashrate.Text = "hashrate";
            this.btnChartHashrate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartHashrate.UseVisualStyleBackColor = false;
            this.btnChartHashrate.Click += new System.EventHandler(this.BtnChartHashrate_Click);
            // 
            // btnChartLightningCapacity
            // 
            this.btnChartLightningCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartLightningCapacity.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartLightningCapacity.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartLightningCapacity.FlatAppearance.BorderSize = 0;
            this.btnChartLightningCapacity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartLightningCapacity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartLightningCapacity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartLightningCapacity.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartLightningCapacity.ForeColor = System.Drawing.Color.White;
            this.btnChartLightningCapacity.Location = new System.Drawing.Point(0, 404);
            this.btnChartLightningCapacity.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartLightningCapacity.Name = "btnChartLightningCapacity";
            this.btnChartLightningCapacity.Size = new System.Drawing.Size(100, 24);
            this.btnChartLightningCapacity.TabIndex = 271;
            this.btnChartLightningCapacity.TabStop = false;
            this.btnChartLightningCapacity.Text = "capacity";
            this.btnChartLightningCapacity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartLightningCapacity.UseVisualStyleBackColor = false;
            this.btnChartLightningCapacity.Click += new System.EventHandler(this.btnChartLightningCapacity_Click);
            // 
            // btnChartLightningChannels
            // 
            this.btnChartLightningChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnChartLightningChannels.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChartLightningChannels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(72)))), ((int)(((byte)(9)))));
            this.btnChartLightningChannels.FlatAppearance.BorderSize = 0;
            this.btnChartLightningChannels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartLightningChannels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(92)))), ((int)(((byte)(29)))));
            this.btnChartLightningChannels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartLightningChannels.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartLightningChannels.ForeColor = System.Drawing.Color.White;
            this.btnChartLightningChannels.Location = new System.Drawing.Point(0, 432);
            this.btnChartLightningChannels.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartLightningChannels.Name = "btnChartLightningChannels";
            this.btnChartLightningChannels.Size = new System.Drawing.Size(100, 24);
            this.btnChartLightningChannels.TabIndex = 272;
            this.btnChartLightningChannels.TabStop = false;
            this.btnChartLightningChannels.Text = "channels";
            this.btnChartLightningChannels.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChartLightningChannels.UseVisualStyleBackColor = false;
            this.btnChartLightningChannels.Click += new System.EventHandler(this.btnChartLightningChannels_Click);
            // 
            // SATSuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BackgroundImage = global::SATSuma.Properties.Resources.AppBackground2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(800, 781);
            this.Controls.Add(this.panelCharts);
            this.Controls.Add(this.panelBitcoinDashboard);
            this.Controls.Add(this.panelBlock);
            this.Controls.Add(this.panelBlockList);
            this.Controls.Add(this.panelTransaction);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelCurrency);
            this.Controls.Add(this.panelXpub);
            this.Controls.Add(this.panelAddress);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelAppearance);
            this.Controls.Add(this.panelBookmarks);
            this.Controls.Add(this.headerNetworkName);
            this.Controls.Add(this.headerNetworkStatusLight);
            this.Controls.Add(this.panelFees);
            this.Controls.Add(this.panelHeaderBlockHeight);
            this.Controls.Add(this.panelAddToBookmarks);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.panelLightningDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSatsumaTitle);
            this.Controls.Add(this.lblNowViewing);
            this.Controls.Add(this.panelHeaderPrice);
            this.Controls.Add(this.btnAddToBookmarks);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.panelRefreshStatusBar);
            this.Controls.Add(this.pictureBoxSatsumaLogo);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.pictureBoxLoadingAnimation);
            this.Controls.Add(this.btnMinimise);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMoveWindow);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SATSuma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SATSuma";
            this.Load += new System.EventHandler(this.SATSuma_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHashrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDifficultyChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderHashrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockListDifficultyChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockListHashrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderPriceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPriceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderFeeRatesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartFeeRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockScreenChartBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChartCirculation)).EndInit();
            this.panelBitcoinDashboard.ResumeLayout(false);
            this.panelBitcoinDashboard.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelLightningDashboard.ResumeLayout(false);
            this.panelLightningDashboard.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            this.panelOwnNodeAddressTXInfo.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel44.PerformLayout();
            this.panel43.ResumeLayout(false);
            this.panel43.PerformLayout();
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.panel41.ResumeLayout(false);
            this.panel41.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddressQRCodePicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingAnimation)).EndInit();
            this.panelBlock.ResumeLayout(false);
            this.panelBlock.PerformLayout();
            this.panelOwnNodeBlockTXInfo.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel56.PerformLayout();
            this.panel55.ResumeLayout(false);
            this.panel55.PerformLayout();
            this.panel54.ResumeLayout(false);
            this.panel54.PerformLayout();
            this.panel53.ResumeLayout(false);
            this.panel53.PerformLayout();
            this.panel52.ResumeLayout(false);
            this.panel52.PerformLayout();
            this.panel51.ResumeLayout(false);
            this.panel51.PerformLayout();
            this.panel50.ResumeLayout(false);
            this.panel50.PerformLayout();
            this.panel49.ResumeLayout(false);
            this.panel49.PerformLayout();
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.panel46.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSatsumaLogo)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelBlockList.ResumeLayout(false);
            this.panelBlockList.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panelRefreshStatusBar.ResumeLayout(false);
            this.panelRefreshStatusBar.PerformLayout();
            this.panelTransaction.ResumeLayout(false);
            this.panelTransaction.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panelTransactionOutputs.ResumeLayout(false);
            this.panelTransactionInputs.ResumeLayout(false);
            this.panelTransactionHeadline.ResumeLayout(false);
            this.panelTransactionHeadline.PerformLayout();
            this.panelTransactionDiagram.ResumeLayout(false);
            this.panelTransactionDiagram.PerformLayout();
            this.panelTransactionMiddle.ResumeLayout(false);
            this.panelXpub.ResumeLayout(false);
            this.panelXpub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUpDownDerivationPathsToCheck)).EndInit();
            this.panel30.ResumeLayout(false);
            this.panelXpubContainer.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panelAddToBookmarks.ResumeLayout(false);
            this.panelAddToBookmarks.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panelFees.ResumeLayout(false);
            this.panelFees.PerformLayout();
            this.panel57.ResumeLayout(false);
            this.panel57.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.panelBookmarks.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panelBookmarksContainer.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panelHeaderPrice.ResumeLayout(false);
            this.panelHeaderPrice.PerformLayout();
            this.panel38.ResumeLayout(false);
            this.panel38.PerformLayout();
            this.panelHeaderBlockHeight.ResumeLayout(false);
            this.panelHeaderBlockHeight.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.panelCurrency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panel77.ResumeLayout(false);
            this.panel77.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDashboardRefresh)).EndInit();
            this.panel76.ResumeLayout(false);
            this.panel76.PerformLayout();
            this.panel74.ResumeLayout(false);
            this.panel74.PerformLayout();
            this.panel75.ResumeLayout(false);
            this.panel75.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            this.panel58.ResumeLayout(false);
            this.panel58.PerformLayout();
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            this.panelAppearance.ResumeLayout(false);
            this.panelAppearance.PerformLayout();
            this.panel73.ResumeLayout(false);
            this.panel73.PerformLayout();
            this.panel71.ResumeLayout(false);
            this.panel71.PerformLayout();
            this.panel72.ResumeLayout(false);
            this.panel72.PerformLayout();
            this.panel70.ResumeLayout(false);
            this.panel70.PerformLayout();
            this.panel69.ResumeLayout(false);
            this.panel69.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomImage)).EndInit();
            this.panel68.ResumeLayout(false);
            this.panel68.PerformLayout();
            this.panel67.ResumeLayout(false);
            this.panel67.PerformLayout();
            this.panel66.ResumeLayout(false);
            this.panel66.PerformLayout();
            this.panel65.ResumeLayout(false);
            this.panel65.PerformLayout();
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            this.panel63.ResumeLayout(false);
            this.panel63.PerformLayout();
            this.panel62.ResumeLayout(false);
            this.panel62.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBTCDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenesis)).EndInit();
            this.panel60.ResumeLayout(false);
            this.panel60.PerformLayout();
            this.panelCharts.ResumeLayout(false);
            this.panelCharts.PerformLayout();
            this.panel81.ResumeLayout(false);
            this.panel81.PerformLayout();
            this.panel80.ResumeLayout(false);
            this.panel80.PerformLayout();
            this.panelLightningNodeNetwork.ResumeLayout(false);
            this.panelLightningNodeNetwork.PerformLayout();
            this.panel79.ResumeLayout(false);
            this.panel79.PerformLayout();
            this.panelChartUTXOScaleButtons.ResumeLayout(false);
            this.panelPriceScaleButtons.ResumeLayout(false);
            this.panelUniqueAddressesScaleButtons.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel78.PerformLayout();
            this.panelCirculationKey.ResumeLayout(false);
            this.panelCirculationKey.PerformLayout();
            this.panelFeeRatesKey.ResumeLayout(false);
            this.panelFeeRatesKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1Sec;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBlockNumber;
        private System.Windows.Forms.Timer timerAPIRefreshPeriod;
        private System.Windows.Forms.Button btnMinimise;
        private System.Windows.Forms.Button btnMoveWindow;
        private System.Windows.Forms.Label lblRefreshSuccessOrFailMessage;
        private System.Windows.Forms.Label lblStatusLight;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label lblElapsedSinceUpdate;
        private System.Windows.Forms.Panel panelBitcoinDashboard;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblBlockchainSize;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblNodes;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblBlocksIn24Hours;
        private System.Windows.Forms.Label lblNextBlockTotalFees;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblNextBlockMinMaxFee;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTransInNextBlock;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl24HourBTCSent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl24HourTransCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTXInMempool;
        private System.Windows.Forms.Label lblMarketCapLabel;
        private System.Windows.Forms.Label lblMarketCapUSD;
        private System.Windows.Forms.Label lblMoscowTimeLabel;
        private System.Windows.Forms.Label lblMoscowTime;
        private System.Windows.Forms.Label lblPriceLabel;
        private System.Windows.Forms.Label lblPriceUSD;
        private System.Windows.Forms.Panel panelLightningDashboard;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lblTotalCapacity;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lblUnknownCapacity;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label lblTorCapacity;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lblClearnetCapacity;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label capacityLabel1;
        private System.Windows.Forms.Label capacityLabel2;
        private System.Windows.Forms.Label aliasLabel2;
        private System.Windows.Forms.Label aliasLabel1;
        private System.Windows.Forms.Label capacityLabel9;
        private System.Windows.Forms.Label capacityLabel10;
        private System.Windows.Forms.Label aliasLabel10;
        private System.Windows.Forms.Label aliasLabel9;
        private System.Windows.Forms.Label capacityLabel7;
        private System.Windows.Forms.Label capacityLabel8;
        private System.Windows.Forms.Label aliasLabel8;
        private System.Windows.Forms.Label aliasLabel7;
        private System.Windows.Forms.Label capacityLabel5;
        private System.Windows.Forms.Label capacityLabel6;
        private System.Windows.Forms.Label aliasLabel6;
        private System.Windows.Forms.Label aliasLabel5;
        private System.Windows.Forms.Label capacityLabel3;
        private System.Windows.Forms.Label capacityLabel4;
        private System.Windows.Forms.Label aliasLabel4;
        private System.Windows.Forms.Label aliasLabel3;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label channelLabel9;
        private System.Windows.Forms.Label channelLabel10;
        private System.Windows.Forms.Label aliasConnLabel10;
        private System.Windows.Forms.Label aliasConnLabel9;
        private System.Windows.Forms.Label channelLabel7;
        private System.Windows.Forms.Label channelLabel8;
        private System.Windows.Forms.Label aliasConnLabel8;
        private System.Windows.Forms.Label aliasConnLabel7;
        private System.Windows.Forms.Label channelLabel5;
        private System.Windows.Forms.Label channelLabel6;
        private System.Windows.Forms.Label aliasConnLabel6;
        private System.Windows.Forms.Label aliasConnLabel5;
        private System.Windows.Forms.Label channelLabel3;
        private System.Windows.Forms.Label channelLabel4;
        private System.Windows.Forms.Label aliasConnLabel4;
        private System.Windows.Forms.Label aliasConnLabel3;
        private System.Windows.Forms.Label channelLabel1;
        private System.Windows.Forms.Label channelLabel2;
        private System.Windows.Forms.Label aliasConnLabel2;
        private System.Windows.Forms.Label aliasConnLabel1;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblUnannouncedNodes;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lblClearnetTorNodes;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblClearnetNodes;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lblNodeCount;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblTorNodes;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lblMedBaseFeeTokens;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lblMedFeeRate;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblMedCapacity;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lblAverageBaseFeeMtokens;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblAverageFeeRate;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblAverageCapacity;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblChannelCount;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label lblHalveningBlock;
        private System.Windows.Forms.Label lblEstimatedHalvingDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblHalvingSecondsRemaining;
        private System.Windows.Forms.Panel panelAddress;
        private System.Windows.Forms.Label lblAddressType;
        private System.Windows.Forms.TextBox textboxSubmittedAddress;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label lblAddressConfirmedTransactionCount;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label lblAddressConfirmedUnspent;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label lblAddressConfirmedSpent;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblAddressConfirmedReceived;
        private System.Windows.Forms.PictureBox AddressQRCodePicturebox;
        private System.Windows.Forms.Label lblAddressConfirmedUnspentOutputs;
        private System.Windows.Forms.Label lblAddressConfirmedSpentOutputs;
        private System.Windows.Forms.Label lblAddressConfirmedReceivedOutputs;
        private System.Windows.Forms.ListView listViewAddressTransactions;
        private System.Windows.Forms.Button btnNextAddressTransactions;
        private System.Windows.Forms.Button btnFirstAddressTransaction;
        private System.Windows.Forms.Label lblAddressTXPositionInList;
        private System.Windows.Forms.ImageList imageListUpDownArrows;
        private System.Windows.Forms.Button BtnViewTransactionFromAddress;
        private System.Windows.Forms.Button BtnViewBlockFromAddress;
        private System.Windows.Forms.Button btnShowAllTX;
        private System.Windows.Forms.Button btnShowConfirmedTX;
        private System.Windows.Forms.Button btnShowUnconfirmedTX;
        private System.Windows.Forms.PictureBox pictureBoxLoadingAnimation;
        private System.Windows.Forms.Panel panelBlock;
        private System.Windows.Forms.TextBox textBoxSubmittedBlockNumber;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label lblBlockHash;
        private System.Windows.Forms.Label lblMiner;
        private System.Windows.Forms.Label lblBlockAverageFee;
        private System.Windows.Forms.Label lblNumberOfTXInBlock;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.Label lblBlockWeight;
        private System.Windows.Forms.Label lblSizeOfBlock;
        private System.Windows.Forms.Label lblBlockFeeRangeAndMedianFee;
        private System.Windows.Forms.Label lblBlockTime;
        private System.Windows.Forms.Button btnPreviousBlockTransactions;
        private System.Windows.Forms.Button btnNextBlockTransactions;
        private System.Windows.Forms.Label lblBlockTXPositionInList;
        private System.Windows.Forms.ListView listViewBlockTransactions;
        private System.Windows.Forms.Button btnViewTransactionFromBlock;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblNonce;
        private System.Windows.Forms.PictureBox pictureBoxSatsumaLogo;
        private System.Windows.Forms.Label lblSatsumaTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMenuSplash;
        private System.Windows.Forms.Button btnMenuBlock;
        private System.Windows.Forms.Button btnMenuAddress;
        private System.Windows.Forms.Button btnMenuBitcoinDashboard;
        private System.Windows.Forms.Button btnMenuLightningDashboard;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Button btnPreviousBlock;
        private System.Windows.Forms.Button btnNextBlock;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label lblBlockRewardAfterHalving;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblHodlingAddresses;
        private System.Windows.Forms.Label lblAvgTimeBetweenBlocks;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAvgNoTransactions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNextDiffAdjBlock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHashesToSolve;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBTCInCirc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblEstHashrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDifficultyAdjEst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBlockReward;
        private System.Windows.Forms.Panel panelBlockList;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblBlockListNonce;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label lblBlockListTotalFees;
        private System.Windows.Forms.Button btnViewBlockFromBlockList;
        private System.Windows.Forms.ListView listViewBlockList;
        private System.Windows.Forms.Label lblBlockListPositionInList;
        private System.Windows.Forms.Button btnNewer15Blocks;
        private System.Windows.Forms.Button btnOlder15Blocks;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label lblBlockListBlockTime;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label lblBlockListBlockFeeRangeAndMedianFee;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label lblBlockListMiner;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label lblBlockListAverageFee;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label lblBlockListTransactionCount;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label lblBlockListReward;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label lblBlockListBlockWeight;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label lblBlockListBlockSize;
        private System.Windows.Forms.TextBox textBoxBlockHeightToStartListFrom;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Button btnMenuBlockList;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label lblBlockListBlockHash;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label lblBlockListTotalOutputs;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label lblBlockListTotalInputs;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label lblBlockListAverageTransactionSize;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label lblBlockListVersion;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblBlockListBlockHeight;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panelRefreshStatusBar;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label lblBlockListBlockReward;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label lblBlockListEstHashRate;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label lblBlockListNextDifficultyAdjustment;
        private System.Windows.Forms.Label lblBlockListAvgTimeBetweenBlocks;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label lblBlockListNextDiffAdjBlock;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label lblBlockListAttemptsToSolveBlock;
        private System.Windows.Forms.Label lblBlockListTotalFeesInNextBlock;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label lblBlockListMinMaxInFeeNextBlock;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label lblBlockListTXInNextBlock;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label lblBlockListTXInMempool;
        private System.Windows.Forms.Button btnMenuTransaction;
        private System.Windows.Forms.Panel panelTransaction;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label lblTransactionVersion;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label lblTransactionFee;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label lblTransactionBlockHeight;
        private System.Windows.Forms.Label lblTransactionInputCount;
        private System.Windows.Forms.Label lblTransactionOutputCount;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label lblTransactionBlockTime;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label lblTransactionLockTime;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Label lblTransactionWeight;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Label lblTransactionSize;
        private System.Windows.Forms.TextBox textBoxTransactionID;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.Panel panelTransactionDiagram;
        private System.Windows.Forms.Panel panelTransactionMiddle;
        private System.Windows.Forms.Panel panelTransactionHeadline;
        private System.Windows.Forms.Label lblCoinbase;
        private System.Windows.Forms.Label lblTotalInputValue;
        private System.Windows.Forms.Label lblTotalOutputValue;
        private System.Windows.Forms.Label lblInvalidTransaction;
        private System.Windows.Forms.ListView listViewTransactionInputs;
        private System.Windows.Forms.Button btnTransactionInputsUp;
        private System.Windows.Forms.Button btnTransactionInputDown;
        public System.Windows.Forms.Panel panelTransactionInputs;
        private System.Windows.Forms.Timer TXInScrollTimer;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Button btnTransactionOutputsUp;
        private System.Windows.Forms.Button btnTransactionOutputsDown;
        public System.Windows.Forms.Panel panelTransactionOutputs;
        private System.Windows.Forms.ListView listViewTransactionOutputs;
        private System.Windows.Forms.Timer TXOutScrollTimer;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Button btnViewAddressFromTXOutput;
        private System.Windows.Forms.Button btnViewAddressFromTXInput;
        private System.Windows.Forms.Button btnMenuXpub;
        private System.Windows.Forms.Panel panelXpub;
        private System.Windows.Forms.Button btnViewAddressFromXpub;
        private System.Windows.Forms.ListView listViewXpubAddresses;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label lblSegwitSummary;
        private System.Windows.Forms.TextBox textBoxSubmittedXpub;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label lblLegacySummary;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label lblSegwitP2SHSummary;
        private System.Windows.Forms.Label lblXpubStatus;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label lblXpubConfirmedUnspent;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.Label lblXpubConfirmedSpent;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.Label lblXpubConfirmedReceived;
        private System.Windows.Forms.Label lblSegwitUsedAddresses;
        private System.Windows.Forms.Label lblLegacyUsedAddresses;
        private System.Windows.Forms.Label lblSegwitP2SHUsedAddresses;
        private System.Windows.Forms.Timer timerHideProgressBars;
        public System.Windows.Forms.Panel panelXpubContainer;
        private System.Windows.Forms.Button btnXpubAddressUp;
        private System.Windows.Forms.Button btnXpubAddressesDown;
        private System.Windows.Forms.Timer XpubScrollTimer;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.TextBox textBoxXpubNodeURL;
        private System.Windows.Forms.Button btnAddToBookmarks;
        private System.Windows.Forms.Panel panelAddToBookmarks;
        private System.Windows.Forms.Label lblBookmarkProposalType;
        private System.Windows.Forms.Button btnCancelAddToBookmarks;
        private System.Windows.Forms.Button btnCommitToBookmarks;
        private System.Windows.Forms.Label lblBookmarkProposalData;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Panel panelFees;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblFeesNoPriority;
        private System.Windows.Forms.Label lblFeesLowPriority;
        private System.Windows.Forms.Label lblfeesHighPriority;
        private System.Windows.Forms.Label lblFeesMediumPriority;
        private System.Windows.Forms.TextBox textBoxBookmarkProposedNote;
        private System.Windows.Forms.TextBox textBoxBookmarkEncryptionKey;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panelBookmarks;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Button btnBookmarksListDown;
        private System.Windows.Forms.Button btnBookmarksListUp;
        public System.Windows.Forms.Panel panelBookmarksContainer;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.Label lblBookmarkBlocksCount;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.Label lblBookmarkTransactionsCount;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label lblBookmarkAddressCount;
        private System.Windows.Forms.Label lblBookmarkXpubsCount;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Button btnMenuBookmarks;
        private System.Windows.Forms.Label lblBookmarkTotalCount;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Button btnDeleteBookmark;
        private System.Windows.Forms.Button btnViewBookmark;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.Label lblBookmarkNoteInFull;
        private System.Windows.Forms.Label lblSelectedBookmarkType;
        private System.Windows.Forms.Label lblBookmarkDataInFull;
        private System.Windows.Forms.Button btnBookmarkUnlock;
        private System.Windows.Forms.Timer BookmarksScrollTimer;
        private System.Windows.Forms.ListView listViewBookmarks;
        private System.Windows.Forms.TextBox textBoxBookmarkKey;
        private System.Windows.Forms.Panel panelHeaderPrice;
        private System.Windows.Forms.Label lblBookmarkSavedSuccess;
        private System.Windows.Forms.Timer hideAddToBookmarksTimer;
        private System.Windows.Forms.Label lblBookmarkStatusMessage;
        private System.Windows.Forms.Timer hideBookmarkStatusMessageTimer;
        private System.Windows.Forms.Button btnDecryptBookmark;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.Label lblTransactionConfirmations;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Button btnMenuHelp;
        private System.Windows.Forms.Label lblValidXpubIndicator;
        private System.Windows.Forms.Label lblNowViewing;
        private System.Windows.Forms.Label lblXpubNodeStatusLight;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblProgressNextDiffAdjPercentage;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.Label lblBlocksUntilDiffAdj;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.Label lblEstDiffAdjDate;
        private ColorProgressBar.ColorProgressBar progressBarNextDiffAdj;
        private ColorProgressBar.ColorProgressBar progressBarProgressToHalving;
        private ColorProgressBar.ColorProgressBar progressBarCheckEachAddressType;
        private ColorProgressBar.ColorProgressBar progressBarCheckAllAddressTypes;
        private System.Windows.Forms.Label lblCheckEachAddressTypeCount;
        private System.Windows.Forms.Label lblCheckAllAddressTypesCount;
        private System.Windows.Forms.Panel panelHeaderBlockHeight;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblP2SHUsedAddresses;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.Label lblP2SHSummary;
        private ColorProgressBar.ColorProgressBar progressBarBlockListHalvingProgress;
        private ColorProgressBar.ColorProgressBar progressBarBlockListNextDiffAdj;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblBlockListProgressNextDiffAdjPercentage;
        private System.Windows.Forms.Label lblBlockListHalvingBlockAndRemaining;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.NumericUpDown numberUpDownDerivationPathsToCheck;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Panel panel52;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel51;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Panel panel50;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Panel panel49;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Panel panel48;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.Label lblHeaderPrice;
        private System.Windows.Forms.Label lblHeaderMarketCap;
        private System.Windows.Forms.Label lblHeaderMoscowTime;
        private System.Windows.Forms.Panel panelCurrency;
        private System.Windows.Forms.Button btnXAU;
        private System.Windows.Forms.Button btnUSD;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Button btnEUR;
        private System.Windows.Forms.Button btnGBP;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label lblHeaderHashrate;
        private System.Windows.Forms.Label lblHeaderMoscowTimeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label lblBlockchairComJSON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDashboardRefresh;
        private System.Windows.Forms.Label lblWhatever;
        private System.Windows.Forms.Label lblBitcoinExplorerEndpoints;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Label lblBlockchainInfoEndpoints;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label lblURLWarning;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.TextBox textBoxSettingsXpubMempoolURL;
        private System.Windows.Forms.Label lblSettingsXpubNodeStatus;
        private System.Windows.Forms.Label lblSettingsXpubNodeStatusLight;
        private System.Windows.Forms.Button btnMenuSettings2;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label lblBitcoinDashboard;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label lblLightningDashboard;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Label lblMempoolLightningJSON;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label lblSettingsCustomNodeStatus;
        private System.Windows.Forms.Label lblSettingsCustomNodeStatusLight;
        private System.Windows.Forms.Label lblSettingsNodeCustom;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.Label lblSettingsNodeTestnet;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.Label lblSettingsNodeMainnet;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.TextBox textBoxSettingsCustomMempoolURL;
        private System.Windows.Forms.Button btnColorDataFields;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColorLabels;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnColorHeadings;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Button btnColorProgressBars;
        private System.Windows.Forms.Label label161;
        private ColorProgressBar.ColorProgressBar colorProgressBar1;
        private System.Windows.Forms.Button btnColorButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnColorButtonText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMenuAppearance;
        private System.Windows.Forms.Panel panelAppearance;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.Button btnColorLines;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Button btnColorTableText;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.Button btnColorOtherText;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.Button btnColorTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnColorPriceBlock;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.Button btnColorStatusError;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label lblShowClock;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.Panel panel62;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.PictureBox pictureBoxCustomColor;
        private System.Windows.Forms.PictureBox pictureBoxBTCDir;
        private System.Windows.Forms.PictureBox pictureBoxGenesis;
        private System.Windows.Forms.Panel panel63;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.Button btnColorTitleBackgrounds;
        private System.Windows.Forms.Label lblTitleBackgroundCustom;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.Label lblTitleBackgroundNone;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.Label lblTitleBackgroundDefault;
        private System.Windows.Forms.Label label185;
        private System.Windows.Forms.Panel panel64;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.Button btnColorTableTitleBar;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.Button btnColorTableBackground;
        private System.Windows.Forms.Panel panel65;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.Panel panel66;
        private System.Windows.Forms.Panel panel67;
        private System.Windows.Forms.Panel panel68;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.Button btnListViewHeadingColor;
        private System.Windows.Forms.PictureBox pictureBoxCustomImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.Button btnSaveTheme;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.TextBox textBoxThemeName;
        private System.Windows.Forms.Panel panel69;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.TextBox textBoxThemeImage;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.Label lblBackgroundBTCdirSelected;
        private System.Windows.Forms.Label lblBackgroundCustomColorSelected;
        private System.Windows.Forms.Label lblBackgroundCustomImageSelected;
        private System.Windows.Forms.Label lblBackgroundGenesisSelected;
        private System.Windows.Forms.Panel panel71;
        private System.Windows.Forms.ComboBox comboBoxThemeList;
        private System.Windows.Forms.Panel panel72;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.Button btnLoadTheme;
        private System.Windows.Forms.Panel panel70;
        private System.Windows.Forms.Panel panel73;
        private System.Windows.Forms.Label label197;
        private System.Windows.Forms.Button btnColorPanels;
        private System.Windows.Forms.Button btnDeleteTheme;
        private System.Windows.Forms.Label headerNetworkName;
        private System.Windows.Forms.Label headerNetworkStatusLight;
        private System.Windows.Forms.Label lblThemeDeleted;
        private System.Windows.Forms.Label lblThemeSaved;
        private System.Windows.Forms.Timer hideThemeSavedTimer;
        private System.Windows.Forms.Timer hideThemeDeletedTimer;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.Panel panel74;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Panel panel75;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Panel panel76;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Panel panel77;
        private System.Windows.Forms.Panel panelOwnNodeBlockTXInfo;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Panel panelOwnNodeAddressTXInfo;
        private System.Windows.Forms.Label label164;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Panel panelCharts;
        private System.Windows.Forms.Button btnMenuCharts;
        private System.Windows.Forms.Button btnChartHashrate;
        private System.Windows.Forms.Button btnChartDifficulty;
        private System.Windows.Forms.PictureBox pictureBoxHashrateChart;
        private System.Windows.Forms.PictureBox pictureBoxDifficultyChart;
        private System.Windows.Forms.PictureBox pictureBoxHeaderHashrateChart;
        private System.Windows.Forms.PictureBox pictureBoxBlockListHashrateChart;
        private System.Windows.Forms.PictureBox pictureBoxBlockListDifficultyChart;
        private System.Windows.Forms.Button btnChartPrice;
        private System.Windows.Forms.PictureBox pictureBoxHeaderPriceChart;
        private System.Windows.Forms.PictureBox pictureBoxPriceChart;
        private System.Windows.Forms.Button btnChartReward;
        private System.Windows.Forms.Button btnChartBlockFees;
        private System.Windows.Forms.Button btnChartPeriod24h;
        private System.Windows.Forms.Button btnChartPeriod3d;
        private System.Windows.Forms.Button btnChartPeriodAll;
        private System.Windows.Forms.Button btnChartPeriod3y;
        private System.Windows.Forms.Button btnChartPeriod2y;
        private System.Windows.Forms.Button btnChartPeriod1y;
        private System.Windows.Forms.Button btnChartPeriod6m;
        private System.Windows.Forms.Button btnChartPeriod3m;
        private System.Windows.Forms.Button btnChartPeriod1m;
        private System.Windows.Forms.Button btnChartPeriod1w;
        private System.Windows.Forms.Label lblChartMousePositionData;
        private System.Windows.Forms.Button btnChartFeeRates;
        private System.Windows.Forms.Button btnChartCirculation;
        private System.Windows.Forms.Panel panelFeeRatesKey;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.Panel panelCirculationKey;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.Label label229;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.Button btnChartBlockSize;
        private System.Windows.Forms.PictureBox pictureBoxHeaderFeeRatesChart;
        private System.Windows.Forms.PictureBox pictureBoxBlockScreenChartBlockSize;
        private System.Windows.Forms.PictureBox pictureBoxBlockScreenChartReward;
        private System.Windows.Forms.PictureBox pictureBoxBlockScreenChartFeeRange;
        private System.Windows.Forms.PictureBox pictureBoxChartCirculation;
        private System.Windows.Forms.Panel panel78;
        private System.Windows.Forms.Label label217;
        private System.Windows.Forms.Button btnChartUniqueAddresses;
        private System.Windows.Forms.Panel panelUniqueAddressesScaleButtons;
        private System.Windows.Forms.Button btnChartAddressScaleLinear;
        private System.Windows.Forms.Button btnChartAddressScaleLog;
        private System.Windows.Forms.Panel panelPriceScaleButtons;
        private System.Windows.Forms.Button btnPriceChartScaleLog;
        private System.Windows.Forms.Button btnPriceChartScaleLinear;
        private System.Windows.Forms.Button btnChartUTXO;
        private System.Windows.Forms.Panel panelChartUTXOScaleButtons;
        private System.Windows.Forms.Button btnChartUTXOScaleLog;
        private System.Windows.Forms.Button btnChartUTXOScaleLinear;
        private System.Windows.Forms.Button btnChartPoolsRanking;
        private ScottPlot.FormsPlot formsPlot2;
        private System.Windows.Forms.Panel panel79;
        private System.Windows.Forms.Label label218;
        private System.Windows.Forms.Button btnChartNodesByNetwork;
        private System.Windows.Forms.Panel panelLightningNodeNetwork;
        private System.Windows.Forms.Label label219;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.Label label227;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.Label label226;
        private System.Windows.Forms.Label label225;
        private System.Windows.Forms.Label label224;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Button btnChartNodesByCountry;
        private ScottPlot.FormsPlot formsPlot3;
        private System.Windows.Forms.Panel panel80;
        private System.Windows.Forms.Label label228;
        private System.Windows.Forms.Panel panel81;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.Button btnChartLightningCapacity;
        private System.Windows.Forms.Button btnChartLightningChannels;
    }
}

