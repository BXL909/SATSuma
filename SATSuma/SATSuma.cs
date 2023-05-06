﻿/*  
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣴⣶⣾⣿⣿⣿⣿⣷⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀  _____      _______ _____                       
⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣄⠀⠀⠀⠀⠀  ⠀ / ____|  /\|__   __/ ____|                      
⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀ ⠀ ⠀| (___   /  \  | | | (___  _   _ _ __ ___   __ _ 
⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠟⠿⠿⡿⠀⢰⣿⠁⢈⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀   ⠀ \___ \ / /\ \ | |  \___ \| | | | '_ ` _ \ / _` |
⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣤⣄⠀⠀⠀⠈⠉⠀⠸⠿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀  ⠀ ____) / ____ \| |  ____) | |_| | | | | | | (_| |
⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⢠⣶⣶⣤⡀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⡆  ⠀|_____/_/    \_\_| |_____/ \__,_|_| |_| |_|\__,_| 
⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠼⣿⣿⡿⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣷   A Bitcoin explorer, Xpub viewer, bitcoin & lightning
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⢀⣀⣀⠀⠀⠀⠀⢴⣿⣿⣿⣿⣿⣿⣿⣿⣿   dashboard with the ability to create encryted 
⢿⣿⣿⣿⣿⣿⣿⣿⢿⣿⠁⠀⠀⣼⣿⣿⣿⣦⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⡿   bookmarks and notes for addresses, blocks, xpubs and
⠸⣿⣿⣿⣿⣿⣿⣏⠀⠀⠀⠀⠀⠛⠛⠿⠟⠋⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⠇   transactions. Xpub queries will only work on the 
⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⣤⡄⠀⣀⣀⣀⣀⣠⣾⣿⣿⣿⣿⣿⣿⣿⡟⠀   user's own node. Keys to unlock encrypted bookmarks
⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣄⣰⣿⠁⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠀⠀   are not stored anywhere and are uncrecoverable. The
⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀   bookmarks file is bookmarks.json, in the installation
⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀   directory.
⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⠿⢿⣿⣿⣿⣿⡿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀

Version history 🍊
0.7 this work in progress

 * Stuff to do:
 * further work on own node connection outside of the xpub screen (pretty broken right now! connects and works, but the local mempool.space installation returns different numbers of records in api calls)
 * handle tabbing and focus better
 * check paging when reaching the end of the block list (block 0) then pressing previous. It should work the same way as transactions work on the block screen
 * Taproot support on xpub screen
 * sorting of bookmarks?
 * find P2SH xpub to test with
 */

#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using NBitcoin;
using QRCoder;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Reflection;
using Panel = System.Windows.Forms.Panel;
using Control = System.Windows.Forms.Control;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

#endregion

namespace SATSuma
{
    public partial class SATSuma : Form
    {
        #region INITIALISE
        //=============================================================================================================
        //---------------------------INITIALISE------------------------------------------------------------------------
        private int intDisplayCountdownToRefresh = 0; // countdown in seconds to next refresh, for display only
        private int intAPIGroup1TimerIntervalMillisecsConstant = 60000; // milliseconds, used to reset the interval of the timer for api refreshes
        private int APIGroup1DisplayTimerIntervalSecsConstant = 60; // seconds, used to reset the countdown display to its original number
        // booleans used to say whether to run individual API's or not. All on/true by default.
        private bool RunBitcoinExplorerEndpointAPI = true;
        private bool RunBlockchainInfoEndpointAPI = true;
        private bool RunBitcoinExplorerOrgJSONAPI = true;
        private bool RunBlockchairComJSONAPI = true;
        private bool RunMempoolSpaceLightningAPI = true;
        private string NodeURL = "https://mempool.space/api/"; // default value. Can be changed by user.
        private int intDisplaySecondsElapsedSinceUpdate = 0; // used to count seconds since the data was last refreshed, for display only.
        private bool ObtainedHalvingSecondsRemainingYet = false; // used to check whether we know halvening seconds before we start trying to subtract from them
        private int APIRefreshFrequency = 1; // mins. Default value 1. Initial value only
        private TransactionsForAddressService _transactionsForAddressService;
        private TransactionsForXpubAddressService _transactionsForXpubAddressService;
        private BlockDataService _blockService;
        private TransactionService _transactionService;
        private TransactionsForBlockService _transactionsForBlockService;
        private int TotalAddressTransactionRowsAdded = 0; // keeps track of how many rows of Address transactions have been added to the listview
        private int TotalBlockTransactionRowsAdded = 0; // keeps track of how many rows of Block transactions have been added to the listview
        private string addressScreenConfUnconfOrAllTx = ""; // used to keep track of whether we're doing transactions requests for conf, unconf, or all transactions
        private string storedLastSeenBlockNumber = "0";
        private readonly List<Point> linePoints = new List<Point>(); // used to store coordinates for all the lines on the transaction screen
        bool PartOfAnAllAddressTransactionsRequest = false; // 'all' transactions use an 'all' api for the first call, but afterwards mempoolConforAllTx is set to chain for remaining (confirmed) txs. This is used to keep headings, etc consistent
        //following bools are used to remember enabled state of buttons to reset them after disabling all during loading
        bool btnShowAllAddressTXWasEnabled = true;
        bool btnShowConfirmedAddressTXWasEnabled = false;
        bool btnShowUnconfirmedAddressTXWasEnabled = true;
        bool btnFirstAddressTransactionWasEnabled = false;
        bool btnNextAddressTransactionsWasEnabled = false;
        bool BtnViewTransactionFromAddressWasEnabled = false;
        bool BtnViewBlockFromAddressWasEnabled = false;
        bool btnViewBlockFromBlockListWasEnabled = false;
        bool btnPreviousBlockTransactionsWasEnabled = false;
        bool btnNextBlockTransactionsWasEnabled = false;
        bool textBoxSubmittedBlockNumberWasEnabled = true;
        bool textBoxSubmittedAddressWasEnabled = true;
        bool btnNextBlockWasEnabled = false;
        bool btnPreviousBlockWasEnabled = true;
        bool btnNewer15BlocksWasEnabled = false;
        bool btnOlder15BlocksWasEnabled = true;
        bool textBoxBlockHeightToStartListFromWasEnabled = true;
        bool xpubNodeURLAlreadySavedInFile = false; // keeps track of whether an xpub node URL is already saved
        string xpubNodeURLInFile = ""; // stores the xpub node URL from the file to check whether a newly supplied one is different, in which case we'll update the file
        bool nodeURLAlreadySavedInFile = false; // keeps track of whether a node URL is already saved
        string nodeURLInFile = ""; // stores the node URL from the file to check whether a newly supplied one is different, in which case we'll update the file
        bool settingsAlreadySavedInFile = false; // keeps track of whether settings are already saved
        string settingsInFile = ""; // stores the settings from the file to check whether any have changed, in which case we'll update the file

        bool defaultThemeAlreadySavedInFile = false; // keeps track of whether a default theme is already saved
        string defaultThemeInFile = ""; // stores the default theme from the file to check whether a newly supplied one is different, in which case we'll update the file
        private int TransactionOutputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private int TransactionInputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private int XpubAddressesScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private int bookmarksScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        readonly Color subItemBackColor = Color.FromArgb(21, 21, 21);
        Color linesColor = Color.FromArgb(106, 72, 9);
        Color titleBackgroundColor = Color.FromArgb(0, 0, 0);
        Color listViewHeaderColor = Color.FromArgb(50, 50, 50);
        Color listViewHeaderTextColor = Color.Silver;
        Color tableTextColor = Color.FromArgb(255, 153, 0);
        bool testNet = false;

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

