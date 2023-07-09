/*  
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣴⣶⣾⣿⣿⣿⣿⣷⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀  _____      _______ _____                       
⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣄⠀⠀⠀⠀⠀  ⠀ / ____|  /\|__   __/ ____|                 v0.93    
⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀ ⠀ ⠀| (___   /  \  | | | (___  _   _ _ __ ___   __ _ 
⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠟⠿⠿⡿⠀⢰⣿⠁⢈⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀   ⠀ \___ \ / /\ \ | |  \___ \| | | | '_ ` _ \ / _` |
⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣤⣄⠀⠀⠀⠈⠉⠀⠸⠿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀  ⠀ ____) / ____ \| |  ____) | |_| | | | | | | (_| |
⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⢠⣶⣶⣤⡀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⡆  ⠀|_____/_/    \_\_| |_____/ \__,_|_| |_| |_|\__,_| 
⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠼⣿⣿⡿⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣷   A block explorer, Xpub viewer, bitcoin & lightning
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⢀⣀⣀⠀⠀⠀⠀⢴⣿⣿⣿⣿⣿⣿⣿⣿⣿   dashboard with the ability to create encryted 
⢿⣿⣿⣿⣿⣿⣿⣿⢿⣿⠁⠀⠀⣼⣿⣿⣿⣦⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⡿   bookmarks and notes for addresses, blocks, xpubs &
⠸⣿⣿⣿⣿⣿⣿⣏⠀⠀⠀⠀⠀⠛⠛⠿⠟⠋⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⠇   transactions. Xpub queries will only work on the 
⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⣤⡄⠀⣀⣀⣀⣀⣠⣾⣿⣿⣿⣿⣿⣿⣿⡟⠀   user's own node. Keys to unlock encrypted bookmarks
⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣄⣰⣿⠁⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠀⠀   are not stored anywhere and are uncrecoverable. The
⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀   bookmarks file is SATSuma_bookmarks.json, and the
⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀   themes file is SATSuma_themes.json, both are in the
⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⠿⢿⣿⣿⣿⣿⡿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀   user's application data directory.

🍊 Homepage
https://satsuma.btcdir.org/

🍊 Version history 
https://satsuma.btcdir.org/version-history/

🍊 Download
https://satsuma.btcdir.org/download/

 * Stuff to do:
 * check paging when reaching the end of the block list (block 0) then pressing previous. It should work the same way as transactions work on the block screen
 * Taproot support on xpub screen
 */

#region Using
using NBitcoin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using ScottPlot;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Panel = System.Windows.Forms.Panel;
#endregion

namespace SATSuma
{
    public partial class SATSuma : Form
    {
        readonly string CurrentVersion = "0.94";
        #region ⚡VARIABLE DECLARATION⚡
        #region timers
        private int intDisplayCountdownToRefresh = 0; // countdown in seconds to next refresh, for display only
        private int intAPIGroup1TimerIntervalMillisecsConstant = 60000; // milliseconds, used to reset the interval of the timer for api refreshes
        private int APIGroup1DisplayTimerIntervalSecsConstant = 60; // seconds, used to reset the countdown display to its original number
        private int intDisplaySecondsElapsedSinceUpdate = 0; // used to count seconds since the data was last refreshed, for display only.
        private int APIRefreshFrequency = 1; // mins. Default value 1. Initial value only
        #endregion
        #region address screen variables
        private int TotalAddressTransactionRowsAdded = 0; // keeps track of how many rows of Address transactions have been added to the listview
        int rowsReturnedByAddressTransactionsAPI; // holds number of rows returned by api (differs betweem mempool.space and own node)
        private string addressScreenConfUnconfOrAllTx = "chain"; // used to keep track of whether we're doing transactions requests for conf, unconf, or all transactions
        bool PartOfAnAllAddressTransactionsRequest = false; // 'all' transactions use an 'all' api for the first call, but afterwards mempoolConforAllTx is set to chain for remaining (confirmed) txs. This is used to keep headings, etc consistent
        #endregion
        #region transaction screen variables
        private int TransactionOutputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private int TransactionInputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private bool isInputButtonPressed = false;
        private bool InputDownButtonPressed = false;
        private bool InputUpButtonPressed = false;
        private bool isOutputButtonPressed = false;
        private bool OutputDownButtonPressed = false;
        private bool OutputUpButtonPressed = false;
        private readonly List<Point> linePoints = new List<Point>(); // used to store coordinates for all the lines on the transaction screen
        #endregion
        #region xpub screen variables
        private bool xpubValid = false;
        private bool isTextBoxMempoolURLWatermarkTextDisplayed = true;
        private bool isXpubButtonPressed = false;
        private bool XpubDownButtonPressed = false;
        private bool XpubUpButtonPressed = false;
        private string previousXpubNodeStringToCompare = "";
        private int XpubAddressesScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        #endregion
        #region block screen variables
        private int TotalBlockTransactionRowsAdded = 0; // keeps track of how many rows of Block transactions have been added to the listview
        int rowsReturnedByBlockTransactionsAPI; // holds number of rows returned by api (differs betweem mempool.space and own node)
        #endregion
        #region bookmark screen variables
        private int bookmarksScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        string bookmarkDataInFullPreserved = string.Empty;
        string bookmarkNoteInFullPreserved = string.Empty;
        string bookmarkKeyCheckPreserved = string.Empty;
        private bool isBookmarksButtonPressed = false;
        private bool bookmarksDownButtonPressed = false;
        private bool bookmarksUpButtonPressed = false;
        private bool isBookmarkKeyWatermarkTextDisplayed = true;
        #endregion
        #region add bookmark tab variables
        private bool isBookmarkNoteWatermarkTextDisplayed = true;
        private bool isEncryptionKeyWatermarkTextDisplayed = true;
        #endregion
        #region blocks screen variables
        private string storedLastSeenBlockNumber = "0"; // restart point to retrieve blocks for block list
        #endregion
        #region btc dashboard variables
        private bool ObtainedHalvingSecondsRemainingYet = false; // used to check whether we know halvening seconds before we start trying to subtract from them
        #endregion
        #region settings variables
        bool privacyMode = false; // disables all comms apart from to full node
        bool testNet = false; // testnet or mainnet
        bool xpubNodeURLAlreadySavedInFile = false; // keeps track of whether an xpub node URL is already saved
        bool nodeURLAlreadySavedInFile = false; // keeps track of whether a node URL is already saved
        bool settingsAlreadySavedInFile = false; // keeps track of whether settings are already saved
        bool defaultThemeAlreadySavedInFile = false; // keeps track of whether a default theme is already saved
        bool isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = true; // settings screen for watermarked node field
        bool isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = true; // settings screen for watermarked node field
        private string NodeURL = "https://mempool.space/api/"; // default value. Can be changed by user.
        private string xpubNodeURL = ""; // no default value. User must provide path to own node
        string xpubNodeURLInFile = ""; // stores the xpub node URL from the file to check whether a newly supplied one is different, in which case we'll update the file
        string nodeURLInFile = ""; // stores the node URL from the file to check whether a newly supplied one is different, in which case we'll update the file
        string settingsInFile = ""; // stores the settings from the file to check whether any have changed, in which case we'll update the file
        string defaultThemeInFile = ""; // stores the default theme from the file to check whether a newly supplied one is different, in which case we'll update the file
        string currencySelected = "D"; // for settings record in bookmarks file
        string selectedNetwork = "M"; // for settings record in bookmarks file
        string blockchairComJSONSelected = "1"; // for settings record in bookmarks file
        string bitcoinExplorerEnpointsSelected = "1"; // for settings record in bookmarks file
        string blockchainInfoEndpointsSelected = "1"; // for settings record in bookmarks file
        string PrivacyModeSelected = "0"; // for settings record in bookmarks file 
        string unused1 = "1"; // for settings record in bookmarks file
        string unused2 = "1"; // for settings record in bookmarks file
        string previousCustomNodeStringToCompare = ""; // settings screen - to check whether settings have changed before saving them
        #endregion
        #region data services
        private TransactionsForAddressService _transactionsForAddressService;
        private TransactionsForXpubAddressService _transactionsForXpubAddressService;
        private BlockDataService _blockService;
        private TransactionService _transactionService;
        private TransactionsForBlockService _transactionsForBlockService;
        private HashrateAndDifficultyService _hashrateAndDifficultyService;
        private HistoricPriceDataService _historicPriceDataService;
        private MarketCapDataService _marketCapDataService;
        private BlockFeeRatesDataService _blockFeeRatesDataService;
        private BitcoinsInCirculationDataService _bitcoinsInCirculationDataService;
        private BlockSizeAndWeightService _blockSizeAndWeightService;
        private UniqueAddressesDataService _uniqueAddressesDataService;
        private UTXODataService _utxoDataService;
        private PoolsRankingDataService _poolsRankingDataService;
        private LightningNodesByCountryService _lightningNodesByCountryService;
        #endregion
        #region api use flag variables
        private bool RunBitcoinExplorerEndpointAPI = true; // enable/disable API
        private bool RunBlockchainInfoEndpointAPI = true; // enable/disable API
        private bool RunBitcoinExplorerOrgJSONAPI = true; // enable/disable API
        private bool RunBlockchairComJSONAPI = true; // enable/disable API
        private bool RunMempoolSpaceLightningAPI = true; // enable/disable API
        #endregion
        #region variables to hold button states
        bool dontDisableButtons = true; // ignore button disables during initial setup
        bool btnShowAllAddressTXWasEnabled = true; // Address screen - store button state during queries to return to that state afterwards
        bool btnShowConfirmedAddressTXWasEnabled = false; // Address screen - store button state during queries to return to that state afterwards
        bool btnShowUnconfirmedAddressTXWasEnabled = true; // Address screen - store button state during queries to return to that state afterwards
        bool btnFirstAddressTransactionWasEnabled = false; // Address screen - store button state during queries to return to that state afterwards
        bool btnNextAddressTransactionsWasEnabled = false; // Address screen - store button state during queries to return to that state afterwards
        bool BtnViewTransactionFromAddressWasEnabled = false; // Address screen - store button state during queries to return to that state afterwards
        bool BtnViewBlockFromAddressWasEnabled = false; // Address screen - store button state during queries to return to that state afterwards
        bool textBoxSubmittedAddressWasEnabled = true; // Address screen - store button state during queries to return to that state afterwards
        bool btnPreviousBlockTransactionsWasEnabled = false; // Block screen - store button state during queries to return to that state afterwards
        bool btnNextBlockTransactionsWasEnabled = false; // Block screen - store button state during queries to return to that state afterwards
        bool textBoxSubmittedBlockNumberWasEnabled = true; // Block screen - store button state during queries to return to that state afterwards
        bool btnNextBlockWasEnabled = false; // Block screen - store button state during queries to return to that state afterwards
        bool btnPreviousBlockWasEnabled = true; // Block screen - store button state during queries to return to that state afterwards
        bool btnViewBlockFromBlockListWasEnabled = false; // Block List screen - store button state during queries to return to that state afterwards
        bool btnNewer15BlocksWasEnabled = false; // Block List screen - store button state during queries to return to that state afterwards
        bool btnOlder15BlocksWasEnabled = true; // Block List screen - store button state during queries to return to that state afterwards
        bool textBoxBlockHeightToStartListFromWasEnabled = true; // Block List screen - store button state during queries to return to that state afterwards
        bool btnChartBlockFeesWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartDifficultyWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartHashrateWasEnabled = false; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPriceWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartRewardWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartFeeRatesWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartCirculationWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod1mWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod1wWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod1yWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod24hWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod2yWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod3dWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod3mWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod3yWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriod6mWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPeriodAllWasEnabled = false; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartBlockSizeWasEnabled = false; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartUniqueAddressesWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnHashrateScaleLinearWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnHashrateScaleLogWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartDifficultyLinearWasEnabled = false; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartDifficultyLogWasEnabled = false; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartAddressScaleLinearWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartAddressScaleLogWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnPriceChartScaleLogWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnPriceChartScaleLinearWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartUTXOWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartPoolsRankingWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartNodesByNetworkWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartNodesByCountryWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartLightningCapacityWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartLightningChannelsWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartMarketCapWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnChartMarketCapLogWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnPriceConverterWasEnabled = true; // Chart screen - store button state during queries to return to that state afterwards
        bool btnTransactionInputsUpWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        bool btnTransactionInputDownWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        bool btnTransactionOutputsUpWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        bool btnTransactionOutputsDownWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        bool btnViewAddressFromTXInputWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        bool btnViewAddressFromTXOutputWasEnabled = false; // Transaction screen - store button state during queries to return to that state afterwards
        #endregion
        #region colour variables
        Color subItemBackColor = Color.FromArgb(20, 20, 20);
        Color labelColor = Color.FromArgb(20, 20, 20);
        Color chartsBackgroundColor = Color.FromArgb(20, 20, 20);
        Color linesColor = Color.FromArgb(106, 72, 9);
        Color titleBackgroundColor = Color.FromArgb(0, 0, 0);
        Color listViewHeaderColor = Color.FromArgb(50, 50, 50);
        Color listViewHeaderTextColor = Color.Silver;
        Color tableTextColor = Color.FromArgb(255, 153, 0);
        #endregion
        #region variables specific to chart screen
        private int LastHighlightedIndex = -1; // used by charts for mousemove events to highlight plots closest to pointer
        private ScottPlot.Plottable.ScatterPlot scatter; // chart data gets plotted onto this
        private ScottPlot.Plottable.MarkerPlot HighlightedPoint; // highlighted (closest to pointer) plot gets plotted onto this
        bool ignoreMouseMoveOnChart = false; // ignore mouse move event while chart is still drawing
        string chartPeriod = "all"; // holds the string needed to generate charts with different time periods
        string chartType = ""; // keeps track of what type of chart is being displayed
        #endregion
        #endregion

        #region ⚡INITIALISE⚡
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]  // needed for the code that moves the form as not using a standard control
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")] // needed for the code that moves the form as not using a standard control
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public SATSuma()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            CreateDataServices();
        }

        private void SATSuma_Load(object sender, EventArgs e)
        {
            try
            {
                lblCurrentVersion.Text = "v" + CurrentVersion;
                RestoreSavedSettings(); // api choices, node, xpub node, theme
                CheckNetworkStatus();
                GetBlockTip();
                UpdateBitcoinAndLightningDashboards(); // setting them now avoids waiting a whole minute for the first refresh
                StartTheClocksTicking(); // start all the timers
                textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; //setup block list screen
                LookupBlockList(); // fetch the first 15 blocks automatically for the block list initial view.
                AddressInvalidHideControls(); // Address screen - initially address textbox is empty so hide the controls
                // prepopulate chart with fee rates
                btnChartPeriodAll.Enabled = false;
                BtnChartFeeRates_Click(sender, e);
                dontDisableButtons = false; // from here on, buttons are disabled during queries
                CheckForUpdates();
            }
            catch (WebException ex)
            {
                HandleException(ex, "SATSuma_Load");
            }
        }
        #endregion

        #region ⚡CLOCK TICK EVENTS (1 sec and API refresh clock only)⚡
        //=============================================================================================================
        // -------------------------CLOCK TICKS------------------------------------------------------------------------
        private void StartTheClocksTicking()
        {
            try
            {
                APIRefreshFrequency = Convert.ToInt32(numericUpDownDashboardRefresh.Value);
                intDisplayCountdownToRefresh = (APIRefreshFrequency * 60); //turn minutes into seconds. This is the number used to display remaning time until refresh
                APIGroup1DisplayTimerIntervalSecsConstant = (APIRefreshFrequency * 60); //turn minutes into seconds. This is kept constant and used to reset the timer to this number
                intAPIGroup1TimerIntervalMillisecsConstant = ((APIRefreshFrequency * 60) * 1000); // turn minutes into seconds, then into milliseconds
                timerAPIRefreshPeriod.Interval = intAPIGroup1TimerIntervalMillisecsConstant; // set the timer interval
                timer1Sec.Start(); // timer used to refresh the clock values
                timerAPIRefreshPeriod.Start(); // used to trigger API refreshes
            }
            catch (Exception ex)
            {
                HandleException(ex, "StartTheClocksTicking");
            }
        }

        private void Timer1Sec_Tick(object sender, EventArgs e) // update the time (if displayed) and refresh countdowns, countups, etc
        {
            try
            {
                UpdateOnScreenClock();
                UpdateOnScreenCountdownAndFlashLights();
                UpdateOnScreenElapsedTimeSinceUpdate();
                UpdateSecondsToHalving();
                if (intDisplayCountdownToRefresh < 11) // when there are only 10 seconds left until the refresh, clear error alert symblol & error message
                {
                    ClearAlertAndErrorMessage();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Timer1Sec_Tick");
            }
        }

        private void TimerAPIRefreshPeriod_Tick(object sender, EventArgs e) // update the btc/lightning dashboard fields
        {
            try
            {
                ClearAlertAndErrorMessage(); // wipe anything that may be showing in the error area (it should be empty anyway)
                CheckNetworkStatus();
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string BlockTipURL = NodeURL + "blocks/tip/height";
                        string BlockTip = client.DownloadString(BlockTipURL); // get current block tip
                        lblBlockNumber.Invoke((MethodInvoker)delegate
                        {
                            lblBlockNumber.Text = BlockTip;
                        });
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, "TimerAPIRefreshPeriod_Tick");
                    }
                }
                UpdateBitcoinAndLightningDashboards(); // fetch data and populate fields for dashboards
                PopulateConverterScreen(); // refresh amounts on BTC/fiat converter screen
            }
            catch (WebException ex)
            {
                HandleException(ex, "TimerAPIRefreshPeriod_Tick");
            }
        }
        #endregion

        #region ⚡BITCOIN AND LIGHTNING DASHBOARD SCREENS⚡
        #region update dashboards
        public async void UpdateBitcoinAndLightningDashboards()
        {
            ToggleLoadingAnimation("enable");

            using (WebClient client = new WebClient())
            {
                bool errorOccurred = false;
                #region mempool.space api's
                Task task0 = Task.Run(async () => // mempool.space api's
                {
                    // current block height, size and transaction count
                    try
                    {
                        var blocksJson = await _blockService.GetBlockDataAsync("000000");  // don't pass a block to start from - we want the tip
                        var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);

                        if (blocks.Count > 0)
                        {
                            lblTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblTransactions.Text = Convert.ToString(blocks[0].Tx_count);
                            });

                            lblBlockNumber.Invoke((MethodInvoker)delegate
                            {
                                lblBlockNumber.Text = Convert.ToString(blocks[0].Height);
                            });

                            long sizeInBytes = blocks[0].Size;
                            string sizeString; // convert display to bytes/kb/mb accordingly
                            if (sizeInBytes < 1000)
                            {
                                sizeString = $"{sizeInBytes} bytes";
                            }
                            else if (sizeInBytes < 1000 * 1000)
                            {
                                double sizeInKB = (double)sizeInBytes / 1000;
                                sizeString = $"{sizeInKB:N2} KB";
                            }
                            else
                            {
                                double sizeInMB = (double)sizeInBytes / (1000 * 1000);
                                sizeString = $"{sizeInMB:N2} MB";
                            }
                            lblHeaderBlockSize.Invoke((MethodInvoker)delegate
                            {
                                lblHeaderBlockSize.Text = sizeString;
                            });
                            pictureBoxHeaderBlockSizeChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxHeaderBlockSizeChart.Location = new Point(lblHeaderBlockSize.Location.X + lblHeaderBlockSize.Width + 10, pictureBoxHeaderBlockSizeChart.Location.Y);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(getting block size & tx count)");
                    }

                    // fees
                    try
                    {
                        var (fastestFee, halfHourFee, hourFee, economyFee, minimumFee) = GetFees();
                        lblfeesHighPriority.Invoke((MethodInvoker)delegate
                        {
                            lblfeesHighPriority.Text = fastestFee;
                        });
                        lblFeesMediumPriority.Invoke((MethodInvoker)delegate
                        {
                            lblFeesMediumPriority.Text = halfHourFee;
                        });
                        lblFeesLowPriority.Invoke((MethodInvoker)delegate
                        {
                            lblFeesLowPriority.Text = hourFee;
                        });
                        lblFeesNoPriority.Invoke((MethodInvoker)delegate
                        {
                            lblFeesNoPriority.Text = economyFee;
                        });
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(getting fees)");
                    }

                    // hashrate
                    try
                    {
                        var (currentHashrate, currentDifficulty) = GetHashrate();
                        lblHeaderHashrate.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderHashrate.Text = currentHashrate;
                        });
                        pictureBoxHeaderHashrateChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxHeaderHashrateChart.Location = new Point(lblHeaderHashrate.Location.X + lblHeaderHashrate.Width + 10, pictureBoxHeaderHashrateChart.Location.Y);
                        });
                        lblEstHashrate.Invoke((MethodInvoker)delegate
                        {
                            lblEstHashrate.Text = currentHashrate;
                        });
                        pictureBoxHashrateChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxHashrateChart.Location = new Point(lblEstHashrate.Location.X + lblEstHashrate.Width + 5, pictureBoxHashrateChart.Location.Y);
                        });
                        lblBlockListEstHashRate.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListEstHashRate.Text = currentHashrate;
                        });
                        pictureBoxBlockListHashrateChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListHashrateChart.Location = new Point(lblBlockListEstHashRate.Location.X + lblBlockListEstHashRate.Width + 5, pictureBoxBlockListHashrateChart.Location.Y);
                        });
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(getting hashrate)");
                    }

                    // difficulty adjustment
                    try
                    {
                        var (progressPercent, difficultyChange, estimatedRetargetDate, remainingBlocks, remainingTime, previousRetarget, nextRetargetHeight, timeAvg, timeOffset) = GetDifficultyAdjustment();
                        decimal progressValue2 = decimal.Parse(progressPercent.TrimEnd('%')) / 100; // convert to decimal and scale to range [0, 1]
                        string truncatedPercent = string.Format("{0:F2}%", progressValue2 * 100); // truncate to two decimal places

                        lblProgressNextDiffAdjPercentage.Invoke((MethodInvoker)delegate
                        {
                            lblProgressNextDiffAdjPercentage.Text = "(" + truncatedPercent + ")";
                        });
                        lblBlockListProgressNextDiffAdjPercentage.Invoke((MethodInvoker)delegate //Block List
                        {
                            lblBlockListProgressNextDiffAdjPercentage.Text = "(" + truncatedPercent + ")"; 
                        });
                        decimal progressValue = decimal.Parse(progressPercent); // convert to decimal and scale to range [0, 1]
                        progressBarNextDiffAdj.Value = Convert.ToInt16(progressValue); // scale to fit progress bar range
                        progressBarBlockListNextDiffAdj.Value = Convert.ToInt16(progressValue); // scale to fit progress bar range - Block List
                        lblDifficultyAdjEst.Invoke((MethodInvoker)delegate
                        {
                            lblDifficultyAdjEst.Text = difficultyChange + "%";
                        });
                        pictureBoxDifficultyChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxDifficultyChart.Location = new Point(lblDifficultyAdjEst.Location.X + lblDifficultyAdjEst.Width + 5, pictureBoxDifficultyChart.Location.Y);
                        });
                        lblBlockListNextDifficultyAdjustment.Invoke((MethodInvoker)delegate  // (Blocks list)
                        {
                            lblBlockListNextDifficultyAdjustment.Text = difficultyChange + "%";
                        });
                        pictureBoxBlockListDifficultyChart.Invoke((MethodInvoker)delegate  // (Blocks list)
                        {
                            pictureBoxBlockListDifficultyChart.Location = new Point(lblBlockListNextDifficultyAdjustment.Location.X + lblBlockListNextDifficultyAdjustment.Width + 5, pictureBoxBlockListDifficultyChart.Location.Y);
                        });
                        lblBlocksUntilDiffAdj.Invoke((MethodInvoker)delegate
                        {
                            lblBlocksUntilDiffAdj.Text = remainingBlocks.ToString();
                        });
                        string formattedDate;
                        if (NodeURL == "https://mempool.space/api/" || NodeURL == "https://mempool.space/testnet/api/")
                        {
                            long unixTimestamp = Convert.ToInt64(estimatedRetargetDate);
                            DateTime retargetDate = DateTimeExtensions.FromUnixTimeMilliseconds(unixTimestamp);
                            formattedDate = retargetDate.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            double estRetargetDate = Convert.ToDouble(estimatedRetargetDate);
                            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds((long)estRetargetDate);
                            DateTime dateTime = dateTimeOffset.LocalDateTime;
                            formattedDate = dateTime.ToString();
                        }
                        lblEstDiffAdjDate.Invoke((MethodInvoker)delegate
                        {
                            lblEstDiffAdjDate.Text = formattedDate;
                        });
                        lblNextDiffAdjBlock.Invoke((MethodInvoker)delegate
                        {
                            lblNextDiffAdjBlock.Text = nextRetargetHeight;
                        });
                        lblBlockListNextDiffAdjBlock.Invoke((MethodInvoker)delegate // (Blocks list)
                        {
                            lblBlockListNextDiffAdjBlock.Text = nextRetargetHeight;
                        });
                        decimal AvgTimeBetweenBlocks = (Convert.ToDecimal(timeAvg) / 1000) / 60;
                        int minutes = (int)AvgTimeBetweenBlocks;
                        int seconds = (int)((AvgTimeBetweenBlocks - minutes) * 60);
                        string timeString = $"{minutes} mins {seconds} secs";
                        lblAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate
                        {
                            lblAvgTimeBetweenBlocks.Text = timeString;
                        });
                        lblBlockListAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate // (Blocks list)
                        {
                            lblBlockListAvgTimeBetweenBlocks.Text = timeString;
                        });
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Getting difficulty adjustment)");
                    }

                    // transactions in mempool
                    try
                    {
                        var (txCount, vSize, totalFees) = GetMempool();
                        string txInMempool = txCount;
                        lblTXInMempool.Invoke((MethodInvoker)delegate
                        {
                            lblTXInMempool.Text = txInMempool;
                        });
                        lblBlockListTXInMempool.Invoke((MethodInvoker)delegate  // Blocks list
                        {
                            lblBlockListTXInMempool.Text = txInMempool;
                        });
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateAPIGroup1DataFields(GetMempool)");
                    }

                });
                Task task4 = Task.Run(() => // mempool.space lightning JSON
                {
                    try
                    {
                        if (!testNet)
                        {
                            if (RunMempoolSpaceLightningAPI)
                            {
                                var (channelCount, nodeCount, totalCapacity, torNodes, clearnetNodes, unannouncedNodes, avgCapacity, avgFeeRate, avgBaseeFeeMtokens, medCapacity, medFeeRate, medBaseeFeeMtokens, clearnetTorNodes) = MempoolSpaceLightningJSONRefresh();
                                lblChannelCount.Invoke((MethodInvoker)delegate
                                {
                                    lblChannelCount.Text = channelCount;
                                });
                                lblNodeCount.Invoke((MethodInvoker)delegate
                                {
                                    lblNodeCount.Text = nodeCount;
                                });
                                lblTotalCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblTotalCapacity.Text = totalCapacity;
                                });
                                lblTorNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblTorNodes.Text = torNodes;
                                });
                                lblClearnetNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetNodes.Text = clearnetNodes;
                                });
                                lblAverageCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageCapacity.Text = avgCapacity;
                                });
                                lblAverageFeeRate.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageFeeRate.Text = avgFeeRate;
                                });
                                lblUnannouncedNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblUnannouncedNodes.Text = unannouncedNodes;
                                });
                                lblAverageBaseFeeMtokens.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageBaseFeeMtokens.Text = avgBaseeFeeMtokens;
                                });
                                lblMedCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblMedCapacity.Text = medCapacity;
                                });
                                lblMedFeeRate.Invoke((MethodInvoker)delegate
                                {
                                    lblMedFeeRate.Text = medFeeRate;
                                });
                                lblMedBaseFeeTokens.Invoke((MethodInvoker)delegate
                                {
                                    lblMedBaseFeeTokens.Text = medBaseeFeeMtokens;
                                });
                                lblClearnetTorNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetTorNodes.Text = clearnetTorNodes;
                                });
                            }
                            else
                            {
                                lblChannelCount.Invoke((MethodInvoker)delegate
                                {
                                    lblChannelCount.Text = "Disabled";
                                });
                                lblNodeCount.Invoke((MethodInvoker)delegate
                                {
                                    lblNodeCount.Text = "Disabled";
                                });
                                lblTotalCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblTotalCapacity.Text = "Disabled";
                                });
                                lblTorNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblTorNodes.Text = "Disabled";
                                });
                                lblClearnetNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetNodes.Text = "Disabled";
                                });
                                lblAverageCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageCapacity.Text = "Disabled";
                                });
                                lblAverageFeeRate.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageFeeRate.Text = "Disabled";
                                });
                                lblUnannouncedNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblUnannouncedNodes.Text = "Disabled";
                                });
                                lblAverageBaseFeeMtokens.Invoke((MethodInvoker)delegate
                                {
                                    lblAverageBaseFeeMtokens.Text = "Disabled";
                                });
                                lblMedCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblMedCapacity.Text = "Disabled";
                                });
                                lblMedFeeRate.Invoke((MethodInvoker)delegate
                                {
                                    lblMedFeeRate.Text = "Disabled";
                                });
                                lblMedBaseFeeTokens.Invoke((MethodInvoker)delegate
                                {
                                    lblMedBaseFeeTokens.Text = "Disabled";
                                });
                                lblClearnetTorNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetTorNodes.Text = "Disabled";
                                });
                            }
                            pictureBoxLightningNodesChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxLightningNodesChart.Location = new Point(label40.Location.X + label40.Width + 5, pictureBoxLightningNodesChart.Location.Y);
                            });
                            pictureBoxLightningChannelsChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxLightningChannelsChart.Location = new Point(label34.Location.X + label34.Width + 5, pictureBoxLightningChannelsChart.Location.Y);
                            });
                            pictureBoxLightningCapacityChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxLightningCapacityChart.Location = new Point(label38.Location.X + label38.Width + 5, pictureBoxLightningCapacityChart.Location.Y);
                            });
                            if (RunMempoolSpaceLightningAPI)
                            {
                                var (clearnetCapacity, torCapacity, unknownCapacity) = MempoolSpaceCapacityBreakdownJSONRefresh();
                                lblClearnetCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetCapacity.Text = clearnetCapacity;
                                });
                                lblTorCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblTorCapacity.Text = torCapacity;
                                });
                                lblUnknownCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblUnknownCapacity.Text = unknownCapacity;
                                });
                            }
                            else
                            {
                                lblClearnetCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblClearnetCapacity.Text = "Disabled";
                                });
                                lblTorCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblTorCapacity.Text = "Disabled";
                                });
                                lblUnknownCapacity.Invoke((MethodInvoker)delegate
                                {
                                    lblUnknownCapacity.Text = "Disabled";
                                });
                            }
                            if (RunMempoolSpaceLightningAPI)
                            {
                                var (aliases, capacities) = MempoolSpaceLiquidityRankingJSONRefresh();
                                for (int i = 0; i < 10; i++)
                                {
                                    System.Windows.Forms.Label aliasLabel = (System.Windows.Forms.Label)this.Controls.Find("aliasLabel" + (i + 1), true)[0];
                                    aliasLabel.Invoke((MethodInvoker)delegate
                                    {
                                        aliasLabel.Text = aliases[i];
                                    });
                                    System.Windows.Forms.Label capacityLabel = (System.Windows.Forms.Label)this.Controls.Find("capacityLabel" + (i + 1), true)[0];
                                    capacityLabel.Invoke((MethodInvoker)delegate
                                    {
                                        capacityLabel.Text = capacities[i];
                                    });
                                }
                                var result7 = MempoolSpaceConnectivityRankingJSONRefresh();
                                if (result7.aliases.Count > 0)
                                {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        System.Windows.Forms.Label aliasLabel = (System.Windows.Forms.Label)this.Controls.Find("aliasConnLabel" + (i + 1), true)[0];
                                        aliasLabel.Invoke((MethodInvoker)delegate
                                        {
                                            aliasLabel.Text = result7.aliases[i];
                                        });
                                        System.Windows.Forms.Label channelLabel = (System.Windows.Forms.Label)this.Controls.Find("channelLabel" + (i + 1), true)[0];
                                        channelLabel.Invoke((MethodInvoker)delegate
                                        {
                                            channelLabel.Text = result7.channels[i];
                                        });
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    System.Windows.Forms.Label aliasLabel = (System.Windows.Forms.Label)this.Controls.Find("aliasLabel" + (i + 1), true)[0];
                                    aliasLabel.Invoke((MethodInvoker)delegate
                                    {
                                        aliasLabel.Text = "disabled";
                                    });
                                    System.Windows.Forms.Label capacityLabel = (System.Windows.Forms.Label)this.Controls.Find("capacityLabel" + (i + 1), true)[0];
                                    capacityLabel.Invoke((MethodInvoker)delegate
                                    {
                                        capacityLabel.Text = "disabled";
                                    });
                                }
                                //var (aliases, channels) = MempoolSpaceConnectivityRankingJSONRefresh();
                                for (int i = 0; i < 10; i++)
                                {
                                    System.Windows.Forms.Label aliasLabel = (System.Windows.Forms.Label)this.Controls.Find("aliasConnLabel" + (i + 1), true)[0];
                                    aliasLabel.Invoke((MethodInvoker)delegate
                                    {
                                        aliasLabel.Text = "disabled";
                                    });
                                    System.Windows.Forms.Label channelLabel = (System.Windows.Forms.Label)this.Controls.Find("channelLabel" + (i + 1), true)[0];
                                    channelLabel.Invoke((MethodInvoker)delegate
                                    {
                                        channelLabel.Text = "disabled";
                                    });
                                }
                            }
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task6)");
                    }
                });
                #endregion
                #region bitcoinexplorer.org api
                Task task1 = Task.Run(() =>  // bitcoinexplorer.org JSON for market data
                {
                    if (!privacyMode)
                    {
                        try
                        {
                            if (!testNet)
                            {
                                if (RunBitcoinExplorerEndpointAPI)
                                {
                                    GetMarketData();
                                }
                                else
                                {
                                    lblPriceUSD.Invoke((MethodInvoker)delegate
                                    {
                                        lblPriceUSD.Text = "disabled";
                                    });

                                    lblMoscowTime.Invoke((MethodInvoker)delegate
                                    {
                                        lblMoscowTime.Text = "disabled";
                                    });
                                    lblMarketCapUSD.Invoke((MethodInvoker)delegate
                                    {
                                        lblMarketCapUSD.Text = "disabled";
                                    });
                                    lblHeaderPrice.Invoke((MethodInvoker)delegate
                                    {
                                        lblHeaderPrice.Text = "disabled";
                                    });

                                    lblHeaderMoscowTime.Invoke((MethodInvoker)delegate
                                    {
                                        lblHeaderMoscowTime.Text = "disabled";
                                    });
                                    lblHeaderMarketCap.Invoke((MethodInvoker)delegate
                                    {
                                        lblHeaderMarketCap.Text = "disabled";
                                    });
                                }
                            }
                            else
                            {
                                lblPriceUSD.Invoke((MethodInvoker)delegate
                                {
                                    lblPriceUSD.Text = "0 (TestNet)";
                                });
                                lblMoscowTime.Invoke((MethodInvoker)delegate
                                {
                                    lblMoscowTime.Text = "0 (TestNet)";
                                });
                                lblMarketCapUSD.Invoke((MethodInvoker)delegate
                                {
                                    lblMarketCapUSD.Text = "0 (TestNet)";
                                });
                                lblHeaderPrice.Invoke((MethodInvoker)delegate
                                {
                                    lblHeaderPrice.Text = "0 (TestNet)";
                                });
                                lblHeaderMoscowTime.Invoke((MethodInvoker)delegate
                                {
                                    lblHeaderMoscowTime.Text = "0 (TestNet)";
                                });
                                lblHeaderMarketCap.Invoke((MethodInvoker)delegate
                                {
                                    lblHeaderMarketCap.Text = "0 (TestNet)";
                                });
                            }
                            pictureBoxMarketCapChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxMarketCapChart.Location = new Point(lblMarketCapUSD.Location.X + lblMarketCapUSD.Width + 5, pictureBoxMarketCapChart.Location.Y);
                            });
                            pictureBoxPriceChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxPriceChart.Location = new Point(lblPriceUSD.Location.X + lblPriceUSD.Width + 5, pictureBoxPriceChart.Location.Y);
                            });
                            pictureBoxConverterChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxConverterChart.Location = new Point(lblMoscowTime.Location.X + lblMoscowTime.Width + 5, pictureBoxConverterChart.Location.Y);
                            });
                            pictureBoxHeaderPriceChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxHeaderPriceChart.Location = new Point(lblHeaderPrice.Location.X + lblHeaderPrice.Width, pictureBoxHeaderPriceChart.Location.Y);
                            });
                            pictureBoxHeaderConverterChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxHeaderConverterChart.Location = new Point(lblHeaderMoscowTime.Location.X + lblHeaderMoscowTime.Width + 10, pictureBoxHeaderConverterChart.Location.Y);
                            });
                            pictureBoxHeaderMarketCapChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxHeaderMarketCapChart.Location = new Point(lblHeaderMarketCap.Location.X + lblHeaderMarketCap.Width + 10, pictureBoxHeaderMarketCapChart.Location.Y);
                            });
                            SetLightsMessagesAndResetTimers();
                        }
                        catch (Exception ex)
                        {
                            errorOccurred = true;
                            HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task1)");
                        }
                    }
                });
                Task task3 = Task.Run(() => // Bitcoinexplorer.org JSON
                {
                    if (!privacyMode)
                    {
                        try
                        {
                            if (!testNet)
                            {
                                if (RunBitcoinExplorerOrgJSONAPI)
                                {
                                    var (nextBlockFee, thirtyMinFee, sixtyMinFee, oneDayFee, txInNextBlock, nextBlockMinFee, nextBlockMaxFee, nextBlockTotalFees) = BitcoinExplorerOrgJSONRefresh();
                                    lblTransInNextBlock.Invoke((MethodInvoker)delegate
                                    {
                                        lblTransInNextBlock.Text = txInNextBlock;
                                    });
                                    lblBlockListTXInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListTXInNextBlock.Text = txInNextBlock;
                                    });
                                    lblNextBlockMinMaxFee.Invoke((MethodInvoker)delegate
                                    {
                                        lblNextBlockMinMaxFee.Text = nextBlockMinFee + " / " + nextBlockMaxFee;
                                    });
                                    lblBlockListMinMaxInFeeNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListMinMaxInFeeNextBlock.Text = nextBlockMinFee + " / " + nextBlockMaxFee;
                                    });
                                    lblNextBlockTotalFees.Invoke((MethodInvoker)delegate
                                    {
                                        lblNextBlockTotalFees.Text = nextBlockTotalFees;
                                    });
                                    lblBlockListTotalFeesInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListTotalFeesInNextBlock.Text = nextBlockTotalFees;
                                    });
                                }
                                else
                                {
                                    lblTransInNextBlock.Invoke((MethodInvoker)delegate
                                    {
                                        lblTransInNextBlock.Text = "disabled";
                                    });
                                    lblBlockListTXInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListTXInNextBlock.Text = "disabled";
                                    });
                                    lblNextBlockMinMaxFee.Invoke((MethodInvoker)delegate
                                    {
                                        lblNextBlockMinMaxFee.Text = "disabled";
                                    });
                                    lblBlockListMinMaxInFeeNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListMinMaxInFeeNextBlock.Text = "disabled";
                                    });
                                    lblNextBlockTotalFees.Invoke((MethodInvoker)delegate
                                    {
                                        lblNextBlockTotalFees.Text = "disabled";
                                    });
                                    lblBlockListTotalFeesInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                    {
                                        lblBlockListTotalFeesInNextBlock.Text = "disabled";
                                    });
                                }
                            }
                            else
                            {
                                lblTransInNextBlock.Invoke((MethodInvoker)delegate
                                {
                                    lblTransInNextBlock.Text = "unavailable on TestNet";
                                });
                                lblBlockListTXInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                {
                                    lblBlockListTXInNextBlock.Text = "unavailable on TestNet";
                                });
                                lblNextBlockMinMaxFee.Invoke((MethodInvoker)delegate
                                {
                                    lblNextBlockMinMaxFee.Text = "unavailable on TestNet";
                                });
                                lblBlockListMinMaxInFeeNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                {
                                    lblBlockListMinMaxInFeeNextBlock.Text = "unavailable on TestNet";
                                });
                                lblNextBlockTotalFees.Invoke((MethodInvoker)delegate
                                {
                                    lblNextBlockTotalFees.Text = "unavailable on TestNet";
                                });
                                lblBlockListTotalFeesInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                                {
                                    lblBlockListTotalFeesInNextBlock.Text = "unavailable on TestNet";
                                });
                            }
                            pictureBoxBlockFeesChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxBlockFeesChart.Location = new Point(lblNextBlockTotalFees.Location.X + lblNextBlockTotalFees.Width + 5, pictureBoxBlockFeesChart.Location.Y);
                            });
                            pictureBoxFeeRangeChart.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxFeeRangeChart.Location = new Point(lblNextBlockMinMaxFee.Location.X + lblNextBlockMinMaxFee.Width + 5, pictureBoxFeeRangeChart.Location.Y);
                            });
                            pictureBoxBlockListFeeRangeChart2.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxBlockListFeeRangeChart2.Location = new Point(lblBlockListMinMaxInFeeNextBlock.Location.X + lblBlockListMinMaxInFeeNextBlock.Width + 5, pictureBoxBlockListFeeRangeChart2.Location.Y);
                            });
                            pictureBoxBlockListFeeChart2.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxBlockListFeeChart2.Location = new Point(lblBlockListTotalFeesInNextBlock.Location.X + lblBlockListTotalFeesInNextBlock.Width + 5, pictureBoxBlockListFeeChart2.Location.Y);
                            });
                            SetLightsMessagesAndResetTimers();
                        }
                        catch (Exception ex)
                        {
                            errorOccurred = true;
                            HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task3)");
                        }
                    }
                });
                #endregion
                #region blockchain.info api
                Task task2 = Task.Run(() => // blockchain.info endpoints 
                {
                    if (!privacyMode)
                    {
                        try
                        {
                            if (!testNet)
                            {
                                if (RunBlockchainInfoEndpointAPI)
                                {
                                    var (avgNoTransactions, blockNumber, blockReward, estHashrate, avgTimeBetweenBlocks, btcInCirc, hashesToSolve, twentyFourHourTransCount, twentyFourHourBTCSent) = BlockchainInfoEndpointsRefresh();
                                    lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                                    {
                                        lblAvgNoTransactions.Text = avgNoTransactions;
                                    });
                                    lblBlockReward.Invoke((MethodInvoker)delegate
                                    {
                                        lblBlockReward.Text = blockReward;
                                    });
                                    decimal DecBlockReward = Convert.ToDecimal(blockReward);
                                    decimal NextBlockReward = DecBlockReward / 2;
                                    lblBlockRewardAfterHalving.Invoke((MethodInvoker)delegate
                                    {
                                        lblBlockRewardAfterHalving.Text = Convert.ToString(NextBlockReward);
                                    });
                                    lblBlockListBlockReward.Invoke((MethodInvoker)delegate // (Blocks list)
                                    {
                                        lblBlockListBlockReward.Text = blockReward;
                                    });
                                    lblBTCInCirc.Invoke((MethodInvoker)delegate
                                    {
                                        lblBTCInCirc.Text = btcInCirc + " / 21000000";
                                    });
                                    lblHashesToSolve.Invoke((MethodInvoker)delegate
                                    {
                                        lblHashesToSolve.Text = hashesToSolve;
                                    });
                                    lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // (Blocks list)
                                    {
                                        lblBlockListAttemptsToSolveBlock.Text = hashesToSolve;
                                    });
                                    lbl24HourTransCount.Invoke((MethodInvoker)delegate
                                    {
                                        lbl24HourTransCount.Text = twentyFourHourTransCount;
                                    });
                                    lbl24HourBTCSent.Invoke((MethodInvoker)delegate
                                    {
                                        lbl24HourBTCSent.Text = twentyFourHourBTCSent;
                                    });
                                }
                                else
                                {
                                    lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                                    {
                                        lblAvgNoTransactions.Text = "disabled";
                                    });
                                    lblBlockReward.Invoke((MethodInvoker)delegate
                                    {
                                        lblBlockReward.Text = "disabled";
                                    });
                                    lblBlockListBlockReward.Invoke((MethodInvoker)delegate // (Blocks list)
                                    {
                                        lblBlockListBlockReward.Text = "disabled";
                                    });
                                    lblBlockRewardAfterHalving.Invoke((MethodInvoker)delegate
                                    {
                                        lblBlockRewardAfterHalving.Text = "disabled";
                                    });
                                    lblBTCInCirc.Invoke((MethodInvoker)delegate
                                    {
                                        lblBTCInCirc.Text = "disabled";
                                    });
                                    lblHashesToSolve.Invoke((MethodInvoker)delegate
                                    {
                                        lblHashesToSolve.Text = "disabled";
                                    });
                                    lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // (Blocks list)
                                    {
                                        lblBlockListAttemptsToSolveBlock.Text = "disabled";
                                    });
                                    lbl24HourTransCount.Invoke((MethodInvoker)delegate
                                    {
                                        lbl24HourTransCount.Text = "disabled";
                                    });
                                    lbl24HourBTCSent.Invoke((MethodInvoker)delegate
                                    {
                                        lbl24HourBTCSent.Text = "disabled";
                                    });
                                }
                            }
                            else
                            {
                                lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                                {
                                    lblAvgNoTransactions.Text = "unavailable on TestNet";
                                });
                                lblBlockReward.Invoke((MethodInvoker)delegate
                                {
                                    lblBlockReward.Text = "unavailable on TestNet";
                                });
                                lblBlockListBlockReward.Invoke((MethodInvoker)delegate // (Blocks list)
                                {
                                    lblBlockListBlockReward.Text = "unavailable on TestNet";
                                });
                                lblBlockRewardAfterHalving.Invoke((MethodInvoker)delegate
                                {
                                    lblBlockRewardAfterHalving.Text = "unavailable on TestNet";
                                });
                                lblBTCInCirc.Invoke((MethodInvoker)delegate
                                {
                                    lblBTCInCirc.Text = "unavailable on TestNet";
                                });
                                lblHashesToSolve.Invoke((MethodInvoker)delegate
                                {
                                    lblHashesToSolve.Text = "unavailable on TestNet";
                                });
                                lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // (Blocks list)
                                {
                                    lblBlockListAttemptsToSolveBlock.Text = "unavailable on TestNet";
                                });
                                lbl24HourTransCount.Invoke((MethodInvoker)delegate
                                {
                                    lbl24HourTransCount.Text = "unavailable on TestNet";
                                });
                                lbl24HourBTCSent.Invoke((MethodInvoker)delegate
                                {
                                    lbl24HourBTCSent.Text = "unavailable on TestNet";
                                });
                            }
                            pictureBoxChartCirculation.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxChartCirculation.Location = new Point(lblBTCInCirc.Location.X + lblBTCInCirc.Width + 5, pictureBoxChartCirculation.Location.Y);
                            });
                            SetLightsMessagesAndResetTimers();
                        }
                        catch (Exception ex)
                        {
                            errorOccurred = true;
                            HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task2)");
                        }
                    }
                });
                #endregion
                #region blockchair.com api
                Task task5 = Task.Run(() =>  // blockchair.com JSON for chain stats
                {
                    try
                    {
                        if (!testNet)
                        {
                            if (RunBlockchairComJSONAPI)
                            {
                                var result7 = BlockchairComChainStatsJSONRefresh();
                                int hodling_addresses = int.Parse(result7.hodling_addresses);
                                if (hodling_addresses > 0) // this api sometimes doesn't populate this field with anything but 0
                                {
                                    lblHodlingAddresses.Invoke((MethodInvoker)delegate
                                    {
                                        lblHodlingAddresses.Text = result7.hodling_addresses;
                                    });
                                }
                                else
                                {
                                    lblHodlingAddresses.Invoke((MethodInvoker)delegate
                                    {
                                        lblHodlingAddresses.Text = "no data";
                                    });
                                }
                                lblBlocksIn24Hours.Invoke((MethodInvoker)delegate
                                {
                                    lblBlocksIn24Hours.Text = result7.blocks_24h;
                                });
                                lblNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblNodes.Text = result7.nodes;
                                });
                                dynamic blockchainSize = result7.blockchain_size;
                                double blockchainSizeGB = Math.Round(Convert.ToDouble(blockchainSize) / 1073741824.0, 2);
                                lblBlockchainSize.Invoke((MethodInvoker)delegate
                                {
                                    lblBlockchainSize.Text = blockchainSizeGB.ToString();
                                });
                            }
                            else
                            {
                                lblHodlingAddresses.Invoke((MethodInvoker)delegate
                                {
                                    lblHodlingAddresses.Text = "disabled";
                                });
                                lblBlocksIn24Hours.Invoke((MethodInvoker)delegate
                                {
                                    lblBlocksIn24Hours.Text = "disabled";
                                });
                                lblNodes.Invoke((MethodInvoker)delegate
                                {
                                    lblNodes.Text = "disabled";
                                });
                                lblBlockchainSize.Invoke((MethodInvoker)delegate
                                {
                                    lblBlockchainSize.Text = "disabled";
                                });
                            }
                        }
                        else
                        {
                            lblHodlingAddresses.Invoke((MethodInvoker)delegate
                            {
                                lblHodlingAddresses.Text = "unavailable on TestNet";
                            });
                            lblBlocksIn24Hours.Invoke((MethodInvoker)delegate
                            {
                                lblBlocksIn24Hours.Text = "unavailable on TestNet";
                            });
                            lblNodes.Invoke((MethodInvoker)delegate
                            {
                                lblNodes.Text = "unavailable on TestNet";
                            });
                            lblBlockchainSize.Invoke((MethodInvoker)delegate
                            {
                                lblBlockchainSize.Text = "unavailable on TestNet";
                            });
                        }
                        pictureBoxPoolRankingChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxPoolRankingChart.Location = new Point(lblBlocksIn24Hours.Location.X + lblBlocksIn24Hours.Width + 5, pictureBoxPoolRankingChart.Location.Y);
                        });
                        pictureBoxUniqueAddressesChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxUniqueAddressesChart.Location = new Point(lblHodlingAddresses.Location.X + lblHodlingAddresses.Width + 5, pictureBoxUniqueAddressesChart.Location.Y);
                        });
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task7)");
                    }
                });
                Task task6 = Task.Run(() =>  // blockchair.com JSON for halving stats
                {
                    try
                    {
                        if (!testNet)
                        {
                            if (RunBlockchairComJSONAPI)
                            {
                                var (halveningBlock, halveningReward, halveningTime, blocksLeft, seconds_left) = BlockchairComHalvingJSONRefresh();
                                lblHalveningBlock.Invoke((MethodInvoker)delegate
                                {
                                    lblHalveningBlock.Text = halveningBlock + " / " + blocksLeft;
                                });
                                int progressBarValue = 210000 - Convert.ToInt32(blocksLeft);
                                progressBarProgressToHalving.Value = progressBarValue;
                                progressBarBlockListHalvingProgress.Value = progressBarValue;
                                lblBlockListHalvingBlockAndRemaining.Invoke((MethodInvoker)delegate // Blocks list
                                {
                                    lblBlockListHalvingBlockAndRemaining.Text = halveningBlock + " / " + blocksLeft;
                                });
                                string halvening_time = halveningTime;
                                DateTime halveningDateTime = DateTime.ParseExact(halvening_time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                                string halveningDate = halveningDateTime.Date.ToString("yyyy-MM-dd");

                                lblEstimatedHalvingDate.Invoke((MethodInvoker)delegate
                                {
                                    lblEstimatedHalvingDate.Text = halveningDate + " / ";
                                });
                                lblHalvingSecondsRemaining.Invoke((MethodInvoker)delegate
                                {
                                    lblHalvingSecondsRemaining.Location = new Point(lblEstimatedHalvingDate.Location.X + lblEstimatedHalvingDate.Width - 8, lblEstimatedHalvingDate.Location.Y);
                                    lblHalvingSecondsRemaining.Text = seconds_left;
                                    ObtainedHalvingSecondsRemainingYet = true; // signifies that we can now start deducting from this
                                });
                            }
                            else
                            {
                                progressBarProgressToHalving.Value = 0;
                                progressBarBlockListHalvingProgress.Value = 0;
                                lblHalveningBlock.Invoke((MethodInvoker)delegate
                                {
                                    lblHalveningBlock.Text = "disabled";
                                });
                                lblBlockListHalvingBlockAndRemaining.Invoke((MethodInvoker)delegate // Blocks list
                                {
                                    lblBlockListHalvingBlockAndRemaining.Text = "disabled";
                                });

                                lblEstimatedHalvingDate.Invoke((MethodInvoker)delegate
                                {
                                    lblEstimatedHalvingDate.Text = "disabled";
                                });
                                lblHalvingSecondsRemaining.Invoke((MethodInvoker)delegate
                                {
                                    lblHalvingSecondsRemaining.Text = "disabled";
                                });
                            }
                        }
                        else
                        {
                            progressBarProgressToHalving.Value = 0;
                            progressBarBlockListHalvingProgress.Value = 0;
                            lblHalveningBlock.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningBlock.Text = "unavailable";
                            });
                            lblBlockListHalvingBlockAndRemaining.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListHalvingBlockAndRemaining.Text = "unavailable";
                            });

                            lblEstimatedHalvingDate.Invoke((MethodInvoker)delegate
                            {
                                lblEstimatedHalvingDate.Text = "unavailable on TestNet";
                            });
                            lblHalvingSecondsRemaining.Invoke((MethodInvoker)delegate
                            {
                                lblHalvingSecondsRemaining.Text = "";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task8)");
                    }
                });
                #endregion
                await Task.WhenAll(task0, task1, task2, task3, task4, task5, task6);

                if (errorOccurred)
                {
                    intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.ForeColor = Color.Red;
                    });
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.Text = "🔴"; 
                    });
                    lblRefreshSuccessOrFailMessage.Invoke((MethodInvoker)delegate
                    {
                        lblRefreshSuccessOrFailMessage.Text = "One or more fields failed to update";
                    });
                }
            }
            ToggleLoadingAnimation("disable");
        }
        #endregion
        #region chart icon clicks
        private void PictureBoxHashrateChart_Click(object sender, EventArgs e)
        {
            BtnChartHashrate_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxDifficultyChart_Click(object sender, EventArgs e)
        {
            BtnChartDifficulty_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxPriceChart_Click(object sender, EventArgs e)
        {
            BtnChartPrice_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxPoolRankingChart_Click(object sender, EventArgs e)
        {
            BtnChartPoolsRanking_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxMarketCapChart_Click(object sender, EventArgs e)
        {
            BtnChartMarketCap_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxUniqueAddressesChart_Click(object sender, EventArgs e)
        {
            BtnChartUniqueAddresses_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxFeeRangeChart_Click(object sender, EventArgs e)
        {
            BtnChartFeeRates_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxBlockFeesChart_Click(object sender, EventArgs e)
        {
            BtnChartBlockFees_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxLightningCapacityChart_Click(object sender, EventArgs e)
        {
            BtnChartLightningCapacity_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxLightningNodesChart_Click(object sender, EventArgs e)
        {
            BtnChartNodesByNetwork_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxLightningChannelsChart_Click(object sender, EventArgs e)
        {
            BtnChartLightningChannels_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxConverterChart_Click(object sender, EventArgs e)
        {
            BtnPriceConverter_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }
        #endregion
        #region api calls for dashboards
        private (string currentHashrate, string currentDifficulty) GetHashrate()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/mining/hashrate/3d");
                var data = JObject.Parse(response);
                string currentHashrate = Convert.ToString(data["currentHashrate"]);
                string currentDifficulty = Convert.ToString(data["currentDifficulty"]);
                return (currentHashrate, currentDifficulty);
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetHashrate");
            }
            return ("error", "error");
        }

        private (string fastestFee, string halfHourFee, string hourFee, string economyFee, string minimumFee) GetFees()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/fees/recommended");
                var data = JObject.Parse(response);
                string fastestFee = Convert.ToString(data["fastestFee"]);
                string halfHourFee = Convert.ToString(data["halfHourFee"]);
                string hourFee = Convert.ToString(data["hourFee"]);
                string economyFee = Convert.ToString(data["economyFee"]);
                string minimumFee = Convert.ToString(data["minimumFee"]);
                return (fastestFee, halfHourFee, hourFee, economyFee, minimumFee);
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetFees");
            }
            return ("error", "error", "error", "error", "error");
        }

        private (string progressPercent, string difficultyChange, string estimatedRetargetDate, string remainingBlocks, string remainingTime, string previousRetarget, string nextRetargetHeight, string timeAvg, string timeOffset) GetDifficultyAdjustment()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/difficulty-adjustment");
                var data = JObject.Parse(response);
                string progressPercent = Convert.ToString(data["progressPercent"]);
                decimal difficultyChangeFull = (decimal)data["difficultyChange"];
                string difficultyChange = Math.Round(difficultyChangeFull, 2).ToString();
                string estimatedRetargetDate = Convert.ToString(data["estimatedRetargetDate"]);
                string remainingBlocks = Convert.ToString(data["remainingBlocks"]);
                string remainingTime = Convert.ToString(data["remainingTime"]);
                string previousRetarget = Convert.ToString(data["previousRetarget"]);
                string nextRetargetHeight = Convert.ToString(data["nextRetargetHeight"]);
                string timeAvg = Convert.ToString(data["timeAvg"]);
                string timeOffset = Convert.ToString(data["timeOffset"]);
                return (progressPercent, difficultyChange, estimatedRetargetDate, remainingBlocks, remainingTime, previousRetarget, nextRetargetHeight, timeAvg, timeOffset);
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetDifficultyAdjustment");
            }
            return ("error", "error", "error", "error", "error", "error", "error", "error", "error");
        }

        private (string priceUSD, string priceGBP, string priceEUR, string priceXAU) BitcoinExplorerOrgGetPrice()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://bitcoinexplorer.org/api/price");
                var data = JObject.Parse(response);
                string priceUSD = Convert.ToString(data["usd"]);
                string priceGBP = Convert.ToString(data["gbp"]);
                string priceEUR = Convert.ToString(data["eur"]);
                string priceXAU = Convert.ToString(data["xau"]);
                return (priceUSD, priceGBP, priceEUR, priceXAU);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BitcoinExplorerOrgGetPrice");
            }
            return ("error", "error", "error", "error");
        }

        private (string mCapUSD, string mCapGBP, string mCapEUR, string mCapXAU) BitcoinExplorerOrgGetMarketCap()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://bitcoinexplorer.org/api/price/marketcap");
                var data = JObject.Parse(response);
                string mCapUSD = Convert.ToString(data["usd"]);
                string mCapGBP = Convert.ToString(data["gbp"]);
                string mCapEUR = Convert.ToString(data["eur"]);
                string mCapXAU = Convert.ToString(data["xau"]);
                return (mCapUSD, mCapGBP, mCapEUR, mCapXAU);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BitcoinExplorerOrgGetMarketCap");
            }
            return ("error", "error", "error", "error");
        }

        private (string satsUSD, string satsGBP, string satsEUR, string satsXAU) BitcoinExplorerOrgGetMoscowTime()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://bitcoinexplorer.org/api/price/sats");
                var data = JObject.Parse(response);
                string satsUSD = Convert.ToString(data["usd"]);
                string satsGBP = Convert.ToString(data["gbp"]);
                string satsEUR = Convert.ToString(data["eur"]);
                string satsXAU = Convert.ToString(data["xau"]);
                return (satsUSD, satsGBP, satsEUR, satsXAU);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BitcoinExplorerOrgGetMoscowTime");
            }
            return ("error", "error", "error", "error");
        }

        private (string txCount, string vSize, string totalFees) GetMempool()
        {
            try
            {

                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "mempool");
                if (testNet)
                {
                    response = client.DownloadString("https://mempool.space/testnet/api/mempool");
                }
                var data = JObject.Parse(response);
                string txCount = Convert.ToString(data["count"]);
                string vSize = Convert.ToString(data["vsize"]);
                string totalFees = Convert.ToString(data["total_fee"]);
                return (txCount, vSize, totalFees);
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetMempool");
            }
            return ("error", "error", "error");
        }

        private (string avgNoTransactions, string blockNumber, string blockReward, string estHashrate, string avgTimeBetweenBlocks, string btcInCirc, string hashesToSolve, string twentyFourHourTransCount, string twentyFourHourBTCSent) BlockchainInfoEndpointsRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                string avgNoTransactions = client.DownloadString("https://blockchain.info/q/avgtxnumber"); // average number of transactions in last 100 blocks (to about 6 decimal places!)
                double dblAvgNoTransactions = Convert.ToDouble(avgNoTransactions);
                dblAvgNoTransactions = Math.Round(dblAvgNoTransactions); // so lets get it down to an integer
                string avgNoTransactionsText = Convert.ToString(dblAvgNoTransactions);
                string blockNumber = client.DownloadString("https://blockchain.info/q/getblockcount"); // most recent block number
                string blockReward = client.DownloadString("https://blockchain.info/q/bcperblock"); // current block reward
                string estHashrate = client.DownloadString("https://blockchain.info/q/hashrate"); // hashrate estimate
                string secondsBetweenBlocks = client.DownloadString("https://blockchain.info/q/interval"); // average time between blocks in seconds
                double dblSecondsBetweenBlocks = Convert.ToDouble(secondsBetweenBlocks);
                TimeSpan time = TimeSpan.FromSeconds(dblSecondsBetweenBlocks);
                string timeString = string.Format("{0:%m}m {0:%s}s", time);
                string avgTimeBetweenBlocks = timeString;
                string totalBTC = client.DownloadString("https://blockchain.info/q/totalbc"); // total sats in circulation
                string btcInCirc = ConvertSatsToBitcoin(totalBTC).ToString();
                string hashesToSolve = client.DownloadString("https://blockchain.info/q/hashestowin"); // avg number of hashes to win a block
                string twentyFourHourTransCount = client.DownloadString("https://blockchain.info/q/24hrtransactioncount"); // number of transactions in last 24 hours
                string twentyFourHourBTCSent = client.DownloadString("https://blockchain.info/q/24hrbtcsent"); // number of sats sent in 24 hours
                twentyFourHourBTCSent = ConvertSatsToBitcoin(twentyFourHourBTCSent).ToString();
                return (avgNoTransactionsText, blockNumber, blockReward, estHashrate, avgTimeBetweenBlocks, btcInCirc, hashesToSolve, twentyFourHourTransCount, twentyFourHourBTCSent);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BlockchainInfoEndpointsRefresh");
            }
            return ("0", "0", "0", "0", "0", "0", "0", "0", "0");
        }

        private (List<string> aliases, List<string> capacities) MempoolSpaceLiquidityRankingJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/lightning/nodes/rankings/liquidity");
                var data = JArray.Parse(response);

                List<string> aliases = new List<string>();
                List<string> capacities = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    aliases.Add((string)data[i]["alias"]);
                    string capacity = (string)data[i]["capacity"];
                    capacity = ConvertSatsToBitcoin(capacity).ToString();
                    double dblCapacity = Convert.ToDouble(capacity);
                    dblCapacity = Math.Round(dblCapacity, 2); // round to 2 decimal places
                    capacity = Convert.ToString(dblCapacity);
                    capacities.Add(capacity);
                }
                return (aliases, capacities);
            }
            catch (Exception ex)
            {
                HandleException(ex, "MempoolSpaceLiquidityRankingJSONRefresh");
            }
            return (new List<string>(), new List<string>());
        }

        private (List<string> aliases, List<string> channels) MempoolSpaceConnectivityRankingJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/lightning/nodes/rankings/connectivity");
                var data = JArray.Parse(response);

                List<string> aliases = new List<string>();
                List<string> channels = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    aliases.Add((string)data[i]["alias"]);
                    channels.Add((string)data[i]["channels"]);
                }
                return (aliases, channels);
            }
            catch (Exception ex)
            {
                HandleException(ex, "MempoolSpaceConnectivityRankingJSONRefresh");
            }
            return (new List<string>(), new List<string>());
        }

        private (string clearnetCapacity, string torCapacity, string unknownCapacity) MempoolSpaceCapacityBreakdownJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/lightning/nodes/isp-ranking");
                var data = JObject.Parse(response);
                string clearnetCapacityString = Convert.ToString(data["clearnetCapacity"]);
                string clearnetCapacity = ConvertSatsToBitcoin(clearnetCapacityString).ToString();
                double dblClearnetCapacity = Convert.ToDouble(clearnetCapacity);
                dblClearnetCapacity = Math.Round(dblClearnetCapacity, 2); // round to 2 decimal places
                clearnetCapacity = Convert.ToString(dblClearnetCapacity);
                string torCapacityString = Convert.ToString(data["torCapacity"]);
                string torCapacity = ConvertSatsToBitcoin(torCapacityString).ToString();
                double dblTorCapacity = Convert.ToDouble(torCapacity);
                dblTorCapacity = Math.Round(dblTorCapacity, 2);
                torCapacity = Convert.ToString(dblTorCapacity);
                string unknownCapacityString = Convert.ToString(data["unknownCapacity"]);
                string unknownCapacity = ConvertSatsToBitcoin(unknownCapacityString).ToString();
                double dblUnknownCapacity = Convert.ToDouble(unknownCapacity);
                dblUnknownCapacity = Math.Round(dblUnknownCapacity, 2);
                unknownCapacity = Convert.ToString(dblUnknownCapacity);
                return (clearnetCapacity, torCapacity, unknownCapacity);
            }
            catch (Exception ex)
            {
                HandleException(ex, "MempoolSpaceCapacityBreakdownJSONRefresh");
            }
            return ("0", "0", "0");
        }

        private (string channelCount, string nodeCount, string totalCapacity, string torNodes, string clearnetNodes, string unannouncedNodes, string avgCapacity, string avgFeeRate, string avgBaseeFeeMtokens, string medCapacity, string medFeeRate, string medBaseeFeeMtokens, string clearnetTorNodes) MempoolSpaceLightningJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString(NodeURL + "v1/lightning/statistics/latest");
                var data = JObject.Parse(response);
                var channelCount = (string)data["latest"]["channel_count"];
                var nodeCount = (string)data["latest"]["node_count"];
                string totalCapacityString = Convert.ToString(data["latest"]["total_capacity"]);
                string totalCapacity = ConvertSatsToBitcoin(totalCapacityString).ToString();
                double dblTotalCapacity = Convert.ToDouble(totalCapacity);
                dblTotalCapacity = Math.Round(dblTotalCapacity, 2);
                totalCapacity = Convert.ToString(dblTotalCapacity);
                var torNodes = (string)data["latest"]["tor_nodes"];
                var clearnetNodes = (string)data["latest"]["clearnet_nodes"];
                var unannouncedNodes = (string)data["latest"]["unannounced_nodes"];
                var avgCapacity = (string)data["latest"]["avg_capacity"];
                var avgFeeRate = (string)data["latest"]["avg_fee_rate"];
                var avgBaseeFeeMtokens = (string)data["latest"]["avg_base_fee_mtokens"];
                var medCapacity = (string)data["latest"]["med_capacity"];
                var medFeeRate = (string)data["latest"]["med_fee_rate"];
                var medBaseeFeeMtokens = (string)data["latest"]["med_basee_fee_mtokens"];
                medBaseeFeeMtokens ??= "0";
                var clearnetTorNodes = (string)data["latest"]["clearnet_tor_nodes"];
                return (channelCount, nodeCount, totalCapacity, torNodes, clearnetNodes, unannouncedNodes, avgCapacity, avgFeeRate, avgBaseeFeeMtokens, medCapacity, medFeeRate, medBaseeFeeMtokens, clearnetTorNodes);
            }
            catch (Exception ex)
            {
                HandleException(ex, "MempoolSpaceLightningJSONRefresh");
            }
            return ("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
        }

        private (string nextBlockFee, string thirtyMinFee, string sixtyMinFee, string oneDayFee, string txInNextBlock, string nextBlockMinFee, string nextBlockMaxFee, string nextBlockTotalFees) BitcoinExplorerOrgJSONRefresh()
        {
            try
            {
                // fees
                var client = new HttpClient();
                var response = client.GetAsync("https://bitcoinexplorer.org/api/mempool/fees").Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JObject.Parse(json);
                var nextBlockFee = (string)data["nextBlock"];
                var thirtyMinFee = (string)data["30min"];
                var sixtyMinFee = (string)data["60min"];
                var oneDayFee = (string)data["1day"];
                // next block
                var response2 = client.GetAsync("https://bitcoinexplorer.org/api/mining/next-block").Result;
                var json2 = response2.Content.ReadAsStringAsync().Result;
                var data2 = JObject.Parse(json2);
                var txInNextBlock = (string)data2["txCount"];
                var nextBlockMinFee = (string)data2["minFeeRate"];
                double valuetoround = Convert.ToDouble(nextBlockMinFee);
                double roundedValue = Math.Round(valuetoround, 2);
                nextBlockMinFee = Convert.ToString(roundedValue);
                var nextBlockMaxFee = (string)data2["maxFeeRate"];
                valuetoround = Convert.ToDouble(nextBlockMaxFee);
                roundedValue = Math.Round(valuetoround, 2);
                nextBlockMaxFee = Convert.ToString(roundedValue);
                var nextBlockTotalFees = (string)data2["totalFees"];
                valuetoround = Convert.ToDouble(nextBlockTotalFees);
                roundedValue = Math.Round(valuetoround, 2);
                nextBlockTotalFees = Convert.ToString(roundedValue);
                return (nextBlockFee, thirtyMinFee, sixtyMinFee, oneDayFee, txInNextBlock, nextBlockMinFee, nextBlockMaxFee, nextBlockTotalFees);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BitcoinExplorerOrgJSONRefresh");
            }
            return ("0", "0", "0", "0", "0", "0", "0", "0");
        }

        private (string halveningBlock, string halveningReward, string halveningTime, string blocksLeft, string seconds_left) BlockchairComHalvingJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://api.blockchair.com/tools/halvening");
                var data = JObject.Parse(response);
                var halveningBlock = (string)data["data"]["bitcoin"]["halvening_block"];
                var halveningReward = (string)data["data"]["bitcoin"]["halvening_reward"];
                var halveningTime = (string)data["data"]["bitcoin"]["halvening_time"];
                var blocksLeft = (string)data["data"]["bitcoin"]["blocks_left"];
                var seconds_left = (string)data["data"]["bitcoin"]["seconds_left"];
                return (halveningBlock, halveningReward, halveningTime, blocksLeft, seconds_left);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BlockchairComHalvingJSONRefresh");
            }
            return ("0", "0", "0", "0", "0");
        }

        private (string hodling_addresses, string blocks_24h, string nodes, string blockchain_size) BlockchairComChainStatsJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://api.blockchair.com/bitcoin/stats");
                var data = JObject.Parse(response);
                var hodling_addresses = (string)data["data"]["hodling_addresses"];
                var blocks_24h = (string)data["data"]["blocks_24h"];
                var nodes = (string)data["data"]["nodes"];
                var blockchain_size = (string)data["data"]["blockchain_size"];
                return (hodling_addresses, blocks_24h, nodes, blockchain_size);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BlockchairComJSONRefresh");
            }
            return ("0", "0", "0", "0");
        }
        #endregion
        #region update seconds to halving
        private void UpdateSecondsToHalving()
        {
            try
            {
                if (!testNet)
                {
                    if (ObtainedHalvingSecondsRemainingYet) // only want to do this if we've already retrieved seconds remaining until halvening
                    {
                        string secondsString = lblHalvingSecondsRemaining.Text;
                        try
                        {
                            int SecondsToHalving = int.Parse(secondsString);
                            if (SecondsToHalving > 0)
                            {
                                SecondsToHalving--; // one second closer to the halvening!
                                lblHalvingSecondsRemaining.Invoke((MethodInvoker)delegate
                                {
                                    lblHalvingSecondsRemaining.Text = SecondsToHalving.ToString();
                                });
                            }
                        }
                        catch
                        {
                            lblHalvingSecondsRemaining.Invoke((MethodInvoker)delegate
                            {
                                lblHalvingSecondsRemaining.Text = "disabled";
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "UpdateSecondsToHalving");
            }
        }
        #endregion
        #region draw lines between fields on lightning dashboard
        private void PanelLightningDashboard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                using Pen pen = new Pen(linesColor, 1);
                // Capacity connecting lines
                e.Graphics.DrawLine(pen, lblTotalCapacity.Right, lblTotalCapacity.Top + (lblTotalCapacity.Height / 2), lblClearnetCapacity.Left, lblClearnetCapacity.Top + (lblClearnetCapacity.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblTotalCapacity.Top + (lblTotalCapacity.Height / 2), (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblUnknownCapacity.Top + (lblUnknownCapacity.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblTorCapacity.Top + (lblTorCapacity.Height / 2), lblTorCapacity.Left, lblTorCapacity.Top + (lblTorCapacity.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblUnknownCapacity.Top + (lblUnknownCapacity.Height / 2), lblUnknownCapacity.Left, lblUnknownCapacity.Top + (lblUnknownCapacity.Height / 2));
                // Node connecting lines
                e.Graphics.DrawLine(pen, lblNodeCount.Right, lblNodeCount.Top + (lblNodeCount.Height / 2), lblTorNodes.Left, lblTorNodes.Top + (lblTorNodes.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblTorNodes.Top + (lblTorNodes.Height / 2), (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblUnannouncedNodes.Top + (lblUnannouncedNodes.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblClearnetNodes.Top + (lblClearnetNodes.Height / 2), lblClearnetNodes.Left, lblClearnetNodes.Top + (lblClearnetNodes.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblClearnetTorNodes.Top + (lblClearnetTorNodes.Height / 2), lblClearnetTorNodes.Left, lblClearnetTorNodes.Top + (lblClearnetTorNodes.Height / 2));
                e.Graphics.DrawLine(pen, (lblTotalCapacity.Right + lblClearnetCapacity.Left) / 2, lblUnannouncedNodes.Top + (lblUnannouncedNodes.Height / 2), lblUnannouncedNodes.Left, lblUnannouncedNodes.Top + (lblUnannouncedNodes.Height / 2));
                // Channel connecting lines
                e.Graphics.DrawLine(pen, lblChannelCount.Right, lblChannelCount.Top + (lblChannelCount.Height / 2), lblAverageCapacity.Left, lblAverageCapacity.Top + (lblAverageCapacity.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblChannelCount.Top + (lblChannelCount.Height / 2), (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblMedBaseFeeTokens.Top + (lblMedBaseFeeTokens.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblAverageFeeRate.Top + (lblAverageFeeRate.Height / 2), lblAverageFeeRate.Left, lblAverageFeeRate.Top + (lblAverageFeeRate.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblAverageBaseFeeMtokens.Top + (lblAverageBaseFeeMtokens.Height / 2), lblAverageBaseFeeMtokens.Left, lblAverageBaseFeeMtokens.Top + (lblAverageBaseFeeMtokens.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblMedCapacity.Top + (lblMedCapacity.Height / 2), lblMedCapacity.Left, lblMedCapacity.Top + (lblMedCapacity.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblMedFeeRate.Top + (lblMedFeeRate.Height / 2), lblMedFeeRate.Left, lblMedFeeRate.Top + (lblMedFeeRate.Height / 2));
                e.Graphics.DrawLine(pen, (lblChannelCount.Right + lblAverageCapacity.Left) / 2, lblMedBaseFeeTokens.Top + (lblMedBaseFeeTokens.Height / 2), lblMedBaseFeeTokens.Left, lblMedBaseFeeTokens.Top + (lblMedBaseFeeTokens.Height / 2));
            }
            catch (WebException ex)
            {
                HandleException(ex, "Drawing connectors on lightning dashboard");
            }
        }
        #endregion
        #endregion

        #region ⚡ADDRESS SCREEN⚡
        #region setup address screen
        private async void TboxSubmittedAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;
                listViewAddressTransactions.Items.Clear(); // wipe any data in the transaction listview
                TotalAddressTransactionRowsAdded = 0;

                string addressString = textboxSubmittedAddress.Text; // supplied address

                string addressType = DetermineAddressType(addressString); // check address is valid and what type of address
                if (addressType == "P2PKH (legacy)" || addressType == "P2SH" || addressType == "P2WPKH (segwit)" || addressType == "P2WSH" || addressType == "P2TT (taproot)" || addressType == "unknown") // address is valid
                {
                    ToggleLoadingAnimation("enable"); // start the loading animation
                    DisableEnableAddressButtons("disable"); // disable buttons during operation
                    lblInvalidAddressIndicator.Invoke((MethodInvoker)delegate
                    {
                        lblInvalidAddressIndicator.ForeColor = Color.OliveDrab;
                        lblInvalidAddressIndicator.Text = "✔️ valid address";
                    });
                    AddressValidShowControls();
                    lblAddressType.Invoke((MethodInvoker)delegate
                    {
                        lblAddressType.Text = addressType + " address";
                    });
                    // generate QR code for address
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(addressString, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    var qrCodeImage = qrCode.GetGraphic(20, Color.Gray, Color.Black, false);
                    qrCodeImage.MakeTransparent(Color.Black);
                    AddressQRCodePicturebox.Invoke((MethodInvoker)delegate
                    {
                        AddressQRCodePicturebox.Image = qrCodeImage;
                    });
                    try
                    {
                        await GetAddressBalanceAsync(addressString); // make sure we get these results before processing transactions
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, "TboxSubmittedAddress_TextChanged (Error getting address balance)");
                        return;
                    }
                    string lastSeenTxId = "0"; // start from the top of the JSON (most recent tx)
                    try
                    {
                        await GetTransactionsForAddress(addressString, lastSeenTxId); // get first batch of transactions
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, "TboxSubmittedAddress_TextChanged (Error getting first batch of transactions for address)");
                        return;
                    }
                    DisableEnableAddressButtons("enable"); // enable the buttons that were previously enabled again
                    ToggleLoadingAnimation("disable"); // stop the loading animation
                }
                else
                {
                    if (addressString == "")
                    {
                        lblInvalidAddressIndicator.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidAddressIndicator.Text = "";
                        });
                    }
                    else
                    {
                        lblInvalidAddressIndicator.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidAddressIndicator.ForeColor = Color.IndianRed;
                            lblInvalidAddressIndicator.Text = "✖️ invalid address";
                        });
                    }
                    lblAddressType.Invoke((MethodInvoker)delegate
                    {
                        lblAddressType.Text = "Invalid address format";
                    });
                    AddressQRCodePicturebox.Invoke((MethodInvoker)delegate
                    {
                        AddressQRCodePicturebox.Image = null;
                    });
                    lblAddressConfirmedReceived.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceived.Text = string.Empty;
                    });
                    lblAddressConfirmedReceivedOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceivedOutputs.Text = string.Empty;
                    });
                    lblAddressConfirmedSpent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpent.Text = string.Empty;
                    });
                    lblAddressConfirmedSpentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpentOutputs.Text = string.Empty;
                    });
                    lblAddressConfirmedTransactionCount.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedTransactionCount.Text = string.Empty;
                    });
                    lblAddressConfirmedUnspent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspent.Text = string.Empty;
                    });
                    lblAddressConfirmedUnspentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspentOutputs.Text = string.Empty;
                    });
                    AddressInvalidHideControls();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TboxSubmittedAddress_TextChanged");
            }
        }

        //---------------------- DETERMINE BITCOIN ADDRESS TYPE--------------------------------------------------------
        private string DetermineAddressType(string address)
        {
            try
            {
                NBitcoin.BitcoinAddress bitcoinAddress;
                if (NodeURL == "https://mempool.space/api/") //mempool.space mainnet
                {
                    bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.Main);
                }
                else
                {
                    if (NodeURL == "https://mempool.space/testnet/api/") //mempool.space testnet
                    {
                        bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.TestNet);
                    }
                    else
                    {
                        bool containsTestnet = NodeURL.Contains("testnet");
                        if (containsTestnet) // own node, testnet
                        {
                            bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.TestNet);
                        }
                        else //own node, mainnet
                        {
                            bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.Main);
                        }

                    }
                }

                if (bitcoinAddress is BitcoinPubKeyAddress)
                {
                    return "P2PKH (legacy)"; // Legacy P2PKH
                }
                else if (bitcoinAddress is BitcoinScriptAddress)
                {
                    return "P2SH"; // (pay-to-script-hash) Multisig P2SH
                }
                else if (bitcoinAddress is BitcoinWitPubKeyAddress)
                {
                    return "P2WPKH (segwit)"; // P2WPKH
                }
                else if (bitcoinAddress is BitcoinWitScriptAddress)
                {
                    return "P2WSH"; // (pay-to- witness-script-hash) P2WSH 
                }
                else if (address.StartsWith("bc1p") && (address.Length > 41 || address.Length < 73))
                {
                    for (int i = 4; i < address.Length - 4; i++)
                    {
                        char c = address[i];
                        if (((c >= '0' && c <= '9') || (c >= 'q' && c <= 'z')))
                        {
                            return "P2TT (taproot)";
                        }
                    }
                }
                return "unknown";
            }
            catch (FormatException)
            {
                return "Invalid address format";
            }
        }

        //------------------------------------------ GET ADDRESS BALANCE-----------------------------------------------
        private async Task GetAddressBalance(string addressString)
        {
            try
            {
                var request = "address/" + addressString;
                var RequestURL = NodeURL + request;
                var client = new HttpClient();
                var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
                if (!response.IsSuccessStatusCode)
                {
                    lblSettingsCustomNodeStatusLight.ForeColor = Color.Red;
                    lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatus.Text = "Disconnected/error";
                    });
                    lblErrorMessage.Invoke((MethodInvoker)delegate
                    {
                        lblErrorMessage.Text = "Node offline/disconnected: ";
                    });
                    return;
                }
                var jsonData = await response.Content.ReadAsStringAsync();
                var addressData = JObject.Parse(jsonData);

                if (addressScreenConfUnconfOrAllTx == "chain" && !PartOfAnAllAddressTransactionsRequest)  //confirmed stats only. 'All' reverts to 'chain' after the first query, so we need to exclude those
                {
                    label61.Invoke((MethodInvoker)delegate
                    {
                        label61.Text = "Confirmed unspent (balance)";
                    });
                    label59.Invoke((MethodInvoker)delegate
                    {
                        label59.Text = "Confirmed transaction count";
                    });
                    label67.Invoke((MethodInvoker)delegate
                    {
                        label67.Text = "Confirmed received";
                    });
                    label63.Invoke((MethodInvoker)delegate
                    {
                        label63.Text = "Confirmed spent";
                    });
                    lblAddressConfirmedTransactionCount.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedTransactionCount.Text = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                    });
                    lblAddressConfirmedReceived.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceived.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["chain_stats"]["funded_txo_sum"])).ToString();
                    });
                    lblAddressConfirmedReceivedOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                        lblAddressConfirmedReceivedOutputs.Text = "(" + addressData["chain_stats"]["funded_txo_count"] + " outputs)";
                    });
                    lblAddressConfirmedSpent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpent.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["chain_stats"]["spent_txo_sum"])).ToString();
                    });
                    lblAddressConfirmedSpentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                        lblAddressConfirmedSpentOutputs.Text = "(" + addressData["chain_stats"]["spent_txo_count"] + " outputs)";
                    });
                    var fundedTx = Convert.ToDouble(addressData["chain_stats"]["funded_txo_count"]);
                    var spentTx = Convert.ToDouble(addressData["chain_stats"]["spent_txo_count"]);
                    var confirmedReceived = Convert.ToDouble(addressData["chain_stats"]["funded_txo_sum"]);
                    var confirmedSpent = Convert.ToDouble(addressData["chain_stats"]["spent_txo_sum"]);
                    var confirmedUnspent = confirmedReceived - confirmedSpent;
                    var unSpentTxOutputs = fundedTx - spentTx;
                    lblAddressConfirmedUnspent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspent)).ToString();
                    });
                    lblAddressConfirmedUnspentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                        lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(unSpentTxOutputs) + " outputs)";
                    });
                }
                if (addressScreenConfUnconfOrAllTx == "mempool") //mempool stats only
                {
                    label61.Invoke((MethodInvoker)delegate
                    {
                        label61.Text = "Unconfirmed unspent (balance)";
                    });
                    label59.Invoke((MethodInvoker)delegate
                    {
                        label59.Text = "Unconfirmed transaction count";
                    });
                    label67.Invoke((MethodInvoker)delegate
                    {
                        label67.Text = "Unconfirmed received";
                    });
                    label63.Invoke((MethodInvoker)delegate
                    {
                        label63.Text = "Unconfirmed spent";
                    });
                    lblAddressConfirmedTransactionCount.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedTransactionCount.Text = Convert.ToString(addressData["mempool_stats"]["tx_count"]);
                    });
                    lblAddressConfirmedReceived.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceived.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["mempool_stats"]["funded_txo_sum"])).ToString();
                    });
                    lblAddressConfirmedReceivedOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                        lblAddressConfirmedReceivedOutputs.Text = "(" + addressData["mempool_stats"]["funded_txo_count"] + " outputs)";
                    });
                    lblAddressConfirmedSpent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpent.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["mempool_stats"]["spent_txo_sum"])).ToString();
                    });
                    lblAddressConfirmedSpentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                        lblAddressConfirmedSpentOutputs.Text = "(" + addressData["mempool_stats"]["spent_txo_count"] + " outputs)";
                    });
                    var fundedTx = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_count"]);
                    var spentTx = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_count"]);
                    var confirmedReceived = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_sum"]);
                    var confirmedSpent = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_sum"]);
                    var confirmedUnspent = confirmedReceived - confirmedSpent;
                    var unSpentTxOutputs = fundedTx - spentTx;
                    lblAddressConfirmedUnspent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspent)).ToString();
                    });
                    lblAddressConfirmedUnspentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                        lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(unSpentTxOutputs) + " outputs)";
                    });
                }
                if (addressScreenConfUnconfOrAllTx == "all" || (addressScreenConfUnconfOrAllTx == "chain" && PartOfAnAllAddressTransactionsRequest)) // all TXs so will need to add chain and mempool amounts together before displaying. 
                {
                    label61.Invoke((MethodInvoker)delegate
                    {
                        label61.Text = "Total unspent (balance)";
                    });
                    label59.Invoke((MethodInvoker)delegate
                    {
                        label59.Text = "Total transaction count";
                    });
                    label67.Invoke((MethodInvoker)delegate
                    {
                        label67.Text = "Total received";
                    });
                    label63.Invoke((MethodInvoker)delegate
                    {
                        label63.Text = "Total spent";
                    });
                    int chainTransactionCount = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                    int mempoolTransactionCount = Convert.ToInt32(addressData["mempool_stats"]["tx_count"]);
                    int totalTransactionCount = chainTransactionCount + mempoolTransactionCount;
                    lblAddressConfirmedTransactionCount.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedTransactionCount.Text = Convert.ToString(totalTransactionCount);
                    });

                    long chainReceived = Convert.ToInt64(addressData["chain_stats"]["funded_txo_sum"]);
                    long mempoolReceived = Convert.ToInt64(addressData["mempool_stats"]["funded_txo_sum"]);
                    long totalReceived = chainReceived + mempoolReceived;
                    decimal BTCtotalReceived = ConvertSatsToBitcoin(totalReceived.ToString());
                    lblAddressConfirmedReceived.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceived.Text = Convert.ToString(BTCtotalReceived);
                    });

                    int chainReceivedOutputs = Convert.ToInt32(addressData["chain_stats"]["funded_txo_count"]);
                    int mempoolReceivedOutputs = Convert.ToInt32(addressData["mempool_stats"]["funded_txo_count"]);
                    int totalReceivedOutputs = chainReceivedOutputs + mempoolReceivedOutputs;
                    lblAddressConfirmedReceivedOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                        lblAddressConfirmedReceivedOutputs.Text = "(" + totalReceivedOutputs + " outputs)";
                    });

                    long chainSpent = Convert.ToInt64(addressData["chain_stats"]["spent_txo_sum"]);
                    long mempoolSpent = Convert.ToInt64(addressData["mempool_stats"]["spent_txo_sum"]);
                    long totalSpent = chainSpent + mempoolSpent;
                    decimal BTCtotalSpent = ConvertSatsToBitcoin(totalSpent.ToString());
                    lblAddressConfirmedSpent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpent.Text = Convert.ToString(BTCtotalSpent);
                    });

                    int chainSpentOutputs = Convert.ToInt32(addressData["chain_stats"]["spent_txo_count"]);
                    int mempoolSpentOutputs = Convert.ToInt32(addressData["mempool_stats"]["spent_txo_count"]);
                    int totalSpentOutputs = chainSpentOutputs + mempoolSpentOutputs;
                    lblAddressConfirmedSpentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                        lblAddressConfirmedSpentOutputs.Text = "(" + totalSpentOutputs + " outputs)";
                    });

                    var chainFundedTx = Convert.ToDouble(addressData["chain_stats"]["funded_txo_count"]);
                    var chainSpentTx = Convert.ToDouble(addressData["chain_stats"]["spent_txo_count"]);
                    var chainReceived2 = Convert.ToDouble(addressData["chain_stats"]["funded_txo_sum"]);
                    var chainSpent2 = Convert.ToDouble(addressData["chain_stats"]["spent_txo_sum"]);
                    var mempoolFundedTx = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_count"]);
                    var mempoolSpentTx = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_count"]);
                    var mempoolReceived2 = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_sum"]);
                    var mempoolSpent2 = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_sum"]);

                    var chainUnspent = chainReceived2 - chainSpent2;
                    var chainUnspentTxOutputs = chainFundedTx - chainSpentTx;
                    var mempoolUnspent = mempoolReceived2 - mempoolSpent2;
                    var mempoolUnspentTxOutputs = mempoolFundedTx - mempoolSpentTx;

                    var totalUnspent = chainUnspent + mempoolUnspent;
                    var totalUnspentTXOutputs = chainUnspentTxOutputs + mempoolUnspentTxOutputs;

                    lblAddressConfirmedUnspent.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(totalUnspent)).ToString();
                    });
                    lblAddressConfirmedUnspentOutputs.Invoke((MethodInvoker)delegate
                    {
                        lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                        lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(totalUnspentTXOutputs) + " outputs)";
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetAddressBalance");
            }
        }

        private async Task GetAddressBalanceAsync(string addressString)
        {
            await GetAddressBalance(addressString);
        }

        //-------------------------------- GET TRANSACTIONS FOR ADDRESS -----------------------------------------------
        private async Task GetTransactionsForAddress(string addressString, string lastSeenTxId)
        {
            try
            {
                if (NodeURL == "https://mempool.space/api/" || NodeURL == "https://mempool.space/testnet/api/")
                {
                    rowsReturnedByAddressTransactionsAPI = 25;
                    panelOwnNodeAddressTXInfo.Visible = false;
                }
                else
                {
                    rowsReturnedByAddressTransactionsAPI = 10;
                    panelOwnNodeAddressTXInfo.Visible = true;
                }

                var transactionsJson = await _transactionsForAddressService.GetTransactionsForAddressAsync(addressString, addressScreenConfUnconfOrAllTx, lastSeenTxId);
                var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
                List<string> txIds = transactions.Select(t => t.Txid).ToList();

                // Update lastSeenTxId if this isn't our first fetch of tranasctions to restart from the right place
                if (transactions.Count > 0)
                {
                    if (transactions.Last().Status.Confirmed == "true") // make sure the last shown tx wasn't a mempool tx before using its txid as a key to a subsequent call. 
                    {
                        lastSeenTxId = transactions.Last().Txid; // it was a confirmed tx so we can carry on the next api call from that point
                    }
                    else
                    {
                        lastSeenTxId = ""; // If it was a mempool record then the next call (to confirmed tx's) will need a null txid to start from the beginning
                    }
                    lastSeenTxId = transactions.Last().Txid;
                }

                //LIST VIEW
                listViewAddressTransactions.Invoke((MethodInvoker)delegate
                {
                    listViewAddressTransactions.Items.Clear(); // remove any data that may be there already
                });
                listViewAddressTransactions.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewAddressTransactions, new object[] { true });

                // Check if the column header already exists
                if (listViewAddressTransactions.Columns.Count == 0)
                {
                    // If not, add the column header
                    if (addressScreenConfUnconfOrAllTx == "chain")
                    {
                        if (PartOfAnAllAddressTransactionsRequest)
                        {
                            listViewAddressTransactions.Invoke((MethodInvoker)delegate
                            {
                                listViewAddressTransactions.Columns.Add(" Transaction ID (all transactions)", 260);
                            });
                        }
                        else
                        {
                            listViewAddressTransactions.Invoke((MethodInvoker)delegate
                            {
                                listViewAddressTransactions.Columns.Add(" Transaction ID (confirmed)", 260);
                            });
                        }
                    }
                    if (addressScreenConfUnconfOrAllTx == "mempool")
                    {
                        listViewAddressTransactions.Invoke((MethodInvoker)delegate
                        {
                            listViewAddressTransactions.Columns.Add(" Transaction ID (unconfirmed)", 260);
                        });
                    }
                    if (addressScreenConfUnconfOrAllTx == "all")
                    {
                        listViewAddressTransactions.Invoke((MethodInvoker)delegate
                        {
                            listViewAddressTransactions.Columns.Add(" Transaction ID (all transactions)", 260);
                        });
                    }
                }

                // Add the block height column header
                if (listViewAddressTransactions.Columns.Count == 1)
                {
                    listViewAddressTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewAddressTransactions.Columns.Add("Block", 65);
                    });
                }

                // Add the balance change column header
                if (listViewAddressTransactions.Columns.Count == 2)
                {
                    listViewAddressTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewAddressTransactions.Columns.Add("Amount", 110);
                    });
                }

                // Add the status column header
                if (listViewAddressTransactions.Columns.Count == 3)
                {
                    listViewAddressTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewAddressTransactions.Columns.Add("Confs", 70);
                    });
                }

                // Add the items to the ListView
                int counter = 0; // used to count rows in list as they're added
                WebClient client2 = new WebClient();
                string CurrentBlockHeightStringForCalc = client2.DownloadString(NodeURL + "blocks/tip/height");

                foreach (AddressTransactions transaction in transactions)
                {
                    decimal balanceChange = 0; // will hold net result of transaction to this address
                    decimal balanceChangeVin = 0; // will hold net result of inputs to this address
                    decimal balanceChangeVout = 0; // will hold net result of outputs to this address
                    balanceChangeVout = (decimal)transaction.Vout // value of all outputs where address is the provided address
                        .Where(v => v.Scriptpubkey_address == addressString)
                        .Sum(v => v.Value);
                    balanceChangeVin = (decimal)transaction.Vin
                        .Where(v => v.Prevout != null && v.Prevout.Scriptpubkey_address == addressString)
                        .Sum(v => v.Prevout.Value);
                    balanceChange = balanceChangeVout - balanceChangeVin; // calculate net change to balance for this transaction
                    string balanceChangeString = balanceChange.ToString();
                    balanceChange = ConvertSatsToBitcoin(balanceChangeString); // convert it to bitcoin
                    if (balanceChange >= 0)
                    {
                        balanceChangeString = "+" + balanceChange.ToString("0.00000000"); // add a + for positive numbers
                    }
                    else
                    {
                        balanceChangeString = balanceChange.ToString("0.00000000"); // - already there for negatives
                    }

                    ListViewItem item = new ListViewItem(transaction.Txid); // create new row
                    if (transaction.Status.Confirmed == "true")
                    {
                        item.SubItems.Add(transaction.Status.Block_height.ToString()); // add block height
                    }
                    else
                    {
                        item.SubItems.Add("------".ToString()); // unconfirmed, so no block height
                    }

                    item.SubItems.Add(balanceChangeString.ToString()); // add net change to balance

                    if (transaction.Status.Confirmed == "true")
                    {
                        decimal CurrentBlockForCalc = Convert.ToDecimal(CurrentBlockHeightStringForCalc);
                        decimal TransactionBlockForCalc = transaction.Status.Block_height;
                        decimal Confirmations = (CurrentBlockForCalc - TransactionBlockForCalc) + 1;
                        item.SubItems.Add(Confirmations.ToString()); // and confirmed status
                    }
                    else
                    {
                        item.SubItems.Add("---".ToString()); // unconfirmed, so no confirmations
                    }

                    listViewAddressTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewAddressTransactions.Items.Add(item); // add row
                    });

                    counter++; // increment rows for this batch
                    TotalAddressTransactionRowsAdded++; // increment all rows

                    if (TotalAddressTransactionRowsAdded <= rowsReturnedByAddressTransactionsAPI) // less than 25 transactions in all
                    {
                        btnFirstAddressTransaction.Visible = false; // so this won't be needed
                    }
                    else
                    {
                        if (addressScreenConfUnconfOrAllTx != "mempool") //regardless how many unconfirmed TXs there are, the api only returns the first batch, but otherwise we can go back to first TX
                        {
                            btnFirstAddressTransaction.Visible = true;
                        }
                    }

                    if (Convert.ToString(TotalAddressTransactionRowsAdded) == lblAddressConfirmedTransactionCount.Text) // we've shown all the TXs
                    {
                        btnNextAddressTransactions.Visible = false; // so we won't need this
                    }
                    else
                    {
                        if (addressScreenConfUnconfOrAllTx != "mempool") //regardless how many unconfirmed TXs there are, the api only returns the first batch, but otherwise we can go to the next batch
                        {
                            btnNextAddressTransactions.Visible = true;
                        }
                    }

                    if (counter == rowsReturnedByAddressTransactionsAPI) // ListView is full. stop adding rows at this point and pick up from here next time.
                    {
                        break;
                    }
                }
                if (listViewAddressTransactions.Items.Count > 0)
                {
                    listViewAddressTransactions.Items[0].Selected = true;
                }
                if (counter > 0)
                {
                    lblAddressTXPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblAddressTXPositionInList.Text = "Transactions " + (TotalAddressTransactionRowsAdded - counter + 1) + " - " + (TotalAddressTransactionRowsAdded) + " of " + lblAddressConfirmedTransactionCount.Text;
                    });
                }
                else
                {
                    lblAddressTXPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblAddressTXPositionInList.Text = "No transactions to display";
                    });
                }
                if (addressScreenConfUnconfOrAllTx == "all") // we only do one call to the 'all' api, then have to switch to the confirmed api for subsequent calls
                {
                    addressScreenConfUnconfOrAllTx = "chain";
                }
                // set focus
                if (btnNextAddressTransactions.Visible && btnNextAddressTransactions.Enabled)
                {
                    btnNextAddressTransactions.Focus();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransactionsForAddress");
            }
        }
        #endregion
        #region show prev/next tx's
        //------------------------ GET NEXT TRANSACTIONS FOR ADDRESS --------------------------------------------------
        private async void BtnGetNextTransactionsForAddress(object sender, EventArgs e)
        {
            try
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableAddressButtons("disable"); // disable buttons during operation
                var address = textboxSubmittedAddress.Text; // Get the address from the address text box
                                                            // Get the last seen transaction ID from the list view
                string lastSeenTxId;
                if (listViewAddressTransactions.Items[listViewAddressTransactions.Items.Count - 1].SubItems[1].Text == "------")
                {
                    lastSeenTxId = ""; // last seen transaction was unconfirmed, so next call will be for confirmed TXs, starting from the first
                }
                else
                {
                    lastSeenTxId = listViewAddressTransactions.Items[listViewAddressTransactions.Items.Count - 1].Text; // last seen transaction was confirmed, so next call will carry on where we left off
                }
                // Call the GetConfirmedTransactionsForAddress method with the updated lastSeenTxId
                await GetTransactionsForAddress(address, lastSeenTxId);
                DisableEnableAddressButtons("enable"); // enable the buttons that were previously enabled again
                ToggleLoadingAnimation("disable"); // stop the loading animation
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnGetNextTransactionsForAddress");
            }
        }

        //------------------------ JUMP BACK TO FIRST TRANSACTION ------------------------------------------------------
        private async void BtnFirstTransactionForAddress_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableAddressButtons("disable"); // disable buttons during operation
                if (PartOfAnAllAddressTransactionsRequest) // if this was originally a list of 'all' TXs which switched to 'chain', switch back to 'all' to get the unconfirmed again first
                {
                    addressScreenConfUnconfOrAllTx = "all";
                }
                btnFirstAddressTransaction.Visible = false;
                var address = textboxSubmittedAddress.Text; // Get the address from the address text box
                var lastSeenTxId = "0"; // Reset the last seen transaction ID to go back to start
                TotalAddressTransactionRowsAdded = 0;
                btnNextAddressTransactions.Visible = true; // this time we know there's a next page (couldn't press first otherwise)
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;

                // Call the GetConfirmedTransactionsForAddress method with the updated lastSeenTxId
                await GetTransactionsForAddress(address, lastSeenTxId);
                DisableEnableAddressButtons("enable"); // enable the buttons that were previously enabled again
                ToggleLoadingAnimation("disable"); // stop the loading animation
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnFirstTransactionForAddress_Click");
            }
        }
        #endregion
        #region confirmed/mempool/both
        //------------------------ SHOW TRANSACTIONS IN MEMPOOL ------------------------------------------------------
        private void BtnShowUnconfirmedTXForAddress_Click(object sender, EventArgs e)
        {
            try
            {
                btnShowConfirmedTX.Enabled = true;
                btnShowAllTX.Enabled = true;
                btnShowUnconfirmedTX.Enabled = false;
                addressScreenConfUnconfOrAllTx = "mempool";
                btnNextAddressTransactions.Visible = false;
                btnFirstAddressTransaction.Visible = false;
                PartOfAnAllAddressTransactionsRequest = false;
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;
                // force a text box (address) change event to fetch unconfirmed transactions
                string temp = textboxSubmittedAddress.Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = "";
                });
                listViewAddressTransactions.Invoke((MethodInvoker)delegate
                {
                    listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
                });
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = temp;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnShowUnconfirmedTXForAddress_Click");
            }
        }

        //------------------------ SHOW CONFIRMED TRANSACTIONS ------------------------------------------------------
        private void BtnShowConfirmedTXForAddress_Click(object sender, EventArgs e)
        {
            try
            {
                btnShowConfirmedTX.Enabled = false;
                btnShowAllTX.Enabled = true;
                btnShowUnconfirmedTX.Enabled = true;
                addressScreenConfUnconfOrAllTx = "chain";
                PartOfAnAllAddressTransactionsRequest = false;
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;
                // force a text box (address) change event to fetch confirmed transactions
                string temp = textboxSubmittedAddress.Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = "";
                });
                listViewAddressTransactions.Invoke((MethodInvoker)delegate
                {
                    listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
                });
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = temp;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnShowConfirmedTXForAddress_Click");
            }
        }

        //------------------------ SHOW CONFIRMED & UNCONFIRMED TRANSACTIONS -------------------------------------------
        private void BtnShowAllTXForAddress_Click(object sender, EventArgs e)
        {
            try
            {
                btnShowConfirmedTX.Enabled = true;
                btnShowAllTX.Enabled = false;
                btnShowUnconfirmedTX.Enabled = true;
                addressScreenConfUnconfOrAllTx = "all";
                PartOfAnAllAddressTransactionsRequest = true;
                BtnViewBlockFromAddress.Visible = false;
                BtnViewTransactionFromAddress.Visible = false;
                // force a text box (address) change event to fetch all (confirmed and unconfirmed) transactions
                string temp = textboxSubmittedAddress.Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = "";
                });
                listViewAddressTransactions.Invoke((MethodInvoker)delegate
                {
                    listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
                });
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = temp;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnShowAllTXForAddress_Click");
            }
        }
        #endregion
        #region navigate from tx row to other screen
        //------------------------ VIEW THE BLOCK CONTAINING THIS TRANSACTION ------------------------------------------
        private void BtnViewBlockFromAddress_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
                // Get the second subitem in the selected item 
                string submittedBlockNumber = selectedItem.SubItems[1].Text;
                // copy block number to the block screen
                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = submittedBlockNumber;
                });
                try
                {
                    LookupBlock();
                }
                catch (Exception ex)
                {
                    HandleException(ex, "BtnViewBlockFromAddress_Click");
                }
                //show the block screen
                BtnMenuBlock_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewBlockFromAddress_Click");
            }
        }

        //------------------------ VIEW THIS TRANSACTION ------------------------------------------------------
        private void BtnViewTransactionFromAddress_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
                // Get the first subitem in the selected item 
                string TransactionIDFromRow = selectedItem.SubItems[0].Text;
                // copy transaction ID to transaction screen
                textBoxTransactionID.Invoke((MethodInvoker)delegate
                {
                    textBoxTransactionID.Text = TransactionIDFromRow;
                });
                //show the transaction screen
                BtnMenuTransaction_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewTransactionFromAddress_Click");
            }
        }
        #endregion
        #region listview appearance
        //------------------------ CHANGE COLOUR OF SELECTED ROW ------------------------------------------------------
        private void ListViewAddressTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewAddressTransactions.Items)
                {
                    if (item.Selected)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        BtnViewTransactionFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width - BtnViewTransactionFromAddress.Width - 8, item.Position.Y + listViewAddressTransactions.Location.Y);
                        BtnViewTransactionFromAddress.Height = item.Bounds.Height;
                        BtnViewBlockFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Columns[1].Width - BtnViewBlockFromAddress.Width - 3, item.Position.Y + listViewAddressTransactions.Location.Y);
                        BtnViewBlockFromAddress.Height = item.Bounds.Height;
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
                BtnViewTransactionFromAddress.Visible = listViewAddressTransactions.SelectedItems.Count > 0;
                BtnViewBlockFromAddress.Visible = listViewAddressTransactions.SelectedItems.Count > 0;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewAddressTransactions_ItemSelectionChanged");
            }
        }

        //-----DRAW AN ELLIPSIS WHEN STRINGS DONT FIT IN LISTVIEW COLUMN (ALSO COLOUR BALANCE DIFFERENCE RED/GREEN)----
        private void ListViewAddressTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;

                if (text[0] == '+') // if the string is a change to an amount and positive
                {
                    e.SubItem.ForeColor = Color.OliveDrab; // make it green
                }
                else
                if (text[0] == '-') // if the string is a change to an amount and negative
                {
                    e.SubItem.ForeColor = Color.IndianRed; // make it red
                }

                var font = listViewAddressTransactions.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewAddressTransactions.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewAddressTransactions.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewAddressTransactions_DrawSubItem");
            }
        }

        //------------------ LIMIT MINIMUM WIDTH OF ADDRESS LISTVIEW COLUMNS ------------------------------------------
        private void ListViewAddressTransactions_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewAddressTransactions.Columns[e.ColumnIndex].Width < 260) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 260;
                    }
                    if (listViewAddressTransactions.Columns[e.ColumnIndex].Width > 460) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 460;
                    }

                    BtnViewTransactionFromAddress.Invoke((MethodInvoker)delegate
                    {
                        BtnViewTransactionFromAddress.Location = new Point(listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Location.X - BtnViewTransactionFromAddress.Width - 6, BtnViewTransactionFromAddress.Location.Y);
                    });
                    BtnViewBlockFromAddress.Invoke((MethodInvoker)delegate
                    {
                        BtnViewBlockFromAddress.Location = new Point(listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Columns[1].Width + listViewAddressTransactions.Location.X - BtnViewBlockFromAddress.Width + 2, BtnViewBlockFromAddress.Location.Y);
                    });
                }

                if (e.ColumnIndex == 1)
                {
                    if (listViewAddressTransactions.Columns[e.ColumnIndex].Width != 65) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 65;
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    if (listViewAddressTransactions.Columns[e.ColumnIndex].Width != 110) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 110;
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (listViewAddressTransactions.Columns[e.ColumnIndex].Width != 70) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 70;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewAddressTransactions_ColumnWidthChanging");
            }
        }
        #endregion
        #region configure controls
        //------------------------ SHOW ALL THE ADDRESS CONTROLS ------------------------------------------------------
        private void AddressValidShowControls() // show all address related controls
        {
            try
            {
                if (addressScreenConfUnconfOrAllTx == "mempool")//only one page of unconfirmed tx regardless how many tx there are
                {
                    btnNextAddressTransactions.Visible = false;
                    btnFirstAddressTransaction.Visible = false;
                }
                lblAddressTXPositionInList.Visible = true;
                label59.Visible = true;
                label61.Visible = true;
                label67.Visible = true;
                label63.Visible = true;
                listViewAddressTransactions.Visible = true;
                lblAddressConfirmedUnspent.Visible = true;
                lblAddressConfirmedUnspentOutputs.Visible = true;
                lblAddressConfirmedTransactionCount.Visible = true;
                lblAddressConfirmedReceived.Visible = true;
                lblAddressConfirmedReceivedOutputs.Visible = true;
                lblAddressConfirmedSpent.Visible = true;
                lblAddressConfirmedSpentOutputs.Visible = true;
                btnShowAllTX.Visible = true;
                btnShowConfirmedTX.Visible = true;
                btnShowUnconfirmedTX.Visible = true;
                lblAddressType.Visible = true;
                panel41.Visible = true;
                panel42.Visible = true;
                panel43.Visible = true;
                panel44.Visible = true;
            }
            catch (Exception ex)
            {
                HandleException(ex, "AddressValidShowControls");
            }
        }

        //------------------------ HIDE ALL THE ADDRESS CONTROLS ------------------------------------------------------
        private void AddressInvalidHideControls() // hide all address related controls
        {
            try
            {
                if (lblAddressType.Visible)
                {
                    btnNextAddressTransactions.Visible = false;
                    btnFirstAddressTransaction.Visible = false;
                    lblAddressTXPositionInList.Visible = false;
                    label59.Visible = false;
                    label61.Visible = false;
                    label67.Visible = false;
                    label63.Visible = false;
                    listViewAddressTransactions.Visible = false;
                    lblAddressConfirmedUnspent.Visible = false;
                    lblAddressConfirmedUnspentOutputs.Visible = false;
                    lblAddressConfirmedTransactionCount.Visible = false;
                    lblAddressConfirmedReceived.Visible = false;
                    lblAddressConfirmedReceivedOutputs.Visible = false;
                    lblAddressConfirmedSpent.Visible = false;
                    lblAddressConfirmedSpentOutputs.Visible = false;
                    btnShowAllTX.Visible = false;
                    btnShowConfirmedTX.Visible = false;
                    btnShowUnconfirmedTX.Visible = false;
                    lblAddressType.Visible = false;
                    panel41.Visible = false;
                    panel42.Visible = false;
                    panel43.Visible = false;
                    panel44.Visible = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "AddressInvalidHideControls");
            }
        }

        private void DisableEnableAddressButtons(string enableOrDisableAddressButtons)
        {
            try
            {
                if (enableOrDisableAddressButtons == "disable")
                {
                    // get current state of buttons before disabling them
                    btnShowAllAddressTXWasEnabled = btnShowAllTX.Enabled;
                    btnShowConfirmedAddressTXWasEnabled = btnShowConfirmedTX.Enabled;
                    btnShowUnconfirmedAddressTXWasEnabled = btnShowUnconfirmedTX.Enabled;
                    btnFirstAddressTransactionWasEnabled = btnFirstAddressTransaction.Enabled;
                    btnNextAddressTransactionsWasEnabled = btnNextAddressTransactions.Enabled;
                    BtnViewTransactionFromAddressWasEnabled = BtnViewTransactionFromAddress.Enabled;
                    BtnViewBlockFromAddressWasEnabled = BtnViewBlockFromAddress.Enabled;
                    textBoxSubmittedAddressWasEnabled = textboxSubmittedAddress.Enabled;

                    //disable them all
                    btnShowAllTX.Enabled = false;
                    btnShowConfirmedTX.Enabled = false;
                    btnShowUnconfirmedTX.Enabled = false;
                    btnFirstAddressTransaction.Enabled = false;
                    btnNextAddressTransactions.Enabled = false;
                    BtnViewTransactionFromAddress.Enabled = false;
                    BtnViewBlockFromAddress.Enabled = false;
                    textboxSubmittedAddress.Enabled = false;
                    btnMenu.Enabled = false;
                }
                else
                {
                    // use previously saved states to reinstate buttons
                    btnShowAllTX.Enabled = btnShowAllAddressTXWasEnabled;
                    btnShowConfirmedTX.Enabled = btnShowConfirmedAddressTXWasEnabled;
                    btnShowUnconfirmedTX.Enabled = btnShowUnconfirmedAddressTXWasEnabled;
                    btnFirstAddressTransaction.Enabled = btnFirstAddressTransactionWasEnabled;
                    btnNextAddressTransactions.Enabled = btnNextAddressTransactionsWasEnabled;
                    BtnViewTransactionFromAddress.Enabled = BtnViewTransactionFromAddressWasEnabled;
                    BtnViewBlockFromAddress.Enabled = BtnViewBlockFromAddressWasEnabled;
                    textboxSubmittedAddress.Enabled = textBoxSubmittedAddressWasEnabled;
                    textboxSubmittedAddress.Focus();
                    // Set the cursor position to the end of the string
                    textboxSubmittedAddress.Select(textboxSubmittedAddress.Text.Length, 0);
                    btnMenu.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableEnableAddressButtons");
            }
        }
        #endregion
        #endregion

        #region ⚡BLOCK SCREEN⚡
        #region user input
        private void TextBoxSubmittedBlockNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Get the maximum allowed value for the block number
                int maxValue = int.Parse(lblBlockNumber.Text);

                // Allow only digits, backspace, delete, and enter
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '\r')
                {
                    e.Handled = true;
                    return;
                }

                // Handle backspace
                if (e.KeyChar == '\b')
                {
                    // If there is a selection, delete it
                    if (textBoxSubmittedBlockNumber.SelectionLength > 0)
                    {
                        int start = textBoxSubmittedBlockNumber.SelectionStart;
                        int length = textBoxSubmittedBlockNumber.SelectionLength;
                        textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                        {
                            textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(start, length);
                            textBoxSubmittedBlockNumber.SelectionStart = start;
                        });
                    }
                    // If the cursor is not at the beginning, delete the character to the left of the cursor
                    else if (textBoxSubmittedBlockNumber.SelectionStart > 0)
                    {
                        int pos = textBoxSubmittedBlockNumber.SelectionStart - 1;
                        textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                        {
                            textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(pos, 1);
                            textBoxSubmittedBlockNumber.SelectionStart = pos;
                        });
                    }

                    e.Handled = true;
                    return;
                }

                // Handle delete
                if (e.KeyChar == '\u007F')
                {
                    // If there is a selection, delete it
                    if (textBoxSubmittedBlockNumber.SelectionLength > 0)
                    {
                        int start = textBoxSubmittedBlockNumber.SelectionStart;
                        int length = textBoxSubmittedBlockNumber.SelectionLength;
                        textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                        {
                            textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(start, length);
                            textBoxSubmittedBlockNumber.SelectionStart = start;
                        });
                    }
                    // If the cursor is not at the end, delete the character to the right of the cursor
                    else if (textBoxSubmittedBlockNumber.SelectionStart < textBoxSubmittedBlockNumber.Text.Length)
                    {
                        int pos = textBoxSubmittedBlockNumber.SelectionStart;
                        textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                        {
                            textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(pos, 1);
                            textBoxSubmittedBlockNumber.SelectionStart = pos;
                        });
                    }

                    e.Handled = true;
                    return;
                }

                // Handle enter
                if (e.KeyChar == '\r')
                {
                    // Submit button was pressed
                    LookupBlock();
                    e.Handled = true;
                    return;
                }

                // Construct the new value of the textbox by appending the pressed character
                string valueString = textBoxSubmittedBlockNumber.Text + e.KeyChar.ToString();

                // Handle the case where the textbox is empty by setting it to 0
                if (string.IsNullOrEmpty(textBoxSubmittedBlockNumber.Text.Trim()))
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = "0";
                        textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                // Handle non-numeric input
                if (!int.TryParse(valueString, out int value))
                {
                    e.Handled = true;
                    return;
                }

                // Handle negative input by setting the textbox to 0
                if (value < 0)
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = "0";
                        textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                // Handle input that exceeds the maximum allowed value by setting the textbox to the maximum value
                if (value > maxValue)
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = maxValue.ToString();
                        textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = value.ToString();
                    textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSubmittedBlockNumber_KeyPress");
            }
        }

        private void TextBoxSubmittedBlockNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxSubmittedBlockNumber.Text.Trim()))
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = "0";
                    });
                    btnPreviousBlock.Enabled = false;
                    btnNextBlock.Enabled = true;
                }
                if (textBoxSubmittedBlockNumber.Text == lblBlockNumber.Text)
                {
                    btnNextBlock.Enabled = false;
                    btnPreviousBlock.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSubmittedBlockNumber_TextChanged");
            }
        }
        #endregion
        #region get the data
        //------------------------ LOOK UP THE BLOCK ------------------------------------------------------------------
        private async void LookupBlock()
        {
            try
            {
                if (textBoxSubmittedBlockNumber.Text == "0")
                {
                    btnPreviousBlock.Enabled = false;
                }
                else
                {
                    btnPreviousBlock.Enabled = true;
                }
                if (textBoxSubmittedBlockNumber.Text == lblBlockNumber.Text)
                {
                    btnNextBlock.Enabled = false;
                }
                else
                {
                    btnNextBlock.Enabled = true;
                }
                TotalBlockTransactionRowsAdded = 0; // _TextChanged has occurred so even if the submitted block hasn't changed, start again
                btnViewTransactionFromBlock.Visible = false;
                int.TryParse(textBoxSubmittedBlockNumber.Text, out var submittedBlockHeight);
                // display block hash
                using (WebClient client = new WebClient())
                {
                    string BlockHashURL = NodeURL + "block-height/" + submittedBlockHeight;
                    string BlockHash = client.DownloadString(BlockHashURL); // get hash of provided block
                    lblBlockHash.Invoke((MethodInvoker)delegate
                    {
                        lblBlockHash.Text = BlockHash;
                    });
                }
                lblBlockBlockHeight.Text = "Block " + textBoxSubmittedBlockNumber.Text;
                var blockNumber = Convert.ToString(textBoxSubmittedBlockNumber.Text);
                //                ToggleLoadingAnimation("enable"); // start the loading animation
                //                DisableEnableBlockButtons("disable"); // disable buttons during operation
                await GetFifteenBlocks(blockNumber);
                string BlockHashToGetTransactionsFor = lblBlockHash.Text;
                await GetTransactionsForBlock(BlockHashToGetTransactionsFor, "0");
                //                ToggleLoadingAnimation("disable"); // stop the loading animation
                //                DisableEnableBlockButtons("enable"); // enable buttons after operation is complete
            }
            catch (Exception ex)
            {
                HandleException(ex, "LookupBlock");
            }
        }

        //------------------------ GET FIFTEEN BLOCKS STARTNG FROM THE ONE WE'RE INTERESTED IN ------------------------
        private async Task GetFifteenBlocks(string blockNumber) // overkill at this point, because we're only interested in one block, but this gets us the data
        {
            try
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableBlockButtons("disable"); // disable buttons during operation
                var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableBlockButtons("enable"); // enable buttons after operation is complete
                lblNumberOfTXInBlock.Invoke((MethodInvoker)delegate
                {
                    lblNumberOfTXInBlock.Text = Convert.ToString(blocks[0].Tx_count);
                });
                long sizeInBytes = blocks[0].Size;
                string sizeString; // convert display to bytes/kb/mb accordingly
                if (sizeInBytes < 1000)
                {
                    sizeString = $"{sizeInBytes} bytes";
                }
                else if (sizeInBytes < 1000 * 1000)
                {
                    double sizeInKB = (double)sizeInBytes / 1000;
                    sizeString = $"{sizeInKB:N2} KB";
                }
                else
                {
                    double sizeInMB = (double)sizeInBytes / (1000 * 1000);
                    sizeString = $"{sizeInMB:N2} MB";
                }
                lblSizeOfBlock.Invoke((MethodInvoker)delegate
                {
                    lblSizeOfBlock.Text = sizeString;
                });
                pictureBoxBlockScreenChartBlockSize.Invoke((MethodInvoker)delegate
                {
                    pictureBoxBlockScreenChartBlockSize.Location = new Point(lblSizeOfBlock.Location.X + lblSizeOfBlock.Width + 5, pictureBoxBlockScreenChartBlockSize.Location.Y);
                });
                string strWeight = Convert.ToString(blocks[0].Weight);
                decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
                string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
                lblBlockWeight.Invoke((MethodInvoker)delegate
                {
                    lblBlockWeight.Text = strFormattedWeight;
                });
                string TotalBlockFees = Convert.ToString(blocks[0].Extras.TotalFees);
                TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
                lblTotalFees.Invoke((MethodInvoker)delegate
                {
                    lblTotalFees.Text = TotalBlockFees;
                });
                pictureBoxBlockFeeChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxBlockFeeChart.Location = new Point(lblTotalFees.Location.X + lblTotalFees.Width + 5, pictureBoxBlockFeeChart.Location.Y);
                });
                long nonceLong = Convert.ToInt64(blocks[0].Nonce);
                lblNonce.Invoke((MethodInvoker)delegate
                {
                    lblNonce.Text = "0x" + nonceLong.ToString("X");
                });
                string Reward = Convert.ToString(blocks[0].Extras.Reward);
                lblReward.Invoke((MethodInvoker)delegate
                {
                    lblReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
                });
                pictureBoxBlockScreenChartReward.Invoke((MethodInvoker)delegate
                {
                    pictureBoxBlockScreenChartReward.Location = new Point(lblReward.Location.X + lblReward.Width + 5, pictureBoxBlockScreenChartReward.Location.Y);
                });
                lblBlockFeeRangeAndMedianFee.Invoke((MethodInvoker)delegate
                {
                    lblBlockFeeRangeAndMedianFee.Text = Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[0])) + "-" + Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[6])) + " / " + Convert.ToString(Convert.ToInt32(blocks[0].Extras.MedianFee));
                });
                pictureBoxBlockScreenChartFeeRange.Invoke((MethodInvoker)delegate
                {
                    pictureBoxBlockScreenChartFeeRange.Location = new Point(lblBlockFeeRangeAndMedianFee.Location.X + lblBlockFeeRangeAndMedianFee.Width + 5, pictureBoxBlockScreenChartFeeRange.Location.Y);
                });
                lblBlockAverageFee.Invoke((MethodInvoker)delegate
                {
                    lblBlockAverageFee.Text = Convert.ToString(blocks[0].Extras.AvgFee);
                });
                lblMiner.Invoke((MethodInvoker)delegate
                {
                    lblMiner.Text = Convert.ToString(blocks[0].Extras.Pool.Name);
                });
                pictureBoxBlockScreenPoolRankingChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxBlockScreenPoolRankingChart.Location = new Point(lblMiner.Location.X + lblMiner.Width + 5, pictureBoxBlockScreenPoolRankingChart.Location.Y);
                });
                lblBlockTime.Invoke((MethodInvoker)delegate
                {
                    lblBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].Timestamp)).ToString("yyyy-MM-dd HH:mm");
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetFifteenBlocks");
            }
        }

        //------------------------ GET TRANSACTIONS FOR BLOCK ---------------------------------------------------------
        private async Task GetTransactionsForBlock(string blockHash, string lastSeenBlockTransaction)
        {
            try
            {
                if (NodeURL == "https://mempool.space/api/" || NodeURL == "https://mempool.space/testnet/api/")
                {
                    rowsReturnedByBlockTransactionsAPI = 25;
                    panelOwnNodeBlockTXInfo.Visible = false;
                }
                else
                {
                    rowsReturnedByBlockTransactionsAPI = 10;
                    panelOwnNodeBlockTXInfo.Visible = true;
                }
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableBlockButtons("disable"); // disable buttons during operation
                var BlockTransactionsJson = await _transactionsForBlockService.GetTransactionsForBlockAsync(blockHash, lastSeenBlockTransaction);
                var transactions = JsonConvert.DeserializeObject<List<Block_Transactions>>(BlockTransactionsJson);
                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableBlockButtons("enable"); // enable buttons after operation is complete
                List<string> txIds = transactions.Select(t => t.Txid).ToList();

                // Update lastSeenTxId if this isn't our first fetch of tranasctions to restart from the right place
                if (txIds.Count > 0)
                {
                    lastSeenBlockTransaction = txIds.Last();
                }

                //LIST VIEW
                listViewBlockTransactions.Invoke((MethodInvoker)delegate
                {
                    listViewBlockTransactions.Items.Clear(); // remove any data that may be there already
                });
                listViewBlockTransactions.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewBlockTransactions, new object[] { true });

                // Check if the column header already exists
                if (listViewBlockTransactions.Columns.Count == 0)
                {
                    // If not, add the column header
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Columns.Add(" Transaction ID", 250);
                    });
                }

                if (listViewBlockTransactions.Columns.Count == 1)
                {
                    // If not, add the column header
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Columns.Add("Fee", 70);
                    });
                }

                if (listViewBlockTransactions.Columns.Count == 2)
                {
                    // If not, add the column header
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Columns.Add("I/P", 40);
                    });
                }
                if (listViewBlockTransactions.Columns.Count == 3)
                {
                    // If not, add the column header
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Columns.Add("O/P", 40);
                    });
                }
                if (listViewBlockTransactions.Columns.Count == 4)
                {
                    // If not, add the column header
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Columns.Add("Amount", 100);
                    });
                }
                // Add the items to the ListView
                int counter = 0; // used to count rows in list as they're added

                foreach (var blockTransaction in transactions)
                {
                    ListViewItem item = new ListViewItem(blockTransaction.Txid); // create new row
                    item.SubItems.Add(blockTransaction.Fee.ToString());
                    item.SubItems.Add(blockTransaction.Vin.Count.ToString()); // number of inputs
                    item.SubItems.Add(blockTransaction.Vout.Count.ToString()); // number of outputs
                    decimal totalValue = blockTransaction.Vout.Sum(v => decimal.Parse(v.Value)); // sum of outputs
                    totalValue = ConvertSatsToBitcoin(totalValue.ToString());
                    item.SubItems.Add(totalValue.ToString());
                    listViewBlockTransactions.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockTransactions.Items.Add(item); // add row
                    });

                    counter++; // increment rows for this batch
                    TotalBlockTransactionRowsAdded++; // increment all rows

                    if (TotalBlockTransactionRowsAdded <= rowsReturnedByBlockTransactionsAPI) // we must still be on first results so there are no previous
                    {
                        btnPreviousBlockTransactions.Enabled = false;
                    }
                    else
                    {
                        btnPreviousBlockTransactions.Enabled = true;
                    }

                    if (Convert.ToString(TotalBlockTransactionRowsAdded) == lblNumberOfTXInBlock.Text) // we've shown all the TXs
                    {
                        btnNextBlockTransactions.Enabled = false; // so we won't need this
                    }
                    else
                    {
                        btnNextBlockTransactions.Enabled = true;
                    }

                    if (counter == rowsReturnedByBlockTransactionsAPI) // ListView is full. stop adding rows at this point and pick up from here...
                    {
                        break;
                    }
                }
                listViewBlockTransactions.Items[0].Selected = true;
                if (counter > 0)
                {
                    lblBlockTXPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblBlockTXPositionInList.Text = "Transactions " + (TotalBlockTransactionRowsAdded - counter + 1) + " - " + (TotalBlockTransactionRowsAdded) + " of " + lblNumberOfTXInBlock.Text;
                    });
                }
                else
                {
                    lblBlockTXPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblBlockTXPositionInList.Text = "No transactions to display"; // this can't really happen as there will always be a coinbase transaction
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransactionsForBlocks");
            }
        }
        #endregion
        #region prev/next transactions
        //------------------------ GET NEXT BATCH OF TRANSACTIONS FOR BLOCK -------------------------------------------
        private async void BtnNextBlockTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                //ToggleLoadingAnimation("enable"); // start the loading animation
                //DisableEnableBlockButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction); // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                //DisableEnableBlockButtons("enable"); // enable the buttons that were previously enabled again
                //ToggleLoadingAnimation("disable"); // stop the loading animation
                btnViewTransactionFromBlock.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnNextBlockTransactions_Click");
            }
        }

        //------------------------ GET PREVIOUS BATCH OF TRANSACTIONS FOR BLOCK -----------------------------------------
        private async void BtnPreviousBlockTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                //                ToggleLoadingAnimation("enable"); // start the loading animation
                //                DisableEnableBlockButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
                if (TotalBlockTransactionRowsAdded % rowsReturnedByBlockTransactionsAPI == 0) // API expects last seen transaction to be a multiple of 25. If it is we can just subtract 50 for the prev page
                {
                    TotalBlockTransactionRowsAdded -= (rowsReturnedByBlockTransactionsAPI * 2);
                }
                else // otherwise we subtract the odd amount (only happens at end of list) and another 25 to be able to go back to the previous page.
                {
                    int closestMultipleOf25 = TotalBlockTransactionRowsAdded - (TotalBlockTransactionRowsAdded % rowsReturnedByBlockTransactionsAPI);
                    int firstNumberBeforeIt = closestMultipleOf25 - rowsReturnedByBlockTransactionsAPI;
                    TotalBlockTransactionRowsAdded = firstNumberBeforeIt;
                }
                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction); // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                                                                                    //                DisableEnableBlockButtons("enable"); // enable the buttons that were previously enabled again
                                                                                    //                ToggleLoadingAnimation("disable"); // stop the loading animation
                btnViewTransactionFromBlock.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnPreviousBlockTransactions_Click");
            }
        }
        #endregion
        #region prev/next block
        //------------------------ VIEW PREVIOUS BLOCK ------------------------------------------------------------------
        private void BtnPreviousBlock_Click(object sender, EventArgs e) // decrease block number by 1 and populate block data
        {
            try
            {
                long CurrentSubmittedBlockNumber = Convert.ToInt32(textBoxSubmittedBlockNumber.Text);
                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = Convert.ToString(CurrentSubmittedBlockNumber - 1);
                });
                LookupBlock();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnPreviousBlock_Click");
            }
        }

        //------------------------ VIEW NEXT BLOCK --------------------------------------------------------------------
        private void BtnNextBlock_Click(object sender, EventArgs e) // increase block number by 1 and populate block data
        {
            try
            {
                long CurrentSubmittedBlockNumber = Convert.ToInt32(textBoxSubmittedBlockNumber.Text);
                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = Convert.ToString(CurrentSubmittedBlockNumber + 1);
                });
                LookupBlock();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnNextBlock_Click");
            }
        }
        #endregion
        #region listview appearance
        //------------------------ USER SELECTED A TRANSACTION ROW -----------------------------------------------------
        private void ListViewBlockTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewBlockTransactions.Items)
                {
                    if (item.Selected)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        btnViewTransactionFromBlock.Invoke((MethodInvoker)delegate
                        {
                            btnViewTransactionFromBlock.Location = new Point(item.Position.X + listViewBlockTransactions.Location.X + listViewBlockTransactions.Columns[0].Width - btnViewTransactionFromBlock.Width - 8, item.Position.Y + listViewBlockTransactions.Location.Y);
                            btnViewTransactionFromBlock.Height = item.Bounds.Height;
                        });
                        anySelected = true;
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
                btnViewTransactionFromBlock.Visible = anySelected;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockTransactions_ItemSelectionChanged");
            }
        }

        //------------------------ USER TRYING TO RESIZE COLUMNS ------------------------------------------------------
        private void ListViewBlockTransactions_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width < 250) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 250;
                    }
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width > 460) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 460;
                    }
                    btnViewTransactionFromBlock.Invoke((MethodInvoker)delegate
                    {
                        btnViewTransactionFromBlock.Location = new Point(listViewBlockTransactions.Columns[0].Width + listViewBlockTransactions.Location.X - btnViewTransactionFromBlock.Width - 6, btnViewTransactionFromBlock.Location.Y);
                    });
                }

                if (e.ColumnIndex == 1)
                {
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 70) // fixed width
                    {
                        e.Cancel = true;
                        e.NewWidth = 70;
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 40) // fixed width
                    {
                        e.Cancel = true;
                        e.NewWidth = 40;
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 40) // fixed width
                    {
                        e.Cancel = true;
                        e.NewWidth = 40;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 100) // fixed width
                    {
                        e.Cancel = true;
                        e.NewWidth = 100;

                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockTransactions_ColumnWidthChanging");
            }
        }

        //------------------------ FORMAT DATA WHILE DRAWING LISTVIEW ------------------------------------------------------
        private void ListViewBlockTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;

                if (text[0] == '+') // if the string is a change to an amount and positive
                {
                    e.SubItem.ForeColor = Color.OliveDrab; // make it green

                }
                else
                if (text[0] == '-') // if the string is a change to an amount and negative
                {
                    e.SubItem.ForeColor = Color.IndianRed; // make it red
                }

                var font = listViewBlockTransactions.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBlockTransactions.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBlockTransactions.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockTransactions_DrawSubItem");
            }
        }
        #endregion
        #region navigate from listview to tx screen
        private void BtnViewTransactionFromBlock_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewBlockTransactions.SelectedItems[0];
                // Get the first subitem in the selected item 
                string TransactionIDFromRow = selectedItem.SubItems[0].Text;
                // copy transaction ID to transaction screen
                textBoxTransactionID.Invoke((MethodInvoker)delegate
                {
                    textBoxTransactionID.Text = TransactionIDFromRow;
                });
                //show the transaction screen
                BtnMenuTransaction_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewTransactionFromBlock_Click");
            }
        }
        #endregion
        #region enable/disable buttons
        private void DisableEnableBlockButtons(string enableOrDisableBlockButtons)
        {
            try
            {
                if (enableOrDisableBlockButtons == "disable")
                {
                    // get current state of buttons before disabling them
                    btnPreviousBlockTransactionsWasEnabled = btnPreviousBlockTransactions.Enabled;
                    btnNextBlockTransactionsWasEnabled = btnNextBlockTransactions.Enabled;
                    textBoxSubmittedBlockNumberWasEnabled = textBoxSubmittedBlockNumber.Enabled;
                    btnNextBlockWasEnabled = btnNextBlock.Enabled;
                    btnPreviousBlockWasEnabled = btnPreviousBlock.Enabled;

                    //disable them all
                    btnPreviousBlockTransactions.Enabled = false;
                    btnNextBlockTransactions.Enabled = false;
                    textBoxSubmittedBlockNumber.Enabled = false;
                    btnNextBlock.Enabled = false;
                    btnPreviousBlock.Enabled = false;
                    btnMenu.Enabled = false;
                }
                else
                {
                    // use previously saved states to reinstate buttons
                    btnPreviousBlockTransactions.Enabled = btnPreviousBlockTransactionsWasEnabled;
                    btnNextBlockTransactions.Enabled = btnNextBlockTransactionsWasEnabled;
                    btnNextBlock.Enabled = btnNextBlockWasEnabled;
                    btnPreviousBlock.Enabled = btnPreviousBlockWasEnabled;
                    textBoxSubmittedBlockNumber.Enabled = textBoxSubmittedBlockNumberWasEnabled;
                    textBoxSubmittedBlockNumber.Focus();
                    // Set the cursor position to the end of the string
                    textBoxSubmittedBlockNumber.Select(textBoxSubmittedBlockNumber.Text.Length, 0);
                    btnMenu.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableEnableBlockButtons");
            }
        }
        #endregion
        #region chart icon clicks
        private void PictureBoxBlockScreenChartBlockSize_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartBlockSize_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockScreenChartBlockSize_Click");
            }
        }

        private void PictureBoxBlockScreenChartReward_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartReward_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockScreenChartReward_Click");
            }
        }

        private void PictureBoxBlockScreenChartFeeRange_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartFeeRates_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockScreenChartFeeRange_Click");
            }
        }

        private void PictureBoxBlockFeeChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartBlockFees_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockFeeChart_Click");
            }
        }

        private void PictureBoxBlockScreenPoolRankingChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartPoolsRanking_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockScreenPoolRankingChart_Click");
            }
        }
        #endregion
        #endregion

        #region ⚡TRANSACTION SCREEN⚡
        #region user input
        private void TextBoxTransactionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Handle enter
                if (e.KeyChar == '\r')
                {
                    // Submit button was pressed
                    LookupTransaction();
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxTransactionID_KeyPress");
            }
        }

        //-------------------- TRANSACTION ID FIELD HAS CHANGED ------------------------------------------------
        private async void TextBoxTransactionID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string transactionIdToValidate = textBoxTransactionID.Text;

                if (ValidateTransactionId(transactionIdToValidate)) // check if the entered string is valid
                {
                    bool exists = await TransactionExists(transactionIdToValidate); // then check if it actually exists
                    if (exists)
                    {
                        lblInvalidTransaction.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidTransaction.ForeColor = Color.OliveDrab;
                            lblInvalidTransaction.Text = "✔️ valid transaction ID";
                        });
                        panelTransactionHeadline.Visible = true;
                        panelTransactionDiagram.Visible = true;
                        panel27.Visible = true;
                        panel28.Visible = true;
                        btnTransactionInputsUp.Visible = true;
                        btnTransactionInputDown.Visible = true;
                        btnTransactionOutputsUp.Visible = true;
                        btnTransactionOutputsDown.Visible = true;
                        listViewTransactionInputs.Visible = true;
                        listViewTransactionOutputs.Visible = true;
                        btnViewAddressFromTXInput.Visible = true;
                        btnViewAddressFromTXOutput.Visible = true;
                        LookupTransaction();
                    }
                    else
                    {
                        panelTransactionHeadline.Visible = false;
                        panelTransactionDiagram.Visible = false;
                        panel27.Visible = false;
                        panel28.Visible = false;
                        btnTransactionInputsUp.Visible = false;
                        btnTransactionInputDown.Visible = false;
                        btnTransactionOutputsUp.Visible = false;
                        btnTransactionOutputsDown.Visible = false;
                        listViewTransactionInputs.Visible = false;
                        listViewTransactionOutputs.Visible = false;
                        btnViewAddressFromTXInput.Visible = false;
                        btnViewAddressFromTXOutput.Visible = false;
                        lblInvalidTransaction.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidTransaction.ForeColor = Color.IndianRed;
                            lblInvalidTransaction.Text = "✖️ invalid transaction ID";
                        });
                    }
                }
                else
                {
                    panelTransactionHeadline.Visible = false;
                    panelTransactionDiagram.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    btnTransactionInputsUp.Visible = false;
                    btnTransactionInputDown.Visible = false;
                    btnTransactionOutputsUp.Visible = false;
                    btnTransactionOutputsDown.Visible = false;
                    listViewTransactionInputs.Visible = false;
                    listViewTransactionOutputs.Visible = false;
                    btnViewAddressFromTXInput.Visible = false;
                    btnViewAddressFromTXOutput.Visible = false;
                    if (transactionIdToValidate == "")
                    {
                        lblInvalidTransaction.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidTransaction.Text = "";
                        });
                    }
                    else
                    {
                        lblInvalidTransaction.Invoke((MethodInvoker)delegate
                        {
                            lblInvalidTransaction.ForeColor = Color.IndianRed;
                            lblInvalidTransaction.Text = "✖️ invalid transaction ID";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxTransactionID_TextChanged");
            }
        }
        #endregion
        #region validation
        //-------------------- CHECK ITS A VALID TRANSACTION ID FORMAT -----------------------------------------
        private bool ValidateTransactionId(string transactionId) // checks if transaction ID is in a valid format
        {
            try
            {
                uint256 txId = uint256.Parse(transactionId);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //-------------------- CHECK IF THE TRANSACTION ID EXISTS ----------------------------------------------
        private async Task<bool> TransactionExists(string transactionId) // checks if the valid transaction ID actually exists
        {
            ToggleLoadingAnimation("enable"); // start the loading animation
            DisableEnableTransactionButtons("disable"); // disable buttons during operation
            string url = NodeURL + "tx/" + transactionId;
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            ToggleLoadingAnimation("disable"); // start the loading animation
            DisableEnableTransactionButtons("enable"); // disable buttons during operation
            return response.IsSuccessStatusCode;
        }
        #endregion
        #region set up transaction screen
        //-------------------- LOOKUP THE TRANSACTION ----------------------------------------------------------
        private async void LookupTransaction()
        {
            try
            {
                string submittedTransactionID = textBoxTransactionID.Text;
                await GetTransaction(submittedTransactionID);
            }
            catch (Exception ex)
            {
                HandleException(ex, "LookupTransaction");
            }
        }

        //-------------------- GET TRANSACTION DATA AND DISPLAY IT AND DIAGRAM ---------------------------------
        private async Task GetTransaction(string submittedTransactionID)
        {
            try
            {
                linePoints.Clear();
                btnViewAddressFromTXInput.Visible = false;
                btnViewAddressFromTXOutput.Visible = false;
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableTransactionButtons("disable"); // disable buttons during operation
                var TransactionJson = await _transactionService.GetTransactionAsync(submittedTransactionID);
                var transaction = JsonConvert.DeserializeObject<Transaction>(TransactionJson);
                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableTransactionButtons("enable"); // enable buttons after operation is complete

                lblTransactionBlockHeight.Invoke((MethodInvoker)delegate
                {
                    lblTransactionBlockHeight.Text = Convert.ToString(transaction.Status.Block_height);
                    lblTransactionBlockHeight.Location = new Point(label113.Location.X + label113.Width, label113.Location.Y);
                });
                label126.Invoke((MethodInvoker)delegate
                {
                    label126.Location = new Point(lblTransactionBlockHeight.Location.X + lblTransactionBlockHeight.Width + 6, lblTransactionBlockHeight.Location.Y);
                });
                long unixTimestamp = Convert.ToInt64(transaction.Status.Block_time);
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
                lblTransactionBlockTime.Invoke((MethodInvoker)delegate
                {
                    lblTransactionBlockTime.Text = dateTime.ToString("yyyyMMdd-HH:mm");
                    lblTransactionBlockTime.Location = new Point(label126.Location.X + label126.Width, label126.Location.Y);
                });
                label125.Invoke((MethodInvoker)delegate
                {
                    label125.Location = new Point(lblTransactionBlockTime.Location.X + lblTransactionBlockTime.Width + 6, lblTransactionBlockTime.Location.Y);
                });
                lblTransactionConfirmations.Invoke((MethodInvoker)delegate
                {
                    lblTransactionConfirmations.Text = Convert.ToString(Convert.ToInt32(lblBlockNumber.Text) - Convert.ToInt32(lblTransactionBlockHeight.Text));
                    lblTransactionConfirmations.Location = new Point(label125.Location.X + label125.Width, label125.Location.Y);
                });

                label128.Invoke((MethodInvoker)delegate
                {
                    label128.Location = new Point(lblTransactionConfirmations.Location.X + lblTransactionConfirmations.Width + 6, lblTransactionConfirmations.Location.Y);
                });
                lblTransactionLockTime.Invoke((MethodInvoker)delegate
                {
                    lblTransactionLockTime.Text = Convert.ToString(transaction.Locktime);
                    lblTransactionLockTime.Location = new Point(label128.Location.X + label128.Width, label128.Location.Y);
                });
                label98.Invoke((MethodInvoker)delegate
                {
                    label98.Location = new Point(lblTransactionLockTime.Location.X + lblTransactionLockTime.Width + 6, lblTransactionLockTime.Location.Y);
                });
                lblTransactionVersion.Invoke((MethodInvoker)delegate
                {
                    lblTransactionVersion.Text = Convert.ToString(transaction.Version);
                    lblTransactionVersion.Location = new Point(label98.Location.X + label98.Width, label98.Location.Y);
                });

                lblTransactionSize.Invoke((MethodInvoker)delegate
                {
                    lblTransactionSize.Text = Convert.ToString(transaction.Size) + " bytes";
                });
                lblTransactionWeight.Invoke((MethodInvoker)delegate
                {
                    lblTransactionWeight.Text = Convert.ToString(transaction.Weight) + " MWU";
                });
                lblTransactionFee.Invoke((MethodInvoker)delegate
                {
                    lblTransactionFee.Text = Convert.ToString(transaction.Fee);
                });

                if (transaction.Vin.Count() == 1)
                {
                    lblTransactionInputCount.Invoke((MethodInvoker)delegate
                    {
                        lblTransactionInputCount.Text = Convert.ToString(transaction.Vin.Count()) + " input";
                    });
                }
                else
                {
                    lblTransactionInputCount.Invoke((MethodInvoker)delegate
                    {
                        lblTransactionInputCount.Text = Convert.ToString(transaction.Vin.Count()) + " inputs";
                    });
                }
                if (transaction.Vout.Count() == 1)
                {
                    lblTransactionOutputCount.Invoke((MethodInvoker)delegate
                    {
                        lblTransactionOutputCount.Text = Convert.ToString(transaction.Vout.Count()) + " output";
                    });
                }
                else
                {
                    lblTransactionOutputCount.Invoke((MethodInvoker)delegate
                    {
                        lblTransactionOutputCount.Text = Convert.ToString(transaction.Vout.Count()) + " outputs";
                    });
                }
                // ----------------- central bit of diagram
                long totalValueIn = 0;
                foreach (TransactionVin vin in transaction.Vin)
                {
                    if (!vin.Is_coinbase)
                    {
                        totalValueIn += vin.Prevout.Value;
                    }
                }
                string strTotalValueIn = totalValueIn.ToString(); // using ToString() instead of Convert.ToString()
                decimal decTotalBitcoinIn = ConvertSatsToBitcoin(strTotalValueIn);
                lblTotalInputValue.Invoke((MethodInvoker)delegate
                {
                    lblTotalInputValue.Text = decTotalBitcoinIn.ToString();
                    lblTotalInputValue.Location = new Point((panelTransactionDiagram.Size.Width / 2) - (lblTotalInputValue.Width / 2) - 95, (panelTransactionDiagram.Size.Height / 2) + 3);
                });
                long totalValueOut = 0;
                foreach (TransactionVout vout in transaction.Vout)
                {
                    totalValueOut += vout.Value;
                }
                string strTotalValueOut = totalValueOut.ToString(); // using ToString() instead of Convert.ToString()
                decimal decTotalBitcoinOut = ConvertSatsToBitcoin(strTotalValueOut);
                lblTotalOutputValue.Invoke((MethodInvoker)delegate
                {
                    lblTotalOutputValue.Text = decTotalBitcoinOut.ToString();
                    lblTotalOutputValue.Location = new Point((panelTransactionDiagram.Size.Width / 2) + 95 - (lblTotalOutputValue.Width / 2), (panelTransactionDiagram.Size.Height / 2) + 3);
                });

                lblTransactionFee.Invoke((MethodInvoker)delegate
                {
                    lblTransactionFee.Location = new Point((panelTransactionDiagram.Size.Width / 2) - (lblTransactionFee.Width / 2), panelTransactionDiagram.Size.Height / 2 - 120);
                });
                label104.Invoke((MethodInvoker)delegate
                {
                    label104.Location = new Point((panelTransactionDiagram.Size.Width / 2) - (label104.Width / 2), panelTransactionDiagram.Size.Height / 2 - 135);
                });
                panelTransactionMiddle.Invoke((MethodInvoker)delegate
                {
                    panelTransactionMiddle.Location = new Point((panelTransactionDiagram.Width / 2) - (panelTransactionMiddle.Width / 2), (panelTransactionDiagram.Height / 2) - (panelTransactionMiddle.Height / 2)); //move middle panel to centre
                });
                lblTransactionInputCount.Invoke((MethodInvoker)delegate
                {
                    lblTransactionInputCount.Location = new Point((panelTransactionDiagram.Size.Width / 2) - 130, (panelTransactionDiagram.Size.Height / 2) - 15);
                });
                lblTransactionOutputCount.Invoke((MethodInvoker)delegate
                {
                    lblTransactionOutputCount.Location = new Point((panelTransactionDiagram.Size.Width / 2) + 130 - lblTransactionOutputCount.Width, (panelTransactionDiagram.Size.Height / 2) - 15);
                });

                if (transaction.Vin[0].Is_coinbase == true)
                {
                    lblCoinbase.Invoke((MethodInvoker)delegate
                    {
                        lblCoinbase.Text = "Coinbase transaction";
                        lblCoinbase.Location = new Point(10, (panelTransactionDiagram.Size.Height / 2) - 15);
                    });
                }
                else
                {
                    lblCoinbase.Invoke((MethodInvoker)delegate
                    {
                        lblCoinbase.Text = "";
                    });
                }
                // central horizontal
                Point startPoint1 = new Point((panelTransactionDiagram.Size.Width / 2) - 150, panelTransactionDiagram.Size.Height / 2);
                Point endPoint1 = new Point((panelTransactionDiagram.Size.Width / 2) + 150, panelTransactionDiagram.Size.Height / 2);
                linePoints.Add(startPoint1);
                linePoints.Add(endPoint1);
                // vertical line up to fees
                Point startPoint2 = new Point(panelTransactionDiagram.Size.Width / 2, panelTransactionDiagram.Size.Height / 2 - panelTransactionMiddle.Height / 2);
                Point endPoint2 = new Point(panelTransactionDiagram.Size.Width / 2, panelTransactionDiagram.Size.Height / 2 - 100);
                linePoints.Add(startPoint2);
                linePoints.Add(endPoint2);
                // ------------- inputs on diagram
                int NumberOfInputLines = Convert.ToInt32(transaction.Vin.Count());
                decimal YInputsStep = 0;
                decimal YInputsPos = 0;
                if (NumberOfInputLines > 1)
                {
                    YInputsStep = (decimal)(panelTransactionDiagram.Size.Height - 20) / (NumberOfInputLines - 1);
                    YInputsPos = 10;
                }
                else
                {
                    YInputsStep = (panelTransactionDiagram.Size.Height / 2) - 20;
                    YInputsPos = (panelTransactionDiagram.Size.Height / 2);
                }

                if (NumberOfInputLines > 4)
                {
                    btnTransactionInputDown.Visible = true;
                    btnTransactionInputsUp.Visible = true;
                }
                else
                {
                    btnTransactionInputDown.Visible = false;
                    btnTransactionInputsUp.Visible = false;
                }

                foreach (var vin in transaction.Vin)
                {
                    if (YInputsPos >= panelTransactionDiagram.Height)
                    {
                        break;
                    }
                    Point startPoint3 = new Point(10, Convert.ToInt32(YInputsPos));
                    Point endPoint3 = new Point(100, Convert.ToInt32(YInputsPos));
                    linePoints.Add(startPoint3);
                    linePoints.Add(endPoint3);
                    Point startPoint4 = new Point(100, Convert.ToInt32(YInputsPos));
                    Point endPoint4 = new Point((panelTransactionDiagram.Size.Width / 2) - 150, panelTransactionDiagram.Size.Height / 2);
                    linePoints.Add(startPoint4);
                    linePoints.Add(endPoint4);
                    YInputsPos += YInputsStep;
                }
                // --------------- outputs on diagram
                int NumberOfOutputLines = Convert.ToInt32(transaction.Vout.Count());
                decimal YOutputsStep = 0;
                decimal YOutputsPos = 0;
                if (NumberOfOutputLines > 1)
                {
                    YOutputsStep = (decimal)(panelTransactionDiagram.Size.Height - 20) / (NumberOfOutputLines - 1);
                    YOutputsPos = 10;
                }
                else
                {
                    YOutputsStep = (panelTransactionDiagram.Size.Height / 2) - 20;
                    YOutputsPos = (panelTransactionDiagram.Size.Height / 2);
                }

                if (NumberOfOutputLines > 4)
                {
                    btnTransactionOutputsDown.Visible = true;
                    btnTransactionOutputsUp.Visible = true;
                }
                else
                {
                    btnTransactionOutputsDown.Visible = false;
                    btnTransactionOutputsUp.Visible = false;
                }

                foreach (var vout in transaction.Vout)
                {
                    if (YOutputsPos >= panelTransactionDiagram.Height)
                    {
                        break;
                    }
                    Point startPoint5 = new Point(panelTransactionDiagram.Size.Width - 10, Convert.ToInt32(YOutputsPos));
                    Point endPoint5 = new Point(panelTransactionDiagram.Size.Width - 100, Convert.ToInt32(YOutputsPos));
                    linePoints.Add(startPoint5);
                    linePoints.Add(endPoint5);
                    Point startPoint6 = new Point(panelTransactionDiagram.Size.Width - 100, Convert.ToInt32(YOutputsPos));
                    Point endPoint6 = new Point((panelTransactionDiagram.Size.Width / 2) + 150, panelTransactionDiagram.Size.Height / 2);
                    linePoints.Add(startPoint6);
                    linePoints.Add(endPoint6);
                    YOutputsPos += YOutputsStep;
                }

                // Inputs listview
                listViewTransactionInputs.Invoke((MethodInvoker)delegate
                {
                    listViewTransactionInputs.Items.Clear(); // remove any data that may be there already
                });
                listViewTransactionInputs.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewTransactionInputs, new object[] { true });

                // Check if the column header already exists
                if (listViewTransactionInputs.Columns.Count == 0)
                {
                    // If not, add the column header
                    listViewTransactionInputs.Invoke((MethodInvoker)delegate
                    {
                        listViewTransactionInputs.Columns.Add(" Address", 225);
                    });
                }

                if (listViewTransactionInputs.Columns.Count == 1)
                {
                    listViewTransactionInputs.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewTransactionInputs.Columns.Add("Amount", 120);
                    });
                }

                List<TransactionVinPrevout> prevouts = new List<TransactionVinPrevout>();

                foreach (TransactionVin vin in transaction.Vin)
                {
                    prevouts.Add(vin.Prevout);
                }

                foreach (TransactionVinPrevout prevout in prevouts)
                {
                    string InputAddress = "";
                    if (prevout != null)
                    {
                        InputAddress = Convert.ToString(prevout.Scriptpubkey_address);
                        ListViewItem item = new ListViewItem(InputAddress); // create new row
                        string InputValue = Convert.ToString(prevout.Value);
                        decimal DecInputValue = ConvertSatsToBitcoin(InputValue);
                        item.SubItems.Add(DecInputValue.ToString());
                        listViewTransactionInputs.Invoke((MethodInvoker)delegate
                        {
                            listViewTransactionInputs.Items.Add(item); // add row
                        });
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem("N/A"); // create new row
                        item.SubItems.Add("N/A");
                        listViewTransactionInputs.Invoke((MethodInvoker)delegate
                        {
                            listViewTransactionInputs.Items.Add(item); // add row
                        });
                    }
                }
                // Get the height of each item to set height of whole listview
                int rowHeight = listViewTransactionInputs.Margin.Vertical + listViewTransactionInputs.Padding.Vertical + listViewTransactionInputs.GetItemRect(0).Height;
                int itemCount = listViewTransactionInputs.Items.Count; // Get the number of items in the ListBox
                int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                listViewTransactionInputs.Height = listBoxHeight; // Set the height of the ListBox
                panelTransactionInputs.VerticalScroll.Value = 0;
                panelTransactionInputs.VerticalScroll.Minimum = 0;
                if (listViewTransactionInputs.Items.Count > 0)
                {
                    listViewTransactionInputs.Items[0].Selected = true;
                }

                // Outputs listview
                listViewTransactionOutputs.Invoke((MethodInvoker)delegate
                {
                    listViewTransactionOutputs.Items.Clear(); // remove any data that may be there already
                });
                listViewTransactionOutputs.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewTransactionOutputs, new object[] { true });

                // Check if the column header already exists
                if (listViewTransactionOutputs.Columns.Count == 0)
                {
                    // If not, add the column header
                    listViewTransactionOutputs.Invoke((MethodInvoker)delegate
                    {
                        listViewTransactionOutputs.Columns.Add(" Address", 225);
                    });
                }

                if (listViewTransactionOutputs.Columns.Count == 1)
                {
                    listViewTransactionOutputs.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewTransactionOutputs.Columns.Add("Amount", 120);
                    });
                }

                List<TransactionVout> vouts = new List<TransactionVout>();

                foreach (TransactionVout vout in transaction.Vout)
                {
                    vouts.Add(vout);
                }

                foreach (TransactionVout vout in vouts)
                {
                    string OutputAddress;
                    if (vout.Scriptpubkey_address != "" && vout.Scriptpubkey_address != null)  // display address
                    {
                        OutputAddress = Convert.ToString(vout.Scriptpubkey_address);
                    }
                    else // display OP RETURN after converting hex to ascii
                    {
                        string input = vout.Scriptpubkey_asm;
                        string hex = Regex.Match(input, @"\b([0-9A-Fa-f]{2})+\b").Value;
                        byte[] bytes = Enumerable.Range(0, hex.Length / 2)
                            .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                            .ToArray();
                        string ascii = Encoding.ASCII.GetString(bytes);
                        OutputAddress = "OP_RETURN: " + ascii;
                    }

                    ListViewItem item = new ListViewItem(OutputAddress); // create new row
                    string OutputValue = Convert.ToString(vout.Value);
                    decimal DecOutputValue = ConvertSatsToBitcoin(OutputValue);
                    item.SubItems.Add(DecOutputValue.ToString());
                    listViewTransactionOutputs.Invoke((MethodInvoker)delegate
                    {
                        listViewTransactionOutputs.Items.Add(item); // add row
                    });
                }
                int rowHeightout = listViewTransactionOutputs.Margin.Vertical + listViewTransactionOutputs.Padding.Vertical + listViewTransactionOutputs.GetItemRect(0).Height; // Get the height of each item to set height of whole listview
                int itemCountout = listViewTransactionOutputs.Items.Count; // Get the number of items in the ListBox
                int listBoxHeightout = (itemCountout + 2) * rowHeightout; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                listViewTransactionOutputs.Height = listBoxHeightout; // Set the height of the ListBox
                panelTransactionOutputs.VerticalScroll.Value = 0;
                panelTransactionOutputs.VerticalScroll.Minimum = 0;

                if (listViewTransactionOutputs.Items.Count > 0)
                {
                    listViewTransactionOutputs.Items[0].Selected = true;
                }
                // Trigger a repaint of the form
                this.Invalidate();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransaction");
            }
        }
        #endregion
        #region listview appearance
        //-------------------- AN INPUT ROW HAS BEEN SELECTED --------------------------------------------------
        private void ListViewTransactionInputs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewTransactionInputs.Items)
                {
                    if (item.Selected)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        if (item.SubItems[0].Text != "N/A" && item.SubItems[0].Text != "")
                        {
                            btnViewAddressFromTXInput.Invoke((MethodInvoker)delegate
                            {
                                btnViewAddressFromTXInput.Visible = true;
                                btnViewAddressFromTXInput.Location = new Point(item.Position.X + listViewTransactionInputs.Location.X + listViewTransactionInputs.Columns[0].Width - btnViewAddressFromTXInput.Width - 8, item.Position.Y + listViewTransactionInputs.Location.Y);
                                btnViewAddressFromTXInput.Height = item.Bounds.Height;
                            });
                            anySelected = true;
                        }
                        else
                        {
                            btnViewAddressFromTXInput.Visible = false;
                        }
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
                btnViewAddressFromTXInput.Visible = anySelected;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionInputs_ItemSelectionChanged");
            }
        }

        //-------------------- AN OUTPUT ROW HAS BEEN SELECTED --------------------------------------------------
        private void ListViewTransactionOutputs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewTransactionOutputs.Items)
                {
                    if (item.Selected)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        if (item.SubItems[0].Text != "N/A" && item.SubItems[0].Text != "")
                        {
                            btnViewAddressFromTXOutput.Invoke((MethodInvoker)delegate
                            {
                                btnViewAddressFromTXOutput.Visible = true;
                                btnViewAddressFromTXOutput.Location = new Point(item.Position.X + listViewTransactionOutputs.Location.X + listViewTransactionOutputs.Columns[0].Width - btnViewAddressFromTXOutput.Width - 8, item.Position.Y + listViewTransactionOutputs.Location.Y);
                                btnViewAddressFromTXOutput.Height = item.Bounds.Height;
                            });
                            anySelected = true;
                        }
                        else
                        {
                            btnViewAddressFromTXOutput.Visible = false;
                        }
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
                btnViewAddressFromTXOutput.Visible = anySelected;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionOutputs_ItemSelectionChanged");
            }
        }

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTHS ----------------------------------------------
        private void ListViewTransactionInputs_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewTransactionInputs.Columns[e.ColumnIndex].Width < 225) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 225;
                    }
                    if (listViewTransactionInputs.Columns[e.ColumnIndex].Width > 345) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 345;
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    if (listViewTransactionInputs.Columns[e.ColumnIndex].Width < 120) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 120;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionInputs_ColumnWidthChanging");
            }
        }

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTHS ----------------------------------------------
        private void ListViewTransactionOutputs_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewTransactionOutputs.Columns[e.ColumnIndex].Width < 225) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 225;
                    }
                    if (listViewTransactionOutputs.Columns[e.ColumnIndex].Width > 345) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 345;
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    if (listViewTransactionOutputs.Columns[e.ColumnIndex].Width < 120) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 120;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionOutputs_ColumnWidthChanging");
            }
        }

        //-------------------- FORMAT DATA WHILE DRAWING LISTVIEW ----------------------------------------------
        private void ListViewTransactionInputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;
                var font = listViewTransactionInputs.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewTransactionInputs.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewTransactionInputs.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionInputs_DrawSubItem");
            }
        }

        //-------------------- FORMAT DATA WHILE DRAWING LISTVIEW ----------------------------------------------
        private void ListViewTransactionOutputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;
                var font = listViewTransactionOutputs.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewTransactionOutputs.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewTransactionOutputs.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewTransactionOutputs_DrawSubItem");
            }
        }
        #endregion
        #region listview scrolling
        //-------------------- SCROLL-DOWN INPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionInputsDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelTransactionInputs.VerticalScroll.Value < panelTransactionInputs.VerticalScroll.Maximum)
                {
                    panelTransactionInputs.VerticalScroll.Value++;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsDown_Click");
            }
        }

        //-------------------- SCROLL-DOWN OUTPUTS CLICKED -----------------------------------------------------
        private void BtnTransactionOutputsDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelTransactionOutputs.VerticalScroll.Value < panelTransactionOutputs.VerticalScroll.Maximum)
                {
                    panelTransactionOutputs.VerticalScroll.Value++;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsDown_Click");
            }
        }

        //-------------------- SCROLL-DOWN MOUSE-DOWN --------------------------------------------------------
        private void BtnTransactionInputsDown_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isInputButtonPressed = true;
                InputDownButtonPressed = true;
                TXInScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsDown_MouseDown");
            }
        }

        private void BtnTransactionOutputsDown_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //scrollPosition = new Point(panel26.HorizontalScroll.Value, panel26.VerticalScroll.Value);
                isOutputButtonPressed = true;
                OutputDownButtonPressed = true;
                TXOutScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsDown_MouseDown");
            }
        }

        //-------------------- SCROLL-DOWN MOUSE-UP-- --------------------------------------------------------
        private void BtnTransactionInputsDown_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isInputButtonPressed = false;
                InputDownButtonPressed = false;
                TXInScrollTimer.Stop();
                TXInScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsDown_MouseUp");
            }
        }

        private void BtnTransactionOutputsDown_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isOutputButtonPressed = false;
                OutputDownButtonPressed = false;
                TXOutScrollTimer.Stop();
                TXOutScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsDown_MouseUp");
            }
        }

        //-------------------- HANDLE THE ACTUAL SCROLLING --------------------------------------------------
        private void TXInTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isInputButtonPressed)
                {
                    if (InputDownButtonPressed)
                    {
                        if (panelTransactionInputs.VerticalScroll.Value < panelTransactionInputs.VerticalScroll.Maximum - 5)
                        {
                            panelTransactionInputs.VerticalScroll.Value = panelTransactionInputs.VerticalScroll.Value + 5;
                            TransactionInputsScrollPosition = panelTransactionInputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        TXInScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                    else if (InputUpButtonPressed)
                    {
                        if (panelTransactionInputs.VerticalScroll.Value > panelTransactionInputs.VerticalScroll.Minimum + 5)
                        {
                            panelTransactionInputs.VerticalScroll.Value = panelTransactionInputs.VerticalScroll.Value - 5;
                            TransactionInputsScrollPosition = panelTransactionInputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        TXInScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                }
                else
                {
                    TXInScrollTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TXInTimer_Tick");
            }
        }

        private void TXOutTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isOutputButtonPressed)
                {
                    if (OutputDownButtonPressed)
                    {
                        if (panelTransactionOutputs.VerticalScroll.Value < panelTransactionOutputs.VerticalScroll.Maximum - 5)
                        {
                            panelTransactionOutputs.VerticalScroll.Value = panelTransactionOutputs.VerticalScroll.Value + 5;
                            TransactionOutputsScrollPosition = panelTransactionOutputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        TXOutScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                    else if (OutputUpButtonPressed)
                    {
                        if (panelTransactionOutputs.VerticalScroll.Value > panelTransactionOutputs.VerticalScroll.Minimum + 5)
                        {
                            panelTransactionOutputs.VerticalScroll.Value = panelTransactionOutputs.VerticalScroll.Value - 5;
                            TransactionOutputsScrollPosition = panelTransactionOutputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        TXOutScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                }
                else
                {
                    TXOutScrollTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TXOutTimer_Tick");
            }
        }

        //-------------------- SCROLL-UP INPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionInputsUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelTransactionInputs.VerticalScroll.Value > panelTransactionInputs.VerticalScroll.Minimum)
                {
                    panelTransactionInputs.VerticalScroll.Value--;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsUp_Click");
            }
        }

        //-------------------- SCROLL-UP OUTPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionOutputsUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelTransactionOutputs.VerticalScroll.Value > panelTransactionOutputs.VerticalScroll.Minimum)
                {
                    panelTransactionOutputs.VerticalScroll.Value--;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsUp_Click");
            }
        }

        //-------------------- SCROLL-UP MOUSE-DOWN -------------------------------------------------------
        private void BtnTransactionInputsUp_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isInputButtonPressed = true;
                InputUpButtonPressed = true;
                TXInScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsUp_MouseDown");
            }
        }

        private void BtnTransactionOutputsUp_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isOutputButtonPressed = true;
                OutputUpButtonPressed = true;
                TXOutScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsUp_MouseDown");
            }
        }

        //-------------------- SCROLL-UP MOUSE-UP -------------------------------------------------------
        private void BtnTransactionInputsUp_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isInputButtonPressed = false;
                InputUpButtonPressed = false;
                TXInScrollTimer.Stop();
                TXInScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionInputsUp_MouseUp");
            }
        }

        private void BtnTransactionOutputsUp_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isOutputButtonPressed = false;
                OutputUpButtonPressed = false;
                TXOutScrollTimer.Stop();
                TXOutScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnTransactionOutputsUp_MouseUp");
            }
        }

        //-------------------- PREVENT LIST-VIEW FROM JUMPING TO TOP WHEN PAINTED ------------------------
        private void PanelTransactionInputs_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btnViewAddressFromTXInput.Visible) // user must have clicked a row given that the button is visible
                {
                    panelTransactionInputs.VerticalScroll.Value = TransactionInputsScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PanelTransactionInputs_Paint");
            }
        }

        private void PanelTransactionOutputs_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btnViewAddressFromTXOutput.Visible) // user must have clicked a row given that the button is visible
                {
                    panelTransactionOutputs.VerticalScroll.Value = TransactionOutputsScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PanelTransactionOutputs_Paint");
            }
        }

        #endregion
        #region draw transaction diagram
        //-------DRAW LINES ON TRANSACTION DIAGRAM FROM PREVIOUSLY STORED LIST-----------------------------------
        private void PanelTransactionDiagram_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Pen pen = new Pen(linesColor);

                // Iterate over the stored list of points and draw lines between them
                for (int i = 0; i < linePoints.Count - 1; i += 2)
                {
                    e.Graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PanelTransactionDiagram_Paint");
            }
        }
        #endregion
        #region navigate from listview to address screen
        //-------------------- VIEW ADDRESS ------------------------------------------------------------
        private void BtnViewAddressFromTXInput_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewTransactionInputs.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress; // copy address to address screen
                });
                //show the address screen
                BtnMenuAddress_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewAddressFromTXInput_Click");
            }
        }

        private void BtnViewAddressFromTXOutput_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewTransactionOutputs.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress; // copy address to address screen
                });
                //show the address screen
                BtnMenuAddress_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewAddressFromTXOutput_Click");
            }
        }
        #endregion
        #region enable/disable buttons
        private void DisableEnableTransactionButtons(string enableOrDisableTransactionButtons)
        {
            try
            {
                if (enableOrDisableTransactionButtons == "disable")
                {
                    // get current state of buttons before disabling them
                    btnTransactionInputsUpWasEnabled = btnTransactionInputsUp.Enabled;
                    btnTransactionInputDownWasEnabled = btnTransactionInputDown.Enabled;
                    btnTransactionOutputsUpWasEnabled = btnTransactionOutputsUp.Enabled;
                    btnTransactionOutputsDownWasEnabled = btnTransactionOutputsDown.Enabled;
                    btnViewAddressFromTXInputWasEnabled = btnViewAddressFromTXInput.Enabled;
                    btnViewAddressFromTXOutputWasEnabled = btnViewAddressFromTXOutput.Enabled;

                    //disable them all
                    btnTransactionInputsUp.Enabled = false;
                    btnTransactionInputDown.Enabled = false;
                    btnTransactionOutputsUp.Enabled = false;
                    btnTransactionOutputsDown.Enabled = false;
                    btnViewAddressFromTXInput.Enabled = false;
                    btnViewAddressFromTXOutput.Enabled = false;
                    btnMenu.Enabled = false;
                }
                else
                {
                    // use previously saved states to reinstate buttons
                    btnTransactionInputsUp.Enabled = btnTransactionInputsUpWasEnabled;
                    btnTransactionInputDown.Enabled = btnTransactionInputDownWasEnabled;
                    btnTransactionOutputsUp.Enabled = btnTransactionOutputsUpWasEnabled;
                    btnTransactionOutputsDown.Enabled = btnTransactionOutputsDownWasEnabled;
                    btnViewAddressFromTXInput.Enabled = btnViewAddressFromTXInputWasEnabled;
                    btnViewAddressFromTXOutput.Enabled = btnViewAddressFromTXOutputWasEnabled;
                    // Set the cursor position to the end of the string
                    btnMenu.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableEnableTransactionButtons");
            }
        }
        #endregion
        #endregion

        #region ⚡BLOCK LIST SCREEN⚡
        #region user input
        private void TextBoxBlockHeightToStartListFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Get the maximum allowed value for the block number
                int maxValue = int.Parse(lblBlockNumber.Text);

                // Allow only digits, backspace, delete, and enter
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '\r')
                {
                    e.Handled = true;
                    return;
                }

                // Handle backspace
                if (e.KeyChar == '\b')
                {
                    // If there is a selection, delete it
                    if (textBoxBlockHeightToStartListFrom.SelectionLength > 0)
                    {
                        int start = textBoxBlockHeightToStartListFrom.SelectionStart;
                        int length = textBoxBlockHeightToStartListFrom.SelectionLength;
                        textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                        {
                            textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(start, length);
                            textBoxBlockHeightToStartListFrom.SelectionStart = start;
                        });
                    }
                    // If the cursor is not at the beginning, delete the character to the left of the cursor
                    else if (textBoxBlockHeightToStartListFrom.SelectionStart > 0)
                    {
                        int pos = textBoxBlockHeightToStartListFrom.SelectionStart - 1;
                        textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                        {
                            textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(pos, 1);
                            textBoxBlockHeightToStartListFrom.SelectionStart = pos;
                        });
                    }

                    e.Handled = true;
                    return;
                }

                // Handle delete
                if (e.KeyChar == '\u007F')
                {
                    // If there is a selection, delete it
                    if (textBoxBlockHeightToStartListFrom.SelectionLength > 0)
                    {
                        int start = textBoxBlockHeightToStartListFrom.SelectionStart;
                        int length = textBoxBlockHeightToStartListFrom.SelectionLength;
                        textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                        {
                            textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(start, length);
                            textBoxBlockHeightToStartListFrom.SelectionStart = start;
                        });
                    }
                    // If the cursor is not at the end, delete the character to the right of the cursor
                    else if (textBoxBlockHeightToStartListFrom.SelectionStart < textBoxBlockHeightToStartListFrom.Text.Length)
                    {
                        int pos = textBoxBlockHeightToStartListFrom.SelectionStart;
                        textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                        {
                            textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(pos, 1);
                            textBoxBlockHeightToStartListFrom.SelectionStart = pos;
                        });
                    }

                    e.Handled = true;
                    return;
                }

                // Handle enter
                if (e.KeyChar == '\r')
                {
                    // Submit button was pressed
                    LookupBlockList();
                    e.Handled = true;
                    return;
                }

                // Construct the new value of the textbox by appending the pressed character
                string valueString = textBoxBlockHeightToStartListFrom.Text + e.KeyChar.ToString();

                // Handle the case where the textbox is empty by setting it to 0
                if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = "0";
                        textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                // Handle non-numeric input
                if (!int.TryParse(valueString, out int value))
                {
                    e.Handled = true;
                    return;
                }

                // Handle negative input by setting the textbox to 0
                if (value < 0)
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = "0";
                        textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                // Handle input that exceeds the maximum allowed value by setting the textbox to the maximum value
                if (value > maxValue)
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = maxValue.ToString();
                        textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                    });
                    e.Handled = true;
                    return;
                }

                textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                {
                    textBoxBlockHeightToStartListFrom.Text = value.ToString();
                    textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                HandleException(ex, "textBoxBlockHeightToStartListFrom_KeyPress");
            }
        }

        private void TextBoxBlockHeightToStartListFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = "0";
                    });
                    // btnPreviousBlock.Enabled = false;
                    // btnNextBlock.Enabled = true;
                }
                if (textBoxBlockHeightToStartListFrom.Text == lblBlockNumber.Text)
                {
                    // btnNextBlock.Enabled = false;
                    // btnPreviousBlock.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "textBoxBlockHeightToStartListFrom_TextChanged");
            }
        }
        #endregion
        #region set up block list screen
        private async void LookupBlockList()
        {
            try
            {
                btnViewBlockFromBlockList.Visible = false;
                var blockNumber = Convert.ToString(textBoxBlockHeightToStartListFrom.Text);
                await GetFifteenBlocksForBlockList(blockNumber);
            }
            catch (Exception ex)
            {
                HandleException(ex, "LookupBlockList");
            }
        }

        //-------------------- GET A LIST OF FIFTEEN BLOCKS AND DISPLAY THEM ------------------------------------------------
        private async Task GetFifteenBlocksForBlockList(string lastSeenBlockNumber)
        {
            try
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableBlockListButtons("disable"); // disable buttons during operation

                var blocksJson = await _blockService.GetBlockDataAsync(lastSeenBlockNumber);

                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableBlockListButtons("enable"); // enable buttons after operation is complete

                var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                List<string> blocklist = blocks.Select(t => t.Height).ToList();

                // Update lastSeenBlockNumber if this isn't our first fetch of blocks to restart from the right place
                if (blocklist.Count > 0)
                {
                    lastSeenBlockNumber = blocklist.Last();
                    storedLastSeenBlockNumber = blocklist.Last();
                }

                //LIST VIEW
                listViewBlockList.Invoke((MethodInvoker)delegate
                {
                    listViewBlockList.Items.Clear(); // remove any data that may be there already
                });
                listViewBlockList.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewBlockList, new object[] { true });

                // Check if the column header already exists
                if (listViewBlockList.Columns.Count == 0)
                {
                    // If not, add the column header
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockList.Columns.Add(" Date / time", 115);
                    });
                }

                if (listViewBlockList.Columns.Count == 1)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("Height", 65);
                    });
                }

                if (listViewBlockList.Columns.Count == 2)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("TX count", 60);
                    });
                }
                if (listViewBlockList.Columns.Count == 3)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("Size", 50);
                    });
                }
                if (listViewBlockList.Columns.Count == 4)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("Fee range", 70);
                    });
                }
                if (listViewBlockList.Columns.Count == 5)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("Med.", 50);
                    });
                }
                if (listViewBlockList.Columns.Count == 6)
                {
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        // If not, add the column header
                        listViewBlockList.Columns.Add("Reward (BTC)", 90);
                    });
                }
                // Add the items to the ListView
                int counter = 0; // used to count rows in list as they're added
                panel92.Visible = false;

                foreach (var block in blocks)
                {
                    long unixTimestamp = Convert.ToInt64(block.Timestamp);
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
                    string formattedDateTime = dateTime.ToString("yyyyMMdd-HH:mm");
                    ListViewItem item = new ListViewItem(formattedDateTime); // create new row
                    item.SubItems.Add(block.Height.ToString());
                    if (block.Height == textBoxBlockHeightToStartListFrom.Text)
                    {
                        panel92.Visible = true;
                    }
                    item.SubItems.Add(block.Tx_count.ToString());
                    decimal sizeInMB = block.Size;
                    sizeInMB /= 1000000;
                    item.SubItems.Add(sizeInMB.ToString("0.00")); // number of outputs
                    string feerange = Convert.ToString(Convert.ToInt32(block.Extras.FeeRange[0])) + "-" + Convert.ToString(Convert.ToInt32(block.Extras.FeeRange[6]));
                    item.SubItems.Add(feerange.ToString());
                    string medFee = Convert.ToString("~" + Convert.ToInt32(block.Extras.MedianFee));
                    item.SubItems.Add(medFee.ToString());
                    string RewardInSats = Convert.ToString(block.Extras.Reward);
                    decimal RewardInBTC = ConvertSatsToBitcoin(RewardInSats);
                    item.SubItems.Add(RewardInBTC.ToString());
                    listViewBlockList.Invoke((MethodInvoker)delegate
                    {
                        listViewBlockList.Items.Add(item); // add row
                    });

                    counter++; // increment rows for this batch


                    if (blocklist.First() == lblBlockNumber.Text) // We're looking at the most recent blocks 
                    {
                        btnNewer15Blocks.Enabled = false;
                    }
                    else
                    {
                        btnNewer15Blocks.Enabled = true;

                    }

                    if (counter > 1 && blocklist.Last() == "0") // we've reached the Genesis Block (bottom of the list)
                    {
                        btnOlder15Blocks.Enabled = false; // so we won't need this
                    }
                    else
                    {
                        btnOlder15Blocks.Enabled = true;
                    }

                    if (counter == 15) // ListView is full. stop adding rows at this point and pick up from here...
                    {
                        break;
                    }
                }

                if (counter > 0)
                {
                    listViewBlockList.Items[0].Selected = true;
                    if (btnOlder15Blocks.Enabled == true)
                    {
                        btnOlder15Blocks.Focus();
                    }
                    else
                    {
                        btnNewer15Blocks.Focus();
                    }
                    lblBlockListPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblBlockListPositionInList.Text = "Blocks " + blocklist.Last() + " - " + blocklist.First() + " of " + lblBlockNumber.Text;
                    });
                }
                else
                {
                    lblBlockListPositionInList.Invoke((MethodInvoker)delegate
                    {
                        lblBlockListPositionInList.Text = "No blocks to display"; // this can't really happen as there will always be a coinbase transaction
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetFifteenBlocksForBlockList");
            }
        }
        #endregion
        #region prev/next batch of blocks
        //-------------------- GET THE PREVIOUS FIFTEEN BLOCKS --------------------------------------------------------------
        private async void BtnOlder15Blocks_Click(object sender, EventArgs e)
        {
            try
            {
                int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) - 1);
                string blockNumber = Convert.ToString(blockheight);
                // Get 15 more blocks starting from the current block height minus the number we've already seen
                await GetFifteenBlocksForBlockList(blockNumber);
                btnViewBlockFromBlockList.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnOlder15Blocks_Click");
            }
        }

        //-------------------- GET THE NEXT FIFTEEN BLOCKS ------------------------------------------------------------------
        private async void BtnNewer15Blocks_Click(object sender, EventArgs e)
        {
            try
            {
                int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) + 29);
                string blockNumber = Convert.ToString(blockheight);
                // Get 15 more blocks starting from the current block height minus the number we've already seen
                await GetFifteenBlocksForBlockList(blockNumber);
                btnViewBlockFromBlockList.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnNewer15Blocks_Click");
            }
        }
        #endregion
        #region listview appearance
        private void ListViewBlockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewBlockList.SelectedItems.Count > 0)
                {
                    Rectangle itemRect = listViewBlockList.GetItemRect(listViewBlockList.SelectedIndices[0]);
                    panel14.Invoke((MethodInvoker)delegate
                    {
                        panel14.Top = itemRect.Top + 8;
                    });
                    panel19.Invoke((MethodInvoker)delegate
                    {
                        panel19.Height = panel17.Top - panel14.Top;
                        panel19.Top = panel14.Top;
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockList_SelectedIndexChanged");
            }
        }

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTH -----------------------------------------------------------
        private void ListViewBlockList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 115) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 115;
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 60) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 60;
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 60) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 60;
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 50) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 50;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 75) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 75;
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 50) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 50;
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (listViewBlockList.Columns[e.ColumnIndex].Width != 90) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 90;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockList_ColumnWidthChanging");
            }
        }

        //---------------------- FORMAT THE DATA IN THE LISTVIEW ------------------------------------------------------------
        private void ListViewBlockList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;

                if (text[0] == '+') // if the string is a change to an amount and positive
                {
                    e.SubItem.ForeColor = Color.OliveDrab; // make it green
                }
                else
                if (text[0] == '-') // if the string is a change to an amount and negative
                {
                    e.SubItem.ForeColor = Color.IndianRed; // make it red
                }

                var font = listViewBlockList.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBlockList.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBlockList.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockList_DrawSubItem");
            }
        }
        #endregion
        #region navigate from listview to block screen
        //-------------------- VIEW INDIVIDUAL BLOCK ------------------------------------------------------------------------
        private void BtnViewBlockFromBlockList_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewBlockList.SelectedItems[0];
                // Get the second subitem in the selected item (index 1)
                string submittedBlockNumber = selectedItem.SubItems[1].Text;
                // Set the text of the textBoxSubmittedBlockNumber control
                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = submittedBlockNumber; // copy block number to block screen
                });
                LookupBlock();
                //show the block screen
                BtnMenuBlock_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewBlockFromBlockList_Click");
            }
        }
        #endregion
        #region detail selected block row
        //-------------------- A ROW HAS BEEN CLICKED ON BLOCKLIST ----------------------------------------------------------
        private async void ListViewBlockList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewBlockList.Items)
                {
                    if (item.Selected)
                    {
                        btnViewBlockFromBlockList.Enabled = true;
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        anySelected = true;
                        btnViewBlockFromBlockList.Invoke((MethodInvoker)delegate
                        {
                            btnViewBlockFromBlockList.Location = new Point(item.Position.X + listViewBlockList.Location.X + listViewBlockList.Columns[0].Width + listViewBlockList.Columns[1].Width - btnViewBlockFromBlockList.Width - 3, item.Position.Y + listViewBlockList.Location.Y);
                            btnViewBlockFromBlockList.Height = item.Bounds.Height;
                        });
                        // display block hash
                        using (WebClient client = new WebClient())
                        {
                            string BlockHashURL = NodeURL + "block-height/" + item.SubItems[1].Text;
                            string BlockHash = client.DownloadString(BlockHashURL); // get hash of provided block
                            lblBlockListBlockHash.Invoke((MethodInvoker)delegate
                            {
                                lblBlockListBlockHash.Text = BlockHash;
                                lblBlockListBlockHash.Location = new Point(label90.Location.X + label90.Width, label90.Location.Y + 2);
                            });
                        }
                        string blockNumber = item.SubItems[1].Text;
                        ToggleLoadingAnimation("enable"); // start the loading animation
                        DisableEnableBlockListButtons("disable"); // disable buttons during operation
                        var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                        ToggleLoadingAnimation("disable"); // stop the loading animation
                        DisableEnableBlockListButtons("enable"); // enable buttons after operation is complete
                        var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                        List<string> blocklist = blocks.Select(t => t.Height).ToList();
                        lblBlockListBlockTime.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].Timestamp)).ToString("yyyy-MM-dd HH:mm");
                            lblBlockListBlockTime.Location = new Point(label91.Location.X + label91.Width, label91.Location.Y + 2);
                        });
                        long sizeInBytes = blocks[0].Size;
                        string sizeString = ""; // convert display to bytes/kb/mb accordingly
                        if (sizeInBytes < 1000)
                        {
                            sizeString = $"{sizeInBytes} bytes";
                        }
                        else if (sizeInBytes < 1000 * 1000)
                        {
                            double sizeInKB = (double)sizeInBytes / 1000;
                            sizeString = $"{sizeInKB:N2} KB";
                        }
                        else
                        {
                            double sizeInMB = (double)sizeInBytes / (1000 * 1000);
                            sizeString = $"{sizeInMB:N2} MB";
                        }
                        lblBlockListBlockSize.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockSize.Text = sizeString;
                            lblBlockListBlockSize.Location = new Point(label105.Location.X + label105.Width, label105.Location.Y + 2);
                        });
                        string strWeight = Convert.ToString(blocks[0].Weight);
                        decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
                        string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
                        lblBlockListBlockWeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockWeight.Text = strFormattedWeight;
                            lblBlockListBlockWeight.Location = new Point(label103.Location.X + label103.Width, label103.Location.Y + 2);
                        });
                        long nonceLong = Convert.ToInt64(blocks[0].Nonce);
                        lblBlockListNonce.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListNonce.Text = "0x" + nonceLong.ToString("X");
                            lblBlockListNonce.Location = new Point(label24.Location.X + label24.Width, label24.Location.Y + 2);
                        });
                        lblBlockListMiner.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListMiner.Text = Convert.ToString(blocks[0].Extras.Pool.Name);
                            lblBlockListMiner.Location = new Point(label95.Location.X + label95.Width, label95.Location.Y + 2);
                        });
                        lblBlockListTransactionCount.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTransactionCount.Text = Convert.ToString(blocks[0].Tx_count);
                            lblBlockListTransactionCount.Location = new Point(label99.Location.X + label99.Width, label99.Location.Y + 2);
                        });
                        string TotalBlockFees = Convert.ToString(blocks[0].Extras.TotalFees);
                        TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
                        lblBlockListTotalFees.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalFees.Text = TotalBlockFees;
                            lblBlockListTotalFees.Location = new Point(label88.Location.X + label88.Width, label88.Location.Y + 2);
                        });
                        string Reward = Convert.ToString(blocks[0].Extras.Reward);
                        lblBlockListReward.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
                            lblBlockListReward.Location = new Point(label101.Location.X + label101.Width, label101.Location.Y + 2);
                        });
                        lblBlockListBlockFeeRangeAndMedianFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockFeeRangeAndMedianFee.Text = Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[0])) + "-" + Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[6])) + " / " + Convert.ToString(Convert.ToInt32(blocks[0].Extras.MedianFee));
                            lblBlockListBlockFeeRangeAndMedianFee.Location = new Point(label93.Location.X + label93.Width, label93.Location.Y + 2);
                        });
                        lblBlockListAverageFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageFee.Text = Convert.ToString(blocks[0].Extras.AvgFee);
                            lblBlockListAverageFee.Location = new Point(label97.Location.X + label97.Width, label97.Location.Y + 2);
                        });
                        lblBlockListTotalInputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalInputs.Text = Convert.ToString(blocks[0].Extras.TotalInputs);
                            lblBlockListTotalInputs.Location = new Point(label89.Location.X + label89.Width, label89.Location.Y + 2);
                        });
                        lblBlockListTotalOutputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalOutputs.Text = Convert.ToString(blocks[0].Extras.TotalOutputs);
                            lblBlockListTotalOutputs.Location = new Point(label94.Location.X + label94.Width, label94.Location.Y + 2);
                        });
                        lblBlockListAverageTransactionSize.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageTransactionSize.Text = Convert.ToString(blocks[0].Extras.AvgTxSize);
                            lblBlockListAverageTransactionSize.Location = new Point(label92.Location.X + label92.Width, label92.Location.Y + 2);
                        });
                        lblBlockListVersion.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListVersion.Text = Convert.ToString(blocks[0].Version);
                            lblBlockListVersion.Location = new Point(label96.Location.X + label96.Width, label96.Location.Y + 2);
                        });
                        lblBlockListBlockHeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockHeight.Text = "Block height: " + Convert.ToString(blocks[0].Height);
                        });
                        pictureBoxBlockListPoolRanking.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListPoolRanking.Location = new Point(lblBlockListMiner.Location.X + lblBlockListMiner.Width + 5, lblBlockListMiner.Location.Y);
                        });
                        pictureBoxBlockListFeeChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListFeeChart.Location = new Point(lblBlockListTotalFees.Location.X + lblBlockListTotalFees.Width + 5, lblBlockListTotalFees.Location.Y);
                        });
                        pictureBoxBlockListRewardChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListRewardChart.Location = new Point(lblBlockListReward.Location.X + lblBlockListReward.Width + 5, lblBlockListReward.Location.Y);
                        });
                        pictureBoxBlockListFeeRangeChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListFeeRangeChart.Location = new Point(lblBlockListBlockFeeRangeAndMedianFee.Location.X + lblBlockListBlockFeeRangeAndMedianFee.Width + 5, lblBlockListBlockFeeRangeAndMedianFee.Location.Y);
                        });
                        pictureBoxBlockListBlockSizeChart.Invoke((MethodInvoker)delegate
                        {
                            pictureBoxBlockListBlockSizeChart.Location = new Point(lblBlockListBlockSize.Location.X + lblBlockListBlockSize.Width + 5, lblBlockListBlockSize.Location.Y);
                        });
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
                btnViewBlockFromBlockList.Visible = anySelected;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBlockList_ItemSelectionChanged");
            }

        }
        #endregion
        #region chart icon clicks
        //---------------------- VIEW CHARTS --------------------------------------------------------------------------------
        private void PictureBoxBlockListDifficultyChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartDifficulty_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListDifficultyChart_Click");
            }
        }

        private void PictureBoxBlockListHashrateChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartHashrate_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListHashrateChart_Click");
            }
        }

        private void PictureBoxBlockListBlockSizeChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartBlockSize_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListBlockSizeChart_Click");
            }
        }

        private void PictureBoxBlockListPoolRanking_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartPoolsRanking_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListPoolRanking_Click");
            }
        }

        private void PictureBoxBlockListFeeChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartBlockFees_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListFeeChart_Click");
            }
        }

        private void PictureBoxBlockListRewardChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartReward_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListRewardChart_Click");
            }
        }

        private void PictureBoxBlockListFeeRangeChart_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartFeeRates_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListFeeRangeChart_Click");
            }
        }

        private void PictureBoxBlockListFeeChart2_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartBlockFees_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListFeeChart2_Click");
            }
        }

        private void PictureBoxBlockListFeeRangeChart2_Click(object sender, EventArgs e)
        {
            try
            {
                BtnChartFeeRates_Click(sender, e);
                BtnMenuCharts_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBlockListFeeRangeChart2_Click");
            }
        }
        #endregion
        #region disable/enable buttons
        private void DisableEnableBlockListButtons(string enableOrDisableBlockListButtons)
        {
            try
            {
                if (!dontDisableButtons)
                {
                    if (enableOrDisableBlockListButtons == "disable")
                    {
                        // get current state of buttons before disabling them
                        btnViewBlockFromBlockListWasEnabled = btnViewBlockFromBlockList.Enabled;
                        btnNewer15BlocksWasEnabled = btnNewer15Blocks.Enabled;
                        btnOlder15BlocksWasEnabled = btnOlder15Blocks.Enabled;
                        textBoxBlockHeightToStartListFromWasEnabled = textBoxBlockHeightToStartListFrom.Enabled;

                        //disable them all
                        btnViewBlockFromBlockList.Enabled = false;
                        btnNewer15Blocks.Enabled = false;
                        btnOlder15Blocks.Enabled = false;
                        textBoxBlockHeightToStartListFrom.Enabled = false;
                        btnMenu.Enabled = false;
                    }
                    else
                    {
                        // use previously saved states to reinstate buttons
                        btnViewBlockFromBlockList.Enabled = btnViewBlockFromBlockListWasEnabled;
                        btnNewer15Blocks.Enabled = btnNewer15BlocksWasEnabled;
                        btnOlder15Blocks.Enabled = btnOlder15BlocksWasEnabled;
                        textBoxBlockHeightToStartListFrom.Enabled = textBoxBlockHeightToStartListFromWasEnabled;
                        btnMenu.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableEnableBlockListButtons");
            }
        }
        #endregion
        #endregion

        #region ⚡XPUB SCREEN⚡
        #region user input & validation
        //-------------------- VALIDATE AND LOOK UP XPUB --------------------------------------------------------------------
        private void TextBoxSubmittedXpub_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    // Submit button was pressed
                    if (xpubValid)
                    {
                        LookupXpub();
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSubmittedXpub_KeyPress");
            }
        }

        private void TextBoxSubmittedXpub_TextChanged(object sender, EventArgs e)
        {
            xpubValid = false;
            panel26.Visible = false;
            lblXpubStatus.Visible = false;
            panel23.Visible = false;
            label123.Visible = false;
            lblSegwitUsedAddresses.Visible = false;
            lblSegwitSummary.Visible = false;
            label111.Visible = false;
            lblLegacyUsedAddresses.Visible = false;
            lblLegacySummary.Visible = false;
            label119.Visible = false;
            lblSegwitP2SHUsedAddresses.Visible = false;
            lblSegwitP2SHSummary.Visible = false;
            panel29.Visible = false;
            label133.Visible = false;
            lblXpubConfirmedReceived.Visible = false;
            label129.Visible = false;
            lblXpubConfirmedSpent.Visible = false;
            label121.Visible = false;
            lblXpubConfirmedUnspent.Visible = false;
            btnXpubAddressUp.Visible = false;
            btnXpubAddressesDown.Visible = false;
            listViewXpubAddresses.Visible = false;
            label135.Visible = false;
            lblP2SHSummary.Visible = false;
            lblP2SHUsedAddresses.Visible = false;
            label140.Visible = false;
            label141.Visible = false;
            btnViewAddressFromXpub.Visible = false;

            if (textBoxSubmittedXpub.Text == "")
            {
                lblValidXpubIndicator.Invoke((MethodInvoker)delegate
                {
                    lblValidXpubIndicator.Text = "";
                });
                return;
            }

            // validate the inputted xpub before proceeding
            try
            {
                string xpubString = textBoxSubmittedXpub.Text;
                BitcoinExtPubKey xpub = new BitcoinExtPubKey(xpubString, Network.Main);
                PubKey OnlyUsedToCheckIfXpubIsValid = xpub.GetPublicKey();
            }
            catch
            {
                xpubValid = false;
                lblValidXpubIndicator.Invoke((MethodInvoker)delegate
                {
                    lblValidXpubIndicator.ForeColor = Color.IndianRed;
                    lblValidXpubIndicator.Text = "✖️ invalid Xpub";
                });

                return;
            }
            xpubValid = true;
            lblValidXpubIndicator.Invoke((MethodInvoker)delegate
            {
                lblValidXpubIndicator.ForeColor = Color.OliveDrab;
                lblValidXpubIndicator.Text = "✔️ valid Xpub";
            });
            LookupXpub();
        }

        //-------------------- VALIDATE NODE URL ENTRY ---------------------------------------------------------------------------
        private void TextBoxMempoolURL_Enter(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxMempoolURLWatermarkTextDisplayed)
                {
                    textBoxXpubNodeURL.Text = "";
                    textBoxXpubNodeURL.ForeColor = Color.White;
                    isTextBoxMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxMempoolURL_Enter");
            }
        }

        private void TextBoxMempoolURL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxXpubNodeURL.Text))
                {
                    textBoxXpubNodeURL.Text = "e.g http://umbrel.local:3006/api/";
                    textBoxXpubNodeURL.ForeColor = Color.Gray;
                    isTextBoxMempoolURLWatermarkTextDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxMempoolURL_Leave");
            }
        }

        private void TextBoxMempoolURL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxMempoolURLWatermarkTextDisplayed)
                {
                    textBoxXpubNodeURL.ForeColor = Color.White;
                    isTextBoxMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxMempoolURL_TextChanged");
            }
        }

        private void TextBoxMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (isTextBoxMempoolURLWatermarkTextDisplayed)
                {
                    textBoxXpubNodeURL.Text = "";
                    textBoxXpubNodeURL.ForeColor = Color.White;
                    isTextBoxMempoolURLWatermarkTextDisplayed = false;
                }
                else
                {
                    previousXpubNodeStringToCompare = textBoxXpubNodeURL.Text;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxMempoolURL_KeyPress");
            }
        }

        private void TextBoxMempoolURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (previousXpubNodeStringToCompare != textBoxXpubNodeURL.Text)
                {
                    textBoxSubmittedXpub.Enabled = false;
                    lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                    label18.Text = "invalid / node offline";
                    textBoxSubmittedXpub.Text = "";
                    previousXpubNodeStringToCompare = textBoxXpubNodeURL.Text;
                    CheckNetworkStatus();
                    // CheckXpubNodeIsOnline();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxMempoolURL_KeyUp");
            }
        }

        //-------------------- DERIVATION PATHS ---------------------------------------------------------------------------
        private void NumberUpDownDerivationPathsToCheck_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (numberUpDownDerivationPathsToCheck.Value > 100)
                {
                    numberUpDownDerivationPathsToCheck.Value = 100;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "NumberUpDownDerivationPathsToCheck_Validating");
            }
        }

        private void NumberUpDownDerivationPathsToCheck_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SaveSettingsToBookmarksFile();
            }
            catch (Exception ex)
            {
                HandleException(ex, "numberUpDownDerivationPathsToCheck_ValueChanged");
            }
        }

        #endregion
        #region check node online
        //-------------------- CHECK NODE ONLINE -------------------------------------------------------
        private async void CheckXpubNodeIsOnline()
        {
            using var client = new HttpClient();
            try
            {
                Ping pingSender = new Ping();
                string pingAddress = "";


                if (textBoxXpubNodeURL.Text != "")
                {
                    // get the contents of the textbox
                    string url = textBoxXpubNodeURL.Text;

                    // create a regex pattern to match URLs
                    string pattern = @"^(http|https):\/\/.*\/api\/$";

                    // create a regex object
                    Regex regex = new Regex(pattern);

                    // use the regex object to match the contents of the textbox
                    if (regex.IsMatch(url)) // (at least partially) valid url
                    {
                        try
                        {
                            xpubNodeURL = textBoxXpubNodeURL.Text;
                            // get the hostname from the URL
                            // parse the URL to extract the hostname
                            Uri uri = new Uri(xpubNodeURL);
                            string hostname = uri.Host;

                            // resolve the hostname to an IP address
                            IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                            IPAddress ipAddress = hostEntry.AddressList[0];
                            pingAddress = ipAddress.ToString();
                        }
                        catch
                        {
                            lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                            lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                            //label18.ForeColor = Color.IndianRed;
                            //lblSettingsXpubNodeStatus.ForeColor = Color.IndianRed;
                            Uri uri = new Uri(xpubNodeURL);
                            string hostname = uri.Host;
                            label18.Text = hostname;
                            lblSettingsXpubNodeStatus.Text = hostname;
                            return;
                        }
                    }
                    else
                    {
                        lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        //label18.ForeColor = Color.IndianRed;
                        //lblSettingsXpubNodeStatus.ForeColor = Color.IndianRed;
                        Uri uri = new Uri(xpubNodeURL);
                        string hostname = uri.Host;
                        label18.Text = hostname;
                        lblSettingsXpubNodeStatus.Text = hostname;
                        return;
                    }
                }

                if (textBoxXpubNodeURL.Text != "")
                {
                    PingReply reply = await pingSender.SendPingAsync(pingAddress);
                    if (reply.Status == IPStatus.Success)
                    {
                        Uri uri = new Uri(xpubNodeURL);
                        string hostname = uri.Host;
                        lblXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                        lblSettingsXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                        headerNetworkStatusLight.ForeColor = Color.OliveDrab;
                        //label18.ForeColor = Color.OliveDrab;
                        //lblSettingsXpubNodeStatus.ForeColor = Color.OliveDrab;
                        label18.Text = hostname;
                        //label18.Text = "node online";
                        lblSettingsXpubNodeStatus.Text = hostname;
                        // write the node url to the bookmarks file for auto retrieval next time (only if it's different to the one that might already be there)
                        DateTime today = DateTime.Today;
                        string bookmarkData;
                        string keyCheck = "21m";
                        bookmarkData = textBoxXpubNodeURL.Text;
                        textBoxSettingsXpubMempoolURL.Text = bookmarkData; // write it back to the settings screen too
                        var newBookmark = new Bookmark { DateAdded = today, Type = "xpubnode", Data = bookmarkData, Note = "", Encrypted = false, KeyCheck = keyCheck };
                        if (!xpubNodeURLAlreadySavedInFile)
                        {

                            // Read the existing bookmarks from the JSON file
                            var bookmarks = ReadBookmarksFromJsonFile();

                            // Add the new bookmark to the list
                            bookmarks.Add(newBookmark);

                            // Write the updated list of bookmarks back to the JSON file
                            WriteBookmarksToJsonFile(bookmarks);
                            xpubNodeURLAlreadySavedInFile = true;
                            xpubNodeURLInFile = bookmarkData;
                        }
                        else
                        {
                            if (xpubNodeURLInFile != textBoxXpubNodeURL.Text)
                            {
                                //delete the currently saved node url
                                DeleteBookmarkFromJsonFile(xpubNodeURLInFile);
                                // Read the existing bookmarks from the JSON file
                                var bookmarks = ReadBookmarksFromJsonFile();
                                // Add the new bookmark to the list
                                bookmarks.Add(newBookmark);
                                // Write the updated list of bookmarks back to the JSON file
                                WriteBookmarksToJsonFile(bookmarks);
                                xpubNodeURLAlreadySavedInFile = true;
                                xpubNodeURLInFile = bookmarkData;
                            }
                        }
                        textBoxSubmittedXpub.Enabled = true;
                    }
                    else
                    {
                        // API is not online
                        lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        label18.Text = "invalid / node offline";
                        lblSettingsXpubNodeStatus.Text = "invalid / node offline";
                    }
                }
            }
            catch (HttpRequestException)
            {
                // API is not online
                lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                label18.Text = "invalid / node offline";
                lblSettingsXpubNodeStatus.Text = "invalid / node offline";
            }
        }
        #endregion
        #region set up xpub screen
        //-----DERIVE ADDRESSES FOR DIFFERENT ADDRESS TYPES, SCAN FOR TX'S AND OUTPUT TO LIST -------------------------------------
        private async void LookupXpub()
        {
            try
            {
                textBoxSubmittedXpub.Enabled = false;
                textBoxXpubNodeURL.Enabled = false;
                // NOT SUPPORTED var newAddress = pubkey.Derive(0).Derive(0).PubKey.GetAddress(ScriptPubKeyType.TaprootBIP86, Network.Main); //Taproot P2SH

                int MaxNumberOfConsecutiveUnusedAddresses = Convert.ToInt32(numericUpDownMaxNumberOfConsecutiveUnusedAddresses.Value - 1);
                int segwitAddressesWithNonZeroBalance = 0;
                int legacyAddressesWithNonZeroBalance = 0;
                int segwitP2SHAddressesWithNonZeroBalance = 0;
                int P2SHAddressesWithNonZeroBalance = 0;
                int consecutiveUnusedAddressesForType = 0;
                int totalUnusedAddresses = 0;
                int usedSegwitAddresses = 0;
                int usedLegacyAddresses = 0;
                int usedSegwitP2SHAddresses = 0;
                int usedP2SHAddresses = 0;
                int numberOfAddressesChecked = 0;
                double segwitAddressesConfirmedUnspentBalance = 0;
                double legacyAddressesConfirmedUnspentBalance = 0;
                double segwitP2SHAddressesConfirmedUnspentBalance = 0;
                double P2SHAddressesConfirmedUnspentBalance = 0;
                double segwitTotalConfirmedReceived = 0;
                double legacyTotalConfirmedReceived = 0;
                double segwitP2SHTotalConfirmedReceived = 0;
                double P2SHTotalConfirmedReceived = 0;
                double segwitTotalConfirmedSpent = 0;
                double legacyTotalConfirmedSpent = 0;
                double segwitP2SHTotalConfirmedSpent = 0;
                double P2SHTotalConfirmedSpent = 0;
                double xpubTotalConfirmedReceived = 0;
                double xpubTotalConfirmedSpent = 0;
                double xpubTotalConfirmedUnspent = 0;

                numberOfAddressesChecked = 0;
                int checkingAddressCount = 1;
                List<NBitcoin.BitcoinAddress> segwitAddresses = new List<NBitcoin.BitcoinAddress>();
                List<NBitcoin.BitcoinAddress> legacyAddresses = new List<NBitcoin.BitcoinAddress>();
                List<NBitcoin.BitcoinAddress> segwitP2SHAddresses = new List<NBitcoin.BitcoinAddress>();
                List<NBitcoin.BitcoinAddress> P2SHAddresses = new List<NBitcoin.BitcoinAddress>();

                int DerivationPath = 0;
                int NumberOfDerivationPathsToCheck = Convert.ToInt32(numberUpDownDerivationPathsToCheck.Value);

                progressBarCheckEachAddressType.Maximum = MaxNumberOfConsecutiveUnusedAddresses;
                progressBarCheckAllAddressTypes.Maximum = MaxNumberOfConsecutiveUnusedAddresses * 4 * NumberOfDerivationPathsToCheck;

                progressBarCheckAllAddressTypes.Visible = true;
                progressBarCheckEachAddressType.Visible = true;

                panel26.Visible = true;
                lblXpubStatus.Visible = true;
                panel23.Visible = true;
                label123.Visible = true;
                lblSegwitUsedAddresses.Visible = true;
                lblSegwitSummary.Visible = true;
                label111.Visible = true;
                lblLegacyUsedAddresses.Visible = true;
                lblLegacySummary.Visible = true;
                label119.Visible = true;
                lblSegwitP2SHUsedAddresses.Visible = true;
                lblSegwitP2SHSummary.Visible = true;
                panel29.Visible = true;
                label133.Visible = true;
                lblXpubConfirmedReceived.Visible = true;
                label129.Visible = true;
                lblXpubConfirmedSpent.Visible = true;
                label121.Visible = true;
                lblXpubConfirmedUnspent.Visible = true;
                listViewXpubAddresses.Visible = true;
                lblCheckAllAddressTypesCount.Visible = true;
                lblCheckEachAddressTypeCount.Visible = true;
                label135.Visible = true;
                lblP2SHSummary.Visible = true;
                lblP2SHUsedAddresses.Visible = true;
                label140.Visible = true;
                label141.Visible = true;
                btnViewAddressFromXpub.Visible = true;

                string submittedXpub = Convert.ToString(textBoxSubmittedXpub.Text);
                #region set up the listview
                //LIST VIEW
                listViewXpubAddresses.Invoke((MethodInvoker)delegate
                {
                    listViewXpubAddresses.Items.Clear(); // remove any data that may be there already
                });
                listViewXpubAddresses.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewXpubAddresses, new object[] { true });

                // Check if the column headers already
                if (listViewXpubAddresses.Columns.Count == 0)
                {
                    listViewXpubAddresses.Invoke((MethodInvoker)delegate
                    {
                        listViewXpubAddresses.Columns.Add(" Address", 130);
                    });
                }
                if (listViewXpubAddresses.Columns.Count == 1)
                {
                    listViewXpubAddresses.Invoke((MethodInvoker)delegate
                    {
                        listViewXpubAddresses.Columns.Add("TX's", 35);
                    });
                }
                if (listViewXpubAddresses.Columns.Count == 2)
                {
                    listViewXpubAddresses.Invoke((MethodInvoker)delegate
                    {
                        listViewXpubAddresses.Columns.Add("Received", 100);
                    });
                }
                if (listViewXpubAddresses.Columns.Count == 3)
                {
                    listViewXpubAddresses.Invoke((MethodInvoker)delegate
                    {
                        listViewXpubAddresses.Columns.Add("Spent", 100);
                    });
                }
                if (listViewXpubAddresses.Columns.Count == 4)
                {
                    listViewXpubAddresses.Invoke((MethodInvoker)delegate
                    {
                        listViewXpubAddresses.Columns.Add("Unspent", 100);
                    });
                }
                #endregion
                #region Taproot - not yet implemented :(
                #endregion
                #region P2WPKH (Bech32 SegWit)
                while (DerivationPath != NumberOfDerivationPathsToCheck)
                {
                    for (uint i = 0; i < 500; i++)
                    {
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2WPKH Bech32 addresses";
                        });
                        var pubkey = ExtPubKey.Parse(submittedXpub, Network.Main);
                        uint index = i; // increment the index for each iteration
                        var BitcoinAddress = pubkey.Derive(Convert.ToUInt32(DerivationPath)).Derive(index).PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main); //Segwit 
                        segwitAddresses.Add(BitcoinAddress);
                    }

                    label140.Text = "derivation path " + DerivationPath;

                    // query the balance for each address
                    foreach (NBitcoin.BitcoinAddress address in segwitAddresses) // (we break when we run out of used addresses)
                    {
                        string truncatedAddressForDisplay = address.ToString().Substring(0, 10) + "...";
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2WPKH Bech32 addresses\r\nChecking address " + checkingAddressCount + " (" + truncatedAddressForDisplay + ")\r\nConsecutive unused addresses: " + consecutiveUnusedAddressesForType;
                        });
                        var request = "address/" + address;
                        var RequestURL = textBoxXpubNodeURL.Text + request;
                        var client = new HttpClient();
                        var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
                        if (!response.IsSuccessStatusCode)
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.Red;
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = "Disconnected/error";
                            });
                            lblErrorMessage.Invoke((MethodInvoker)delegate
                            {
                                lblErrorMessage.Text = "Node offline/disconnected: ";
                            });
                            return;
                        }
                        var jsonData = await response.Content.ReadAsStringAsync();
                        var addressData = JObject.Parse(jsonData);

                        // transactions for the address
                        string lastSeenTxId = "";
                        decimal TotalInForAllTXOnThisAddress = 0;
                        decimal TotalOutForAllTXOnThisAddress = 0;
                        int totalTXForAddress = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                        int txProcessedForThisAddress = 0;

                        while (txProcessedForThisAddress != totalTXForAddress)
                        {
                            _transactionsForXpubAddressService = new TransactionsForXpubAddressService(textBoxXpubNodeURL.Text);
                            var transactionsJson = await _transactionsForXpubAddressService.GetTransactionsForXpubAddressAsync(Convert.ToString(address), "chain", lastSeenTxId);
                            var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
                            List<string> txIds = transactions.Select(t => t.Txid).ToList();
                            foreach (AddressTransactions transaction in transactions)
                            {
                                decimal balanceChangeVin = 0; // will hold net result of inputs to this address
                                decimal balanceChangeVout = 0; // will hold net result of outputs to this address    
                                balanceChangeVin = (decimal)transaction.Vout // value of all outputs where address is the provided address
                                    .Where(v => v.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Value);
                                balanceChangeVout = (decimal)transaction.Vin
                                    .Where(v => v.Prevout != null && v.Prevout.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Prevout.Value);
                                TotalInForAllTXOnThisAddress += balanceChangeVin;
                                TotalOutForAllTXOnThisAddress += balanceChangeVout;
                                txProcessedForThisAddress++;
                            }
                            if (transactions.Last().Status.Confirmed == "true") // there might be more transactions to get. 
                            {
                                lastSeenTxId = transactions.Last().Txid; // so we can carry on the next api call where we left off
                            }
                            else
                            {
                                lastSeenTxId = "";
                            }
                        }

                        string ConfirmedTransactionCount = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                        string ConfirmedReceived = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalInForAllTXOnThisAddress)).ToString("0.00000000"));
                        string ConfirmedSpent = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalOutForAllTXOnThisAddress)).ToString("0.00000000"));
                        var confirmedReceivedForCalc = Convert.ToDouble(TotalInForAllTXOnThisAddress);
                        var confirmedSpentForCalc = Convert.ToDouble(TotalOutForAllTXOnThisAddress);
                        var confirmedUnspentResult = confirmedReceivedForCalc - confirmedSpentForCalc;
                        string ConfirmedUnspent = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspentResult)).ToString("0.00000000");

                        ListViewItem item = new ListViewItem(Convert.ToString(address)); // create new row
                        item.SubItems.Add(ConfirmedTransactionCount.ToString());
                        item.SubItems.Add(ConfirmedReceived.ToString());
                        item.SubItems.Add(ConfirmedSpent.ToString());
                        item.SubItems.Add(ConfirmedUnspent.ToString());
                        listViewXpubAddresses.Invoke((MethodInvoker)delegate
                        {
                            listViewXpubAddresses.Items.Add(item); // add row
                            numberOfAddressesChecked++;
                        });
                        if (listViewXpubAddresses.Items.Count > 23)
                        {
                            btnXpubAddressUp.Visible = true;
                            btnXpubAddressesDown.Visible = true;
                        }
                        else
                        {
                            btnXpubAddressUp.Visible = false;
                            btnXpubAddressesDown.Visible = false;
                        }

                        // Get the height of each item to set height of whole listview
                        int rowHeight = listViewXpubAddresses.Margin.Vertical + listViewXpubAddresses.Padding.Vertical + listViewXpubAddresses.GetItemRect(0).Height;
                        int itemCount = listViewXpubAddresses.Items.Count; // Get the number of items in the ListBox
                        int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                        listViewXpubAddresses.Height = listBoxHeight; // Set the height of the ListBox
                        panelXpubContainer.VerticalScroll.Minimum = 0;

                        string segwitTotalConfirmedReceivedDisplay = "";
                        string segwitTotalConfirmedSpentDisplay = "";
                        string segwitAddressesConfirmedUnspentBalanceDisplay = "";

                        if (confirmedReceivedForCalc == 0)
                        {
                            consecutiveUnusedAddressesForType++; // unused addresses for this type of address
                            totalUnusedAddresses++; // overall count of unused addresses

                            // progress bar for this address type
                            if (consecutiveUnusedAddressesForType < progressBarCheckEachAddressType.Maximum)
                            {
                                progressBarCheckEachAddressType.Value = consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckEachAddressType.Value = progressBarCheckEachAddressType.Maximum;
                            }
                            lblCheckEachAddressTypeCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckEachAddressTypeCount.Text = consecutiveUnusedAddressesForType.ToString() + "/" + (MaxNumberOfConsecutiveUnusedAddresses + 1).ToString();
                            });
                            // progress bar for all address types
                            if (totalUnusedAddresses < progressBarCheckAllAddressTypes.Maximum)
                            {
                                progressBarCheckAllAddressTypes.Value = (DerivationPath * MaxNumberOfConsecutiveUnusedAddresses) + consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckAllAddressTypes.Value = progressBarCheckAllAddressTypes.Maximum;
                            }
                            lblCheckAllAddressTypesCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckAllAddressTypesCount.Text = totalUnusedAddresses.ToString() + "/" + ((MaxNumberOfConsecutiveUnusedAddresses + 1) * 4 * NumberOfDerivationPathsToCheck).ToString();
                            });
                            // assume there are no more used addresses at this point
                            if (consecutiveUnusedAddressesForType > MaxNumberOfConsecutiveUnusedAddresses)
                            {
                                break;
                            }
                        }
                        else
                        {
                            usedSegwitAddresses++;
                            consecutiveUnusedAddressesForType = 0;  //
                            totalUnusedAddresses = DerivationPath * MaxNumberOfConsecutiveUnusedAddresses;  //
                        }

                        if (confirmedReceivedForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            segwitTotalConfirmedReceived += confirmedReceivedForCalc;
                            xpubTotalConfirmedReceived += confirmedReceivedForCalc;
                        }

                        if (confirmedSpentForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            segwitTotalConfirmedSpent += confirmedSpentForCalc;
                            xpubTotalConfirmedSpent += confirmedSpentForCalc;
                        }

                        if (confirmedUnspentResult > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            xpubTotalConfirmedUnspent += confirmedUnspentResult;
                            segwitAddressesWithNonZeroBalance++;
                            segwitAddressesConfirmedUnspentBalance += confirmedUnspentResult;

                        }
                        checkingAddressCount++;
                        lblSegwitUsedAddresses.Invoke((MethodInvoker)delegate
                        {
                            lblSegwitUsedAddresses.Text = Convert.ToString(usedSegwitAddresses) + " used";
                        });
                        // format values before displaying them in the summary
                        if (segwitTotalConfirmedReceived > 0)
                        {
                            segwitTotalConfirmedReceivedDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitTotalConfirmedReceived)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitTotalConfirmedReceivedDisplay = "0";
                        }

                        if (segwitTotalConfirmedSpent > 0)
                        {
                            segwitTotalConfirmedSpentDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitTotalConfirmedSpent)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitTotalConfirmedSpentDisplay = "0";
                        }

                        if (segwitAddressesConfirmedUnspentBalance > 0)
                        {
                            segwitAddressesConfirmedUnspentBalanceDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitAddressesConfirmedUnspentBalance)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitAddressesConfirmedUnspentBalanceDisplay = "0";
                        }
                        lblSegwitSummary.Invoke((MethodInvoker)delegate
                        {
                            lblSegwitSummary.Text = segwitTotalConfirmedReceivedDisplay + "," + segwitTotalConfirmedSpentDisplay + "," + segwitAddressesConfirmedUnspentBalanceDisplay;
                        });
                    }

                    progressBarCheckEachAddressType.Value = 0;
                    consecutiveUnusedAddressesForType = 0;
                    checkingAddressCount = 1;
                    DerivationPath++;
                    segwitAddresses.Clear();

                }
                DerivationPath = 0;
                #endregion
                #region P2PKH legacy
                while (DerivationPath != NumberOfDerivationPathsToCheck)
                {
                    for (uint i = 0; i < 500; i++)
                    {
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2PKH legacy addresses";
                        });
                        var pubkey = ExtPubKey.Parse(submittedXpub, Network.Main);
                        uint index = i; // increment the index for each iteration
                        var BitcoinAddress = pubkey.Derive(Convert.ToUInt32(DerivationPath)).Derive(index).PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main); //Legacy 
                        legacyAddresses.Add(BitcoinAddress);
                    }

                    label140.Text = "derivation path " + DerivationPath;

                    // query the balance for each address
                    foreach (NBitcoin.BitcoinAddress address in legacyAddresses) // (we break when we run out of addresses with a balance)
                    {
                        string truncatedAddressForDisplay = address.ToString().Substring(0, 10) + "...";
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2PKH legacy addresses\r\nChecking address " + checkingAddressCount + " (" + truncatedAddressForDisplay + ")\r\nConsecutive unused addresses: " + consecutiveUnusedAddressesForType;
                        });
                        var request = "address/" + address;
                        var RequestURL = textBoxXpubNodeURL.Text + request;
                        var client = new HttpClient();
                        var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
                        if (!response.IsSuccessStatusCode)
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.Red;
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = "Disconnected/error";
                            });
                            lblErrorMessage.Invoke((MethodInvoker)delegate
                            {
                                lblErrorMessage.Text = "Node offline/disconnected: ";
                            });
                            return;
                        }
                        var jsonData = await response.Content.ReadAsStringAsync();
                        var addressData = JObject.Parse(jsonData);

                        // transactions for the address
                        string lastSeenTxId = "";
                        decimal TotalInForAllTXOnThisAddress = 0;
                        decimal TotalOutForAllTXOnThisAddress = 0;
                        int totalTXForAddress = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                        int txProcessedForThisAddress = 0;

                        while (txProcessedForThisAddress != totalTXForAddress)
                        {
                            _transactionsForXpubAddressService = new TransactionsForXpubAddressService(textBoxXpubNodeURL.Text);
                            var transactionsJson = await _transactionsForXpubAddressService.GetTransactionsForXpubAddressAsync(Convert.ToString(address), "chain", lastSeenTxId);
                            var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
                            List<string> txIds = transactions.Select(t => t.Txid).ToList();
                            foreach (AddressTransactions transaction in transactions)
                            {
                                decimal balanceChangeVin = 0; // will hold net result of inputs to this address
                                decimal balanceChangeVout = 0; // will hold net result of outputs to this address    
                                balanceChangeVin = (decimal)transaction.Vout // value of all outputs where address is the provided address
                                    .Where(v => v.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Value);
                                balanceChangeVout = (decimal)transaction.Vin
                                    .Where(v => v.Prevout != null && v.Prevout.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Prevout.Value);
                                TotalInForAllTXOnThisAddress += balanceChangeVin;
                                TotalOutForAllTXOnThisAddress += balanceChangeVout;
                                txProcessedForThisAddress++;
                            }
                            if (transactions.Last().Status.Confirmed == "true") // there might be more transactions to get. 
                            {
                                lastSeenTxId = transactions.Last().Txid; // so we can carry on the next api call where we left off
                            }
                            else
                            {
                                lastSeenTxId = "";
                            }
                        }

                        string ConfirmedTransactionCount = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                        string ConfirmedReceived = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalInForAllTXOnThisAddress)).ToString("0.00000000"));
                        string ConfirmedSpent = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalOutForAllTXOnThisAddress)).ToString("0.00000000"));
                        var confirmedReceivedForCalc = Convert.ToDouble(TotalInForAllTXOnThisAddress);
                        var confirmedSpentForCalc = Convert.ToDouble(TotalOutForAllTXOnThisAddress);
                        var confirmedUnspentResult = confirmedReceivedForCalc - confirmedSpentForCalc;
                        string ConfirmedUnspent = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspentResult)).ToString("0.00000000");

                        ListViewItem item = new ListViewItem(Convert.ToString(address)); // create new row
                        item.SubItems.Add(ConfirmedTransactionCount.ToString());
                        item.SubItems.Add(ConfirmedReceived.ToString());
                        item.SubItems.Add(ConfirmedSpent.ToString());
                        item.SubItems.Add(ConfirmedUnspent.ToString());
                        listViewXpubAddresses.Invoke((MethodInvoker)delegate
                        {
                            listViewXpubAddresses.Items.Add(item); // add row
                            numberOfAddressesChecked++;
                        });
                        if (listViewXpubAddresses.Items.Count > 23)
                        {
                            btnXpubAddressUp.Visible = true;
                            btnXpubAddressesDown.Visible = true;
                        }
                        else
                        {
                            btnXpubAddressUp.Visible = false;
                            btnXpubAddressesDown.Visible = false;
                        }

                        // Get the height of each item to set height of whole listview
                        int rowHeight = listViewXpubAddresses.Margin.Vertical + listViewXpubAddresses.Padding.Vertical + listViewXpubAddresses.GetItemRect(0).Height;
                        int itemCount = listViewXpubAddresses.Items.Count; // Get the number of items in the ListBox
                        int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                        listViewXpubAddresses.Height = listBoxHeight; // Set the height of the ListBox
                        panelXpubContainer.VerticalScroll.Minimum = 0;

                        string legacyTotalConfirmedReceivedDisplay = "";
                        string legacyTotalConfirmedSpentDisplay = "";
                        string legacyAddressesConfirmedUnspentBalanceDisplay = "";

                        if (confirmedReceivedForCalc == 0)
                        {
                            consecutiveUnusedAddressesForType++; // unused addresses for this type of address
                            totalUnusedAddresses++; // overall count of unused addresses

                            // progress bar for this address type
                            if (consecutiveUnusedAddressesForType < progressBarCheckEachAddressType.Maximum)
                            {
                                progressBarCheckEachAddressType.Value = consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckEachAddressType.Value = progressBarCheckEachAddressType.Maximum;
                            }
                            lblCheckEachAddressTypeCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckEachAddressTypeCount.Text = consecutiveUnusedAddressesForType.ToString() + "/" + (MaxNumberOfConsecutiveUnusedAddresses + 1).ToString();
                            });
                            // progress bar for all address types
                            if (totalUnusedAddresses < progressBarCheckAllAddressTypes.Maximum)
                            {
                                progressBarCheckAllAddressTypes.Value = ((NumberOfDerivationPathsToCheck + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses) + consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckAllAddressTypes.Value = progressBarCheckAllAddressTypes.Maximum;
                            }
                            lblCheckAllAddressTypesCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckAllAddressTypesCount.Text = totalUnusedAddresses.ToString() + "/" + ((MaxNumberOfConsecutiveUnusedAddresses + 1) * 4 * NumberOfDerivationPathsToCheck).ToString();
                            });

                            // assume there are no more used addresses at this point
                            if (consecutiveUnusedAddressesForType > MaxNumberOfConsecutiveUnusedAddresses)
                            {
                                break;
                            }
                        }
                        else
                        {
                            usedLegacyAddresses++;
                            consecutiveUnusedAddressesForType = 0;  //
                            totalUnusedAddresses = (NumberOfDerivationPathsToCheck + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses;  // this is the second address type, so reset to account for that, rather than 0
                        }

                        if (confirmedReceivedForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            legacyTotalConfirmedReceived += confirmedReceivedForCalc;
                            xpubTotalConfirmedReceived += confirmedReceivedForCalc;
                        }

                        if (confirmedSpentForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            legacyTotalConfirmedSpent += confirmedSpentForCalc;
                            xpubTotalConfirmedSpent += confirmedSpentForCalc;
                        }

                        if (confirmedUnspentResult > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            xpubTotalConfirmedUnspent += confirmedUnspentResult;
                            legacyAddressesWithNonZeroBalance++;
                            legacyAddressesConfirmedUnspentBalance += confirmedUnspentResult;

                        }
                        checkingAddressCount++;
                        lblLegacyUsedAddresses.Invoke((MethodInvoker)delegate
                        {
                            lblLegacyUsedAddresses.Text = Convert.ToString(usedLegacyAddresses) + " used";
                        });
                        // format values before displaying them in the summary
                        if (legacyTotalConfirmedReceived > 0)
                        {
                            legacyTotalConfirmedReceivedDisplay = ConvertSatsToBitcoin(Convert.ToString(legacyTotalConfirmedReceived)).ToString("0.00000000");
                        }
                        else
                        {
                            legacyTotalConfirmedReceivedDisplay = "0";
                        }

                        if (legacyTotalConfirmedSpent > 0)
                        {
                            legacyTotalConfirmedSpentDisplay = ConvertSatsToBitcoin(Convert.ToString(legacyTotalConfirmedSpent)).ToString("0.00000000");
                        }
                        else
                        {
                            legacyTotalConfirmedSpentDisplay = "0";
                        }

                        if (legacyAddressesConfirmedUnspentBalance > 0)
                        {
                            legacyAddressesConfirmedUnspentBalanceDisplay = ConvertSatsToBitcoin(Convert.ToString(legacyAddressesConfirmedUnspentBalance)).ToString("0.00000000");
                        }
                        else
                        {
                            legacyAddressesConfirmedUnspentBalanceDisplay = "0";
                        }
                        lblLegacySummary.Invoke((MethodInvoker)delegate
                        {
                            lblLegacySummary.Text = legacyTotalConfirmedReceivedDisplay + "," + legacyTotalConfirmedSpentDisplay + "," + legacyAddressesConfirmedUnspentBalanceDisplay;
                        });
                    }

                    progressBarCheckEachAddressType.Value = 0;
                    consecutiveUnusedAddressesForType = 0;
                    checkingAddressCount = 1;
                    DerivationPath++;
                    legacyAddresses.Clear();
                }
                DerivationPath = 0;
                #endregion
                #region P2SH-P2WPKH
                while (DerivationPath != NumberOfDerivationPathsToCheck)
                {
                    for (uint i = 0; i < 500; i++)
                    {
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2SH-P2WPKH addresses";
                        });
                        var pubkey = ExtPubKey.Parse(submittedXpub, Network.Main);
                        uint index = i; // increment the index for each iteration
                        var BitcoinAddress = pubkey.Derive(Convert.ToUInt32(DerivationPath)).Derive(index).PubKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main); //Segwit P2SH
                        segwitP2SHAddresses.Add(BitcoinAddress);
                    }

                    label140.Text = "derivation path " + DerivationPath;

                    // query the balance for each address
                    foreach (NBitcoin.BitcoinAddress address in segwitP2SHAddresses) // (we break when we run out of addresses with a balance)
                    {
                        string truncatedAddressForDisplay = address.ToString().Substring(0, 10) + "...";
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2SH-P2WPKH addresses\r\nChecking address " + checkingAddressCount + " (" + truncatedAddressForDisplay + ")\r\nConsecutive unused addresses: " + consecutiveUnusedAddressesForType;
                        });
                        var request = "address/" + address;
                        var RequestURL = textBoxXpubNodeURL.Text + request;
                        var client = new HttpClient();
                        var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
                        if (!response.IsSuccessStatusCode)
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.Red;
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = "Disconnected/error";
                            });
                            lblErrorMessage.Invoke((MethodInvoker)delegate
                            {
                                lblErrorMessage.Text = "Node offline/disconnected: ";
                            });
                            return;
                        }
                        var jsonData = await response.Content.ReadAsStringAsync();
                        var addressData = JObject.Parse(jsonData);

                        // transactions for the address
                        string lastSeenTxId = "";
                        decimal TotalInForAllTXOnThisAddress = 0;
                        decimal TotalOutForAllTXOnThisAddress = 0;
                        int totalTXForAddress = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                        int txProcessedForThisAddress = 0;

                        while (txProcessedForThisAddress != totalTXForAddress)
                        {
                            _transactionsForXpubAddressService = new TransactionsForXpubAddressService(textBoxXpubNodeURL.Text);
                            var transactionsJson = await _transactionsForXpubAddressService.GetTransactionsForXpubAddressAsync(Convert.ToString(address), "chain", lastSeenTxId);
                            var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
                            List<string> txIds = transactions.Select(t => t.Txid).ToList();
                            foreach (AddressTransactions transaction in transactions)
                            {
                                decimal balanceChangeVin = 0; // will hold net result of inputs to this address
                                decimal balanceChangeVout = 0; // will hold net result of outputs to this address    
                                balanceChangeVout = (decimal)transaction.Vout // value of all outputs where address is the provided address
                                    .Where(v => v.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Value);
                                balanceChangeVin = (decimal)transaction.Vin
                                    .Where(v => v.Prevout != null && v.Prevout.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Prevout.Value);
                                TotalInForAllTXOnThisAddress += balanceChangeVin;
                                TotalOutForAllTXOnThisAddress += balanceChangeVout;
                                txProcessedForThisAddress++;
                            }
                            if (transactions.Last().Status.Confirmed == "true") // there might be more transactions to get. 
                            {
                                lastSeenTxId = transactions.Last().Txid; // so we can carry on the next api call where we left off
                            }
                            else
                            {
                                lastSeenTxId = "";
                            }
                        }

                        string ConfirmedTransactionCount = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                        string ConfirmedReceived = Convert.ToString(TotalInForAllTXOnThisAddress.ToString("0.00000000"));
                        string ConfirmedSpent = Convert.ToString(TotalOutForAllTXOnThisAddress.ToString("0.00000000"));

                        var confirmedReceivedForCalc = Convert.ToDouble(TotalInForAllTXOnThisAddress);
                        var confirmedSpentForCalc = Convert.ToDouble(TotalOutForAllTXOnThisAddress);
                        var confirmedUnspentResult = confirmedReceivedForCalc - confirmedSpentForCalc;

                        string ConfirmedUnspent = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspentResult)).ToString("0.00000000");

                        ListViewItem item = new ListViewItem(Convert.ToString(address)); // create new row
                        item.SubItems.Add(ConfirmedTransactionCount.ToString());
                        item.SubItems.Add(ConvertSatsToBitcoin(ConfirmedReceived.ToString()).ToString("0.00000000"));
                        item.SubItems.Add(ConvertSatsToBitcoin(ConfirmedSpent.ToString()).ToString("0.00000000"));
                        item.SubItems.Add(ConfirmedUnspent.ToString());
                        listViewXpubAddresses.Invoke((MethodInvoker)delegate
                        {
                            listViewXpubAddresses.Items.Add(item); // add row
                            numberOfAddressesChecked++;
                        });
                        if (listViewXpubAddresses.Items.Count > 23)
                        {
                            btnXpubAddressUp.Visible = true;
                            btnXpubAddressesDown.Visible = true;
                        }
                        else
                        {
                            btnXpubAddressUp.Visible = false;
                            btnXpubAddressesDown.Visible = false;
                        }

                        // Get the height of each item to set height of whole listview
                        int rowHeight = listViewXpubAddresses.Margin.Vertical + listViewXpubAddresses.Padding.Vertical + listViewXpubAddresses.GetItemRect(0).Height;
                        int itemCount = listViewXpubAddresses.Items.Count; // Get the number of items in the ListBox
                        int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                        listViewXpubAddresses.Height = listBoxHeight; // Set the height of the ListBox
                        panelXpubContainer.VerticalScroll.Minimum = 0;

                        string segwitP2SHTotalConfirmedReceivedDisplay = "";
                        string segwitP2SHTotalConfirmedSpentDisplay = "";
                        string segwitP2SHAddressesConfirmedUnspentBalanceDisplay = "";

                        if (confirmedReceivedForCalc == 0)
                        {
                            consecutiveUnusedAddressesForType++; // unused addresses for this type of address
                            totalUnusedAddresses++; // overall count of unused addresses

                            // progress bar for this address type
                            if (consecutiveUnusedAddressesForType < progressBarCheckEachAddressType.Maximum)
                            {
                                progressBarCheckEachAddressType.Value = consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckEachAddressType.Value = progressBarCheckEachAddressType.Maximum;
                            }
                            lblCheckEachAddressTypeCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckEachAddressTypeCount.Text = consecutiveUnusedAddressesForType.ToString() + "/" + (MaxNumberOfConsecutiveUnusedAddresses + 1).ToString();
                            });
                            // progress bar for all address types
                            if (totalUnusedAddresses < progressBarCheckAllAddressTypes.Maximum)
                            {
                                progressBarCheckAllAddressTypes.Value = (((NumberOfDerivationPathsToCheck * 2) + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses) + consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckAllAddressTypes.Value = progressBarCheckAllAddressTypes.Maximum;
                            }
                            lblCheckAllAddressTypesCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckAllAddressTypesCount.Text = totalUnusedAddresses.ToString() + "/" + ((MaxNumberOfConsecutiveUnusedAddresses + 1) * 4 * NumberOfDerivationPathsToCheck).ToString();
                            });

                            // assume there are no more used addresses at this point
                            if (consecutiveUnusedAddressesForType > MaxNumberOfConsecutiveUnusedAddresses)
                            {
                                break;
                            }
                        }
                        else
                        {
                            usedSegwitP2SHAddresses++;
                            consecutiveUnusedAddressesForType = 0;  //
                            totalUnusedAddresses = ((NumberOfDerivationPathsToCheck * 2) + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses;  // this is the third address type, so reset to account for that, rather than 0
                        }

                        if (confirmedReceivedForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            segwitP2SHTotalConfirmedReceived += confirmedReceivedForCalc;
                            xpubTotalConfirmedReceived += confirmedReceivedForCalc;
                        }

                        if (confirmedSpentForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            segwitP2SHTotalConfirmedSpent += confirmedSpentForCalc;
                            xpubTotalConfirmedSpent += confirmedSpentForCalc;
                        }

                        if (confirmedUnspentResult > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            xpubTotalConfirmedUnspent += confirmedUnspentResult;
                            segwitP2SHAddressesWithNonZeroBalance++;
                            segwitP2SHAddressesConfirmedUnspentBalance += confirmedUnspentResult;

                        }
                        checkingAddressCount++;
                        lblSegwitP2SHUsedAddresses.Invoke((MethodInvoker)delegate
                        {
                            lblSegwitP2SHUsedAddresses.Text = Convert.ToString(usedSegwitP2SHAddresses) + " used";
                        });
                        // format values before displaying them in the summary
                        if (segwitP2SHTotalConfirmedReceived > 0)
                        {
                            segwitP2SHTotalConfirmedReceivedDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitP2SHTotalConfirmedReceived)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitP2SHTotalConfirmedReceivedDisplay = "0";
                        }

                        if (segwitP2SHTotalConfirmedSpent > 0)
                        {
                            segwitP2SHTotalConfirmedSpentDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitP2SHTotalConfirmedSpent)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitP2SHTotalConfirmedSpentDisplay = "0";
                        }

                        if (segwitP2SHAddressesConfirmedUnspentBalance > 0)
                        {
                            segwitP2SHAddressesConfirmedUnspentBalanceDisplay = ConvertSatsToBitcoin(Convert.ToString(segwitP2SHAddressesConfirmedUnspentBalance)).ToString("0.00000000");
                        }
                        else
                        {
                            segwitP2SHAddressesConfirmedUnspentBalanceDisplay = "0";
                        }
                        lblSegwitP2SHSummary.Invoke((MethodInvoker)delegate
                        {
                            lblSegwitP2SHSummary.Text = segwitP2SHTotalConfirmedReceivedDisplay + "," + segwitP2SHTotalConfirmedSpentDisplay + "," + segwitP2SHAddressesConfirmedUnspentBalanceDisplay;
                        });
                    }

                    progressBarCheckEachAddressType.Value = 0;
                    consecutiveUnusedAddressesForType = 0;
                    checkingAddressCount = 1;
                    DerivationPath++;
                    segwitP2SHAddresses.Clear();
                }
                DerivationPath = 0;
                #endregion
                #region P2SH
                while (DerivationPath != NumberOfDerivationPathsToCheck)
                {
                    for (uint i = 0; i < 500; i++)
                    {
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2SH addresses";
                        });
                        var pubkey = ExtPubKey.Parse(submittedXpub, Network.Main);
                        uint index = i; // increment the index for each iteration
                        var redeemScript = pubkey.Derive(Convert.ToUInt32(DerivationPath)).Derive(index).PubKey.ScriptPubKey;
                        var scriptPubKey = redeemScript.Hash.ScriptPubKey;
                        var BitcoinAddress = scriptPubKey.GetDestinationAddress(Network.Main);
                        P2SHAddresses.Add(BitcoinAddress);
                    }

                    label140.Text = "derivation path " + DerivationPath;

                    // query the balance for each address
                    foreach (NBitcoin.BitcoinAddress address in P2SHAddresses) // (we break when we run out of addresses with a balance)
                    {
                        string truncatedAddressForDisplay = address.ToString().Substring(0, 10) + "...";
                        lblXpubStatus.Invoke((MethodInvoker)delegate
                        {
                            lblXpubStatus.Text = "Deriving P2SH addresses\r\nChecking address " + checkingAddressCount + " (" + truncatedAddressForDisplay + ")\r\nConsecutive unused addresses: " + consecutiveUnusedAddressesForType;
                        });
                        var request = "address/" + address;
                        var RequestURL = textBoxXpubNodeURL.Text + request;
                        var client = new HttpClient();
                        var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
                        if (!response.IsSuccessStatusCode)
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.Red;
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = "Disconnected/error";
                            });
                            lblErrorMessage.Invoke((MethodInvoker)delegate
                            {
                                lblErrorMessage.Text = "Node offline/disconnected: ";
                            });
                            return;
                        }
                        var jsonData = await response.Content.ReadAsStringAsync();
                        var addressData = JObject.Parse(jsonData);

                        // transactions for the address
                        string lastSeenTxId = "";
                        decimal TotalInForAllTXOnThisAddress = 0;
                        decimal TotalOutForAllTXOnThisAddress = 0;
                        int totalTXForAddress = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                        int txProcessedForThisAddress = 0;

                        while (txProcessedForThisAddress != totalTXForAddress)
                        {
                            _transactionsForXpubAddressService = new TransactionsForXpubAddressService(textBoxXpubNodeURL.Text);
                            var transactionsJson = await _transactionsForXpubAddressService.GetTransactionsForXpubAddressAsync(Convert.ToString(address), "chain", lastSeenTxId);
                            var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
                            List<string> txIds = transactions.Select(t => t.Txid).ToList();
                            foreach (AddressTransactions transaction in transactions)
                            {
                                decimal balanceChangeVin = 0; // will hold net result of inputs to this address
                                decimal balanceChangeVout = 0; // will hold net result of outputs to this address    
                                balanceChangeVin = (decimal)transaction.Vout // value of all outputs where address is the provided address
                                    .Where(v => v.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Value);
                                balanceChangeVout = (decimal)transaction.Vin
                                    .Where(v => v.Prevout != null && v.Prevout.Scriptpubkey_address == Convert.ToString(address))
                                    .Sum(v => v.Prevout.Value);
                                TotalInForAllTXOnThisAddress += balanceChangeVin;
                                TotalOutForAllTXOnThisAddress += balanceChangeVout;
                                txProcessedForThisAddress++;
                            }
                            if (transactions.Last().Status.Confirmed == "true") // there might be more transactions to get. 
                            {
                                lastSeenTxId = transactions.Last().Txid; // so we can carry on the next api call where we left off
                            }
                            else
                            {
                                lastSeenTxId = "";
                            }
                        }

                        string ConfirmedTransactionCount = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                        string ConfirmedReceived = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalInForAllTXOnThisAddress)).ToString("0.00000000"));
                        string ConfirmedSpent = Convert.ToString(ConvertSatsToBitcoin(Convert.ToString(TotalOutForAllTXOnThisAddress)).ToString("0.00000000"));
                        var confirmedReceivedForCalc = Convert.ToDouble(TotalInForAllTXOnThisAddress);
                        var confirmedSpentForCalc = Convert.ToDouble(TotalOutForAllTXOnThisAddress);
                        var confirmedUnspentResult = confirmedReceivedForCalc - confirmedSpentForCalc;
                        string ConfirmedUnspent = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspentResult)).ToString("0.00000000");

                        ListViewItem item = new ListViewItem(Convert.ToString(address)); // create new row
                        item.SubItems.Add(ConfirmedTransactionCount.ToString());
                        item.SubItems.Add(ConfirmedReceived.ToString());
                        item.SubItems.Add(ConfirmedSpent.ToString());
                        item.SubItems.Add(ConfirmedUnspent.ToString());
                        listViewXpubAddresses.Invoke((MethodInvoker)delegate
                        {
                            listViewXpubAddresses.Items.Add(item); // add row
                            numberOfAddressesChecked++;
                        });
                        if (listViewXpubAddresses.Items.Count > 23)
                        {
                            btnXpubAddressUp.Visible = true;
                            btnXpubAddressesDown.Visible = true;
                        }
                        else
                        {
                            btnXpubAddressUp.Visible = false;
                            btnXpubAddressesDown.Visible = false;
                        }

                        // Get the height of each item to set height of whole listview
                        int rowHeight = listViewXpubAddresses.Margin.Vertical + listViewXpubAddresses.Padding.Vertical + listViewXpubAddresses.GetItemRect(0).Height;
                        int itemCount = listViewXpubAddresses.Items.Count; // Get the number of items in the ListBox
                        int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                        listViewXpubAddresses.Height = listBoxHeight; // Set the height of the ListBox
                        panelXpubContainer.VerticalScroll.Minimum = 0;

                        string P2SHTotalConfirmedReceivedDisplay = "";
                        string P2SHTotalConfirmedSpentDisplay = "";
                        string P2SHAddressesConfirmedUnspentBalanceDisplay = "";

                        if (confirmedReceivedForCalc == 0)
                        {
                            consecutiveUnusedAddressesForType++; // unused addresses for this type of address
                            totalUnusedAddresses++; // overall count of unused addresses

                            // progress bar for this address type
                            if (consecutiveUnusedAddressesForType < progressBarCheckEachAddressType.Maximum)
                            {
                                progressBarCheckEachAddressType.Value = consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckEachAddressType.Value = progressBarCheckEachAddressType.Maximum;
                            }
                            lblCheckEachAddressTypeCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckEachAddressTypeCount.Text = consecutiveUnusedAddressesForType.ToString() + "/" + (MaxNumberOfConsecutiveUnusedAddresses + 1).ToString();
                            });
                            // progress bar for all address types
                            if (totalUnusedAddresses < progressBarCheckAllAddressTypes.Maximum)
                            {
                                progressBarCheckAllAddressTypes.Value = (((NumberOfDerivationPathsToCheck * 3) + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses) + consecutiveUnusedAddressesForType;
                            }
                            else
                            {
                                progressBarCheckAllAddressTypes.Value = progressBarCheckAllAddressTypes.Maximum;
                            }
                            lblCheckAllAddressTypesCount.Invoke((MethodInvoker)delegate
                            {
                                lblCheckAllAddressTypesCount.Text = totalUnusedAddresses.ToString() + "/" + ((MaxNumberOfConsecutiveUnusedAddresses + 1) * 4 * NumberOfDerivationPathsToCheck).ToString();
                            });

                            // assume there are no more used addresses at this point
                            if (consecutiveUnusedAddressesForType > MaxNumberOfConsecutiveUnusedAddresses)
                            {
                                break;
                            }
                        }
                        else
                        {
                            usedP2SHAddresses++;
                            consecutiveUnusedAddressesForType = 0;  //
                            totalUnusedAddresses = ((NumberOfDerivationPathsToCheck * 3) + DerivationPath) * MaxNumberOfConsecutiveUnusedAddresses;  // this is the fourth address type, so reset to account for that, rather than 0
                        }

                        if (confirmedReceivedForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            P2SHTotalConfirmedReceived += confirmedReceivedForCalc;
                            xpubTotalConfirmedReceived += confirmedReceivedForCalc;
                        }

                        if (confirmedSpentForCalc > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            P2SHTotalConfirmedSpent += confirmedSpentForCalc;
                            xpubTotalConfirmedSpent += confirmedSpentForCalc;
                        }

                        if (confirmedUnspentResult > 0)
                        {
                            consecutiveUnusedAddressesForType = 0;
                            xpubTotalConfirmedUnspent += confirmedUnspentResult;
                            P2SHAddressesWithNonZeroBalance++;
                            P2SHAddressesConfirmedUnspentBalance += confirmedUnspentResult;
                        }
                        checkingAddressCount++;
                        lblP2SHUsedAddresses.Invoke((MethodInvoker)delegate
                        {
                            lblP2SHUsedAddresses.Text = Convert.ToString(usedP2SHAddresses) + " used";
                        });
                        // format values before displaying them in the summary
                        if (P2SHTotalConfirmedReceived > 0)
                        {
                            P2SHTotalConfirmedReceivedDisplay = ConvertSatsToBitcoin(Convert.ToString(P2SHTotalConfirmedReceived)).ToString("0.00000000");
                        }
                        else
                        {
                            P2SHTotalConfirmedReceivedDisplay = "0";
                        }

                        if (P2SHTotalConfirmedSpent > 0)
                        {
                            P2SHTotalConfirmedSpentDisplay = ConvertSatsToBitcoin(Convert.ToString(P2SHTotalConfirmedSpent)).ToString("0.00000000");
                        }
                        else
                        {
                            P2SHTotalConfirmedSpentDisplay = "0";
                        }

                        if (P2SHAddressesConfirmedUnspentBalance > 0)
                        {
                            P2SHAddressesConfirmedUnspentBalanceDisplay = ConvertSatsToBitcoin(Convert.ToString(P2SHAddressesConfirmedUnspentBalance)).ToString("0.00000000");
                        }
                        else
                        {
                            P2SHAddressesConfirmedUnspentBalanceDisplay = "0";
                        }
                        lblP2SHSummary.Invoke((MethodInvoker)delegate
                        {
                            lblP2SHSummary.Text = P2SHTotalConfirmedReceivedDisplay + "," + P2SHTotalConfirmedSpentDisplay + "," + P2SHAddressesConfirmedUnspentBalanceDisplay;
                        });
                    }

                    progressBarCheckEachAddressType.Value = 0;
                    consecutiveUnusedAddressesForType = 0;
                    checkingAddressCount = 1;
                    DerivationPath++;
                    P2SHAddresses.Clear();
                }
                if (listViewXpubAddresses.Items.Count > 0)
                {
                    listViewXpubAddresses.Items[0].Selected = true;
                }

                DerivationPath = 0;
                #endregion
                #region totals after processing, hide progress bars, re-enable textboxes
                lblXpubStatus.Invoke((MethodInvoker)delegate
                {
                    lblXpubStatus.Text = "Finished scanning addresses\r\n" + numberOfAddressesChecked + " addresses checked";
                });
                lblXpubConfirmedReceived.Invoke((MethodInvoker)delegate
                {
                    lblXpubConfirmedReceived.Text = ConvertSatsToBitcoin(Convert.ToString(xpubTotalConfirmedReceived)).ToString("0.00000000");
                });
                lblXpubConfirmedSpent.Invoke((MethodInvoker)delegate
                {
                    lblXpubConfirmedSpent.Text = ConvertSatsToBitcoin(Convert.ToString(xpubTotalConfirmedSpent)).ToString("0.00000000");
                });
                lblXpubConfirmedUnspent.Invoke((MethodInvoker)delegate
                {
                    lblXpubConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(xpubTotalConfirmedUnspent)).ToString("0.00000000");
                });
                textBoxSubmittedXpub.Enabled = true;
                textBoxXpubNodeURL.Enabled = true;
                timerHideProgressBars.Start();
                #endregion
            }
            catch (Exception ex)
            {
                HandleException(ex, "LookupXpub");
            }
        }
        #endregion
        #region listview appearance
        //-------------------- FORMAT DATA IN LISTVIEW ----------------------------------------------------------------------------
        private void ListViewXpubAddresses_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;

                if (e.ColumnIndex == 2)
                {
                    if (text != "0.00000000") // received
                    {
                        e.SubItem.ForeColor = Color.OliveDrab; // make it green
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (text != "0.00000000") // spent
                    {
                        e.SubItem.ForeColor = Color.IndianRed; // make it red
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (text != "0.00000000") // unspent
                    {
                        e.SubItem.ForeColor = Color.OliveDrab; // make it green if non-zero
                    }
                }

                var font = listViewXpubAddresses.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewXpubAddresses.BackColor), bounds);
                    }
                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewXpubAddresses.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewXpubAddresses_DrawSubItem");
            }
        }

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTHS -------------------------------------
        private void ListViewXpubAddresses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width < 130) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 130;
                    }
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width > 460) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 460;
                    }

                    btnViewAddressFromXpub.Invoke((MethodInvoker)delegate
                    {
                        btnViewAddressFromXpub.Location = new Point(listViewXpubAddresses.Columns[0].Width + listViewXpubAddresses.Location.X - btnViewAddressFromXpub.Width - 6, btnViewAddressFromXpub.Location.Y);
                    });
                }

                if (e.ColumnIndex == 1)
                {
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width != 35) // don't allow this one to change
                    {
                        e.Cancel = true;
                        e.NewWidth = 35;
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width < 100) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 100;
                    }
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width > 250) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 250;
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width < 100) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 100;
                    }
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width > 250) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 250;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width < 100) // min width
                    {
                        e.Cancel = true;
                        e.NewWidth = 100;
                    }
                    if (listViewXpubAddresses.Columns[e.ColumnIndex].Width > 250) // max width
                    {
                        e.Cancel = true;
                        e.NewWidth = 250;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewXpubAddresses_ColumnWidthChanging");
            }
        }

        //-------------------- ROW SELECTED ON THE LISTVIEW --------------------------------------------
        private void ListViewXpubAddresses_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewXpubAddresses.Items)
                {
                    if (item.Selected)
                    {
                        btnViewAddressFromXpub.Visible = true;
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = Color.White;
                        }
                        if (item.SubItems[1].Text == "0")
                        {
                            btnViewAddressFromXpub.Enabled = false;
                        }
                        else
                        {
                            btnViewAddressFromXpub.Enabled = true;
                        }
                        btnViewAddressFromXpub.Invoke((MethodInvoker)delegate
                        {
                            btnViewAddressFromXpub.Location = new Point(item.Position.X + listViewXpubAddresses.Location.X + listViewXpubAddresses.Columns[0].Width - btnViewAddressFromXpub.Width - 8, item.Position.Y + listViewXpubAddresses.Location.Y - 2);
                            btnViewAddressFromXpub.Height = item.Bounds.Height;
                        });
                    }
                    else
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            subItem.ForeColor = tableTextColor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "listViewXpubAddresses_ItemSelectionChanged");
            }
        }
        #endregion
        #region reposition & hide elements
        //-------------------- HIDE PROGRESS BARS, ETC AFTER A PERIOD ----------------------------------
        private void TimerHideProgressBars_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBarCheckAllAddressTypes.Visible = false;
                progressBarCheckEachAddressType.Visible = false;
                lblCheckAllAddressTypesCount.Visible = false;
                lblCheckEachAddressTypeCount.Visible = false;
                label140.Visible = false;
                label141.Visible = false;

                timerHideProgressBars.Stop();
            }
            catch (Exception ex)
            {
                HandleException(ex, "TimerHideProgressBars_Tick");
            }
        }
        #endregion
        #region listview scrolling
        //-------------------- SCROLL-DOWN LISTVIEW ----------------------------------------------------
        private void BtnXpubAddressesDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelXpubContainer.VerticalScroll.Value < panelXpubContainer.VerticalScroll.Maximum)
                {
                    panelXpubContainer.VerticalScroll.Value++;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressesDown_Click");
            }
        }

        private void BtnXpubAddressesDown_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isXpubButtonPressed = true;
                XpubDownButtonPressed = true;
                XpubScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressesDown_MouseDown");
            }
        }

        private void BtnXpubAddressesDown_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isXpubButtonPressed = false;
                XpubDownButtonPressed = false;
                XpubScrollTimer.Stop();
                XpubScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressesDown_MouseUp");
            }
        }

        //-------------------- SCROLL-UP LISTVIEW -------------------------------------------------------
        private void BtnXpubAddressUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelXpubContainer.VerticalScroll.Value > panelXpubContainer.VerticalScroll.Minimum)
                {
                    panelXpubContainer.VerticalScroll.Value--;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressUp_Click");
            }
        }

        private void BtnXpubAddressUp_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isXpubButtonPressed = true;
                XpubUpButtonPressed = true;
                XpubScrollTimer.Start();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressUp_MouseDown");
            }
        }

        private void BtnXpubAddressUp_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isXpubButtonPressed = false;
                XpubUpButtonPressed = false;
                XpubScrollTimer.Stop();
                XpubScrollTimer.Interval = 50; // reset the interval to its original value
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnXpubAddressUp_MouseUp");
            }
        }

        //-------------------- HANDLE THE SCROLLING -------------------------------------------------------
        private void XpubScrollTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isXpubButtonPressed)
                {
                    if (XpubDownButtonPressed)
                    {
                        if (panelXpubContainer.VerticalScroll.Value < panelXpubContainer.VerticalScroll.Maximum - 5)
                        {
                            panelXpubContainer.VerticalScroll.Value = panelXpubContainer.VerticalScroll.Value + 5;
                            XpubAddressesScrollPosition = panelXpubContainer.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        XpubScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                    else if (XpubUpButtonPressed)
                    {
                        if (panelXpubContainer.VerticalScroll.Value > panelXpubContainer.VerticalScroll.Minimum + 5)
                        {
                            panelXpubContainer.VerticalScroll.Value = panelXpubContainer.VerticalScroll.Value - 5;
                            XpubAddressesScrollPosition = panelXpubContainer.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                        }
                        XpubScrollTimer.Interval = 1; // set a faster interval while the button is held down
                    }
                }
                else
                {
                    XpubScrollTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "XpubScrollTimer_Tick");
            }
        }

        private void PanelXpubContainer_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btnViewAddressFromXpub.Visible) // user must have clicked a row given that the button is visible
                {
                    panelXpubContainer.VerticalScroll.Value = XpubAddressesScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PanelXpubContainer_Paint");
            }
        }
        #endregion
        #region navigate from listview to address screen
        //-------------------- VIEW ADDRESS --------------------------------------------------------------
        private void BtnViewAddressFromXpub_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                // Get the selected item
                ListViewItem selectedItem = listViewXpubAddresses.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress; // copy address to address screen
                });
                //show the address screen
                BtnMenuAddress_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnViewAddressFromXpub_Click");
            }
        }
        #endregion
        #endregion

        #region ⚡CHARTS SCREEN⚡
        #region chart - pools ranking
        private async void BtnChartPoolsRanking_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot1.Visible = false;
                formsPlot3.Visible = false;
                chartType = "poolranking";

                EnableAllCharts();
                btnChartPoolsRanking.Enabled = false;

                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                int desiredSpacing = 98; // spacing added to title to force left-align in
                string spacing = new string('\u00A0', desiredSpacing);
                string title = string.Format("Mining pool rankings - time period: {0}{1}", chartPeriod, spacing);
                formsPlot2.Plot.Title(title, size: 13, color: labelColor, bold: true);

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                var PoolRankingDataJson = await _poolsRankingDataService.GetPoolsRankingDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(PoolRankingDataJson);

                List<PoolsRanking> poolsRankingList = JsonConvert.DeserializeObject<List<PoolsRanking>>(jsonObj["pools"].ToString());

                // Calculate the total BlockCount
                int totalBlockCount = poolsRankingList.Sum(p => int.Parse(p.BlockCount));

                // Create lists for values and labels
                List<double> values = new List<double>();
                List<string> labels = new List<string>();

                // Populate values and labels for the first 15 segments
                int blocksMinedByTop15 = 0;
                for (int i = 0; i < Math.Min(15, poolsRankingList.Count); i++)
                {
                    var pool = poolsRankingList[i];
                    values.Add(double.Parse(pool.BlockCount));
                    blocksMinedByTop15 += Convert.ToInt32(pool.BlockCount);
                    labels.Add(pool.Name);
                }

                int numberOfBlocksMinedByOthers = totalBlockCount - blocksMinedByTop15;
                values.Add(numberOfBlocksMinedByOthers);
                labels.Add("Others");

                // Copy values list to an array
                double[] valuesArray = values.ToArray();
                // Copy labels list to an array
                string[] labelsArray = labels.ToArray();

                string[] labelsAndValuesArray = new string[labelsArray.Length]; // this array is used to label the segments
                for (int i = 0; i < labelsArray.Count(); i++)
                {
                    string labelAndValue = labelsArray[i] + " (" + valuesArray[i] + ")";
                    labelsAndValuesArray[i] = labelAndValue;
                }

                // Define the color spectrum
                Color[] colorSpectrum = GenerateRainbowColorSpectrum(values.Count);

                // Method to generate a rainbow-like color spectrum
                Color[] GenerateRainbowColorSpectrum(int segmentCount)
                {
                    var colors = new Color[segmentCount];
                    double hueIncrement = 360.0 / segmentCount;

                    for (int i = 0; i < segmentCount; i++)
                    {
                        double hue = i * hueIncrement;
                        Color color = ColorFromHSV(hue, 0.6, 0.7);
                        colors[i] = color;
                    }

                    return colors;
                }

                // Method to convert HSV (Hue, Saturation, Value) to RGB
                Color ColorFromHSV(double hue, double saturation, double value)
                {
                    int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                    double f = hue / 60 - Math.Floor(hue / 60);

                    value *= 255;
                    int v = Convert.ToInt32(value);
                    int p = Convert.ToInt32(value * (1 - saturation));
                    int q = Convert.ToInt32(value * (1 - f * saturation));
                    int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

                    if (hi == 0)
                        return Color.FromArgb(255, v, t, p);
                    else if (hi == 1)
                        return Color.FromArgb(255, q, v, p);
                    else if (hi == 2)
                        return Color.FromArgb(255, p, v, t);
                    else if (hi == 3)
                        return Color.FromArgb(255, p, q, v);
                    else if (hi == 4)
                        return Color.FromArgb(255, t, p, v);
                    else
                        return Color.FromArgb(255, v, p, q);
                }

                // Create the pie chart 
                var pie = formsPlot2.Plot.AddPie(valuesArray);
                pie.DonutSize = .3;
                pie.DonutLabel = Convert.ToString(totalBlockCount - 1 + "\r\nblocks mined\r\n" + "period: " + chartPeriod);
                pie.CenterFont.Color = Color.Orange;
                pie.CenterFont.Size = 13;
                pie.CenterFont.Bold = false;
                pie.SliceFillColors = colorSpectrum;
                pie.ShowPercentages = true;
                pie.ShowValues = false;
                pie.ShowLabels = true;
                pie.Size = .7;
                pie.SliceFont.Size = 11;
                pie.SliceFont.Bold = false;
                pie.SliceLabels = labelsAndValuesArray;
                pie.SliceLabelColors = colorSpectrum;
                pie.SliceLabelPosition = 0.60;

                var padding = new ScottPlot.PixelPadding(
                    left: 45,
                    right: 25,
                    bottom: 15,
                    top: 27);
                formsPlot2.Plot.ManualDataArea(padding);

                formsPlot2.Plot.YAxis.Label("");
                formsPlot2.Plot.XAxis.Label("");
                // refresh the graph
                formsPlot2.Refresh();
                formsPlot2.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating pools ranking chart");
            }
        }
        #endregion
        #region chart - fee rates
        private async void BtnChartFeeRates_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "feerates";
                lblChartMousePositionData.Text = "";
                EnableAllCharts();
                btnChartFeeRates.Enabled = false;
                DisableIrrelevantTimePeriods();
                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Block fee rates - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // Create an instance of HttpClient
                HttpClient client = new HttpClient();

                string url = NodeURL + "v1/mining/blocks/fee-rates/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                List<BlockFeeRates> feeRatesList = JsonConvert.DeserializeObject<List<BlockFeeRates>>(json.ToString());

                // set the number of points on the graph to the number of hashrates to display
                int pointCount = feeRatesList.Count;

                // create arrays of doubles of the hashrates and the dates
                double[] yValues1 = feeRatesList.Select(h => (double)(h.AvgFee_100)).ToArray();
                double[] yValues2 = feeRatesList.Select(h => (double)(h.AvgFee_90)).ToArray();
                double[] yValues3 = feeRatesList.Select(h => (double)(h.AvgFee_75)).ToArray();
                double[] yValues4 = feeRatesList.Select(h => (double)(h.AvgFee_50)).ToArray();
                double[] yValues5 = feeRatesList.Select(h => (double)(h.AvgFee_25)).ToArray();
                double[] yValues6 = feeRatesList.Select(h => (double)(h.AvgFee_10)).ToArray();
                double[] yValues7 = feeRatesList.Select(h => (double)(h.AvgFee_0)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = feeRatesList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                // prevent navigating beyond the data
                double yBoundary = yValues2.Max();
                if (yBoundary > 5000)
                {
                    yBoundary = 5000;
                }
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yBoundary);
                formsPlot1.Plot.YAxis.SetBoundary(0, yBoundary);
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());
                formsPlot1.Plot.AddFill(xValues, yValues1, 0, color: Color.FromArgb(30, Color.DarkGray));
                formsPlot1.Plot.AddFill(xValues, yValues2, 0, color: Color.Red);
                formsPlot1.Plot.AddFill(xValues, yValues3, 0, color: Color.Orange);
                formsPlot1.Plot.AddFill(xValues, yValues4, 0, color: Color.Yellow);
                formsPlot1.Plot.AddFill(xValues, yValues5, 0, color: Color.LimeGreen);
                formsPlot1.Plot.AddFill(xValues, yValues6, 0, color: Color.Blue);
                formsPlot1.Plot.AddFill(xValues, yValues7, 0, color: Color.Indigo);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("sats per v/byte", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // Set the tick and gridline settings
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelFeeRatesKey.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating fee rates chart");
            }
        }
        #endregion
        #region chart - nodes by network
        private async void BtnChartNodesByNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "lightningnodesbynetwork";
                lblChartMousePositionData.Text = "";

                // if chart period too short for this chart, set it to max instead
                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }
                EnableAllCharts();
                btnChartNodesByNetwork.Enabled = false;

                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Number of Lightning nodes by network - " + chartPeriod, size: 13, bold: true);

                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // Create an instance of HttpClient
                HttpClient client = new HttpClient();

                string url = NodeURL + "v1/lightning/statistics/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                List<NodesPerNetworkAndCapacity> lightningNodesPerNetworkList = JsonConvert.DeserializeObject<List<NodesPerNetworkAndCapacity>>(json.ToString());

                // set the number of points on the graph
                int pointCount = lightningNodesPerNetworkList.Count;

                // create arrays of doubles
                double[] yValues1 = lightningNodesPerNetworkList.Select(h => (double)(h.Tor_nodes)).ToArray();
                double[] yValues2 = lightningNodesPerNetworkList.Select(h => (double)(h.Clearnet_nodes)).ToArray();
                double[] yValues3 = lightningNodesPerNetworkList.Select(h => (double)(h.Unannounced_nodes)).ToArray();
                double[] yValues4 = lightningNodesPerNetworkList.Select(h => (double)(h.Clearnet_tor_nodes)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = lightningNodesPerNetworkList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Added)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                // prevent navigating beyond the data
                double yBoundary = yValues1.Max();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yBoundary);
                formsPlot1.Plot.YAxis.SetBoundary(0, yBoundary);
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());
                //formsPlot1.Plot.AddFill(xValues, yValues1, 0, Color.IndianRed);
                formsPlot1.Plot.AddScatter(xValues, yValues1, lineWidth: 1, markerSize: 1, color: Color.IndianRed);
                formsPlot1.Plot.AddScatter(xValues, yValues2, lineWidth: 1, markerSize: 1, color: Color.OliveDrab);
                formsPlot1.Plot.AddScatter(xValues, yValues3, lineWidth: 1, markerSize: 1, color: Color.SteelBlue);
                formsPlot1.Plot.AddScatter(xValues, yValues4, lineWidth: 1, markerSize: 1, color: Color.Gold);
                //formsPlot1.Plot.AddFill(xValues, yValues2, 0, Color.DarkOrange);
                //formsPlot1.Plot.AddFill(xValues, yValues3, 0, Color.DarkSalmon);
                //formsPlot1.Plot.AddFill(xValues, yValues4, 0, Color.DarkGoldenrod);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("lightning nodes per network", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // Set the tick and gridline settings
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                formsPlot1.Plot.Legend();
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelLightningNodeNetwork.Visible = true;
                //panelFeeRatesKey.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating nodes by network chart");
            }
        }
        #endregion
        #region chart - hashrate linear and log
        private async void BtnChartHashrate_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnHashrateScaleLinear.Enabled = false;
                btnHashrateScaleLog.Enabled = true;
                chartType = "hashrate";
                // if chart period too short for this chart, set it to max instead
                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "1m")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }
                EnableAllCharts();
                btnChartHashrate.Enabled = false;
                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Hashrate (exahash per second) - " + chartPeriod, size: 13, bold: true);

                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // get a series of historic dates/hashrates/difficulties
                var HashrateAndDifficultyJson = await _hashrateAndDifficultyService.GetHashrateAndDifficultyAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HashrateAndDifficultyJson);

                //split the data into two lists
                List<HashrateSnapshot> hashratesList = JsonConvert.DeserializeObject<List<HashrateSnapshot>>(jsonObj["hashrates"].ToString());
                List<DifficultySnapshot> difficultyList = JsonConvert.DeserializeObject<List<DifficultySnapshot>>(jsonObj["difficulty"].ToString());

                // set the number of points on the graph to the number of hashrates to display
                int pointCount = hashratesList.Count;

                // create arrays of doubles of the hashrates and the dates
                double[] yValues = hashratesList.Select(h => (double)(h.AvgHashrate / (decimal)1E18)).ToArray(); // divide by 1E18 to get exahash
                                                                                                                 // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = hashratesList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);

                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("EH/s", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;

                panelHashrateScaleButtons.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating hashrate chart");
            }
        }

        private async void BtnHashrateScaleLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnHashrateScaleLinear.Enabled = true;
                btnHashrateScaleLog.Enabled = false;
                chartType = "hashratelog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartHashrate.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Hashrate (terrahash per second) - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of historic dates/hashrates/difficulties
                var HashrateAndDifficultyJson = await _hashrateAndDifficultyService.GetHashrateAndDifficultyAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HashrateAndDifficultyJson);

                //split the data into two lists
                List<HashrateSnapshot> hashratesList = JsonConvert.DeserializeObject<List<HashrateSnapshot>>(jsonObj["hashrates"].ToString());
                List<DifficultySnapshot> difficultyList = JsonConvert.DeserializeObject<List<DifficultySnapshot>>(jsonObj["difficulty"].ToString());

                // set the number of points on the graph
                int pointCount = hashratesList.Count;

                // create arrays of doubles of the hashrates and the dates
                double[] yValues = hashratesList.Select(h => (double)(h.AvgHashrate / (decimal)1E12)).ToArray(); // divide by 1E12 to get terrahash
                                                                                                                 // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = hashratesList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < hashratesList.Count; i++)
                {
                    //double yValue = (double)hashratesList[i].AvgHashrate;
                    double yValue = (double)yValues[i];
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues2 = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues2.Min();
                double maxY = yValues2.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues2, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("TH/s", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelHashrateScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating hashrate chart (log) chart");
            }
        }
        #endregion
        #region chart - lightning capacity
        private async void BtnChartLightningCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "lightningcapacity";
                // if chart period too short for this chart, set it to max instead
                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartLightningCapacity.Enabled = false;
                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Lightning network capacity - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // Create an instance of HttpClient
                HttpClient client = new HttpClient();

                string url = NodeURL + "v1/lightning/statistics/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                List<NodesPerNetworkAndCapacity> lightningCapacityList = JsonConvert.DeserializeObject<List<NodesPerNetworkAndCapacity>>(json.ToString());

                // set the number of points on the graph
                int pointCount = lightningCapacityList.Count;

                // create arrays of doubles
                double[] yValuesCapacity = lightningCapacityList.Select(h => (double)(h.Total_capacity / 100000000)).ToArray();

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = lightningCapacityList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Added)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValuesCapacity.Max() * 1.05);

                scatter = formsPlot1.Plot.AddScatter(xValues, yValuesCapacity, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Capacity (BTC)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValuesCapacity.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating lightning capacity chart");
            }
        }
        #endregion
        #region chart - lightning channels
        private async void BtnChartLightningChannels_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "lightningchannels";
                // if chart period too short for this chart, set it to max instead
                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartLightningChannels.Enabled = false;
                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Lightning network channels - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // Create an instance of HttpClient
                HttpClient client = new HttpClient();

                string url = NodeURL + "v1/lightning/statistics/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                List<NodesPerNetworkAndCapacity> lightningChannelsList = JsonConvert.DeserializeObject<List<NodesPerNetworkAndCapacity>>(json.ToString());

                // set the number of points on the graph
                int pointCount = lightningChannelsList.Count;

                // create arrays of doubles
                double[] yValuesChannels = lightningChannelsList.Select(h => (double)(h.Channel_count)).ToArray();

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = lightningChannelsList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Added)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValuesChannels.Max() * 1.05);

                scatter = formsPlot1.Plot.AddScatter(xValues, yValuesChannels, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Capacity (BTC)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValuesChannels.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating lightning channels chart");
            }
        }
        #endregion
        #region chart - nodes by country
        private async void BtnChartNodesByCountry_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot1.Visible = false;
                formsPlot2.Visible = false;
                chartType = "nodesbycountry";

                EnableAllCharts();
                btnChartNodesByCountry.Enabled = false;
                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot3.Plot.Title("Lightning nodes per country (excluding Darknet)", size: 13, bold: true);

                // switch to linear scaling in case it was log before
                formsPlot3.Plot.YAxis.MinorLogScale(false);
                formsPlot3.Plot.YAxis.MajorGrid(false);
                formsPlot3.Plot.YAxis.MinorGrid(false);

                formsPlot3.Plot.XAxis.DateTimeFormat(false);

                // Define a new tick label formatter for the linear scale
                static string linearTickLabels(double y) => y.ToString("N0");
                formsPlot3.Plot.YAxis.TickLabelFormat(linearTickLabels);

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // Fetch data from the API
                string url = NodeURL + "v1/lightning/nodes/countries";
                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(url);

                // Deserialize the JSON response
                var response = JsonConvert.DeserializeObject<LightningNodeCountry[]>(json);

                // Extract the top 40 country names (En) and counts, handling nullable decimal values
                string[] countryNames = response.Select(node => node.Name.En).Take(40).ToArray();
                double[] counts = response.Select(node => Convert.ToDouble(node.Count)).Take(40).ToArray();
                double[] allcounts = response.Select(node => Convert.ToDouble(node.Count)).ToArray();
                double totalNodes = allcounts.Sum();
                double nodesInTop40 = counts.Sum();
                double nodesOfOtherCountries = totalNodes - nodesInTop40;
                countryNames = countryNames.Concat(new[] { "Other" }).ToArray();
                counts = counts.Concat(new[] { nodesOfOtherCountries }).ToArray();

                // Create the ScottPlot bar chart
                var bar = formsPlot3.Plot.AddBar(counts);
                bar.Orientation = ScottPlot.Orientation.Horizontal;

                // Generate a sequence of numbers for the Y-axis tick positions
                double[] yPositions = Enumerable.Range(0, counts.Length).Select(y => (double)y).ToArray();

                // Set the Y-axis tick positions and labels
                formsPlot3.Plot.YTicks(yPositions, countryNames);
                formsPlot3.Plot.YLabel("");
                formsPlot3.Plot.XLabel("");
                formsPlot3.Plot.SetAxisLimits(0, counts.Max());
                formsPlot3.Plot.XAxis.SetBoundary(0, counts.Max());
                formsPlot3.Plot.YAxis.SetBoundary(-3, 45);
                formsPlot3.Plot.Layout(left: 100);

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot3.Refresh();
                formsPlot3.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating nodes by country chart");
            }
        }
        #endregion
        #region chart - block reward
        private async void BtnChartReward_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "reward";

                EnableAllCharts();
                btnChartReward.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Block rewards (block subsidy plus fees) - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                HttpClient client = new HttpClient();
                string url = NodeURL + "v1/mining/blocks/rewards/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                // Deserialize JSON array into a list of HistoricRewardsAndPrice objects
                List<HistoricRewardsAndPrice> rewardsAndPriceList = JsonConvert.DeserializeObject<List<HistoricRewardsAndPrice>>(json);

                // set the number of points on the graph to the number of hashrates to display
                int pointCount = rewardsAndPriceList.Count;

                // create arrays of doubles of the rewards and the dates
                double[] yValues = rewardsAndPriceList.Select(h => (double)(h.AvgRewards / 100000000)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = rewardsAndPriceList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("BTC", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating block reward chart");
            }
        }
        #endregion
        #region chart - block fees
        private async void BtnChartBlockFees_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "blockfees";

                EnableAllCharts();
                btnChartBlockFees.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Average total fees per block - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                HttpClient client = new HttpClient();
                string url = NodeURL + "v1/mining/blocks/fees/" + chartPeriod;
                string json = await client.GetStringAsync(url);

                // Deserialize JSON array into a list of HistoricFeesAndPrice objects
                List<HistoricFeesAndPrice> feesAndPriceList = JsonConvert.DeserializeObject<List<HistoricFeesAndPrice>>(json);

                // set the number of points on the graph to the number of hashrates to display
                int pointCount = feesAndPriceList.Count;

                // create arrays of doubles of the rewards and the dates
                double[] yValues = feesAndPriceList.Select(h => (double)(h.AvgFees / 100000000)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = feesAndPriceList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("BTC", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating block fees chart");
            }
        }
        #endregion
        #region chart - difficulty linear and log
        private async void BtnChartDifficulty_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartDifficultyLinear.Enabled = false;
                btnChartDifficultyLog.Enabled = true;
                chartType = "difficulty";

                // if chart period too short for this chart, set it to max instead
                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "1m")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartDifficulty.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Difficulty - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic dates/hashrates/difficulties
                var HashrateAndDifficultyJson = await _hashrateAndDifficultyService.GetHashrateAndDifficultyAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HashrateAndDifficultyJson);

                //split the data into two lists
                List<HashrateSnapshot> hashratesList = JsonConvert.DeserializeObject<List<HashrateSnapshot>>(jsonObj["hashrates"].ToString());
                List<DifficultySnapshot> difficultyList = JsonConvert.DeserializeObject<List<DifficultySnapshot>>(jsonObj["difficulty"].ToString());

                // set the number of points on the graph to the number of hashrates to display
                int pointCount = difficultyList.Count;

                // create arrays of doubles of the difficulties and the dates
                double[] yValues = difficultyList.Select(h => (double)(h.Difficulty / (decimal)1E12)).ToArray(); // divide by 1E12 to convert to trillions
                                                                                                                 // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = difficultyList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Time)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);
                scatter.StepDisplay = true;

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("trillion", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartDifficultyScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating difficulty chart");
            }
        }

        private async void BtnChartDifficultyLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartDifficultyLinear.Enabled = true;
                btnChartDifficultyLog.Enabled = false;
                chartType = "difficultylog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartDifficulty.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Difficulty - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of historic dates/hashrates/difficulties
                var HashrateAndDifficultyJson = await _hashrateAndDifficultyService.GetHashrateAndDifficultyAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HashrateAndDifficultyJson);

                //split the data into two lists
                List<HashrateSnapshot> hashratesList = JsonConvert.DeserializeObject<List<HashrateSnapshot>>(jsonObj["hashrates"].ToString());
                List<DifficultySnapshot> difficultyList = JsonConvert.DeserializeObject<List<DifficultySnapshot>>(jsonObj["difficulty"].ToString());

                // set the number of points on the graph
                int pointCount = difficultyList.Count;

                // create arrays of doubles of the difficulties and the dates
                double[] yValues = difficultyList.Select(h => (double)(h.Difficulty / (decimal)1E12)).ToArray(); // divide by 1E12 to convert to trillions
                                                                                                                 // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = difficultyList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Time)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < difficultyList.Count; i++)
                {
                    //double yValue = (double)hashratesList[i].AvgHashrate;
                    double yValue = (double)yValues[i];
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues2 = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues2.Min();
                double maxY = yValues2.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues2, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("trillion", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartDifficultyScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating difficulty chart (log) chart");
            }
        }
        #endregion
        #region chart - unique addresses linear and log
        private async void BtnChartUniqueAddresses_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartAddressScaleLinear.Enabled = false;
                btnChartAddressScaleLog.Enabled = true;
                chartType = "addresses";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }
                EnableAllCharts();
                btnChartUniqueAddresses.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Unique addresses - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic price data
                var UniqueAddressesDataJson = await _uniqueAddressesDataService.GetUniqueAddressesDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(UniqueAddressesDataJson);

                List<UniqueAddressesList> AddressesList = JsonConvert.DeserializeObject<List<UniqueAddressesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = AddressesList.Count;

                // create arrays of doubles of the amounts and the dates
                double[] yValues = AddressesList.Select(h => (double)(h.Y)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = AddressesList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Unique addresses", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelUniqueAddressesScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating unique addresses chart");
            }
        }

        private async void BtnChartUniqueAddressesLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartAddressScaleLinear.Enabled = true;
                btnChartAddressScaleLog.Enabled = false;
                chartType = "addresseslog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartUniqueAddresses.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Unique addresses - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of historic price data
                var UniqueAddressesDataJson = await _uniqueAddressesDataService.GetUniqueAddressesDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(UniqueAddressesDataJson);

                List<UniqueAddressesList> AddressList = JsonConvert.DeserializeObject<List<UniqueAddressesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = AddressList.Count;

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = AddressList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < AddressList.Count; i++)
                {
                    double yValue = (double)AddressList[i].Y;
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues.Min();
                double maxY = yValues.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Unique addresses", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelUniqueAddressesScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating unique addresses (log) chart");
            }
        }
        #endregion
        #region chart - price linear and log
        private async void BtnChartPrice_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnPriceChartScaleLinear.Enabled = false;
                btnPriceChartScaleLog.Enabled = true;
                chartType = "price";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartPrice.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Average USD market price across major bitcoin exchanges - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic price data
                var HistoricPriceDataJson = await _historicPriceDataService.GetHistoricPriceDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HistoricPriceDataJson);

                List<PriceCoordinatesList> PriceList = JsonConvert.DeserializeObject<List<PriceCoordinatesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = PriceList.Count;

                // create arrays of doubles of the difficulties and the dates
                double[] yValues = PriceList.Select(h => (double)(h.Y)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = PriceList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Price (USD)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelPriceScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating price chart");
            }
        }

        private async void BtnChartPriceLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnPriceChartScaleLinear.Enabled = true;
                btnPriceChartScaleLog.Enabled = false;
                chartType = "pricelog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartPrice.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Average USD market price across major bitcoin exchanges - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of historic price data
                var HistoricPriceDataJson = await _historicPriceDataService.GetHistoricPriceDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(HistoricPriceDataJson);

                List<PriceCoordinatesList> PriceList = JsonConvert.DeserializeObject<List<PriceCoordinatesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = PriceList.Count;

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = PriceList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < PriceList.Count; i++)
                {
                    double yValue = (double)PriceList[i].Y;
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues.Min();
                double maxY = yValues.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Price (USD)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelPriceScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating price (log) chart");
            }
        }
        #endregion
        #region chart - market cap linear and log
        private async void BtnChartMarketCap_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnPriceChartScaleLinear.Enabled = false;
                btnChartMarketCapScaleLog.Enabled = true;
                chartType = "marketcap";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartMarketCap.Enabled = false;
                btnChartMarketCapScaleLinear.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Market capitalization in USD - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic price data
                var MarketCapDataJson = await _marketCapDataService.GetMarketCapDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(MarketCapDataJson);

                List<MarketCapCoordinatesList> MarketCapList = JsonConvert.DeserializeObject<List<MarketCapCoordinatesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = MarketCapList.Count;

                // create arrays of doubles of the difficulties and the dates
                double[] yValues = MarketCapList.Select(h => (double)(h.Y)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = MarketCapList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Market Capitalization (USD)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartMarketCapScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating market cap chart");
            }
        }

        private async void BtnChartMarketCapScaleLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartMarketCapScaleLinear.Enabled = true;
                btnChartMarketCapScaleLog.Enabled = false;
                chartType = "marketcaplog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartMarketCap.Enabled = false;
                btnChartMarketCapScaleLog.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Market capitalization in USD - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of market cap data
                var MarketCapDataJson = await _marketCapDataService.GetMarketCapDataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(MarketCapDataJson);

                List<MarketCapCoordinatesList> MarketCapList = JsonConvert.DeserializeObject<List<MarketCapCoordinatesList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = MarketCapList.Count;

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = MarketCapList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < MarketCapList.Count; i++)
                {
                    double yValue = (double)MarketCapList[i].Y;
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues.Min();
                double maxY = yValues.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Market Capitalization (USD)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartMarketCapScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating market cap (log) chart");
            }
        }
        #endregion
        #region chart - utxo count linear and log
        private async void BtnChartUTXO_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartUTXOScaleLinear.Enabled = false;
                btnChartUTXOScaleLog.Enabled = true;
                chartType = "utxo";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartUTXO.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Total number of valid unspent transaction outputs - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic price data
                var UTXODataJson = await _utxoDataService.GetUTXODataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(UTXODataJson);

                List<UTXOList> UTXOList = JsonConvert.DeserializeObject<List<UTXOList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = UTXOList.Count;

                // create arrays of doubles
                double[] yValues = UTXOList.Select(h => (double)(h.Y)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = UTXOList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("valid UTXO count", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartUTXOScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating UTXO chart");
            }
        }

        private async void BtnChartUTXOScaleLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                btnChartUTXOScaleLinear.Enabled = true;
                btnChartUTXOScaleLog.Enabled = false;
                chartType = "pricelog";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartUTXO.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Total number of valid unspent transaction outputs - " + chartPeriod + " (log scale)", size: 13, bold: true);

                // get a series of historic price data
                var UTXODataJson = await _utxoDataService.GetUTXODataAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(UTXODataJson);

                List<UTXOList> UTXOList = JsonConvert.DeserializeObject<List<UTXOList>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = UTXOList.Count;

                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = UTXOList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();


                List<double> filteredYValues = new List<double>();
                List<double> filteredXValues = new List<double>();

                for (int i = 0; i < UTXOList.Count; i++)
                {
                    double yValue = (double)UTXOList[i].Y;
                    if (yValue > 0)
                    {
                        filteredYValues.Add(Math.Log10(yValue));
                        filteredXValues.Add(xValues[i]);
                    }
                }

                double[] yValues = filteredYValues.ToArray();
                double[] xValuesFiltered = filteredXValues.ToArray();


                double minY = yValues.Min();
                double maxY = yValues.Max() * 1.05;
                formsPlot1.Plot.SetAxisLimits(xValuesFiltered.Min(), xValuesFiltered.Max(), minY, maxY);
                scatter = formsPlot1.Plot.AddScatter(xValuesFiltered, yValues, lineWidth: 1, markerSize: 1);

                // Use a custom formatter to control the label for each tick mark
                static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(logTickLabels);

                // Use log-spaced minor tick marks and grid lines
                formsPlot1.Plot.YAxis.MinorLogScale(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MinorGrid(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("valid UTXO count", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(minY, maxY);
                //formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                panelChartUTXOScaleButtons.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating UTXO (log) chart");
            }
        }
        #endregion
        #region chart - block size
        private async void BtnChartBlockSize_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "blocksize";

                EnableAllCharts();
                btnChartBlockSize.Enabled = false;
                DisableIrrelevantTimePeriods();

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Block size - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // get a series of historic dates/hashrates/difficulties
                var BlockSizeAndWeightJson = await _blockSizeAndWeightService.GetBlockSizeAndWeightServiceAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(BlockSizeAndWeightJson);

                //split the data into two lists
                List<Sizes> blockSizeList = JsonConvert.DeserializeObject<List<Sizes>>(jsonObj["sizes"].ToString());
                List<Weights> blockWeightList = JsonConvert.DeserializeObject<List<Weights>>(jsonObj["weights"].ToString());

                // set the number of points on the graph to the number of records to display
                int pointCount = blockSizeList.Count;

                // create arrays of doubles of the hashrates and the dates

                double[] yValues = blockSizeList.Select(h => (double)h.AvgSize / (1000 * 1000)).ToArray();
                //double[] yValues = blockSizeList.Select(h => (double)(h.AvgSize / (decimal)1E18)).ToArray(); // divide by 1E18 to get exahash
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = blockSizeList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.Timestamp)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();

                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, yValues.Max() * 1.05);

                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Block size (MB)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, yValues.Max());
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;
                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating block size chart");
            }
        }
        #endregion
        #region chart - circulation
        private async void BtnChartCirculation_Click(object sender, EventArgs e)
        {
            try
            {
                ShowChartLoadingPanel();
                HideAllChartKeysAndPanels();
                formsPlot2.Visible = false;
                formsPlot3.Visible = false;
                chartType = "circulation";

                if (chartPeriod == "24h" || chartPeriod == "3d" || chartPeriod == "1w" || chartPeriod == "2y")
                {
                    chartPeriod = "all";
                    btnChartPeriodAll.Enabled = false;
                }

                EnableAllCharts();
                btnChartCirculation.Enabled = false;
                DisableIrrelevantTimePeriods();

                ToggleLoadingAnimation("enable");
                DisableEnableChartButtons("disable");

                // clear any previous graph
                ClearAllChartData();
                formsPlot1.Plot.Title("Bitcoin circulation - " + chartPeriod, size: 13, bold: true);
                PrepareLinearScaleChart();

                // get a series of historic dates and amounts of btc in circulation
                var CirculationJson = await _bitcoinsInCirculationDataService.GetBitcoinsInCirculationAsync(chartPeriod);
                JObject jsonObj = JObject.Parse(CirculationJson);

                List<BTCInCircChartCoordinates> CirculationList = JsonConvert.DeserializeObject<List<BTCInCircChartCoordinates>>(jsonObj["values"].ToString());

                // set the number of points on the graph
                int pointCount = CirculationList.Count;

                // create arrays of doubles of the difficulties and the dates
                double[] yValues = CirculationList.Select(h => (double)(h.Y)).ToArray();
                // create a new list of the dates, this time in DateTime format
                List<DateTime> dateTimes = CirculationList.Select(h => DateTimeOffset.FromUnixTimeSeconds(long.Parse(h.X)).LocalDateTime).ToList();
                double[] xValues = dateTimes.Select(x => x.ToOADate()).ToArray();
                formsPlot1.Plot.SetAxisLimits(xValues.Min(), xValues.Max(), 0, 22500000);
                scatter = formsPlot1.Plot.AddScatter(xValues, yValues, lineWidth: 1, markerSize: 1, color: Color.Orange);

                double[] yConstant = new double[xValues.Count()];
                for (int i = 0; i < xValues.Count(); i++)
                {
                    yConstant[i] = 21000000;
                }

                formsPlot1.Plot.AddFill(xValues, yConstant, 0, color: Color.FromArgb(30, Color.Orange));
                formsPlot1.Plot.AddFill(xValues, yValues, 0, color: Color.Orange);

                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Plot.XAxis.TickLabelStyle(fontSize: 10);
                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Label("Bitcoin (max. 21m)", size: 11, bold: true);
                formsPlot1.Plot.XAxis.Label("");

                // prevent navigating beyond the data
                formsPlot1.Plot.YAxis.SetBoundary(0, 22500000);
                formsPlot1.Plot.XAxis.SetBoundary(xValues.Min(), xValues.Max());

                // Add a red circle we can move around later as a highlighted point indicator
                HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
                panelCirculationKey.Visible = true;

                formsPlot1.Plot.XAxis.Ticks(true);
                formsPlot1.Plot.YAxis.Ticks(true);
                formsPlot1.Plot.XAxis.MajorGrid(true);
                formsPlot1.Plot.YAxis.MajorGrid(true);

                // refresh the graph
                formsPlot1.Refresh();
                formsPlot1.Visible = true;

                ToggleLoadingAnimation("disable");
                DisableEnableChartButtons("enable");
                HideChartLoadingPanel();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Generating circulation chart");
            }
        }
        #endregion
        #region chart - price converter
        #region set up chart area
        private void BtnPriceConverter_Click(object sender, EventArgs e)
        {
            HideAllChartKeysAndPanels();
            formsPlot1.Visible = false;
            formsPlot2.Visible = false;
            formsPlot3.Visible = false;
            panelPriceConverter.Visible = true;
            EnableAllCharts();
            btnPriceConverter.Enabled = false;
            ToggleLoadingAnimation("enable");
            DisableEnableChartButtons("disable");
            // clear any previous graph
            ClearAllChartData();
            PopulateConverterScreen();
            ToggleLoadingAnimation("disable");
            DisableEnableChartButtons("enable");
            HideChartLoadingPanel();
        }
        #endregion
        #region populate data
        private void PopulateConverterScreen()
        {
            try
            {
                if (!privacyMode)
                {
                    var (priceUSD, priceGBP, priceEUR, priceXAU) = BitcoinExplorerOrgGetPrice();

                    #region USD list
                    labelPCUSD1.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD1.Text = (Convert.ToDecimal(priceUSD) / 100000000).ToString("0.00");
                    });
                    labelPCUSD2.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD2.Text = (Convert.ToDecimal(priceUSD) / 10000000).ToString("0.00");
                    });
                    labelPCUSD3.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD3.Text = (Convert.ToDecimal(priceUSD) / 1000000).ToString("0.00");
                    });
                    labelPCUSD4.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD4.Text = (Convert.ToDecimal(priceUSD) / 100000).ToString("0.00");
                    });
                    labelPCUSD5.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD5.Text = (Convert.ToDecimal(priceUSD) / 10000).ToString("0.00");
                    });
                    labelPCUSD6.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD6.Text = (Convert.ToDecimal(priceUSD) / 1000).ToString("0.00");
                    });
                    labelPCUSD7.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD7.Text = (Convert.ToDecimal(priceUSD) / 100).ToString("0.00");
                    });
                    labelPCUSD8.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD8.Text = (Convert.ToDecimal(priceUSD) / 10).ToString("0.00");
                    });
                    labelPCUSD9.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD9.Text = (Convert.ToDecimal(priceUSD)).ToString("0.00");
                    });
                    labelPCUSD10.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD10.Text = (Convert.ToDecimal(priceUSD) * 10).ToString("0.00");
                    });
                    labelPCUSD11.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD11.Text = (Convert.ToDecimal(priceUSD) * 100).ToString("0.00");
                    });
                    labelPCUSD12.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD12.Text = (Convert.ToDecimal(priceUSD) * 1000).ToString("0.00");
                    });
                    labelPCUSD13.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD13.Text = (Convert.ToDecimal(priceUSD) * 10000).ToString("0.00");
                    });
                    labelPCUSD14.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD14.Text = (Convert.ToDecimal(priceUSD) * 100000).ToString("0.00");
                    });
                    labelPCUSD15.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD15.Text = (Convert.ToDecimal(priceUSD) * 1000000).ToString("0.00");
                    });
                    labelPCUSD16.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD16.Text = (Convert.ToDecimal(priceUSD) * 10000000).ToString("0.00");
                    });
                    labelPCUSD17.Invoke((MethodInvoker)delegate
                    {
                        labelPCUSD17.Text = (Convert.ToDecimal(priceUSD) * 21000000).ToString("0.00");
                    });
                    #endregion
                    #region EUR list
                    labelPCEUR1.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR1.Text = (Convert.ToDecimal(priceEUR) / 100000000).ToString("0.00");
                    });
                    labelPCEUR2.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR2.Text = (Convert.ToDecimal(priceEUR) / 10000000).ToString("0.00");
                    });
                    labelPCEUR3.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR3.Text = (Convert.ToDecimal(priceEUR) / 1000000).ToString("0.00");
                    });
                    labelPCEUR4.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR4.Text = (Convert.ToDecimal(priceEUR) / 100000).ToString("0.00");
                    });
                    labelPCEUR5.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR5.Text = (Convert.ToDecimal(priceEUR) / 10000).ToString("0.00");
                    });
                    labelPCEUR6.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR6.Text = (Convert.ToDecimal(priceEUR) / 1000).ToString("0.00");
                    });
                    labelPCEUR7.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR7.Text = (Convert.ToDecimal(priceEUR) / 100).ToString("0.00");
                    });
                    labelPCEUR8.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR8.Text = (Convert.ToDecimal(priceEUR) / 10).ToString("0.00");
                    });
                    labelPCEUR9.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR9.Text = (Convert.ToDecimal(priceEUR)).ToString("0.00");
                    });
                    labelPCEUR10.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR10.Text = (Convert.ToDecimal(priceEUR) * 10).ToString("0.00");
                    });
                    labelPCEUR11.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR11.Text = (Convert.ToDecimal(priceEUR) * 100).ToString("0.00");
                    });
                    labelPCEUR12.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR12.Text = (Convert.ToDecimal(priceEUR) * 1000).ToString("0.00");
                    });
                    labelPCEUR13.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR13.Text = (Convert.ToDecimal(priceEUR) * 10000).ToString("0.00");
                    });
                    labelPCEUR14.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR14.Text = (Convert.ToDecimal(priceEUR) * 100000).ToString("0.00");
                    });
                    labelPCEUR15.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR15.Text = (Convert.ToDecimal(priceEUR) * 1000000).ToString("0.00");
                    });
                    labelPCEUR16.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR16.Text = (Convert.ToDecimal(priceEUR) * 10000000).ToString("0.00");
                    });
                    labelPCEUR17.Invoke((MethodInvoker)delegate
                    {
                        labelPCEUR17.Text = (Convert.ToDecimal(priceEUR) * 21000000).ToString("0.00");
                    });
                    #endregion
                    #region GBP list
                    labelPCGBP1.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP1.Text = (Convert.ToDecimal(priceGBP) / 100000000).ToString("0.00");
                    });
                    labelPCGBP2.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP2.Text = (Convert.ToDecimal(priceGBP) / 10000000).ToString("0.00");
                    });
                    labelPCGBP3.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP3.Text = (Convert.ToDecimal(priceGBP) / 1000000).ToString("0.00");
                    });
                    labelPCGBP4.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP4.Text = (Convert.ToDecimal(priceGBP) / 100000).ToString("0.00");
                    });
                    labelPCGBP5.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP5.Text = (Convert.ToDecimal(priceGBP) / 10000).ToString("0.00");
                    });
                    labelPCGBP6.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP6.Text = (Convert.ToDecimal(priceGBP) / 1000).ToString("0.00");
                    });
                    labelPCGBP7.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP7.Text = (Convert.ToDecimal(priceGBP) / 100).ToString("0.00");
                    });
                    labelPCGBP8.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP8.Text = (Convert.ToDecimal(priceGBP) / 10).ToString("0.00");
                    });
                    labelPCGBP9.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP9.Text = (Convert.ToDecimal(priceGBP)).ToString("0.00");
                    });
                    labelPCGBP10.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP10.Text = (Convert.ToDecimal(priceGBP) * 10).ToString("0.00");
                    });
                    labelPCGBP11.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP11.Text = (Convert.ToDecimal(priceGBP) * 100).ToString("0.00");
                    });
                    labelPCGBP12.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP12.Text = (Convert.ToDecimal(priceGBP) * 1000).ToString("0.00");
                    });
                    labelPCGBP13.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP13.Text = (Convert.ToDecimal(priceGBP) * 10000).ToString("0.00");
                    });
                    labelPCGBP14.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP14.Text = (Convert.ToDecimal(priceGBP) * 100000).ToString("0.00");
                    });
                    labelPCGBP15.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP15.Text = (Convert.ToDecimal(priceGBP) * 1000000).ToString("0.00");
                    });
                    labelPCGBP16.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP16.Text = (Convert.ToDecimal(priceGBP) * 10000000).ToString("0.00");
                    });
                    labelPCGBP17.Invoke((MethodInvoker)delegate
                    {
                        labelPCGBP17.Text = (Convert.ToDecimal(priceGBP) * 21000000).ToString("0.00");
                    });
                    #endregion
                    #region XAU list
                    labelPCXAU1.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU1.Text = (Convert.ToDecimal(priceXAU) / 100000000).ToString("0.00");
                    });
                    labelPCXAU2.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU2.Text = (Convert.ToDecimal(priceXAU) / 10000000).ToString("0.00");
                    });
                    labelPCXAU3.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU3.Text = (Convert.ToDecimal(priceXAU) / 1000000).ToString("0.00");
                    });
                    labelPCXAU4.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU4.Text = (Convert.ToDecimal(priceXAU) / 100000).ToString("0.00");
                    });
                    labelPCXAU5.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU5.Text = (Convert.ToDecimal(priceXAU) / 10000).ToString("0.00");
                    });
                    labelPCXAU6.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU6.Text = (Convert.ToDecimal(priceXAU) / 1000).ToString("0.00");
                    });
                    labelPCXAU7.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU7.Text = (Convert.ToDecimal(priceXAU) / 100).ToString("0.00");
                    });
                    labelPCXAU8.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU8.Text = (Convert.ToDecimal(priceXAU) / 10).ToString("0.00");
                    });
                    labelPCXAU9.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU9.Text = (Convert.ToDecimal(priceXAU)).ToString("0.00");
                    });
                    labelPCXAU10.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU10.Text = (Convert.ToDecimal(priceXAU) * 10).ToString("0.00");
                    });
                    labelPCXAU11.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU11.Text = (Convert.ToDecimal(priceXAU) * 100).ToString("0.00");
                    });
                    labelPCXAU12.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU12.Text = (Convert.ToDecimal(priceXAU) * 1000).ToString("0.00");
                    });
                    labelPCXAU13.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU13.Text = (Convert.ToDecimal(priceXAU) * 10000).ToString("0.00");
                    });
                    labelPCXAU14.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU14.Text = (Convert.ToDecimal(priceXAU) * 100000).ToString("0.00");
                    });
                    labelPCXAU15.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU15.Text = (Convert.ToDecimal(priceXAU) * 1000000).ToString("0.00");
                    });
                    labelPCXAU16.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU16.Text = (Convert.ToDecimal(priceXAU) * 10000000).ToString("0.00");
                    });
                    labelPCXAU17.Invoke((MethodInvoker)delegate
                    {
                        labelPCXAU17.Text = (Convert.ToDecimal(priceXAU) * 21000000).ToString("0.00");
                    });
                    #endregion
                    #region calculate fields derived from user input
                    SetCalculatedFiatAmounts();
                    SetCalculatedUSDAmount();
                    SetCalculatedEURAmount();
                    SetCalculatedGBPAmount();
                    SetCalculatedXAUAmount();
                    #endregion
                }
            }
            catch (WebException ex)
            {
                HandleException(ex, "getting market data");
            }
        }
        #endregion
        #region clear contents of textboxes on focus
        private void TextBoxConvertUSDtoBTC_Enter(object sender, EventArgs e)
        {
            textBoxConvertUSDtoBTC.Invoke((MethodInvoker)delegate
            {
                textBoxConvertUSDtoBTC.Text = "";
            });
        }

        private void TextBoxConvertEURtoBTC_Enter(object sender, EventArgs e)
        {
            textBoxConvertEURtoBTC.Invoke((MethodInvoker)delegate
            {
                textBoxConvertEURtoBTC.Text = "";
            });
        }

        private void TextBoxConvertGBPtoBTC_Enter(object sender, EventArgs e)
        {
            textBoxConvertGBPtoBTC.Invoke((MethodInvoker)delegate
            {
                textBoxConvertGBPtoBTC.Text = "";
            });
        }

        private void TextBoxConvertXAUtoBTC_Enter(object sender, EventArgs e)
        {
            textBoxConvertXAUtoBTC.Invoke((MethodInvoker)delegate
            {
                textBoxConvertXAUtoBTC.Text = "";
            });
        }

        private void TextBoxConvertBTCtoFiat_Enter(object sender, EventArgs e)
        {
            textBoxConvertBTCtoFiat.Invoke((MethodInvoker)delegate
            {
                textBoxConvertBTCtoFiat.Text = "";
            });
        }
        #endregion
        #region set textboxes to 0 if left empty by user
        private void TextBoxConvertUSDtoBTC_Leave(object sender, EventArgs e)
        {
            if (textBoxConvertUSDtoBTC.Text == "")
            {
                textBoxConvertUSDtoBTC.Invoke((MethodInvoker)delegate
                {
                    textBoxConvertUSDtoBTC.Text = "0";
                });
            }
        }

        private void TextBoxConvertEURtoBTC_Leave(object sender, EventArgs e)
        {
            if (textBoxConvertEURtoBTC.Text == "")
            {
                textBoxConvertEURtoBTC.Invoke((MethodInvoker)delegate
                {
                    textBoxConvertEURtoBTC.Text = "0";
                });
            }
        }

        private void TextBoxConvertGBPtoBTC_Leave(object sender, EventArgs e)
        {
            if (textBoxConvertGBPtoBTC.Text == "")
            {
                textBoxConvertGBPtoBTC.Invoke((MethodInvoker)delegate
                {
                    textBoxConvertGBPtoBTC.Text = "0";
                });
            }
        }

        private void TextBoxConvertXAUtoBTC_Leave(object sender, EventArgs e)
        {
            if (textBoxConvertXAUtoBTC.Text == "")
            {
                textBoxConvertXAUtoBTC.Invoke((MethodInvoker)delegate
                {
                    textBoxConvertXAUtoBTC.Text = "0";
                });
            }
        }

        private void TextBoxConvertBTCtoFiat_Leave(object sender, EventArgs e)
        {
            if (textBoxConvertBTCtoFiat.Text == "")
            {
                textBoxConvertBTCtoFiat.Invoke((MethodInvoker)delegate
                {
                    textBoxConvertBTCtoFiat.Text = "0";
                });
            }
        }
        #endregion
        #region validate user inputs
        private void CurrencyTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                string text = textBox.Text;

                // Allow digits, backspace, and decimal point
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                    return;
                }

                // Only allow one decimal point
                if (e.KeyChar == '.' && text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }

                // Get the current caret position
                int caretPos = textBox.SelectionStart;

                // Check if the new character is being inserted after the decimal point
                if (text.Contains('.') && caretPos > text.IndexOf('.'))
                {
                    // Allow two digits after the decimal point
                    int decimalPlaces = text.Length - text.IndexOf('.') - 1;
                    if (decimalPlaces >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                // Combine the current text with the newly typed character
                string newText = text.Substring(0, caretPos) + e.KeyChar + text.Substring(caretPos);

                // Remove any commas in the text
                string strippedText = newText.Replace(",", "");

                // max = 100 trillion
                if (!string.IsNullOrEmpty(strippedText) && decimal.TryParse(strippedText, out decimal value))
                {
                    if (value > 100000000000000)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            catch (WebException ex)
            {
                HandleException(ex, "CurrencyTextBoxes_KeyPress - validating currency input");
            }
        }

        private void TextBoxConvertBTCtoFiat_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                string text = textBox.Text;

                // Allow digits, backspace, and decimal point
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                    return;
                }

                // Only allow one decimal point
                if (e.KeyChar == '.' && text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }

                // Get the current caret position
                int caretPos = textBox.SelectionStart;

                // Check if the new character is being inserted after the decimal point
                if (text.Contains('.') && caretPos > text.IndexOf('.'))
                {
                    // Allow 8 digits after the decimal point
                    int decimalPlaces = text.Length - text.IndexOf('.') - 1;
                    if (decimalPlaces >= 8)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                // Combine the current text with the newly typed character
                string newText = text.Substring(0, caretPos) + e.KeyChar + text.Substring(caretPos);

                // Remove any commas in the text
                string strippedText = newText.Replace(",", "");

                // max = 21 million
                if (!string.IsNullOrEmpty(strippedText) && decimal.TryParse(strippedText, out decimal value))
                {
                    if (value > 21000000)
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
            catch (WebException ex)
            {
                HandleException(ex, "textBoxConvertBTCtoFiat_KeyPress - validating BTC input");
            }
        }
        #endregion
        #region respond to and calculate from user inputs
        private void TextBoxConvertBTCtoFiat_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConvertBTCtoFiat.Text != "")
            {
                SetCalculatedFiatAmounts();
            }
        }

        private void SetCalculatedFiatAmounts()
        {
            labelPCUSDcustom.Invoke((MethodInvoker)delegate
            {
                labelPCUSDcustom.Text = (Convert.ToDecimal(textBoxConvertBTCtoFiat.Text) * Convert.ToDecimal(labelPCUSD9.Text)).ToString("0.00");
            });
            labelPCEURcustom.Invoke((MethodInvoker)delegate
            {
                labelPCEURcustom.Text = (Convert.ToDecimal(textBoxConvertBTCtoFiat.Text) * Convert.ToDecimal(labelPCEUR9.Text)).ToString("0.00");
            });
            labelPCGBPcustom.Invoke((MethodInvoker)delegate
            {
                labelPCGBPcustom.Text = (Convert.ToDecimal(textBoxConvertBTCtoFiat.Text) * Convert.ToDecimal(labelPCGBP9.Text)).ToString("0.00");
            });
            labelPCXAUcustom.Invoke((MethodInvoker)delegate
            {
                labelPCXAUcustom.Text = (Convert.ToDecimal(textBoxConvertBTCtoFiat.Text) * Convert.ToDecimal(labelPCXAU9.Text)).ToString("0.00");
            });
        }

        private void FiatAmountTextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConvertUSDtoBTC.Text != "")
            {
                SetCalculatedUSDAmount();
            }
            if (textBoxConvertEURtoBTC.Text != "")
            {
                SetCalculatedEURAmount();
            }
            if (textBoxConvertGBPtoBTC.Text != "")
            {
                SetCalculatedGBPAmount();
            }
            if (textBoxConvertXAUtoBTC.Text != "")
            {
                SetCalculatedXAUAmount();
            }
        }

        private void SetCalculatedUSDAmount()
        {
            if (labelPCUSD9.Text != "USD" && Convert.ToDecimal(labelPCUSD9.Text) > 0)
            {
                lblCalculatedUSDFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedUSDFromBTCAmount.Text = (Convert.ToDecimal(textBoxConvertUSDtoBTC.Text) / Convert.ToDecimal(labelPCUSD9.Text)).ToString("0.00000000");
                });
                label267.Invoke((MethodInvoker)delegate
                {
                    label267.Text = "$" + textBoxConvertUSDtoBTC.Text + " USD (US dollar) =";
                });
                lblCalculatedUSDFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedUSDFromBTCAmount.Location = new Point(label267.Location.X + label267.Width - 4, lblCalculatedUSDFromBTCAmount.Location.Y);
                });
                label273.Invoke((MethodInvoker)delegate
                {
                    label273.Location = new Point(lblCalculatedUSDFromBTCAmount.Location.X + lblCalculatedUSDFromBTCAmount.Width, label273.Location.Y);
                });
            }
        }
        private void SetCalculatedEURAmount()
        {
            if (labelPCEUR9.Text != "EUR" && Convert.ToDecimal(labelPCEUR9.Text) > 0)
            {
                lblCalculatedEURFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedEURFromBTCAmount.Text = (Convert.ToDecimal(textBoxConvertEURtoBTC.Text) / Convert.ToDecimal(labelPCEUR9.Text)).ToString("0.00000000");
                });
                label270.Invoke((MethodInvoker)delegate
                {
                    label270.Text = "€" + textBoxConvertEURtoBTC.Text + " EUR (European euro) =";
                });
                lblCalculatedEURFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedEURFromBTCAmount.Location = new Point(label270.Location.X + label270.Width - 4, lblCalculatedEURFromBTCAmount.Location.Y);
                });
                label274.Invoke((MethodInvoker)delegate
                {
                    label274.Location = new Point(lblCalculatedEURFromBTCAmount.Location.X + lblCalculatedEURFromBTCAmount.Width, label274.Location.Y);
                });
            }
        }
        private void SetCalculatedGBPAmount()
        {
            if (labelPCGBP9.Text != "GBP" && Convert.ToDecimal(labelPCGBP9.Text) > 0)
            {
                lblCalculatedGBPFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedGBPFromBTCAmount.Text = (Convert.ToDecimal(textBoxConvertGBPtoBTC.Text) / Convert.ToDecimal(labelPCGBP9.Text)).ToString("0.00000000");
                });
                label269.Invoke((MethodInvoker)delegate
                {
                    label269.Text = "£" + textBoxConvertGBPtoBTC.Text + " GBP (British pound sterling) =";
                });
                lblCalculatedGBPFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedGBPFromBTCAmount.Location = new Point(label269.Location.X + label269.Width - 4, lblCalculatedGBPFromBTCAmount.Location.Y);
                });
                label276.Invoke((MethodInvoker)delegate
                {
                    label276.Location = new Point(lblCalculatedGBPFromBTCAmount.Location.X + lblCalculatedGBPFromBTCAmount.Width, label276.Location.Y);
                });
            }
        }
        private void SetCalculatedXAUAmount()
        {
            if (labelPCXAU9.Text != "XAU" && Convert.ToDecimal(labelPCXAU9.Text) > 0)
            {
                lblCalculatedXAUFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedXAUFromBTCAmount.Text = (Convert.ToDecimal(textBoxConvertXAUtoBTC.Text) / Convert.ToDecimal(labelPCXAU9.Text)).ToString("0.00000000");
                });
                label268.Invoke((MethodInvoker)delegate
                {
                    label268.Text = "🪙" + textBoxConvertXAUtoBTC.Text + " XAU (ounce of gold) =";
                });
                lblCalculatedXAUFromBTCAmount.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedXAUFromBTCAmount.Location = new Point(label268.Location.X + label268.Width - 4, lblCalculatedXAUFromBTCAmount.Location.Y);
                });
                label275.Invoke((MethodInvoker)delegate
                {
                    label275.Location = new Point(lblCalculatedXAUFromBTCAmount.Location.X + lblCalculatedXAUFromBTCAmount.Width, label275.Location.Y);
                });
            }
        }
        #endregion
        #endregion
        #region show/hide chart loading panel
        private void ShowChartLoadingPanel()
        {
            pictureBoxChartLoadingAnimation.Enabled = true;
            panelChartLoading.Visible = true;
        }

        private void HideChartLoadingPanel()
        {
            pictureBoxChartLoadingAnimation.Enabled = false;
            panelChartLoading.Visible = false;
        }
        #endregion
        #region disable/enable charts, time periods, hide panels, etc
        private void EnableAllCharts()
        {
            btnChartHashrate.Enabled = true;
            btnChartDifficulty.Enabled = true;
            btnChartFeeRates.Enabled = true;
            btnChartPrice.Enabled = true;
            btnChartReward.Enabled = true;
            btnChartBlockFees.Enabled = true;
            btnChartCirculation.Enabled = true;
            btnChartBlockSize.Enabled = true;
            btnChartUniqueAddresses.Enabled = true;
            btnChartNodesByNetwork.Enabled = true;
            btnChartLightningCapacity.Enabled = true;
            btnChartLightningChannels.Enabled = true;
            btnChartUTXO.Enabled = true;
            btnChartNodesByCountry.Enabled = true;
            btnChartPoolsRanking.Enabled = true;
            btnChartMarketCap.Enabled = true;
            btnPriceConverter.Enabled = true;
        }

        private void ClearAllChartData()
        {
            formsPlot1.Plot.Clear();
            formsPlot2.Plot.Clear();
            formsPlot3.Plot.Clear();
        }

        private void HideAllChartKeysAndPanels()
        {
            panelHashrateScaleButtons.Visible = false;
            panelChartUTXOScaleButtons.Visible = false;
            panelUniqueAddressesScaleButtons.Visible = false;
            panelPriceScaleButtons.Visible = false;
            panelLightningNodeNetwork.Visible = false;
            panelCirculationKey.Visible = false;
            panelFeeRatesKey.Visible = false;
            panelChartMarketCapScaleButtons.Visible = false;
            panelChartDifficultyScaleButtons.Visible = false;
            panelPriceConverter.Visible = false;
        }

        private void DisableIrrelevantTimePeriods()
        {
            try
            {
                if (chartType == "hashrate" || chartType == "hashratelog")
                {
                    btnChartPeriod24h.Enabled = false;
                    btnChartPeriod3d.Enabled = false;
                    btnChartPeriod1w.Enabled = false;
                    btnChartPeriod1m.Enabled = false;
                    if (chartPeriod != "3m")
                    {
                        btnChartPeriod3m.Enabled = true;
                    }
                    if (chartPeriod != "6m")
                    {
                        btnChartPeriod6m.Enabled = true;
                    }
                    if (chartPeriod != "1y")
                    {
                        btnChartPeriod1y.Enabled = true;
                    }
                    if (chartPeriod != "2y")
                    {
                        btnChartPeriod2y.Enabled = true;
                    }
                    if (chartPeriod != "3y")
                    {
                        btnChartPeriod3y.Enabled = true;
                    }
                    if (chartPeriod != "all")
                    {
                        btnChartPeriodAll.Enabled = true;
                    }
                }
                else
                {
                    if (chartType == "difficulty" || chartType == "difficultylog")
                    {
                        btnChartPeriod24h.Enabled = false;
                        btnChartPeriod3d.Enabled = false;
                        btnChartPeriod1w.Enabled = false;
                        btnChartPeriod1m.Enabled = false;
                        if (chartPeriod != "3m")
                        {
                            btnChartPeriod3m.Enabled = true;
                        }
                        if (chartPeriod != "6m")
                        {
                            btnChartPeriod6m.Enabled = true;
                        }
                        if (chartPeriod != "1y")
                        {
                            btnChartPeriod1y.Enabled = true;
                        }
                        if (chartPeriod != "2y")
                        {
                            btnChartPeriod2y.Enabled = true;
                        }
                        if (chartPeriod != "3y")
                        {
                            btnChartPeriod3y.Enabled = true;
                        }
                        if (chartPeriod != "all")
                        {
                            btnChartPeriodAll.Enabled = true;
                        }
                    }
                    else
                    {
                        if (chartType == "price" || chartType == "pricelog" || chartType == "circulation" || chartType == "addresses" || chartType == "addresseslog" || chartType == "utxo" || chartType == "utxolog" || chartType == "marketcap" || chartType == "marketcaplog")
                        {
                            btnChartPeriod24h.Enabled = false;
                            btnChartPeriod3d.Enabled = false;
                            btnChartPeriod1w.Enabled = false;
                            btnChartPeriod2y.Enabled = false;
                            if (chartPeriod != "1m")
                            {
                                btnChartPeriod1m.Enabled = true;
                            }
                            if (chartPeriod != "3m")
                            {
                                btnChartPeriod3m.Enabled = true;
                            }
                            if (chartPeriod != "6m")
                            {
                                btnChartPeriod6m.Enabled = true;
                            }
                            if (chartPeriod != "1y")
                            {
                                btnChartPeriod1y.Enabled = true;
                            }
                            if (chartPeriod != "3y")
                            {
                                btnChartPeriod3y.Enabled = true;
                            }
                            if (chartPeriod != "all")
                            {
                                btnChartPeriodAll.Enabled = true;
                            }
                        }
                        else
                        {
                            if (chartType == "nodesbycountry")
                            {
                                if (chartPeriod != "24h")
                                {
                                    btnChartPeriod24h.Enabled = false;
                                }
                                if (chartPeriod != "3d")
                                {
                                    btnChartPeriod3d.Enabled = false;
                                }
                                if (chartPeriod != "1w")
                                {
                                    btnChartPeriod1w.Enabled = false;
                                }
                                if (chartPeriod != "1m")
                                {
                                    btnChartPeriod1m.Enabled = false;
                                }
                                if (chartPeriod != "3m")
                                {
                                    btnChartPeriod3m.Enabled = false;
                                }
                                if (chartPeriod != "6m")
                                {
                                    btnChartPeriod6m.Enabled = false;
                                }
                                if (chartPeriod != "1y")
                                {
                                    btnChartPeriod1y.Enabled = false;
                                }
                                if (chartPeriod != "2y")
                                {
                                    btnChartPeriod2y.Enabled = false;
                                }
                                if (chartPeriod != "3y")
                                {
                                    btnChartPeriod3y.Enabled = false;
                                }
                                if (chartPeriod != "all")
                                {
                                    btnChartPeriodAll.Enabled = false;
                                }
                            }
                            else
                            {
                                if (chartType == "lightningcapacity" || chartType == "lightningchannels" || chartType == "lightningnodesbynetwork")
                                {
                                    btnChartPeriod24h.Enabled = false;
                                    btnChartPeriod3d.Enabled = false;
                                    btnChartPeriod1w.Enabled = false;
                                    if (chartPeriod != "1m")
                                    {
                                        btnChartPeriod1m.Enabled = true;
                                    }
                                    if (chartPeriod != "3m")
                                    {
                                        btnChartPeriod3m.Enabled = true;
                                    }
                                    if (chartPeriod != "6m")
                                    {
                                        btnChartPeriod6m.Enabled = true;
                                    }
                                    if (chartPeriod != "1y")
                                    {
                                        btnChartPeriod1y.Enabled = true;
                                    }
                                    if (chartPeriod != "2y")
                                    {
                                        btnChartPeriod2y.Enabled = true;
                                    }
                                    if (chartPeriod != "3y")
                                    {
                                        btnChartPeriod3y.Enabled = true;
                                    }
                                    if (chartPeriod != "all")
                                    {
                                        btnChartPeriodAll.Enabled = true;
                                    }
                                }

                                else
                                {
                                    if (chartPeriod != "24h")
                                    {
                                        btnChartPeriod24h.Enabled = true;
                                    }
                                    if (chartPeriod != "3d")
                                    {
                                        btnChartPeriod3d.Enabled = true;
                                    }
                                    if (chartPeriod != "1w")
                                    {
                                        btnChartPeriod1w.Enabled = true;
                                    }
                                    if (chartPeriod != "1m")
                                    {
                                        btnChartPeriod1m.Enabled = true;
                                    }
                                    if (chartPeriod != "3m")
                                    {
                                        btnChartPeriod3m.Enabled = true;
                                    }
                                    if (chartPeriod != "6m")
                                    {
                                        btnChartPeriod6m.Enabled = true;
                                    }
                                    if (chartPeriod != "1y")
                                    {
                                        btnChartPeriod1y.Enabled = true;
                                    }
                                    if (chartPeriod != "2y")
                                    {
                                        btnChartPeriod2y.Enabled = true;
                                    }
                                    if (chartPeriod != "3y")
                                    {
                                        btnChartPeriod3y.Enabled = true;
                                    }
                                    if (chartPeriod != "all")
                                    {
                                        btnChartPeriodAll.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "disabling irrelevant chart time periods");
            }
        }

        private void DisableEnableChartButtons(string enableOrDisableAllButtons)
        {
            try
            {
                if (enableOrDisableAllButtons == "disable")
                {
                    ignoreMouseMoveOnChart = true;
                    // get current state of buttons before disabling them
                    btnChartBlockFeesWasEnabled = btnChartBlockFees.Enabled;
                    btnChartDifficultyWasEnabled = btnChartDifficulty.Enabled;
                    btnChartHashrateWasEnabled = btnChartHashrate.Enabled;
                    btnChartPriceWasEnabled = btnChartPrice.Enabled;
                    btnChartRewardWasEnabled = btnChartReward.Enabled;
                    btnChartFeeRatesWasEnabled = btnChartFeeRates.Enabled;
                    btnChartCirculationWasEnabled = btnChartCirculation.Enabled;
                    btnChartBlockSizeWasEnabled = btnChartBlockSize.Enabled;
                    btnChartPeriod1mWasEnabled = btnChartPeriod1m.Enabled;
                    btnChartPeriod1wWasEnabled = btnChartPeriod1w.Enabled;
                    btnChartPeriod1yWasEnabled = btnChartPeriod1y.Enabled;
                    btnChartPeriod24hWasEnabled = btnChartPeriod24h.Enabled;
                    btnChartPeriod2yWasEnabled = btnChartPeriod2y.Enabled;
                    btnChartPeriod3dWasEnabled = btnChartPeriod3d.Enabled;
                    btnChartPeriod3mWasEnabled = btnChartPeriod3m.Enabled;
                    btnChartPeriod3yWasEnabled = btnChartPeriod3y.Enabled;
                    btnChartPeriod6mWasEnabled = btnChartPeriod6m.Enabled;
                    btnChartPeriodAllWasEnabled = btnChartPeriodAll.Enabled;
                    btnChartUniqueAddressesWasEnabled = btnChartUniqueAddresses.Enabled;
                    btnHashrateScaleLogWasEnabled = btnHashrateScaleLog.Enabled;
                    btnHashrateScaleLinearWasEnabled = btnHashrateScaleLinear.Enabled;
                    btnChartAddressScaleLinearWasEnabled = btnChartAddressScaleLinear.Enabled;
                    btnChartAddressScaleLogWasEnabled = btnChartAddressScaleLog.Enabled;
                    btnPriceChartScaleLogWasEnabled = btnPriceChartScaleLog.Enabled;
                    btnPriceChartScaleLinearWasEnabled = btnPriceChartScaleLinear.Enabled;
                    btnChartUTXOWasEnabled = btnChartUTXO.Enabled;
                    btnChartPoolsRankingWasEnabled = btnChartPoolsRanking.Enabled;
                    btnChartNodesByNetworkWasEnabled = btnChartNodesByNetwork.Enabled;
                    btnChartNodesByCountryWasEnabled = btnChartNodesByCountry.Enabled;
                    btnChartLightningCapacityWasEnabled = btnChartLightningCapacity.Enabled;
                    btnChartLightningChannelsWasEnabled = btnChartLightningChannels.Enabled;
                    btnChartMarketCapWasEnabled = btnChartMarketCap.Enabled;
                    btnChartMarketCapLogWasEnabled = btnChartMarketCapScaleLog.Enabled;
                    btnChartDifficultyLinearWasEnabled = btnChartDifficultyLinear.Enabled;
                    btnChartDifficultyLogWasEnabled = btnChartDifficultyLog.Enabled;
                    btnPriceConverterWasEnabled = btnPriceConverter.Enabled;

                    //disable them all
                    btnChartBlockFees.Enabled = false;
                    btnChartDifficulty.Enabled = false;
                    btnChartHashrate.Enabled = false;
                    btnChartPrice.Enabled = false;
                    btnChartReward.Enabled = false;
                    btnChartFeeRates.Enabled = false;
                    btnChartCirculation.Enabled = false;
                    btnChartPeriod1m.Enabled = false;
                    btnChartPeriod1w.Enabled = false;
                    btnChartPeriod1y.Enabled = false;
                    btnChartPeriod24h.Enabled = false;
                    btnChartPeriod2y.Enabled = false;
                    btnChartPeriod3d.Enabled = false;
                    btnChartPeriod3m.Enabled = false;
                    btnChartPeriod3y.Enabled = false;
                    btnChartPeriod6m.Enabled = false;
                    btnChartPeriodAll.Enabled = false;
                    btnChartBlockSize.Enabled = false;
                    btnChartUniqueAddresses.Enabled = false;
                    btnHashrateScaleLinear.Enabled = false;
                    btnHashrateScaleLog.Enabled = false;
                    btnChartAddressScaleLinear.Enabled = false;
                    btnChartAddressScaleLog.Enabled = false;
                    btnPriceChartScaleLog.Enabled = false;
                    btnPriceChartScaleLinear.Enabled = false;
                    btnChartUTXO.Enabled = false;
                    btnChartPoolsRanking.Enabled = false;
                    btnChartNodesByNetwork.Enabled = false;
                    btnChartNodesByCountry.Enabled = false;
                    btnChartLightningCapacity.Enabled = false;
                    btnChartLightningChannels.Enabled = false;
                    btnChartMarketCap.Enabled = false;
                    btnChartMarketCapScaleLog.Enabled = false;
                    btnChartDifficultyLinear.Enabled = false;
                    btnChartDifficultyLog.Enabled = false;
                    btnPriceConverter.Enabled = false;
                }
                else
                {
                    // use previously saved states to reinstate buttons

                    btnChartBlockFees.Enabled = btnChartBlockFeesWasEnabled;
                    btnChartDifficulty.Enabled = btnChartDifficultyWasEnabled;
                    btnChartHashrate.Enabled = btnChartHashrateWasEnabled;
                    btnChartPrice.Enabled = btnChartPriceWasEnabled;
                    btnChartReward.Enabled = btnChartRewardWasEnabled;
                    btnChartFeeRates.Enabled = btnChartFeeRatesWasEnabled;
                    btnChartCirculation.Enabled = btnChartCirculationWasEnabled;
                    btnChartBlockSize.Enabled = btnChartBlockSizeWasEnabled;
                    btnChartPeriod1m.Enabled = btnChartPeriod1mWasEnabled;
                    btnChartPeriod1w.Enabled = btnChartPeriod1wWasEnabled;
                    btnChartPeriod1y.Enabled = btnChartPeriod1yWasEnabled;
                    btnChartPeriod24h.Enabled = btnChartPeriod24hWasEnabled;
                    btnChartPeriod2y.Enabled = btnChartPeriod2yWasEnabled;
                    btnChartPeriod3d.Enabled = btnChartPeriod3dWasEnabled;
                    btnChartPeriod3m.Enabled = btnChartPeriod3mWasEnabled;
                    btnChartPeriod3y.Enabled = btnChartPeriod3yWasEnabled;
                    btnChartPeriod6m.Enabled = btnChartPeriod6mWasEnabled;
                    btnChartPeriodAll.Enabled = btnChartPeriodAllWasEnabled;
                    btnChartUniqueAddresses.Enabled = btnChartUniqueAddressesWasEnabled;
                    btnChartAddressScaleLinear.Enabled = btnChartAddressScaleLinearWasEnabled;
                    btnChartAddressScaleLog.Enabled = btnChartAddressScaleLogWasEnabled;
                    btnHashrateScaleLinear.Enabled = btnHashrateScaleLinearWasEnabled;
                    btnHashrateScaleLog.Enabled = btnHashrateScaleLogWasEnabled;
                    btnPriceChartScaleLog.Enabled = btnPriceChartScaleLogWasEnabled;
                    btnPriceChartScaleLinear.Enabled = btnPriceChartScaleLinearWasEnabled;
                    btnChartUTXO.Enabled = btnChartUTXOWasEnabled;
                    btnChartPoolsRanking.Enabled = btnChartPoolsRankingWasEnabled;
                    btnChartNodesByNetwork.Enabled = btnChartNodesByNetworkWasEnabled;
                    btnChartNodesByCountry.Enabled = btnChartNodesByCountryWasEnabled;
                    btnChartLightningCapacity.Enabled = btnChartLightningCapacityWasEnabled;
                    btnChartLightningChannels.Enabled = btnChartLightningChannelsWasEnabled;
                    btnChartMarketCap.Enabled = btnChartMarketCapWasEnabled;
                    btnChartMarketCapScaleLog.Enabled = btnChartMarketCapLogWasEnabled;
                    btnChartDifficultyLinear.Enabled = btnChartDifficultyLinearWasEnabled;
                    btnChartDifficultyLog.Enabled = btnChartDifficultyLogWasEnabled;
                    btnPriceConverter.Enabled = btnPriceConverterWasEnabled;
                    ignoreMouseMoveOnChart = false;
                }
                // disable charts where corresponding API is disabled
                if (RunBlockchainInfoEndpointAPI == false)
                {
                    DisableChartsThatDontUseMempoolSpace();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "changing chart button states");
            }
        }

        private void DisableChartsThatDontUseMempoolSpace()
        {
            try
            {
                btnPriceConverter.Enabled = false;
                btnChartCirculation.Enabled = false;
                btnChartMarketCap.Enabled = false;
                btnChartPrice.Enabled = false;
                btnChartUniqueAddresses.Enabled = false;
                btnChartUTXO.Enabled = false;
                pictureBoxChartCirculation.Enabled = false;
                pictureBoxChartCirculation.Invoke((MethodInvoker)delegate
                {
                    pictureBoxChartCirculation.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxHeaderPriceChart.Enabled = false;
                pictureBoxHeaderPriceChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderPriceChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxPriceChart.Enabled = false;
                pictureBoxPriceChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxPriceChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxConverterChart.Enabled = false;
                pictureBoxConverterChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxConverterChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxMarketCapChart.Enabled = false;
                pictureBoxMarketCapChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxMarketCapChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxUniqueAddressesChart.Enabled = false;
                pictureBoxUniqueAddressesChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxUniqueAddressesChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxHeaderConverterChart.Enabled = false;
                pictureBoxHeaderConverterChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderConverterChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxHeaderBlockSizeChart.Enabled = false;
                pictureBoxHeaderBlockSizeChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderBlockSizeChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
                pictureBoxHeaderMarketCapChart.Enabled = false;
                pictureBoxHeaderMarketCapChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderMarketCapChart.BackgroundImage = Properties.Resources.graphIcondisabled;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "Disabling non-mempool.space charts");
            }

        }

        private void EnableChartsThatDontUseMempoolSpace()
        {
            try
            {
                btnPriceConverter.Enabled = true;
                btnChartCirculation.Enabled = true;
                btnChartMarketCap.Enabled = true;
                btnChartPrice.Enabled = true;
                btnChartUniqueAddresses.Enabled = true;
                btnChartUTXO.Enabled = true;
                pictureBoxChartCirculation.Enabled = true;
                pictureBoxChartCirculation.Invoke((MethodInvoker)delegate
                {
                    pictureBoxChartCirculation.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxConverterChart.Enabled = true;
                pictureBoxConverterChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxConverterChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxHeaderPriceChart.Enabled = true;
                pictureBoxHeaderPriceChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderPriceChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxPriceChart.Enabled = true;
                pictureBoxPriceChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxPriceChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxMarketCapChart.Enabled = true;
                pictureBoxMarketCapChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxMarketCapChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxUniqueAddressesChart.Enabled = true;
                pictureBoxUniqueAddressesChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxUniqueAddressesChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxHeaderConverterChart.Enabled = true;
                pictureBoxHeaderConverterChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderConverterChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxHeaderBlockSizeChart.Enabled = true;
                pictureBoxHeaderBlockSizeChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderBlockSizeChart.BackgroundImage = Properties.Resources.graphIcon;
                });
                pictureBoxHeaderMarketCapChart.Enabled = true;
                pictureBoxHeaderMarketCapChart.Invoke((MethodInvoker)delegate
                {
                    pictureBoxHeaderMarketCapChart.BackgroundImage = Properties.Resources.graphIcon;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "Enabling non-mempool.space charts");
            }
        }

        #endregion
        #region prepare for linear scale chart
        private void PrepareLinearScaleChart()
        {
            try
            {
                // switch to linear scaling in case it was log before
                formsPlot1.Plot.YAxis.MinorLogScale(false);
                formsPlot1.Plot.YAxis.MajorGrid(false);
                formsPlot1.Plot.YAxis.MinorGrid(false);

                // Define a new tick label formatter for the linear scale
                static string linearTickLabels(double y) => y.ToString("N0");
                formsPlot1.Plot.YAxis.TickLabelFormat(linearTickLabels);

                // Revert back to automatic data area
                formsPlot1.Plot.ResetLayout();
                formsPlot1.Plot.AxisAuto();
            }
            catch (Exception ex)
            {
                HandleException(ex, "switching to linear scale chart");
            }
        }
        #endregion
        #region change chart time period
        private void BtnChartPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                Control[] chartPeriodButtons = { btnChartPeriod24h, btnChartPeriod3d, btnChartPeriod1w, btnChartPeriod1m, btnChartPeriod3m, btnChartPeriod6m, btnChartPeriod1y, btnChartPeriod2y, btnChartPeriod3y, btnChartPeriodAll };

                Button clickedButton = (Button)sender;
                clickedButton.Enabled = false;

                foreach (Control control in chartPeriodButtons)
                {
                    if (control is Button && control == clickedButton)
                    {
                        chartPeriod = clickedButton.Text;
                    }
                    if (control is Button && control != clickedButton)
                    {
                        control.Enabled = true;
                    }
                }

                if (chartType == "hashrate")
                {
                    BtnChartHashrate_Click(sender, e);
                }
                if (chartType == "hashratelog")
                {
                    BtnHashrateScaleLog_Click(sender, e);
                }
                if (chartType == "blockfees")
                {
                    BtnChartBlockFees_Click(sender, e);
                }
                if (chartType == "difficulty")
                {
                    BtnChartDifficulty_Click(sender, e);
                }
                if (chartType == "difficultylog")
                {
                    BtnChartDifficultyLog_Click(sender, e);
                }
                if (chartType == "price")
                {
                    BtnChartPrice_Click(sender, e);
                }
                if (chartType == "pricelog")
                {
                    BtnChartPriceLog_Click(sender, e);
                }
                if (chartType == "reward")
                {
                    BtnChartReward_Click(sender, e);
                }
                if (chartType == "feerates")
                {
                    BtnChartFeeRates_Click(sender, e);
                }
                if (chartType == "blocksize")
                {
                    BtnChartBlockSize_Click(sender, e);
                }
                if (chartType == "addresses")
                {
                    BtnChartUniqueAddresses_Click(sender, e);
                }
                if (chartType == "addresseslog")
                {
                    BtnChartUniqueAddressesLog_Click(sender, e);
                }
                if (chartType == "poolranking")
                {
                    BtnChartPoolsRanking_Click(sender, e);
                }
                if (chartType == "lightningnodesbynetwork")
                {
                    BtnChartNodesByNetwork_Click(sender, e);
                }
                if (chartType == "lightningcapacity")
                {
                    BtnChartLightningCapacity_Click(sender, e);
                }
                if (chartType == "lightningchannels")
                {
                    BtnChartLightningChannels_Click(sender, e);
                }
                if (chartType == "marketcap")
                {
                    BtnChartMarketCap_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "switching chart time period");
            }
        }
        #endregion
        #region track mouse position to show nearest data point
        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!ignoreMouseMoveOnChart)
                {
                    if (chartType != "feerates" && chartType != "poolranking" && chartType != "lightningnodesbynetwork" && chartType != "nodesbycountry")
                    {
                        // determine point nearest the cursor
                        (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
                        double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
                        (double pointX, double pointY, int pointIndex) = scatter.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

                        // place the highlight over the point of interest
                        HighlightedPoint.X = pointX;
                        HighlightedPoint.Y = pointY;
                        HighlightedPoint.IsVisible = true;

                        // render if the highlighted point chnaged
                        if (LastHighlightedIndex != pointIndex)
                        {
                            LastHighlightedIndex = pointIndex;
                            formsPlot1.Render();
                        }
                        // Convert pointX to a DateTime object
                        DateTime pointXDate = DateTime.FromOADate(pointX);

                        // Format the DateTime object using the desired format string
                        string formattedPointX = pointXDate.ToString("yyyy-MM-dd");

                        if (chartType == "pricelog" || chartType == "addresseslog" || chartType == "utxolog" || chartType == "marketcaplog" || chartType == "hashratelog" || chartType == "difficultylog")
                        {
                            double originalY = Math.Pow(10, pointY); // Convert back to the original scale
                            lblChartMousePositionData.Text = $"{originalY:N2} ({formattedPointX})";
                        }
                        else
                        {
                            // update coordinate data label below chart
                            lblChartMousePositionData.Text = $"{pointY:N2} ({formattedPointX})";
                        }
                        lblChartMousePositionData.Location = new Point(765 - lblChartMousePositionData.Width - btnSaveChart.Width - 10, lblChartMousePositionData.Location.Y);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "rendering mouse-over chart coordinates data");
            }
        }
        #endregion
        #region save chart image
        private void BtnSaveChart_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                FileName = "SATSuma.png",
                Filter = "PNG Files (*.png)|*.png;*.png" +
                 "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                 "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                 "|All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (formsPlot1.Visible == true)
                {
                    formsPlot1.Plot.SaveFig(sfd.FileName);
                }
                if (formsPlot2.Visible == true)
                {
                    formsPlot2.Plot.SaveFig(sfd.FileName);
                }
                if (formsPlot3.Visible == true)
                {
                    formsPlot3.Plot.SaveFig(sfd.FileName);
                }
            }

        }
        #endregion
        #endregion

        #region ⚡BOOKMARKS SCREEN⚡
        #region set up bookmarks screen
        private void SetupBookmarksScreen()
        {
            try
            {
                var bookmarks = ReadBookmarksFromJsonFile();
                btnViewBookmark.Enabled = false;
                btnDeleteBookmark.Enabled = false;
                lblBookmarkDataInFull.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkDataInFull.Text = "";
                });
                lblBookmarkNoteInFull.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkNoteInFull.Text = "";
                });
                label138.Invoke((MethodInvoker)delegate
                {
                    label138.Text = "";
                });
                lblSelectedBookmarkType.Invoke((MethodInvoker)delegate
                {
                    lblSelectedBookmarkType.Text = "";
                });
                //LIST VIEW
                listViewBookmarks.Invoke((MethodInvoker)delegate
                {
                    listViewBookmarks.Items.Clear(); // remove any data that may be there already
                });
                listViewBookmarks.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewBookmarks, new object[] { true });
                // Check if the column header already exists
                if (listViewBookmarks.Columns.Count == 0)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add(" Date added", 100);
                    });
                }

                if (listViewBookmarks.Columns.Count == 1)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add("Type", 95);
                    });
                }

                if (listViewBookmarks.Columns.Count == 2)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add("", 20);
                    });
                }
                if (listViewBookmarks.Columns.Count == 3)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add("Bookmark", 233);
                    });
                }
                if (listViewBookmarks.Columns.Count == 4)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add("Note", 600);
                    });
                }
                if (listViewBookmarks.Columns.Count == 5)
                {
                    // If not, add the column header
                    listViewBookmarks.Invoke((MethodInvoker)delegate
                    {
                        listViewBookmarks.Columns.Add("HiddenColumn", 600); //used to store the KeyCheck string.
                    });
                }
                // Add the items to the ListView
                int counterAllBookmarks = 0; // used to count rows in list as they're added
                int counterBlocks = 0;
                int counterAddresses = 0;
                int counterXpubs = 0;
                int counterTransactions = 0;

                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type != "xpubnode" && bookmark.Type != "node" && bookmark.Type != "defaulttheme" && bookmark.Type != "settings")
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(bookmark.DateAdded)); // create new row
                        item.SubItems.Add(bookmark.Type);
                        if (bookmark.Encrypted == true)
                        {
                            item.SubItems.Add("🔒");
                        }
                        else
                        {
                            item.SubItems.Add("");
                        }
                        item.SubItems.Add(bookmark.Data);
                        item.SubItems.Add(bookmark.Note);
                        item.SubItems.Add(bookmark.KeyCheck);
                        listViewBookmarks.Invoke((MethodInvoker)delegate
                        {
                            listViewBookmarks.Items.Add(item); // add row
                        });

                        if (listViewBookmarks.Items.Count > 21)
                        {
                            btnBookmarksListUp.Visible = true;
                            btnBookmarksListDown.Visible = true;
                        }
                        else
                        {
                            btnBookmarksListUp.Visible = false;
                            btnBookmarksListDown.Visible = false;

                        }

                        // Get the height of each item to set height of whole listview
                        int rowHeight = listViewBookmarks.Margin.Vertical + listViewBookmarks.Padding.Vertical + listViewBookmarks.GetItemRect(0).Height;
                        int itemCount = listViewBookmarks.Items.Count; // Get the number of items in the ListBox
                        int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                        listViewBookmarks.Height = listBoxHeight; // Set the height of the ListBox

                        if (bookmark.Type == "block")
                        {
                            counterBlocks++;
                        }
                        if (bookmark.Type == "address")
                        {
                            counterAddresses++;
                        }
                        if (bookmark.Type == "xpub")
                        {
                            counterXpubs++;
                        }
                        if (bookmark.Type == "transaction")
                        {
                            counterTransactions++;
                        }
                        counterAllBookmarks++;
                    }
                }


                listViewBookmarks.Items[0].Selected = true;

                lblBookmarkXpubsCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkXpubsCount.Text = counterXpubs.ToString();
                    lblBookmarkXpubsCount.Location = new Point(label142.Location.X - lblBookmarkXpubsCount.Width, label142.Location.Y);
                });
                label147.Invoke((MethodInvoker)delegate
                {
                    label147.Location = new Point(lblBookmarkXpubsCount.Location.X - label147.Width, lblBookmarkXpubsCount.Location.Y);
                });
                lblBookmarkTransactionsCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkTransactionsCount.Text = counterTransactions.ToString();
                    lblBookmarkTransactionsCount.Location = new Point(label147.Location.X - lblBookmarkTransactionsCount.Width, label147.Location.Y);
                });
                label151.Invoke((MethodInvoker)delegate
                {
                    label151.Location = new Point(lblBookmarkTransactionsCount.Location.X - label151.Width, lblBookmarkTransactionsCount.Location.Y);
                });
                lblBookmarkBlocksCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkBlocksCount.Text = counterBlocks.ToString();
                    lblBookmarkBlocksCount.Location = new Point(label151.Location.X - lblBookmarkBlocksCount.Width, label151.Location.Y);
                });
                label153.Invoke((MethodInvoker)delegate
                {
                    label153.Location = new Point(lblBookmarkBlocksCount.Location.X - label153.Width, lblBookmarkBlocksCount.Location.Y);
                });
                lblBookmarkAddressCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkAddressCount.Text = counterAddresses.ToString();
                    lblBookmarkAddressCount.Location = new Point(label153.Location.X - lblBookmarkAddressCount.Width, label153.Location.Y);
                });

                lblBookmarkTotalCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkTotalCount.Text = counterAllBookmarks.ToString();
                });

                lblBookmarkTotalCount.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkStatusMessage.Location = new Point(btnDecryptBookmark.Location.X + btnDecryptBookmark.Width + 10, lblBookmarkStatusMessage.Location.Y);
                });

                label144.Invoke((MethodInvoker)delegate
                {
                    label144.Location = new Point(lblBookmarkTotalCount.Location.X + lblBookmarkTotalCount.Width, lblBookmarkTotalCount.Location.Y);
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "SetupBookmarksScreen");
            }
        }
        #endregion
        #region view and unlock bookmarks
        private void ListViewBookmarks_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                textBoxBookmarkKey.Visible = false;
                btnDecryptBookmark.Visible = false;
                foreach (ListViewItem item in listViewBookmarks.Items)
                {
                    if (item.Selected)
                    {
                        item.EnsureVisible();
                        if (item.SubItems[1].Text == "xpub")
                        {
                            if (lblXpubNodeStatusLight.ForeColor == Color.OliveDrab)
                            {
                                btnViewBookmark.Enabled = true;
                            }
                            else
                            {
                                lblAlert.Text = "⚠️";
                                lblErrorMessage.Text = "you need to connect to a full node before the selected Xpub can be viewed.";
                            }
                        }

                        btnDeleteBookmark.Enabled = true;
                        item.BackColor = Color.Blue;
                        item.ForeColor = Color.White;
                        item.SubItems[2].ForeColor = Color.White;
                        item.SubItems[3].ForeColor = Color.White;
                        item.SubItems[4].ForeColor = Color.White;
                        lblSelectedBookmarkType.Invoke((MethodInvoker)delegate
                        {
                            lblSelectedBookmarkType.Text = item.SubItems[1].Text;
                        });
                        label138.Invoke((MethodInvoker)delegate
                        {
                            label138.Text = "note";
                        });
                        lblSelectedBookmarkType.Invoke((MethodInvoker)delegate
                        {
                            lblBookmarkDataInFull.Location = new Point(lblSelectedBookmarkType.Location.X + lblSelectedBookmarkType.Width, lblSelectedBookmarkType.Location.Y);
                            lblBookmarkDataInFull.Text = item.SubItems[3].Text;
                            bookmarkDataInFullPreserved = item.SubItems[3].Text;
                        });
                        lblBookmarkNoteInFull.Invoke((MethodInvoker)delegate
                        {
                            lblBookmarkNoteInFull.Location = new Point(label138.Location.X + label138.Width, label138.Location.Y);
                            lblBookmarkNoteInFull.Text = item.SubItems[4].Text;
                            bookmarkNoteInFullPreserved = item.SubItems[4].Text;
                        });
                        if (item.SubItems[2].Text == "🔒")
                        {
                            btnBookmarkUnlock.Enabled = true;
                            bookmarkKeyCheckPreserved = item.SubItems[5].Text;
                            btnViewBookmark.Enabled = false;
                        }
                        else
                        {
                            btnBookmarkUnlock.Enabled = false;
                            btnViewBookmark.Enabled = true;
                        }
                    }
                    else
                    {
                        item.ForeColor = tableTextColor;
                        item.SubItems[2].ForeColor = tableTextColor;
                        item.SubItems[3].ForeColor = tableTextColor;
                        item.SubItems[4].ForeColor = tableTextColor;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBookmarks_ItemSelectionChanged");
            }
        }

        private void BtnBookmarkUnlock_Click(object sender, EventArgs e)
        {
            if (textBoxBookmarkKey.Visible)
            {
                textBoxBookmarkKey.Visible = false;
                btnDecryptBookmark.Visible = false;
            }
            else
            {
                textBoxBookmarkKey.Visible = true;
                btnDecryptBookmark.Visible = true;
            }
        }

        private void BtnViewBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNetworkStatus();
                if (lblSelectedBookmarkType.Text == "block")
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = lblBookmarkDataInFull.Text;
                    });
                    try
                    {
                        LookupBlock();
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, "btnViewBookmark_Click");
                    }
                    //show the block screen
                    BtnMenuBlock_Click(sender, e);
                }
                if (lblSelectedBookmarkType.Text == "address")
                {
                    textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                    {
                        textboxSubmittedAddress.Text = lblBookmarkDataInFull.Text;
                    });
                    //show the address screen
                    BtnMenuAddress_Click(sender, e);
                }
                if (lblSelectedBookmarkType.Text == "transaction")
                {
                    textBoxTransactionID.Invoke((MethodInvoker)delegate
                    {
                        textBoxTransactionID.Text = lblBookmarkDataInFull.Text;
                    });
                    //show the transaction screen
                    BtnMenuTransaction_Click(sender, e);
                }
                if (lblSelectedBookmarkType.Text == "xpub")
                {
                    textBoxSubmittedXpub.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedXpub.Text = lblBookmarkDataInFull.Text;
                    });
                    BtnMenuXpub_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewBookmark_Click");
            }
        }
        #endregion
        #region delete bookmark
        private static void DeleteBookmarkFromJsonFile(string bookmarkDataToDelete)
        {
            // Read the existing bookmarks from the JSON file
            var bookmarks = ReadBookmarksFromJsonFile();

            // Find the index of the bookmark with the specified data
            int index = bookmarks.FindIndex(bookmark =>
                bookmark.Data == bookmarkDataToDelete);

            // If a matching bookmark was found, remove it from the list
            if (index >= 0)
            {
                bookmarks.RemoveAt(index);

                // Write the updated list of bookmarks back to the JSON file
                WriteBookmarksToJsonFile(bookmarks);
            }
        }

        private void BtnDeleteBoookmark_Click(object sender, EventArgs e)
        {
            try
            {
                string bookmarkDataToDelete = "";

                foreach (ListViewItem item in listViewBookmarks.Items)
                {
                    if (item.Selected)
                    {
                        bookmarkDataToDelete = item.SubItems[3].Text;
                    }
                }
                DeleteBookmarkFromJsonFile(bookmarkDataToDelete);
                lblBookmarkStatusMessage.ForeColor = Color.IndianRed;
                lblBookmarkStatusMessage.Text = "bookmark deleted";
                lblBookmarkStatusMessage.Visible = true;
                hideBookmarkStatusMessageTimer.Start();
                SetupBookmarksScreen();
                lblBookmarkDataInFull.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkDataInFull.Text = "";
                });
                lblBookmarkNoteInFull.Invoke((MethodInvoker)delegate
                {
                    lblBookmarkNoteInFull.Text = "";
                });
                label138.Invoke((MethodInvoker)delegate
                {
                    label138.Text = "";
                });
                lblSelectedBookmarkType.Invoke((MethodInvoker)delegate
                {
                    lblSelectedBookmarkType.Text = "";
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnDeleteBookmark_Click");
            }
        }
        #endregion
        #region listview appearance
        private void ListViewBookmarks_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (listViewBookmarks.Columns[e.ColumnIndex].Width < 100) // min width
                {
                    e.Cancel = true;
                    e.NewWidth = 100;
                }
                if (listViewBookmarks.Columns[e.ColumnIndex].Width > 150) // max width
                {
                    e.Cancel = true;
                    e.NewWidth = 150;
                }
            }

            if (e.ColumnIndex == 1)
            {
                if (listViewBookmarks.Columns[e.ColumnIndex].Width != 95) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 95;
                }
            }


            if (e.ColumnIndex == 2)
            {
                if (listViewBookmarks.Columns[e.ColumnIndex].Width != 20) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 20;
                }
            }

            if (e.ColumnIndex == 3)
            {
                if (listViewBookmarks.Columns[e.ColumnIndex].Width < 100) // min width
                {
                    e.Cancel = true;
                    e.NewWidth = 100;
                }
                if (listViewBookmarks.Columns[e.ColumnIndex].Width > 400) // max width
                {
                    e.Cancel = true;
                    e.NewWidth = 400;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (listViewBookmarks.Columns[e.ColumnIndex].Width < 100) // min width
                {
                    e.Cancel = true;
                    e.NewWidth = 100;
                }
                if (listViewBookmarks.Columns[e.ColumnIndex].Width > 600) // max width
                {
                    e.Cancel = true;
                    e.NewWidth = 600;
                }
            }
        }

        private void ListViewBookmarks_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                var text = e.SubItem.Text;

                if (e.ColumnIndex == 1)
                {
                    if (text == "address")
                    {
                        e.SubItem.ForeColor = Color.DarkSlateBlue;
                    }
                    if (text == "block")
                    {
                        e.SubItem.ForeColor = Color.PaleVioletRed;
                    }
                    if (text == "transaction")
                    {
                        e.SubItem.ForeColor = Color.OliveDrab;
                    }
                    if (text == "xpub")
                    {
                        e.SubItem.ForeColor = Color.Peru;
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    if (text == "")
                    {
                        e.SubItem.ForeColor = Color.OliveDrab;
                    }
                    else
                    {
                        e.SubItem.ForeColor = Color.IndianRed;
                    }
                }
                var font = listViewBookmarks.Font;
                var columnWidth = e.Header.Width;
                var textWidth = TextRenderer.MeasureText(text, font).Width;
                if (textWidth > columnWidth)
                {
                    // Truncate the text
                    var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                    // Clear the background
                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBookmarks.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
                }
                else if (textWidth < columnWidth)
                {
                    // Clear the background
                    var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                    if (e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(subItemBackColor), bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(listViewBookmarks.BackColor), bounds);
                    }

                    TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ListViewBookmarks_DrawSubItem");
            }
        }
        #endregion
        #region scroll listview
        private void BtnDecryptBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                string decryptedBookmarkData = Decrypt(bookmarkDataInFullPreserved, textBoxBookmarkKey.Text);
                string decryptedBookmarkNote = Decrypt(bookmarkNoteInFullPreserved, textBoxBookmarkKey.Text);
                string decryptedBookmarkKeyCheck = Decrypt(bookmarkKeyCheckPreserved, textBoxBookmarkKey.Text);
                if (decryptedBookmarkKeyCheck == "21m") // correct key
                {
                    lblBookmarkDataInFull.Text = decryptedBookmarkData;
                    lblBookmarkNoteInFull.Text = decryptedBookmarkNote;
                    textBoxBookmarkKey.Text = "";
                    lblBookmarkStatusMessage.ForeColor = Color.OliveDrab;
                    lblBookmarkStatusMessage.Text = "bookmark unlocked";
                    lblBookmarkStatusMessage.Visible = true;
                    hideBookmarkStatusMessageTimer.Start();
                    btnViewBookmark.Enabled = true;
                }
                else // wrong key
                {
                    lblBookmarkStatusMessage.ForeColor = Color.IndianRed;
                    lblBookmarkStatusMessage.Text = "incorrect key";
                    lblBookmarkStatusMessage.Visible = true;
                    hideBookmarkStatusMessageTimer.Start();
                    btnViewBookmark.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "decrypting bookmark");
            }
        }

        private void BtnBookmarksListDown_Click(object sender, EventArgs e)
        {
            if (panelBookmarksContainer.VerticalScroll.Value < panelBookmarksContainer.VerticalScroll.Maximum)
            {
                panelBookmarksContainer.VerticalScroll.Value++;
            }
        }

        private void BtnBookmarksListDown_MouseDown(object sender, MouseEventArgs e)
        {
            isBookmarksButtonPressed = true;
            bookmarksDownButtonPressed = true;
            BookmarksScrollTimer.Start();
        }

        private void BtnBookmarksListDown_MouseUp(object sender, MouseEventArgs e)
        {
            isBookmarksButtonPressed = false;
            bookmarksDownButtonPressed = false;
            BookmarksScrollTimer.Stop();
            BookmarksScrollTimer.Interval = 50; // reset the interval to its original value
        }

        private void BtnBookmarksListUp_Click(object sender, EventArgs e)
        {
            if (panelBookmarksContainer.VerticalScroll.Value > panelBookmarksContainer.VerticalScroll.Minimum)
            {
                panelBookmarksContainer.VerticalScroll.Value--;
            }
        }

        private void BtnBookmarksListUp_MouseDown(object sender, MouseEventArgs e)
        {
            isBookmarksButtonPressed = true;
            bookmarksUpButtonPressed = true;
            BookmarksScrollTimer.Start();
        }

        private void BtnBookmarksListUp_MouseUp(object sender, MouseEventArgs e)
        {
            isBookmarksButtonPressed = false;
            bookmarksUpButtonPressed = false;
            BookmarksScrollTimer.Stop();
            BookmarksScrollTimer.Interval = 50; // reset the interval to its original value
        }

        private void BookmarksScrollTimer_Tick(object sender, EventArgs e)
        {
            if (isBookmarksButtonPressed)
            {
                if (bookmarksDownButtonPressed)
                {
                    if (panelBookmarksContainer.VerticalScroll.Value < panelBookmarksContainer.VerticalScroll.Maximum - 5)
                    {
                        panelBookmarksContainer.VerticalScroll.Value = panelBookmarksContainer.VerticalScroll.Value + 5;
                        bookmarksScrollPosition = panelBookmarksContainer.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    BookmarksScrollTimer.Interval = 1; // set a faster interval while the button is held down
                }
                else if (bookmarksUpButtonPressed)
                {
                    if (panelBookmarksContainer.VerticalScroll.Value > panelBookmarksContainer.VerticalScroll.Minimum + 5)
                    {
                        panelBookmarksContainer.VerticalScroll.Value = panelBookmarksContainer.VerticalScroll.Value - 5;
                        bookmarksScrollPosition = panelBookmarksContainer.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    BookmarksScrollTimer.Interval = 1; // set a faster interval while the button is held down
                }
            }
            else
            {
                BookmarksScrollTimer.Stop();
            }
        }

        private void PanelBookmarksContainer_Paint(object sender, PaintEventArgs e)
        {
            if (btnViewBookmark.Enabled)
            {
                panelBookmarksContainer.VerticalScroll.Value = bookmarksScrollPosition;

            }
        }
        #endregion
        #region user input
        private void TextBoxBookmarkKey_Enter(object sender, EventArgs e)
        {
            if (isBookmarkKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkKey.Text = "";
                });
                textBoxBookmarkKey.ForeColor = Color.White;
                isBookmarkKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isBookmarkKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkKey.Text = "";
                });
                textBoxBookmarkKey.ForeColor = Color.White;
                isBookmarkKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkKey_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookmarkKey.Text))
            {
                textBoxBookmarkKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkKey.Text = "enter key to unlock";
                    textBoxBookmarkKey.ForeColor = Color.Gray;
                    isBookmarkKeyWatermarkTextDisplayed = true;
                });
               
            }
        }

        private void TextBoxBookmarkKey_TextChanged(object sender, EventArgs e)
        {
            if (isBookmarkKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkKey.ForeColor = Color.White;
                isBookmarkKeyWatermarkTextDisplayed = false;
            }
        }
        #endregion
        #endregion

        #region ⚡ADD TO BOOKMARKS TAB⚡
        #region show, populate or hide the add bookmark tab
        private void BtnAddToBookmarks_Click(object sender, EventArgs e)
        {
            if (!panelAddToBookmarks.Visible)
            {
                panelFees.Visible = false;
                panelAddToBookmarks.Visible = true;
                lblBookmarkSavedSuccess.Visible = false;
                btnCommitToBookmarks.Enabled = true;
                btnCancelAddToBookmarks.Enabled = true;
                panelAddToBookmarks.BringToFront();
            }
            else
            {
                panelAddToBookmarks.Visible = false;
                panelFees.Visible = true;
            }
        }

        private void PanelAddToBookmarks_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (panelAddress.Visible)
                {
                    lblBookmarkProposalType.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalType.Text = "address";
                    });
                    lblBookmarkProposalData.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalData.Text = textboxSubmittedAddress.Text;
                    });

                }
                if (panelBlock.Visible)
                {
                    lblBookmarkProposalType.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalType.Text = "block";
                    });
                    lblBookmarkProposalData.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalData.Text = textBoxSubmittedBlockNumber.Text;
                    });
                }
                if (panelTransaction.Visible)
                {
                    lblBookmarkProposalType.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalType.Text = "transaction";
                    });
                    lblBookmarkProposalData.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalData.Text = textBoxTransactionID.Text;
                    });
                }
                if (panelXpub.Visible)
                {
                    lblBookmarkProposalType.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalType.Text = "xpub";
                    });
                    lblBookmarkProposalData.Invoke((MethodInvoker)delegate
                    {
                        lblBookmarkProposalData.Text = textBoxSubmittedXpub.Text;
                    });
                }

                lblBookmarkProposalType.Location = new Point(label131.Location.X + label131.Width, label131.Location.Y);
                lblBookmarkProposalData.Location = new Point(lblBookmarkProposalType.Location.X + lblBookmarkProposalType.Width, lblBookmarkProposalType.Location.Y);
                lblBookmarkProposalData.Width = panelAddToBookmarks.Width - label131.Width - lblBookmarkProposalType.Width - 5;
            }
            catch (Exception ex)
            {
                HandleException(ex, "PanelAddToBookmarks_Paint");
            }
        }

        private void BtnCancelAddToBookmarks_Click(object sender, EventArgs e)
        {
            HideBookmarksShowFees(sender,e);
        }

        private void HideBookmarksShowFees(object sender, EventArgs e)
        {
            panelAddToBookmarks.Visible = false;
            panelFees.Visible = true;
        }
        #endregion
        #region create bookmark record to be saved
        private void BtnCommitToBookmarks_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;
                bool toBeEncrypted = false;
                if (textBoxBookmarkEncryptionKey.Text == "" || textBoxBookmarkEncryptionKey.Text == "optional encryption key")
                {
                    toBeEncrypted = false;
                }
                else
                {
                    toBeEncrypted = true;
                }

                string bookmarkNote;
                if (textBoxBookmarkProposedNote.Text == "optional notes" || textBoxBookmarkProposedNote.Text == "")
                {
                    bookmarkNote = "";
                }
                else
                {
                    bookmarkNote = textBoxBookmarkProposedNote.Text;
                }

                string bookmarkData;
                string keyCheck = "21m";
                if (toBeEncrypted)
                {
                    // Encrypt the new bookmark using the encryption key
                    string encryptionKey = textBoxBookmarkEncryptionKey.Text;
                    string unencryptedBookmarkData = lblBookmarkProposalData.Text;
                    string unencryptedBookmarkNote = bookmarkNote;
                    string unencryptedKeyCheck = "21m";
                    string encryptedKeyCheck = Encrypt(unencryptedKeyCheck, encryptionKey);
                    string encryptedBookmarkData = Encrypt(unencryptedBookmarkData, encryptionKey);
                    string encryptedBookmarkNote = Encrypt(unencryptedBookmarkNote, encryptionKey);
                    bookmarkNote = encryptedBookmarkNote;
                    bookmarkData = encryptedBookmarkData;
                    keyCheck = encryptedKeyCheck;
                }
                else
                {
                    bookmarkData = lblBookmarkProposalData.Text;
                }

                var newBookmark = new Bookmark { DateAdded = today, Type = lblBookmarkProposalType.Text, Data = bookmarkData, Note = bookmarkNote, Encrypted = toBeEncrypted, KeyCheck = keyCheck };

                // Read the existing bookmarks from the JSON file
                var bookmarks = ReadBookmarksFromJsonFile();

                // Add the new bookmark to the list
                bookmarks.Add(newBookmark);

                // Write the updated list of bookmarks back to the JSON file
                WriteBookmarksToJsonFile(bookmarks);
                lblBookmarkSavedSuccess.Visible = true;
                btnCommitToBookmarks.Enabled = false;
                btnCancelAddToBookmarks.Enabled = false;
                hideAddToBookmarksTimer.Start();

                textBoxBookmarkProposedNote.Text = "";
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnCommitToBookmarks_Click");
            }
        }
        #endregion
        #region read bookmarks from file
        private static List<Bookmark> ReadBookmarksFromJsonFile()
        {
            string bookmarksFileName = "SATSuma_bookmarks.json";
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string applicationDirectory = Path.Combine(appDataDirectory, "SATSuma");
            // Create the application directory if it doesn't exist
            Directory.CreateDirectory(applicationDirectory);
            string bookmarksFilePath = Path.Combine(applicationDirectory, bookmarksFileName);
            string filePath = bookmarksFilePath;

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Dispose();
            }
            // Read the contents of the JSON file into a string
            string json = System.IO.File.ReadAllText(filePath);

            // Deserialize the JSON string into a list of bookmark objects
            var bookmarks = JsonConvert.DeserializeObject<List<Bookmark>>(json);

            // If the JSON file doesn't exist or is empty, return an empty list
            bookmarks ??= new List<Bookmark>();
            bookmarks = bookmarks.OrderByDescending(b => b.DateAdded).ToList();
            return bookmarks;
        }
        #endregion
        #region write bookmarks to file
        private static void WriteBookmarksToJsonFile(List<Bookmark> bookmarks)
        {
            // Serialize the list of bookmark objects into a JSON string
            string json = JsonConvert.SerializeObject(bookmarks);

            string bookmarksFileName = "SATSuma_bookmarks.json";
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string applicationDirectory = Path.Combine(appDataDirectory, "SATSuma");
            // Create the application directory if it doesn't exist
            Directory.CreateDirectory(applicationDirectory);
            string bookmarksFilePath = Path.Combine(applicationDirectory, bookmarksFileName);
            string filePath = bookmarksFilePath;

            // Write the JSON string to the bookmarks.json file
            System.IO.File.WriteAllText(filePath, json);
        }
        #endregion
        #region user input
        private void TextBoxBookmarkProposedNote_Enter(object sender, EventArgs e)
        {
            if (isBookmarkNoteWatermarkTextDisplayed)
            {
                textBoxBookmarkProposedNote.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkProposedNote.Text = "";
                    textBoxBookmarkProposedNote.ForeColor = Color.White;
                });
                isBookmarkNoteWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkProposedNote_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookmarkProposedNote.Text))
            {
                textBoxBookmarkProposedNote.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkProposedNote.Text = "optional notes";
                    textBoxBookmarkProposedNote.ForeColor = Color.Gray;
                });
                isBookmarkNoteWatermarkTextDisplayed = true;
            }
        }

        private void TextBoxBookmarkProposedNote_TextChanged(object sender, EventArgs e)
        {
            if (isBookmarkNoteWatermarkTextDisplayed)
            {
                textBoxBookmarkProposedNote.ForeColor = Color.White;
                isBookmarkNoteWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkProposedNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isBookmarkNoteWatermarkTextDisplayed)
            {
                textBoxBookmarkProposedNote.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkProposedNote.Text = "";
                    textBoxBookmarkProposedNote.ForeColor = Color.White;
                });
                isBookmarkNoteWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkEncryptionKey_Enter(object sender, EventArgs e)
        {
            if (isEncryptionKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkEncryptionKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkEncryptionKey.Text = "";
                    textBoxBookmarkEncryptionKey.ForeColor = Color.White;
                });
                isEncryptionKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkEncryptionKey_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookmarkEncryptionKey.Text))
            {
                textBoxBookmarkEncryptionKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkEncryptionKey.Text = "optional encryption key";
                    textBoxBookmarkEncryptionKey.ForeColor = Color.Gray;
                });
                isEncryptionKeyWatermarkTextDisplayed = true;
            }
        }

        private void TextBoxBookmarkEncryptionKey_TextChanged(object sender, EventArgs e)
        {
            if (isEncryptionKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkEncryptionKey.ForeColor = Color.White;
                isEncryptionKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkEncryptionKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isEncryptionKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkEncryptionKey.Invoke((MethodInvoker)delegate
                {
                    textBoxBookmarkEncryptionKey.Text = "";
                    textBoxBookmarkEncryptionKey.ForeColor = Color.White;
                });
                isEncryptionKeyWatermarkTextDisplayed = false;
            }
        }
        #endregion
        #region timer to hide add bookmark panel after adding
        private void HideAddToBookmarks_Tick(object sender, EventArgs e)
        {
            panelAddToBookmarks.Visible = false;
            panelFees.Visible = true;
            hideAddToBookmarksTimer.Stop();
        }

        private void HideDeletedBookmarkMessageTimer_Tick(object sender, EventArgs e)
        {
            lblBookmarkStatusMessage.Visible = false;
            hideBookmarkStatusMessageTimer.Stop();
        }
        #endregion
        #endregion

        #region ⚡SETTINGS SCREEN⚡
        #region user input xpub url
        private void TextBoxSettingsXpubMempoolURL_Enter(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsXpubMempoolURL.Text = "";
                        textBoxSettingsXpubMempoolURL.ForeColor = Color.White;
                    });
                    isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsXpubMempoolURL_Enter");
            }
        }

        private void TextBoxSettingsXpubMempoolURL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSettingsXpubMempoolURL.Text))
                {
                    textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                        {
                            textBoxSettingsXpubMempoolURL.Text = "e.g http://umbrel.local:3006/api/";
                            textBoxSettingsXpubMempoolURL.ForeColor = Color.Gray;
                        });
                    });
                    isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsXpubMempoolURL_Leave");
            }
        }

        private void TextBoxSettingsXpubMempoolURL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsXpubMempoolURL.ForeColor = Color.White;
                    isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsXpubMempoolURL_TextChanged");
            }
        }

        private void TextBoxSettingsXpubMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                        {
                            textBoxSettingsXpubMempoolURL.Text = "";
                            textBoxSettingsXpubMempoolURL.ForeColor = Color.White;
                        });
                    });
                    isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = false;
                }
                else
                {
                    previousXpubNodeStringToCompare = textBoxSettingsXpubMempoolURL.Text;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsXpubMempoolURL_KeyPress");
            }
        }

        private void TextBoxSettingsXpubMempoolURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (previousXpubNodeStringToCompare != textBoxSettingsXpubMempoolURL.Text)
                {
                    textBoxSubmittedXpub.Enabled = false;
                    lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                    lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                    label18.Invoke((MethodInvoker)delegate
                    {
                        label18.Text = "invalid / node offline";
                    });
                    lblSettingsXpubNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsXpubNodeStatus.Text = "invalid / node offline";
                    });
                    textBoxSubmittedXpub.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedXpub.Text = "";
                    });
                    previousXpubNodeStringToCompare = textBoxSettingsXpubMempoolURL.Text;
                    textBoxXpubNodeURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxXpubNodeURL.Text = textBoxSettingsXpubMempoolURL.Text;
                    });
                    CheckXpubNodeIsOnline();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsXpubMempoolURL_KeyUp");
            }
        }
        #endregion
        #region user input mempool url
        private void TextBoxSettingsCustomMempoolURL_Enter(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsCustomMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsCustomMempoolURL.Text = "";
                        textBoxSettingsCustomMempoolURL.ForeColor = Color.White;
                    });
                    isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsCustomMempoolURL_Enter");
            }
        }

        private void TextBoxSettingsCustomMempoolURL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSettingsCustomMempoolURL.Text))
                {
                    textBoxSettingsCustomMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsCustomMempoolURL.Text = "e.g http://umbrel.local:3006/api/";
                        textBoxSettingsCustomMempoolURL.ForeColor = Color.Gray;
                    });
                    isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsCustomMempoolURL_Leave");
            }
        }

        private void TextBoxSettingsCustomMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsCustomMempoolURL.Invoke((MethodInvoker)delegate
                    {
                        textBoxSettingsCustomMempoolURL.Text = "";
                        textBoxSettingsCustomMempoolURL.ForeColor = Color.White;
                    });
                    isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = false;
                }
                else
                {
                    previousCustomNodeStringToCompare = textBoxSettingsCustomMempoolURL.Text;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsCustomMempoolURL_KeyPress");
            }
        }

        private void TextBoxSettingsCustomMempoolURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                {
                    lblSettingsCustomNodeStatus.Text = "invalid / node offline";
                });
                previousCustomNodeStringToCompare = textBoxSettingsCustomMempoolURL.Text;
                CheckCustomNodeIsOnline();
                CheckNetworkStatus();
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsCustomMempoolURL_KeyUp");
            }
        }

        private void TextBoxSettingsCustomMempoolURL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed)
                {
                    textBoxSettingsCustomMempoolURL.ForeColor = Color.White;
                    isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TextBoxSettingsCustomMempoolURL_TextChanged");
            }
        }
        #endregion
        #region node selection
        private void LblSettingsNodeMainnet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSettingsNodeMainnet.Text == "❌")
                {
                    lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeMainnet.ForeColor = Color.Green;
                        lblSettingsNodeMainnet.Text = "✔️";
                    });
                    testNet = false;
                    lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                        lblSettingsNodeTestnet.Text = "❌";
                    });
                    lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                        lblSettingsNodeCustom.Text = "❌";
                    });
                    textBoxSettingsCustomMempoolURL.Enabled = false;
                    NodeURL = "https://mempool.space/api/";
                    RunMempoolSpaceLightningAPI = true;
                    CheckNetworkStatus();
                    CreateDataServices();
                    SaveSettingsToBookmarksFile();
                    if (RunBlockchainInfoEndpointAPI)
                    {
                        EnableChartsThatDontUseMempoolSpace();
                    }
                    GetBlockTip();
                    LookupBlockList();
                    EnableFunctionalityForMainNet();
                    UpdateBitcoinAndLightningDashboards();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblSettingsNodeMainnet_Click");
            }
        }

        private void LblSettingsNodeTestnet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSettingsNodeTestnet.Text == "❌")
                {
                    lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeTestnet.ForeColor = Color.Green;
                        lblSettingsNodeTestnet.Text = "✔️";
                    });
                    testNet = true;
                    lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                        lblSettingsNodeMainnet.Text = "❌";
                    });
                    lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                        lblSettingsNodeCustom.Text = "❌";
                    });
                    textBoxSettingsCustomMempoolURL.Enabled = false;
                    NodeURL = "https://mempool.space/testnet/api/";
                    RunMempoolSpaceLightningAPI = true;
                    CheckNetworkStatus();
                    CreateDataServices();
                    SaveSettingsToBookmarksFile();
                    DisableFunctionalityForTestNet();
                    GetBlockTip();
                    LookupBlockList();
                    UpdateBitcoinAndLightningDashboards();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblSettingsNodeTestnet_Click");
            }
        }

        private void LblSettingsNodeCustom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSettingsNodeCustom.Text == "❌")
                {
                    lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeCustom.ForeColor = Color.Green;
                        lblSettingsNodeCustom.Text = "✔️";
                    });
                    testNet = false;
                    lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                        lblSettingsNodeMainnet.Text = "❌";
                    });
                    lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                        lblSettingsNodeTestnet.Text = "❌";
                    });
                    textBoxSettingsCustomMempoolURL.Enabled = true;
                    textBoxSettingsCustomMempoolURL.Focus();

                    lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                    lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatus.Text = "invalid / node offline";
                    });
                    previousCustomNodeStringToCompare = textBoxSettingsCustomMempoolURL.Text;
                    RunMempoolSpaceLightningAPI = false;
                    CheckCustomNodeIsOnline();
                    CheckNetworkStatus();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblSettingsNodeCustom_Click");
            }
        }
        #endregion
        #region check custom node online
        private async void CheckCustomNodeIsOnline()
        {
            using var client = new HttpClient();
            try
            {
                Ping pingSender = new Ping();
                string pingAddress = "";
                if (textBoxSettingsCustomMempoolURL.Text != "")
                {
                    // get the contents of the textbox
                    string url = textBoxSettingsCustomMempoolURL.Text;

                    // create a regex pattern to match URLs
                    string pattern = @"^(http|https):\/\/.*\/api\/$";

                    // create a regex object
                    Regex regex = new Regex(pattern);

                    // use the regex object to match the contents of the textbox
                    if (regex.IsMatch(url)) // (at least partially) valid url
                    {
                        try
                        {
                            NodeURL = textBoxSettingsCustomMempoolURL.Text;
                            // parse the URL to extract the hostname
                            Uri uri = new Uri(NodeURL);
                            string hostname = uri.Host;

                            // resolve the hostname to an IP address
                            IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                            IPAddress ipAddress = hostEntry.AddressList[0];
                            pingAddress = ipAddress.ToString();
                        }
                        catch
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = "node offline";
                            });
                            return;
                        }
                    }
                    else
                    {
                        lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                        lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsCustomNodeStatus.Text = "node offline";
                        });
                        return;
                    }
                }

                if (textBoxSettingsCustomMempoolURL.Text != "")
                {
                    PingReply reply = await pingSender.SendPingAsync(pingAddress);
                    if (reply.Status == IPStatus.Success)
                    {
                        lblSettingsCustomNodeStatusLight.ForeColor = Color.OliveDrab;
                        lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsCustomNodeStatus.Text = "node online";
                        });
                        if (lblSettingsNodeCustom.Text == "✔️")
                        {
                            CreateDataServices();
                            SaveSettingsToBookmarksFile();
                            GetBlockTip();
                            LookupBlockList();
                            UpdateBitcoinAndLightningDashboards();
                        }

                        // write the node url to the bookmarks file for auto retrieval next time (only if it's different to the one that might already be there)
                        DateTime today = DateTime.Today;
                        string bookmarkData;
                        string keyCheck = "21m";
                        bookmarkData = textBoxSettingsCustomMempoolURL.Text;
                        var newBookmark = new Bookmark { DateAdded = today, Type = "node", Data = bookmarkData, Note = "", Encrypted = false, KeyCheck = keyCheck };
                        if (!nodeURLAlreadySavedInFile)
                        {
                            // Read the existing bookmarks from the JSON file
                            var bookmarks = ReadBookmarksFromJsonFile();

                            // Add the new bookmark to the list
                            bookmarks.Add(newBookmark);

                            // Write the updated list of bookmarks back to the JSON file
                            WriteBookmarksToJsonFile(bookmarks);
                            nodeURLAlreadySavedInFile = true;
                            nodeURLInFile = bookmarkData;
                        }
                        else
                        {
                            if (nodeURLInFile != textBoxSettingsCustomMempoolURL.Text)
                            {
                                //delete the currently saved node url
                                DeleteBookmarkFromJsonFile(nodeURLInFile);
                                // Read the existing bookmarks from the JSON file
                                var bookmarks = ReadBookmarksFromJsonFile();
                                // Add the new bookmark to the list
                                bookmarks.Add(newBookmark);
                                // Write the updated list of bookmarks back to the JSON file
                                WriteBookmarksToJsonFile(bookmarks);
                                nodeURLAlreadySavedInFile = true;
                                nodeURLInFile = bookmarkData;
                            }
                        }
                    }
                    else
                    {
                        // API is not online
                        lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                        lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsCustomNodeStatus.Text = "invalid / node offline";
                        });
                    }
                }
            }
            catch (HttpRequestException)
            {
                // API is not online
                lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                {
                    lblSettingsCustomNodeStatus.Text = "invalid / node offline";
                });
            }
        }
        #endregion
        #region enable/disable api's
        private void LblBlockchairComJSON_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBlockchairComJSON.Text == "✔️")
                {
                    lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                    {
                        lblBlockchairComJSON.ForeColor = Color.IndianRed;
                        lblBlockchairComJSON.Text = "❌";
                    });
                    RunBlockchairComJSONAPI = false;
                    blockchairComJSONSelected = "0";
                    DisableChartsThatDontUseMempoolSpace();
                }
                else
                {
                    lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                    {
                        lblBlockchairComJSON.ForeColor = Color.Green;
                        lblBlockchairComJSON.Text = "✔️";
                    });
                    RunBlockchairComJSONAPI = true;
                    blockchairComJSONSelected = "1";
                    EnableChartsThatDontUseMempoolSpace();
                }
                SaveSettingsToBookmarksFile();
                TimerAPIRefreshPeriod_Tick(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblBlockchairComJSON_Click");
            }
        }

        private void LblBitcoinExplorerEndpoints_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBitcoinExplorerEndpoints.Text == "✔️")
                {
                    lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                    {
                        lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                        lblBitcoinExplorerEndpoints.Text = "❌";
                    });
                    RunBitcoinExplorerEndpointAPI = false;
                    RunBitcoinExplorerOrgJSONAPI = false;
                    bitcoinExplorerEnpointsSelected = "0";
                    DisableChartsThatDontUseMempoolSpace();
                }
                else
                {
                    lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                    {
                        lblBitcoinExplorerEndpoints.ForeColor = Color.Green;
                        lblBitcoinExplorerEndpoints.Text = "✔️";
                    });
                    RunBitcoinExplorerEndpointAPI = true;
                    RunBitcoinExplorerOrgJSONAPI = true;
                    bitcoinExplorerEnpointsSelected = "1";
                    EnableChartsThatDontUseMempoolSpace();
                }
                SaveSettingsToBookmarksFile();
                TimerAPIRefreshPeriod_Tick(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblBitcoinExplorerEndpoints_Click");
            }
        }

        private void LblBlockchainInfoEndpoints_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBlockchainInfoEndpoints.Text == "✔️")
                {
                    lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                    {
                        lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                        lblBlockchainInfoEndpoints.Text = "❌";
                    });
                    RunBlockchainInfoEndpointAPI = false;
                    blockchainInfoEndpointsSelected = "0";
                    DisableChartsThatDontUseMempoolSpace();
                }
                else
                {
                    lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                    {
                        lblBlockchainInfoEndpoints.ForeColor = Color.Green;
                        lblBlockchainInfoEndpoints.Text = "✔️";
                    });
                    RunBlockchainInfoEndpointAPI = true;
                    blockchainInfoEndpointsSelected = "1";
                    EnableChartsThatDontUseMempoolSpace();
                }
                SaveSettingsToBookmarksFile();
                TimerAPIRefreshPeriod_Tick(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblBlockchainInfoEndpoints_Click");
            }
        }
        #region enable/disable privacy mode
        private void LblPrivacyMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPrivacyMode.Text == "❌")
                {
                    EnablePrivacyMode();
                }
                else
                {
                    DisablePrivacyMode();
                }
                SaveSettingsToBookmarksFile();
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblPrivacyMode_Click");
            }
        }
        
        private void DisablePrivacyMode()
        {
            try
            {
                privacyMode = false;
                lblPrivacyMode.Invoke((MethodInvoker)delegate
                {
                    lblPrivacyMode.ForeColor = Color.IndianRed;
                    lblPrivacyMode.Text = "❌";
                });
                lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                {
                    lblBlockchairComJSON.ForeColor = Color.IndianRed;
                    lblBlockchairComJSON.Text = "❌";
                    lblBlockchairComJSON.Enabled = true;
                });
                RunBlockchairComJSONAPI = false;
                lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                    lblBitcoinExplorerEndpoints.Text = "❌";
                    lblBitcoinExplorerEndpoints.Enabled = true;
                });
                RunBitcoinExplorerEndpointAPI = false;
                RunBitcoinExplorerOrgJSONAPI = false;
                lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                    lblBlockchainInfoEndpoints.Text = "❌";
                    lblBlockchainInfoEndpoints.Enabled = true;
                });
                RunBlockchainInfoEndpointAPI = false;

                PrivacyModeSelected = "0";
                blockchairComJSONSelected = "0";
                bitcoinExplorerEnpointsSelected = "0";
                blockchainInfoEndpointsSelected = "0";

                lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                {
                    lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                    lblSettingsNodeTestnet.Enabled = true;
                });
                lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                {
                    lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                    lblSettingsNodeMainnet.Enabled = true;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisablePrivacyMode");
            }
        }

        private void EnablePrivacyMode()
        {
            try
            {
                privacyMode = true;
                lblPrivacyMode.Invoke((MethodInvoker)delegate
                {
                    lblPrivacyMode.ForeColor = Color.Green;
                    lblPrivacyMode.Text = "✔️";
                });
                lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                {
                    lblBlockchairComJSON.ForeColor = Color.Gray;
                    lblBlockchairComJSON.Text = "❌";
                    lblBlockchairComJSON.Enabled = false;
                });
                RunBlockchairComJSONAPI = false;
                lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBitcoinExplorerEndpoints.ForeColor = Color.Gray;
                    lblBitcoinExplorerEndpoints.Text = "❌";
                    lblBitcoinExplorerEndpoints.Enabled = false;
                });
                RunBitcoinExplorerEndpointAPI = false;
                RunBitcoinExplorerOrgJSONAPI = false;
                lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBlockchainInfoEndpoints.ForeColor = Color.Gray;
                    lblBlockchainInfoEndpoints.Text = "❌";
                    lblBlockchainInfoEndpoints.Enabled = false;
                });
                RunBlockchainInfoEndpointAPI = false;
                RunMempoolSpaceLightningAPI = false;
                PrivacyModeSelected = "1";
                blockchairComJSONSelected = "0";
                bitcoinExplorerEnpointsSelected = "0";
                blockchainInfoEndpointsSelected = "0";

                lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                {
                    lblSettingsNodeCustom.ForeColor = Color.Green;
                    lblSettingsNodeCustom.Text = "✔️";
                });
                testNet = false;
                textBoxSettingsCustomMempoolURL.Enabled = true;
                textBoxSettingsCustomMempoolURL.Focus();

                lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                {
                    lblSettingsCustomNodeStatus.Text = "invalid / node offline";
                });
                previousCustomNodeStringToCompare = textBoxSettingsCustomMempoolURL.Text;

                CheckCustomNodeIsOnline();
                CheckNetworkStatus();

                lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                {
                    lblSettingsNodeTestnet.ForeColor = Color.Gray;
                    lblSettingsNodeTestnet.Enabled = false;
                });
                lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                {
                    lblSettingsNodeMainnet.ForeColor = Color.Gray;
                    lblSettingsNodeMainnet.Enabled = false;
                });
                DisableChartsThatDontUseMempoolSpace();
            }
            catch (Exception ex)
            {
                HandleException(ex, "EnablePrivacyMode");
            }
        }
        #endregion
        #region unused settings
        private void LblUnused1_Click(object sender, EventArgs e)
        {
            /*
            if (lblLightningDashboard.Text == "✔️")
            {
                lblMempoolLightningJSON.Invoke((MethodInvoker)delegate
                {
                    lblMempoolLightningJSON.ForeColor = Color.IndianRed;
                    lblMempoolLightningJSON.Text = "❌";
                });
                lblLightningDashboard.Invoke((MethodInvoker)delegate
                {
                    lblLightningDashboard.ForeColor = Color.IndianRed;
                    lblLightningDashboard.Text = "❌";
                });
                RunMempoolSpaceLightningAPI = false;
                lblMempoolLightningJSON.Enabled = false;
                lightningDashboardSelected = "0";
                mempoolLightningJSONSelected = "0";
                btnMenuLightningDashboard.Enabled = false;
            }
            else
            {
                lblMempoolLightningJSON.Invoke((MethodInvoker)delegate
                {
                    lblMempoolLightningJSON.ForeColor = Color.Green;
                    lblMempoolLightningJSON.Text = "✔️";
                });
                lblLightningDashboard.Invoke((MethodInvoker)delegate
                {
                    lblLightningDashboard.ForeColor = Color.Green;
                    lblLightningDashboard.Text = "✔️";
                });
                RunMempoolSpaceLightningAPI = true;
                lblMempoolLightningJSON.Enabled = true;
                lightningDashboardSelected = "1";
                mempoolLightningJSONSelected = "1";
                btnMenuLightningDashboard.Enabled = true;
            }
            SaveSettingsToBookmarksFile();
            */
        }

        private void LblUnused2_Click(object sender, EventArgs e)
        {
            /*
            if (lblMempoolLightningJSON.Text == "✔️")
            {
                lblMempoolLightningJSON.Invoke((MethodInvoker)delegate
                {
                    lblMempoolLightningJSON.ForeColor = Color.IndianRed;
                    lblMempoolLightningJSON.Text = "❌";
                });
                lblLightningDashboard.Invoke((MethodInvoker)delegate
                {
                    lblLightningDashboard.ForeColor = Color.IndianRed;
                    lblLightningDashboard.Text = "❌";
                });
                RunMempoolSpaceLightningAPI = false;
                mempoolLightningJSONSelected = "0";
            }
            else
            {
                lblMempoolLightningJSON.Invoke((MethodInvoker)delegate
                {
                    lblMempoolLightningJSON.ForeColor = Color.Green;
                    lblMempoolLightningJSON.Text = "✔️";
                });
                lblLightningDashboard.Invoke((MethodInvoker)delegate
                {
                    lblLightningDashboard.ForeColor = Color.Green;
                    lblLightningDashboard.Text = "✔️";
                });
                RunMempoolSpaceLightningAPI = true;
                mempoolLightningJSONSelected = "1";
            }
            SaveSettingsToBookmarksFile();
            */
        }
        #endregion
        #endregion
        #region numeric up/down control changes
        private void NumericUpDownDashboardRefresh_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                APIGroup1DisplayTimerIntervalSecsConstant = (int)numericUpDownDashboardRefresh.Value * 60;
                intAPIGroup1TimerIntervalMillisecsConstant = (((int)numericUpDownDashboardRefresh.Value * 60) * 1000);
                intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                timerAPIRefreshPeriod.Stop();
                timerAPIRefreshPeriod.Interval = intAPIGroup1TimerIntervalMillisecsConstant;
                timerAPIRefreshPeriod.Start();
                SaveSettingsToBookmarksFile();
            }
            catch (Exception ex)
            {
                HandleException(ex, "NumericUpDownDashboardRefresh_ValueChanged");
            }
        }

        private void NumericUpDownMaxNumberOfConsecutiveUnusedAddresses_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SaveSettingsToBookmarksFile();
            }
            catch (Exception ex)
            {
                HandleException(ex, "numericUpDownMaxNumberOfConsecutiveUnusedAddresses_ValueChanged");
            }
        }
        #endregion
        #region enable/disable functionality depending on mainnet/testnet
        private void DisableFunctionalityForTestNet()
        {
            try
            {
                Control[] DisableThisStuffForTestnet = { pictureBoxBlockFeeChart, pictureBoxBlockFeesChart, pictureBoxBlockListBlockSizeChart, pictureBoxBlockListDifficultyChart, pictureBoxBlockListFeeChart, pictureBoxBlockListFeeChart2, pictureBoxBlockListFeeRangeChart, pictureBoxBlockListFeeRangeChart2, pictureBoxBlockListHashrateChart, pictureBoxBlockListPoolRanking, pictureBoxBlockListRewardChart, pictureBoxBlockScreenChartBlockSize, pictureBoxBlockScreenChartFeeRange, pictureBoxBlockScreenChartReward, pictureBoxBlockScreenPoolRankingChart, pictureBoxChartCirculation, pictureBoxDifficultyChart, pictureBoxFeeRangeChart, pictureBoxHashrateChart, pictureBoxHeaderFeeRatesChart, pictureBoxHeaderHashrateChart, pictureBoxHeaderPriceChart, pictureBoxLightningCapacityChart, pictureBoxLightningChannelsChart, pictureBoxLightningNodesChart, pictureBoxMarketCapChart, pictureBoxPoolRankingChart, pictureBoxPriceChart, pictureBoxUniqueAddressesChart };
                foreach (Control control in DisableThisStuffForTestnet)
                {
                    control.Enabled = false;
                    control.BackgroundImage = Properties.Resources.graphIcondisabled;
                }
                btnMenuCharts.Enabled = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableFunctionalityForTestNet");
            }
        }

        private void EnableFunctionalityForMainNet()
        {
            try
            {
                btnMenuCharts.Enabled = true;
                if (RunBlockchainInfoEndpointAPI == true && privacyMode == false)
                {
                    EnableChartsThatDontUseMempoolSpace();
                }
                Control[] EnableThisStuffForMainnet = { pictureBoxBlockFeeChart, pictureBoxBlockFeesChart, pictureBoxBlockListBlockSizeChart, pictureBoxBlockListDifficultyChart, pictureBoxBlockListFeeChart, pictureBoxBlockListFeeChart2, pictureBoxBlockListFeeRangeChart, pictureBoxBlockListFeeRangeChart2, pictureBoxBlockListHashrateChart, pictureBoxBlockListPoolRanking, pictureBoxBlockListRewardChart, pictureBoxBlockScreenChartBlockSize, pictureBoxBlockScreenChartFeeRange, pictureBoxBlockScreenChartReward, pictureBoxBlockScreenPoolRankingChart, pictureBoxDifficultyChart, pictureBoxFeeRangeChart, pictureBoxHashrateChart, pictureBoxHeaderFeeRatesChart, pictureBoxHeaderHashrateChart, pictureBoxLightningCapacityChart, pictureBoxLightningChannelsChart, pictureBoxLightningNodesChart, pictureBoxPoolRankingChart };
                foreach (Control control in EnableThisStuffForMainnet)
                {
                    control.Enabled = true;
                    control.BackgroundImage = Properties.Resources.graphIcon;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "EnableFunctionalityForMainNet");
            }
        }
        #endregion
        #region save settings (to bookmarks file)
        private void SaveSettingsToBookmarksFile()
        {
            // settings entry in the bookmark file = DM111111nnnnnnnnn... 1st char P(ound), D(ollar), E(uro), G(old) = GBP, USD, EUR, XAU. 2nd char M, T, C = Mainnet, Testnet, Custom, then 6 bools = blockchairComJSON, BitcoinExplorerEndpoints, BlockchainInfoEndpoints, Privacy Mode, unused, unused, nnnn = refresh freq, nn = max number of consecutive non-zero addresses on xpub scan, nnn = number of derivation paths to check.
            try
            {
                if (btnUSD.Enabled == false)
                {
                    currencySelected = "D";
                }
                if (btnGBP.Enabled == false)
                {
                    currencySelected = "P";
                }
                if (btnEUR.Enabled == false)
                {
                    currencySelected = "E";
                }
                if (btnXAU.Enabled == false)
                {
                    currencySelected = "G";
                }
                if (lblSettingsNodeMainnet.Text == "✔️")
                {
                    selectedNetwork = "M";
                }
                if (lblSettingsNodeTestnet.Text == "✔️")
                {
                    selectedNetwork = "T";
                }
                if (lblSettingsNodeCustom.Text == "✔️")
                {
                    selectedNetwork = "C";
                }
                if (lblPrivacyMode.Text == "✔️")
                {
                    PrivacyModeSelected = "1";
                }
                if (lblBlockchairComJSON.Text == "✔️")
                {
                    blockchairComJSONSelected = "1";
                }
                if (lblBitcoinExplorerEndpoints.Text == "✔️")
                {
                    bitcoinExplorerEnpointsSelected = "1";
                }
                if (lblBlockchainInfoEndpoints.Text == "✔️")
                {
                    blockchainInfoEndpointsSelected = "1";
                }
                if (lblUnused1.Text == "✔️")
                {
                    unused1 = "1";
                }
                if (lblUnused2.Text == "✔️")
                {
                    unused2 = "1";
                }

                // write the settings to the bookmarks file for auto retrieval next time
                DateTime today = DateTime.Today;
                string bookmarkData = currencySelected + selectedNetwork + blockchairComJSONSelected + bitcoinExplorerEnpointsSelected + blockchainInfoEndpointsSelected + PrivacyModeSelected + unused1 + unused2 + numericUpDownDashboardRefresh.Value.ToString().PadLeft(4, '0') + numericUpDownMaxNumberOfConsecutiveUnusedAddresses.Value.ToString().PadLeft(2, '0') + numberUpDownDerivationPathsToCheck.Value.ToString().PadLeft(3, '0');
                string keyCheck = "21m";
                var newBookmark = new Bookmark { DateAdded = today, Type = "settings", Data = bookmarkData, Note = "", Encrypted = false, KeyCheck = keyCheck };
                if (!settingsAlreadySavedInFile)
                {
                    // Read the existing bookmarks from the JSON file
                    var bookmarks = ReadBookmarksFromJsonFile();
                    // Add the new bookmark to the list
                    bookmarks.Add(newBookmark);
                    // Write the updated list of bookmarks back to the JSON file
                    WriteBookmarksToJsonFile(bookmarks);
                    settingsAlreadySavedInFile = true;
                    settingsInFile = bookmarkData;
                }
                else
                {
                    //delete the currently saved settings
                    DeleteBookmarkFromJsonFile(settingsInFile);
                    // Read the existing settings from the JSON file
                    var bookmarks = ReadBookmarksFromJsonFile();
                    // Add the new bookmark to the list
                    bookmarks.Add(newBookmark);
                    // Write the updated list of bookmarks back to the JSON file
                    WriteBookmarksToJsonFile(bookmarks);
                    settingsAlreadySavedInFile = true;
                    settingsInFile = bookmarkData;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "SaveSettingsToBookmarksFile");
            }
        }
        #endregion
        #region restore settings
        private void RestoreSavedSettings()
        {
            try
            {
                var bookmarks = ReadBookmarksFromJsonFile();

                // check if settings are already saved in the bookmarks file and either restore them or use defaults and save a settings entry in bookmarks file
                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type == "settings")
                    {
                        settingsAlreadySavedInFile = true;
                        settingsInFile = bookmark.Data;
                        if (Convert.ToString(bookmark.Data[0]) == "P")
                        {
                            //GBP
                            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonText.Text = "GBP £";
                                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnGBP.Location.X + (btnGBP.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnGBP.Location.Y + 3);
                            });
                            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnGBP.Location.X, btnGBP.Location.Y + 5);
                            });
                            btnGBP.Enabled = false;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = true;
                            btnCurrency.Text = "GBP £";
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "D")
                        {
                            //USD
                            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonText.Text = "USD $";
                                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnUSD.Location.X + (btnUSD.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnUSD.Location.Y + 3);
                            });
                            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnUSD.Location.X, btnUSD.Location.Y + 5);
                            });
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = false;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = true;
                            btnCurrency.Text = "USD $";
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "E")
                        {
                            //EUR
                            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonText.Text = "EUR €";
                                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnEUR.Location.X + (btnEUR.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnEUR.Location.Y + 3);
                            });
                            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnEUR.Location.X, btnEUR.Location.Y + 5);
                            });
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = false;
                            btnXAU.Enabled = true;
                            btnCurrency.Text = "EUR €";
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "G")
                        {
                            //XAU
                            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonText.Text = "XAU 🪙";
                                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnXAU.Location.X + (btnXAU.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnXAU.Location.Y + 3);
                            });
                            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                            {
                                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnXAU.Location.X, btnXAU.Location.Y + 5);
                            });
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = false;
                            btnCurrency.Text = "XAU 🪙";
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "M")
                        {
                            //mainnet
                            testNet = false;
                            NodeURL = "https://mempool.space/api/";
                            RunMempoolSpaceLightningAPI = true;
                            CreateDataServices();
                            lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeMainnet.Text = "✔️";
                                lblSettingsNodeMainnet.ForeColor = Color.Green;
                            });
                            lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeTestnet.Text = "❌";
                                lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                            });
                            lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeCustom.Text = "❌";
                                lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                            });
                            textBoxSettingsCustomMempoolURL.Enabled = false;
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "T")
                        {
                            //testnet
                            testNet = true;
                            NodeURL = "https://mempool.space/testnet/api/";
                            RunMempoolSpaceLightningAPI = true;
                            CreateDataServices();
                            DisableFunctionalityForTestNet();
                            lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeMainnet.Text = "❌";
                                lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                            });
                            lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeTestnet.Text = "✔️";
                                lblSettingsNodeTestnet.ForeColor = Color.Green;
                            });
                            lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeCustom.Text = "❌";
                                lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                            });
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "C")
                        {
                            //custom
                            RunMempoolSpaceLightningAPI = false;
                            CreateDataServices();
                            lblSettingsNodeMainnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeMainnet.Text = "❌";
                                lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                            });
                            lblSettingsNodeTestnet.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeTestnet.Text = "❌";
                                lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                            });
                            lblSettingsNodeCustom.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsNodeCustom.Text = "✔️";
                                lblSettingsNodeCustom.ForeColor = Color.Green;
                            });
                        }
                        if (Convert.ToString(bookmark.Data[2]) == "1")
                        {
                            RunBlockchairComJSONAPI = true;
                            lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                            {
                                lblBlockchairComJSON.Text = "✔️";
                                lblBlockchairComJSON.ForeColor = Color.Green;
                            });
                        }
                        else
                        {
                            RunBlockchairComJSONAPI = false;
                            lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                            {
                                lblBlockchairComJSON.Text = "❌";
                                lblBlockchairComJSON.ForeColor = Color.IndianRed;
                            });
                        }
                        if (Convert.ToString(bookmark.Data[3]) == "1")
                        {
                            RunBitcoinExplorerEndpointAPI = true;
                            RunBitcoinExplorerOrgJSONAPI = true;
                            lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                            {
                                lblBitcoinExplorerEndpoints.Text = "✔️";
                                lblBitcoinExplorerEndpoints.ForeColor = Color.Green;
                            });
                        }
                        else
                        {
                            RunBitcoinExplorerEndpointAPI = false;
                            RunBitcoinExplorerOrgJSONAPI = false;
                            lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                            {
                                lblBitcoinExplorerEndpoints.Text = "❌";
                                lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                            });
                        }
                        if (Convert.ToString(bookmark.Data[4]) == "1")
                        {
                            RunBlockchainInfoEndpointAPI = true;
                            lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                            {
                                lblBlockchainInfoEndpoints.Text = "✔️";
                                lblBlockchainInfoEndpoints.ForeColor = Color.Green;
                            });
                        }
                        else
                        {
                            RunBlockchainInfoEndpointAPI = false;
                            lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                            {
                                lblBlockchainInfoEndpoints.Text = "❌";
                                lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                            });
                        }
                        if (Convert.ToString(bookmark.Data[5]) == "1")
                        {
                            lblPrivacyMode.Invoke((MethodInvoker)delegate
                            {
                                lblPrivacyMode.Enabled = true;
                                lblPrivacyMode.Text = "✔️";
                                lblPrivacyMode.ForeColor = Color.Green;
                            });
                            EnablePrivacyMode();
                        }
                        else
                        {
                            privacyMode = false;
                            lblPrivacyMode.Invoke((MethodInvoker)delegate
                            {
                                lblPrivacyMode.Text = "❌";
                                lblPrivacyMode.ForeColor = Color.IndianRed;
                            });

                            lblBlockchairComJSON.Enabled = true;
                            lblBitcoinExplorerEndpoints.Enabled = true;
                            lblBlockchainInfoEndpoints.Enabled = true;
                            lblSettingsNodeMainnet.Enabled = true;
                            lblSettingsNodeTestnet.Enabled = true;
                        }
                        if (Convert.ToString(bookmark.Data[6]) == "1")
                        {
                            lblUnused1.Invoke((MethodInvoker)delegate
                            {
                                lblUnused1.Text = "✔️";
                                lblUnused1.ForeColor = Color.Green;
                            });
                            lblUnused2.Invoke((MethodInvoker)delegate
                            {
                                lblUnused2.Text = "✔️";
                                lblUnused2.ForeColor = Color.Green;
                            });
                            lblUnused2.Enabled = true;

                        }
                        else
                        {
                            lblUnused1.Invoke((MethodInvoker)delegate
                            {
                                lblUnused1.Text = "❌";
                                lblUnused1.ForeColor = Color.IndianRed;
                            });
                            lblUnused2.Invoke((MethodInvoker)delegate
                            {
                                lblUnused2.Text = "❌";
                                lblUnused2.ForeColor = Color.IndianRed;
                            });
                            lblUnused2.Enabled = false;
                        }
                        if (Convert.ToString(bookmark.Data[7]) == "1")
                        {
                            lblUnused2.Invoke((MethodInvoker)delegate
                            {
                                lblUnused2.Text = "✔️";
                                lblUnused2.ForeColor = Color.Green;
                            });
                            lblUnused2.Enabled = true;
                        }
                        else
                        {
                            lblUnused2.Invoke((MethodInvoker)delegate
                            {
                                lblUnused2.Text = "❌";
                                lblUnused2.ForeColor = Color.IndianRed;
                            });
                            lblUnused2.Enabled = false;
                        }
                        numericUpDownDashboardRefresh.Value = Convert.ToInt32(bookmark.Data.Substring(8, 4));
                        numericUpDownMaxNumberOfConsecutiveUnusedAddresses.Value = Convert.ToInt32(bookmark.Data.Substring(12, 2));
                        numberUpDownDerivationPathsToCheck.Value = Convert.ToInt32(bookmark.Data.Substring(14, 3));
                        break;
                    }
                }

                // check if there is a node address saved in the bookmarks file
                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type == "node")
                    {
                        textBoxSettingsCustomMempoolURL.Text = bookmark.Data; // move it to the settings screen

                        nodeURLInFile = bookmark.Data;
                        nodeURLAlreadySavedInFile = true;
                        if (lblSettingsNodeCustom.Text == "✔️")
                        {
                            CheckCustomNodeIsOnline();
                        }
                        break;
                    }
                    nodeURLAlreadySavedInFile = false;
                }

                // check if there is an xpub node address saved in the bookmarks file
                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type == "xpubnode")
                    {
                        textBoxXpubNodeURL.Invoke((MethodInvoker)delegate
                        {
                            textBoxXpubNodeURL.Text = bookmark.Data; // move node url string to the form
                        });
                        textBoxSettingsXpubMempoolURL.Invoke((MethodInvoker)delegate
                        {
                            textBoxSettingsXpubMempoolURL.Text = bookmark.Data; // and to the settings screen
                        });
                        CheckXpubNodeIsOnline();
                        xpubNodeURLInFile = bookmark.Data;
                        xpubNodeURLAlreadySavedInFile = true;
                        break;
                    }
                    xpubNodeURLAlreadySavedInFile = false;
                }

                // check if there is a default theme saved in the bookmarks file
                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type == "defaulttheme")
                    {
                        var themes = ReadThemesFromJsonFile();
                        foreach (Theme theme in themes)
                        {
                            if (theme.ThemeName == bookmark.Data)
                            {
                                if (theme.ThemeName == "Genesis (preset)")
                                {
                                    BtnMenuThemeGenesis.Enabled = false;
                                    btnMenuThemeBTCdir.Enabled = true;
                                    btnMenuThemeSatsuma.Enabled = true;
                                    btnMenuThemeCustom.Enabled = true;
                                    lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonText.Text = "genesis";
                                        lblThemeMenuHighlightedButtonText.Location = new Point((BtnMenuThemeGenesis.Location.X + (BtnMenuThemeGenesis.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, BtnMenuThemeGenesis.Location.Y + 3);
                                    });
                                    lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonMarker.Location = new Point(BtnMenuThemeGenesis.Location.X, BtnMenuThemeGenesis.Location.Y + 5);
                                    });
                                }
                                else
                                {
                                    if (theme.ThemeName == "BTCdir (preset)")
                                    {
                                        BtnMenuThemeGenesis.Enabled = true;
                                        btnMenuThemeBTCdir.Enabled = false;
                                        btnMenuThemeSatsuma.Enabled = true;
                                        btnMenuThemeCustom.Enabled = true;
                                        lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                        {
                                            lblThemeMenuHighlightedButtonText.Text = "btcdir";
                                            lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeBTCdir.Location.X + (btnMenuThemeBTCdir.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeBTCdir.Location.Y + 3);
                                        });
                                        lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                        {
                                            lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeBTCdir.Location.X, btnMenuThemeBTCdir.Location.Y + 5);
                                        });
                                    }
                                    else
                                    {
                                        if (theme.ThemeName == "Satsuma (preset)")
                                        {
                                            BtnMenuThemeGenesis.Enabled = true;
                                            btnMenuThemeBTCdir.Enabled = true;
                                            btnMenuThemeSatsuma.Enabled = false;
                                            btnMenuThemeCustom.Enabled = true;
                                            lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                            {
                                                lblThemeMenuHighlightedButtonText.Text = "satsuma";
                                                lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeSatsuma.Location.X + (btnMenuThemeSatsuma.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeSatsuma.Location.Y + 3);
                                            });
                                            lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                            {
                                                lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeSatsuma.Location.X, btnMenuThemeSatsuma.Location.Y + 5);
                                            });
                                        }
                                        else
                                        {
                                            BtnMenuThemeGenesis.Enabled = true;
                                            btnMenuThemeBTCdir.Enabled = true;
                                            btnMenuThemeSatsuma.Enabled = true;
                                            btnMenuThemeCustom.Enabled = true;
                                            lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                            {
                                                lblThemeMenuHighlightedButtonText.Text = "custom";
                                                lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeCustom.Location.X + (btnMenuThemeCustom.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeCustom.Location.Y + 3);
                                            });
                                            lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                            {
                                                lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeCustom.Location.X, btnMenuThemeCustom.Location.Y + 5);
                                            });
                                        }
                                    }
                                }

                                RestoreTheme(theme);
                                defaultThemeInFile = bookmark.Data;
                                defaultThemeAlreadySavedInFile = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "RestoreSavedSettings");
            }
        }
        #endregion
        #endregion

        #region ⚡APPEARANCE SCREEN⚡
        #region top menu theme switching buttons
        private void BtnThemeMenu_Click(object sender, EventArgs e)
        {
            CloseMainMenu();
            CloseCurrencyMenu();
            panelThemeMenu.BringToFront();
            if (panelThemeMenu.Height == 24)
            {
                panelThemeMenu.Invoke((MethodInvoker)delegate
                {
                    panelThemeMenu.Height = 122;
                });
                btnThemeMenu.Invoke((MethodInvoker)delegate
                {
                    btnThemeMenu.BackColor = panelMenu.BackColor;
                });
            }
            else
            {
                CloseThemeMenu();
            }
        }
        private void BtnMenuThemeGenesis_Click(object sender, EventArgs e)
        {
            try
            {
                CloseThemeMenu();
                BtnMenuThemeGenesis.Enabled = false;
                btnMenuThemeBTCdir.Enabled = true;
                btnMenuThemeSatsuma.Enabled = true;
                btnMenuThemeCustom.Enabled = true;
                lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonText.Visible = true;
                    lblThemeMenuHighlightedButtonText.Text = "genesis";
                    lblThemeMenuHighlightedButtonText.Location = new Point((BtnMenuThemeGenesis.Location.X + (BtnMenuThemeGenesis.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, BtnMenuThemeGenesis.Location.Y + 3);
                });
                lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonMarker.Visible = true;
                    lblThemeMenuHighlightedButtonMarker.Location = new Point(BtnMenuThemeGenesis.Location.X, BtnMenuThemeGenesis.Location.Y + 5);
                });
                var themes = ReadThemesFromJsonFile();
                foreach (Theme theme in themes)
                {
                    if (theme.ThemeName == "Genesis (preset)")
                    {
                        RestoreTheme(theme);
                        SaveThemeAsDefault(theme.ThemeName);
                        // reload the listviews to apply the new color
                        LookupBlockList();
                        LookupBlock();
                        SetupBookmarksScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnMenuThemeGenesis_Click");
            }
        }

        private void BtnMenuThemeBTCdir_Click(object sender, EventArgs e)
        {
            try
            {
                CloseThemeMenu();
                BtnMenuThemeGenesis.Enabled = true;
                btnMenuThemeBTCdir.Enabled = false;
                btnMenuThemeSatsuma.Enabled = true;
                btnMenuThemeCustom.Enabled = true;
                lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonText.Visible = true;
                    lblThemeMenuHighlightedButtonText.Text = "btcdir";
                    lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeBTCdir.Location.X + (btnMenuThemeBTCdir.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeBTCdir.Location.Y + 3);
                });
                lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonMarker.Visible = true;
                    lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeBTCdir.Location.X, btnMenuThemeBTCdir.Location.Y + 5);
                });
                var themes = ReadThemesFromJsonFile();
                foreach (Theme theme in themes)
                {
                    if (theme.ThemeName == "BTCdir (preset)")
                    {
                        RestoreTheme(theme);
                        SaveThemeAsDefault(theme.ThemeName);
                        // reload the listviews to apply the new color
                        LookupBlockList();
                        LookupBlock();
                        SetupBookmarksScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnMenuThemeBTCdir_Click");
            }
        }

        private void BtnMenuThemeSatsuma_Click(object sender, EventArgs e)
        {
            try
            {
                CloseThemeMenu();
                BtnMenuThemeGenesis.Enabled = true;
                btnMenuThemeBTCdir.Enabled = true;
                btnMenuThemeSatsuma.Enabled = false;
                btnMenuThemeCustom.Enabled = true;
                lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonText.Visible = true;
                    lblThemeMenuHighlightedButtonText.Text = "satsuma";
                    lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeSatsuma.Location.X + (btnMenuThemeSatsuma.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeSatsuma.Location.Y + 3);
                });
                lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblThemeMenuHighlightedButtonMarker.Visible = true;
                    lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeSatsuma.Location.X, btnMenuThemeSatsuma.Location.Y + 5);
                });
                var themes = ReadThemesFromJsonFile();
                foreach (Theme theme in themes)
                {
                    if (theme.ThemeName == "Satsuma (preset)")
                    {
                        RestoreTheme(theme);
                        SaveThemeAsDefault(theme.ThemeName);
                        // reload the listviews to apply the new color
                        LookupBlockList();
                        LookupBlock();
                        SetupBookmarksScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnMenuThemeSatsuma_Click");
            }
        }

        private void BtnMenuThemeCustom_Click(object sender, EventArgs e)
        {
            CloseThemeMenu();
            BtnMenuThemeGenesis.Enabled = true;
            btnMenuThemeBTCdir.Enabled = true;
            btnMenuThemeSatsuma.Enabled = true;
            btnMenuThemeCustom.Enabled = true;
            lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
            {
                lblThemeMenuHighlightedButtonText.Visible = false;
                lblThemeMenuHighlightedButtonText.Text = "custom";
                lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeCustom.Location.X + (btnMenuThemeCustom.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeCustom.Location.Y + 3);
            });
            lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
            {
                lblThemeMenuHighlightedButtonMarker.Visible = false;
                lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeCustom.Location.X, btnMenuThemeCustom.Location.Y + 5);
            });
            BtnAppearance_Click(sender, e);
        }
        #endregion
        #region select colours
        private void BtnColorDataFields_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForDataFields = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForDataFields.ShowDialog() == DialogResult.OK)
                {
                    ColorDataFields(colorDlgForDataFields.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorDataFields_Click");
            }
        }

        private void BtnColorLabels_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForLabels = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForLabels.ShowDialog() == DialogResult.OK)
                {
                    ColorLabels(colorDlgForLabels.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorLabels_Click");
            }
        }

        private void BtnColorPanels_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForPanels = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForPanels.ShowDialog() == DialogResult.OK)
                {
                    ColorPanels(colorDlgForPanels.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorPanels_Click");
            }
        }

        private void BtnColorHeadings_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForHeadings = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForHeadings.ShowDialog() == DialogResult.OK)
                {
                    ColorHeadings(colorDlgForHeadings.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorHeadings_Click");
            }
        }

        private void BtnColorProgressBars_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForProgressBars = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForProgressBars.ShowDialog() == DialogResult.OK)
                {
                    ColorProgressBars(colorDlgForProgressBars.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorProgressBars_Click");
            }
        }

        private void BtnColorButtons_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForButtons = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForButtons.ShowDialog() == DialogResult.OK)
                {
                    ColorButtons(colorDlgForButtons.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorButtons_Click");
            }
        }

        private void BtnColorButtonText_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForButtonText = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForButtonText.ShowDialog() == DialogResult.OK)
                {
                    ColorButtonText(colorDlgForButtonText.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorButtonText_Click");
            }
        }

        private void BtnColorLines_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForLines = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForLines.ShowDialog() == DialogResult.OK)
                {
                    ColorLines(colorDlgForLines.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorLines_Click");
            }
        }

        private void BtnColorTableText_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForTableText = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForTableText.ShowDialog() == DialogResult.OK)
                {
                    ColorTables(colorDlgForTableText.Color);
                    // reload the listviews to apply the new color
                    LookupBlockList();
                    LookupBlock();
                    SetupBookmarksScreen();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorTableText_Click");
            }
        }

        private void BtnColorOtherText_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForOtherText = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForOtherText.ShowDialog() == DialogResult.OK)
                {
                    ColorOtherText(colorDlgForOtherText.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorOtherText_Click");
            }
        }

        private void BtnColorTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForTextBoxes = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForTextBoxes.ShowDialog() == DialogResult.OK)
                {
                    ColorTextBoxes(colorDlgForTextBoxes.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorTextBox_Click");
            }
        }

        private void BtnColorPriceBlock_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForPriceBlock = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForPriceBlock.ShowDialog() == DialogResult.OK)
                {
                    ColorPriceBlock(colorDlgForPriceBlock.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorPriceBlock_Click");
            }
        }

        private void BtnColorStatusError_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForStatusError = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForStatusError.ShowDialog() == DialogResult.OK)
                {
                    ColorStatusError(colorDlgForStatusError.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorStatusError_Click");
            }
        }

        private void BtnColorTableBackground_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForTableBackgrounds = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Black
                };

                if (colorDlgForTableBackgrounds.ShowDialog() == DialogResult.OK)
                {
                    ColorTableBackgrounds(colorDlgForTableBackgrounds.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorTableBackground_Click");
            }
        }

        private void BtnColorTableTitleBar_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForlistViewTitleBarBG = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Black
                };

                if (colorDlgForlistViewTitleBarBG.ShowDialog() == DialogResult.OK)
                {
                    ColorTableTitleBars(colorDlgForlistViewTitleBarBG.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorTableTitleBar_Click");
            }
        }

        private void BtnListViewHeadingColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForTableHeadings = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Black
                };

                if (colorDlgForTableHeadings.ShowDialog() == DialogResult.OK)
                {
                    ColorTableHeadings(colorDlgForTableHeadings.Color);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnListViewHeadingColor_Click");
            }
        }

        #endregion
        #region enable/disable realtime clock in genesis background
        private void LblShowClock_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblShowClock.Text == "✔️")
                {
                    lblShowClock.Invoke((MethodInvoker)delegate
                    {
                        lblShowClock.ForeColor = Color.IndianRed;
                        lblShowClock.Text = "❌";
                    });
                    lblTime.Visible = false;
                }
                else
                {
                    lblShowClock.Invoke((MethodInvoker)delegate
                    {
                        lblShowClock.ForeColor = Color.Green;
                        lblShowClock.Text = "✔️";
                    });
                    if (lblBackgroundGenesisSelected.Visible == true)
                    {
                        lblTime.Font = new Font(lblTime.Font.FontFamily, 14, lblTime.Font.Style);
                        lblTime.Location = new Point(697, 91);
                        lblTime.Visible = true;
                        lblTime.BringToFront();
                    }
                    else
                    {
                        lblTime.Visible = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblShowClock_Click");
            }
        }
        #endregion
        #region select loading animation
        private void LabelInfinity1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInfinity1.Text == "✔️")
                {
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.IndianRed;
                        lblInfinity1.Text = "❌";
                    });
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.Green;
                        lblInfinity2.Text = "✔️";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                }
                else
                {
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.Green;
                        lblInfinity1.Text = "✔️";
                    });
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.IndianRed;
                        lblInfinity2.Text = "❌";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                }
            }

            catch (Exception ex)
            {
                HandleException(ex, "lbllblInfinity1_Click");
            }
        }

        private void LblInfinity2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInfinity2.Text == "✔️")
                {
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.IndianRed;
                        lblInfinity2.Text = "❌";
                    });
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.Green;
                        lblInfinity1.Text = "✔️";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                }
                else
                {
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.Green;
                        lblInfinity2.Text = "✔️";
                    });
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.IndianRed;
                        lblInfinity1.Text = "❌";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                }
            }

            catch (Exception ex)
            {
                HandleException(ex, "lbllblInfinity1_Click");
            }
        }
        #endregion
        #region charts background colour
        private void LblChartsLightBackground_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblChartsLightBackground.Text == "✔️")
                {
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.IndianRed;
                        lblChartsLightBackground.Text = "❌";
                    });
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.Green;
                        lblChartsDarkBackground.Text = "✔️";
                    });
                    chartsBackgroundColor = Color.FromArgb(20, 20, 20);
                }
                else
                {
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.Green;
                        lblChartsLightBackground.Text = "✔️";
                    });
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.IndianRed;
                        lblChartsDarkBackground.Text = "❌";
                    });
                    chartsBackgroundColor = Color.FromArgb(255, 255, 255);
                }
                CustomiseCharts(lblHeaderPrice.ForeColor);
            }

            catch (Exception ex)
            {
                HandleException(ex, "lblChartsLightBackground_Click");
            }
        }

        private void LblChartsDarkBackground_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblChartsDarkBackground.Text == "✔️")
                {
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.IndianRed;
                        lblChartsDarkBackground.Text = "❌";
                    });
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.Green;
                        lblChartsLightBackground.Text = "✔️";
                    });
                    chartsBackgroundColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.Green;
                        lblChartsDarkBackground.Text = "✔️";
                    });
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.IndianRed;
                        lblChartsLightBackground.Text = "❌";
                    });
                    chartsBackgroundColor = Color.FromArgb(20, 20, 20);
                }
                CustomiseCharts(lblHeaderPrice.ForeColor);
            }
            catch (Exception ex)
            {
                HandleException(ex, "lblChartsDarkBackground_Click");
            }
        }
        #endregion
        #region background picture/colour
        private void PictureBoxGenesis_Click(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.BackgroundImage = Properties.Resources.AppBackground2;
                });
                lblBackgroundGenesisSelected.Visible = true;
                lblBackgroundBTCdirSelected.Visible = false;
                lblBackgroundSatsumaSelected.Visible = false;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = false;
                lblTime.Visible = true;
                label194.Enabled = false;
                textBoxThemeImage.Enabled = false;
                textBoxThemeImage.Invoke((MethodInvoker)delegate
                {
                    textBoxThemeImage.Text = "";
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxGenesis_Click");
            }
        }

        private void PictureBoxBTCDir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.BackgroundImage = Properties.Resources.SatsumaBTCdir1;
                });
                lblTime.Visible = false;
                lblBackgroundGenesisSelected.Visible = false;
                lblBackgroundSatsumaSelected.Visible = false;
                lblBackgroundBTCdirSelected.Visible = true;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = false;
                label194.Enabled = false;
                textBoxThemeImage.Enabled = false;
                textBoxThemeImage.Invoke((MethodInvoker)delegate
                {
                    textBoxThemeImage.Text = "";
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxBTCDir_Click");
            }
        }

        private void PictureBoxSatsuma_Click(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.BackgroundImage = Properties.Resources.Satsuma3;
                });
                lblTime.Visible = false;
                lblBackgroundGenesisSelected.Visible = false;
                lblBackgroundBTCdirSelected.Visible = false;
                lblBackgroundSatsumaSelected.Visible = true;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = false;
                label194.Enabled = false;
                textBoxThemeImage.Enabled = false;
                textBoxThemeImage.Invoke((MethodInvoker)delegate
                {
                    textBoxThemeImage.Text = "";
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxSatsuma_Click");
            }

        }

        private void PictureBoxCustomImage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog
                {
                    Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG;|" + "All files (*.*)|*.*"
                };

                //openFileDialog1.ShowDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog1.FileName;
                    this.BackgroundImage = System.Drawing.Image.FromFile(selectedFilePath);
                    pictureBoxCustomImage.Image = System.Drawing.Image.FromFile(selectedFilePath);
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = false;
                    lblBackgroundCustomImageSelected.Visible = true;
                    lblTime.Visible = false;
                    label194.Enabled = true;
                    textBoxThemeImage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxCustomImage_Click");
            }
        }

        private void PictureBoxCustomColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForFormBackground = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Red
                };

                if (colorDlgForFormBackground.ShowDialog() == DialogResult.OK)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.BackColor = colorDlgForFormBackground.Color;
                        panel33.BackColor = colorDlgForFormBackground.Color;
                        panel30.BackColor = colorDlgForFormBackground.Color;
                        panel24.BackColor = colorDlgForFormBackground.Color;
                        panel25.BackColor = colorDlgForFormBackground.Color;
                        this.BackgroundImage = null;
                    });
                    lblTime.Visible = false;
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = true;
                    lblBackgroundCustomImageSelected.Visible = false;
                    label194.Enabled = false;
                    textBoxThemeImage.Enabled = false;
                    textBoxThemeImage.Invoke((MethodInvoker)delegate
                    {
                        textBoxThemeImage.Text = "";
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "PictureBoxCustomColor_Click");
            }
        }
        #endregion
        #region title backgrounds
        private void LblTitleBackgroundNone_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTitleBackgroundNone.Text != "✔️")
                {
                    HeadingBackgroundsToNone();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblTitleBackgroundNone_Click");
            }
        }

        private void LblTitleBackgroundDefault_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTitleBackgroundDefault.Text != "✔️")
                {
                    HeadingBackgroundsToDefault();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblTitleBackgroundDefault_Click");
            }
        }

        private void BtnColorTitleBackgrounds_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDlgForTitleBackgrounds = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = true,
                    Color = Color.Black
                };

                if (colorDlgForTitleBackgrounds.ShowDialog() == DialogResult.OK)
                {
                    titleBackgroundColor = colorDlgForTitleBackgrounds.Color;
                    lblTitleBackgroundCustom.ForeColor = Color.Green;
                    lblTitleBackgroundCustom.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundCustom.Text = "✔️";
                    });
                    lblTitleBackgroundNone.ForeColor = Color.IndianRed;
                    lblTitleBackgroundNone.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundNone.Text = "❌";
                    });
                    lblTitleBackgroundDefault.ForeColor = Color.IndianRed;
                    lblTitleBackgroundDefault.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundDefault.Text = "❌";
                    });

                    SetCustomTitleBackgroundColor();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnColorTitleBackgrounds_Click");
            }
        }

        private void LblTitleBackgroundCustom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTitleBackgroundCustom.Text != "✔️")
                {
                    lblTitleBackgroundCustom.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundCustom.Text = "✔️";
                        lblTitleBackgroundCustom.ForeColor = Color.Green;
                    });
                    lblTitleBackgroundNone.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundNone.Text = "❌";
                        lblTitleBackgroundNone.ForeColor = Color.IndianRed;
                    });
                    lblTitleBackgroundDefault.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundDefault.Text = "❌";
                        lblTitleBackgroundDefault.ForeColor = Color.IndianRed;
                    });
                    SetCustomTitleBackgroundColor();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "LblTitleBackgroundCustom_Click");
            }
        }

        private void SetCustomTitleBackgroundColor()
        {
            try
            {
                HeadingBackgroundsToCustomColor();
            }
            catch (Exception ex)
            {
                HandleException(ex, "SetCustomTitleBackgroundColor");
            }
        }
        #endregion
        #region read theme from file
        private static List<Theme> ReadThemesFromJsonFile()
        {
            string themesFileName = "SATSuma_themes.json";
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string applicationDirectory = Path.Combine(appDataDirectory, "SATSuma");
            // Create the application directory if it doesn't exist
            Directory.CreateDirectory(applicationDirectory);
            string themesFilePath = Path.Combine(applicationDirectory, themesFileName);
            string filePath = themesFilePath;

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Dispose();
            }
            // Read the contents of the JSON file into a string
            string json = System.IO.File.ReadAllText(filePath);

            // Deserialize the JSON string into a list of bookmark objects
            var themes = JsonConvert.DeserializeObject<List<Theme>>(json);

            // If the JSON file doesn't exist or is empty, return an empty list
            themes ??= new List<Theme>();

            return themes;
        }
        #endregion
        #region construct theme record to be saved
        private void TextBoxThemeName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxThemeName.Text.Length > 0)
            {
                btnSaveTheme.Enabled = true;
            }
            else
            {
                btnSaveTheme.Enabled = false;
            }
        }

        private void BtnSaveTheme_Click(object sender, EventArgs e)
        {
            try
            {
                //take the selected color values from examples on the appearance screen
                Color datafields = label154.ForeColor;
                Color labels = label73.ForeColor;
                Color headings = label156.ForeColor;
                Color tables = label170.ForeColor;
                Color tableheadings = label190.ForeColor;
                Color othertext = label173.ForeColor;
                Color priceblock = label175.ForeColor;
                Color statuserrors = label176.ForeColor;
                Color buttons = button1.BackColor;
                Color buttontext = button2.ForeColor;
                Color lines = panel61.BackColor;
                Color textboxes = textBox1.BackColor;
                Color progressbars = colorProgressBar1.BarColor;
                Color tablebackgrounds = panel66.BackColor;
                Color tabletitlebars = panel67.BackColor;
                Color panels = panel73.BackColor;
                bool chartsDark = false;
                if (lblChartsDarkBackground.Text == "✔️")
                {
                    chartsDark = true;
                }

                bool showtime = lblTime.Visible;
                bool headingbgdefault = false;
                if (lblTitleBackgroundDefault.Text == "✔️")
                {
                    headingbgdefault = true;
                }
                bool headingbgnone = false;
                if (lblTitleBackgroundNone.Text == "✔️")
                {
                    headingbgnone = true;
                }
                bool headingbgcustom = false;
                if (lblTitleBackgroundCustom.Text == "✔️")
                {
                    headingbgcustom = true;
                }
                bool backgroundgenesis = false;
                if (lblBackgroundGenesisSelected.Visible == true)
                {
                    backgroundgenesis = true;
                }
                bool backgroundbtcdir = false;
                if (lblBackgroundBTCdirSelected.Visible == true)
                {
                    backgroundbtcdir = true;
                }
                bool backgroundSatsuma = false;
                if (lblBackgroundSatsumaSelected.Visible == true)
                {
                    backgroundSatsuma = true;
                }
                bool backgroundcustomcolor = false;
                if (lblBackgroundCustomColorSelected.Visible == true)
                {
                    backgroundcustomcolor = true;
                }
                bool backgroundcustomimage = false;
                if (lblBackgroundCustomImageSelected.Visible == true)
                {
                    backgroundcustomimage = true;
                }
                Color headingbackgrounds = panel64.BackColor;
                Color windowbackground = this.BackColor;
                string windowimage = "";
                if (lblBackgroundGenesisSelected.Visible)
                {
                    windowimage = "AppBackground2.png";
                }
                else
                {
                    if (lblBackgroundBTCdirSelected.Visible)
                    {
                        windowimage = "SatsumaBTCdir.png";
                    }
                    else
                    {
                        if (lblBackgroundSatsumaSelected.Visible)
                        {
                            windowimage = "Satsuma3.png";
                        }
                        else
                        {
                            if (this.BackgroundImage != null && textBoxThemeImage.Text.Length > 0)
                            {
                                windowimage = textBoxThemeImage.Text;
                            }
                            else
                            {
                                windowimage = "";
                            }
                        }
                    }
                }
                bool orangeinfinity = true;
                if (lblInfinity1.Text == "✔️")
                {
                    orangeinfinity = false;
                }
                var newTheme = new Theme { ThemeName = textBoxThemeName.Text, DataFields = datafields, Labels = labels, Headings = headings, Tables = tables, TableHeadings = tableheadings, OtherText = othertext, PriceBlock = priceblock, StatusErrors = statuserrors, Buttons = buttons, ButtonText = buttontext, Lines = lines, TextBoxes = textboxes, ProgressBars = progressbars, TableBackgrounds = tablebackgrounds, TableTitleBars = tabletitlebars, ShowTime = showtime, HeadingBGDefault = headingbgdefault, HeadingBGNone = headingbgnone, HeadingBGCustom = headingbgcustom, HeadingBackgrounds = headingbackgrounds, WindowBackground = windowbackground, WindowImage = windowimage, BackgroundGenesis = backgroundgenesis, BackgroundBTCdir = backgroundbtcdir, BackgroundSatsuma = backgroundSatsuma, BackgroundCustomColor = backgroundcustomcolor, BackgroundCustomImage = backgroundcustomimage, Panels = panels, ChartsDark = chartsDark, OrangeInfinity = orangeinfinity };

                // Read the existing themes from the JSON file
                var themes = ReadThemesFromJsonFile();

                // Add the new theme to the list
                themes.Add(newTheme);

                // Write the updated list of themes back to the JSON file
                WriteThemeToJsonFile(themes);

                SaveThemeAsDefault(textBoxThemeName.Text);
                // repopulate the dropdown list with the available themes
                themes.Clear();
                themes = ReadThemesFromJsonFile();
                List<string> themeNames = themes.Select(t => t.ThemeName).ToList();
                comboBoxThemeList.DataSource = themeNames;
                lblThemeSaved.Visible = true;
                hideThemeSavedTimer.Start();
                textBoxThemeName.Invoke((MethodInvoker)delegate
                {
                    textBoxThemeName.Text = "";
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnSaveTheme_Click");
            }
        }
        #endregion
        #region write theme to file
        private static void WriteThemeToJsonFile(List<Theme> themes)
        {
            // Serialize the list of bookmark objects into a JSON string
            string json = JsonConvert.SerializeObject(themes);

            string themesFileName = "SATSuma_themes.json";
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string applicationDirectory = Path.Combine(appDataDirectory, "SATSuma");
            // Create the application directory if it doesn't exist
            Directory.CreateDirectory(applicationDirectory);
            string themesFilePath = Path.Combine(applicationDirectory, themesFileName);
            string filePath = themesFilePath;

            // Write the JSON string to the themes.json file
            System.IO.File.WriteAllText(filePath, json);
        }
        #endregion
        #region select previously saved theme from list
        private void BtnLoadTheme_Click(object sender, EventArgs e)
        {
            try
            {
                var themes = ReadThemesFromJsonFile();
                foreach (Theme theme in themes)
                {
                    if (theme.ThemeName == comboBoxThemeList.Text)
                    {
                        if (theme.ThemeName == "Genesis (preset)")
                        {
                            BtnMenuThemeGenesis.Enabled = false;
                            btnMenuThemeBTCdir.Enabled = true;
                            btnMenuThemeSatsuma.Enabled = true;
                            btnMenuThemeCustom.Enabled = true;
                            lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                            {
                                lblThemeMenuHighlightedButtonText.Text = "genesis";
                                lblThemeMenuHighlightedButtonText.Location = new Point((BtnMenuThemeGenesis.Location.X + (BtnMenuThemeGenesis.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, BtnMenuThemeGenesis.Location.Y + 3);
                            });
                            lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                            {
                                lblThemeMenuHighlightedButtonMarker.Location = new Point(BtnMenuThemeGenesis.Location.X, BtnMenuThemeGenesis.Location.Y + 5);
                            });
                        }
                        else
                        {
                            if (theme.ThemeName == "BTCdir (preset)")
                            {
                                BtnMenuThemeGenesis.Enabled = true;
                                btnMenuThemeBTCdir.Enabled = false;
                                btnMenuThemeSatsuma.Enabled = true;
                                btnMenuThemeCustom.Enabled = true;
                                lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                {
                                    lblThemeMenuHighlightedButtonText.Text = "btcdir";
                                    lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeBTCdir.Location.X + (btnMenuThemeBTCdir.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeBTCdir.Location.Y + 3);
                                });
                                lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                {
                                    lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeBTCdir.Location.X, btnMenuThemeBTCdir.Location.Y + 5);
                                });
                            }
                            else
                            {
                                if (theme.ThemeName == "Satsuma (preset)")
                                {
                                    BtnMenuThemeGenesis.Enabled = true;
                                    btnMenuThemeBTCdir.Enabled = true;
                                    btnMenuThemeSatsuma.Enabled = false;
                                    btnMenuThemeCustom.Enabled = true;
                                    lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonText.Text = "satsuma";
                                        lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeSatsuma.Location.X + (btnMenuThemeSatsuma.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeSatsuma.Location.Y + 3);
                                    });
                                    lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeSatsuma.Location.X, btnMenuThemeSatsuma.Location.Y + 5);
                                    });
                                }
                                else
                                {
                                    BtnMenuThemeGenesis.Enabled = true;
                                    btnMenuThemeBTCdir.Enabled = true;
                                    btnMenuThemeSatsuma.Enabled = true;
                                    btnMenuThemeCustom.Enabled = true;
                                    lblThemeMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonText.Text = "custom";
                                        lblThemeMenuHighlightedButtonText.Location = new Point((btnMenuThemeCustom.Location.X + (btnMenuThemeCustom.Width / 2)) - lblThemeMenuHighlightedButtonText.Width / 2, btnMenuThemeCustom.Location.Y + 3);
                                    });
                                    lblThemeMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                                    {
                                        lblThemeMenuHighlightedButtonMarker.Location = new Point(btnMenuThemeCustom.Location.X, btnMenuThemeCustom.Location.Y + 5);
                                    });
                                }
                            }
                        }

                        RestoreTheme(theme);
                        SaveThemeAsDefault(theme.ThemeName);
                        // reload the listviews to apply the new color
                        LookupBlockList();
                        LookupBlock();
                        SetupBookmarksScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnLoadTheme_Click");
            }
        }
        #endregion
        #region restore theme
        private void RestoreTheme(Theme theme)
        {
            try
            {
                if (theme.ChartsDark == true)
                {
                    chartsBackgroundColor = Color.FromArgb(20, 20, 20);
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.IndianRed;
                        lblChartsLightBackground.Text = "❌";
                    });
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.Green;
                        lblChartsDarkBackground.Text = "✔️";
                    });
                }
                else
                {
                    chartsBackgroundColor = Color.FromArgb(255, 255, 255);
                    lblChartsLightBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsLightBackground.ForeColor = Color.Green;
                        lblChartsLightBackground.Text = "✔️";
                    });
                    lblChartsDarkBackground.Invoke((MethodInvoker)delegate
                    {
                        lblChartsDarkBackground.ForeColor = Color.IndianRed;
                        lblChartsDarkBackground.Text = "❌";
                    });
                }
                CustomiseCharts(theme.PriceBlock);
                ColorDataFields(theme.DataFields);
                labelColor = theme.Labels; // (only used for poolranking chart title)
                ColorLabels(theme.Labels);
                ColorHeadings(theme.Headings);
                ColorTables(theme.Tables);
                ColorTableHeadings(theme.TableHeadings);
                ColorOtherText(theme.OtherText);
                ColorPriceBlock(theme.PriceBlock);
                ColorStatusError(theme.StatusErrors);
                ColorButtons(theme.Buttons);
                ColorButtonText(theme.ButtonText);
                ColorLines(theme.Lines);
                ColorTextBoxes(theme.TextBoxes);
                ColorProgressBars(theme.ProgressBars);
                ColorTableBackgrounds(theme.TableBackgrounds);
                ColorTableTitleBars(theme.TableTitleBars);
                ColorPanels(theme.Panels);

                if (theme.ShowTime == false)
                {
                    lblShowClock.Invoke((MethodInvoker)delegate
                    {
                        lblShowClock.ForeColor = Color.IndianRed;
                        lblShowClock.Text = "❌";
                    });
                    lblTime.Visible = false;
                }
                else
                {
                    lblShowClock.Invoke((MethodInvoker)delegate
                    {
                        lblShowClock.ForeColor = Color.Green;
                        lblShowClock.Text = "✔️";
                    });
                    if (theme.BackgroundGenesis == true)
                    {
                        lblTime.Font = new Font(lblTime.Font.FontFamily, 14, lblTime.Font.Style);
                        lblTime.Location = new Point(697, 91);
                        lblTime.Visible = true;
                        lblTime.BringToFront();
                    }
                }
                if (theme.HeadingBGDefault == true)
                {
                    HeadingBackgroundsToDefault();
                }
                if (theme.HeadingBGNone == true)
                {
                    HeadingBackgroundsToNone();
                }
                if (theme.HeadingBGCustom == true)
                {
                    lblTitleBackgroundCustom.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundCustom.ForeColor = Color.Green;
                        lblTitleBackgroundCustom.Text = "✔️";
                    });
                    lblTitleBackgroundNone.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundNone.ForeColor = Color.IndianRed;
                        lblTitleBackgroundNone.Text = "❌";
                    });
                    lblTitleBackgroundDefault.Invoke((MethodInvoker)delegate
                    {
                        lblTitleBackgroundDefault.ForeColor = Color.IndianRed;
                        lblTitleBackgroundDefault.Text = "❌";
                    });
                    titleBackgroundColor = theme.HeadingBackgrounds;
                    HeadingBackgroundsToCustomColor();
                }
                if (theme.BackgroundBTCdir == true)
                {
                    lblBackgroundBTCdirSelected.ForeColor = Color.Green;
                    lblBackgroundBTCdirSelected.Visible = true;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = false;
                    lblBackgroundCustomImageSelected.Visible = false;
                    this.BackgroundImage = Properties.Resources.SatsumaBTCdir1;
                }
                if (theme.BackgroundGenesis == true)
                {
                    lblBackgroundGenesisSelected.ForeColor = Color.Green;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundGenesisSelected.Visible = true;
                    lblBackgroundCustomColorSelected.Visible = false;
                    lblBackgroundCustomImageSelected.Visible = false;
                    this.BackgroundImage = Properties.Resources.AppBackground2;
                }
                if (theme.BackgroundSatsuma == true)
                {
                    lblBackgroundSatsumaSelected.ForeColor = Color.Green;
                    lblBackgroundSatsumaSelected.Visible = true;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = false;
                    lblBackgroundCustomImageSelected.Visible = false;
                    this.BackgroundImage = Properties.Resources.Satsuma3;
                }
                if (theme.BackgroundCustomColor == true)
                {
                    lblBackgroundCustomColorSelected.ForeColor = Color.Green;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = true;
                    lblBackgroundCustomImageSelected.Visible = false;
                    this.BackgroundImage = null;
                    this.BackColor = theme.WindowBackground;
                }
                if (theme.BackgroundCustomImage == true)
                {
                    lblBackgroundCustomImageSelected.ForeColor = Color.Green;
                    lblBackgroundBTCdirSelected.Visible = false;
                    lblBackgroundSatsumaSelected.Visible = false;
                    lblBackgroundGenesisSelected.Visible = false;
                    lblBackgroundCustomColorSelected.Visible = false;
                    lblBackgroundCustomImageSelected.Visible = true;
                    this.BackgroundImage = System.Drawing.Image.FromFile(theme.WindowImage);
                }
                if (theme.OrangeInfinity == true)
                {
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.Green;
                        lblInfinity2.Text = "✔️";
                    });
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.IndianRed;
                        lblInfinity1.Text = "❌";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.OrangeInfinity;
                }
                else
                {
                    lblInfinity2.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity2.ForeColor = Color.IndianRed;
                        lblInfinity2.Text = "❌";
                    });
                    lblInfinity1.Invoke((MethodInvoker)delegate
                    {
                        lblInfinity1.ForeColor = Color.Green;
                        lblInfinity1.Text = "✔️";
                    });
                    pictureBoxLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                    pictureBoxChartLoadingAnimation.Image = Properties.Resources.InfinityTrans;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "RestoreTheme");
            }
        }
        #endregion
        #region apply changes to lists of controls
        private void CustomiseCharts(Color thisColor)
        {
            formsPlot1.Plot.Margins(x: .1, y: .1);
            formsPlot1.Plot.Style(ScottPlot.Style.Black);
            formsPlot1.RightClicked -= formsPlot1.DefaultRightClickEvent; // disable default right-click event
            formsPlot1.Configuration.DoubleClickBenchmark = false;
            formsPlot1.Plot.Palette = ScottPlot.Palette.Amber;
            formsPlot1.Plot.YAxis.AxisLabel.IsVisible = false;
            
            
            formsPlot2.Plot.Margins(x: .1, y: .1);
            formsPlot2.Plot.Style(ScottPlot.Style.Black);
            formsPlot2.RightClicked -= formsPlot2.DefaultRightClickEvent; // disable default right-click event
            formsPlot2.Configuration.DoubleClickBenchmark = false;
            formsPlot2.Configuration.Pan = false;
            formsPlot2.Configuration.RightClickDragZoom = false;
            formsPlot2.Configuration.LeftClickDragPan = false;
            formsPlot2.Configuration.Zoom = false;

            formsPlot3.Plot.Margins(x: .1, y: .1);
            formsPlot3.Plot.Style(ScottPlot.Style.Black);
            formsPlot3.RightClicked -= formsPlot3.DefaultRightClickEvent; // disable default right-click event
            formsPlot3.Configuration.DoubleClickBenchmark = false;
            formsPlot3.Plot.Palette = ScottPlot.Palette.Amber;
            formsPlot3.Plot.YAxis.AxisLabel.IsVisible = false;

            formsPlot1.Plot.Style(
                figureBackground: Color.Transparent,
                dataBackground: chartsBackgroundColor,
                //titleLabel: headerNetworkName.ForeColor, // using any random label to get the color from
                titleLabel: thisColor, // using any random label to get the color from
                //axisLabel: headerNetworkName.ForeColor); // using any random label to get the color from
                axisLabel: thisColor); // using any random label to get the color from
            formsPlot2.Plot.Style(
                figureBackground: Color.Transparent,
                dataBackground: chartsBackgroundColor,
                //titleLabel: headerNetworkName.ForeColor, // using any random label to get the color from
                titleLabel: thisColor, // using any random label to get the color from
                                                      //axisLabel: headerNetworkName.ForeColor); // using any random label to get the color from
                axisLabel: thisColor); // using any random label to get the color from
            formsPlot3.Plot.Style(
                figureBackground: Color.Transparent,
                dataBackground: chartsBackgroundColor,
                //titleLabel: headerNetworkName.ForeColor, // using any random label to get the color from
                titleLabel: thisColor, // using any random label to get the color from
                                                      //axisLabel: headerNetworkName.ForeColor); // using any random label to get the color from
                axisLabel: thisColor); // using any random label to get the color from
            panelFeeRatesKey.BackColor = chartsBackgroundColor;
            panelCirculationKey.BackColor = chartsBackgroundColor;
            panelPriceScaleButtons.BackColor = chartsBackgroundColor;
            panelChartMarketCapScaleButtons.BackColor = chartsBackgroundColor;
            panelChartUTXOScaleButtons.BackColor = chartsBackgroundColor;
            panelUniqueAddressesScaleButtons.BackColor = chartsBackgroundColor;
            panelLightningNodeNetwork.BackColor = chartsBackgroundColor;
            panelPriceConvert.BackColor = chartsBackgroundColor;
            Color newGridlineColor = Color.FromArgb(40, 40, 40);
            if (lblChartsLightBackground.Text == "✔️")
            {
                newGridlineColor = Color.FromArgb(220, 220, 220);
            }

            // Update the Grid color
            formsPlot1.Plot.Style(grid: newGridlineColor);
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void ColorDataFields(Color thisColor)
        {
            try
            {
                //header
                Control[] listHeaderDataFieldsToColor = { lblHeaderMarketCap, lblHeaderMoscowTime, lblTransactions, lblHeaderBlockSize, lblfeesHighPriority, lblFeesMediumPriority, lblFeesLowPriority, lblFeesNoPriority, lblHeaderHashrate, lblBlockBlockHeight };
                foreach (Control control in listHeaderDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardDataFieldsToColor = { lblPriceUSD, lblMoscowTime, lblMarketCapUSD, lblBTCInCirc, lblHodlingAddresses, lblAvgNoTransactions, lblBlocksIn24Hours, lbl24HourTransCount, lbl24HourBTCSent, lblTXInMempool, lblNextBlockMinMaxFee, lblNextBlockTotalFees, lblTransInNextBlock, lblHashesToSolve, lblAvgTimeBetweenBlocks, lblEstHashrate, lblNextDiffAdjBlock, lblDifficultyAdjEst, lblBlockReward, lblProgressNextDiffAdjPercentage, lblBlocksUntilDiffAdj, lblEstDiffAdjDate, lblNodes, lblBlockchainSize, lblHalveningBlock, lblEstimatedHalvingDate, lblHalvingSecondsRemaining, lblBlockRewardAfterHalving };
                foreach (Control control in listBitcoinDashboardDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //lightningdashboard
                Control[] listLightningDashboardDataFieldsToColor = { lblTotalCapacity, lblClearnetCapacity, lblTorCapacity, lblUnknownCapacity, lblNodeCount, lblTorNodes, lblClearnetNodes, lblClearnetTorNodes, lblUnannouncedNodes, lblChannelCount, lblAverageCapacity, lblAverageFeeRate, lblAverageBaseFeeMtokens, lblMedCapacity, lblMedFeeRate, lblMedBaseFeeTokens, aliasLabel1, aliasLabel2, aliasLabel3, aliasLabel4, aliasLabel5, aliasLabel6, aliasLabel7, aliasLabel8, aliasLabel9, aliasLabel10, capacityLabel1, capacityLabel2, capacityLabel3, capacityLabel4, capacityLabel5, capacityLabel6, capacityLabel7, capacityLabel8, capacityLabel9, capacityLabel10, aliasConnLabel1, aliasConnLabel2, aliasConnLabel3, aliasConnLabel4, aliasConnLabel5, aliasConnLabel6, aliasConnLabel7, aliasConnLabel8, aliasConnLabel9, aliasConnLabel10, channelLabel1, channelLabel2, channelLabel3, channelLabel4, channelLabel5, channelLabel6, channelLabel7, channelLabel8, channelLabel9, channelLabel10 };
                foreach (Control control in listLightningDashboardDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //address
                Control[] listAddressDataFieldsToColor = { lblAddressType, lblAddressConfirmedUnspent, lblAddressConfirmedUnspentOutputs, lblAddressConfirmedTransactionCount, lblAddressConfirmedReceived, lblAddressConfirmedReceivedOutputs, lblAddressConfirmedSpent, lblAddressConfirmedSpentOutputs };
                foreach (Control control in listAddressDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //block
                Control[] listBlockDataFieldsToColor = { lblBlockHash, lblBlockTime, lblNumberOfTXInBlock, lblSizeOfBlock, lblBlockWeight, lblTotalFees, lblReward, lblBlockFeeRangeAndMedianFee, lblBlockAverageFee, lblNonce, lblMiner };
                foreach (Control control in listBlockDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //blocklist
                Control[] listBlocklistDataFieldsToColor = { lblBlockListTXInMempool, lblBlockListTXInNextBlock, lblBlockListMinMaxInFeeNextBlock, lblBlockListTotalFeesInNextBlock, lblBlockListAttemptsToSolveBlock, lblBlockListNextDiffAdjBlock, lblBlockListAvgTimeBetweenBlocks, lblBlockListNextDifficultyAdjustment, lblBlockListProgressNextDiffAdjPercentage, lblBlockListEstHashRate, lblBlockListBlockReward, lblBlockListHalvingBlockAndRemaining, lblBlockListBlockHash, lblBlockListBlockTime, lblBlockListBlockSize, lblBlockListBlockWeight, lblBlockListNonce, lblBlockListMiner, lblBlockListTransactionCount, lblBlockListVersion, lblBlockListTotalFees, lblBlockListReward, lblBlockListBlockFeeRangeAndMedianFee, lblBlockListAverageFee, lblBlockListTotalInputs, lblBlockListTotalOutputs, lblBlockListAverageTransactionSize };
                foreach (Control control in listBlocklistDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //transaction
                Control[] listTransactionDataFieldsToColor = { lblTransactionBlockHeight, lblTransactionBlockTime, lblTransactionConfirmations, lblTransactionLockTime, lblTransactionVersion, lblTransactionInputCount, lblCoinbase, lblTransactionFee, lblTransactionOutputCount, lblTransactionSize, lblTransactionWeight, lblTotalInputValue, lblTotalOutputValue };
                foreach (Control control in listTransactionDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //xpub
                Control[] listXpubDataFieldsToColor = { lblCheckEachAddressTypeCount, lblCheckAllAddressTypesCount, lblSegwitUsedAddresses, lblSegwitSummary, lblLegacyUsedAddresses, lblLegacySummary, lblSegwitP2SHUsedAddresses, lblSegwitP2SHSummary, lblP2SHUsedAddresses, lblP2SHSummary, lblXpubConfirmedReceived, lblXpubConfirmedSpent, lblXpubConfirmedUnspent };
                foreach (Control control in listXpubDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //bookmarks
                Control[] listBookmarksDataFieldsToColor = { lblBookmarkTotalCount, lblBookmarkAddressCount, lblBookmarkBlocksCount, lblBookmarkTransactionsCount, lblBookmarkXpubsCount, lblBookmarkDataInFull, lblBookmarkNoteInFull, lblBookmarkProposalData };
                foreach (Control control in listBookmarksDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //settings
                Control[] listSettingsDataFieldsToColor = { label154 };
                foreach (Control control in listSettingsDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
                //charts
                Control[] listChartsDataFieldsToColor = { lblChartMousePositionData, labelPCUSD1, labelPCUSD2, labelPCUSD3, labelPCUSD4, labelPCUSD5, labelPCUSD6, labelPCUSD7, labelPCUSD8, labelPCUSD9, labelPCUSD10, labelPCUSD11, labelPCUSD12, labelPCUSD13, labelPCUSD14, labelPCUSD15, labelPCUSD16, labelPCUSD17, labelPCUSDcustom, labelPCEUR1, labelPCEUR2, labelPCEUR3, labelPCEUR4, labelPCEUR5, labelPCEUR6, labelPCEUR7, labelPCEUR8, labelPCEUR9, labelPCEUR10, labelPCEUR11, labelPCEUR12, labelPCEUR13, labelPCEUR14, labelPCEUR15, labelPCEUR16, labelPCEUR17, labelPCEURcustom, labelPCGBP1, labelPCGBP2, labelPCGBP3, labelPCGBP4, labelPCGBP5, labelPCGBP6, labelPCGBP7, labelPCGBP8, labelPCGBP9, labelPCGBP10, labelPCGBP11, labelPCGBP12, labelPCGBP13, labelPCGBP14, labelPCGBP15, labelPCGBP16, labelPCGBP17, labelPCGBPcustom, labelPCXAU1, labelPCXAU2, labelPCXAU3, labelPCXAU4, labelPCXAU5, labelPCXAU6, labelPCXAU7, labelPCXAU8, labelPCXAU9, labelPCXAU10, labelPCXAU11, labelPCXAU12, labelPCXAU13, labelPCXAU14, labelPCXAU15, labelPCXAU16, labelPCXAU17, labelPCXAUcustom, lblCalculatedUSDFromBTCAmount, lblCalculatedEURFromBTCAmount, lblCalculatedGBPFromBTCAmount, lblCalculatedXAUFromBTCAmount };
                foreach (Control control in listChartsDataFieldsToColor)
                {
                    control.ForeColor = thisColor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorDataFields");
            }
        }

        private void ColorLabels(Color thiscolor)
        {
            try
            {
                //header
                Control[] listHeaderLabelsToColor = { headerNetworkName, label77, lblHeaderMoscowTimeLabel, label148, label149, label15, label25, label28, label29, lblSatsumaTitle, lblNowViewing };
                foreach (Control control in listHeaderLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //settings and appearance
                Control[] listSettingsLabelsToColor = { label243, label246, label242, label239, label240, label199, label200, label201, label50, label198, lblSettingsXpubNodeStatus, lblSettingsCustomNodeStatus, label193, label194, label196, label73, label161, label168, label157, label172, label174, label4, lblWhatever, label152, label169, label171, label167, label178, label177, label179, label180, label188, label185, label187, label191, label197 };
                foreach (Control control in listSettingsLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardLabelsToColor = { lblPriceLabel, lblMoscowTimeLabel, lblMarketCapLabel, label7, label30, label14, label31, label10, label12, label11, label21, label20, label17, label8, label27, label13, label9, label3, label2, label23, label134, label137, label32, label33, label57, label19, label85 };
                foreach (Control control in listBitcoinDashboardLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //lightningdashboard
                Control[] listLightningDashboardLabelsToColor = { label38, label47, label48, label49, label40, label36, label35, label45, label46, label34, label37, label39, label41, label42, label44, label43, label51, label52, label56, label55 };
                foreach (Control control in listLightningDashboardLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //address
                Control[] listAddressLabelsToColor = { label58, lblAddressTXPositionInList };
                foreach (Control control in listAddressLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //block
                Control[] listBlockLabelsToColor = { label64, label60, lblBlockTXPositionInList, label145, label69, label68, label74, label72, label66, label70, label62, label65, label71 };
                foreach (Control control in listBlockLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //transaction
                Control[] listTransactionLabelsToColor = { label136, label113, label126, label125, label128, label98, label104, label132, label130 };
                foreach (Control control in listTransactionLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //blocklist
                Control[] listBlockListLabelsToColor = { label87, label100, label106, label108, label110, label112, label115, label116, label16, label118, label120, label122, lblBlockListPositionInList, label109, label90, label91, label105, label103, label24, label95, label99, label96, label88, label101, label93, label97, label89, label94, label92 };
                foreach (Control control in listBlockListLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //xpub
                Control[] listXpubLabelsToColor = { label114, label139, label146, label18, label140, label141, label123, label111, label119, label135, label133, label129, label121, lblXpubStatus };
                foreach (Control control in listXpubLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //bookmarks
                Control[] listBookmarksLabelsToColor = { label144, label153, label151, label147, label142, lblSelectedBookmarkType, label138 };
                foreach (Control control in listBookmarksLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //charts
                Control[] listChartsLabelsToColor = { label236, label220, label225, label226, label229, label230, label233, label232, label202, label203, label205, label206, label207, label208, label209, label236, label262, label263, label264, label265, label266, label245, label241, label189, label256, label255, label254, label253, label252, label251, label250, label249, label247, label261, label260, label259, label258, label257, label277, label278, label279, label280, label267, label270, label269, label268, label273, label274, label275, label276 };
                foreach (Control control in listChartsLabelsToColor)
                {
                    control.ForeColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorLabels");
            }
        }

        private void ColorHeadings(Color thiscolor)
        {
            try
            {
                //header
                Control[] listHeaderHeadingsToColor = { label26, label22, label1, label150, lblCurrentVersion };
                foreach (Control control in listHeaderHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //settings & appearance
                Control[] listSettingsHeadingsToColor = { label248, label162, label163, label155, label5, label156, label166, label181, label182, label183, label184, label192, label195, label234, label237, label244 };
                foreach (Control control in listSettingsHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardHeadingsToColor = { label79, label84, label80, label81, label83, label86, label82 };
                foreach (Control control in listBitcoinDashboardHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //lightningdashboard
                Control[] listLightningDashboardHeadingsToColor = { label76, label78, label75, label53, label54 };
                foreach (Control control in listLightningDashboardHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //address
                Control[] listAddressHeadingsToColor = { label61, label59, label67, label63 };
                foreach (Control control in listAddressHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //blocklist
                Control[] listBlockListHeadingsToColor = { label143, lblBlockListBlockHeight, label6 };
                foreach (Control control in listBlockListHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //block
                Control[] listBlockHeadingsToColor = { lblBlockBlockHeight };
                foreach (Control control in listBlockHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //transaction
                Control[] listTransactionHeadingsToColor = { label102, label107 };
                foreach (Control control in listTransactionHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //xpub
                Control[] listXpubHeadingsToColor = { label124, label117, label127 };
                foreach (Control control in listXpubHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //bookmarks
                Control[] listBookmarksHeadingsToColor = { label131 };
                foreach (Control control in listBookmarksHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //charts
                Control[] listChartsHeadingsToColor = { label228, label218, label231, label217, label271, label272 };
                foreach (Control control in listChartsHeadingsToColor)
                {
                    control.ForeColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorHeadings");
            }
        }

        private void ColorTables(Color thiscolor)
        {
            try
            {
                Control[] listTableTextToColor = { label170, listViewAddressTransactions, listViewBlockTransactions, listViewBlockList, listViewTransactionInputs, listViewTransactionOutputs, listViewXpubAddresses, listViewBookmarks, label186 };
                foreach (Control control in listTableTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                tableTextColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorTables");
            }
        }

        private void ColorTableHeadings(Color thiscolor)
        {
            try
            {
                listViewHeaderTextColor = thiscolor;
                label188.ForeColor = thiscolor;
                label190.ForeColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorTableHeadings");
            }
        }

        private void ColorOtherText(Color thiscolor)
        {
            try
            {
                Control[] listOtherTextToColor = { label235, label238, label160, label204, lblURLWarning, label159, label158, label165, label173, label167, lblURLWarning, textBoxXpubNodeURL, textBoxSubmittedXpub, numberUpDownDerivationPathsToCheck, textboxSubmittedAddress, textBoxBlockHeightToStartListFrom, textBoxSubmittedBlockNumber, textBoxTransactionID, textBoxBookmarkEncryptionKey, textBoxBookmarkKey, textBoxBookmarkProposedNote, textBoxSettingsCustomMempoolURL, textBoxSettingsXpubMempoolURL, numericUpDownDashboardRefresh, numericUpDownMaxNumberOfConsecutiveUnusedAddresses, textBoxThemeImage, textBoxThemeName, textBox1, comboBoxThemeList, lblUpdateAvailable, lblCurrentVersion };
                foreach (Control control in listOtherTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorOtherText");
            }
        }

        private void ColorPriceBlock(Color thiscolor)
        {
            try
            {
                lblHeaderPrice.ForeColor = thiscolor;
                lblBlockNumber.ForeColor = thiscolor;
                label175.ForeColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorPriceBlock");
            }
        }

        private void ColorStatusError(Color thiscolor)
        {
            try
            {
                lblRefreshSuccessOrFailMessage.ForeColor = thiscolor;
                lblElapsedSinceUpdate.ForeColor = thiscolor;
                lblErrorMessage.ForeColor = thiscolor;
                label176.ForeColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorStatusError");
            }
        }

        private void ColorButtons(Color thiscolor)
        {
            try
            {
                //header
                Control[] listHeaderButtonsToColor = { lblMenuHighlightedButtonText, lblCurrencyMenuHighlightedButtonText, lblMenuHighlightedButtonMarker, btnCurrency, btnAddToBookmarks, btnMenu, btnHelp, btnMinimise, btnExit, btnCommitToBookmarks, btnCancelAddToBookmarks, btnMenuAddress, btnMenuAppearance, btnMenuBitcoinDashboard, btnMenuBlock, btnMenuBlockList, btnMenuBookmarks, btnMenuCharts, btnMenuHelp, btnMenuLightningDashboard, btnMenuSettings2, btnMenuSplash, btnMenuTransaction, btnMenuXpub, btnThemeMenu, btnMenuThemeBTCdir, btnMenuThemeCustom, btnMenuThemeSatsuma, BtnMenuThemeGenesis, btnUSD, btnEUR, btnGBP, btnXAU };
                foreach (Control control in listHeaderButtonsToColor)
                {
                    control.BackColor = chartsBackgroundColor;
                }
                lblCurrencyMenuHighlightedButtonMarker.BackColor = chartsBackgroundColor;
                lblMenuHighlightedButtonMarker.BackColor = chartsBackgroundColor;
                lblThemeMenuHighlightedButtonMarker.BackColor = chartsBackgroundColor;
                lblCurrencyMenuHighlightedButtonText.BackColor = chartsBackgroundColor;
                lblMenuHighlightedButtonText.BackColor = chartsBackgroundColor;
                lblThemeMenuHighlightedButtonText.BackColor = chartsBackgroundColor;
                //settings
                Control[] listSettingsButtonsToColor = { button1, button2, btnSaveTheme, btnLoadTheme, btnDeleteTheme };
                foreach (Control control in listSettingsButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //address
                Control[] listAddressButtonsToColor = { btnShowAllTX, btnShowConfirmedTX, btnShowUnconfirmedTX, btnFirstAddressTransaction, btnNextAddressTransactions, BtnViewTransactionFromAddress, BtnViewBlockFromAddress };
                foreach (Control control in listAddressButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //block
                Control[] listBlockButtonsToColor = { btnPreviousBlock, btnNextBlock, btnViewTransactionFromBlock, btnPreviousBlockTransactions, btnNextBlockTransactions };
                foreach (Control control in listBlockButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //blocklist
                Control[] listBlockListButtonsToColor = { btnViewBlockFromBlockList, btnNewer15Blocks, btnOlder15Blocks };
                foreach (Control control in listBlockListButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //transaction
                Control[] listTransactionButtonsToColor = { btnViewAddressFromTXInput, btnViewAddressFromTXOutput, btnTransactionInputsUp, btnTransactionInputDown, btnTransactionOutputsUp, btnTransactionOutputsDown };
                foreach (Control control in listTransactionButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //xpub
                Control[] listXpubButtonsToColor = { btnViewAddressFromXpub, btnXpubAddressUp, btnXpubAddressesDown };
                foreach (Control control in listXpubButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //bookmarks
                Control[] listBookmarksButtonsToColor = { btnBookmarksListUp, btnBookmarksListDown, btnBookmarkUnlock, btnDecryptBookmark, btnDeleteBookmark, btnViewBookmark };
                foreach (Control control in listBookmarksButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
                //charts
                Control[] listChartsButtonsToColor = { btnChartFeeRates, btnChartBlockFees, btnChartReward, btnChartBlockSize, btnChartHashrate, btnChartDifficulty, btnChartCirculation, btnChartUniqueAddresses, btnChartUTXO, btnChartPoolsRanking, btnChartNodesByNetwork, btnChartNodesByCountry, btnChartLightningCapacity, btnChartLightningChannels, btnChartPrice, btnChartMarketCap, btnChartPeriod24h, btnChartPeriod3d, btnChartPeriod1w, btnChartPeriod1m, btnChartPeriod3m, btnChartPeriod6m, btnChartPeriod1y, btnChartPeriod2y, btnChartPeriod3y, btnChartPeriodAll, btnPriceChartScaleLinear, btnPriceChartScaleLog, btnChartMarketCapScaleLinear, btnChartMarketCapScaleLog, btnChartUTXOScaleLinear, btnChartUTXOScaleLog, btnChartAddressScaleLinear, btnChartAddressScaleLog, btnPriceConverter, btnSaveChart };
                foreach (Control control in listChartsButtonsToColor)
                {
                    control.BackColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorButtons");
            }
        }

        private void ColorButtonText(Color thiscolor)
        {
            try
            {
                //header
                Control[] listHeaderButtonTextToColor = { btnCurrency, btnAddToBookmarks, btnMenu, btnHelp, btnMinimise, btnExit, btnCommitToBookmarks, btnCancelAddToBookmarks, btnMenuAddress, btnMenuAppearance, btnMenuBitcoinDashboard, btnMenuBlock, btnMenuBlockList, btnMenuBookmarks, btnMenuCharts, btnMenuHelp, btnMenuLightningDashboard, btnMenuSettings2, btnMenuSplash, btnMenuTransaction, btnMenuXpub, btnThemeMenu, btnMenuThemeBTCdir, btnMenuThemeCustom, btnMenuThemeSatsuma, BtnMenuThemeGenesis, btnUSD, btnEUR, btnGBP, btnXAU };
                foreach (Control control in listHeaderButtonTextToColor)
                {
                    control.ForeColor = Color.Silver;
                }
                lblCurrencyMenuHighlightedButtonText.ForeColor = Color.DimGray;
                lblMenuHighlightedButtonText.ForeColor = Color.DimGray;
                lblThemeMenuHighlightedButtonText.ForeColor = Color.DimGray;

                //settings
                Control[] listSettingsButtonTextToColor = { button1, button2, btnSaveTheme, btnLoadTheme, btnDeleteTheme };
                foreach (Control control in listSettingsButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //address
                Control[] listAddressButtonTextToColor = { btnShowAllTX, btnShowConfirmedTX, btnShowUnconfirmedTX, btnFirstAddressTransaction, btnNextAddressTransactions, BtnViewTransactionFromAddress, BtnViewBlockFromAddress };
                foreach (Control control in listAddressButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //block
                Control[] listBlockButtonTextToColor = { btnPreviousBlock, btnNextBlock, btnViewTransactionFromBlock, btnPreviousBlockTransactions, btnNextBlockTransactions };
                foreach (Control control in listBlockButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //blocklist
                Control[] listBlockListButtonTextToColor = { btnViewBlockFromBlockList, btnNewer15Blocks, btnOlder15Blocks };
                foreach (Control control in listBlockListButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //transaction
                Control[] listTransactionButtonTextToColor = { btnViewAddressFromTXInput, btnViewAddressFromTXOutput, btnTransactionInputsUp, btnTransactionInputDown, btnTransactionOutputsUp, btnTransactionOutputsDown };
                foreach (Control control in listTransactionButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //xpub
                Control[] listXpubButtonTextToColor = { btnViewAddressFromXpub, btnXpubAddressUp, btnXpubAddressesDown };
                foreach (Control control in listXpubButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //bookmarks
                Control[] listBookmarksButtonTextToColor = { btnBookmarksListUp, btnBookmarksListDown, btnBookmarkUnlock, btnDecryptBookmark, btnDeleteBookmark, btnViewBookmark };
                foreach (Control control in listBookmarksButtonTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
                //charts
                Control[] listChartsButtonsTextToColor = { btnChartFeeRates, btnChartBlockFees, btnChartReward, btnChartBlockSize, btnChartHashrate, btnChartDifficulty, btnChartCirculation, btnChartUniqueAddresses, btnChartUTXO, btnChartPoolsRanking, btnChartNodesByNetwork, btnChartNodesByCountry, btnChartLightningCapacity, btnChartLightningChannels, btnChartPrice, btnChartMarketCap, btnChartPeriod24h, btnChartPeriod3d, btnChartPeriod1w, btnChartPeriod1m, btnChartPeriod3m, btnChartPeriod6m, btnChartPeriod1y, btnChartPeriod2y, btnChartPeriod3y, btnChartPeriodAll, btnPriceChartScaleLinear, btnPriceChartScaleLog, btnChartMarketCapScaleLinear, btnChartMarketCapScaleLog, btnChartUTXOScaleLinear, btnChartUTXOScaleLog, btnChartAddressScaleLinear, btnChartAddressScaleLog, btnSaveChart };
                foreach (Control control in listChartsButtonsTextToColor)
                {
                    control.ForeColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorButtonText");
            }
        }

        private void ColorLines(Color thiscolor)
        {
            try
            {
                Control[] listLinesToColor = { panel14, panel17, panel16, panel18, panel21, panel15, panel19, panel61, panel92, panel95, panel96, panel97, panel98 };
                foreach (Control control in listLinesToColor)
                {
                    control.BackColor = thiscolor;
                }
                linesColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorLines");
            }
        }

        private void ColorTextBoxes(Color thiscolor)
        {
            try
            {
                Control[] listTextBoxesToColor = { lblShowClock, numericUpDownMaxNumberOfConsecutiveUnusedAddresses, textBox1, textBoxBookmarkProposedNote, textBoxBookmarkEncryptionKey, textboxSubmittedAddress, textBoxSubmittedBlockNumber, textBoxTransactionID, textBoxBlockHeightToStartListFrom, textBoxXpubNodeURL, numberUpDownDerivationPathsToCheck, textBoxSubmittedXpub, textBoxBookmarkKey, textBoxSettingsXpubMempoolURL, textBoxSettingsCustomMempoolURL, numericUpDownDashboardRefresh, textBoxThemeImage, textBoxThemeName, comboBoxThemeList, lblTitleBackgroundCustom, lblTitleBackgroundDefault, lblTitleBackgroundNone, lblBackgroundBTCdirSelected, lblBackgroundCustomColorSelected, lblBackgroundCustomImageSelected, lblBackgroundGenesisSelected, lblBackgroundSatsumaSelected, lblSettingsNodeCustom, lblSettingsNodeMainnet, lblSettingsNodeTestnet, lblBitcoinExplorerEndpoints, lblBlockchainInfoEndpoints, lblBlockchairComJSON, lblPrivacyMode, lblChartsDarkBackground, lblChartsLightBackground, textBoxConvertBTCtoFiat, textBoxConvertEURtoBTC, textBoxConvertGBPtoBTC, textBoxConvertUSDtoBTC, textBoxConvertXAUtoBTC };
                foreach (Control control in listTextBoxesToColor)
                {
                    control.BackColor = thiscolor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorTextBoxes");
            }
        }

        private void ColorProgressBars(Color thiscolor)
        {
            try
            {
                //settings
                colorProgressBar1.BarColor = thiscolor;
                //bitcoindashboard
                progressBarNextDiffAdj.BarColor = thiscolor;
                progressBarProgressToHalving.BarColor = thiscolor;
                //blocklist
                progressBarBlockListNextDiffAdj.BarColor = thiscolor;
                progressBarBlockListHalvingProgress.BarColor = thiscolor;
                //xpub
                progressBarCheckEachAddressType.BarColor = thiscolor;
                progressBarCheckAllAddressTypes.BarColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorProgressBars");
            }
        }

        private void ColorTableBackgrounds(Color thiscolor)
        {
            try
            {
                Control[] listListViewBackgroundsToColor = { panelTransactionOutputs, panelTransactionInputs, panel102, listViewBlockList, listViewTransactionInputs, listViewTransactionOutputs, listViewXpubAddresses, listViewBookmarks, listViewAddressTransactions, listViewBlockTransactions, panel66, panel24, panel25, panel30, panel33, panel100, panel101, panelXpubContainer };
                foreach (Control control in listListViewBackgroundsToColor)
                {
                    {
                        control.BackColor = thiscolor;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorTableBackgrounds");
            }
        }

        private void ColorTableTitleBars(Color thiscolor)
        {
            try
            {
                listViewHeaderColor = thiscolor;
                panel67.BackColor = thiscolor;
                panel68.BackColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorTableTitleBars");
            }
        }

        private void HeadingBackgroundsToDefault()
        {
            try
            {
                lblTitleBackgroundDefault.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundDefault.ForeColor = Color.Green;
                    lblTitleBackgroundDefault.Text = "✔️";
                });
                lblTitleBackgroundNone.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundNone.ForeColor = Color.IndianRed;
                    lblTitleBackgroundNone.Text = "❌";
                });
                lblTitleBackgroundCustom.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundCustom.ForeColor = Color.IndianRed;
                    lblTitleBackgroundCustom.Text = "❌";
                });
                //header
                Control[] listHeaderHeadingsToColor = { panel38, panel39, panel31, panel40, panel57, panelRefreshStatusBar };
                foreach (Control control in listHeaderHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //settings & appearance
                Control[] listSettingsHeadingsToColor = { panel47, panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72, panel82, panel83, panel104 };
                foreach (Control control in listSettingsHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardHeadingsToColor = { panel6, panel11, panel7, panel8, panel10, panel12, panel9 };
                foreach (Control control in listBitcoinDashboardHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //lightningdashboard
                Control[] listLightningDashboardHeadingsToColor = { panel4, panel5, panel1, panel2, panel3 };
                foreach (Control control in listLightningDashboardHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //address
                Control[] listAddressHeadingsToColor = { panel41, panel42, panel43, panel44 };
                foreach (Control control in listAddressHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //block
                Control[] listBlockHeadingsToColor = { panel105 };
                foreach (Control control in listBlockHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //blocklist
                Control[] listBlockListHeadingsToColor = { panel93, panel13, panel45 };
                foreach (Control control in listBlockListHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //transaction
                Control[] listTransactionHeadingsToColor = { panel27, panel28 };
                foreach (Control control in listTransactionHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //xpub
                Control[] listXpubHeadingsToColor = { panel23, panel26, panel29 };
                foreach (Control control in listXpubHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
                //charts
                Control[] listChartsHeadingsToColor = { panel80, panel79, panel81, panel78, panel49, panel50 };
                foreach (Control control in listChartsHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "HeadingBackgroundsToDefault");
            }
        }

        private void HeadingBackgroundsToNone()
        {
            try
            {
                lblTitleBackgroundNone.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundNone.ForeColor = Color.Green;
                    lblTitleBackgroundNone.Text = "✔️";
                });
                lblTitleBackgroundDefault.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundDefault.ForeColor = Color.IndianRed;
                    lblTitleBackgroundDefault.Text = "❌";
                });
                lblTitleBackgroundCustom.Invoke((MethodInvoker)delegate
                {
                    lblTitleBackgroundCustom.ForeColor = Color.IndianRed;
                    lblTitleBackgroundCustom.Text = "❌";
                });

                //header
                Control[] listHeaderHeadingsToColor = { panel38, panel39, panel31, panel40, panel57, panelRefreshStatusBar };
                foreach (Control control in listHeaderHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //settings & appearance
                Control[] listSettingsHeadingsToColor = { panel47, panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72, panel82, panel83, panel104 };
                foreach (Control control in listSettingsHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardHeadingsToColor = { panel6, panel11, panel7, panel8, panel10, panel12, panel9 };
                foreach (Control control in listBitcoinDashboardHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //lightningdashboard
                Control[] listLightningDashboardHeadingsToColor = { panel4, panel5, panel1, panel2, panel3 };
                foreach (Control control in listLightningDashboardHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //address
                Control[] listAddressHeadingsToColor = { panel41, panel42, panel43, panel44 };
                foreach (Control control in listAddressHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //block
                Control[] listBlockHeadingsToColor = { panel105 };
                foreach (Control control in listBlockHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //blocklist
                Control[] listBlockListHeadingsToColor = { panel93, panel13, panel45 };
                foreach (Control control in listBlockListHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //transaction
                Control[] listTransactionHeadingsToColor = { panel27, panel28 };
                foreach (Control control in listTransactionHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //xpub
                Control[] listXpubHeadingsToColor = { panel23, panel26, panel29 };
                foreach (Control control in listXpubHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
                //charts
                Control[] listChartsHeadingsToColor = { panel80, panel79, panel81, panel78, panel49, panel50 };
                foreach (Control control in listChartsHeadingsToColor)
                {
                    control.BackColor = Color.Transparent;
                    control.BackgroundImage = null;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "HeadingBackgroundsToNone");
            }
        }

        private void HeadingBackgroundsToCustomColor()
        {
            try
            {
                //header
                Control[] listHeaderHeadingsToColor = { panel38, panel39, panel31, panel40, panel57, panelRefreshStatusBar };
                foreach (Control control in listHeaderHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //settings & appearance
                Control[] listSettingsHeadingsToColor = { panel47, panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72, panel82, panel83, panel104 };
                foreach (Control control in listSettingsHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //bitcoindashboard
                Control[] listBitcoinDashboardHeadingsToColor = { panel6, panel11, panel7, panel8, panel10, panel12, panel9 };
                foreach (Control control in listBitcoinDashboardHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //lightningdashboard
                Control[] listLightningDashboardHeadingsToColor = { panel4, panel5, panel1, panel2, panel3 };
                foreach (Control control in listLightningDashboardHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //address
                Control[] listAddressHeadingsToColor = { panel41, panel42, panel43, panel44 };
                foreach (Control control in listAddressHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //block
                Control[] listBlockHeadingsToColor = { panel105 };
                foreach (Control control in listBlockHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //blocklist
                Control[] listBlockListHeadingsToColor = { panel93, panel13, panel45 };
                foreach (Control control in listBlockListHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //transaction
                Control[] listTransactionHeadingsToColor = { panel27, panel28 };
                foreach (Control control in listTransactionHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //xpub
                Control[] listXpubHeadingsToColor = { panel23, panel26, panel29 };
                foreach (Control control in listXpubHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
                //charts
                Control[] listChartsHeadingsToColor = { panel80, panel79, panel81, panel78, panel49, panel50 };
                foreach (Control control in listChartsHeadingsToColor)
                {
                    control.BackgroundImage = null;
                    control.BackColor = titleBackgroundColor;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "HeadingBackgroundsToCustomColor");
            }
        }

        private void ColorPanels(Color thiscolor)
        {
            try
            {
                Control[] listPanelsToColor = { panelMenu, panelThemeMenu, panelCurrency, panel46, panel103, panelOwnNodeBlockTXInfo, panel70, panel71, panel73, panel20, panel32, panel74, panel75, panel76, panel77, panel88, panel89, panel90, panel86, panel87, panel91, panel84, panel85, panel99, panel94, panelTransactionMiddle, panelOwnNodeAddressTXInfo };
                foreach (Control control in listPanelsToColor)
                {
                    {
                        control.BackColor = thiscolor;
                    }
                }
                subItemBackColor = thiscolor;
            }
            catch (Exception ex)
            {
                HandleException(ex, "ColorPanels");
            }
        }

        // all menu buttons derive their colour from chartbackgroundcolor
        private void BtnMenuButtons_MouseEnter(object sender, EventArgs e)
        {
            if (sender == btnMenuBitcoinDashboard)
            {
                btnMenuBitcoinDashboard.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenu)
            {
                btnMenu.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuAddress)
            {
                btnMenuAddress.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuAppearance)
            {
                btnMenuAppearance.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuBlock)
            {
                btnMenuBlock.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuBlockList)
            {
                btnMenuBlockList.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuBookmarks)
            {
                btnMenuBookmarks.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuCharts)
            {
                btnMenuCharts.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuHelp)
            {
                btnMenuHelp.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuLightningDashboard)
            {
                btnMenuLightningDashboard.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuSettings2)
            {
                btnMenuSettings2.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuTransaction)
            {
                btnMenuTransaction.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuXpub)
            {
                btnMenuXpub.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuSplash)
            {
                btnMenuSplash.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuThemeBTCdir)
            {
                btnMenuThemeBTCdir.BackColor = panelMenu.BackColor;
            }
            if (sender == BtnMenuThemeGenesis)
            {
                BtnMenuThemeGenesis.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuThemeSatsuma)
            {
                btnMenuThemeSatsuma.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMenuThemeCustom)
            {
                btnMenuThemeCustom.BackColor = panelMenu.BackColor;
            }
            if (sender == btnThemeMenu)
            {
                btnThemeMenu.BackColor = panelMenu.BackColor;
            }
            if (sender == btnUSD)
            {
                btnUSD.BackColor = panelMenu.BackColor;
            }
            if (sender == btnEUR)
            {
                btnEUR.BackColor = panelMenu.BackColor;
            }
            if (sender == btnGBP)
            {
                btnGBP.BackColor = panelMenu.BackColor;
            }
            if (sender == btnXAU)
            {
                btnXAU.BackColor = panelMenu.BackColor;
            }
            if (sender == btnCurrency)
            {
                btnCurrency.BackColor = panelMenu.BackColor;
            }
            if (sender == btnHelp)
            {
                btnHelp.BackColor = panelMenu.BackColor;
            }
            if (sender == btnMinimise)
            {
                btnMinimise.BackColor = panelMenu.BackColor;
            }
            if (sender == btnExit)
            {
                btnExit.BackColor = panelMenu.BackColor;
            }
            if (sender == btnAddToBookmarks)
            {
                btnAddToBookmarks.BackColor = panelMenu.BackColor;
            }
        }

        private void BtnMenuButtons_MouseLeave(object sender, EventArgs e)
        {
            if (sender == btnMenuBitcoinDashboard)
            {
                btnMenuBitcoinDashboard.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenu)
            {
                if (panelMenu.Height == 24)
                {
                    btnMenu.BackColor = chartsBackgroundColor;
                }
            }
            if (sender == btnMenuAddress)
            {
                btnMenuAddress.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuAppearance)
            {
                btnMenuAppearance.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuBlock)
            {
                btnMenuBlock.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuBlockList)
            {
                btnMenuBlockList.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuBookmarks)
            {
                btnMenuBookmarks.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuCharts)
            {
                btnMenuCharts.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuHelp)
            {
                btnMenuHelp.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuLightningDashboard)
            {
                btnMenuLightningDashboard.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuSettings2)
            {
                btnMenuSettings2.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuTransaction)
            {
                btnMenuTransaction.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuXpub)
            {
                btnMenuXpub.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuSplash)
            {
                btnMenuSplash.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuThemeBTCdir)
            {
                btnMenuThemeBTCdir.BackColor = chartsBackgroundColor;
            }
            if (sender == BtnMenuThemeGenesis)
            {
                BtnMenuThemeGenesis.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuThemeSatsuma)
            {
                btnMenuThemeSatsuma.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMenuThemeCustom)
            {
                btnMenuThemeCustom.BackColor = chartsBackgroundColor;
            }
            if (sender == btnThemeMenu)
            {
                if (panelThemeMenu.Height == 24)
                {
                    btnThemeMenu.BackColor = chartsBackgroundColor;
                }
            }
            if (sender == btnUSD)
            {
                btnUSD.BackColor = chartsBackgroundColor;
            }
            if (sender == btnEUR)
            {
                btnEUR.BackColor = chartsBackgroundColor;
            }
            if (sender == btnGBP)
            {
                btnGBP.BackColor = chartsBackgroundColor;
            }
            if (sender == btnXAU)
            {
                btnXAU.BackColor = chartsBackgroundColor;
            }
            if (sender == btnCurrency)
            {
                if (panelCurrency.Height == 24)
                {
                    btnCurrency.BackColor = chartsBackgroundColor;
                }
            }
            if (sender == btnHelp)
            {
                btnHelp.BackColor = chartsBackgroundColor;
            }
            if (sender == btnMinimise)
            {
                btnMinimise.BackColor = chartsBackgroundColor;
            }
            if (sender == btnExit)
            {
                btnExit.BackColor = chartsBackgroundColor;
            }
            if (sender == btnAddToBookmarks)
            {
                btnAddToBookmarks.BackColor = chartsBackgroundColor;
            }
        }
        #endregion
        #region save theme as default
        private void SaveThemeAsDefault(string themename)
        {
            try
            {
                // write the theme name to the bookmarks file for auto retrieval next time
                DateTime today = DateTime.Today;
                string bookmarkData;
                string keyCheck = "";
                bookmarkData = themename;
                var newBookmark = new Bookmark { DateAdded = today, Type = "defaulttheme", Data = bookmarkData, Note = "", Encrypted = false, KeyCheck = keyCheck };
                if (!defaultThemeAlreadySavedInFile)
                {
                    // Read the existing bookmarks from the JSON file
                    var bookmarks = ReadBookmarksFromJsonFile();

                    // Add the new bookmark to the list
                    bookmarks.Add(newBookmark);

                    // Write the updated list of bookmarks back to the JSON file
                    WriteBookmarksToJsonFile(bookmarks);
                    defaultThemeAlreadySavedInFile = true;
                    defaultThemeInFile = bookmarkData;
                }
                else
                {
                    if (defaultThemeInFile != themename)
                    {
                        //delete the currently saved default theme
                        DeleteBookmarkFromJsonFile(defaultThemeInFile);
                        // Read the existing bookmarks from the JSON file
                        var bookmarks = ReadBookmarksFromJsonFile();
                        // Add the new bookmark to the list
                        bookmarks.Add(newBookmark);
                        // Write the updated list of bookmarks back to the JSON file
                        WriteBookmarksToJsonFile(bookmarks);
                        defaultThemeAlreadySavedInFile = true;
                        defaultThemeInFile = bookmarkData;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "SaveThemeAsDefault");
            }
        }
        #endregion
        #region delete theme
        private void ComboBoxThemeList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(comboBoxThemeList.SelectedValue) == "Genesis (preset)" || Convert.ToString(comboBoxThemeList.SelectedValue) == "BTCdir (preset)" || Convert.ToString(comboBoxThemeList.SelectedValue) == "Satsuma (preset)")
                {
                    btnDeleteTheme.Enabled = false;
                }
                else
                {
                    btnDeleteTheme.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ComboBoxThemeList_SelectedValueChanged");
            }
        }

        private void BtnDeleteTheme_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the existing thenes from the JSON file
                var themes = ReadThemesFromJsonFile();

                // Find the index of the bookmark with the specified data
                int index = themes.FindIndex(theme =>
                    theme.ThemeName == Convert.ToString(comboBoxThemeList.SelectedItem));

                // If a matching bookmark was found, remove it from the list
                if (index >= 0)
                {
                    themes.RemoveAt(index);

                    // Write the updated list of bookmarks back to the JSON file
                    WriteThemeToJsonFile(themes);
                    // repopulate the dropdown list with the available themes
                    themes.Clear();
                    themes = ReadThemesFromJsonFile();
                    List<string> themeNames = themes.Select(t => t.ThemeName).ToList();
                    comboBoxThemeList.DataSource = themeNames;
                    lblThemeDeleted.Visible = true;
                    hideThemeDeletedTimer.Start();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnDeleteTheme_Click");
            }
        }
        #endregion region
        #region timers to hide saved/deleted messages after display
        private void HideThemeSavedTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblThemeSaved.Visible = false;
                hideThemeSavedTimer.Stop();
            }
            catch (Exception ex)
            {
                HandleException(ex, "HideThemeSavedTimer_Tick");
            }
        }

        private void HideThemeDeletedTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblThemeDeleted.Visible = false;
                hideThemeDeletedTimer.Stop();
            }
            catch (Exception ex)
            {
                HandleException(ex, "HideThemeDeletedTimer_Tick");
            }
        }
        #endregion
        #endregion

        #region ⚡COMMON CODE⚡
        #region check for updates
        private void CheckForUpdates()
        {
            try
            {
                if (!privacyMode)
                {
                    using WebClient client = new WebClient();
                    string VersionURL = "https://satsuma.btcdir.org/SATSumaVersion.txt";
                    string LatestVersion = client.DownloadString(VersionURL);
                    if (LatestVersion != CurrentVersion)
                    {
                        lblUpdateAvailable.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "CheckForUpdates");
            }
        }
        private void LblUpdateAvailable_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://satsuma.btcdir.org/download/");
        }
        #endregion
        #region form paint - border round window, relocate objects, set window title, bookmark button state
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid); // place a 1px border around the form
                if (panelAddress.Visible || panelBlock.Visible || panelTransaction.Visible || panelXpub.Visible)
                {
                    if (panelAddress.Visible && lblAddressType.Text != "Invalid address format")
                    {
                        btnAddToBookmarks.Enabled = true;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Address";
                        });
                    }
                    if (panelAddress.Visible && lblAddressType.Text == "Invalid address format")
                    {
                        btnAddToBookmarks.Enabled = false;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Address";
                        });
                    }
                    if (panelBlock.Visible && lblBlockHash.Text != "")
                    {
                        btnAddToBookmarks.Enabled = true;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Block";
                        });
                    }
                    if (panelBlock.Visible && lblBlockHash.Text == "")
                    {
                        btnAddToBookmarks.Enabled = false;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Block";
                        });
                    }
                    if (panelTransaction.Visible && !lblInvalidTransaction.Visible)
                    {
                        btnAddToBookmarks.Enabled = true;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Transaction";
                        });
                    }
                    if (panelTransaction.Visible && lblInvalidTransaction.Visible)
                    {
                        btnAddToBookmarks.Enabled = false;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Transaction";
                        });
                    }
                    if (panelXpub.Visible && lblValidXpubIndicator.Text != "✔️ valid Xpub")
                    {
                        btnAddToBookmarks.Enabled = false;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Xpub";
                        });
                    }
                    if (panelXpub.Visible && lblValidXpubIndicator.Text == "✔️ valid Xpub")
                    {
                        btnAddToBookmarks.Enabled = true;
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Xpub";
                        });
                    }
                }
                else
                {
                    if (panelBitcoinDashboard.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Bitcoin dashboard";
                        });
                    }
                    if (panelLightningDashboard.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Lightning dashboard";
                        });
                    }
                    if (panelBlockList.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Blocks";
                        });
                    }
                    if (panelBookmarks.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Bookmarks";
                        });
                    }
                    if (panelSettings.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Settings";
                        });
                    }
                    if (panelAppearance.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Appearance";
                        });
                    }
                    if (panelCharts.Visible)
                    {
                        lblNowViewing.Invoke((MethodInvoker)delegate
                        {
                            lblNowViewing.Text = "Charts";
                        });
                    }
                    btnAddToBookmarks.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Form_paint");
            }
        }
        #endregion
        #region status message/alert at bottom of window
        private void UpdateOnScreenElapsedTimeSinceUpdate()
        {
            try
            {
                intDisplaySecondsElapsedSinceUpdate++; // increment displayed time elapsed since last update
                if (intDisplaySecondsElapsedSinceUpdate == 1)
                {
                    lblElapsedSinceUpdate.Invoke((MethodInvoker)delegate
                    {
                        lblElapsedSinceUpdate.Text = intDisplaySecondsElapsedSinceUpdate.ToString() + " second ago. " + "Refreshing in " + Convert.ToString(intDisplayCountdownToRefresh);
                    });
                }
                else
                {
                    lblElapsedSinceUpdate.Invoke((MethodInvoker)delegate
                    {
                        lblElapsedSinceUpdate.Text = intDisplaySecondsElapsedSinceUpdate.ToString() + " seconds ago. " + "Refreshing in " + Convert.ToString(intDisplayCountdownToRefresh);
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "UpdateOnScreenElapsedTimeSinceUpdate");
            }
        }

        private void ShowAlertSymbol()
        {
            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
        }

        private void ToggleLoadingAnimation(string enableOrDisableAnimation)
        {
            try
            {
                if (enableOrDisableAnimation == "enable")
                {
                    //start the loading animation
                    pictureBoxLoadingAnimation.Enabled = true;
                }
                else
                {
                    //stop the animation
                    pictureBoxLoadingAnimation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "DisableEnableLoadingAnimation");
            }
        }

        private void UpdateOnScreenCountdownAndFlashLights()
        {
            try
            {
                intDisplayCountdownToRefresh--; // reduce the countdown of the 1 minute timer by 1 second
                if (intDisplayCountdownToRefresh <= 0) // if the 1 minute timer countdown has reached zero...
                {
                    intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant; // reset it
                }
                if (intDisplayCountdownToRefresh < (APIGroup1DisplayTimerIntervalSecsConstant - 1)) // if more than a second has expired since the data from the blocktimer was refreshed...
                {
                    ChangeStatusLights();
                }
                lblElapsedSinceUpdate.Invoke((MethodInvoker)delegate
                {
                    lblElapsedSinceUpdate.Location = new Point(lblRefreshSuccessOrFailMessage.Location.X + lblRefreshSuccessOrFailMessage.Width, lblElapsedSinceUpdate.Location.Y);
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "UpdateOnScreenCountdownAndFlashLights");
            }
        }

        private void ChangeStatusLights()
        {
            try
            {
                if (lblStatusLight.ForeColor != Color.IndianRed && lblStatusLight.ForeColor != Color.OliveDrab) // check whether a data refresh has just occured to see if a status light flash needs dimming
                {
                    if (lblStatusLight.ForeColor == Color.Lime) // successful data refresh has occured
                    {
                        lblStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblStatusLight.ForeColor = Color.OliveDrab; // reset the colours to a duller version to give appearance of a flash
                        });
                    }
                    else // an error must have just occured
                    {
                        lblStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblStatusLight.ForeColor = Color.IndianRed; // reset the colours to a duller version to give appearance of a flash
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "ChangeStatusLights");
            }
        }

        private void ClearAlertAndErrorMessage()
        {
            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = ""; // clear any error message
            });
            lblErrorMessage.Invoke((MethodInvoker)delegate
            {
                lblErrorMessage.Text = ""; // clear any error message
            });
        }

        private void SetLightsMessagesAndResetTimers()
        {
            try
            {
                // set successful lights and messages on the form
                lblStatusLight.Invoke((MethodInvoker)delegate
                {
                    lblStatusLight.ForeColor = Color.Lime; // for a bright green flash
                });
                lblStatusLight.Invoke((MethodInvoker)delegate
                {
                    lblStatusLight.Text = "🟢"; // circle/light
                });
                lblRefreshSuccessOrFailMessage.Invoke((MethodInvoker)delegate
                {
                    lblRefreshSuccessOrFailMessage.Text = "Data updated successfully";
                });
                intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant; // reset the timer
                intDisplaySecondsElapsedSinceUpdate = 0; // reset the seconds since last refresh
            }
            catch (Exception ex)
            {
                HandleException(ex, "SetLightsMessagesAndResetTimers");
            }
        }
        #endregion
        #region create data services
        private void CreateDataServices()
        {
            _transactionsForAddressService = new TransactionsForAddressService(NodeURL);
            _blockService = new BlockDataService(NodeURL);
            _transactionsForBlockService = new TransactionsForBlockService(NodeURL);
            _transactionService = new TransactionService(NodeURL);
            _hashrateAndDifficultyService = new HashrateAndDifficultyService(NodeURL);
            _historicPriceDataService = new HistoricPriceDataService();
            _blockFeeRatesDataService = new BlockFeeRatesDataService(NodeURL);
            _bitcoinsInCirculationDataService = new BitcoinsInCirculationDataService();
            _blockSizeAndWeightService = new BlockSizeAndWeightService(NodeURL);
            _uniqueAddressesDataService = new UniqueAddressesDataService();
            _utxoDataService = new UTXODataService();
            _poolsRankingDataService = new PoolsRankingDataService(NodeURL);
            _lightningNodesByCountryService = new LightningNodesByCountryService(NodeURL);
            _marketCapDataService = new MarketCapDataService();
        }
        #endregion
        #region get block tip
        private void GetBlockTip()
        {
            try
            {
                using WebClient client = new WebClient();
                string BlockTipURL = NodeURL + "blocks/tip/height";
                string BlockTip = client.DownloadString(BlockTipURL); 
                lblBlockNumber.Invoke((MethodInvoker)delegate
                {
                    lblBlockNumber.Text = BlockTip;
                    textBoxBlockHeightToStartListFrom.Text = BlockTip;
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetBlockTip");
            }
        }
        #endregion
        #region encrypt/decrypt string using SHA-256
        private string Encrypt(string input, string key) // encrypt a string using SHA-256
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            using var sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(keyBytes);
            byte[] encryptedBytes = new byte[inputBytes.Length];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(inputBytes[i] ^ hashedBytes[i % hashedBytes.Length]);
            }
            return Convert.ToBase64String(encryptedBytes);
        } 
                
        private string Decrypt(string input, string key) // decrypt a string using SHA-256
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Convert.FromBase64String(input);
            using var sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(keyBytes);
            byte[] decryptedBytes = new byte[inputBytes.Length];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(inputBytes[i] ^ hashedBytes[i % hashedBytes.Length]);
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        } 
        #endregion
        #region error handler
        private void HandleException(Exception ex, string methodName)
        {
            string errorMessage;
            if (ex is WebException)
            {
                errorMessage = $"Web exception in {methodName}: {ex.Message}";
            }
            else if (ex is HttpRequestException)
            {
                errorMessage = $"HTTP Request error in {methodName}: {ex.Message}";
            }
            else if (ex is JsonException)
            {
                errorMessage = $"JSON parsing error in {methodName}: {ex.Message}";
            }
            else
            {
                errorMessage = $"Error in {methodName}: {ex.Message}";
            }

            lblErrorMessage.Invoke((MethodInvoker)delegate
            {
                lblErrorMessage.Text = errorMessage;
            });
            ShowAlertSymbol();
        }
        #endregion
        #region override colours for listview headings
        private void AllListViews_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            try
            {
                SolidBrush brush = new SolidBrush(listViewHeaderColor);
                e.Graphics.FillRectangle(brush, e.Bounds);
                // Change text color and alignment
                SolidBrush textBrush = new SolidBrush(listViewHeaderTextColor);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
            }
            catch (Exception ex)
            {
                HandleException(ex, "AllListViews_DrawColumnHeader");
            }
        }
        #endregion
        #region convert sats to bitcoin
        private decimal ConvertSatsToBitcoin(string numerics)
        {
            decimal number = decimal.Parse(numerics);
            decimal result = number / 100000000;
            return result;
        }
        #endregion
        #region check network status
        private async void CheckNetworkStatus()
        {
            try
            {
                string hostnameForDisplay = "";

                if (panelXpub.Visible)
                {
                    CheckXpubNodeIsOnline();
                    Uri uri = new Uri(xpubNodeURL);

                    hostnameForDisplay = uri.Host;
                    if (lblXpubNodeStatusLight.ForeColor == Color.OliveDrab)
                    {
                        headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                        {
                            headerNetworkStatusLight.ForeColor = Color.OliveDrab;
                        });
                        headerNetworkName.Invoke((MethodInvoker)delegate
                        {
                            headerNetworkName.Text = hostnameForDisplay + " (Xpub queries only)";
                        });
                        lblSettingsXpubNodeStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                        });
                        lblSettingsXpubNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsXpubNodeStatus.Text = hostnameForDisplay;
                        });
                        label18.Invoke((MethodInvoker)delegate
                        {
                            label18.Text = hostnameForDisplay;
                        });
                        lblXpubNodeStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                        });
                    }
                    else
                    {
                        headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                        {
                            headerNetworkStatusLight.ForeColor = Color.IndianRed;
                        });
                        headerNetworkName.Invoke((MethodInvoker)delegate
                        {
                            headerNetworkName.Text = hostnameForDisplay + " (Xpub queries only)";
                        });
                        lblSettingsXpubNodeStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        });
                        lblSettingsXpubNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsXpubNodeStatus.Text = hostnameForDisplay;
                        });
                        label18.Invoke((MethodInvoker)delegate
                        {
                            label18.Text = hostnameForDisplay;
                        });
                        lblXpubNodeStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        });
                    }
                }
                else
                {
                    using var client = new HttpClient();
                    try
                    {
                        Ping pingSender = new Ping();
                        string pingAddress = null;
                        if (NodeURL == "https://mempool.space/api/")
                        {
                            pingAddress = "mempool.space";
                        }
                        else
                        {
                            if (NodeURL == "https://mempool.space/testnet/api/")
                            {
                                pingAddress = "mempool.space";
                            }
                            else
                            {
                                if (NodeURL == null)
                                {
                                    pingAddress = "mempool.space";
                                    NodeURL = "https://mempool.space/api/";
                                }
                                else
                                {
                                    if (textBoxSettingsCustomMempoolURL.Text != "")
                                    {
                                        // get the contents of the textbox
                                        string url = textBoxSettingsCustomMempoolURL.Text;

                                        // create a regex pattern to match URLs
                                        string pattern = @"^(http|https):\/\/.*\/api\/$";

                                        // create a regex object
                                        Regex regex = new Regex(pattern);

                                        // use the regex object to match the contents of the textbox
                                        if (regex.IsMatch(url)) // (at least partially) valid url
                                        {
                                            try
                                            {
                                                NodeURL = textBoxSettingsCustomMempoolURL.Text;
                                                // parse the URL to extract the hostname
                                                Uri uri = new Uri(NodeURL);
                                                string hostname = uri.Host;
                                                hostnameForDisplay = hostname;
                                                // resolve the hostname to an IP address
                                                IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                                                IPAddress ipAddress = hostEntry.AddressList[0];
                                                pingAddress = ipAddress.ToString();
                                            }
                                            catch
                                            {
                                                lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                                                {
                                                    lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                                                });
                                                lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                                                {
                                                    lblSettingsCustomNodeStatus.Text = "node offline";
                                                });
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                                            {
                                                lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                                            });
                                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                                            {
                                                lblSettingsCustomNodeStatus.Text = "node offline";
                                            });
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        PingReply reply = await pingSender.SendPingAsync(pingAddress);
                        if (reply.Status == IPStatus.Success)
                        {
                            lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatusLight.ForeColor = Color.OliveDrab;
                            });
                            headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                            {
                                headerNetworkStatusLight.ForeColor = Color.OliveDrab;
                            });
                            var displayNodeName = "";
                            if (NodeURL == "https://mempool.space/api/")
                            {
                                displayNodeName = "MAINNET (mempool.space)";
                            }
                            else
                            {
                                if (NodeURL == "https://mempool.space/testnet/api/")
                                {
                                    displayNodeName = "TESTNET (mempool.space)";
                                }
                                else
                                {
                                    displayNodeName = hostnameForDisplay;
                                }
                            }
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = displayNodeName;
                            });
                            headerNetworkName.Invoke((MethodInvoker)delegate
                            {
                                headerNetworkName.Text = displayNodeName;
                            });

                            if (lblErrorMessage.Text == "Node disconnected/offline")
                            {
                                ClearAlertAndErrorMessage();
                            }
                        }
                        else
                        {
                            // API is not online
                            lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                            });
                            headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                            {
                                headerNetworkStatusLight.ForeColor = Color.IndianRed;
                            });
                            var displayNodeName = "";
                            if (NodeURL == "https://mempool.space/api/")
                            {
                                displayNodeName = "MAINNET (mempool.space)";
                            }
                            else
                            {
                                if (NodeURL == "https://mempool.space/testnet/api/")
                                {
                                    displayNodeName = "TESTNET (mempool.space)";
                                }
                                else
                                {
                                    displayNodeName = hostnameForDisplay;
                                }
                            }
                            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                            {
                                lblSettingsCustomNodeStatus.Text = displayNodeName;
                            });
                            headerNetworkName.Invoke((MethodInvoker)delegate
                            {
                                headerNetworkName.Text = displayNodeName;
                            });
                            ShowAlertSymbol();
                            lblErrorMessage.Invoke((MethodInvoker)delegate
                            {
                                lblErrorMessage.Text = "Node disconnected/offline";
                            });
                        }
                    }
                    catch (HttpRequestException)
                    {
                        // API is not online
                        lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
                        });
                        var displayNodeName = "";
                        if (NodeURL == "https://mempool.space/api/")
                        {
                            displayNodeName = "MAINNET (mempool.space)";
                        }
                        else
                        {
                            if (NodeURL == "https://mempool.space/testnet/api/")
                            {
                                displayNodeName = "TESTNET (mempool.space)";
                            }
                            else
                            {
                                displayNodeName = hostnameForDisplay;
                            }
                        }
                        lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                        {
                            lblSettingsCustomNodeStatus.Text = displayNodeName;
                        });
                        headerNetworkName.Invoke((MethodInvoker)delegate
                        {
                            headerNetworkName.Text = displayNodeName;
                        });
                        ShowAlertSymbol();
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = "Node disconnected/offline";
                        });
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = "CheckNetworkStatus: " + ex.Message;
                        });
                    }

                    headerNetworkName.Invoke((MethodInvoker)delegate
                    {
                        headerNetworkName.Location = new Point(panelFees.Location.X + panelFees.Width - headerNetworkName.Width, headerNetworkName.Location.Y);
                    });
                    headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                    {
                        headerNetworkStatusLight.Location = new Point(headerNetworkName.Location.X - headerNetworkStatusLight.Width, headerNetworkStatusLight.Location.Y);
                    });
                }
                headerNetworkName.Invoke((MethodInvoker)delegate
                {
                    headerNetworkName.Location = new Point(774 - headerNetworkName.Width, headerNetworkName.Location.Y);
                });
                headerNetworkStatusLight.Invoke((MethodInvoker)delegate
                {
                    headerNetworkStatusLight.Location = new Point(headerNetworkName.Location.X - 13, headerNetworkStatusLight.Location.Y);
                });
            }
            catch (Exception ex)
            {
                HandleException(ex, "CheckNetworkStatus");
            }
        }
        #endregion
        #region update genesis background clock
        private void UpdateOnScreenClock()
        {
            try
            {
                lblTime.Invoke((MethodInvoker)delegate
                {
                    lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                });

            }
            catch (Exception ex)
            {
                HandleException(ex, "UpdateOnScreenClock");
            }
        }
        #endregion
        #endregion

        #region ⚡GENERAL FORM NAVIGATION AND CONTROLS⚡
        #region main menu
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
            if (panelMenu.Height == 24)
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 338;
                });
                btnMenu.Invoke((MethodInvoker)delegate
                {
                    btnMenu.BackColor = panelMenu.BackColor;
                });
                CloseCurrencyMenu();
                CloseThemeMenu();
            }
            else
            {
                CloseMainMenu();
            }
        }

        private void BtnMenuBitcoinDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();

                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "₿ dashboard";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuBitcoinDashboard.Location.X + (btnMenuBitcoinDashboard.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuBitcoinDashboard.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuBitcoinDashboard.Location.X, btnMenuBitcoinDashboard.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = false;
                btnMenuBlockList.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBlock.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuSettings2.Enabled = true;
                btnMenuAppearance.Enabled = true;
                this.DoubleBuffered = true;
                this.SuspendLayout();
                panelBookmarks.Visible = false;
                panelBlockList.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = false;
                panelXpub.Visible = false;
                panelBitcoinDashboard.Visible = true;
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuBitcoinDashboard_Click");
            }
        }

        private void BtnMenuLightningDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();

                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "⚡dashboard";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuLightningDashboard.Location.X + (btnMenuLightningDashboard.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuLightningDashboard.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuLightningDashboard.Location.X, btnMenuLightningDashboard.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuSettings2.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuLightningDashboard.Enabled = false;
                this.DoubleBuffered = true;
                this.SuspendLayout();
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelCharts.Visible = false;
                panelBlockList.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = false;
                panelLightningDashboard.Visible = true;
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuLightningDashboard_Click");
            }
        }

        private void BtnMenuCharts_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();

                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "charts";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuCharts.Location.X + (btnMenuCharts.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuCharts.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuCharts.Location.X, btnMenuCharts.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuCharts.Enabled = false;
                this.DoubleBuffered = true;
                this.SuspendLayout();
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelBlockList.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = true;
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnMenuGraphs_Click");
            }
        }

        private void BtnMenuAddress_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "address";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuAddress.Location.X + (btnMenuAddress.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuAddress.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuAddress.Location.X, btnMenuAddress.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuAddress.Enabled = false;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelBlockList.Visible = false;
                panelLightningDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelBlock.Visible = false;
                panelCharts.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = false;
                panelAddress.Visible = true;
                CheckNetworkStatus();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuAddress_Click");
            }
        }

        private void BtnMenuBlock_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();

                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "block";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuBlock.Location.X + (btnMenuBlock.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuBlock.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuBlock.Location.X, btnMenuBlock.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlock.Enabled = false;
                btnMenuBookmarks.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuSettings2.Enabled = true;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelCharts.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelBlock.Visible = true;
                CheckNetworkStatus();
                if (textBoxSubmittedBlockNumber.Text == "")
                {
                    textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        textBoxSubmittedBlockNumber.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                    });
                    LookupBlock(); // fetch all the block data automatically for the initial view. 
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuBlock_Click");
            }
        }

        private void BtnMenuXpub_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "xpub";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuXpub.Location.X + (btnMenuXpub.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuXpub.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuXpub.Location.X, btnMenuXpub.Location.Y + 5);
                });
                btnMenuXpub.Enabled = false;
                btnMenuBlock.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuAppearance.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuBlockList.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelBookmarks.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelBlock.Visible = false;
                panelSettings.Visible = false;
                panelXpub.Visible = true;
                CheckNetworkStatus();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuXpub_Click");
            }
        }

        private void BtnMenuBlockList_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "blocks";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuBlockList.Location.X + (btnMenuBlockList.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuBlockList.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuBlockList.Location.X, btnMenuBlockList.Location.Y + 5);
                });
                btnMenuBlockList.Enabled = false;
                btnMenuXpub.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelAppearance.Visible = false;
                panelSettings.Visible = false;
                panelBlockList.Visible = true;
                CheckNetworkStatus();
                if (textBoxBlockHeightToStartListFrom.Text == "")
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                    });
                    LookupBlockList(); // fetch the first 15 blocks automatically for the initial view.
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuBlockList_Click");
            }
        }

        private void BtnMenuTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "transaction";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuTransaction.Location.X + (btnMenuTransaction.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuTransaction.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuTransaction.Location.X, btnMenuTransaction.Location.Y + 5);
                });
                btnMenuTransaction.Enabled = false;
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuAppearance.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuBookmarks.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelBookmarks.Visible = false;
                panelBlock.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelBlockList.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelTransaction.Visible = true;
                CheckNetworkStatus();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuTransaction_Click");
            }
        }

        private void BtnMenuBookmarks_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "bookmarks";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuBookmarks.Location.X + (btnMenuBookmarks.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuBookmarks.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuBookmarks.Location.X, btnMenuBookmarks.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuAppearance.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuBookmarks.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelSettings.Visible = false;
                panelBookmarks.Visible = true;
                CheckNetworkStatus();
                SetupBookmarksScreen();
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnMenuBookmarks_Click");
            }
        }

        private void BtnMenuSettings2_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "settings";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuSettings2.Location.X + (btnMenuSettings2.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuSettings2.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuSettings2.Location.X, btnMenuSettings2.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuBookmarks.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuSettings2.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelTransaction.Visible = false;
                panelAppearance.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelBookmarks.Visible = false;
                panelSettings.Visible = true;
                CheckNetworkStatus();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuSettings2_Click");
            }
        }

        private void BtnAppearance_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();
                lblMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonText.Text = "appearance";
                    lblMenuHighlightedButtonText.Location = new Point((btnMenuAppearance.Location.X + (btnMenuAppearance.Width / 2)) - lblMenuHighlightedButtonText.Width / 2, btnMenuAppearance.Location.Y + 3);
                });
                lblMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
                {
                    lblMenuHighlightedButtonMarker.Location = new Point(btnMenuAppearance.Location.X, btnMenuAppearance.Location.Y + 5);
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                if (!testNet)
                {
                    btnMenuCharts.Enabled = true;
                }
                btnMenuBookmarks.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuAppearance.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelCharts.Visible = false;
                panelAddress.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelBookmarks.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = true;
                CheckNetworkStatus();
                // populate the dropdown list with the available themes
                var themes = ReadThemesFromJsonFile();
                List<string> themeNames = themes.Select(t => t.ThemeName).ToList();
                comboBoxThemeList.DataSource = themeNames;
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnAppearance_Click");
            }
        }

        #endregion
        #region show help screen
        private void BtnMenuHelp_Click(object sender, EventArgs e)
        {
            try
            {
                var modalWindow = new HelpScreen
                {
                    Owner = this, // Set the parent window as the owner of the modal window
                    StartPosition = FormStartPosition.CenterParent, // Set the start position to center of parent
                    TextColor = label77.ForeColor, // random label color to pass to the help screen
                    HeadingTextColor = label26.ForeColor, // random heading color to pass to the help screen
                    ButtonTextColor = btnMenu.ForeColor,
                    ButtonBackColor = btnMenu.BackColor,
                    ButtonTextColor2 = btnPreviousBlock.ForeColor,
                    ButtonBackColor2 = btnPreviousBlock.BackColor,
                    TextBoxBackColor = chartsBackgroundColor,
                    TextBoxForeColor = textBoxBlockHeightToStartListFrom.ForeColor,
                    WindowBackgroundColor = BackColor,
                    WindowBackgroundImage = BackgroundImage
                };
                modalWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuHelp_Click");
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e) // help screen
        {
            try
            {
                var modalWindow = new HelpScreen
                {
                    Owner = this, // Set the parent window as the owner of the modal window
                    StartPosition = FormStartPosition.CenterParent, // Set the start position to center of parent
                    TextColor = label77.ForeColor, // random label color to pass to the help screen
                    HeadingTextColor = label26.ForeColor, // random heading color to pass to the help screen
                    ButtonTextColor = btnMenu.ForeColor,
                    ButtonBackColor = btnMenu.BackColor,
                    ButtonTextColor2 = btnPreviousBlock.ForeColor,
                    ButtonBackColor2 = btnPreviousBlock.BackColor,
                    TextBoxBackColor = chartsBackgroundColor,
                    TextBoxForeColor = textBoxBlockHeightToStartListFrom.ForeColor,
                    WindowBackgroundColor = BackColor,
                    WindowBackgroundImage = BackgroundImage

                };
                modalWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnHelp_Click");
            }
        }
        #endregion
        #region show about screen
        private void BtnMenuSplash_Click(object sender, EventArgs e)
        {
            try
            {
                CloseMainMenu();

                var modalWindow = new Splash
                {
                    Owner = this, // Set the parent window as the owner of the modal window
                    StartPosition = FormStartPosition.CenterParent, // Set the start position to center of parent
                    WindowBackgroundColor = panel88.BackColor,
                    LabelColor = label26.ForeColor,
                    LinksColor = lblHeaderMarketCap.ForeColor,
                    ButtonTextColor = btnMenu.ForeColor,
                    ButtonBackColor = btnMenu.BackColor,
                    CurrentVersion = CurrentVersion,
                    PrivacyMode = privacyMode
                };
                modalWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuSplash_Click");
            }
        }
        #endregion
        #region currency menu & get market data
        private void BtnCurrency_Click(object sender, EventArgs e)
        {
            panelCurrency.BringToFront();
            if (panelCurrency.Height == 24)
            {
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 122;
                });
                btnCurrency.Invoke((MethodInvoker)delegate
                {
                    btnCurrency.BackColor = panelMenu.BackColor;
                });
                CloseMainMenu();
                CloseThemeMenu();
            }
            else
            {
                CloseCurrencyMenu();
            }
        }

        private void BtnUSD_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = false;
            btnEUR.Enabled = true;
            btnGBP.Enabled = true;
            btnXAU.Enabled = true;
            btnCurrency.Text = "USD $";
            CloseCurrencyMenuGetMarketDataSaveCurrency();
            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonText.Text = "USD $";
                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnUSD.Location.X + (btnUSD.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnUSD.Location.Y + 3);
            });
            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnUSD.Location.X, btnUSD.Location.Y + 5);
            });
        }

        private void BtnEUR_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = false;
            btnGBP.Enabled = true;
            btnXAU.Enabled = true;
            btnCurrency.Text = "EUR €";
            CloseCurrencyMenuGetMarketDataSaveCurrency();
            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonText.Text = "EUR €";
                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnEUR.Location.X + (btnEUR.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnEUR.Location.Y + 3);
            });
            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnEUR.Location.X, btnEUR.Location.Y + 5);
            });
        }

        private void BtnGBP_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = true;
            btnGBP.Enabled = false;
            btnXAU.Enabled = true;
            btnCurrency.Text = "GBP £";
            CloseCurrencyMenuGetMarketDataSaveCurrency();
            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonText.Text = "GBP £";
                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnGBP.Location.X + (btnGBP.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnGBP.Location.Y + 3);
            });
            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnGBP.Location.X, btnGBP.Location.Y + 5);
            });
        }

        private void BtnXAU_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = true;
            btnGBP.Enabled = true;
            btnXAU.Enabled = false;
            btnCurrency.Text = "XAU 🪙";
            CloseCurrencyMenuGetMarketDataSaveCurrency();
            lblCurrencyMenuHighlightedButtonText.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonText.Text = "XAU 🪙";
                lblCurrencyMenuHighlightedButtonText.Location = new Point((btnXAU.Location.X + (btnXAU.Width / 2)) - lblCurrencyMenuHighlightedButtonText.Width / 2, btnXAU.Location.Y + 3);
            });
            lblCurrencyMenuHighlightedButtonMarker.Invoke((MethodInvoker)delegate
            {
                lblCurrencyMenuHighlightedButtonMarker.Location = new Point(btnXAU.Location.X, btnXAU.Location.Y + 5);
            });
        }

        private void CloseCurrencyMenuGetMarketDataSaveCurrency()
        {
            CloseCurrencyMenu();
            GetMarketData();
            SaveSettingsToBookmarksFile();
        }

        private void GetMarketData()
        {
            try
            {
                if (!privacyMode)
                {
                    var (priceUSD, priceGBP, priceEUR, priceXAU) = BitcoinExplorerOrgGetPrice();
                    var (mCapUSD, mCapGBP, mCapEUR, mCapXAU) = BitcoinExplorerOrgGetMarketCap();
                    var (satsUSD, satsGBP, satsEUR, satsXAU) = BitcoinExplorerOrgGetMoscowTime();
                    if (testNet)
                    {
                        priceUSD = "0 (TestNet)";
                        priceGBP = "0 (TestNet)";
                        priceEUR = "0 (TestNet)";
                        priceXAU = "0 (TestNet)";
                        mCapUSD = "0 (TestNet)";
                        mCapGBP = "0 (TestNet)";
                        mCapEUR = "0 (TestNet)";
                        mCapXAU = "0 (TestNet)";
                        satsUSD = "0 (TestNet)";
                        satsGBP = "0 (TestNet)";
                        satsEUR = "0 (TestNet)";
                        satsXAU = "0 (TestNet)";
                    }
                    string price = "";
                    string mCap = "";
                    string satsPerUnit = "";
                    if (!btnUSD.Enabled)
                    {
                        price = "$" + priceUSD;
                        mCap = "$" + mCapUSD;
                        satsPerUnit = satsUSD;
                        lblHeaderMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderMoscowTimeLabel.Text = "1$ (USD) / sats";
                        });
                        lblMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMoscowTimeLabel.Text = "1 USD / sats";
                        });
                        lblPriceLabel.Invoke((MethodInvoker)delegate
                        {
                            lblPriceLabel.Text = "1 BTC / USD";
                        });
                        lblMarketCapLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMarketCapLabel.Text = "Market cap (USD)";
                        });
                    }
                    if (!btnEUR.Enabled)
                    {
                        price = "€" + priceEUR;
                        mCap = "€" + mCapEUR;
                        satsPerUnit = satsEUR;
                        lblHeaderMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderMoscowTimeLabel.Text = "1€ (EUR) / sats";
                        });
                        lblMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMoscowTimeLabel.Text = "1 EUR / sats";
                        });
                        lblPriceLabel.Invoke((MethodInvoker)delegate
                        {
                            lblPriceLabel.Text = "1 BTC / EUR";
                        });
                        lblMarketCapLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMarketCapLabel.Text = "Market cap (EUR)";
                        });
                    }
                    if (!btnGBP.Enabled)
                    {
                        price = "£" + priceGBP;
                        mCap = "£" + mCapGBP;
                        satsPerUnit = satsGBP;
                        lblHeaderMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderMoscowTimeLabel.Text = "1£ (GBP) / sats";
                        });
                        lblMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMoscowTimeLabel.Text = "1 GBP / sats";
                        });
                        lblPriceLabel.Invoke((MethodInvoker)delegate
                        {
                            lblPriceLabel.Text = "1 BTC / GBP";
                        });
                        lblMarketCapLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMarketCapLabel.Text = "Market cap (GBP)";
                        });
                    }
                    if (!btnXAU.Enabled)
                    {
                        price = "🪙" + priceXAU;
                        mCap = "🪙" + mCapXAU;
                        satsPerUnit = satsXAU;
                        lblHeaderMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderMoscowTimeLabel.Text = "1🪙 (XAU) / sats";
                        });
                        lblMoscowTimeLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMoscowTimeLabel.Text = "1 XAU / sats";
                        });
                        lblPriceLabel.Invoke((MethodInvoker)delegate
                        {
                            lblPriceLabel.Text = "1 BTC / XAU";
                        });
                        lblMarketCapLabel.Invoke((MethodInvoker)delegate
                        {
                            lblMarketCapLabel.Text = "Market cap (XAU)";
                        });
                    }

                    lblHeaderMoscowTime.Invoke((MethodInvoker)delegate
                    {
                        lblHeaderMoscowTime.Location = new Point(lblHeaderMoscowTimeLabel.Location.X + lblHeaderMoscowTimeLabel.Width, lblHeaderMoscowTimeLabel.Location.Y);
                    });
                    lblPriceUSD.Invoke((MethodInvoker)delegate
                    {
                        lblPriceUSD.Text = price;
                    });
                    lblHeaderPrice.Invoke((MethodInvoker)delegate
                    {
                        lblHeaderPrice.Text = price;
                    });
                    pictureBoxHeaderPriceChart.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxHeaderPriceChart.Location = new Point(lblHeaderPrice.Location.X + lblHeaderPrice.Width, pictureBoxHeaderPriceChart.Location.Y);
                    });
                    lblMarketCapUSD.Invoke((MethodInvoker)delegate
                    {
                        lblMarketCapUSD.Text = mCap;
                    });
                    lblHeaderMarketCap.Invoke((MethodInvoker)delegate
                    {
                        lblHeaderMarketCap.Text = mCap;
                    });
                    pictureBoxHeaderMarketCapChart.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxHeaderMarketCapChart.Location = new Point(lblHeaderMarketCap.Location.X + lblHeaderMarketCap.Width, pictureBoxHeaderMarketCapChart.Location.Y);
                    });
                    lblMoscowTime.Invoke((MethodInvoker)delegate
                    {
                        lblMoscowTime.Text = satsPerUnit;
                    });
                    lblHeaderMoscowTime.Invoke((MethodInvoker)delegate
                    {
                        lblHeaderMoscowTime.Text = satsPerUnit;
                    });
                    pictureBoxHeaderConverterChart.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxHeaderConverterChart.Location = new Point(lblHeaderMoscowTime.Location.X + lblHeaderMoscowTime.Width, pictureBoxHeaderConverterChart.Location.Y);
                    });
                }
            }
            catch (WebException ex)
            {
                HandleException(ex, "getting market data");
            }
        }
        #endregion
        #region minimise/exit window
        private void BtnExit_Click(object sender, EventArgs e) // exit
        {
            this.Close();
        }

        private void BtnMinimise_Click(object sender, EventArgs e) // minimise the form
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region move window
        private void BtnMoveWindow_MouseDown(object sender, MouseEventArgs e) // move the form when the move control is used
        {

            CloseMainMenu();
            CloseCurrencyMenu();
            CloseThemeMenu();
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMoveWindow_MouseUp(object sender, MouseEventArgs e) // reset colour of the move form control
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                return;
            }
            btnMoveWindow.BackColor = System.Drawing.ColorTranslator.FromHtml("#1D1D1D");
        }

        private void BtnMoveWindow_Click(object sender, EventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                return;
            }
            CloseMainMenu();
            CloseCurrencyMenu();
            CloseThemeMenu();
        }
        #endregion
        #region chart icons in header area
        private void PictureBoxHeaderHashrateChart_Click(object sender, EventArgs e)
        {
            BtnChartHashrate_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxHeaderPriceChart_Click(object sender, EventArgs e)
        {
            BtnChartPrice_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxHeaderFeeRatesChart_Click(object sender, EventArgs e)
        {
            BtnChartFeeRates_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxChartCirculation_Click(object sender, EventArgs e)
        {
            BtnChartCirculation_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxHeaderBlockSizeChart_Click(object sender, EventArgs e)
        {
            BtnChartBlockSize_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxHeaderConverterChart_Click(object sender, EventArgs e)
        {
            BtnPriceConverter_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }

        private void PictureBoxHeaderMarketCapChart_Click(object sender, EventArgs e)
        {
            BtnChartMarketCap_Click(sender, e);
            BtnMenuCharts_Click(sender, e);
        }
        #endregion
        #region get panel states
        public Panel GetPanelBlock() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelBlock;
        }

        public Panel GetPanelBlockList() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelBlockList;
        }

        public Panel GetPanelAddress() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelAddress;
        }

        public Panel GetPanelBitcoinDashboard() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelBitcoinDashboard;
        }

        public Panel GetPanelLightningDashboard() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelLightningDashboard;
        }

        public Panel GetPanelTransaction() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelTransaction;
        }

        public Panel GetPanelXpub() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelXpub;
        }

        public Panel GetPanelCharts() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelCharts;
        }

        public Panel GetPanelBookmarks() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelBookmarks;
        }

        public Panel GetPanelAppearance() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelAppearance;
        }

        public Panel GetPanelSettings() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelSettings;
        }

        public Panel GetPanelMenu() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelMenu;
        }
        #endregion
        #region close menus
        private void CloseMainMenu()
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24;
            });
            btnMenu.Invoke((MethodInvoker)delegate
            {
                btnMenu.BackColor = chartsBackgroundColor;
            });
        }
        private void CloseThemeMenu()
        {
            panelThemeMenu.Invoke((MethodInvoker)delegate
            {
                panelThemeMenu.Height = 24;
            });
            btnThemeMenu.Invoke((MethodInvoker)delegate
            {
                btnThemeMenu.BackColor = chartsBackgroundColor;
            });
        }

        private void CloseCurrencyMenu()
        {
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            btnCurrency.Invoke((MethodInvoker)delegate
            {
                btnCurrency.BackColor = chartsBackgroundColor;
            });
        }
#endregion
        #endregion

        #region CLASSES
        #region bookmark
public class Bookmark
        {
            public DateTime DateAdded { get; set; }
            public string Type { get; set; }
            public string Data { get; set; }
            public string Note { get; set; }
            public bool Encrypted { get; set; }
            public string KeyCheck { get; set; }
        }
        #endregion
        #region theme
        public class Theme
        {
            public string ThemeName { get; set; }
            public Color DataFields { get; set; }
            public Color Labels { get; set; }
            public Color Headings { get; set; }
            public Color Tables { get; set; }
            public Color TableHeadings { get; set; }
            public Color OtherText { get; set; }
            public Color PriceBlock { get; set; }
            public Color StatusErrors { get; set; }
            public Color Buttons { get; set; }
            public Color ButtonText { get; set; }
            public Color Lines { get; set; }
            public Color TextBoxes { get; set; }
            public Color ProgressBars { get; set; }
            public Color TableBackgrounds { get; set; }
            public Color TableTitleBars { get; set; }
            public bool ShowTime { get; set; }
            public bool HeadingBGDefault { get; set; }
            public bool HeadingBGNone { get; set; }
            public bool HeadingBGCustom { get; set; }
            public Color HeadingBackgrounds { get; set; }
            public Color WindowBackground { get; set; }
            public string WindowImage { get; set; }
            public bool BackgroundGenesis { get; set; }
            public bool BackgroundBTCdir { get; set; }
            public bool BackgroundSatsuma { get; set; }
            public bool BackgroundCustomColor { get; set; }
            public bool BackgroundCustomImage { get; set; }
            public Color Panels { get; set; }
            public bool ChartsDark { get; set; }
            public bool OrangeInfinity { get; set; }
        }
        #endregion
        #region address transactions
        // ------------------------------------- Address Transactions -----------------------------------
        public class TransactionsForAddressService
        {
            private readonly string _nodeUrl;

            public TransactionsForAddressService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }

            public async Task<string> GetTransactionsForAddressAsync(string address, string mempoolConfOrAllTx, string lastSeenTxId = "")
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        if (mempoolConfOrAllTx == "chain")
                        {
                            var response = await client.GetAsync($"address/{address}/txs/chain/{lastSeenTxId}");
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                        }
                        if (mempoolConfOrAllTx == "mempool")
                        {
                            var response = await client.GetAsync($"address/{address}/txs/mempool");
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                        }
                        if (mempoolConfOrAllTx == "all")
                        {
                            var response = await client.GetAsync($"address/{address}/txs");
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                        }

                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }

        // ------------------------------------- Address Transactions (for xpub screen) -----------------------------------
        public class TransactionsForXpubAddressService
        {
            private readonly string _nodeUrl;

            public TransactionsForXpubAddressService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }

            public async Task<string> GetTransactionsForXpubAddressAsync(string address, string mempoolConfOrAllTx, string lastSeenTxId = "")
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        if (mempoolConfOrAllTx == "chain")
                        {
                            if (lastSeenTxId == "")
                            {
                                var response = await client.GetAsync($"address/{address}/txs/{lastSeenTxId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    return await response.Content.ReadAsStringAsync();
                                }
                            }
                            else
                            {
                                var response = await client.GetAsync($"address/{address}/txs/chain/{lastSeenTxId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    return await response.Content.ReadAsStringAsync();
                                }
                            }
                            
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }

        public class AddressTransactions
        {
            public string Txid { get; set; }
            public Status_AddressTransactions Status { get; set; }
            public List<Vout_AddressTransactions> Vout { get; set; }
            public List<Vin_AddressTransactions> Vin { get; set; }
        }

        public class Vin_AddressTransactions
        {
            public Prevout_AddressTransactions Prevout { get; set; }
            //public decimal Value { get; set; }
            //public decimal Amount { get; set; }
        }

        public class Prevout_AddressTransactions
        {
            public string Scriptpubkey_address { get; set; }
            public decimal Value { get; set; }
        }

        public class Vout_AddressTransactions
        {
            public double Value { get; set; }
           // public decimal Amount { get; set; }
            public string Scriptpubkey_address { get; set; }
           // public string Scriptpubkey_asm { get; set; }
        }

        public class Status_AddressTransactions
        {
            public int Block_height { get; set; }
            public string Confirmed { get; set; }
        }
        #endregion
        #region blocks
        public class BlockDataService
        {
            private readonly string _nodeUrl;
            public BlockDataService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetBlockDataAsync(string blockHeight)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        if (blockHeight == "000000")
                        {
                            blockHeight = "";
                        }
                       
                        client.BaseAddress = new Uri(_nodeUrl);

                        var response = await client.GetAsync($"v1/blocks/{blockHeight}");
                        
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }

        public class Block
        {
            public Block_extras Extras { get; set; }
          //  public string Id { get; set; }
            public string Height { get; set; }
            public string Version { get; set; }
            public string Timestamp { get; set; }
          //  public string Bits { get; set; }
            public string Nonce { get; set; }
           // public string Difficulty { get; set; }
           // public string Merkle_root { get; set; }
            public int Tx_count { get; set; }
            public int Size { get; set; }
            public string Weight { get; set; }
           // public string Previousblockhash { get; set; }
        }

        public class Block_extras
        {
            public string Reward { get; set; }
            public decimal MedianFee { get; set; }
            public decimal[] FeeRange { get; set; }
            public int TotalFees { get; set; }
            public string AvgFee { get; set; }
            //  public string AvgFeeRate { get; set; }
            public string AvgTxSize { get; set; }
            public string TotalInputs { get; set; }
            public string TotalOutputs { get; set; }
           // public string TotalOutputAmt { get; set; }
            public Block_pool Pool { get; set; }

        }

        public class Block_pool
        {
            public string Name { get; set; }
        }
        #endregion
        #region transaction
        public class TransactionService
        {
            private readonly string _nodeUrl;
            public TransactionService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetTransactionAsync(string TransactionID)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"tx/{TransactionID}");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }

        public class Transaction
        {
          //  public string Txid { get; set; }
            public int Version { get; set; }
            public int Locktime { get; set; }
            public TransactionVin[] Vin { get; set; }
            public TransactionVout[] Vout { get; set; }
            public int Size { get; set; }
            public int Weight { get; set; }
            public int Fee { get; set; }
            public TransactionStatus Status { get; set; }
        }

        public class TransactionStatus
        {
          //  public bool Confirmed { get; set; }
            public int Block_height { get; set; }
           // public string Block_hash { get; set; }
            public int Block_time { get; set; }
        }

        public class TransactionVin
        {
          //  public string Txid { get; set; }
          //  public long Vout { get; set; }
            public TransactionVinPrevout Prevout { get; set; }
           // public string Scriptsig { get; set; }
           // public string Scriptsig_asm { get; set; }
           // public string[] Witness { get; set; }
            public bool Is_coinbase { get; set; }
           // public long Sequence { get; set; }
           // public string Inner_redeemscript_asm { get; set; }
        }

        public class TransactionVinPrevout
        {
           // public string Scriptpubkey { get; set; }
           // public string Scriptpubkey_asm { get; set; }
           // public string Scriptpubkey_type { get; set; }
            public string Scriptpubkey_address { get; set; }
            public long Value { get; set; }
        }

        public class TransactionVout
        {
          //  public string Scriptpubkey { get; set; }
            public string Scriptpubkey_asm { get; set; }
          //  public string Scriptpubkey_type { get; set; }
            public string Scriptpubkey_address { get; set; }
            public long Value { get; set; }
        }
        #endregion
        #region block transactions
        public class TransactionsForBlockService
        {
            private readonly string _nodeUrl;

            public TransactionsForBlockService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }

            public async Task<string> GetTransactionsForBlockAsync(string blockHash, string lastSeenBlockTransaction)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"block/{blockHash}/txs/{lastSeenBlockTransaction}");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }

                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return null;
            }
        }

        public class Block_Transactions
        {
            public string Txid { get; set; }
            //      public string version { get; set; }
            //     public string locktime { get; set; }
            public List<Vin_BlockTransactions> Vin { get; set; }
            public List<Vout_BlockTransactions> Vout { get; set; }
            //      public string size { get; set; }
            //      public string weight { get; set; }
            public string Fee { get; set; }
            //     public List<Status_BlockTransactions> status { get; set; }
        }

        public class Vin_BlockTransactions
        {
            //public string Is_coinbase { get; set; }
            //public string sequence { get; set; }
        }

        public class Vout_BlockTransactions
        {
            //     public string scriptpubkey { get; set; }
            //     public string scriptpubkey_asm { get; set; }
            //    public string scriptpubkey_type { get; set; }
            //    public string scriptpubkey_address { get; set; }
            public string Value { get; set; }
        }
        #endregion
        #region date/time
        public static class DateTimeExtensions
        {
            public static DateTime FromUnixTimeMilliseconds(long milliseconds)
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                return dateTimeOffset.UtcDateTime;
            }
        }
        #endregion
        #region charts
        #region price chart
        public class PriceCoordinatesList
        {
            public string X { get; set; }
            public decimal Y { get; set; }
        }

        public class HistoricPriceDataService
        {
            public async Task<string> GetHistoricPriceDataAsync(string chartPeriod)
            {
                int retryCount = 3; 
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.blockchain.info/");
                        string blockChainInfoPeriod = "";
                        if (chartPeriod == "1m")
                        {
                            blockChainInfoPeriod = "1months";
                        }
                        if (chartPeriod == "3m")
                        {
                            blockChainInfoPeriod = "3months";
                        }
                        if (chartPeriod == "6m")
                        {
                            blockChainInfoPeriod = "6months";
                        }
                        if (chartPeriod == "1y")
                        {
                            blockChainInfoPeriod = "1years";
                        }
                        if (chartPeriod == "3y")
                        {
                            blockChainInfoPeriod = "3years";
                        }
                        if (chartPeriod == "all")
                        {
                            blockChainInfoPeriod = "all";
                        }
                        var response = await client.GetAsync($"charts/market-price?timespan=" + blockChainInfoPeriod + "&format=json");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region market cap chart
        public class MarketCapCoordinatesList
        {
            public string X { get; set; }
            public decimal Y { get; set; }
        }

        public class MarketCapDataService
        {
            public async Task<string> GetMarketCapDataAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.blockchain.info/");
                        string blockChainInfoPeriod = "";
                        if (chartPeriod == "1m")
                        {
                            blockChainInfoPeriod = "1months";
                        }
                        if (chartPeriod == "3m")
                        {
                            blockChainInfoPeriod = "3months";
                        }
                        if (chartPeriod == "6m")
                        {
                            blockChainInfoPeriod = "6months";
                        }
                        if (chartPeriod == "1y")
                        {
                            blockChainInfoPeriod = "1years";
                        }
                        if (chartPeriod == "3y")
                        {
                            blockChainInfoPeriod = "3years";
                        }
                        if (chartPeriod == "all")
                        {
                            blockChainInfoPeriod = "all";
                        }
                        var response = await client.GetAsync($"charts/market-cap?timespan=" + blockChainInfoPeriod + "&format=json");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region reward chart
        public class HistoricRewardsAndPrice
        {
          //  public string AvgHeight { get; set; }
            public string Timestamp { get; set; }
            public decimal AvgRewards { get; set; }
          //  public decimal USD { get; set; }
        }
        #endregion
        #region fees chart
        public class HistoricFeesAndPrice
        {
         //   public string AvgHeight { get; set; }
            public string Timestamp { get; set; }
            public decimal AvgFees { get; set; }
          //  public decimal USD { get; set; }
        }
        #endregion
        #region hashrate and difficulty charts
        public class HashrateSnapshot
        {
            public string Timestamp { get; set; }
            public decimal AvgHashrate { get; set; }
        }

        public class DifficultySnapshot
        {
            public string Time { get; set; }
         //   public long Height { get; set; }
            public decimal Difficulty { get; set; }
          //  public decimal Adjustment { get; set; }
        }

        public class HashrateAndDifficultyService
        {
            private readonly string _nodeUrl;
            public HashrateAndDifficultyService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetHashrateAndDifficultyAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/mining/hashrate/" + chartPeriod);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region fee rates chart
        public class BlockFeeRates
        {
          //  public string AvgHeight { get; set; }
            public string Timestamp { get; set; }
            public double AvgFee_0 { get; set; }
            public double AvgFee_10 { get; set; }
            public double AvgFee_25 { get; set; }
            public double AvgFee_50 { get; set; }
            public double AvgFee_75 { get; set; }
            public double AvgFee_90 { get; set; }
            public double AvgFee_100 { get; set; }
        }

        public class BlockFeeRatesDataService
        {
            private readonly string _nodeUrl;
            public BlockFeeRatesDataService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetBlockFeeRatesAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/mining/blocks/fee-rates/" + chartPeriod);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region circulation chart
        public class BTCInCircChartCoordinates
        {
            public string X { get; set; } // date
            public decimal Y { get; set; } // BTC in circ
        }

        public class BitcoinsInCirculationDataService
        {
            public async Task<string> GetBitcoinsInCirculationAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.blockchain.info/");
                        string blockChainInfoPeriod = "";
                        if (chartPeriod == "1m")
                        {
                            blockChainInfoPeriod = "1months";
                        }
                        if (chartPeriod == "3m")
                        {
                            blockChainInfoPeriod = "3months";
                        }
                        if (chartPeriod == "6m")
                        {
                            blockChainInfoPeriod = "6months";
                        }
                        if (chartPeriod == "1y")
                        {
                            blockChainInfoPeriod = "1years";
                        }
                        if (chartPeriod == "3y")
                        {
                            blockChainInfoPeriod = "3years";
                        }
                        if (chartPeriod == "all")
                        {
                            blockChainInfoPeriod = "all";
                        }
                        var response = await client.GetAsync($"charts/total-bitcoins?timespan=" + blockChainInfoPeriod + "&format=json");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region block size chart
        public class Sizes
        {
         //   public string AvgHeight { get; set; }
            public string Timestamp { get; set; }
            public decimal AvgSize { get; set; }
        }

        public class Weights
        {
         //   public string AvgHeight { get; set; }
          //  public string Timestamp { get; set; }
         //   public decimal AvgWeight { get; set; }
        }

        public class BlockSizeAndWeightService
        {
            private readonly string _nodeUrl;
            public BlockSizeAndWeightService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetBlockSizeAndWeightServiceAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/mining/blocks/sizes-weights/" + chartPeriod);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region unique addresses chart
        public class UniqueAddressesList
        {
            public string X { get; set; }
            public decimal Y { get; set; }
        }

        public class UniqueAddressesDataService
        {
            public async Task<string> GetUniqueAddressesDataAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.blockchain.info/");
                        string blockChainInfoPeriod = "";
                        if (chartPeriod == "1m")
                        {
                            blockChainInfoPeriod = "1months";
                        }
                        if (chartPeriod == "3m")
                        {
                            blockChainInfoPeriod = "3months";
                        }
                        if (chartPeriod == "6m")
                        {
                            blockChainInfoPeriod = "6months";
                        }
                        if (chartPeriod == "1y")
                        {
                            blockChainInfoPeriod = "1years";
                        }
                        if (chartPeriod == "3y")
                        {
                            blockChainInfoPeriod = "3years";
                        }
                        if (chartPeriod == "all")
                        {
                            blockChainInfoPeriod = "all";
                        }
                        var response = await client.GetAsync($"charts/n-unique-addresses?timespan=" + blockChainInfoPeriod + "&format=json");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region utxo chart
        public class UTXOList
        {
            public string X { get; set; }
            public decimal Y { get; set; }
        }

        public class UTXODataService
        {
            public async Task<string> GetUTXODataAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.blockchain.info/");
                        string blockChainInfoPeriod = "";
                        if (chartPeriod == "1m")
                        {
                            blockChainInfoPeriod = "1months";
                        }
                        if (chartPeriod == "3m")
                        {
                            blockChainInfoPeriod = "3months";
                        }
                        if (chartPeriod == "6m")
                        {
                            blockChainInfoPeriod = "6months";
                        }
                        if (chartPeriod == "1y")
                        {
                            blockChainInfoPeriod = "1years";
                        }
                        if (chartPeriod == "3y")
                        {
                            blockChainInfoPeriod = "3years";
                        }
                        if (chartPeriod == "all")
                        {
                            blockChainInfoPeriod = "all";
                        }
                        var response = await client.GetAsync($"charts/utxo-count?timespan=" + blockChainInfoPeriod + "&format=json");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region pools ranking chart
        public class PoolsRanking
        {
           // public string PoolId { get; set; } 
            public string Name { get; set; }
            //public string Link { get; set; }
            public string BlockCount { get; set; }
            //public string Rank { get; set; }
            //public string EmptyBlocks { get; set; }
            //public string Slug { get; set; }
            //public string AvgMatchRate { get; set; }
        }

        public class PoolsRankingDataService
        {
            private readonly string _nodeUrl;
            public PoolsRankingDataService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetPoolsRankingDataAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/mining/pools/" + chartPeriod);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region nodes per network, channels and capacity charts
        public class NodesPerNetworkAndCapacity
        {
            public string Added { get; set; }
            public double Channel_count { get; set; }
            public double Total_capacity { get; set; }
            public double Tor_nodes { get; set; }
            public double Clearnet_nodes { get; set; }
            public double Unannounced_nodes { get; set; }
            public double Clearnet_tor_nodes { get; set; }
        }

        public class NodesPerNetworkAndCapacityDataService
        {
            private readonly string _nodeUrl;
            public NodesPerNetworkAndCapacityDataService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetNodesPerNetworkAndCapacityAsync(string chartPeriod)
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/lightning/statistics/" + chartPeriod);
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }
        #endregion
        #region nodes by country chart
        public class CountryName 
        {
            public string En { get; set; }
        }

        public class LightningNodeCountry
        {
            public CountryName Name { get; set; }
         //   public string Iso { get; set; }
            public decimal Count { get; set; }
         //   public decimal Share { get; set; }
         //   public decimal? Capacity { get; set; } // Nullable decimal
        }

        public class LightningNodesByCountryService
        {
            private readonly string _nodeUrl;
            public LightningNodesByCountryService(string nodeUrl)
            {
                _nodeUrl = nodeUrl;
            }
            public async Task<string> GetLightningNodesByCountryAsync()
            {
                int retryCount = 3;
                while (retryCount > 0)
                {
                    using var client = new HttpClient();
                    try
                    {
                        client.BaseAddress = new Uri(_nodeUrl);
                        var response = await client.GetAsync($"v1/lightning/nodes/countries");
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        retryCount--;
                        await Task.Delay(3000);
                    }
                    catch (HttpRequestException)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
                return string.Empty;
            }
        }


        #endregion

        #endregion

        #endregion
    }
}