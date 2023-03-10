/* 
────██──██─────     _____      _______ _____                       
███████████▄───    / ____|  /\|__   __/ ____|                      
──███████████▄─   | (___   /  \  | | | (___  _   _ _ __ ___   __ _ 
──███────▀████─    \___ \ / /\ \ | |  \___ \| | | | '_ ` _ \ / _` |
──███──────███─    ____) / ____ \| |  ____) | |_| | | | | | | (_| |
──███────▄███▀─   |_____/_/    \_\_| |_____/ \__,_|_| |_| |_|\__,_| 
──█████████▀───  
──███████████▄─  Version history 🍊
──███─────▀████  0.1 This takes over where 'Statamoto' left off. More realistic version numbers this time! And hopefully a much more useful application 
──███───────███  
──███─────▄████  
──████████████─  
████████████▀──  
────██──██─────

 * Stuff to do:
 * further testing of own node connection, then add to settings once tested, with warning it might be much slower
 * bring the address screen and block list screen within the Group1timertick? Might not be practical/useful
 * check whether there are any UI scaling issues
 * handle tabbing and focus better
 * replace as many fields as possible on dashboards with selected node versions
 * test button enable/disable on block list screen in all scenarios
 * check 'first' button after reaching end of block transactions screen (and all other ends of lists)
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;
using System.Globalization;
using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;
using NBitcoin.BouncyCastle.Math;
using QBitNinja.Client;
using QBitNinja.Client.Models;
using NBitcoin.RPC;
using NBitcoin.Payment;
using QRCoder;
using System.Windows.Controls;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using Panel = System.Windows.Forms.Panel;
using System.Windows.Documents;
using System.Reflection.Emit;
using Control = System.Windows.Forms.Control;
#endregion

namespace SATSuma
{
    public partial class SATSuma : Form
    {
#region INITIALISE
        //=============================================================================================================
        //---------------------------INITIALISE------------------------------------------------------------------------
        private int intDisplayCountdownToRefresh = 0; // countdown in seconds to next refresh, for display only
        private int intAPIGroup1TimerIntervalMillisecsConstant = 60000; // milliseconds, used to reset the interval of the timer for api group1 refresh
        private int APIGroup1DisplayTimerIntervalSecsConstant = 60; // seconds, used to reset the countdown display to its original number
        // booleans used to say whether to run individual API's or not. All on/true by default.
        private bool RunBitcoinExplorerEndpointAPI = true;
        private bool RunBlockchainInfoEndpointAPI = true;
        private bool RunBitcoinExplorerOrgJSONAPI = true;
        private bool RunBlockchainInfoJSONAPI = true;
        private bool RunCoingeckoComJSONAPI = true;
        private bool RunBlockchairComJSONAPI = true;
        private bool RunMempoolSpaceLightningAPI = true;
        private string NodeURL = "https://mempool.space/api/"; // default value. Can be changed by user.
#pragma warning disable IDE0044 // Add readonly modifier
        private int APIGroup1RefreshFrequency = 1; // mins. Default value 1. Initial value only
#pragma warning restore IDE0044 // Add readonly modifier
        private int intDisplaySecondsElapsedSinceUpdate = 0; // used to count seconds since the data was last refreshed, for display only.
        private bool ObtainedHalveningSecondsRemainingYet = false; // used to check whether we know halvening seconds before we start trying to subtract from them
        private TransactionsForAddressService _transactionsForAddressService;
        private readonly BlockDataService _blockService;
        private readonly TransactionService _transactionService;
        private readonly TransactionsForBlockService _transactionsForBlockService;
        private int TotalAddressTransactionRowsAdded = 0; // keeps track of how many rows of Address transactions have been added to the listview
        private int TotalBlockTransactionRowsAdded = 0; // keeps track of how many rows of Block transactions have been added to the listview
        private string mempoolConfUnconfOrAllTx = ""; // used to keep track of whether we're doing transactions requests for conf, unconf, or all transactions
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
        bool btnViewTransactionsFromBlockListWasEnabled = false;
        bool btnPreviousBlockTransactionsWasEnabled = false;
        bool btnNextBlockTransactionsWasEnabled = false;
        bool textBoxSubmittedBlockNumberWasEnabled = true;
        bool textBoxSubmittedAddressWasEnabled = true;
        bool btnNextBlockWasEnabled = false;
        bool btnPreviousBlockWasEnabled = true;
        bool btnNewer15BlocksWasEnabled = false;
        bool btnOlder15BlocksWasEnabled = true;
        bool textBoxBlockHeightToStartListFromWasEnabled = true;
        private int TransactionOutputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event
        private int TransactionInputsScrollPosition = 0; // used to remember position in scrollable panel to return to that position after paint event

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]  // needed for the code that moves the form as not using a standard control
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")] // needed for the code that moves the form as not using a standard control

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public SATSuma()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            _transactionsForAddressService = new TransactionsForAddressService(NodeURL);
            _blockService = new BlockDataService(NodeURL);
            _transactionsForBlockService = new TransactionsForBlockService(NodeURL);
            _transactionService = new TransactionService(NodeURL);
        }

        private void Form1_Load(object sender, EventArgs e) // on form loading
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string BlockTipURL = NodeURL + "blocks/tip/height";
                    string BlockTip = client.DownloadString(BlockTipURL); // get current block tip
                    lblBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        lblBlockNumber.Text = BlockTip;
                    });
                }
                UpdateAPIGroup1DataFields(); // setting them now avoids waiting a whole minute for the first refresh
                StartTheClocksTicking(); // start all the timers
                textboxSubmittedAddress.Invoke((MethodInvoker)delegate
                {
                    textboxSubmittedAddress.Text = "bc1qnymv08yth53u4zfyqxfjp5wu0kxl3d57pka0q7"; // initial value for testing purposes
                });
                CheckBlockchainExplorerApiStatus();
                mempoolConfUnconfOrAllTx = "chain"; // valid values are chain, mempool or all
                btnShowConfirmedTX.Enabled = false; // already looking at confirmed transactions to start with
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Form1_Load, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Form1_Load, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Form1_Load, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Form1_Load, " + ex.Message;
                });
            }
        }
#endregion

#region CLOCK TICK EVENTS
        //=============================================================================================================
        // -------------------------CLOCK TICKS------------------------------------------------------------------------
        private void StartTheClocksTicking()
        {
            intDisplayCountdownToRefresh = (APIGroup1RefreshFrequency * 60); //turn minutes into seconds. This is the number used to display remaning time until refresh
            APIGroup1DisplayTimerIntervalSecsConstant = (APIGroup1RefreshFrequency * 60); //turn minutes into seconds. This is kept constant and used to reset the timer to this number
            intAPIGroup1TimerIntervalMillisecsConstant = ((APIGroup1RefreshFrequency * 60) * 1000); // turn minutes into seconds, then into milliseconds
            timerAPIGroup1.Interval = intAPIGroup1TimerIntervalMillisecsConstant; // set the timer interval
            timer1Sec.Start(); // timer used to refresh the clock values
            timerAPIGroup1.Start(); // timer used to refresh most btc data
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
            if (ObtainedHalveningSecondsRemainingYet) // only want to do this if we've already retrieved seconds remaining until halvening
            {
                string secondsString = lblHalveningSecondsRemaining.Text;
                int SecondsToHalving = int.Parse(secondsString);
                if (SecondsToHalving > 0)
                {
                    SecondsToHalving--; // one second closer to the halvening!
                    lblHalveningSecondsRemaining.Invoke((MethodInvoker)delegate
                    {
                        lblHalveningSecondsRemaining.Text = SecondsToHalving.ToString();
                    });
                }
            }
           
            if (intDisplayCountdownToRefresh < 11) // when there are only 10 seconds left until the refresh...
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

        private void TimerAPIGroup1_Tick(object sender, EventArgs e) // update the btc/lightning dashboard fields
        {
            try
            {
                ClearAlertAndErrorMessage(); // wipe anything that may be showing in the error area (it should be empty anyway)
                                             // get current block height before anything else
                using (WebClient client = new WebClient())
                {
                    string BlockTipURL = NodeURL + "blocks/tip/height";
                    string BlockTip = client.DownloadString(BlockTipURL); // get current block tip
                    lblBlockNumber.Invoke((MethodInvoker)delegate
                    {
                        lblBlockNumber.Text = BlockTip;
                    });
                }
                UpdateAPIGroup1DataFields(); // fetch data and populate fields
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TimerAPIGroup1_Tick, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TimerAPIGroup1_Tick, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TimerAPIGroup1_Tick, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TimerAPIGroup1_Tick, " + ex.Message;
                });
            }
        }

#endregion

#region BITCOIN AND LIGHTNING DASHBOARD SPECIFIC STUFF
        //==============================================================================================================================================================================================
        //======================BITCOIN AND LIGHTNING DASHBOARD SPECIFIC STUFF==========================================================================================================================
        //=============================================================================================================
        //-------------------------UPDATE FORM FIELDS------------------------------------------------------------------

        public async void UpdateAPIGroup1DataFields()
        {
            DisableEnableLoadingAnimation("enable");
            
            using (WebClient client = new WebClient())
            {
                bool errorOccurred = false;
                Task task1 = Task.Run(() =>  // call bitcoinexplorer.org endpoints and populate the fields on the form
                {
                    try
                    {
                        if (RunBitcoinExplorerEndpointAPI)
                        {
                            var (priceUSD, moscowTime, marketCapUSD, difficultyAdjEst, txInMempool) = BitcoinExplorerOrgEndpointsRefresh();
                            // move returned data to the labels on the form
                            lblPriceUSD.Invoke((MethodInvoker)delegate
                            {
                                lblPriceUSD.Text = priceUSD;
                            });
                            lblMoscowTime.Invoke((MethodInvoker)delegate
                            {
                                lblMoscowTime.Text = moscowTime;
                            });
                            lblMarketCapUSD.Invoke((MethodInvoker)delegate
                            {
                                lblMarketCapUSD.Text = marketCapUSD;
                            });
                            lblDifficultyAdjEst.Invoke((MethodInvoker)delegate
                            {
                                lblDifficultyAdjEst.Text = difficultyAdjEst;
                            });
                            lblBlockListNextDifficultyAdjustment.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListNextDifficultyAdjustment.Text = difficultyAdjEst;
                            });
                            lblTXInMempool.Invoke((MethodInvoker)delegate
                            {
                                lblTXInMempool.Text = txInMempool;
                            });
                            lblBlockListTXInMempool.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListTXInMempool.Text = txInMempool;
                            });
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
                            lblDifficultyAdjEst.Invoke((MethodInvoker)delegate
                            {
                                lblDifficultyAdjEst.Text = "disabled";
                            });
                            lblBlockListNextDifficultyAdjustment.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListNextDifficultyAdjustment.Text = "disabled";
                            });
                            lblTXInMempool.Invoke((MethodInvoker)delegate
                            {
                                lblTXInMempool.Text = "disabled";
                            });
                            lblBlockListTXInMempool.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListTXInMempool.Text = "disabled";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task2 = Task.Run(() => // call blockchain.info endpoints and populate the fields on the form
                {
                    try
                    {
                        if (RunBlockchainInfoEndpointAPI)
                        {
                            var (avgNoTransactions, blockNumber, blockReward, estHashrate, avgTimeBetweenBlocks, btcInCirc, hashesToSolve, twentyFourHourTransCount, twentyFourHourBTCSent) = BlockchainInfoEndpointsRefresh();
                            // move returned data to the labels on the form
                            lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblAvgNoTransactions.Text = avgNoTransactions;
                            });
//                            lblBlockNumber.Invoke((MethodInvoker)delegate
//                            {
//                                lblBlockNumber.Text = blockNumber;
//                            });
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
                            lblBlockListBlockReward.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListBlockReward.Text = blockReward;
                            });
                            lblEstHashrate.Invoke((MethodInvoker)delegate
                            {
                                lblEstHashrate.Text = estHashrate;
                            });
                            lblBlockListEstHashRate.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListEstHashRate.Text = estHashrate;
                            });
                            lblAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate
                            {
                                lblAvgTimeBetweenBlocks.Text = avgTimeBetweenBlocks;
                            });
                            lblBlockListAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListAvgTimeBetweenBlocks.Text = avgTimeBetweenBlocks;
                            });
                            lblBTCInCirc.Invoke((MethodInvoker)delegate
                            {
                                lblBTCInCirc.Text = btcInCirc + " / 21000000";
                            });
                            lblHashesToSolve.Invoke((MethodInvoker)delegate
                            {
                                lblHashesToSolve.Text = hashesToSolve;
                            });
                            lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // Blocks list
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
//                            lblBlockNumber.Invoke((MethodInvoker)delegate
//                            {
//                                lblBlockNumber.Text = "disabled";
//                            });
                            lblBlockReward.Invoke((MethodInvoker)delegate
                            {
                                lblBlockReward.Text = "disabled";
                            });
                            lblBlockListBlockReward.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListBlockReward.Text = "disabled";
                            });
                            lblBlockRewardAfterHalving.Invoke((MethodInvoker)delegate
                            {
                                lblBlockRewardAfterHalving.Text = "disabled";
                            });
                            lblEstHashrate.Invoke((MethodInvoker)delegate
                            {
                                lblEstHashrate.Text = "disabled";
                            });
                            lblAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate
                            {
                                lblAvgTimeBetweenBlocks.Text = "disabled";
                            });
                            lblBlockListAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListAvgTimeBetweenBlocks.Text = "disabled";
                            });
                            lblBTCInCirc.Invoke((MethodInvoker)delegate
                            {
                                lblBTCInCirc.Text = "disabled";
                            });
                            lblHashesToSolve.Invoke((MethodInvoker)delegate
                            {
                                lblHashesToSolve.Text = "disabled";
                            });
                            lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // Blocks list
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
                            lblBlockListEstHashRate.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListEstHashRate.Text = "disabled";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task3 = Task.Run(() => // call Bitcoinexplorer.org JSON
                {
                    try
                    {
                        if (RunBitcoinExplorerOrgJSONAPI)
                        {
                            var (nextBlockFee, thirtyMinFee, sixtyMinFee, oneDayFee, txInNextBlock, nextBlockMinFee, nextBlockMaxFee, nextBlockTotalFees) = BitcoinExplorerOrgJSONRefresh();
                            // move returned data to the labels on the form
                            lblfeesNextBlock.Invoke((MethodInvoker)delegate
                            {
                                lblfeesNextBlock.Text = nextBlockFee;
                            });
                            lblFees30Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees30Mins.Text = thirtyMinFee;
                            });
                            lblFees60Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees60Mins.Text = sixtyMinFee;
                            });
                            lblFees1Day.Invoke((MethodInvoker)delegate
                            {
                                lblFees1Day.Text = oneDayFee;
                            });
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
                            lblfeesNextBlock.Invoke((MethodInvoker)delegate
                            {
                                lblfeesNextBlock.Text = "n/a";
                            });
                            lblFees30Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees30Mins.Text = "n/a";
                            });
                            lblFees60Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees60Mins.Text = "n/a";
                            });
                            lblFees1Day.Invoke((MethodInvoker)delegate
                            {
                                lblFees1Day.Text = "n/a";
                            });
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
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task4 = Task.Run(() => //call blockchain.info JSON
                {
                    try
                    {
                        if (RunBlockchainInfoJSONAPI)
                        {
                            var (n_tx, size, nextretarget) = BlockchainInfoJSONRefresh();
                            // move returned data to the labels on the form
                            lblTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblTransactions.Text = n_tx;
                            });
                            lblBlockSize.Invoke((MethodInvoker)delegate
                            {
                                lblBlockSize.Text = size;
                            });
                            lblNextDifficultyChange.Invoke((MethodInvoker)delegate
                            {
                                lblNextDifficultyChange.Text = nextretarget;
                            });
                            lblBlockListNextDiffAdjBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListNextDiffAdjBlock.Text = nextretarget;
                            });
                        }
                        else
                        {
                            lblTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblTransactions.Text = "disabled";
                            });
                            lblBlockSize.Invoke((MethodInvoker)delegate
                            {
                                lblBlockSize.Text = "disabled";
                            });
                            lblNextDifficultyChange.Invoke((MethodInvoker)delegate
                            {
                                lblNextDifficultyChange.Text = "disabled";
                            });
                            lblBlockListNextDiffAdjBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListNextDiffAdjBlock.Text = "disabled";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task5 = Task.Run(() => // call CoinGecko.com JSON
                {
                    try
                    {
                        if (RunCoingeckoComJSONAPI)
                        {
                            var (ath, athDate, athDifference, twentyFourHourHigh, twentyFourHourLow) = CoingeckoComJSONRefresh();
                            // move returned data to the labels on the form
                            lblATH.Invoke((MethodInvoker)delegate
                            {
                                lblATH.Text = ath;
                            });
                            lblATHDate.Invoke((MethodInvoker)delegate
                            {
                                lblATHDate.Location = new Point(lblATH.Location.X + lblATH.Width, lblATHDate.Location.Y); // place the ATH date according to the width of the ATH (future proofed for hyperbitcoinization!)
                                lblATHDate.Text = "(" + athDate + ")";
                            });
                            lblATHDifference.Invoke((MethodInvoker)delegate
                            {
                                lblATHDifference.Text = athDifference;
                            });
                            lbl24HrHigh.Invoke((MethodInvoker)delegate
                            {
                                lbl24HrHigh.Text = twentyFourHourHigh + " / " + twentyFourHourLow;
                            });
                        }
                        else
                        {
                            lblATH.Invoke((MethodInvoker)delegate
                            {
                                lblATH.Text = "disabled";
                            });
                            lblATHDate.Invoke((MethodInvoker)delegate
                            {
                                lblATHDate.Location = new Point(lblATH.Location.X + lblATH.Width, lblATHDate.Location.Y); // place the ATH date according to the width of the ATH (future proofed for hyperbitcoinization!)
                                lblATHDate.Text = "(" + "disabled" + ")";
                            });
                            lblATHDifference.Invoke((MethodInvoker)delegate
                            {
                                lblATHDifference.Text = "disabled";
                            });
                            lbl24HrHigh.Invoke((MethodInvoker)delegate
                            {
                                lbl24HrHigh.Text = "disabled";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task6 = Task.Run(() => //call mempool.space lightning JSON
                {
                    try
                    {
                        if (RunMempoolSpaceLightningAPI)
                        {
                            var (channelCount, nodeCount, totalCapacity, torNodes, clearnetNodes, unannouncedNodes, avgCapacity, avgFeeRate, avgBaseeFeeMtokens, medCapacity, medFeeRate, medBaseeFeeMtokens, clearnetTorNodes) = MempoolSpaceLightningJSONRefresh();
                            // move returned data to the labels on the form
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
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task7 = Task.Run(() =>  // call blockchair.com endpoints and populate the fields on the form
                {
                    try
                    {
                        if (RunBlockchairComJSONAPI)
                        {
                            var result7 = BlockchairComJSONRefresh();
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
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                Task task8 = Task.Run(() =>  // call blockchair.com endpoints and populate the fields on the form
                {
                    try
                    {
                        if (RunBlockchairComJSONAPI)
                        {
                            var (halveningBlock, halveningReward, halveningTime, blocksLeft, seconds_left) = BlockchairComHalvingJSONRefresh();
                            lblHalveningBlock.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningBlock.Text = halveningBlock + " / " + blocksLeft;
                            });
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
                            lblHalveningSecondsRemaining.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningSecondsRemaining.Location = new Point(lblEstimatedHalvingDate.Location.X + lblEstimatedHalvingDate.Width - 8, lblEstimatedHalvingDate.Location.Y);
                                lblHalveningSecondsRemaining.Text = seconds_left;
                                ObtainedHalveningSecondsRemainingYet = true; // signifies that we can now start deducting from this
                            });
                        }
                        else
                        {
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
                            lblHalveningSecondsRemaining.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningSecondsRemaining.Text = "disabled";
                            });
                        }
                        SetLightsMessagesAndResetTimers();
                    }
                    catch (Exception ex)
                    {
                        errorOccurred = true;
                        lblAlert.Invoke((MethodInvoker)delegate
                        {
                            lblAlert.Text = "⚠️";
                        });
                        lblErrorMessage.Invoke((MethodInvoker)delegate
                        {
                            lblErrorMessage.Text = ex.Message; // move returned error to the error message label on the form
                        });
                    }
                });

                await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, task8);

                // If any errors occurred with any of the API calls, a decent error message has already been displayed. Now display the red light and generic error.
                if (errorOccurred)
                {
                    intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                    // lblAlert.Invoke((MethodInvoker)delegate
                    // {
                    //     lblAlert.Text = "⚠️";
                    // });
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.ForeColor = Color.Red;
                    });
                    lblStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblStatusLight.Text = "🔴"; // red light
                    });
                    lblStatusMessPart1.Invoke((MethodInvoker)delegate
                    {
                        lblStatusMessPart1.Text = "One or more fields failed to update";
                    });
                }
            }
            DisableEnableLoadingAnimation("disable");
        }

        //=============================================================================================================
        //-----------------------BITCOIN AND LIGHTNING DASHBOARD API CALLS---------------------------------------------
        //------BitcoinExplorer and BlockchainInfo endpoints 
        private (string priceUSD, string moscowTime, string marketCapUSD, string difficultyAdjEst, string txInMempool) BitcoinExplorerOrgEndpointsRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                string priceUSD = client.DownloadString("https://bitcoinexplorer.org/api/price/usd"); // 1 bitcoin = ? usd
                string moscowTime = client.DownloadString("https://bitcoinexplorer.org/api/price/usd/sats"); // 1 usd = ? sats
                string marketCapUSD = client.DownloadString("https://bitcoinexplorer.org/api/price/usd/marketcap"); // bitcoin market cap in usd
                string difficultyAdjEst = client.DownloadString("https://bitcoinexplorer.org/api/mining/diff-adj-estimate") + "%"; // difficulty adjustment as a percentage
                string txInMempool = client.DownloadString("https://bitcoinexplorer.org/api/mempool/count"); // total number of transactions in the mempool
                return (priceUSD, moscowTime, marketCapUSD, difficultyAdjEst, txInMempool);
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0");
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0", "0", "0", "0", "0");
        }

        //-----Mempool Lighting JSON
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
        }

        //-----BitcoinExplorer JSON
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0", "0", "0", "0");
        }

        //-----BlockchainInfo JSON
        private (string n_tx, string size, string nextretarget) BlockchainInfoJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                // LATEST BLOCK
                string jsonurl = "https://blockchain.info/rawblock/";  // use this...
                string blockNumberUrl = "https://blockchain.info/q/getblockcount";
                string blocknumber = client.DownloadString(blockNumberUrl); //combined with the result of that (we can't rely on already knowing the latest block number)
                string finalurl = jsonurl + blocknumber; // to create a url we can use to get the JSON of the latest block
                string size;
                var response3 = client.DownloadString(finalurl);
                var data3 = JObject.Parse(response3);
                var n_tx = (string)data3["n_tx"] + " transactions";  // number of transactions
                var sizeInKB = ((double)data3["size"] / 1000); // size in bytes divided by 1000 to get kb
                if (sizeInKB < 1024) // if less than 1MB
                {
                    size = sizeInKB + " KB block size";
                }
                else // if more than 1MB
                {
                    size = Convert.ToString(Math.Round((sizeInKB / 1000), 2)) + "MB block size";
                }
                // NEXT DIFFICULTY ADJUSTMENT BLOCK
                var response4 = client.DownloadString("https://api.blockchain.info/stats");
                var data4 = JObject.Parse(response4);
                var nextretarget = (string)data4["nextretarget"];
                return (n_tx, size, nextretarget);
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0");
        }

        //-----CoinGecko JSON
        private (string ath, string athDate, string athDifference, string twentyFourHourHigh, string twentyFourHourLow) CoingeckoComJSONRefresh()
        {
            try
            {
                using WebClient client = new WebClient();
                // ATH & 24hr data
                var response5 = client.DownloadString("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                var data5 = JArray.Parse(response5);
                var btcData = data5.Where(x => (string)x["symbol"] == "btc").FirstOrDefault();
                var ath = (string)btcData["ath"];  // all time high value of btc in usd
                var athDate = (string)btcData["ath_date"]; // date of the all time high
                DateTime date = DateTime.Parse(athDate); // change it to dd MMM yyyy format
                string strATHDate = date.ToString("dd MMM yyyy");
                athDate = strATHDate;
                double doubleathDifference = (double)btcData["ath_change_percentage"]; // percentage change from ATH to multiple decimal places
                string formattedAthDifference = doubleathDifference.ToString("0.00"); // round it to 2 decimal places before sending it back
                string athDifference = Convert.ToString(formattedAthDifference);

                var twentyFourHourHigh = (string)btcData["high_24h"]; // highest value of btc in usd over last 24 hours
                var twentyFourHourLow = (string)btcData["low_24h"]; // lowest value of btc in usd over last 24 hours
                return (ath, athDate, athDifference, twentyFourHourHigh, twentyFourHourLow);
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0");
        }

        //-----Blockchair JSON
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0", "0");
        }

        private (string hodling_addresses, string blocks_24h, string nodes, string blockchain_size) BlockchairComJSONRefresh()
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = ex.Message;
                });
            }

            lblAlert.Invoke((MethodInvoker)delegate
            {
                lblAlert.Text = "⚠️";
            });
            return ("0", "0", "0", "0");
        }

        //=============================================================================================================
        //---------------------- CONNECTING LINES BETWEEN FIELDS ON LIGHTNING DASHBOARD -------------------------------
        private void PanelLightningDashboard_Paint(object sender, PaintEventArgs e)
        {
            using Pen pen = new Pen(Color.FromArgb(106, 72, 9), 1);
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

#region ADDRESS SCREEN STUFF
        //==============================================================================================================================================================================================
        //======================== ADDRESS TAB =========================================================================================================================================================
        //=============================================================================================================
        //---------------------- DETERMINE BITCOIN ADDRESS TYPE--------------------------------------------------------
        private string DetermineAddressType(string address)
        {
            try
            {
                BitcoinAddress bitcoinAddress = BitcoinAddress.Create(address, Network.Main);
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

        //=============================================================================================================
        //--------------- VALIDATE BITCOIN ADDRESS,GENERATE QR, BALANCE, TX, ETC---------------------------------------
        private async void TboxSubmittedAddress_TextChanged(object sender, EventArgs e)
        {
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            BtnViewBlockFromAddress.Visible = false;
            BtnViewTransactionFromAddress.Visible = false;
            listViewAddressTransactions.Items.Clear(); // wipe any data in the transaction listview
            TotalAddressTransactionRowsAdded = 0;

            if (textboxSubmittedAddress.Text == "")
            {
                AddressInvalidHideControls();
            }
            else
            {
                AddressValidShowControls();
            }
            string addressString = textboxSubmittedAddress.Text; //user entered address
            string addressType = DetermineAddressType(addressString); // check address is valid and what type of address
            if (addressType == "P2PKH (legacy)" || addressType == "P2SH" || addressType == "P2WPKH (segwit)" || addressType == "P2WSH" || addressType == "P2TT (taproot)" || addressType == "unknown") // address is valid
            {
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
                    lblAlert.Invoke((MethodInvoker)delegate
                    {
                        lblAlert.Text = "⚠️";
                    });
                    lblErrorMessage.Invoke((MethodInvoker)delegate
                    {
                        lblErrorMessage.Text = "Error getting address balance: " + ex.Message;
                    });
                    return;
                }
                string lastSeenTxId = ""; // start from the top of the JSON (most recent tx)
                try
                {
                    await GetTransactionsForAddress(addressString, lastSeenTxId); // get first batch of transactions
                }
                catch (Exception ex)
                {
                    lblAlert.Invoke((MethodInvoker)delegate
                    {
                        lblAlert.Text = "⚠️";
                    });
                    lblErrorMessage.Invoke((MethodInvoker)delegate
                    {
                        lblErrorMessage.Text = "Error getting first batch of transactions for address: " + ex.Message;
                    });
                    return;
                }
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
            DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
        }

        //=============================================================================================================
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
                    lblNodeStatusLight.ForeColor = Color.Red;
                    lblActiveNode.Invoke((MethodInvoker)delegate
                    {
                        lblActiveNode.Text = "Disconnected/error";
                    });
                    lblErrorMessage.Invoke((MethodInvoker)delegate
                    {
                        lblErrorMessage.Text = "Node offline/disconnected: ";
                    });
                    return;
                }
                var jsonData = await response.Content.ReadAsStringAsync();
                var addressData = JObject.Parse(jsonData);

                if (mempoolConfUnconfOrAllTx == "chain" && !PartOfAnAllAddressTransactionsRequest)  //confirmed stats only. 'All' reverts to 'chain' after the first query, so we need to exclude those
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
                if (mempoolConfUnconfOrAllTx == "mempool") //mempool stats only
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
                if (mempoolConfUnconfOrAllTx == "all" || (mempoolConfUnconfOrAllTx == "chain" && PartOfAnAllAddressTransactionsRequest)) // all TXs so will need to add chain and mempool amounts together before displaying. 
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetAddressBalance, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetAddressBalance, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetAddressBalance, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetAddressBalance " + ex.Message;
                });
            }
        }

        private async Task GetAddressBalanceAsync(string addressString)
        {
            await GetAddressBalance(addressString);
        }

        //=============================================================================================================
        //-------------------------------- GET TRANSACTIONS FOR ADDRESS -----------------------------------------------
        private async Task GetTransactionsForAddress(string addressString, string lastSeenTxId)
        {
            try
            {
                var transactionsJson = await _transactionsForAddressService.GetTransactionsForAddressAsync(addressString, mempoolConfUnconfOrAllTx, lastSeenTxId);
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
                    if (mempoolConfUnconfOrAllTx == "chain")
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
                    if (mempoolConfUnconfOrAllTx == "mempool")
                    {
                        listViewAddressTransactions.Invoke((MethodInvoker)delegate
                        {
                            listViewAddressTransactions.Columns.Add(" Transaction ID (unconfirmed)", 260);
                        });
                    }
                    if (mempoolConfUnconfOrAllTx == "all")
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
                    balanceChangeVin = (decimal)transaction.Vin // value of all inputs where address is the provided address
                        .Where(v => v.Prevout.Scriptpubkey_address == addressString)
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
                        if (mempoolConfUnconfOrAllTx != "mempool") //regardless how many unconfirmed TXs there are, the api only returns the first batch, but otherwise we can go back to first TX
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
                        if (mempoolConfUnconfOrAllTx != "mempool") //regardless how many unconfirmed TXs there are, the api only returns the first batch, but otherwise we can go to the next batch
                        {
                            btnNextAddressTransactions.Visible = true;
                        }
                    }

                    if (counter == 25) // ListView is full. stop adding rows at this point and pick up from here next time.
                    {
                        break;
                    }
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
                if (mempoolConfUnconfOrAllTx == "all") // we only do one call to the 'all' api, then have to switch to the confirmed api for subsequent calls
                {
                    mempoolConfUnconfOrAllTx = "chain";
                }
                // set focus
                if (btnNextAddressTransactions.Visible && btnNextAddressTransactions.Enabled)
                {
                    btnNextAddressTransactions.Focus();
                }
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForAddress, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForAddress, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForAddress, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForAddress: " + ex.Message;
                });
            }
        }

        private async void BtnGetNextTransactionsForAddress(object sender, EventArgs e)
        {
            DisableEnableLoadingAnimation("enable"); // start the loading animation
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
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
            BtnViewBlockFromAddress.Visible = false;
            BtnViewTransactionFromAddress.Visible = false;
        }

        private async void BtnFirstTransactionForAddress_Click(object sender, EventArgs e)
        {
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            if (PartOfAnAllAddressTransactionsRequest) // if this was originally a list of 'all' TXs which switched to 'chain', switch back to 'all' to get the unconfirmed again first
            {
                mempoolConfUnconfOrAllTx = "all";
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
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
        }

        private void BtnShowUnconfirmedTXForAddress_Click(object sender, EventArgs e)
        {
            btnShowConfirmedTX.Enabled = true;
            btnShowAllTX.Enabled = true;
            btnShowUnconfirmedTX.Enabled = false;
            mempoolConfUnconfOrAllTx = "mempool";
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

        private void BtnShowConfirmedTXForAddress_Click(object sender, EventArgs e)
        {
            btnShowConfirmedTX.Enabled = false;
            btnShowAllTX.Enabled = true;
            btnShowUnconfirmedTX.Enabled = true;
            mempoolConfUnconfOrAllTx = "chain";
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

        private void BtnShowAllTXForAddress_Click(object sender, EventArgs e)
        {
            btnShowConfirmedTX.Enabled = true;
            btnShowAllTX.Enabled = false;
            btnShowUnconfirmedTX.Enabled = true;
            mempoolConfUnconfOrAllTx = "all";
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewBlockFromAddress, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewBlockFromAddress, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewBlockFromAddress, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewBlockFromAddress: " + ex.Message;
                });
            }
            //show the block screen
            BtnMenuBlock_Click(sender, e);
        }

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

        //=============================================================================================================
        //--------------- OVERRIDE COLOURS FOR LISTVIEW HEADINGS ------------------------------------------------------
        private void ListViewAddressTransactions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

        //=============================================================================================================
        //------------------------ CHANGE COLOUR OF SELECTED ROW ------------------------------------------------------
        private void ListViewAddressTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool anySelected = false;
            foreach (ListViewItem item in listViewAddressTransactions.Items)
            {
                if (item.Selected)
                {
                    item.ForeColor = Color.White; // txID
                    item.SubItems[1].ForeColor = Color.White; //Block 
                    anySelected = true;
                    BtnViewTransactionFromAddress.Invoke((MethodInvoker)delegate
                    {
                        BtnViewTransactionFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width - BtnViewTransactionFromAddress.Width - 8, item.Position.Y + listViewAddressTransactions.Location.Y - 2);
                    });
                    BtnViewBlockFromAddress.Invoke((MethodInvoker)delegate
                    {
                        BtnViewBlockFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Columns[1].Width - BtnViewBlockFromAddress.Width - 3, item.Position.Y + listViewAddressTransactions.Location.Y - 2);
                    });
                }
                else
                {
                    item.ForeColor = Color.FromArgb(255, 153, 0); //txID
                    item.SubItems[1].ForeColor = Color.FromArgb(255, 153, 0); //Block
                }
            }
            BtnViewTransactionFromAddress.Visible = anySelected;
            BtnViewBlockFromAddress.Visible = anySelected;
        }

        //=============================================================================================================
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
                e.Graphics.FillRectangle(new SolidBrush(listViewAddressTransactions.BackColor), bounds);
                TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
            }
            else if (textWidth < columnWidth)
            {
                // Clear the background
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                e.Graphics.FillRectangle(new SolidBrush(listViewAddressTransactions.BackColor), bounds);

                TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
            }
        }

        //=============================================================================================================
        //------------------ LIMIT MINIMUM WIDTH OF LISTVIEW COLUMNS --------------------------------------------------
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

        private void AddressValidShowControls() // show all address related controls
        {
            if (mempoolConfUnconfOrAllTx == "mempool")//only one page of unconfirmed tx regardless how many tx there are
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
        }

        private void AddressInvalidHideControls() // hide all address related controls
        {
            btnNextAddressTransactions.Visible = false;
            btnFirstAddressTransaction.Visible = false;
            lblAddressTXPositionInList.Visible = false;
            label59.Visible = false;
            label61.Visible = false;
            label67.Visible = false;
            label63.Visible = false;
            listViewAddressTransactions.Visible = false;
        }
#endregion

#region BLOCK SCREEN STUFF
        //==============================================================================================================================================================================================
        //====================== BLOCK SCREEN STUFF ====================================================================================================================================================
        //=============================================================================================================
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TextBoxSubmittedBlockNumber_KeyPress, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TextBoxSubmittedBlockNumber_KeyPress, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TextBoxSubmittedBlockNumber_KeyPress, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "TextBoxSubmittedBlockNumber_KeyPress: " + ex.Message;
                });
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
                DisableEnableLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                await GetFifteenBlocks(blockNumber);
                string BlockHashToGetTransactionsFor = lblBlockHash.Text;
                await GetTransactionsForBlock(BlockHashToGetTransactionsFor, "0");
                DisableEnableLoadingAnimation("disable"); // stop the loading animation
                DisableEnableButtons("enable"); // enable buttons after operation is complete
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlock, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlock, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlock, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlock: " + ex.Message;
                });
            }
        }

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
                    lblBlockFeeRangeAndMedianFee.Text = Convert.ToString(blocks[0].Extras.FeeRange[0]) + "-" + Convert.ToString(blocks[0].Extras.FeeRange[6]) + " / " + Convert.ToString(blocks[0].Extras.MedianFee);
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocks, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocks, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocks, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocks: " + ex.Message;
                });
            }
        }

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForBlock, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForBlock, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForBlock, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransactionsForBlock: " + ex.Message;
                });
            }
        }

        private async void BtnNextBlockTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                DisableEnableLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
                                                   // Get the last seen transaction ID from the list view
                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                                                                                                 // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction);
                DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
                DisableEnableLoadingAnimation("disable"); // stop the loading animation
                btnViewTransactionFromBlock.Visible = false;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlockTransactions_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlockTransactions_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlockTransactions_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlockTransactions_Click: " + ex.Message;
                });
            }
        }

        private async void BtnPreviousBlockTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                DisableEnableLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
                                                   // Get the last seen transaction ID from the list view
                TotalBlockTransactionRowsAdded -= 50;
                var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
                                                                                                 // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
                await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction);
                DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
                DisableEnableLoadingAnimation("disable"); // stop the loading animation
                btnViewTransactionFromBlock.Visible = false;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlockTransactions_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlockTransactions_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlockTransactions_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlockTransactions_Click: " + ex.Message;
                });
            }
        }

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlock_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlock_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlock_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnPreviousBlock_Click: " + ex.Message;
                });
            }
        }

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlock_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlock_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlock_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNextBlock_Click: " + ex.Message;
                });
            }
        }

        private void ListViewBlockTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewBlockTransactions.Items)
                {
                    if (item.Selected)
                    {
                            item.ForeColor = Color.White; // txID
                        btnViewTransactionFromBlock.Invoke((MethodInvoker)delegate
                        {
                            btnViewTransactionFromBlock.Location = new Point(item.Position.X + listViewBlockTransactions.Location.X + listViewBlockTransactions.Columns[0].Width - btnViewTransactionFromBlock.Width - 8, item.Position.Y + listViewBlockTransactions.Location.Y - 2);
                        });
                        anySelected = true;
                    }
                    else
                    {
                        item.ForeColor = Color.FromArgb(255, 153, 0); //txID
                    }
                }
                btnViewTransactionFromBlock.Visible = anySelected;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockTransactions_ItemSelectionChanged, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockTransactions_ItemSelectionChanged, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockTransactions_ItemSelectionChanged, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockTransactions_ItemSelectionChanged: " + ex.Message;
                });
            }
        }

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
                if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 70) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 70;
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 40) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 40;
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 40) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 40;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (listViewBlockTransactions.Columns[e.ColumnIndex].Width != 100) // don't allow this one to change
                {
                    e.Cancel = true;
                    e.NewWidth = 100;
                }
            }
        }

        private void ListViewBlockTransactions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

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
                e.Graphics.FillRectangle(new SolidBrush(listViewBlockTransactions.BackColor), bounds);
                TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
            }
            else if (textWidth < columnWidth)
            {
                // Clear the background
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                e.Graphics.FillRectangle(new SolidBrush(listViewBlockTransactions.BackColor), bounds);

                TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
            }
        }

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionFromBlock_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionFromBlock_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionFromBlock_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionFromBlock_Click: " + ex.Message;
                });
            }
        }

        #endregion

#region TRANSACTION STUFF

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxTransactionID_KeyPress, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxTransactionID_KeyPress, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxTransactionID_KeyPress, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxTransactionID_KeyPress: " + ex.Message;
                });
            }
        }

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
                    LookupTransaction();
                }
                else
                {
                    panelTransactionHeadline.Visible = false;
                    panelTransactionDiagram.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    lblInvalidTransaction.Visible = true;
                }
            }
            else
            {
                panelTransactionHeadline.Visible = false;
                panelTransactionDiagram.Visible = false;
                panel27.Visible = false;
                panel28.Visible = false;
                lblInvalidTransaction.Visible = true;
            }
        }

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

        private async Task<bool> TransactionExists(string transactionId) // checks if the valid transaction ID actually exists
        {
            string url = NodeURL + "tx/" + transactionId;
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return response.IsSuccessStatusCode;
        }

        private async void LookupTransaction()
        {
            try
            {
                string submittedTransactionID = textBoxTransactionID.Text;
                await GetTransaction(submittedTransactionID);
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupTransaction, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupTransaction, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupTransaction, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupTransaction: " + ex.Message;
                });
            }
        }

        private async Task GetTransaction(string submittedTransactionID) 
        {
            try
            {
                linePoints.Clear();
                btnViewAddressFromTXInput.Visible = false;
                btnViewAddressFromTXOutput.Visible = false;
                //panelTransactionDiagram.Invalidate();
                //            DisableEnableLoadingAnimation("enable"); // start the loading animation
                //            DisableEnableButtons("disable"); // disable buttons during operation
                var TransactionJson = await _transactionService.GetTransactionAsync(submittedTransactionID);
                //            DisableEnableLoadingAnimation("disable"); // stop the loading animation
                //            DisableEnableButtons("enable"); // enable buttons after operation is complete
                var transaction = JsonConvert.DeserializeObject<Transaction>(TransactionJson);
                lblTransactionVersion.Invoke((MethodInvoker)delegate
                {
                    lblTransactionVersion.Text = Convert.ToString(transaction.Version);
                });
                lblTransactionLockTime.Invoke((MethodInvoker)delegate
                {
                    lblTransactionLockTime.Text = Convert.ToString(transaction.Locktime);
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
                lblTransactionBlockHeight.Invoke((MethodInvoker)delegate
                {
                    lblTransactionBlockHeight.Text = Convert.ToString(transaction.Status.Block_height);
                });
                long unixTimestamp = Convert.ToInt64(transaction.Status.Block_time);
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
                lblTransactionBlockTime.Invoke((MethodInvoker)delegate
                {
                    lblTransactionBlockTime.Text = dateTime.ToString("yyyyMMdd-HH:mm");
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
                    totalValueIn += vin.Prevout.Value;
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
                int YInputsStep = 0;
                int YInputsPos = 0;
                if (NumberOfInputLines > 1)
                {
                    YInputsStep = (panelTransactionDiagram.Size.Height - 20) / (NumberOfInputLines - 1);
                    YInputsPos = 10;
                    if (NumberOfInputLines > panelTransactionDiagram.Height)
                    {
                        YInputsStep = 1;
                    }
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
                    Point startPoint3 = new Point(10, YInputsPos);
                    Point endPoint3 = new Point(100, YInputsPos);
                    linePoints.Add(startPoint3);
                    linePoints.Add(endPoint3);
                    Point startPoint4 = new Point(100, YInputsPos);
                    Point endPoint4 = new Point((panelTransactionDiagram.Size.Width / 2) - 150, panelTransactionDiagram.Size.Height / 2);
                    linePoints.Add(startPoint4);
                    linePoints.Add(endPoint4);
                    YInputsPos += YInputsStep;
                }
                // --------------- outputs on diagram
                int NumberOfOutputLines = Convert.ToInt32(transaction.Vout.Count());
                int YOutputsStep = 0;
                int YOutputsPos = 0;
                if (NumberOfOutputLines > 1)
                {
                    YOutputsStep = (panelTransactionDiagram.Size.Height - 20) / (NumberOfOutputLines - 1);
                    YOutputsPos = 10;
                    if (NumberOfOutputLines > panelTransactionDiagram.Height)
                    {
                        YOutputsStep = 1;
                    }
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
                    Point startPoint5 = new Point(panelTransactionDiagram.Size.Width - 10, YOutputsPos);
                    Point endPoint5 = new Point(panelTransactionDiagram.Size.Width - 100, YOutputsPos);
                    linePoints.Add(startPoint5);
                    linePoints.Add(endPoint5);
                    Point startPoint6 = new Point(panelTransactionDiagram.Size.Width - 100, YOutputsPos);
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
                    string InputAddress = Convert.ToString(prevout.Scriptpubkey_address);
                    ListViewItem item = new ListViewItem(InputAddress); // create new row
                    string InputValue = Convert.ToString(prevout.Value);
                    decimal DecInputValue = ConvertSatsToBitcoin(InputValue);
                    item.SubItems.Add(DecInputValue.ToString());
                    listViewTransactionInputs.Invoke((MethodInvoker)delegate
                    {
                        listViewTransactionInputs.Items.Add(item); // add row
                    });
                }
                // Get the height of each item to set height of whole listview
                int rowHeight = listViewTransactionInputs.Margin.Vertical + listViewTransactionInputs.Padding.Vertical + listViewTransactionInputs.GetItemRect(0).Height;
                int itemCount = listViewTransactionInputs.Items.Count; // Get the number of items in the ListBox
                int listBoxHeight = (itemCount + 2) * rowHeight; // Calculate the height of the ListBox (the extra 2 gives room for the header)

                listViewTransactionInputs.Height = listBoxHeight; // Set the height of the ListBox
                panelTransactionInputs.VerticalScroll.Value = 0;
                panelTransactionInputs.VerticalScroll.Minimum = 0;

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
                    string OutputAddress = Convert.ToString(vout.Scriptpubkey_address);
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

                // Trigger a repaint of the form
                this.Invalidate();

            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransaction, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransaction, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransaction, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetTransaction: " + ex.Message;
                });
            }
        }

        private void ListViewTransactionInputs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewTransactionInputs.Items)
                {
                    if (item.Selected)
                    {
                        item.ForeColor = Color.White; // address
                        btnViewAddressFromTXInput.Invoke((MethodInvoker)delegate
                        {
                            btnViewAddressFromTXInput.Location = new Point(item.Position.X + listViewTransactionInputs.Location.X + listViewTransactionInputs.Columns[0].Width - btnViewAddressFromTXInput.Width - 8, item.Position.Y + listViewTransactionInputs.Location.Y - 2);
                        });
                        anySelected = true;
                    }
                    else
                    {
                        item.ForeColor = Color.FromArgb(255, 153, 0); //txID
                    }
                }
                btnViewAddressFromTXInput.Visible = anySelected;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged: " + ex.Message;
                });
            }
        }
        
        private void ListViewTransactionOutputs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                bool anySelected = false;
                foreach (ListViewItem item in listViewTransactionOutputs.Items)
                {
                    if (item.Selected)
                    {
                        item.ForeColor = Color.White; // address
                        btnViewAddressFromTXOutput.Invoke((MethodInvoker)delegate
                        {
                            btnViewAddressFromTXOutput.Location = new Point(item.Position.X + listViewTransactionOutputs.Location.X + listViewTransactionOutputs.Columns[0].Width - btnViewAddressFromTXOutput.Width - 8, item.Position.Y + listViewTransactionOutputs.Location.Y - 2);
                        });
                        anySelected = true;
                    }
                    else
                    {
                        item.ForeColor = Color.FromArgb(255, 153, 0); //txID
                    }
                }
                btnViewAddressFromTXOutput.Visible = anySelected;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewTransactionInputs_ItemSelectionChanged: " + ex.Message;
                });
            }
        }

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

        private void ListViewTransactionInputs_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

        private void ListViewTransactionOutputs_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

        private void ListViewTransactionInputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            var font = listViewTransactionInputs.Font;
            var columnWidth = e.Header.Width;
            var textWidth = TextRenderer.MeasureText(text, font).Width;
            if (textWidth > columnWidth)
            {
                // Truncate the text
                var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                // Clear the background
                e.Graphics.FillRectangle(new SolidBrush(listViewTransactionInputs.BackColor), bounds);
                TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
            }
            else if (textWidth < columnWidth)
            {
                // Clear the background
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                e.Graphics.FillRectangle(new SolidBrush(listViewTransactionInputs.BackColor), bounds);

                TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
            }
        }

        private void ListViewTransactionOutputs_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            var font = listViewTransactionOutputs.Font;
            var columnWidth = e.Header.Width;
            var textWidth = TextRenderer.MeasureText(text, font).Width;
            if (textWidth > columnWidth)
            {
                // Truncate the text
                var maxText = text.Substring(0, text.Length * columnWidth / textWidth - 3) + "...";
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);
                // Clear the background
                e.Graphics.FillRectangle(new SolidBrush(listViewTransactionOutputs.BackColor), bounds);
                TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
            }
            else if (textWidth < columnWidth)
            {
                // Clear the background
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                e.Graphics.FillRectangle(new SolidBrush(listViewTransactionOutputs.BackColor), bounds);

                TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
            }


            
        }

        // draw all the lines on the transaction diagram from the previously stored list.
        private void PanelTransactionDiagram_Paint(object sender, PaintEventArgs e) 
        {
            Pen pen = new Pen(Color.FromArgb(106, 72, 9));

            // Iterate over the stored list of points and draw lines between them
            for (int i = 0; i < linePoints.Count - 1; i += 2)
            {
                e.Graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
            }
        }

        private void BtnTransactionInputsDown_Click(object sender, EventArgs e)
        {
            if (panelTransactionInputs.VerticalScroll.Value < panelTransactionInputs.VerticalScroll.Maximum)
            {
                panelTransactionInputs.VerticalScroll.Value++;
            }
        }

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (isInputButtonPressed)
            {
                if (InputDownButtonPressed)
                {
                    if (panelTransactionInputs.VerticalScroll.Value < panelTransactionInputs.VerticalScroll.Maximum - 4)
                    {
                        panelTransactionInputs.VerticalScroll.Value = panelTransactionInputs.VerticalScroll.Value + 4;
                        TransactionInputsScrollPosition = panelTransactionInputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    TXInScrollTimer.Interval = 2; // set a faster interval while the button is held down
                }
                else if (InputUpButtonPressed)
                {
                    if (panelTransactionInputs.VerticalScroll.Value > panelTransactionInputs.VerticalScroll.Minimum + 4)
                    {
                        panelTransactionInputs.VerticalScroll.Value = panelTransactionInputs.VerticalScroll.Value - 4;
                        TransactionInputsScrollPosition = panelTransactionInputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    TXInScrollTimer.Interval = 2; // set a faster interval while the button is held down
                }
            }
            else
            {
                TXInScrollTimer.Stop();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (isOutputButtonPressed)
            {
                if (OutputDownButtonPressed)
                {
                    if (panelTransactionOutputs.VerticalScroll.Value < panelTransactionOutputs.VerticalScroll.Maximum - 4)
                    {
                        panelTransactionOutputs.VerticalScroll.Value = panelTransactionOutputs.VerticalScroll.Value + 4;
                        TransactionOutputsScrollPosition = panelTransactionOutputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    TXOutScrollTimer.Interval = 2; // set a faster interval while the button is held down
                }
                else if (OutputUpButtonPressed)
                {
                    if (panelTransactionOutputs.VerticalScroll.Value > panelTransactionOutputs.VerticalScroll.Minimum + 4)
                    {
                        panelTransactionOutputs.VerticalScroll.Value = panelTransactionOutputs.VerticalScroll.Value - 4;
                        TransactionOutputsScrollPosition = panelTransactionOutputs.VerticalScroll.Value; // store the scroll position to reposition on the paint event
                    }
                    TXOutScrollTimer.Interval = 2; // set a faster interval while the button is held down
                }
            }
            else
            {
                TXOutScrollTimer.Stop();
            }
        }

        private void BtnTransactionInputsUp_Click(object sender, EventArgs e)
        {
            if (panelTransactionInputs.VerticalScroll.Value > panelTransactionInputs.VerticalScroll.Minimum)
            {
                panelTransactionInputs.VerticalScroll.Value--;
            }
        }

        private void BtnTransactionOutputsUp_Click(object sender, EventArgs e)
        {
            if (panelTransactionOutputs.VerticalScroll.Value > panelTransactionOutputs.VerticalScroll.Minimum)
            {
                panelTransactionOutputs.VerticalScroll.Value--;
            }
        }

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewAddressFromTXInput_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewAddressFromTXInput_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewAddressFromTXInput_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewAddressFromTXInput_Click: " + ex.Message;
                });
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewAddressFromTXOutput_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewAddressFromTXOutput_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewAddressFromTXOutput_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnViewAddressFromTXOutput_Click: " + ex.Message;
                });
            }
        }

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

#region BLOCK LIST STUFF

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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxBlockHeightToStartListFrom_KeyPress, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxBlockHeightToStartListFrom_KeyPress, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxBlockHeightToStartListFrom_KeyPress, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "textBoxBlockHeightToStartListFrom_KeyPress: " + ex.Message;
                });
            }
        }

        private void TextBoxBlockHeightToStartListFrom_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
            {
                textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                {
                    textBoxBlockHeightToStartListFrom.Text = "0";
                });
            }
            if (textBoxBlockHeightToStartListFrom.Text == lblBlockNumber.Text)
            {
            }
            
        }

        private async void LookupBlockList()
        {
            try
            {
                btnViewBlockFromBlockList.Visible = false;
                btnViewTransactionsFromBlockList.Visible = false;
                var blockNumber = Convert.ToString(textBoxBlockHeightToStartListFrom.Text);
                //            DisableEnableLoadingAnimation("enable"); // start the loading animation
                //            DisableEnableButtons("disable"); // disable buttons during operation
                await GetFifteenBlocksForBlockList(blockNumber); // overkill on this occasion, because we're only interested in one block, but this gets us the data
                                                                 //            DisableEnableLoadingAnimation("disable"); // stop the loading animation
                                                                 //            DisableEnableButtons("enable"); // enable buttons after operation is complete
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlockList, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlockList, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlockList, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "LookupBlockList: " + ex.Message;
                });
            }
        }

        private async Task GetFifteenBlocksForBlockList(string lastSeenBlockNumber)
        {
            try
            {
                DisableEnableLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation

                var blocksJson = await _blockService.GetBlockDataAsync(lastSeenBlockNumber);

                DisableEnableLoadingAnimation("disable"); // stop the loading animation
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
                    string feerange = Convert.ToString(block.Extras.FeeRange[0]) + "-" + Convert.ToString(block.Extras.FeeRange[6]);
                    item.SubItems.Add(feerange.ToString());
                    string medFee = "~" + block.Extras.MedianFee;
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocksForBlockList, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocksForBlockList, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocksForBlockList, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "GetFifteenBlocksForBlockList: " + ex.Message;
                });
            }
        }

        private async void BtnOlder15Blocks_Click(object sender, EventArgs e)
        {
            try
            {
                int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) - 1);
                string blockNumber = Convert.ToString(blockheight);
                // Get 15 more blocks starting from the current block height minus the number we've already seen
                await GetFifteenBlocksForBlockList(blockNumber);
                btnViewBlockFromBlockList.Visible = false;
                btnViewTransactionsFromBlockList.Visible = false;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnOlder15Blocks_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnOlder15Blocks_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnOlder15Blocks_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnOlder15Blocks_Click: " + ex.Message;
                });
            }
        }

        private async void BtnNewer15Blocks_Click(object sender, EventArgs e)
        {
            try
            {
                int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) + 29);
                string blockNumber = Convert.ToString(blockheight);
                // Get 15 more blocks starting from the current block height minus the number we've already seen
                await GetFifteenBlocksForBlockList(blockNumber);
                btnViewBlockFromBlockList.Visible = false;
                btnViewTransactionsFromBlockList.Visible = false;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNewer15Blocks_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNewer15Blocks_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNewer15Blocks_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnNewer15Blocks_Click: " + ex.Message;
                });
            }
        }

        private void ListViewBlockList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
            
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
                        btnViewTransactionsFromBlockList.Enabled = true;
                        item.SubItems[1].ForeColor = Color.White; // Block number
                        item.SubItems[2].ForeColor = Color.White; // TX count
                        anySelected = true;
                        btnViewBlockFromBlockList.Invoke((MethodInvoker)delegate
                        {
                            btnViewBlockFromBlockList.Location = new Point(item.Position.X + listViewBlockList.Location.X + listViewBlockList.Columns[0].Width + listViewBlockList.Columns[1].Width - btnViewBlockFromBlockList.Width - 3, item.Position.Y + listViewBlockList.Location.Y - 1);
                        });
                        btnViewTransactionsFromBlockList.Invoke((MethodInvoker)delegate
                        {
                            btnViewTransactionsFromBlockList.Location = new Point(item.Position.X + listViewBlockList.Location.X + listViewBlockList.Columns[0].Width + listViewBlockList.Columns[1].Width + listViewBlockList.Columns[2].Width - btnViewBlockFromBlockList.Width - 10, item.Position.Y + listViewBlockList.Location.Y - 1);
                        });
                        // display block hash
                        using (WebClient client = new WebClient())
                        {
                            string BlockHashURL = NodeURL + "block-height/" + item.SubItems[1].Text;
                            string BlockHash = client.DownloadString(BlockHashURL); // get hash of provided block
                            lblBlockListBlockHash.Invoke((MethodInvoker)delegate
                            {
                                lblBlockListBlockHash.Text = BlockHash;
                            });
                        }
                        string blockNumber = item.SubItems[1].Text;
                        DisableEnableLoadingAnimation("enable"); // start the loading animation
                        DisableEnableButtons("disable"); // disable buttons during operation
                        var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                        DisableEnableLoadingAnimation("disable"); // stop the loading animation
                        DisableEnableButtons("enable"); // enable buttons after operation is complete
                        var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                        List<string> blocklist = blocks.Select(t => t.Height).ToList();
                        lblBlockListBlockTime.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].Timestamp)).ToString("yyyy-MM-dd HH:mm");
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
                        });
                        string strWeight = Convert.ToString(blocks[0].Weight);
                        decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
                        string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
                        lblBlockListBlockWeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockWeight.Text = strFormattedWeight;
                        });
                        long nonceLong = Convert.ToInt64(blocks[0].Nonce);
                        lblBlockListNonce.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListNonce.Text = "0x" + nonceLong.ToString("X");
                        });
                        lblBlockListMiner.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListMiner.Text = Convert.ToString(blocks[0].Extras.Pool.Name);
                        });
                        lblBlockListTransactionCount.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTransactionCount.Text = Convert.ToString(blocks[0].Tx_count);
                        });
                        string TotalBlockFees = Convert.ToString(blocks[0].Extras.TotalFees);
                        TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
                        lblBlockListTotalFees.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalFees.Text = TotalBlockFees;
                        });
                        string Reward = Convert.ToString(blocks[0].Extras.Reward);
                        lblBlockListReward.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
                        });
                        lblBlockListBlockFeeRangeAndMedianFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockFeeRangeAndMedianFee.Text = Convert.ToString(blocks[0].Extras.FeeRange[0]) + "-" + Convert.ToString(blocks[0].Extras.FeeRange[6]) + " / " + Convert.ToString(blocks[0].Extras.MedianFee);
                        });
                        lblBlockListAverageFee.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageFee.Text = Convert.ToString(blocks[0].Extras.AvgFee);
                        });
                        lblBlockListTotalInputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalInputs.Text = Convert.ToString(blocks[0].Extras.TotalInputs);
                        });
                        lblBlockListTotalOutputs.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListTotalOutputs.Text = Convert.ToString(blocks[0].Extras.TotalOutputs);
                        });
                        lblBlockListAverageTransactionSize.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListAverageTransactionSize.Text = Convert.ToString(blocks[0].Extras.AvgTxSize);
                        });
                        lblBlockListVersion.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListVersion.Text = Convert.ToString(blocks[0].Version);
                        });
                        lblBlockListBlockHeight.Invoke((MethodInvoker)delegate
                        {
                            lblBlockListBlockHeight.Text = "Block height: " + Convert.ToString(blocks[0].Height);
                        });
                    }
                    else
                    {
                        item.SubItems[1].ForeColor = Color.FromArgb(255, 153, 0); // Block number
                        item.SubItems[2].ForeColor = Color.FromArgb(255, 153, 0); // TX count
                    }
                }
                btnViewBlockFromBlockList.Visible = anySelected;
                btnViewTransactionsFromBlockList.Visible = anySelected;
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockList_ItemSelectionChanged, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockList_ItemSelectionChanged, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockList_ItemSelectionChanged, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "listViewBlockList_ItemSelectionChanged: " + ex.Message;
                });
            }

        }

        private void BtnViewTransactionsFromBlockList_Click(object sender, EventArgs e)  // this and btnViewBlockFromBlockList_Click do exactly the same. They both exist for UI only
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionsFromBlockList_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionsFromBlockList_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionsFromBlockList_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewTransactionsFromBlockList_Click: " + ex.Message;
                });
            }
        }

        private void BtnViewBlockFromBlockList_Click(object sender, EventArgs e)  // this and btnViewTransactionsFromBlockList_Click do exactly the same. They both exist for UI only
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
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewBlockFromBlockList_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewBlockFromBlockList_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewBlockFromBlockList_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnViewBlockFromBlockList_Click: " + ex.Message;
                });
            }
        }

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
                e.Graphics.FillRectangle(new SolidBrush(listViewBlockList.BackColor), bounds);
                TextRenderer.DrawText(e.Graphics, maxText, font, bounds, e.Item.ForeColor, TextFormatFlags.EndEllipsis | TextFormatFlags.Left);
            }
            else if (textWidth < columnWidth)
            {
                // Clear the background
                var bounds = new Rectangle(e.SubItem.Bounds.Left, e.SubItem.Bounds.Top, columnWidth, e.SubItem.Bounds.Height);

                e.Graphics.FillRectangle(new SolidBrush(listViewBlockList.BackColor), bounds);

                TextRenderer.DrawText(e.Graphics, text, font, bounds, e.SubItem.ForeColor, TextFormatFlags.Left);
            }
            
        }
#endregion

#region REUSEABLE STUFF
        //==============================================================================================================================================================================================
        //====================== GENERIC STUFF =========================================================================================================================================================
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
                btnViewTransactionsFromBlockListWasEnabled = btnViewTransactionsFromBlockList.Enabled;
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
                btnViewTransactionsFromBlockList.Enabled = false;
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
                btnViewTransactionsFromBlockList.Enabled = btnViewTransactionsFromBlockListWasEnabled;
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

        private void DisableEnableLoadingAnimation(string enableOrDisableAnimation)
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
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "DisableEnableLoadingAnimation: " + ex.Message;
                });
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
                    lblElapsedSinceUpdate.Location = new Point(lblStatusMessPart1.Location.X + lblStatusMessPart1.Width, lblElapsedSinceUpdate.Location.Y);
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "UpdateOnScreenCountdownAndFlashLights: " + ex.Message;
                });
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
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "ChangeStatusLights: " + ex.Message;
                });
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
            lblStatusMessPart1.Invoke((MethodInvoker)delegate
            {
                lblStatusMessPart1.Text = "Data updated successfully";
            });
            intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant; // reset the timer
            intDisplaySecondsElapsedSinceUpdate = 0; // reset the seconds since last refresh
        }

        //=============================================================================================================        
        //-------------------------- CHECK API ONLINE STATUS ----------------------------------------------------------
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
                    lblNodeStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblNodeStatusLight.ForeColor = Color.OliveDrab;
                    });
                    var displayNodeName = "";
                    if (NodeURL == "https://blockstream.info/api/")
                    {
                        displayNodeName = "Blockstream";
                    }
                    if (NodeURL == "https://mempool.space/api/")
                    {
                        displayNodeName = "Mempool.space";
                    }
                    lblActiveNode.Invoke((MethodInvoker)delegate
                    {
                        lblActiveNode.Text = displayNodeName + " status";
                    });
                }
                else
                {
                    // API is not online
                    lblNodeStatusLight.Invoke((MethodInvoker)delegate
                    {
                        lblNodeStatusLight.ForeColor = Color.Red;
                    });
                    var displayNodeName = "";
                    if (NodeURL == "https://blockstream.info/api/")
                    {
                        displayNodeName = "Blockstream";
                    }
                    if (NodeURL == "https://mempool.space/api/")
                    {
                        displayNodeName = "Mempool.space";
                    }
                    lblActiveNode.Invoke((MethodInvoker)delegate
                    {
                        lblActiveNode.Text = displayNodeName + " status";
                    });
                }
            }
            catch (HttpRequestException)
            {
                // API is not online
                lblNodeStatusLight.Invoke((MethodInvoker)delegate
                {
                    lblNodeStatusLight.ForeColor = Color.Red;
                });
                var displayNodeName = "";
                if (NodeURL == "https://blockstream.info/api/")
                {
                    displayNodeName = "Blockstream";
                }
                if (NodeURL == "https://mempool.space/api/")
                {
                    displayNodeName = "Mempool.space";
                }
                lblActiveNode.Invoke((MethodInvoker)delegate
                {
                    lblActiveNode.Text = displayNodeName + " status";
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "CheckBlockchainExplorerApiStatus: " + ex.Message;
                });
            }
            lblNodeStatusLight.Invoke((MethodInvoker)delegate
            {
                lblNodeStatusLight.Location = new Point(lblActiveNode.Location.X + lblActiveNode.Width, lblActiveNode.Location.Y);
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
                    panelMenu.Height = 216;
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

        private void BtnMenuSplash_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                splash splash = new splash(); // invoke the about/splash screen
                splash.ShowDialog();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnMenuSplash_Click: " + ex.Message;
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
        }

        private void BtnMenuBitcoinDashboard_Click(object sender, EventArgs e)
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24;
            });
            btnMenuAddress.Enabled = true;
            btnMenuTransaction.Enabled = true;
            btnMenuBitcoinDashboard.Enabled = false;
            btnMenuBlockList.Enabled = true;
            btnMenuLightningDashboard.Enabled = true;
            btnMenuBlock.Enabled = true;
            this.DoubleBuffered = true;
            this.SuspendLayout();
            panelBlockList.Visible = false;
            panelLightningDashboard.Visible = false;
            panelAddress.Visible = false;
            panelBlock.Visible = false;
            panelTransaction.Visible = false;
            panelBitcoinDashboard.Visible = true;
            this.ResumeLayout();
        }

        private void BtnMenuLightningDashboard_Click(object sender, EventArgs e)
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24;
            });
            btnMenuAddress.Enabled = true;
            btnMenuTransaction.Enabled = true;
            btnMenuBitcoinDashboard.Enabled = true;
            btnMenuBlockList.Enabled = true;
            btnMenuBlock.Enabled = true;
            btnMenuLightningDashboard.Enabled = false;
            this.DoubleBuffered = true;
            this.SuspendLayout();
            panelBitcoinDashboard.Visible = false;
            panelBlockList.Visible = false;
            panelAddress.Visible = false;
            panelBlock.Visible = false;
            panelTransaction.Visible = false;
            panelLightningDashboard.Visible = true;
            this.ResumeLayout();
        }

        private void BtnMenuAddress_Click(object sender, EventArgs e)
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24;
            });
            btnMenuAddress.Enabled = false;
            btnMenuTransaction.Enabled = true;
            btnMenuBlockList.Enabled = true;
            btnMenuBitcoinDashboard.Enabled = true;
            btnMenuBlock.Enabled = true;
            btnMenuLightningDashboard.Enabled = true;
            panelBitcoinDashboard.Visible = false;
            panelBlockList.Visible = false;
            panelLightningDashboard.Visible = false;
            panelBlock.Visible = false;
            panelTransaction.Visible = false;
            panelAddress.Visible = true;
        }

        private void BtnMenuBlock_Click(object sender, EventArgs e)
        {
            panelMenu.Invoke((MethodInvoker)delegate
            {
                panelMenu.Height = 24;
            });
            btnMenuBlock.Enabled = false;
            btnMenuTransaction.Enabled = true;
            btnMenuAddress.Enabled = true;
            btnMenuBlockList.Enabled = true;
            btnMenuBitcoinDashboard.Enabled = true;
            btnMenuLightningDashboard.Enabled = true;
            panelBlockList.Visible = false;
            panelBitcoinDashboard.Visible = false;
            panelLightningDashboard.Visible = false;
            panelAddress.Visible = false;
            panelTransaction.Visible = false;
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

        private void LblBlockNumber_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                btnMenuBlockList.Enabled = true;
                btnMenuTransaction.Enabled = true;
                btnMenuBlock.Enabled = false;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                panelBlockList.Visible = false;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelTransaction.Visible = false;
                panelBlock.Visible = true;
                textBoxSubmittedBlockNumber.Text = lblBlockNumber.Text; // overwrite whatever is in block screen textbox with the current block height.
                LookupBlock();
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "lblBlockNumber_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "lblBlockNumber_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "lblBlockNumber_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "lblBlockNumber_Click: " + ex.Message;
                });
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
                btnMenuBlockList.Enabled = false;
                btnMenuTransaction.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelBlockList.Visible = true;
                if (textBoxBlockHeightToStartListFrom.Text == "")
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                    });
                    LookupBlockList(); // fetch the first 15 blocks automatically for the initial view. 
                }
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuBlockList_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuBlockList_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuBlockList_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuBlockList_Click: " + ex.Message;
                });
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
                btnMenuTransaction.Enabled = false;
                btnMenuBlockList.Enabled = true;
                btnMenuBlock.Enabled = true;
                btnMenuAddress.Enabled = true;
                btnMenuBitcoinDashboard.Enabled = true;
                btnMenuLightningDashboard.Enabled = true;
                panelBitcoinDashboard.Visible = false;
                panelLightningDashboard.Visible = false;
                panelAddress.Visible = false;
                panelBlock.Visible = false;
                panelTransaction.Visible = false;
                panelBlockList.Visible = false;
                panelTransaction.Visible = true;
                if (textBoxBlockHeightToStartListFrom.Text == "")
                {
                    textBoxBlockHeightToStartListFrom.Invoke((MethodInvoker)delegate
                    {
                        textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                    });
                    LookupBlockList(); // fetch the first 15 blocks automatically for the initial view. 
                }
            }
            catch (WebException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuTransaction_Click, Web exception: " + ex.Message;
                });
            }
            catch (HttpRequestException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuTransaction_Click, HTTP Request error: " + ex.Message;
                });
            }
            catch (JsonException ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuTransaction_Click, JSON parsing error: " + ex.Message;
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnMenuTransaction_Click: " + ex.Message;
                });
            }
        }

        private void BtnMenuSettings_Click(object sender, EventArgs e)
        {
            try
            {
                panelMenu.Invoke((MethodInvoker)delegate
                {
                    panelMenu.Height = 24;
                });
                SettingsScreen.CreateInstance();
                SettingsScreen.Instance.ShowDialog();
                // read all fields from the settings screen and set variables for use on the main form
                if (SettingsScreen.Instance.BitcoinExplorerEndpointsEnabled)
                {
                    RunBitcoinExplorerEndpointAPI = true;
                }
                else
                {
                    RunBitcoinExplorerEndpointAPI = false;
                }
                if (SettingsScreen.Instance.BlockchainInfoEndpointsEnabled)
                {
                    RunBlockchainInfoEndpointAPI = true;
                }
                else
                {
                    RunBlockchainInfoEndpointAPI = false;
                }
                if (SettingsScreen.Instance.BitcoinExplorerOrgJSONEnabled)
                {
                    RunBitcoinExplorerOrgJSONAPI = true;
                }
                else
                {
                    RunBitcoinExplorerOrgJSONAPI = false;
                }
                if (SettingsScreen.Instance.BlockchainInfoJSONEnabled)
                {
                    RunBlockchainInfoJSONAPI = true;
                }
                else
                {
                    RunBlockchainInfoJSONAPI = false;
                }
                if (SettingsScreen.Instance.CoingeckoComJSONEnabled)
                {
                    RunCoingeckoComJSONAPI = true;
                }
                else
                {
                    RunCoingeckoComJSONAPI = false;
                }
                if (SettingsScreen.Instance.BlockchairComJSONEnabled)
                {
                    RunBlockchairComJSONAPI = true;
                }
                else
                {
                    RunBlockchairComJSONAPI = false;
                }
                if (SettingsScreen.Instance.MempoolSpaceLightningJSONEnabled)
                {
                    RunMempoolSpaceLightningAPI = true;
                }
                else
                {
                    RunMempoolSpaceLightningAPI = false;
                }
                if (SettingsScreen.Instance.NodeURL != NodeURL)
                {
                    NodeURL = SettingsScreen.Instance.NodeURL;
                    _transactionsForAddressService = new TransactionsForAddressService(NodeURL);
                }
                CheckBlockchainExplorerApiStatus();

                if (APIGroup1DisplayTimerIntervalSecsConstant != (SettingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60)) // if user has changed refresh frequency
                {
                    APIGroup1DisplayTimerIntervalSecsConstant = SettingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60;
                    intAPIGroup1TimerIntervalMillisecsConstant = ((SettingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60) * 1000);
                    intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                    timerAPIGroup1.Stop();
                    timerAPIGroup1.Interval = intAPIGroup1TimerIntervalMillisecsConstant;
                    timerAPIGroup1.Start();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "BtnMenuSettings_Click: " + ex.Message;
                });
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
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "btnHelp_Click: " + ex.Message;
                });
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
                    lblTime.Text = DateTime.Now.ToString("HH:mm");
                });
                lblSeconds.Invoke((MethodInvoker)delegate
                {
                    lblSeconds.Text = DateTime.Now.ToString("ss");
                });
                lblDate.Invoke((MethodInvoker)delegate
                {
                    lblDate.Text = DateTime.Now.ToString("MMMM dd yyyy");
                });
                lblDay.Invoke((MethodInvoker)delegate
                {
                    lblDay.Text = DateTime.Now.ToString("dddd");
                });
                lblSeconds.Invoke((MethodInvoker)delegate
                {
                    lblSeconds.Location = new Point(lblTime.Location.X + lblTime.Width - 10, lblSeconds.Location.Y); // place the seconds according to the width of the minutes/seconds (lblTime)
                });
            }
            catch (Exception ex)
            {
                lblErrorMessage.Invoke((MethodInvoker)delegate
                {
                    lblErrorMessage.Text = "UpdateOnScreenClock: " + ex.Message;
                });
            }
        }

        //=============================================================================================================
        //---------------------- BORDER AROUND WINDOW------------------------------------------------------------------
        private void Form1_Paint(object sender, PaintEventArgs e) // place a 1px border around the form
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }



        #endregion

    }
    //==============================================================================================================================================================================================
    //==============================================================================================================================================================================================

#region CLASSES

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
        public string MedianFee { get; set; }
        public int[] FeeRange { get; set; }
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
#endregion

}
//==================================================================================================================================================================================================
//======================================================================================== END =====================================================================================================
//==================================================================================================================================================================================================