        private void Form1_Load(object sender, EventArgs e) 
        {
            try
            {
                var bookmarks = ReadBookmarksFromJsonFile();
                // check if settings are already saved in the bookmarks file and either restore them or set defaults and save a settings entry in bookmarks file
                foreach (var bookmark in bookmarks)
                {
                    if (bookmark.Type == "settings")
                    {
                        settingsAlreadySavedInFile = true;
                        settingsInFile = bookmark.Data;
                        if (Convert.ToString(bookmark.Data[0]) == "P")
                        {
                            //GBP
                            btnGBP.Enabled = false;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = true;
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "D")
                        {
                            //USD
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = false;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = true;
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "E")
                        {
                            //EUR
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = false;
                            btnXAU.Enabled = true;
                        }
                        if (Convert.ToString(bookmark.Data[0]) == "G")
                        {
                            //XAU
                            btnGBP.Enabled = true;
                            btnUSD.Enabled = true;
                            btnEUR.Enabled = true;
                            btnXAU.Enabled = false;
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "M")
                        {
                            //mainnet
                            NodeURL = "https://mempool.space/api/";
                            CreateDataServices();
                            lblSettingsNodeMainnet.Text = "✔️";
                            lblSettingsNodeMainnet.ForeColor = Color.Green;
                            lblSettingsNodeTestnet.Text = "❌";
                            lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                            lblSettingsNodeCustom.Text = "❌";
                            lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "T")
                        {
                            //testnet
                            NodeURL = "https://mempool.space/testnet/api/";
                            CreateDataServices();
                            lblSettingsNodeMainnet.Text = "❌";
                            lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                            lblSettingsNodeTestnet.Text = "✔️";
                            lblSettingsNodeTestnet.ForeColor = Color.Green;
                            lblSettingsNodeCustom.Text = "❌";
                            lblSettingsNodeCustom.ForeColor = Color.IndianRed;
                        }
                        if (Convert.ToString(bookmark.Data[1]) == "C")
                        {
                            //custom
////////////////////////////////////////////////////////////////////////////////////// still need to set and test this
                            CreateDataServices();
                            lblSettingsNodeMainnet.Text = "❌";
                            lblSettingsNodeMainnet.ForeColor = Color.IndianRed;
                            lblSettingsNodeTestnet.Text = "❌";
                            lblSettingsNodeTestnet.ForeColor = Color.IndianRed;
                            lblSettingsNodeCustom.Text = "✔️";
                            lblSettingsNodeCustom.ForeColor = Color.Green;
                        }
                        if (Convert.ToString(bookmark.Data[2]) == "1")
                        {
                            RunBlockchairComJSONAPI = true;
                            lblBlockchairComJSON.Text = "✔️";
                            lblBlockchairComJSON.ForeColor = Color.Green;
                        }
                        else
                        {
                            RunBlockchairComJSONAPI = false;
                            lblBlockchairComJSON.Text = "❌";
                            lblBlockchairComJSON.ForeColor = Color.IndianRed;
                        }
                        if (Convert.ToString(bookmark.Data[3]) == "1")
                        {
                            RunBitcoinExplorerEndpointAPI = true;
                            RunBitcoinExplorerOrgJSONAPI = true;
                            lblBitcoinExplorerEndpoints.Text = "✔️";
                            lblBitcoinExplorerEndpoints.ForeColor = Color.Green;
                        }
                        else
                        {
                            RunBitcoinExplorerEndpointAPI = false;
                            RunBitcoinExplorerOrgJSONAPI = false;
                            lblBitcoinExplorerEndpoints.Text = "❌";
                            lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                        }
                        if (Convert.ToString(bookmark.Data[4]) == "1")
                        {
                            RunBlockchainInfoEndpointAPI = true;
                            lblBlockchainInfoEndpoints.Text = "✔️";
                            lblBlockchainInfoEndpoints.ForeColor = Color.Green;
                        }
                        else
                        {
                            RunBlockchainInfoEndpointAPI = false;
                            lblBlockchainInfoEndpoints.Text = "❌";
                            lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                        }
                        if (Convert.ToString(bookmark.Data[5]) == "1")
                        {
                            lblBitcoinDashboard.Text = "✔️";
                            lblBitcoinDashboard.ForeColor = Color.Green;
                            lblBlockchairComJSON.Enabled = true;
                            lblBitcoinExplorerEndpoints.Enabled = true;
                            lblBlockchainInfoEndpoints.Enabled = true;
                            btnMenuBitcoinDashboard.Enabled = true;
                        }
                        else
                        {
                            lblBitcoinDashboard.Text = "❌";
                            lblBitcoinDashboard.ForeColor = Color.IndianRed;
                            RunBlockchairComJSONAPI = false;
                            lblBlockchairComJSON.Text = "❌";
                            lblBlockchairComJSON.Enabled = false;
                            lblBlockchairComJSON.ForeColor = Color.IndianRed;
                            RunBitcoinExplorerEndpointAPI = false;
                            RunBitcoinExplorerOrgJSONAPI = false;
                            lblBitcoinExplorerEndpoints.Text = "❌";
                            lblBitcoinExplorerEndpoints.Enabled = false;
                            lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                            RunBlockchainInfoEndpointAPI = false;
                            lblBlockchainInfoEndpoints.Text = "❌";
                            lblBlockchainInfoEndpoints.Enabled = false;
                            lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                            btnMenuBitcoinDashboard.Enabled = false;
                        }
                        if (Convert.ToString(bookmark.Data[6]) == "1")
                        {
                            lblLightningDashboard.Text = "✔️";
                            lblLightningDashboard.ForeColor = Color.Green;
                            RunMempoolSpaceLightningAPI = true;
                            lblMempoolLightningJSON.Text = "✔️";
                            lblMempoolLightningJSON.Enabled = true;
                            lblMempoolLightningJSON.ForeColor = Color.Green;
                            btnMenuLightningDashboard.Enabled = true;
                        }
                        else
                        {
                            lblLightningDashboard.Text = "❌";
                            lblLightningDashboard.ForeColor = Color.IndianRed;
                            RunMempoolSpaceLightningAPI = false;
                            lblMempoolLightningJSON.Text = "❌";
                            lblMempoolLightningJSON.Enabled = false;
                            lblMempoolLightningJSON.ForeColor = Color.IndianRed;
                            btnMenuLightningDashboard.Enabled = false;
                        }
                        if (Convert.ToString(bookmark.Data[7]) == "1")
                        {
                            lblMempoolLightningJSON.Text = "✔️";
                            lblMempoolLightningJSON.Enabled = true;
                            lblMempoolLightningJSON.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblMempoolLightningJSON.Text = "❌";
                            lblMempoolLightningJSON.Enabled = false;
                            lblMempoolLightningJSON.ForeColor = Color.IndianRed;
                        }
                        numericUpDownDashboardRefresh.Value = Convert.ToInt32(bookmark.Data.Substring(8, 4));
                        
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
                        textBoxXpubNodeURL.Text = bookmark.Data; // move node url string to the form
                        textBoxSettingsXpubMempoolURL.Text = bookmark.Data; // and to the settings screen
                        CheckXpubNodeIsOnline();
                        xpubNodeURLInFile = bookmark.Data;
                        xpubNodeURLAlreadySavedInFile = true;
                        break;
                    }
                    xpubNodeURLAlreadySavedInFile = false;
                }

                CheckNetworkStatus();
                GetBlockTip();



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
                                RestoreTheme(theme);
                                defaultThemeInFile = bookmark.Data;
                                defaultThemeAlreadySavedInFile = true;
                                break;
                            }
                        }
                    }
                }

                UpdateBitcoinAndLightningDashboards(); // setting them now avoids waiting a whole minute for the first refresh
                StartTheClocksTicking(); // start all the timers
                //setup block list screen
                textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text;
                LookupBlockList(); // fetch the first 15 blocks automatically for the initial view.
                //setup address screen
                AddressInvalidHideControls(); // initially address textbox is empty so hide the controls
                CheckNetworkStatus();
                addressScreenConfUnconfOrAllTx = "chain"; // valid values are chain, mempool or all
                btnShowConfirmedTX.Enabled = false; // already looking at confirmed transactions to start with
            }
            catch (WebException ex)
            {
                HandleException(ex, "Form1_Load");
            }
        }
        #endregion

        #region CLOCK TICK EVENTS
        //=============================================================================================================
        // -------------------------CLOCK TICKS------------------------------------------------------------------------
        private void StartTheClocksTicking()
        {
            APIRefreshFrequency = Convert.ToInt32(numericUpDownDashboardRefresh.Value);
            intDisplayCountdownToRefresh = (APIRefreshFrequency * 60); //turn minutes into seconds. This is the number used to display remaning time until refresh
            APIGroup1DisplayTimerIntervalSecsConstant = (APIRefreshFrequency * 60); //turn minutes into seconds. This is kept constant and used to reset the timer to this number
            intAPIGroup1TimerIntervalMillisecsConstant = ((APIRefreshFrequency * 60) * 1000); // turn minutes into seconds, then into milliseconds
            timerAPIRefreshPeriod.Interval = intAPIGroup1TimerIntervalMillisecsConstant; // set the timer interval
            timer1Sec.Start(); // timer used to refresh the clock values
            timerAPIRefreshPeriod.Start(); // used to trigger API refreshes
        }

        private void Timer1Sec_Tick(object sender, EventArgs e) // update the calendar time and date
        {
            UpdateOnScreenClock();
            UpdateOnScreenCountdownAndFlashLights();
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

            if (intDisplayCountdownToRefresh < 11) // when there are only 10 seconds left until the refresh, clear error alert symblol & error message
            {
                lblAlert.Invoke((MethodInvoker)delegate
                {
                    lblAlert.Text = "";
                });
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "";
                });
            }
        }

        private void TimerAPIRefreshPeriod_Tick(object sender, EventArgs e) // update the btc/lightning dashboard fields
        {
            try
            {
                ClearAlertAndErrorMessage(); // wipe anything that may be showing in the error area (it should be empty anyway)
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
                        HandleException(ex, "BlockchainInfoEndpointsRefresh");
                    }
                }
                UpdateBitcoinAndLightningDashboards(); // fetch data and populate fields
            }
            catch (WebException ex)
            {
                HandleException(ex, "TimerAPIRefreshPeriod_Tick");
            }
        }
        #endregion

        #region BITCOIN AND LIGHTNING DASHBOARD SCREENS
        //==============================================================================================================================================================================================
        //======================BITCOIN AND LIGHTNING DASHBOARD SPECIFIC STUFF==========================================================================================================================

        public async void UpdateBitcoinAndLightningDashboards()
        {
            ToggleLoadingAnimation("enable");

            using (WebClient client = new WebClient())
            {
                bool errorOccurred = false;

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
                            lblBlockSize.Invoke((MethodInvoker)delegate
                            {
                                lblBlockSize.Text = sizeString;
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
                        // move returned data to the labels on the form
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
                        // move returned data to the labels on the form
                        lblHeaderHashrate.Invoke((MethodInvoker)delegate
                        {
                            lblHeaderHashrate.Text = currentHashrate;
                        });
                        lblEstHashrate.Invoke((MethodInvoker)delegate
                        {
                            lblEstHashrate.Text = currentHashrate;
                        });
                        lblBlockListEstHashRate.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListEstHashRate.Text = currentHashrate;
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
                            lblProgressNextDiffAdjPercentage.Text = "(" + truncatedPercent + ")"; // update label with truncated value
                        });
                        lblBlockListProgressNextDiffAdjPercentage.Invoke((MethodInvoker)delegate //Block List
                        {
                            lblBlockListProgressNextDiffAdjPercentage.Text = "(" + truncatedPercent + ")"; // update label with truncated value
                        });
                        decimal progressValue = decimal.Parse(progressPercent); // convert to decimal and scale to range [0, 1]
                        progressBarNextDiffAdj.Value = Convert.ToInt16(progressValue); // scale to fit progress bar range
                        progressBarBlockListNextDiffAdj.Value = Convert.ToInt16(progressValue); // scale to fit progress bar range - Block List
                        lblDifficultyAdjEst.Invoke((MethodInvoker)delegate
                        {
                            lblDifficultyAdjEst.Text = difficultyChange + "%";
                        });
                        lblBlockListNextDifficultyAdjustment.Invoke((MethodInvoker)delegate  // (Blocks list)
                        {
                            lblBlockListNextDifficultyAdjustment.Text = difficultyChange + "%";
                        });
                        lblBlocksUntilDiffAdj.Invoke((MethodInvoker)delegate
                        {
                            lblBlocksUntilDiffAdj.Text = remainingBlocks.ToString();
                        });
                        long unixTimestamp = Convert.ToInt64(estimatedRetargetDate);
                        DateTime retargetDate = DateTimeExtensions.FromUnixTimeMilliseconds(unixTimestamp);
                        string formattedDate = retargetDate.ToString("yyyy-MM-dd");
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
                Task task1 = Task.Run(() =>  // bitcoinexplorer.org JSON for market data
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
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task1)");
                    }
                });
                Task task2 = Task.Run(() => // blockchain.info endpoints 
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
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task2)");
                    }
                });
                Task task3 = Task.Run(() => // Bitcoinexplorer.org JSON
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
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        HandleException(ex, "UpdateBitcoinAndLightningDashboards(Task3)");
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
                                var (aliases, channels) = MempoolSpaceConnectivityRankingJSONRefresh();
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

                await Task.WhenAll(task0, task1, task2, task3, task4, task5, task6);

                // If any errors occurred with any of the API calls, a decent error message has already been displayed. Now display the red light and generic error.
                if (errorOccurred)
                {
                    intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.ForeColor = Color.Red;
                    });
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.Text = "🔴"; // red light
                    });
                    lblRefreshSuccessOrFailMessage.Invoke((MethodInvoker)delegate
                    {
                        lblRefreshSuccessOrFailMessage.Text = "One or more fields failed to update";
                    });
                }
            }
            ToggleLoadingAnimation("disable");
        }

        //-----------------------BITCOIN AND LIGHTNING DASHBOARD API CALLS---------------------------------------------

        private (string currentHashrate, string currentDifficulty) GetHashrate()
        {
            try
            {
                using WebClient client = new WebClient();
                var response = client.DownloadString("https://mempool.space/api/v1/mining/hashrate/3d");
                if (testNet)
                {
                    response = client.DownloadString("https://mempool.space/testnet/api/v1/mining/hashrate/3d");
                }
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
                var response = client.DownloadString("https://mempool.space/api/v1/fees/recommended");
                if (testNet)
                {
                    response = client.DownloadString("https://mempool.space/testnet/api/v1/fees/recommended");
                }
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
                var response = client.DownloadString("https://mempool.space/api/v1/difficulty-adjustment");
                if (testNet)
                {
                    response = client.DownloadString("https://mempool.space/testnet/api/v1/difficulty-adjustment");
                }
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
                HandleException(ex, "BitcoinExplorerOrgGetPrice");
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
                var response = client.DownloadString("https://mempool.space/api/mempool");
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
                var response = client.DownloadString("https://mempool.space/api/v1/lightning/nodes/rankings/liquidity");
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
                var response = client.DownloadString("https://mempool.space/api/v1/lightning/nodes/rankings/connectivity");
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
                var response = client.DownloadString("https://mempool.space/api/v1/lightning/nodes/isp-ranking");
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
                var response = client.DownloadString("https://mempool.space/api/v1/lightning/statistics/latest");
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
                var txInNextBlock = (string)data2["txCount"]; //transaction count
                var nextBlockMinFee = (string)data2["minFeeRate"]; // minimum fee rate
                double valuetoround = Convert.ToDouble(nextBlockMinFee);
                double roundedValue = Math.Round(valuetoround, 2);
                nextBlockMinFee = Convert.ToString(roundedValue);
                var nextBlockMaxFee = (string)data2["maxFeeRate"]; // maximum fee rate
                valuetoround = Convert.ToDouble(nextBlockMaxFee);
                roundedValue = Math.Round(valuetoround, 2);
                nextBlockMaxFee = Convert.ToString(roundedValue);
                var nextBlockTotalFees = (string)data2["totalFees"]; // total fees
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

        //------------------------------------ CURRENCY --------------------------------------------------------------

        private void BtnUSD_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = false;
            btnEUR.Enabled = true;
            btnGBP.Enabled = true;
            btnXAU.Enabled = true;
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            GetMarketData();
            SaveSettingsToBookmarksFile();
        }

        private void BtnEUR_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = false;
            btnGBP.Enabled = true;
            btnXAU.Enabled = true;
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            GetMarketData();
            SaveSettingsToBookmarksFile();
        }

        private void BtnGBP_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = true;
            btnGBP.Enabled = false;
            btnXAU.Enabled = true;
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            GetMarketData();
            SaveSettingsToBookmarksFile();
        }

        private void BtnXAU_Click(object sender, EventArgs e)
        {
            btnUSD.Enabled = true;
            btnEUR.Enabled = true;
            btnGBP.Enabled = true;
            btnXAU.Enabled = false;
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            GetMarketData();
            SaveSettingsToBookmarksFile();
        }

        private void GetMarketData()
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
            lblMarketCapUSD.Invoke((MethodInvoker)delegate
            {
                lblMarketCapUSD.Text = mCap;
            });
            lblHeaderMarketCap.Invoke((MethodInvoker)delegate
            {
                lblHeaderMarketCap.Text = mCap;
            });
            lblMoscowTime.Invoke((MethodInvoker)delegate
            {
                lblMoscowTime.Text = satsPerUnit;
            });
            lblHeaderMoscowTime.Invoke((MethodInvoker)delegate
            {
                lblHeaderMoscowTime.Text = satsPerUnit;
            });
        }

        //---------------------- CONNECTING LINES BETWEEN FIELDS ON LIGHTNING DASHBOARD -------------------------------
        private void PanelLightningDashboard_Paint(object sender, PaintEventArgs e)
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
        #endregion

        #region ADDRESS SCREEN
        //==============================================================================================================================================================================================
        //======================== ADDRESS TAB =========================================================================================================================================================

        //---------------------- DETERMINE BITCOIN ADDRESS TYPE--------------------------------------------------------
        private string DetermineAddressType(string address)
        {
            try
            {
                NBitcoin.BitcoinAddress bitcoinAddress;
                if (NodeURL == "https://mempool.space/api/")
                {
                    bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.Main);
                }
                else
                {
                     bitcoinAddress = NBitcoin.BitcoinAddress.Create(address, Network.TestNet);
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

        //--------------- VALIDATE BITCOIN ADDRESS,GENERATE QR, BALANCE, TX, ETC---------------------------------------
        private async void TboxSubmittedAddress_TextChanged(object sender, EventArgs e)
        {
            BtnViewBlockFromAddress.Visible = false;
            BtnViewTransactionFromAddress.Visible = false;
            listViewAddressTransactions.Items.Clear(); // wipe any data in the transaction listview
            TotalAddressTransactionRowsAdded = 0;

            string addressString = textboxSubmittedAddress.Text; //user entered address
            string addressType = DetermineAddressType(addressString); // check address is valid and what type of address
            if (addressType == "P2PKH (legacy)" || addressType == "P2SH" || addressType == "P2WPKH (segwit)" || addressType == "P2WSH" || addressType == "P2TT (taproot)" || addressType == "unknown") // address is valid
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                AddressValidShowControls();
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
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
                string lastSeenTxId = ""; // start from the top of the JSON (most recent tx)
                try
                {
                    await GetTransactionsForAddress(addressString, lastSeenTxId); // get first batch of transactions
                }
                catch (Exception ex)
                {
                    HandleException(ex, "TboxSubmittedAddress_TextChanged (Error getting first batch of transactions for address)");
                    return;
                }
                DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
                ToggleLoadingAnimation("disable"); // stop the loading animation
            }
            else
            {
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

        //------------------------------------------ GET ADDRESS BALANCE-----------------------------------------------
        private async Task GetAddressBalance(string addressString)
        {
            try
            {
                var request = "address/" + addressString;
                var RequestURL = NodeURL + request;
                //var RequestURL = "http://umbrel.local:3006/api/" + request;
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
                string CurrentBlockHeightStringForCalc = client2.DownloadString("https://mempool.space/api/blocks/tip/height");

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

                    if (TotalAddressTransactionRowsAdded <= 25) // less than 25 transactions in all
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

                    if (counter == 25) // ListView is full. stop adding rows at this point and pick up from here next time.
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

        //------------------------ GET NEXT TRANSACTIONS FOR ADDRESS --------------------------------------------------
        private async void BtnGetNextTransactionsForAddress(object sender, EventArgs e)
        {
            ToggleLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
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
            DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
            ToggleLoadingAnimation("disable"); // stop the loading animation
            BtnViewBlockFromAddress.Visible = false;
            BtnViewTransactionFromAddress.Visible = false;
        }

        //------------------------ JUMP BACK TO FIRST TRANSACTION ------------------------------------------------------
        private async void BtnFirstTransactionForAddress_Click(object sender, EventArgs e)
        {
            ToggleLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            if (PartOfAnAllAddressTransactionsRequest) // if this was originally a list of 'all' TXs which switched to 'chain', switch back to 'all' to get the unconfirmed again first
            {
                addressScreenConfUnconfOrAllTx = "all";
            }
            btnFirstAddressTransaction.Visible = false;
            var address = textboxSubmittedAddress.Text; // Get the address from the address text box
            var lastSeenTxId = ""; // Reset the last seen transaction ID to go back to start
            TotalAddressTransactionRowsAdded = 0;
            btnNextAddressTransactions.Visible = true; // this time we know there's a next page (couldn't press first otherwise)
            BtnViewBlockFromAddress.Visible = false;
            BtnViewTransactionFromAddress.Visible = false;

            // Call the GetConfirmedTransactionsForAddress method with the updated lastSeenTxId
            await GetTransactionsForAddress(address, lastSeenTxId);
            DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
            ToggleLoadingAnimation("disable"); // stop the loading animation
        }

        //------------------------ SHOW TRANSACTIONS IN MEMPOOL ------------------------------------------------------
        private void BtnShowUnconfirmedTXForAddress_Click(object sender, EventArgs e)
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

        //------------------------ SHOW CONFIRMED TRANSACTIONS ------------------------------------------------------
        private void BtnShowConfirmedTXForAddress_Click(object sender, EventArgs e)
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

        //------------------------ SHOW CONFIRMED & UNCONFIRMED TRANSACTIONS -------------------------------------------
        private void BtnShowAllTXForAddress_Click(object sender, EventArgs e)
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

        //------------------------ VIEW THE BLOCK CONTAINING THIS TRANSACTION ------------------------------------------
        private void BtnViewBlockFromAddress_Click(object sender, EventArgs e)
        {
            //assign block number to text box on block panel
            // Get the selected item
            ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
            // Get the second subitem in the selected item 
            string submittedBlockNumber = selectedItem.SubItems[1].Text;
            // Set the text of the textBoxSubmittedBlockNumber control
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

        //------------------------ VIEW THIS TRANSACTION ------------------------------------------------------
        private void BtnViewTransactionFromAddress_Click(object sender, EventArgs e)
        {
            //assign TX ID to text box on transaction panel
            // Get the selected item
            ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
            // Get the first subitem in the selected item 
            string TransactionIDFromRow = selectedItem.SubItems[0].Text;
            // Set the text of the textBoxTransactionID control
            textBoxTransactionID.Invoke((MethodInvoker)delegate
            {
                textBoxTransactionID.Text = TransactionIDFromRow;
            });
            //show the transaction screen
            BtnMenuTransaction_Click(sender, e);
        }

        //------------------------ CHANGE COLOUR OF SELECTED ROW ------------------------------------------------------

        private void ListViewAddressTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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

        //-----DRAW AN ELLIPSIS WHEN STRINGS DONT FIT IN LISTVIEW COLUMN (ALSO COLOUR BALANCE DIFFERENCE RED/GREEN)----
        private void ListViewAddressTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        //------------------ LIMIT MINIMUM WIDTH OF ADDRESS LISTVIEW COLUMNS ------------------------------------------
        private void ListViewAddressTransactions_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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

        //------------------------ SHOW ALL THE ADDRESS CONTROLS ------------------------------------------------------
        private void AddressValidShowControls() // show all address related controls
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

        //------------------------ HIDE ALL THE ADDRESS CONTROLS ------------------------------------------------------
        private void AddressInvalidHideControls() // hide all address related controls
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

        private void PanelAddress_Paint(object sender, PaintEventArgs e)
        {
            textboxSubmittedAddress.Location = new Point(label58.Location.X + label58.Width, textboxSubmittedAddress.Location.Y);
            textboxSubmittedAddress.Width = panel35.Width - textboxSubmittedAddress.Location.X;
        }
        #endregion

        #region BLOCK SCREEN
        //==============================================================================================================================================================================================
        //====================== BLOCK SCREEN STUFF ====================================================================================================================================================

        //-------------------- PREVENT ANYTHING OTHER THAN NUMERICS IN BLOCK TEXTBOX ----------------------------------
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

                var blockNumber = Convert.ToString(textBoxSubmittedBlockNumber.Text);
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                await GetFifteenBlocks(blockNumber);
                string BlockHashToGetTransactionsFor = lblBlockHash.Text;
                await GetTransactionsForBlock(BlockHashToGetTransactionsFor, "0");
                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableButtons("enable"); // enable buttons after operation is complete
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
                var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
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
                lblBlockFeeRangeAndMedianFee.Invoke((MethodInvoker)delegate
                {
                    lblBlockFeeRangeAndMedianFee.Text = Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[0])) + "-" + Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[6])) + " / " + Convert.ToString(Convert.ToInt32(blocks[0].Extras.MedianFee));
                });
                lblBlockAverageFee.Invoke((MethodInvoker)delegate
                {
                    lblBlockAverageFee.Text = Convert.ToString(blocks[0].Extras.AvgFee);
                });
                lblMiner.Invoke((MethodInvoker)delegate
                {
                    lblMiner.Text = Convert.ToString(blocks[0].Extras.Pool.Name);
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
                var BlockTransactionsJson = await _transactionsForBlockService.GetTransactionsForBlockAsync(blockHash, lastSeenBlockTransaction);
                var transactions = JsonConvert.DeserializeObject<List<Block_Transactions>>(BlockTransactionsJson);
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

                    if (TotalBlockTransactionRowsAdded <= 25) // we must still be on first results so there are no previous
                    {
                        btnPreviousBlockTransactions.Visible = false; // so this won't be needed
                    }
                    else
                    {
                        btnPreviousBlockTransactions.Visible = true;
                    }

                    if (Convert.ToString(TotalBlockTransactionRowsAdded) == lblNumberOfTXInBlock.Text) // we've shown all the TXs
                    {
                        btnNextBlockTransactions.Visible = false; // so we won't need this
                    }
                    else
                    {
                        btnNextBlockTransactions.Visible = true;
                    }

                    if (counter == 25) // ListView is full. stop adding rows at this point and pick up from here...
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

        //------------------------ GET NEXT BATCH OF TRANSACTIONS FOR BLOCK -------------------------------------------
        private async void BtnNextBlockTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
                                                   // Get the last seen transaction ID from the list view
                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                                                                                                 // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction);
                DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
                ToggleLoadingAnimation("disable"); // stop the loading animation
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
                ToggleLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again

                if (TotalBlockTransactionRowsAdded % 25 == 0) // API expects last seen transaction to be a multiple of 25. If it is we can just subtract 50 for the prev page
                {
                    TotalBlockTransactionRowsAdded -= 50;
                }
                else // otherwise we subtract the odd amount (only happens at end of list) and another 25 to be able to go back to the previous page.
                {
                    int closestMultipleOf25 = TotalBlockTransactionRowsAdded - (TotalBlockTransactionRowsAdded % 25);
                    int firstNumberBeforeIt = closestMultipleOf25 - 25;
                    TotalBlockTransactionRowsAdded = firstNumberBeforeIt;
                }

                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                                                                                                 // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction);
                DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
                ToggleLoadingAnimation("disable"); // stop the loading animation
                btnViewTransactionFromBlock.Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnPreviousBlockTransactions_Click");
            }
        }

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

        //------------------------ FORMAT DATA WHILE DRAWING LISTVIEW ------------------------------------------------------
        private void ListViewBlockTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        //------------------------ GO TO THE TRANSACTION SCREEN ----------------------------------------------------------
        private void BtnViewTransactionFromBlock_Click(object sender, EventArgs e)
        {
            try
            {
                //assign TX ID to text box on transaction panel
                // Get the selected item
                ListViewItem selectedItem = listViewBlockTransactions.SelectedItems[0];
                // Get the first subitem in the selected item 
                string TransactionIDFromRow = selectedItem.SubItems[0].Text;
                // Set the text of the textBoxTransactionID control
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

        #region TRANSACTION SCREEN
        //==============================================================================================================================================================================================
        //====================== TRANSACTION SCREEN STUFF ==============================================================================================================================================

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
            string transactionIdToValidate = textBoxTransactionID.Text;
            if (ValidateTransactionId(transactionIdToValidate)) // check if the entered string is valid
            {
                bool exists = await TransactionExists(transactionIdToValidate); // then check if it actually exists
                if (exists)
                {
                    lblInvalidTransaction.Visible = false;
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
                    lblInvalidTransaction.Visible = true;
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
                lblInvalidTransaction.Visible = true;
            }
        }

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
            string url = NodeURL + "tx/" + transactionId;
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return response.IsSuccessStatusCode;
        }

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
                // DisableEnableLoadingAnimation("enable"); // start the loading animation
                // DisableEnableButtons("disable"); // disable buttons during operation
                var TransactionJson = await _transactionService.GetTransactionAsync(submittedTransactionID);
                // DisableEnableLoadingAnimation("disable"); // stop the loading animation
                // DisableEnableButtons("enable"); // enable buttons after operation is complete
                var transaction = JsonConvert.DeserializeObject<Transaction>(TransactionJson);
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
                // Get the height of each item to set height of whole listview
                int rowHeightout = listViewTransactionOutputs.Margin.Vertical + listViewTransactionOutputs.Padding.Vertical + listViewTransactionOutputs.GetItemRect(0).Height;
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
                        //item.ForeColor = Color.White; // address
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

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTHS ----------------------------------------------
        private void ListViewTransactionOutputs_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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

        //-------------------- FORMAT DATA WHILE DRAWING LISTVIEW ----------------------------------------------
        private void ListViewTransactionInputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        //-------------------- FORMAT DATA WHILE DRAWING LISTVIEW ----------------------------------------------
        private void ListViewTransactionOutputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        //-------DRAW LINES ON TRANSACTION DIAGRAM FROM PREVIOUSLY STORED LIST-----------------------------------
        private void PanelTransactionDiagram_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(linesColor);

            // Iterate over the stored list of points and draw lines between them
            for (int i = 0; i < linePoints.Count - 1; i += 2)
            {
                e.Graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
            }
        }

        //-------------------- SCROLL-DOWN INPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionInputsDown_Click(object sender, EventArgs e)
        {
            if (panelTransactionInputs.VerticalScroll.Value < panelTransactionInputs.VerticalScroll.Maximum)
            {
                panelTransactionInputs.VerticalScroll.Value++;
            }
        }

        //-------------------- SCROLL-DOWN OUTPUTS CLICKED -----------------------------------------------------
        private void BtnTransactionOutputsDown_Click(object sender, EventArgs e)
        {
            if (panelTransactionOutputs.VerticalScroll.Value < panelTransactionOutputs.VerticalScroll.Maximum)
            {
                panelTransactionOutputs.VerticalScroll.Value++;
            }
        }

        private bool isInputButtonPressed = false;
        private bool InputDownButtonPressed = false;
        private bool InputUpButtonPressed = false;
        private bool isOutputButtonPressed = false;
        private bool OutputDownButtonPressed = false;
        private bool OutputUpButtonPressed = false;

        //-------------------- SCROLL-DOWN MOUSE-DOWN --------------------------------------------------------
        private void BtnTransactionInputsDown_MouseDown(object sender, MouseEventArgs e)
        {
            isInputButtonPressed = true;
            InputDownButtonPressed = true;
            TXInScrollTimer.Start();
        }

        private void BtnTransactionOutputsDown_MouseDown(object sender, MouseEventArgs e)
        {
            //scrollPosition = new Point(panel26.HorizontalScroll.Value, panel26.VerticalScroll.Value);
            isOutputButtonPressed = true;
            OutputDownButtonPressed = true;
            TXOutScrollTimer.Start();
        }

        //-------------------- SCROLL-DOWN MOUSE-UP-- --------------------------------------------------------
        private void BtnTransactionInputsDown_MouseUp(object sender, MouseEventArgs e)
        {
            isInputButtonPressed = false;
            InputDownButtonPressed = false;
            TXInScrollTimer.Stop();
            TXInScrollTimer.Interval = 50; // reset the interval to its original value
        }

        private void BtnTransactionOutputsDown_MouseUp(object sender, MouseEventArgs e)
        {
            isOutputButtonPressed = false;
            OutputDownButtonPressed = false;
            TXOutScrollTimer.Stop();
            TXOutScrollTimer.Interval = 50; // reset the interval to its original value
        }

        //-------------------- HANDLE THE ACTUAL SCROLLING --------------------------------------------------
        private void TXInTimer_Tick(object sender, EventArgs e)
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

        private void TXOutTimer_Tick(object sender, EventArgs e)
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

        //-------------------- SCROLL-UP INPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionInputsUp_Click(object sender, EventArgs e)
        {
            if (panelTransactionInputs.VerticalScroll.Value > panelTransactionInputs.VerticalScroll.Minimum)
            {
                panelTransactionInputs.VerticalScroll.Value--;
            }
        }

        //-------------------- SCROLL-UP OUTPUTS CLICKED -------------------------------------------------------
        private void BtnTransactionOutputsUp_Click(object sender, EventArgs e)
        {
            if (panelTransactionOutputs.VerticalScroll.Value > panelTransactionOutputs.VerticalScroll.Minimum)
            {
                panelTransactionOutputs.VerticalScroll.Value--;
            }
        }

        //-------------------- SCROLL-UP MOUSE-DOWN -------------------------------------------------------
        private void BtnTransactionInputsUp_MouseDown(object sender, MouseEventArgs e)
        {
            isInputButtonPressed = true;
            InputUpButtonPressed = true;
            TXInScrollTimer.Start();
        }

        private void BtnTransactionOutputsUp_MouseDown(object sender, MouseEventArgs e)
        {
            isOutputButtonPressed = true;
            OutputUpButtonPressed = true;
            TXOutScrollTimer.Start();
        }

        //-------------------- SCROLL-UP MOUSE-UP -------------------------------------------------------
        private void BtnTransactionInputsUp_MouseUp(object sender, MouseEventArgs e)
        {
            isInputButtonPressed = false;
            InputUpButtonPressed = false;
            TXInScrollTimer.Stop();
            TXInScrollTimer.Interval = 50; // reset the interval to its original value
        }

        private void BtnTransactionOutputsUp_MouseUp(object sender, MouseEventArgs e)
        {
            isOutputButtonPressed = false;
            OutputUpButtonPressed = false;
            TXOutScrollTimer.Stop();
            TXOutScrollTimer.Interval = 50; // reset the interval to its original value
        }

        //-------------------- VIEW ADDRESS ------------------------------------------------------------
        private void BtnViewAddressFromTXInput_Click(object sender, EventArgs e)
        {
            try
            {
                //assign address to text box on address panel
                // Get the selected item
                ListViewItem selectedItem = listViewTransactionInputs.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress;
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
                //assign address to text box on address panel
                // Get the selected item
                ListViewItem selectedItem = listViewTransactionOutputs.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress;
                });
                //show the address screen
                BtnMenuAddress_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnViewAddressFromTXOutput_Click");
            }
        }

        //-------------------- PREVENT LIST-VIEW FROM JUMPING TO TOP WHEN PAINTED ------------------------
        private void PanelTransactionInputs_Paint(object sender, PaintEventArgs e)
        {
            if (btnViewAddressFromTXInput.Visible) // user must have clicked a row given that the button is visible
            {
                panelTransactionInputs.VerticalScroll.Value = TransactionInputsScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
            }
        }

        private void PanelTransactionOutputs_Paint(object sender, PaintEventArgs e)
        {
            if (btnViewAddressFromTXOutput.Visible) // user must have clicked a row given that the button is visible
            {
                panelTransactionOutputs.VerticalScroll.Value = TransactionOutputsScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
            }
        }
        #endregion

        #region BLOCK LIST SCREEN
        //==============================================================================================================================================================================================
        //====================== BLOCK LIST SCREEN STUFF ==============================================================================================================================================

        //-------------------- VALIDATE BLOCK LIST HEIGHT TO START LIST FROM ------------------------------------------------
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
                    //DisableEnableLoadingAnimation("enable"); // start the loading animation
                    //DisableEnableButtons("disable"); // disable buttons during operation
                    LookupBlockList();
                    //DisableEnableLoadingAnimation("disable"); // stop the loading animation
                    //DisableEnableButtons("enable"); // enable buttons after operation is complete
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
                HandleException(ex, "TextBoxBlockHeightToStartListFrom_KeyPress");
            }
        }

        private void TextBoxBlockHeightToStartListFrom_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
            {
                textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                {
                    textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text;
                });
            }
        }

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
                DisableEnableButtons("disable"); // disable buttons during operation

                var blocksJson = await _blockService.GetBlockDataAsync(lastSeenBlockNumber);

                ToggleLoadingAnimation("disable"); // stop the loading animation
                DisableEnableButtons("enable"); // enable buttons after operation is complete

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

                foreach (var block in blocks)
                {
                    long unixTimestamp = Convert.ToInt64(block.Timestamp);
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
                    string formattedDateTime = dateTime.ToString("yyyyMMdd-HH:mm");
                    ListViewItem item = new ListViewItem(formattedDateTime); // create new row
                    item.SubItems.Add(block.Height.ToString());
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
                        btnNewer15Blocks.Visible = false; // so this won't be needed
                    }
                    else
                    {
                        btnNewer15Blocks.Visible = true;
                    }

                    if (counter > 1 && blocklist.Last() == "0") // we've reached the Genesis Block (bottom of the list)
                    {
                        btnOlder15Blocks.Visible = false; // so we won't need this
                    }
                    else
                    {
                        btnOlder15Blocks.Visible = true;
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

        private void ListViewBlockList_SelectedIndexChanged(object sender, EventArgs e)
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
                                lblBlockListBlockHash.Location = new Point(label90.Location.X + label90.Width, label90.Location.Y);
                            });
                        }
                        string blockNumber = item.SubItems[1].Text;
                        //DisableEnableLoadingAnimation("enable"); // start the loading animation
                        //DisableEnableButtons("disable"); // disable buttons during operation
                        var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                        //DisableEnableLoadingAnimation("disable"); // stop the loading animation
                        //DisableEnableButtons("enable"); // enable buttons after operation is complete
                        var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                        List<string> blocklist = blocks.Select(t => t.Height).ToList();
                        lblBlockListBlockTime.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].Timestamp)).ToString("yyyy-MM-dd HH:mm");
                            lblBlockListBlockTime.Location = new Point(label91.Location.X + label91.Width, label91.Location.Y);
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
                            lblBlockListBlockSize.Location = new Point(label105.Location.X + label105.Width, label105.Location.Y);
                        });
                        string strWeight = Convert.ToString(blocks[0].Weight);
                        decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
                        string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
                        lblBlockListBlockWeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockWeight.Text = strFormattedWeight;
                            lblBlockListBlockWeight.Location = new Point(label103.Location.X + label103.Width, label103.Location.Y);
                        });
                        long nonceLong = Convert.ToInt64(blocks[0].Nonce);
                        lblBlockListNonce.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListNonce.Text = "0x" + nonceLong.ToString("X");
                            lblBlockListNonce.Location = new Point(label24.Location.X + label24.Width, label24.Location.Y);
                        });
                        lblBlockListMiner.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListMiner.Text = Convert.ToString(blocks[0].Extras.Pool.Name);
                            lblBlockListMiner.Location = new Point(label95.Location.X + label95.Width, label95.Location.Y);
                        });
                        lblBlockListTransactionCount.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTransactionCount.Text = Convert.ToString(blocks[0].Tx_count);
                            lblBlockListTransactionCount.Location = new Point(label99.Location.X + label99.Width, label99.Location.Y);
                        });
                        string TotalBlockFees = Convert.ToString(blocks[0].Extras.TotalFees);
                        TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
                        lblBlockListTotalFees.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalFees.Text = TotalBlockFees;
                            lblBlockListTotalFees.Location = new Point(label88.Location.X + label88.Width, label88.Location.Y);
                        });
                        string Reward = Convert.ToString(blocks[0].Extras.Reward);
                        lblBlockListReward.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
                            lblBlockListReward.Location = new Point(label101.Location.X + label101.Width, label101.Location.Y);
                        });
                        lblBlockListBlockFeeRangeAndMedianFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockFeeRangeAndMedianFee.Text = Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[0])) + "-" + Convert.ToString(Convert.ToInt32(blocks[0].Extras.FeeRange[6])) + " / " + Convert.ToString(Convert.ToInt32(blocks[0].Extras.MedianFee));
                            lblBlockListBlockFeeRangeAndMedianFee.Location = new Point(label93.Location.X + label93.Width, label93.Location.Y);
                        });
                        lblBlockListAverageFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageFee.Text = Convert.ToString(blocks[0].Extras.AvgFee);
                            lblBlockListAverageFee.Location = new Point(label97.Location.X + label97.Width, label97.Location.Y);
                        });
                        lblBlockListTotalInputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalInputs.Text = Convert.ToString(blocks[0].Extras.TotalInputs);
                            lblBlockListTotalInputs.Location = new Point(label89.Location.X + label89.Width, label89.Location.Y);
                        });
                        lblBlockListTotalOutputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalOutputs.Text = Convert.ToString(blocks[0].Extras.TotalOutputs);
                            lblBlockListTotalOutputs.Location = new Point(label94.Location.X + label94.Width, label94.Location.Y);
                        });
                        lblBlockListAverageTransactionSize.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageTransactionSize.Text = Convert.ToString(blocks[0].Extras.AvgTxSize);
                            lblBlockListAverageTransactionSize.Location = new Point(label92.Location.X + label92.Width, label92.Location.Y);
                        });
                        lblBlockListVersion.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListVersion.Text = Convert.ToString(blocks[0].Version);
                            lblBlockListVersion.Location = new Point(label96.Location.X + label96.Width, label96.Location.Y);
                        });
                        lblBlockListBlockHeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockHeight.Text = "Block height: " + Convert.ToString(blocks[0].Height);
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

        //-------------------- VIEW INDIVIDUAL BLOCK ------------------------------------------------------------------------
        private void BtnViewBlockFromBlockList_Click(object sender, EventArgs e)  
        {
            try
            {
                //assign block number to text box on block panel
                // Get the selected item
                ListViewItem selectedItem = listViewBlockList.SelectedItems[0];
                // Get the second subitem in the selected item (index 1)
                string submittedBlockNumber = selectedItem.SubItems[1].Text;
                // Set the text of the textBoxSubmittedBlockNumber control
                textBoxSubmittedBlockNumber.Invoke((MethodInvoker)delegate
                {
                    textBoxSubmittedBlockNumber.Text = submittedBlockNumber;
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

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTH -----------------------------------------------------------
        private void ListViewBlockList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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

        ////-------------------- FORMAT THE DATA IN THE LISTVIEW ------------------------------------------------------------
        private void ListViewBlockList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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
        #endregion

        #region XPUB SCREEN
        //==============================================================================================================================================================================================
        //====================== TRANSACTION SCREEN STUFF ==============================================================================================================================================

        private bool xpubValid = false;

        private void TextBoxSubmittedXpub_KeyPress(object sender, KeyPressEventArgs e)
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

        //-----DERIVE ADDRESSES FOR DIFFERENT ADDRESS TYPES, SCAN FOR TX'S AND OUTPUT TO LIST -------------------------------------
        private async void LookupXpub()
        {
            try
            {
                textBoxSubmittedXpub.Enabled = false;
                textBoxXpubNodeURL.Enabled = false;
                // NOT SUPPORTED var newAddress = pubkey.Derive(0).Derive(0).PubKey.GetAddress(ScriptPubKeyType.TaprootBIP86, Network.Main); //Taproot P2SH

                int MaxNumberOfConsecutiveUnusedAddresses = 19; // loop does this amount + 1
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

                string submittedXpub = Convert.ToString(textBoxSubmittedXpub.Text);

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

                // -------------------------------------------------------- TAPROOT :(

                // -------------------------------------------------------- P2WPKH (Bech32 SegWit)
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

                // -------------------------------------------------------- P2PKH legacy
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

                // -------------------------------------------------------- P2SH-P2WPKH
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

                // -------------------------------------------------------- P2SH
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
            }
            catch (Exception ex)
            {
                HandleException(ex, "LookupXpub");
            }
        }

        //-------------------- VALIDATE INPUT AND LOOK UP XPUB --------------------------------------------------------------------
        private void TextBoxSubmittedXpub_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSubmittedXpub.Text == "")
            {
                lblValidXpubIndicator.Text = "";
            }
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
                lblValidXpubIndicator.ForeColor = Color.IndianRed;
                lblValidXpubIndicator.Text = "✖️ Invalid Xpub";
                
                return;
            }
            xpubValid = true;
            lblValidXpubIndicator.ForeColor = Color.OliveDrab;
            lblValidXpubIndicator.Text = "✔️ valid Xpub";
            LookupXpub();
        }

        //-------------------- FORMAT DATA IN LISTVIEW ----------------------------------------------------------------------------
        private void ListViewXpubAddresses_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        private bool isTextBoxMempoolURLWatermarkTextDisplayed = true;

        //-------------------- VALIDATE NODE URL ENTRY ---------------------------------------------------------------------------
        private void TextBoxMempoolURL_Enter(object sender, EventArgs e)
        {
            if (isTextBoxMempoolURLWatermarkTextDisplayed)
            {
                textBoxXpubNodeURL.Text = "";
                textBoxXpubNodeURL.ForeColor = Color.White;
                isTextBoxMempoolURLWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxMempoolURL_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxXpubNodeURL.Text))
            {
                textBoxXpubNodeURL.Text = "e.g http://umbrel.local:3006/api/";
                textBoxXpubNodeURL.ForeColor = Color.Gray;
                isTextBoxMempoolURLWatermarkTextDisplayed = true;
            }
        }

        private void TextBoxMempoolURL_TextChanged(object sender, EventArgs e)
        {
            if (isTextBoxMempoolURLWatermarkTextDisplayed)
            {
                textBoxXpubNodeURL.ForeColor = Color.White;
                isTextBoxMempoolURLWatermarkTextDisplayed = false;
            }
        }

        private string previousXpubNodeStringToCompare = "";

        private void TextBoxMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBoxMempoolURL_KeyUp(object sender, KeyEventArgs e)
        {
            if (previousXpubNodeStringToCompare != textBoxXpubNodeURL.Text)
            {
                textBoxSubmittedXpub.Enabled = false;
                lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                label18.Text = "invalid / node offline";
                textBoxSubmittedXpub.Text = "";
                previousXpubNodeStringToCompare = textBoxXpubNodeURL.Text;
                CheckXpubNodeIsOnline();
            }
        }

        private void LblSegwitUsedAddresses_Paint(object sender, PaintEventArgs e)
        {
            lblSegwitUsedAddresses.Location = new Point(label123.Location.X + label123.Width, label123.Location.Y);
        }

        private void LblLegacyUsedAddresses_Paint(object sender, PaintEventArgs e)
        {
            lblLegacyUsedAddresses.Location = new Point(label111.Location.X + label111.Width, label111.Location.Y);
        }

        private void LblSegwitP2SHUsedAddresses_Paint(object sender, PaintEventArgs e)
        {
            lblSegwitP2SHUsedAddresses.Location = new Point(label119.Location.X + label119.Width, label119.Location.Y);
        }

        private string xpubNodeURL = "";

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
                            label18.ForeColor = Color.IndianRed;
                            //lblSettingsXpubNodeStatus.ForeColor = Color.IndianRed;
                            label18.Text = "node offline";
                            lblSettingsXpubNodeStatus.Text = "node offline";
                            return;
                        }
                    }
                    else
                    {
                        lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                        label18.ForeColor = Color.IndianRed;
                        //lblSettingsXpubNodeStatus.ForeColor = Color.IndianRed;
                        label18.Text = "node offline";
                        lblSettingsXpubNodeStatus.Text = "node offline";
                        return;
                    }
                }

                // handle this being null!
                PingReply reply = await pingSender.SendPingAsync(pingAddress);
                if (reply.Status == IPStatus.Success)
                {
                    lblXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                    lblSettingsXpubNodeStatusLight.ForeColor = Color.OliveDrab;
                    label18.ForeColor = Color.OliveDrab;
                    //lblSettingsXpubNodeStatus.ForeColor = Color.OliveDrab;
                    label18.Text = "node online";
                    lblSettingsXpubNodeStatus.Text = "node online";
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

                   // textBoxSubmittedXpub.Text = "";
                    textBoxSubmittedXpub.Enabled = true;
                    //textBoxSubmittedXpub.Focus();
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
            catch (HttpRequestException)
            {
                // API is not online
                lblXpubNodeStatusLight.ForeColor = Color.IndianRed;
                lblSettingsXpubNodeStatusLight.ForeColor = Color.IndianRed;
                label18.Text = "invalid / node offline";
                lblSettingsXpubNodeStatus.Text = "invalid / node offline";
            }
        }

        //-------------------- USER TRYING TO CHANGE COLUMN WIDTHS -------------------------------------
        private void ListViewXpubAddresses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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

        //-------------------- HIDE PROGRESS BARS, ETC AFTER A PERIOD ----------------------------------
        private void TimerHideProgressBars_Tick(object sender, EventArgs e)
        {
            progressBarCheckAllAddressTypes.Visible = false;
            progressBarCheckEachAddressType.Visible = false;
            lblCheckAllAddressTypesCount.Visible = false;
            lblCheckEachAddressTypeCount.Visible = false;
            label140.Visible = false;
            label141.Visible = false;

            timerHideProgressBars.Stop();
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

        //-------------------- SCROLL-DOWN LISTVIEW ----------------------------------------------------
        private void BtnXpubAddressesDown_Click(object sender, EventArgs e)
        {
            if (panelXpubContainer.VerticalScroll.Value < panelXpubContainer.VerticalScroll.Maximum)
            {
                panelXpubContainer.VerticalScroll.Value++;
            }
        }

        private bool isXpubButtonPressed = false;
        private bool XpubDownButtonPressed = false;
        private bool XpubUpButtonPressed = false;

        private void BtnXpubAddressesDown_MouseDown(object sender, MouseEventArgs e)
        {
            isXpubButtonPressed = true;
            XpubDownButtonPressed = true;
            XpubScrollTimer.Start();
        }

        private void BtnXpubAddressesDown_MouseUp(object sender, MouseEventArgs e)
        {
            isXpubButtonPressed = false;
            XpubDownButtonPressed = false;
            XpubScrollTimer.Stop();
            XpubScrollTimer.Interval = 50; // reset the interval to its original value
        }

        //-------------------- SCROLL-UP LISTVIEW -------------------------------------------------------
        private void BtnXpubAddressUp_Click(object sender, EventArgs e)
        {
            if (panelXpubContainer.VerticalScroll.Value > panelXpubContainer.VerticalScroll.Minimum)
            {
                panelXpubContainer.VerticalScroll.Value--;
            }
        }

        private void BtnXpubAddressUp_MouseDown(object sender, MouseEventArgs e)
        {
            isXpubButtonPressed = true;
            XpubUpButtonPressed = true;
            XpubScrollTimer.Start();
        }

        private void BtnXpubAddressUp_MouseUp(object sender, MouseEventArgs e)
        {
            isXpubButtonPressed = false;
            XpubUpButtonPressed = false;
            XpubScrollTimer.Stop();
            XpubScrollTimer.Interval = 50; // reset the interval to its original value
        }

        //-------------------- HANDLE THE SCROLLING -------------------------------------------------------
        private void XpubScrollTimer_Tick(object sender, EventArgs e)
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

        private void PanelXpub_Paint(object sender, PaintEventArgs e)
        {
            textBoxSubmittedXpub.Location = new Point(label146.Location.X + label146.Width, textBoxSubmittedXpub.Location.Y);
            textBoxXpubNodeURL.Location = new Point(label114.Location.X + label114.Width + 4, textBoxXpubNodeURL.Location.Y);
            lblValidXpubIndicator.Location = new Point(textBoxSubmittedXpub.Location.X + textBoxSubmittedXpub.Width, lblValidXpubIndicator.Location.Y);
        }

        private void PanelXpubContainer_Paint(object sender, PaintEventArgs e)
        {
            if (btnViewAddressFromXpub.Visible) // user must have clicked a row given that the button is visible
            {
                panelXpubContainer.VerticalScroll.Value = XpubAddressesScrollPosition; //return the scroll position to where it was when clicked (it jumps to top otherwise)
            }
        }

        //-------------------- VIEW ADDRESS --------------------------------------------------------------
        private void BtnViewAddressFromXpub_Click(object sender, EventArgs e)
        {
            try
            {
                //assign address to text box on address panel
                // Get the selected item
                ListViewItem selectedItem = listViewXpubAddresses.SelectedItems[0];
                // Get the first subitem in the selected item 
                string SelectedAddress = selectedItem.SubItems[0].Text;
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = SelectedAddress;
                });
                //show the address screen
                BtnMenuAddress_Click(sender, e);
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnViewAddressFromXpub_Click");
            }
        }

        private void NumberUpDownDerivationPathsToCheck_Validating(object sender, CancelEventArgs e)
        {
            if (numberUpDownDerivationPathsToCheck.Value > 100)
            {
                numberUpDownDerivationPathsToCheck.Value = 100;
            }
        }

        #endregion

        #region BOOKMARKS SCREEN
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
                    if (bookmark.Type != "xpubnode" && bookmark.Type != "defaulttheme" && bookmark.Type != "settings")
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

        string bookmarkDataInFullPreserved = string.Empty;
        string bookmarkNoteInFullPreserved = string.Empty;
        string bookmarkKeyCheckPreserved = string.Empty;

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
                        if (label18.Text == "node online")
                        {
                            btnViewBookmark.Enabled = true;
                        }
                        else
                        {
                            lblAlert.Text = "⚠️";
                            lblErrorMessage.Text = "a url to a connected full node must be provided on the Xpub screen before the selected Xpub can be viewed.";
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

        private void BtnViewBookmark_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void BtnDeleteBoookmark_Click(object sender, EventArgs e)
        {
            try
            {
                string bookmarkDataToDelete = lblBookmarkDataInFull.Text;
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

        private void BtnDecryptBookmark_Click(object sender, EventArgs e)
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

        private void BtnBookmarksListDown_Click(object sender, EventArgs e)
        {
            if (panelBookmarksContainer.VerticalScroll.Value < panelBookmarksContainer.VerticalScroll.Maximum)
            {
                panelBookmarksContainer.VerticalScroll.Value++;
            }
        }

        private bool isBookmarksButtonPressed = false;
        private bool bookmarksDownButtonPressed = false;
        private bool bookmarksUpButtonPressed = false;

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

        private bool isBookmarkKeyWatermarkTextDisplayed = true;

        private void TextBoxBookmarkKey_Enter(object sender, EventArgs e)
        {
            if (isBookmarkKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkKey.Text = "";
                textBoxBookmarkKey.ForeColor = Color.White;
                isBookmarkKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isBookmarkKeyWatermarkTextDisplayed)
            {
                textBoxBookmarkKey.Text = "";
                textBoxBookmarkKey.ForeColor = Color.White;
                isBookmarkKeyWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxBookmarkKey_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookmarkProposedNote.Text))
            {
                textBoxBookmarkKey.Text = "enter key to unlock";
                textBoxBookmarkKey.ForeColor = Color.Gray;
                isBookmarkKeyWatermarkTextDisplayed = true;
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

        private void PanelBookmarksContainer_Paint(object sender, PaintEventArgs e)
        {
            if (btnViewBookmark.Enabled)
            {
                panelBookmarksContainer.VerticalScroll.Value = bookmarksScrollPosition;

            }
        }
        #endregion

        #region ADD TO BOOKMARKS TAB
        //==============================================================================================================
        //---------------------- ADD TO BOOKMARKS ---------------------------------------------------------------------
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

        private void BtnCancelAddToBookmarks_Click(object sender, EventArgs e)
        {
            panelAddToBookmarks.Visible = false;
            panelFees.Visible = true;
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

                var newBookmark = new Bookmark { DateAdded = today, Type = lblBookmarkProposalType.Text, Data = bookmarkData, Note = bookmarkNote, Encrypted = toBeEncrypted, KeyCheck = keyCheck};

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

        private static List<Bookmark> ReadBookmarksFromJsonFile()
        {
            string filePath = "bookmarks.json";

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

            return bookmarks;
        }

        private static void WriteBookmarksToJsonFile(List<Bookmark> bookmarks)
        {
            // Serialize the list of bookmark objects into a JSON string
            string json = JsonConvert.SerializeObject(bookmarks);

            // Write the JSON string to the bookmarks.json file
            System.IO.File.WriteAllText("bookmarks.json", json);
        }

        private void HideBookmarksShowFees(object sender, EventArgs e)
        {
            panelAddToBookmarks.Visible = false;
            panelFees.Visible = true;
        }

        private bool isBookmarkNoteWatermarkTextDisplayed = true;

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

        private bool isEncryptionKeyWatermarkTextDisplayed = true;

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

        #region SETTINGS SCREEN
        private bool isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = true;

        private void TextBoxSettingsXpubMempoolURL_Enter(object sender, EventArgs e)
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

        private void TextBoxSettingsXpubMempoolURL_Leave(object sender, EventArgs e)
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

        private void TextBoxSettingsXpubMempoolURL_TextChanged(object sender, EventArgs e)
        {
            if (isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed)
            {
                textBoxSettingsXpubMempoolURL.ForeColor = Color.White;
                isTextBoxSettingsXpubMempoolURLWatermarkTextDisplayed = false;
            }
        }

        private void TextBoxSettingsXpubMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBoxSettingsXpubMempoolURL_KeyUp(object sender, KeyEventArgs e)
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

        private void LblSettingsNodeMainnet_Click(object sender, EventArgs e)
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
                btnMenuLightningDashboard.Enabled = true;
                textBoxSettingsCustomMempoolURL.Enabled = false;
                NodeURL = "https://mempool.space/api/";
                CheckNetworkStatus();
                CreateDataServices();
                SaveSettingsToBookmarksFile();
                GetBlockTip();
                LookupBlockList();
                UpdateBitcoinAndLightningDashboards();
            }

        }

        private void LblSettingsNodeTestnet_Click(object sender, EventArgs e)
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
                btnMenuLightningDashboard.Enabled = false;
                NodeURL = "https://mempool.space/testnet/api/";
                CheckNetworkStatus();
                CreateDataServices();
                SaveSettingsToBookmarksFile();
                GetBlockTip();
                LookupBlockList();
                UpdateBitcoinAndLightningDashboards();
            }
        }

        private void LblSettingsNodeCustom_Click(object sender, EventArgs e)
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

                //string tempurl = textBoxSettingsCustomMempoolURL.Text;
                //textBoxSettingsCustomMempoolURL.Text = "";
                //textBoxSettingsCustomMempoolURL.Text = tempurl;
                
                CheckCustomNodeIsOnline();
                

                      CheckNetworkStatus();
                //      CreateDataServices();
                //      SaveSettingsToBookmarksFile();
                //      GetBlockTip();
                //      LookupBlockList();
                //      UpdateBitcoinAndLightningDashboards();
            }
        }

        private bool isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = true;
        private string previousCustomNodeStringToCompare = "";

        private void TextBoxSettingsCustomMempoolURL_Enter(object sender, EventArgs e)
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

        private void TextBoxSettingsCustomMempoolURL_Leave(object sender, EventArgs e)
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

        private void TextBoxSettingsCustomMempoolURL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBoxSettingsCustomMempoolURL_KeyUp(object sender, KeyEventArgs e)
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

        private void TextBoxSettingsCustomMempoolURL_TextChanged(object sender, EventArgs e)
        {
            if (isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed)
            {
                textBoxSettingsCustomMempoolURL.ForeColor = Color.White;
                isTextBoxSettingsCustomMempoolURLWatermarkTextDisplayed = false;
            }
        }

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
                            // get the hostname from the URL
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
                                //lblSettingsCustomNodeStatus.ForeColor = Color.IndianRed;
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
                            //lblSettingsCustomNodeStatus.ForeColor = Color.IndianRed;
                            lblSettingsCustomNodeStatus.Text = "node offline";
                        });
                        return;
                    }
                }

                // handle this being null!
                PingReply reply = await pingSender.SendPingAsync(pingAddress);
                if (reply.Status == IPStatus.Success)
                {
                    lblSettingsCustomNodeStatusLight.ForeColor = Color.OliveDrab;
                    lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        //lblSettingsCustomNodeStatus.ForeColor = Color.OliveDrab;
                        lblSettingsCustomNodeStatus.Text = "node online";
                    });
                    if (lblSettingsNodeCustom.Text == "✔️")
                    {
                        //CheckNetworkStatus();
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
                    ////////////

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

        string currencySelected = "D";
        string selectedNetwork = "M";
        string blockchairComJSONSelected = "1";
        string bitcoinExplorerEnpointsSelected = "1";
        string blockchainInfoEndpointsSelected = "1";
        string bitcoinDashboardSelected = "1";
        string lightningDashboardSelected = "1";
        string mempoolLightningJSONSelected = "1";

        private void LblBlockchairComJSON_Click(object sender, EventArgs e)
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
            }
            SaveSettingsToBookmarksFile();
        }

        private void LblBitcoinExplorerEndpoints_Click(object sender, EventArgs e)
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
            }
            SaveSettingsToBookmarksFile();
        }

        private void LblBlockchainInfoEndpoints_Click(object sender, EventArgs e)
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
            }
            SaveSettingsToBookmarksFile();
        }

        private void LblBitcoinDashboard_Click(object sender, EventArgs e)
        {
            if (lblBitcoinDashboard.Text == "✔️")
            {
                lblBitcoinDashboard.Invoke((MethodInvoker)delegate
                {
                    lblBitcoinDashboard.ForeColor = Color.IndianRed;
                    lblBitcoinDashboard.Text = "❌";
                });
                lblBlockchairComJSON.Invoke((MethodInvoker)delegate
                {
                    lblBlockchairComJSON.ForeColor = Color.IndianRed;
                    lblBlockchairComJSON.Text = "❌";
                    RunBlockchairComJSONAPI = false;
                });
                lblBitcoinExplorerEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBitcoinExplorerEndpoints.ForeColor = Color.IndianRed;
                    lblBitcoinExplorerEndpoints.Text = "❌";
                });
                RunBitcoinExplorerEndpointAPI = false;
                RunBitcoinExplorerOrgJSONAPI = false;
                lblBlockchainInfoEndpoints.Invoke((MethodInvoker)delegate
                {
                    lblBlockchainInfoEndpoints.ForeColor = Color.IndianRed;
                    lblBlockchainInfoEndpoints.Text = "❌";
                });
                RunBlockchainInfoEndpointAPI = false;
                lblBlockchairComJSON.Enabled = false;
                lblBitcoinExplorerEndpoints.Enabled = false;
                lblBlockchainInfoEndpoints.Enabled = false;
                bitcoinDashboardSelected = "0";
                blockchairComJSONSelected = "0";
                bitcoinExplorerEnpointsSelected = "0";
                blockchainInfoEndpointsSelected = "0";
                btnMenuBitcoinDashboard.Enabled = false;
            }
            else
            {
                lblBitcoinDashboard.Invoke((MethodInvoker)delegate
                {
                    lblBitcoinDashboard.ForeColor = Color.Green;
                    lblBitcoinDashboard.Text = "✔️";
                });
                lblBlockchairComJSON.Enabled = true;
                lblBitcoinExplorerEndpoints.Enabled = true;
                lblBlockchainInfoEndpoints.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                bitcoinDashboardSelected = "1";
            }
            SaveSettingsToBookmarksFile();
        }

        private void LblLightningDashboard_Click(object sender, EventArgs e)
        {
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
        }

        private void LblMempoolLightningJSON_Click(object sender, EventArgs e)
        {
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
        }

        private void NumericUpDownDashboardRefresh_ValueChanged(object sender, EventArgs e)
        {
            APIGroup1DisplayTimerIntervalSecsConstant = (int)numericUpDownDashboardRefresh.Value * 60;
            intAPIGroup1TimerIntervalMillisecsConstant = (((int)numericUpDownDashboardRefresh.Value * 60) * 1000);
            intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
            timerAPIRefreshPeriod.Stop();
            timerAPIRefreshPeriod.Interval = intAPIGroup1TimerIntervalMillisecsConstant;
            timerAPIRefreshPeriod.Start();
            SaveSettingsToBookmarksFile();
        }

        // settings entry in the bookmark file = M111111nnn... 1st char P(ound), D(ollar), E(uro), G(old) = GBP, USD, EUR, XAU. 2nd char M, T, C = Mainnet, Testnet, Custom, then 6 bools = blockchairComJSON, BitcoinExplorerEndpoints, BlockchainInfoEndpoints, Bitcoin Dashboard, Lightning Dashboard, MempoolLightningJSON, nnn = refresh freq.

        private void SaveSettingsToBookmarksFile()
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
            // write the settings to the bookmarks file for auto retrieval next time
            DateTime today = DateTime.Today;
            string bookmarkData = currencySelected + selectedNetwork + blockchairComJSONSelected + bitcoinExplorerEnpointsSelected + blockchainInfoEndpointsSelected + bitcoinDashboardSelected + lightningDashboardSelected + mempoolLightningJSONSelected + numericUpDownDashboardRefresh.Value.ToString().PadLeft(4, '0'); ;
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
                //if (settingsInFile != bookmarkData)
                //{
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
                //}
            }
        }

        #endregion

        #region APPEARANCE SCREEN

        private void BtnColorDataFields_Click(object sender, EventArgs e)
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

        private void BtnColorLabels_Click(object sender, EventArgs e)
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

        private void BtnColorPanels_Click(object sender, EventArgs e)
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

        private void BtnColorHeadings_Click(object sender, EventArgs e)
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

        private void BtnColorProgressBars_Click(object sender, EventArgs e)
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

        private void BtnColorButtons_Click(object sender, EventArgs e)
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

        private void BtnColorButtonText_Click(object sender, EventArgs e)
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

        private void BtnColorLines_Click(object sender, EventArgs e)
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

        private void BtnColorTableText_Click(object sender, EventArgs e)
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
            }

        }
        
        private void BtnColorOtherText_Click(object sender, EventArgs e)
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

        private void BtnColorTextBox_Click(object sender, EventArgs e)
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

        private void BtnColorPriceBlock_Click(object sender, EventArgs e)
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

        private void BtnColorStatusError_Click(object sender, EventArgs e)
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

        private void LblShowClock_Click(object sender, EventArgs e)
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
                lblTime.Visible = true;
            }
        }

        private void PictureBoxGenesis_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.BackgroundImage = Properties.Resources.AppBackground2;
            });
            lblBackgroundGenesisSelected.Visible = true;
            lblBackgroundBTCdirSelected.Visible = false;
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

        private void PictureBoxBTCDir_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.BackgroundImage = Properties.Resources.SatsumaBTCdir1;
            });
            lblTime.Visible = false;
            lblBackgroundGenesisSelected.Visible =false;
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

        private void PictureBoxCustomColor_Click(object sender, EventArgs e)
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

        private void LblTitleBackgroundNone_Click(object sender, EventArgs e)
        {
            if (lblTitleBackgroundNone.Text != "✔️")
            {
                HeadingBackgroundsToNone();
            }

        }

        private void LblTitleBackgroundDefault_Click(object sender, EventArgs e)
        {
            if (lblTitleBackgroundDefault.Text != "✔️")
            {
                HeadingBackgroundsToDefault();
            }
        }

        private void BtnColorTitleBackgrounds_Click(object sender, EventArgs e)
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

        private void LblTitleBackgroundCustom_Click(object sender, EventArgs e)
        {
            if (lblTitleBackgroundCustom.Text != "✔️")
            {
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

        private void SetCustomTitleBackgroundColor()
        {
            HeadingBackgroundsToCustomColor();
        }

        private void BtnColorTableBackground_Click(object sender, EventArgs e)
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

        private void BtnColorTableTitleBar_Click(object sender, EventArgs e)
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

        private void BtnListViewHeadingColor_Click(object sender, EventArgs e)
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

        private void PictureBoxCustomImage_Click(object sender, EventArgs e)
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
                lblBackgroundBTCdirSelected.Visible = false;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = true;
                lblTime.Visible = false;
                label194.Enabled = true;
                textBoxThemeImage.Enabled = true;
            }
        }

        private static List<Theme> ReadThemesFromJsonFile()
        {
            string filePath = "themes.json";

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

        private static void WriteThemeToJsonFile(List<Theme> themes)
        {
            // Serialize the list of bookmark objects into a JSON string
            string json = JsonConvert.SerializeObject(themes);

            // Write the JSON string to the bookmarks.json file
            System.IO.File.WriteAllText("themes.json", json);
        }

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
                var newTheme = new Theme { ThemeName = textBoxThemeName.Text, DataFields = datafields, Labels = labels, Headings = headings, Tables = tables, TableHeadings = tableheadings, OtherText = othertext, PriceBlock = priceblock, StatusErrors = statuserrors, Buttons = buttons, ButtonText = buttontext, Lines = lines, TextBoxes = textboxes, ProgressBars = progressbars, TableBackgrounds = tablebackgrounds, TableTitleBars = tabletitlebars, ShowTime = showtime, HeadingBGDefault = headingbgdefault, HeadingBGNone = headingbgnone, HeadingBGCustom = headingbgcustom, HeadingBackgrounds = headingbackgrounds, WindowBackground = windowbackground, WindowImage = windowimage, BackgroundGenesis = backgroundgenesis, BackgroundBTCdir = backgroundbtcdir, BackgroundCustomColor = backgroundcustomcolor, BackgroundCustomImage = backgroundcustomimage, Panels = panels };

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

        private void BtnLoadTheme_Click(object sender, EventArgs e)
        {
            try
            {
                var themes = ReadThemesFromJsonFile();
                foreach (Theme theme in themes)
                {
                    if (theme.ThemeName == comboBoxThemeList.Text)
                    {
                        RestoreTheme(theme);
                        SaveThemeAsDefault(theme.ThemeName);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "btnLoadTheme_Click");
            }
        }

        private void RestoreTheme(Theme theme)
        {
            ColorDataFields(theme.DataFields);
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
                lblBackgroundGenesisSelected.Visible = false;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = false;
                this.BackgroundImage = Properties.Resources.SatsumaBTCdir1;
            }
            if (theme.BackgroundGenesis == true)
            {
                lblBackgroundGenesisSelected.ForeColor = Color.Green;
                lblBackgroundBTCdirSelected.Visible = false;
                lblBackgroundGenesisSelected.Visible = true;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = false;
                this.BackgroundImage = Properties.Resources.AppBackground2;
            }
            if (theme.BackgroundCustomColor == true)
            {
                lblBackgroundCustomColorSelected.ForeColor = Color.Green;
                lblBackgroundBTCdirSelected.Visible = false;
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
                lblBackgroundGenesisSelected.Visible = false;
                lblBackgroundCustomColorSelected.Visible = false;
                lblBackgroundCustomImageSelected.Visible = true;
                this.BackgroundImage = System.Drawing.Image.FromFile(theme.WindowImage);
            }

        }

        private void ColorDataFields(Color thisColor)
        {
            //header
            Control[] listHeaderDataFieldsToColor = { lblHeaderMarketCap, lblHeaderMoscowTime, lblTransactions, lblBlockSize, lblfeesHighPriority, lblFeesMediumPriority, lblFeesLowPriority, lblFeesNoPriority, lblHeaderHashrate };
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
            Control[] listTransactionDataFieldsToColor = { lblInvalidTransaction, lblTransactionBlockHeight, lblTransactionBlockTime, lblTransactionConfirmations, lblTransactionLockTime, lblTransactionVersion, lblTransactionInputCount, lblCoinbase, lblTransactionFee, lblTransactionOutputCount, lblTransactionSize, lblTransactionWeight, lblTotalInputValue, lblTotalOutputValue };
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
        }

        private void ColorLabels(Color thiscolor)
        {
            //header
            Control[] listHeaderLabelsToColor = { label77, lblHeaderMoscowTimeLabel, label148, label149, label15, label25, label28, label29 };
            foreach (Control control in listHeaderLabelsToColor)
            {
                control.ForeColor = thiscolor;
            }
            //settings
            Control[] listSettingsLabelsToColor = { label193, label194, label196, label73, label161, label168, label160, label157, label172, label174, label167, label4, lblWhatever, label152, label169, label171, label6, label178, label177, label179, label180, label188, label186, label185, label187, label189, label191 };
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
            Control[] listLightningDashboardLabelsToColor = { label38, label50, label47, label48, label49, label40, label36, label35, label45, label46, label34, label37, label39, label41, label42, label44, label43, label51, label52, label56, label55 };
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
            Control[] listBlockLabelsToColor = { label60, lblBlockTXPositionInList };
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
            Control[] listXpubLabelsToColor = { label114, label139, label146, label18, label140, label141, label123, label111, label119, label135, label133, label129, label121 };
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
        }

        private void ColorHeadings(Color thiscolor)
        {
            //header
            Control[] listHeaderHeadingsToColor = { label26, label22, label1, label150 };
            foreach (Control control in listHeaderHeadingsToColor)
            {
                control.ForeColor = thiscolor;
            }
            //settings
            Control[] listSettingsHeadingsToColor = { label162, label163, label155, label5, label156, label166, label181, label182, label183, label184, label192, label195 };
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
            //block
            Control[] listBlockHeadingsToColor = { label64, label145, label69, label68, label74, label72, label66, label70, label65, label62, label71 };
            foreach (Control control in listBlockHeadingsToColor)
            {
                control.ForeColor = thiscolor;
            }
            //blocklist
            Control[] listBlockListHeadingsToColor = { label143, lblBlockListBlockHeight };
            foreach (Control control in listBlockListHeadingsToColor)
            {
                control.ForeColor = thiscolor;
            }
            //transaction
            Control[] listTransactionHeadingsToColor = { label102, label102 };
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
        }

        private void ColorTables(Color thiscolor)
        {
            Control[] listTableTextToColor = { label170, listViewAddressTransactions, listViewBlockTransactions, listViewBlockList, listViewTransactionInputs, listViewTransactionOutputs, listViewXpubAddresses, listViewBookmarks, label186 };
            foreach (Control control in listTableTextToColor)
            {
                control.ForeColor = thiscolor;
            }
            tableTextColor = thiscolor;
        }

        private void ColorTableHeadings(Color thiscolor)
        {
            listViewHeaderTextColor = thiscolor;
            label188.ForeColor = thiscolor;
            label190.ForeColor = thiscolor;
        }

        private void ColorOtherText(Color thiscolor)
        {
            Control[] listOtherTextToColor = { label159, label158, label165, label173, label164, lblURLWarning };
            foreach (Control control in listOtherTextToColor)
            {
                control.ForeColor = thiscolor;
            }
        }

        private void ColorPriceBlock(Color thiscolor)
        {
            lblHeaderPrice.ForeColor = thiscolor;
            lblBlockNumber.ForeColor = thiscolor;
            label175.ForeColor = thiscolor;
        }

        private void ColorStatusError(Color thiscolor)
        {
            lblRefreshSuccessOrFailMessage.ForeColor = thiscolor;
            lblElapsedSinceUpdate.ForeColor = thiscolor;
            lblErrorMessage.ForeColor = thiscolor;
            label176.ForeColor = thiscolor;

        }

        private void ColorButtons(Color thiscolor)
        {
            //header
            Control[] listHeaderButtonsToColor = { btnCurrency, btnAddToBookmarks, btnMenu, btnHelp, btnMinimise, btnExit, btnCommitToBookmarks, btnCancelAddToBookmarks };
            foreach (Control control in listHeaderButtonsToColor)
            {
                control.BackColor = thiscolor;
            }
            //settings
            Control[] listSettingsButtonsToColor = { button1, button2, btnSaveTheme, btnLoadTheme };
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
        }

        private void ColorButtonText(Color thiscolor)
        {
            //header
            Control[] listHeaderButtonTextToColor = { btnCurrency, btnAddToBookmarks, btnMenu, btnHelp, btnMinimise, btnExit, btnCommitToBookmarks, btnCancelAddToBookmarks };
            foreach (Control control in listHeaderButtonTextToColor)
            {
                control.ForeColor = thiscolor;
            }
            //settings
            Control[] listSettingsButtonTextToColor = { button1, button2, btnSaveTheme, btnLoadTheme };
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
        }

        private void ColorLines(Color thiscolor)
        {
            Control[] listLinesToColor = { panel14, panel17, panel16, panel18, panel21, panel15, panel19, panel61 };
            foreach (Control control in listLinesToColor)
            {
                control.BackColor = thiscolor;
            }

            linesColor = thiscolor;
        }

        private void ColorTextBoxes(Color thiscolor)
        {
            Control[] listTextBoxesToColor = { textBox1, textBoxBookmarkProposedNote, textBoxBookmarkEncryptionKey, textboxSubmittedAddress, textBoxSubmittedBlockNumber, textBoxTransactionID, textBoxBlockHeightToStartListFrom, textBoxXpubNodeURL, numberUpDownDerivationPathsToCheck, textBoxSubmittedXpub, textBoxBookmarkKey, textBoxSettingsXpubMempoolURL, textBoxSettingsCustomMempoolURL, numericUpDownDashboardRefresh, textBoxThemeImage, textBoxThemeName, comboBoxThemeList };
            foreach (Control control in listTextBoxesToColor)
            {
                control.BackColor = thiscolor;
            }
        }

        private void ColorProgressBars(Color thiscolor)
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

        private void ColorTableBackgrounds(Color thiscolor)
        {
            Control[] listListViewBackgroundsToColor = { listViewBlockList, listViewTransactionInputs, listViewTransactionOutputs, listViewXpubAddresses, listViewBookmarks, listViewAddressTransactions, listViewBlockTransactions, panel66 };
            foreach (Control control in listListViewBackgroundsToColor)
            {
                {
                    control.BackColor = thiscolor;
                }
            }
        }

        private void ColorTableTitleBars(Color thiscolor)
        {
            listViewHeaderColor = thiscolor;
            panel67.BackColor = thiscolor;
            panel68.BackColor = thiscolor;
        }

        private void HeadingBackgroundsToDefault()
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
            //settings
            Control[] listSettingsHeadingsToColor = { panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72 };
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
            Control[] listBlockHeadingsToColor = { panel46, panel47, panel48, panel49, panel50, panel51, panel52, panel53, panel54, panel55 };
            foreach (Control control in listBlockHeadingsToColor)
            {
                control.BackColor = Color.Transparent;
                control.BackgroundImage = Properties.Resources.titleBGLongerOrange;
            }
            //blocklist
            Control[] listBlockListHeadingsToColor = { panel13, panel45 };
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

        }

        private void HeadingBackgroundsToNone()
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
            //settings
            Control[] listSettingsHeadingsToColor = { panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72 };
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
            Control[] listBlockHeadingsToColor = { panel46, panel47, panel48, panel49, panel50, panel51, panel52, panel53, panel54, panel55 };
            foreach (Control control in listBlockHeadingsToColor)
            {
                control.BackColor = Color.Transparent;
                control.BackgroundImage = null;
            }
            //blocklist
            Control[] listBlockListHeadingsToColor = { panel13, panel45 };
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
        }

        private void HeadingBackgroundsToCustomColor()
        {
            //header
            Control[] listHeaderHeadingsToColor = { panel38, panel39, panel31, panel40, panel57, panelRefreshStatusBar };
            foreach (Control control in listHeaderHeadingsToColor)
            {
                control.BackgroundImage = null;
                control.BackColor = titleBackgroundColor;
            }
            //settings
            Control[] listSettingsHeadingsToColor = { panel58, panel59, panel60, panel62, panel63, panel64, panel22, panel34, panel37, panel65, panel69, panel72 };
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
            Control[] listBlockHeadingsToColor = { panel46, panel47, panel48, panel49, panel50, panel51, panel52, panel53, panel54, panel55 };
            foreach (Control control in listBlockHeadingsToColor)
            {
                control.BackgroundImage = null;
                control.BackColor = titleBackgroundColor;
            }
            //blocklist
            Control[] listBlockListHeadingsToColor = { panel13, panel45 };
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
        }

        private void ColorPanels(Color thiscolor)
        {
            Control[] listPanelsToColor = { panel70, panel71, panel73, panel20, panel32 };
            foreach (Control control in listPanelsToColor)
            {
                {
                    control.BackColor = thiscolor;
                }
            }
        }

        private void SaveThemeAsDefault(string themename)
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

        private void ComboBoxThemeList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBoxThemeList.SelectedValue) == "Genesis (default)" || Convert.ToString(comboBoxThemeList.SelectedValue) == "BTCdir")
            {
                btnDeleteTheme.Enabled = false;
            }
            else
            {
                btnDeleteTheme.Enabled = true;
            }
        }

        private void BtnDeleteTheme_Click(object sender, EventArgs e)
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

        private void HideThemeSavedTimer_Tick(object sender, EventArgs e)
        {
            lblThemeSaved.Visible = false;
            hideThemeSavedTimer.Stop();
        }

        private void HideThemeDeletedTimer_Tick(object sender, EventArgs e)
        {
            lblThemeDeleted.Visible = false;
            hideThemeDeletedTimer.Stop();
        }
        #endregion

        #region REUSEABLE STUFF
        //==============================================================================================================================================================================================
        //====================== COMMON CODE ++=========================================================================================================================================================

        private void CreateDataServices()
        {
            _transactionsForAddressService = new TransactionsForAddressService(NodeURL);
            _blockService = new BlockDataService(NodeURL);
            _transactionsForBlockService = new TransactionsForBlockService(NodeURL);
            _transactionService = new TransactionService(NodeURL);
        }

        // Get current block tip
        private void GetBlockTip()
        {
            using WebClient client = new WebClient();
            string BlockTipURL = NodeURL + "blocks/tip/height";
            string BlockTip = client.DownloadString(BlockTipURL); // get current block tip
            lblBlockNumber.Invoke((MethodInvoker)delegate
            {
                lblBlockNumber.Text = BlockTip;
                textBoxBlockHeightToStartListFrom.Text = BlockTip;
            });
        }

        // Method to encrypt a string using SHA-256
        private string Encrypt(string input, string key)
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

        // Method to decrypt a string using SHA-256
        private string Decrypt(string input, string key)
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

        //=============================================================================================================
        //--------------- ERROR HANDLER -------------------------------------------------------------------------------

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

        //=============================================================================================================
        //--------------- SHOW ALERT SYMBOL -------------------------------------------------------------------------------

        private void ShowAlertSymbol()
        {
            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
        }


        //=============================================================================================================
        //--------------- OVERRIDE COLOURS FOR LISTVIEW HEADINGS ------------------------------------------------------

        private void AllListViews_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        //=============================================================================================================
        //-------------------- CONVERT SATS TO BITCOIN ----------------------------------------------------------------

        private decimal ConvertSatsToBitcoin(string numerics)
        {
            decimal number = decimal.Parse(numerics);
            decimal result = number / 100000000;
            return result;
        }

        //=============================================================================================================
        //-------DISABLE/ENABLE BUTTONS AND ANIMATION DURING LOADING AND RETURN THEM TO PREVIOUS STATE-----------------
        private void DisableEnableButtons(string enableOrDisableAllButtons)
        {
            if (enableOrDisableAllButtons == "disable")
            {
                // get current state of buttons before disabling them
                btnShowAllAddressTXWasEnabled = btnShowAllTX.Enabled;
                btnShowConfirmedAddressTXWasEnabled = btnShowConfirmedTX.Enabled;
                btnShowUnconfirmedAddressTXWasEnabled = btnShowUnconfirmedTX.Enabled;
                btnFirstAddressTransactionWasEnabled = btnFirstAddressTransaction.Enabled;
                btnNextAddressTransactionsWasEnabled = btnNextAddressTransactions.Enabled;
                BtnViewTransactionFromAddressWasEnabled = BtnViewTransactionFromAddress.Enabled;
                BtnViewBlockFromAddressWasEnabled = BtnViewBlockFromAddress.Enabled;
                btnViewBlockFromBlockListWasEnabled = btnViewBlockFromBlockList.Enabled;
                btnPreviousBlockTransactionsWasEnabled = btnPreviousBlockTransactions.Enabled;
                btnNextBlockTransactionsWasEnabled = btnNextBlockTransactions.Enabled;
                textBoxSubmittedBlockNumberWasEnabled = textBoxSubmittedBlockNumber.Enabled;
                textBoxSubmittedAddressWasEnabled = textboxSubmittedAddress.Enabled;
                btnNextBlockWasEnabled = btnNextBlock.Enabled;
                btnPreviousBlockWasEnabled = btnPreviousBlock.Enabled;
                btnNewer15BlocksWasEnabled = btnNewer15Blocks.Enabled;
                btnOlder15BlocksWasEnabled = btnOlder15Blocks.Enabled;
                textBoxBlockHeightToStartListFromWasEnabled = textBoxBlockHeightToStartListFrom.Enabled;

                //disable them all
                btnShowAllTX.Enabled = false;
                btnShowConfirmedTX.Enabled = false;
                btnShowUnconfirmedTX.Enabled = false;
                btnFirstAddressTransaction.Enabled = false;
                btnNextAddressTransactions.Enabled = false;
                BtnViewTransactionFromAddress.Enabled = false;
                BtnViewBlockFromAddress.Enabled = false;
                btnViewBlockFromBlockList.Enabled = false;
                btnPreviousBlockTransactions.Enabled = false;
                btnNextBlockTransactions.Enabled = false;
                textboxSubmittedAddress.Enabled = false;
                textBoxSubmittedBlockNumber.Enabled = false;
                btnNextBlock.Enabled = false;
                btnPreviousBlock.Enabled = false;
                btnMenu.Enabled = false;
                btnNewer15Blocks.Enabled = false;
                btnOlder15Blocks.Enabled = false;
                textBoxBlockHeightToStartListFrom.Enabled = false;
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
                btnViewBlockFromBlockList.Enabled = btnViewBlockFromBlockListWasEnabled;
                btnPreviousBlockTransactions.Enabled = btnPreviousBlockTransactionsWasEnabled;
                btnNextBlockTransactions.Enabled = btnNextBlockTransactionsWasEnabled;
                btnNextBlock.Enabled = btnNextBlockWasEnabled;
                btnPreviousBlock.Enabled = btnPreviousBlockWasEnabled;
                textboxSubmittedAddress.Enabled = textBoxSubmittedAddressWasEnabled;
                textBoxSubmittedBlockNumber.Enabled = textBoxSubmittedBlockNumberWasEnabled;
                btnNewer15Blocks.Enabled = btnNewer15BlocksWasEnabled;
                btnOlder15Blocks.Enabled = btnOlder15BlocksWasEnabled;
                textBoxBlockHeightToStartListFrom.Enabled = textBoxBlockHeightToStartListFromWasEnabled;
                if (panelBlock.Visible == true)
                {
                    textBoxSubmittedBlockNumber.Focus();
                    // Set the cursor position to the end of the string
                    textBoxSubmittedBlockNumber.Select(textBoxSubmittedBlockNumber.Text.Length, 0);
                }
                if (panelAddress.Visible == true)
                {
                    textboxSubmittedAddress.Focus();
                    // Set the cursor position to the end of the string
                    textboxSubmittedAddress.Select(textboxSubmittedAddress.Text.Length, 0);
                }
                btnMenu.Enabled = true;
            }
        }

        //=============================================================================================================
        //------------------------DISABLE/ENABLE THE LOADING ANIMATION-------------------------------------------------

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

        //=============================================================================================================
        //--------------------COUNTDOWN, ERROR MESSAGES AND STATUS LIGHTS----------------------------------------------
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

        //=============================================================================================================        
        //-------------------------- CHECK API ONLINE STATUS ----------------------------------------------------------
        private async void CheckNetworkStatus()
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
                            //////////////////////////////////////////////////////////////////////////
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
                                        // get the hostname from the URL
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
                                            //lblSettingsCustomNodeStatus.ForeColor = Color.IndianRed;
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
                                        //lblSettingsCustomNodeStatus.ForeColor = Color.IndianRed;
                                        lblSettingsCustomNodeStatus.Text = "node offline";
                                    });
                                    return;
                                }
                            }
                            /////////////////////////////////////////////////

                        }
                    }

                }
                
                
                PingReply reply = await pingSender.SendPingAsync(pingAddress);
                if (reply.Status == IPStatus.Success)
                {
                    lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatusLight.ForeColor = Color.OliveDrab;
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
                            displayNodeName = textBoxSettingsCustomMempoolURL.Text;
                        }
                    }
                    
                    lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatus.Text = displayNodeName;
                        headerNetworkName.Text = displayNodeName;
                    });
                }
                else
                {
                    // API is not online
                    lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
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
                            displayNodeName = textBoxSettingsCustomMempoolURL.Text;
                        }
                    }
                    lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                    {
                        lblSettingsCustomNodeStatus.Text = displayNodeName;
                        headerNetworkName.Text = displayNodeName;
                    });
                }
            }
            catch (HttpRequestException)
            {
                // API is not online
                lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
                {
                    lblSettingsCustomNodeStatusLight.ForeColor = Color.IndianRed;
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
                        displayNodeName = textBoxSettingsCustomMempoolURL.Text;
                    }
                }
                lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
                {
                    lblSettingsCustomNodeStatus.Text = displayNodeName;
                    headerNetworkName.Text = displayNodeName;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "CheckNetworkStatus: " + ex.Message;
                });
            }

            lblSettingsCustomNodeStatusLight.Invoke((MethodInvoker)delegate
            {
                lblSettingsCustomNodeStatusLight.Location = new Point(textBoxSettingsCustomMempoolURL.Location.X + textBoxSettingsCustomMempoolURL.Width, lblSettingsCustomNodeStatus.Location.Y + 3);
            });

            lblSettingsCustomNodeStatus.Invoke((MethodInvoker)delegate
            {
                lblSettingsCustomNodeStatus.Location = new Point(lblSettingsCustomNodeStatusLight.Location.X + lblSettingsCustomNodeStatusLight.Width, lblSettingsCustomNodeStatus.Location.Y);
            });

        }

        #endregion

        #region GENERAL FORM NAVIGATION AND CONTROLS
        //=============================================================================================================        
        //-------------------------- GENERAL FORM NAVIGATION/BUTTON CONTROLS-------------------------------------------

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
            if (panelMenu.Height == 24)
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 312;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
            }
            else
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
            }
        }

        private void BtnMenuHelp_Click(object sender, EventArgs e)
        {
            try
            {
                var modalWindow = new HelpScreen
                {
                    Owner = this, // Set the parent window as the owner of the modal window
                    StartPosition = FormStartPosition.CenterParent // Set the start position to center of parent
                };
                modalWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuHelp_Click");
            }
        }

        private void BtnMenuSplash_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                Splash splash = new Splash(); // invoke the about/splash screen
                splash.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuSplash_Click");
            }
        }

        private void BtnCurrency_Click(object sender, EventArgs e)
        {
            panelCurrency.BringToFront();
            if (panelCurrency.Height == 24)
            {
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 120;
                });
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
            }
            else
            {
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
            }
        }

        private void BtnExit_Click(object sender, EventArgs e) // exit
        {
            this.Close();
        }

        private void BtnMinimise_Click(object sender, EventArgs e) // minimise the form
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMoveWindow_MouseDown(object sender, MouseEventArgs e) // move the form when the move control is used
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24; //close menu
            });
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMoveWindow_MouseUp(object sender, MouseEventArgs e) // reset colour of the move form control
        {
            btnMoveWindow.BackColor = System.Drawing.ColorTranslator.FromHtml("#1D1D1D");
        }

        private void BtnMoveWindow_Click(object sender, EventArgs e)
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24; //close menu
            });
            panelCurrency.Invoke((MethodInvoker)delegate
            {
                panelCurrency.Height = 24;
            });
        }

        private void BtnMenuBitcoinDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuXpub.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = false;
                btnMenuBlockList.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuAppearance.Enabled = true;
                this.DoubleBuffered = true;
                this.SuspendLayout();
                panelBookmarks.Visible = false;
                panelBlockList.Visible = false;
                panelLightningDashboard.Visible = false;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
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
                btnMenuLightningDashboard.Enabled = false;
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
                panelLightningDashboard.Visible = true;
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnMenuLightningDashboard_Click");
            }
        }

        private void BtnMenuAddress_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
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
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelBlockList.Visible = false;
                panelLightningDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = false;
                panelAddress.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
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
                btnMenuSettings2.Enabled = true;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelBlock.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuXpub.Enabled = false;
                btnMenuBlock.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelBlock.Visible = false;
                panelSettings.Visible = false;
                panelXpub.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuBlockList.Enabled = false;
                btnMenuXpub.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelAppearance.Visible = false;
                panelSettings.Visible = false;
                panelBlockList.Visible = true;
                if (textBoxBlockHeightToStartListFrom.Text == "")
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                    });
                    // DisableEnableLoadingAnimation("enable"); // start the loading animation
                    // DisableEnableButtons("disable"); // disable buttons during operation
                    LookupBlockList(); // fetch the first 15 blocks automatically for the initial view.
                                       // DisableEnableLoadingAnimation("disable"); // stop the loading animation
                                       // DisableEnableButtons("enable"); // enable buttons after operation is complete
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuTransaction.Enabled = false;
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuSettings2.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelBookmarks.Visible = false;
                panelBlock.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelBlockList.Visible = false;
                panelXpub.Visible = false;
                panelSettings.Visible = false;
                panelTransaction.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuBookmarks.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelAppearance.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelSettings.Visible = false;
                panelBookmarks.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuAppearance.Enabled = true;
                btnMenuSettings2.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelTransaction.Visible = false;
                panelAppearance.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelBookmarks.Visible = false;
                panelSettings.Visible = true;
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
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                panelCurrency.Invoke((MethodInvoker)delegate
                {
                    panelCurrency.Height = 24;
                });
                btnMenuXpub.Enabled = true;
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                btnMenuBookmarks.Enabled = true;
                btnMenuSettings2.Enabled = true;
                btnMenuAppearance.Enabled = false;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelBookmarks.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelTransaction.Visible = false;
                panelXpub.Visible = false;
                panelBlock.Visible = false;
                panelBookmarks.Visible = false;
                panelSettings.Visible = false;
                panelAppearance.Visible = true;
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

        private void BtnHelp_Click(object sender, EventArgs e) // help screen
        {
            try
            {
                var modalWindow = new HelpScreen
                {
                    Owner = this, // Set the parent window as the owner of the modal window
                    StartPosition = FormStartPosition.CenterParent // Set the start position to center of parent
                };
                modalWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleException(ex, "BtnHelp_Click");
            }
        }

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

        public Panel GetPanelBookmarks() // enables help screen to get state (visible) of panel to determine which help text to show
        {
            return this.panelBookmarks;
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

        #region MISC UI STUFF
        //=============================================================================================================
        //--------------------------ON-SCREEN CLOCK--------------------------------------------------------------------
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

        //=============================================================================================================
        //---------------------- BORDER AROUND WINDOW------------------------------------------------------------------
        private void Form1_Paint(object sender, PaintEventArgs e) // place a 1px border around the form
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            lblXpubNodeStatusLight.Location = new Point(textBoxXpubNodeURL.Location.X + textBoxXpubNodeURL.Width, textBoxXpubNodeURL.Location.Y + 4);
            label18.Location = new Point(lblXpubNodeStatusLight.Location.X + lblXpubNodeStatusLight.Width, textBoxXpubNodeURL.Location.Y);
            if (panelAddress.Visible || panelBlock.Visible || panelTransaction.Visible || panelXpub.Visible)
            {
               if (panelAddress.Visible && lblAddressType.Text != "Invalid address format")
                {
                    btnAddToBookmarks.Enabled = true;
                    lblNowViewing.Text = "Address";
                }
               if (panelAddress.Visible && lblAddressType.Text == "Invalid address format")
                {
                    btnAddToBookmarks.Enabled = false;
                    lblNowViewing.Text = "Address";
                }
               if (panelBlock.Visible && lblBlockHash.Text != "")
                {
                    btnAddToBookmarks.Enabled = true;
                    lblNowViewing.Text = "Block";
                }
                if (panelBlock.Visible && lblBlockHash.Text == "")
                {
                    btnAddToBookmarks.Enabled = false;
                    lblNowViewing.Text = "Block";
                }
                if (panelTransaction.Visible && !lblInvalidTransaction.Visible)
                {
                    btnAddToBookmarks.Enabled = true;
                    lblNowViewing.Text = "Transaction";
                }
                if (panelTransaction.Visible && lblInvalidTransaction.Visible)
                {
                    btnAddToBookmarks.Enabled = false;
                    lblNowViewing.Text = "Transaction";
                }
                if (panelXpub.Visible && lblValidXpubIndicator.Text != "✔️ valid Xpub")
                { 
                    btnAddToBookmarks.Enabled = false;
                    lblNowViewing.Text = "Xpub";
                }
                if (panelXpub.Visible && lblValidXpubIndicator.Text == "✔️ valid Xpub")
                {
                    btnAddToBookmarks.Enabled = true;
                    lblNowViewing.Text = "Xpub";
                }
            }
            else
            {
                if (panelBitcoinDashboard.Visible)
                {
                    lblNowViewing.Text = "Bitcoin dashboard";
                }
                if (panelLightningDashboard.Visible)
                {
                    lblNowViewing.Text = "Lightning dashboard";
                }
                if (panelBlockList.Visible)
                {
                    lblNowViewing.Text = "Blocks";
                }
                if (panelBookmarks.Visible)
                {
                    lblNowViewing.Text = "Bookmarks";
                }
                if (panelSettings.Visible)
                {
                    lblNowViewing.Text = "Settings";
                }
                if (panelAppearance.Visible)
                {
                    lblNowViewing.Text = "Appearance";
                }
                btnAddToBookmarks.Enabled = false;
            }
            
        }
        #endregion

        #region CLASSES

        public class Bookmark
        {
            public DateTime DateAdded { get; set; }
            public string Type { get; set; }
            public string Data { get; set; }
            public string Note { get; set; }
            public bool Encrypted { get; set; }
            public string KeyCheck { get; set; }
        }

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
            public bool BackgroundCustomColor { get; set; }
            public bool BackgroundCustomImage { get; set; }
            public Color Panels { get; set; }
        }

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
            public decimal Value { get; set; }
            public decimal Amount { get; set; }
        }

        public class Prevout_AddressTransactions
        {
            public string Scriptpubkey_address { get; set; }
            public decimal Value { get; set; }
        }

        public class Vout_AddressTransactions
        {
            public double Value { get; set; }
            public decimal Amount { get; set; }
            public string Scriptpubkey_address { get; set; }
            public string Scriptpubkey_asm { get; set; }
        }

        public class Status_AddressTransactions
        {
            public int Block_height { get; set; }
            public string Confirmed { get; set; }
        }

        // ------------------------------------- Blocks -------------------------------------------------
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
            public string Id { get; set; }
            public string Height { get; set; }
            public string Version { get; set; }
            public string Timestamp { get; set; }
            public string Bits { get; set; }
            public string Nonce { get; set; }
            public string Difficulty { get; set; }
            public string Merkle_root { get; set; }
            public int Tx_count { get; set; }
            public int Size { get; set; }
            public string Weight { get; set; }
            public string Previousblockhash { get; set; }
        }

        public class Block_extras
        {
            public string Reward { get; set; }
            public decimal MedianFee { get; set; }
            public decimal[] FeeRange { get; set; }
            public int TotalFees { get; set; }
            public string AvgFee { get; set; }
            public string AvgFeeRate { get; set; }
            public string AvgTxSize { get; set; }
            public string TotalInputs { get; set; }
            public string TotalOutputs { get; set; }
            public string TotalOutputAmt { get; set; }
            public Block_pool Pool { get; set; }

        }

        public class Block_pool
        {
            public string Name { get; set; }
        }

        // ------------------------------------- Transaction --------------------------------------------
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
            public string Txid { get; set; }
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
            public bool Confirmed { get; set; }
            public int Block_height { get; set; }
            public string Block_hash { get; set; }
            public int Block_time { get; set; }
        }

        public class TransactionVin
        {
            public string Txid { get; set; }
            public long Vout { get; set; }
            public TransactionVinPrevout Prevout { get; set; }
            public string Scriptsig { get; set; }
            public string Scriptsig_asm { get; set; }
            public string[] Witness { get; set; }
            public bool Is_coinbase { get; set; }
            public long Sequence { get; set; }
            public string Inner_redeemscript_asm { get; set; }
        }

        public class TransactionVinPrevout
        {
            public string Scriptpubkey { get; set; }
            public string Scriptpubkey_asm { get; set; }
            public string Scriptpubkey_type { get; set; }
            public string Scriptpubkey_address { get; set; }
            public long Value { get; set; }
        }

        public class TransactionVout
        {
            public string Scriptpubkey { get; set; }
            public string Scriptpubkey_asm { get; set; }
            public string Scriptpubkey_type { get; set; }
            public string Scriptpubkey_address { get; set; }
            public long Value { get; set; }
        }


        // ------------------------------------- Block Transactions -------------------------------------
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
            //   public string txid { get; set; }
            //   public string vout { get; set; }
            //    public List<Prevout_BlockTransactions> prevout { get; set; }
            //    public string scriptsig { get; set; }
            //   public string scriptsig_asm { get; set; }
            //   public List<string> witness { get; set; }
            public string Is_coinbase { get; set; }
            //   public string sequence { get; set; }
        }


        public class Prevout_BlockTransactions
        {
            public string Scriptpubkey { get; set; }
            public string Scriptpubkey_asm { get; set; }
            public string Scriptpubkey_type { get; set; }
            public string Scriptpubkey_address { get; set; }
            public string Value { get; set; }
        }

        public class Status_BlockTransactions
        {
            public string Confirmed { get; set; }
            public string Block_height { get; set; }
            public string Block_hash { get; set; }
            public string Block_time { get; set; }
        }

        public class Vout_BlockTransactions
        {
            //     public string scriptpubkey { get; set; }
            //     public string scriptpubkey_asm { get; set; }
            //    public string scriptpubkey_type { get; set; }
            //    public string scriptpubkey_address { get; set; }
            public string Value { get; set; }
        }

        public static class DateTimeExtensions
        {
            public static DateTime FromUnixTimeMilliseconds(long milliseconds)
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                return dateTimeOffset.UtcDateTime;
            }
        }






        #endregion
    }
}