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
 * bring the address screen within the Group1timertick? Might not be practical/useful
 * better/more error handling everywhere
 * check whether there are any UI scaling issues
 * handle tabbing and focus better
 * validation of user input of transaction ID
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
        private int intDisplayCountdownToRefresh; // countdown in seconds to next refresh, for display only
        private int intAPIGroup1TimerIntervalMillisecsConstant; // milliseconds, used to reset the interval of the timer for api group1 refresh
        private int APIGroup1DisplayTimerIntervalSecsConstant; // seconds, used to reset the countdown display to its original number
        // booleans used to say whether to run individual API's or not. All on/true by default.
        private bool RunBitcoinExplorerEndpointAPI = true;
        private bool RunBlockchainInfoEndpointAPI = true;
        private bool RunBitcoinExplorerOrgJSONAPI = true;
        private bool RunBlockchainInfoJSONAPI = true;
        private bool RunCoingeckoComJSONAPI = true;
        private bool RunBlockchairComJSONAPI = true;
        private bool RunMempoolSpaceLightningAPI = true;
        private string NodeURL = "https://mempool.space/api/"; // default value. Can be changed by user.
        private int APIGroup1RefreshFrequency = 1; // mins. Default value 1. Initial value only
        private int intDisplaySecondsElapsedSinceUpdate = 0; // used to count seconds since the data was last refreshed, for display only.
        private bool ObtainedHalveningSecondsRemainingYet = false; // used to check whether we know halvening seconds before we start trying to subtract from them
        private TransactionsForAddressService _transactionsForAddressService;
        private BlockDataService _blockService;
        private TransactionService _transactionService;
        private TransactionsForBlockService _transactionsForBlockService;
        private int TotalAddressTransactionRowsAdded = 0; // keeps track of how many rows of Address transactions have been added to the listview
        private int TotalBlockTransactionRowsAdded = 0; // keeps track of how many rows of Block transactions have been added to the listview
        private string mempoolConfUnconfOrAllTx = ""; // used to keep track of whether we're doing transactions requests for conf, unconf, or all transactions
        private string storedLastSeenBlockNumber;
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
            UpdateAPIGroup1DataFields(); // setting them now avoids waiting a whole minute for the first refresh
            StartTheClocksTicking(); // start all the timers
            textboxSubmittedAddress.Text = "bc1qnymv08yth53u4zfyqxfjp5wu0kxl3d57pka0q7"; // initial value for testing purposes
            CheckBlockchainExplorerApiStatus();
            mempoolConfUnconfOrAllTx = "chain"; // valid values are chain, mempool or all
            btnShowConfirmedTX.Enabled = false; // already looking at confirmed transactions to start with
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
                lblElapsedSinceUpdate.Text = intDisplaySecondsElapsedSinceUpdate.ToString() + " second ago. " + "Refreshing in " + Convert.ToString(intDisplayCountdownToRefresh);
            }
            else
            {
                lblElapsedSinceUpdate.Text = intDisplaySecondsElapsedSinceUpdate.ToString() + " seconds ago. " + "Refreshing in " + Convert.ToString(intDisplayCountdownToRefresh);
            }
            if (ObtainedHalveningSecondsRemainingYet) // only want to do this if we've already retrieved seconds remaining until halvening
            {
                string secondsString = lblHalveningSecondsRemaining.Text;
                int SecondsToHalving = int.Parse(secondsString);
                if (SecondsToHalving > 0)
                {
                    SecondsToHalving = SecondsToHalving - 1; // one second closer to the halvening!
                    lblHalveningSecondsRemaining.Text = SecondsToHalving.ToString();
                }
            }
           
            if (intDisplayCountdownToRefresh < 11) // when there are only 10 seconds left until the refresh...
            {
                lblAlert.Text = "";
                lblErrorMessage.Text = "";
            }
           
        }

        private void TimerAPIGroup1_Tick(object sender, EventArgs e) // update the btc/lightning dashboard fields
        {
            ClearAlertAndErrorMessage(); // wipe anything that may be showing in the error area (it should be empty anyway)
            UpdateAPIGroup1DataFields(); // fetch data and populate fields
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
                            var result = BitcoinExplorerOrgEndpointsRefresh();
                            // move returned data to the labels on the form
                            lblPriceUSD.Invoke((MethodInvoker)delegate
                            {
                                lblPriceUSD.Text = result.priceUSD;
                            });
                            lblMoscowTime.Invoke((MethodInvoker)delegate
                            {
                                lblMoscowTime.Text = result.moscowTime;
                            });
                            lblMarketCapUSD.Invoke((MethodInvoker)delegate
                            {
                                lblMarketCapUSD.Text = result.marketCapUSD;
                            });
                            lblDifficultyAdjEst.Invoke((MethodInvoker)delegate
                            {
                                lblDifficultyAdjEst.Text = result.difficultyAdjEst;
                            });
                            lblBlockListNextDifficultyAdjustment.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListNextDifficultyAdjustment.Text = result.difficultyAdjEst;
                            });
                            lblTXInMempool.Invoke((MethodInvoker)delegate
                            {
                                lblTXInMempool.Text = result.txInMempool;
                            });
                            lblBlockListTXInMempool.Invoke((MethodInvoker)delegate  // Blocks list
                            {
                                lblBlockListTXInMempool.Text = result.txInMempool;
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
                            var result2 = BlockchainInfoEndpointsRefresh();
                            // move returned data to the labels on the form
                            lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblAvgNoTransactions.Text = result2.avgNoTransactions;
                            });
                            lblBlockNumber.Invoke((MethodInvoker)delegate
                            {
                                lblBlockNumber.Text = result2.blockNumber;
                            });
                            lblBlockReward.Invoke((MethodInvoker)delegate
                            {
                                lblBlockReward.Text = result2.blockReward;
                                decimal DecBlockReward = Convert.ToDecimal(result2.blockReward);
                                decimal NextBlockReward = DecBlockReward / 2;
                                lblBlockRewardAfterHalving.Text = Convert.ToString(NextBlockReward);
                            });
                            lblBlockListBlockReward.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListBlockReward.Text = result2.blockReward;
                            });
                            lblEstHashrate.Invoke((MethodInvoker)delegate
                            {
                                lblEstHashrate.Text = result2.estHashrate;
                            });
                            lblBlockListEstHashRate.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListEstHashRate.Text = result2.estHashrate;
                            });
                            lblAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate
                            {
                                lblAvgTimeBetweenBlocks.Text = result2.avgTimeBetweenBlocks;
                            });
                            lblBlockListAvgTimeBetweenBlocks.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListAvgTimeBetweenBlocks.Text = result2.avgTimeBetweenBlocks;
                            });
                            lblBTCInCirc.Invoke((MethodInvoker)delegate
                            {
                                lblBTCInCirc.Text = result2.btcInCirc + " / 21000000";
                            });
                            lblHashesToSolve.Invoke((MethodInvoker)delegate
                            {
                                lblHashesToSolve.Text = result2.hashesToSolve;
                            });
                            lblBlockListAttemptsToSolveBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListAttemptsToSolveBlock.Text = result2.hashesToSolve;
                            });
                            lbl24HourTransCount.Invoke((MethodInvoker)delegate
                            {
                                lbl24HourTransCount.Text = result2.twentyFourHourTransCount;
                            });
                            lbl24HourBTCSent.Invoke((MethodInvoker)delegate
                            {
                                lbl24HourBTCSent.Text = result2.twentyFourHourBTCSent;
                            });
                        }
                        else
                        {
                            lblAvgNoTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblAvgNoTransactions.Text = "disabled";
                            });
                            lblBlockNumber.Invoke((MethodInvoker)delegate
                            {
                                lblBlockNumber.Text = "disabled";
                            });
                            lblBlockReward.Invoke((MethodInvoker)delegate
                            {
                                lblBlockReward.Text = "disabled";
                            });
                            lblBlockListBlockReward.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListBlockReward.Text = "disabled";
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
                            var result3 = BitcoinExplorerOrgJSONRefresh();
                            // move returned data to the labels on the form
                            lblfeesNextBlock.Invoke((MethodInvoker)delegate
                            {
                                lblfeesNextBlock.Text = result3.nextBlockFee;
                            });
                            lblFees30Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees30Mins.Text = result3.thirtyMinFee;
                            });
                            lblFees60Mins.Invoke((MethodInvoker)delegate
                            {
                                lblFees60Mins.Text = result3.sixtyMinFee;
                            });
                            lblFees1Day.Invoke((MethodInvoker)delegate
                            {
                                lblFees1Day.Text = result3.oneDayFee;
                            });
                            lblTransInNextBlock.Invoke((MethodInvoker)delegate
                            {
                                lblTransInNextBlock.Text = result3.txInNextBlock;
                            });
                            lblBlockListTXInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListTXInNextBlock.Text = result3.txInNextBlock;
                            });
                            lblNextBlockMinMaxFee.Invoke((MethodInvoker)delegate
                            {
                                lblNextBlockMinMaxFee.Text = result3.nextBlockMinFee + " / " + result3.nextBlockMaxFee;
                            });
                            lblBlockListMinMaxInFeeNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListMinMaxInFeeNextBlock.Text = result3.nextBlockMinFee + " / " + result3.nextBlockMaxFee;
                            });
                            lblNextBlockTotalFees.Invoke((MethodInvoker)delegate
                            {
                                lblNextBlockTotalFees.Text = result3.nextBlockTotalFees;
                            });
                            lblBlockListTotalFeesInNextBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListTotalFeesInNextBlock.Text = result3.nextBlockTotalFees;
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
                            var result4 = BlockchainInfoJSONRefresh();
                            // move returned data to the labels on the form
                            lblTransactions.Invoke((MethodInvoker)delegate
                            {
                                lblTransactions.Text = result4.n_tx;
                            });
                            lblBlockSize.Invoke((MethodInvoker)delegate
                            {
                                lblBlockSize.Text = result4.size;
                            });
                            lblNextDifficultyChange.Invoke((MethodInvoker)delegate
                            {
                                lblNextDifficultyChange.Text = result4.nextretarget;
                            });
                            lblBlockListNextDiffAdjBlock.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListNextDiffAdjBlock.Text = result4.nextretarget;
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
                            var result5 = CoingeckoComJSONRefresh();
                            // move returned data to the labels on the form
                            lblATH.Invoke((MethodInvoker)delegate
                            {
                                lblATH.Text = result5.ath;
                            });
                            lblATHDate.Invoke((MethodInvoker)delegate
                            {
                                lblATHDate.Location = new Point(lblATH.Location.X + lblATH.Width, lblATHDate.Location.Y); // place the ATH date according to the width of the ATH (future proofed for hyperbitcoinization!)
                            });
                            lblATHDate.Invoke((MethodInvoker)delegate
                            {
                                lblATHDate.Text = "(" + result5.athDate + ")";
                            });
                            lblATHDifference.Invoke((MethodInvoker)delegate
                            {
                                lblATHDifference.Text = result5.athDifference;
                            });
                            lbl24HrHigh.Invoke((MethodInvoker)delegate
                            {
                                lbl24HrHigh.Text = result5.twentyFourHourHigh + " / " + result5.twentyFourHourLow;
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
                            });
                            lblATHDate.Invoke((MethodInvoker)delegate
                            {
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
                            var result6 = MempoolSpaceLightningJSONRefresh();
                            // move returned data to the labels on the form
                            lblChannelCount.Invoke((MethodInvoker)delegate
                            {
                                lblChannelCount.Text = result6.channelCount;
                            });
                            lblNodeCount.Invoke((MethodInvoker)delegate
                            {
                                lblNodeCount.Text = result6.nodeCount;
                            });
                            lblTotalCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblTotalCapacity.Text = result6.totalCapacity;
                            });
                            lblTorNodes.Invoke((MethodInvoker)delegate
                            {
                                lblTorNodes.Text = result6.torNodes;
                            });
                            lblClearnetNodes.Invoke((MethodInvoker)delegate
                            {
                                lblClearnetNodes.Text = result6.clearnetNodes;
                            });
                            lblAverageCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblAverageCapacity.Text = result6.avgCapacity;
                            });
                            lblAverageFeeRate.Invoke((MethodInvoker)delegate
                            {
                                lblAverageFeeRate.Text = result6.avgFeeRate;
                            });
                            lblUnannouncedNodes.Invoke((MethodInvoker)delegate
                            {
                                lblUnannouncedNodes.Text = result6.unannouncedNodes;
                            });
                            lblAverageBaseFeeMtokens.Invoke((MethodInvoker)delegate
                            {
                                lblAverageBaseFeeMtokens.Text = result6.avgBaseeFeeMtokens;
                            });
                            lblMedCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblMedCapacity.Text = result6.medCapacity;
                            });
                            lblMedFeeRate.Invoke((MethodInvoker)delegate
                            {
                                lblMedFeeRate.Text = result6.medFeeRate;
                            });
                            lblMedBaseFeeTokens.Invoke((MethodInvoker)delegate
                            {
                                lblMedBaseFeeTokens.Text = result6.medBaseeFeeMtokens;
                            });
                            lblClearnetTorNodes.Invoke((MethodInvoker)delegate
                            {
                                lblClearnetTorNodes.Text = result6.clearnetTorNodes;
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
                            var result6 = MempoolSpaceCapacityBreakdownJSONRefresh();
                            lblClearnetCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblClearnetCapacity.Text = result6.clearnetCapacity;
                            });
                            lblTorCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblTorCapacity.Text = result6.torCapacity;
                            });
                            lblUnknownCapacity.Invoke((MethodInvoker)delegate
                            {
                                lblUnknownCapacity.Text = result6.unknownCapacity;
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
                            var result6 = MempoolSpaceLiquidityRankingJSONRefresh();
                            for (int i = 0; i < 10; i++)
                            {
                                System.Windows.Forms.Label aliasLabel = (System.Windows.Forms.Label)this.Controls.Find("aliasLabel" + (i + 1), true)[0];
                                aliasLabel.Invoke((MethodInvoker)delegate
                                {
                                    aliasLabel.Text = result6.aliases[i];
                                });
                                System.Windows.Forms.Label capacityLabel = (System.Windows.Forms.Label)this.Controls.Find("capacityLabel" + (i + 1), true)[0];
                                capacityLabel.Invoke((MethodInvoker)delegate
                                {
                                    capacityLabel.Text = result6.capacities[i];
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
                            var result8 = BlockchairComHalvingJSONRefresh();
                            lblHalveningBlock.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningBlock.Text = result8.halveningBlock + " / " + result8.blocksLeft;
                            });
                            lblBlockListHalvingBlockAndRemaining.Invoke((MethodInvoker)delegate // Blocks list
                            {
                                lblBlockListHalvingBlockAndRemaining.Text = result8.halveningBlock + " / " + result8.blocksLeft;
                            });
                            string halvening_time = result8.halveningTime;
                            DateTime halveningDateTime = DateTime.ParseExact(halvening_time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            string halveningDate = halveningDateTime.Date.ToString("yyyy-MM-dd");

                            lblEstimatedHalvingDate.Invoke((MethodInvoker)delegate
                            {
                                lblEstimatedHalvingDate.Text = halveningDate + " / ";
                            });
                            lblHalveningSecondsRemaining.Invoke((MethodInvoker)delegate
                            {
                                lblHalveningSecondsRemaining.Location = new Point(lblEstimatedHalvingDate.Location.X + lblEstimatedHalvingDate.Width - 8, lblEstimatedHalvingDate.Location.Y);
                                lblHalveningSecondsRemaining.Text = result8.seconds_left;
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
            using (WebClient client = new WebClient())
            {
                string priceUSD = client.DownloadString("https://bitcoinexplorer.org/api/price/usd"); // 1 bitcoin = ? usd
                string moscowTime = client.DownloadString("https://bitcoinexplorer.org/api/price/usd/sats"); // 1 usd = ? sats
                string marketCapUSD = client.DownloadString("https://bitcoinexplorer.org/api/price/usd/marketcap"); // bitcoin market cap in usd
                string difficultyAdjEst = client.DownloadString("https://bitcoinexplorer.org/api/mining/diff-adj-estimate") + "%"; // difficulty adjustment as a percentage
                string txInMempool = client.DownloadString("https://bitcoinexplorer.org/api/mempool/count"); // total number of transactions in the mempool
                return (priceUSD, moscowTime, marketCapUSD, difficultyAdjEst, txInMempool);
            }
        }

        private (string avgNoTransactions, string blockNumber, string blockReward, string estHashrate, string avgTimeBetweenBlocks, string btcInCirc, string hashesToSolve, string twentyFourHourTransCount, string twentyFourHourBTCSent) BlockchainInfoEndpointsRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        //-----Mempool Lighting JSON
        private (List<string> aliases, List<string> capacities) MempoolSpaceLiquidityRankingJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        private (List<string> aliases, List<string> channels) MempoolSpaceConnectivityRankingJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        private (string clearnetCapacity, string torCapacity, string unknownCapacity) MempoolSpaceCapacityBreakdownJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        private (string channelCount, string nodeCount, string totalCapacity, string torNodes, string clearnetNodes, string unannouncedNodes, string avgCapacity, string avgFeeRate, string avgBaseeFeeMtokens, string medCapacity, string medFeeRate, string medBaseeFeeMtokens, string clearnetTorNodes) MempoolSpaceLightningJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
                if (medBaseeFeeMtokens == null)
                {
                    medBaseeFeeMtokens = "0";
                }
                var clearnetTorNodes = (string)data["latest"]["clearnet_tor_nodes"];
                return (channelCount, nodeCount, totalCapacity, torNodes, clearnetNodes, unannouncedNodes, avgCapacity, avgFeeRate, avgBaseeFeeMtokens, medCapacity, medFeeRate, medBaseeFeeMtokens, clearnetTorNodes);
            }
        }

        //-----BitcoinExplorer JSON
        private (string nextBlockFee, string thirtyMinFee, string sixtyMinFee, string oneDayFee, string txInNextBlock, string nextBlockMinFee, string nextBlockMaxFee, string nextBlockTotalFees) BitcoinExplorerOrgJSONRefresh()
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

        //-----BlockchainInfo JSON
        private (string n_tx, string size, string nextretarget) BlockchainInfoJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        //-----CoinGecko JSON
        private (string ath, string athDate, string athDifference, string twentyFourHourHigh, string twentyFourHourLow) CoingeckoComJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
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
        }

        //-----Blockchair JSON
        private (string halveningBlock, string halveningReward, string halveningTime, string blocksLeft, string seconds_left) BlockchairComHalvingJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
                var response = client.DownloadString("https://api.blockchair.com/tools/halvening");
                var data = JObject.Parse(response);
                var halveningBlock = (string)data["data"]["bitcoin"]["halvening_block"];
                var halveningReward = (string)data["data"]["bitcoin"]["halvening_reward"];
                var halveningTime = (string)data["data"]["bitcoin"]["halvening_time"];
                var blocksLeft = (string)data["data"]["bitcoin"]["blocks_left"];
                var seconds_left = (string)data["data"]["bitcoin"]["seconds_left"];
                return (halveningBlock, halveningReward, halveningTime, blocksLeft, seconds_left);
            }
        }

        private (string hodling_addresses, string blocks_24h, string nodes, string blockchain_size) BlockchairComJSONRefresh()
        {
            using (WebClient client = new WebClient())
            {
                var response = client.DownloadString("https://api.blockchair.com/bitcoin/stats");
                var data = JObject.Parse(response);
                var hodling_addresses = (string)data["data"]["hodling_addresses"];
                var blocks_24h = (string)data["data"]["blocks_24h"];
                var nodes = (string)data["data"]["nodes"];
                var blockchain_size = (string)data["data"]["blockchain_size"];
                return (hodling_addresses, blocks_24h, nodes, blockchain_size);
            }
        }

        //=============================================================================================================
        //---------------------- CONNECTING LINES BETWEEN FIELDS ON LIGHTNING DASHBOARD -------------------------------
        private void PanelLightningDashboard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(106, 72, 9), 1))
            {
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
                lblAddressType.Text = addressType + " address";
                // generate QR code for address
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(addressString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                var qrCodeImage = qrCode.GetGraphic(20, Color.Gray, Color.Black, false);
                qrCodeImage.MakeTransparent(Color.Black);
                AddressQRCodePicturebox.Image = qrCodeImage;

                await GetAddressBalanceAsync(addressString); // make sure we get these results before processing transactions
                string lastSeenTxId = ""; // start from the top of the JSON (most recent tx)
                await GetTransactionsForAddress(addressString, lastSeenTxId); // get first batch of transactions
            }
            else
            {
                lblAddressType.Text = "Invalid address format";
                AddressQRCodePicturebox.Image = null;
                lblAddressConfirmedReceived.Text = string.Empty;
                lblAddressConfirmedReceivedOutputs.Text = string.Empty;
                lblAddressConfirmedSpent.Text = string.Empty;
                lblAddressConfirmedSpentOutputs.Text = string.Empty;
                lblAddressConfirmedTransactionCount.Text = string.Empty;
                lblAddressConfirmedUnspent.Text = string.Empty;
                lblAddressConfirmedUnspentOutputs.Text = string.Empty;
                AddressInvalidHideControls();
            }
            DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
        }

        //=============================================================================================================
        //------------------------------------------ GET ADDRESS BALANCE-----------------------------------------------
        private async Task GetAddressBalance(string addressString)
        {
            var request = "address/" + addressString;
            var RequestURL = NodeURL + request;
            //var RequestURL = "http://umbrel.local:3006/api/" + request;
            var client = new HttpClient();
            var response = await client.GetAsync($"{RequestURL}"); // get the JSON to get address balance and no of transactions etc
            if (!response.IsSuccessStatusCode)
            {
                lblNodeStatusLight.ForeColor = Color.Red;
                lblActiveNode.Text = "Disconnected/error";
                return;
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var addressData = JObject.Parse(jsonData);

            if (mempoolConfUnconfOrAllTx == "chain" && !PartOfAnAllAddressTransactionsRequest)  //confirmed stats only. 'All' reverts to 'chain' after the first query, so we need to exclude those
            {
                label61.Text = "Confirmed unspent (balance)";
                label59.Text = "Confirmed transaction count";
                label67.Text = "Confirmed received";
                label63.Text = "Confirmed spent";
                lblAddressConfirmedTransactionCount.Text = Convert.ToString(addressData["chain_stats"]["tx_count"]);
                lblAddressConfirmedReceived.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["chain_stats"]["funded_txo_sum"])).ToString();
                lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                lblAddressConfirmedReceivedOutputs.Text = "(" + addressData["chain_stats"]["funded_txo_count"] + " outputs)";
                lblAddressConfirmedSpent.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["chain_stats"]["spent_txo_sum"])).ToString();
                lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                lblAddressConfirmedSpentOutputs.Text = "(" + addressData["chain_stats"]["spent_txo_count"] + " outputs)";
                var fundedTx = Convert.ToDouble(addressData["chain_stats"]["funded_txo_count"]);
                var spentTx = Convert.ToDouble(addressData["chain_stats"]["spent_txo_count"]);
                var confirmedReceived = Convert.ToDouble(addressData["chain_stats"]["funded_txo_sum"]);
                var confirmedSpent = Convert.ToDouble(addressData["chain_stats"]["spent_txo_sum"]);
                var confirmedUnspent = confirmedReceived - confirmedSpent;
                var unSpentTxOutputs = fundedTx - spentTx;
                lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspent)).ToString();
                lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(unSpentTxOutputs) + " outputs)";
            }
            if (mempoolConfUnconfOrAllTx == "mempool") //mempool stats only
            {
                label61.Text = "Unconfirmed unspent (balance)";
                label59.Text = "Unconfirmed transaction count";
                label67.Text = "Unconfirmed received";
                label63.Text = "Unconfirmed spent";
                lblAddressConfirmedTransactionCount.Text = Convert.ToString(addressData["mempool_stats"]["tx_count"]);
                lblAddressConfirmedReceived.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["mempool_stats"]["funded_txo_sum"])).ToString();
                lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                lblAddressConfirmedReceivedOutputs.Text = "(" + addressData["mempool_stats"]["funded_txo_count"] + " outputs)";
                lblAddressConfirmedSpent.Text = ConvertSatsToBitcoin(Convert.ToString(addressData["mempool_stats"]["spent_txo_sum"])).ToString();
                lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                lblAddressConfirmedSpentOutputs.Text = "(" + addressData["mempool_stats"]["spent_txo_count"] + " outputs)";
                var fundedTx = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_count"]);
                var spentTx = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_count"]);
                var confirmedReceived = Convert.ToDouble(addressData["mempool_stats"]["funded_txo_sum"]);
                var confirmedSpent = Convert.ToDouble(addressData["mempool_stats"]["spent_txo_sum"]);
                var confirmedUnspent = confirmedReceived - confirmedSpent;
                var unSpentTxOutputs = fundedTx - spentTx;
                lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(confirmedUnspent)).ToString();
                lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(unSpentTxOutputs) + " outputs)";
            }
            if (mempoolConfUnconfOrAllTx == "all" || (mempoolConfUnconfOrAllTx == "chain" && PartOfAnAllAddressTransactionsRequest)) // all TXs so will need to add chain and mempool amounts together before displaying. 
            {
                label61.Text = "Total unspent (balance)";
                label59.Text = "Total transaction count";
                label67.Text = "Total received";
                label63.Text = "Total spent";
                int chainTransactionCount = Convert.ToInt32(addressData["chain_stats"]["tx_count"]);
                int mempoolTransactionCount = Convert.ToInt32(addressData["mempool_stats"]["tx_count"]);
                int totalTransactionCount = chainTransactionCount + mempoolTransactionCount;
                lblAddressConfirmedTransactionCount.Text = Convert.ToString(totalTransactionCount);

                long chainReceived = Convert.ToInt64(addressData["chain_stats"]["funded_txo_sum"]);
                long mempoolReceived = Convert.ToInt64(addressData["mempool_stats"]["funded_txo_sum"]);
                long totalReceived = chainReceived + mempoolReceived;
                decimal BTCtotalReceived = ConvertSatsToBitcoin(totalReceived.ToString());
                lblAddressConfirmedReceived.Text = Convert.ToString(BTCtotalReceived);

                lblAddressConfirmedReceivedOutputs.Location = new Point(lblAddressConfirmedReceived.Location.X + lblAddressConfirmedReceived.Width - 5, lblAddressConfirmedReceivedOutputs.Location.Y);
                int chainReceivedOutputs = Convert.ToInt32(addressData["chain_stats"]["funded_txo_count"]);
                int mempoolReceivedOutputs = Convert.ToInt32(addressData["mempool_stats"]["funded_txo_count"]);
                int totalReceivedOutputs = chainReceivedOutputs + mempoolReceivedOutputs;
                lblAddressConfirmedReceivedOutputs.Text = "(" + totalReceivedOutputs + " outputs)";

                long chainSpent = Convert.ToInt64(addressData["chain_stats"]["spent_txo_sum"]);
                long mempoolSpent = Convert.ToInt64(addressData["mempool_stats"]["spent_txo_sum"]);
                long totalSpent = chainSpent + mempoolSpent;
                decimal BTCtotalSpent = ConvertSatsToBitcoin(totalSpent.ToString());
                lblAddressConfirmedSpent.Text = Convert.ToString(BTCtotalSpent);

                lblAddressConfirmedSpentOutputs.Location = new Point(lblAddressConfirmedSpent.Location.X + lblAddressConfirmedSpent.Width - 5, lblAddressConfirmedSpentOutputs.Location.Y);
                int chainSpentOutputs = Convert.ToInt32(addressData["chain_stats"]["spent_txo_count"]);
                int mempoolSpentOutputs = Convert.ToInt32(addressData["mempool_stats"]["spent_txo_count"]);
                int totalSpentOutputs = chainSpentOutputs + mempoolSpentOutputs;
                lblAddressConfirmedSpentOutputs.Text = "(" + totalSpentOutputs + " outputs)";

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

                lblAddressConfirmedUnspent.Text = ConvertSatsToBitcoin(Convert.ToString(totalUnspent)).ToString();
                lblAddressConfirmedUnspentOutputs.Location = new Point(lblAddressConfirmedUnspent.Location.X + lblAddressConfirmedUnspent.Width - 5, lblAddressConfirmedUnspentOutputs.Location.Y);
                lblAddressConfirmedUnspentOutputs.Text = "(" + Convert.ToString(totalUnspentTXOutputs) + " outputs)";
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
            var transactionsJson = await _transactionsForAddressService.GetTransactionsForAddressAsync(addressString, mempoolConfUnconfOrAllTx, lastSeenTxId);
            var transactions = JsonConvert.DeserializeObject<List<AddressTransactions>>(transactionsJson);
            List<string> txIds = transactions.Select(t => t.txid).ToList();

            // Update lastSeenTxId if this isn't our first fetch of tranasctions to restart from the right place
            if (transactions.Count > 0)
            {
                if (transactions.Last().status.confirmed == "true") // make sure the last shown tx wasn't a mempool tx before using its txid as a key to a subsequent call. 
                {
                    lastSeenTxId = transactions.Last().txid; // it was a confirmed tx so we can carry on the next api call from that point
                }
                else
                {
                    lastSeenTxId = ""; // If it was a mempool record then the next call (to confirmed tx's) will need a null txid to start from the beginning
                }
                lastSeenTxId = transactions.Last().txid;
            }

            //LIST VIEW
            listViewAddressTransactions.Items.Clear(); // remove any data that may be there already
            listViewAddressTransactions.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewAddressTransactions, new object[] { true });

            // Check if the column header already exists
            if (listViewAddressTransactions.Columns.Count == 0)
            {
                // If not, add the column header
                if (mempoolConfUnconfOrAllTx == "chain")
                {
                    if (PartOfAnAllAddressTransactionsRequest)
                    {
                        listViewAddressTransactions.Columns.Add(" Transaction ID (all transactions)", 260);
                    }
                    else
                    {
                        listViewAddressTransactions.Columns.Add(" Transaction ID (confirmed)", 260);
                    }
                }
                if (mempoolConfUnconfOrAllTx == "mempool")
                {
                    listViewAddressTransactions.Columns.Add(" Transaction ID (unconfirmed)", 260);
                }
                if (mempoolConfUnconfOrAllTx == "all")
                {
                    listViewAddressTransactions.Columns.Add(" Transaction ID (all transactions)", 260);
                }
            }

            // Add the block height column header
            if (listViewAddressTransactions.Columns.Count == 1)
            {
                listViewAddressTransactions.Columns.Add("Block", 65);
            }

            // Add the balance change column header
            if (listViewAddressTransactions.Columns.Count == 2)
            {
                listViewAddressTransactions.Columns.Add("Amount", 110);
            }

            // Add the status column header
            if (listViewAddressTransactions.Columns.Count == 3)
            {
                listViewAddressTransactions.Columns.Add("Confs", 70);
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
                balanceChangeVout = (decimal)transaction.vout // value of all outputs where address is the provided address
                    .Where(v => v.scriptpubkey_address == addressString)
                    .Sum(v => v.value);
                balanceChangeVin = (decimal)transaction.vin // value of all inputs where address is the provided address
                    .Where(v => v.prevout.scriptpubkey_address == addressString)
                    .Sum(v => v.prevout.value);
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

                ListViewItem item = new ListViewItem(transaction.txid); // create new row
                if (transaction.status.confirmed == "true")
                {
                    item.SubItems.Add(transaction.status.block_height.ToString()); // add block height
                }
                else
                {
                    item.SubItems.Add("------".ToString()); // unconfirmed, so no block height
                }

                item.SubItems.Add(balanceChangeString.ToString()); // add net change to balance

                if (transaction.status.confirmed == "true")
                {
                    decimal CurrentBlockForCalc = Convert.ToDecimal(CurrentBlockHeightStringForCalc);
                    decimal TransactionBlockForCalc = transaction.status.block_height;
                    decimal Confirmations = (CurrentBlockForCalc - TransactionBlockForCalc) + 1;
                    item.SubItems.Add(Confirmations.ToString()); // and confirmed status
                }
                else
                {
                    item.SubItems.Add("---".ToString()); // unconfirmed, so no confirmations
                }

                listViewAddressTransactions.Items.Add(item); // add row

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
                lblAddressTXPositionInList.Text = "Transactions " + (TotalAddressTransactionRowsAdded - counter + 1) + " - " + (TotalAddressTransactionRowsAdded) + " of " + lblAddressConfirmedTransactionCount.Text;
            }
            else
            {
                lblAddressTXPositionInList.Text = "No transactions to display";
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

        private async void BtnGetNextTransactionsForAddress(object sender, EventArgs e)
        {
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            var address = textboxSubmittedAddress.Text; // Get the address from the address text box
            // Get the last seen transaction ID from the list view
            var lastSeenTxId = "";
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

        private void btnShowUnconfirmedTXForAddress_Click(object sender, EventArgs e)
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
            textboxSubmittedAddress.Text = "";
            listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
            textboxSubmittedAddress.Text = temp;
        }

        private void btnShowConfirmedTXForAddress_Click(object sender, EventArgs e)
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
            textboxSubmittedAddress.Text = "";
            listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
            textboxSubmittedAddress.Text = temp;
        }

        private void btnShowAllTXForAddress_Click(object sender, EventArgs e)
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
            textboxSubmittedAddress.Text = "";
            listViewAddressTransactions.Columns.Clear(); // force headings to be redrawn
            textboxSubmittedAddress.Text = temp;
        }

        private void BtnViewBlockFromAddress_Click(object sender, EventArgs e)
        {
            //assign block number to text box on block panel
            // Get the selected item
            ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
            // Get the second subitem in the selected item 
            string submittedBlockNumber = selectedItem.SubItems[1].Text;
            // Set the text of the textBoxSubmittedBlockNumber control
            textBoxSubmittedBlockNumber.Text = submittedBlockNumber;
            LookupBlock();
            //show the block screen
            btnMenuBlock_Click(sender, e);
        }

        private void BtnViewTransactionFromAddress_Click(object sender, EventArgs e)
        {
            //assign TX ID to text box on transaction panel
            // Get the selected item
            ListViewItem selectedItem = listViewAddressTransactions.SelectedItems[0];
            // Get the first subitem in the selected item 
            string TransactionIDFromRow = selectedItem.SubItems[0].Text;
            // Set the text of the textBoxTransactionID control
            textBoxTransactionID.Text = TransactionIDFromRow;
            LookupTransaction();
            //show the transaction screen
            btnMenuTransaction_Click(sender, e);
        }

        //=============================================================================================================
        //--------------- OVERRIDE COLOURS FOR LISTVIEW HEADINGS ------------------------------------------------------
        private void listViewAddressTransactions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

        //=============================================================================================================
        //------------------------ CHANGE COLOUR OF SELECTED ROW ------------------------------------------------------
        private void listViewAddressTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool anySelected = false;
            foreach (ListViewItem item in listViewAddressTransactions.Items)
            {
                if (item.Selected)
                {
                    item.ForeColor = Color.White; // txID
                    item.SubItems[1].ForeColor = Color.White; //Block 
                    anySelected = true;
                    BtnViewTransactionFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width - BtnViewTransactionFromAddress.Width - 8, item.Position.Y + listViewAddressTransactions.Location.Y - 2);
                    BtnViewBlockFromAddress.Location = new Point(item.Position.X + listViewAddressTransactions.Location.X + listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Columns[1].Width - BtnViewBlockFromAddress.Width - 3, item.Position.Y + listViewAddressTransactions.Location.Y - 2);
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
        private void listViewAddressTransactions_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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
                BtnViewTransactionFromAddress.Location = new Point(listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Location.X - BtnViewTransactionFromAddress.Width - 6, BtnViewTransactionFromAddress.Location.Y);
                BtnViewBlockFromAddress.Location = new Point(listViewAddressTransactions.Columns[0].Width + listViewAddressTransactions.Columns[1].Width + listViewAddressTransactions.Location.X - BtnViewBlockFromAddress.Width + 2, BtnViewBlockFromAddress.Location.Y);
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
                    textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(start, length);
                    textBoxSubmittedBlockNumber.SelectionStart = start;
                }
                // If the cursor is not at the beginning, delete the character to the left of the cursor
                else if (textBoxSubmittedBlockNumber.SelectionStart > 0)
                {
                    int pos = textBoxSubmittedBlockNumber.SelectionStart - 1;
                    textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(pos, 1);
                    textBoxSubmittedBlockNumber.SelectionStart = pos;
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
                    textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(start, length);
                    textBoxSubmittedBlockNumber.SelectionStart = start;
                }
                // If the cursor is not at the end, delete the character to the right of the cursor
                else if (textBoxSubmittedBlockNumber.SelectionStart < textBoxSubmittedBlockNumber.Text.Length)
                {
                    int pos = textBoxSubmittedBlockNumber.SelectionStart;
                    textBoxSubmittedBlockNumber.Text = textBoxSubmittedBlockNumber.Text.Remove(pos, 1);
                    textBoxSubmittedBlockNumber.SelectionStart = pos;
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
                textBoxSubmittedBlockNumber.Text = "0";
                textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
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
                textBoxSubmittedBlockNumber.Text = "0";
                textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                e.Handled = true;
                return;
            }

            // Handle input that exceeds the maximum allowed value by setting the textbox to the maximum value
            if (value > maxValue)
            {
                textBoxSubmittedBlockNumber.Text = maxValue.ToString();
                textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
                e.Handled = true;
                return;
            }

            textBoxSubmittedBlockNumber.Text = value.ToString();
            textBoxSubmittedBlockNumber.SelectionStart = textBoxSubmittedBlockNumber.Text.Length;
            e.Handled = true;
        }

        private void textBoxSubmittedBlockNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSubmittedBlockNumber.Text.Trim()))
            {
                textBoxSubmittedBlockNumber.Text = "0";
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
                lblBlockHash.Text = BlockHash;
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

        private async Task GetFifteenBlocks(string blockNumber) // overkill at this point, because we're only interested in one block, but this gets us the data
        {
            var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
            var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
            lblNumberOfTXInBlock.Text = Convert.ToString(blocks[0].tx_count);
            long sizeInBytes = blocks[0].size;
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
            lblSizeOfBlock.Text = sizeString;
            string strWeight = Convert.ToString(blocks[0].weight);
            decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
            string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
            lblBlockWeight.Text = strFormattedWeight;
            string TotalBlockFees = Convert.ToString(blocks[0].extras.totalFees);
            TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
            lblTotalFees.Text = TotalBlockFees;
            long nonceLong = Convert.ToInt64(blocks[0].nonce);

            lblNonce.Text = "0x" + nonceLong.ToString("X");
            string Reward = Convert.ToString(blocks[0].extras.reward);
            lblReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
            lblBlockFeeRangeAndMedianFee.Text = Convert.ToString(blocks[0].extras.feeRange[0]) + "-" + Convert.ToString(blocks[0].extras.feeRange[6]) + " / " + Convert.ToString(blocks[0].extras.medianFee);
            lblBlockAverageFee.Text = Convert.ToString(blocks[0].extras.avgFee);
            lblMiner.Text = Convert.ToString(blocks[0].extras.pool.name);
            lblBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].timestamp)).ToString("yyyy-MM-dd HH:mm");
        }

        private async Task GetTransactionsForBlock(string blockHash, string lastSeenBlockTransaction)
        {
            var BlockTransactionsJson = await _transactionsForBlockService.GetTransactionsForBlockAsync(blockHash, lastSeenBlockTransaction);
            var transactions = JsonConvert.DeserializeObject<List<Block_Transactions>>(BlockTransactionsJson);
            List<string> txIds = transactions.Select(t => t.txid).ToList();

            // Update lastSeenTxId if this isn't our first fetch of tranasctions to restart from the right place
            if (txIds.Count > 0)
            {
                lastSeenBlockTransaction = txIds.Last();
            }

            //LIST VIEW
            listViewBlockTransactions.Items.Clear(); // remove any data that may be there already
            listViewBlockTransactions.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewBlockTransactions, new object[] { true });

            // Check if the column header already exists
            if (listViewBlockTransactions.Columns.Count == 0)
            {
                // If not, add the column header
                listViewBlockTransactions.Columns.Add(" Transaction ID", 250);
            }

            if (listViewBlockTransactions.Columns.Count == 1)
            {
                // If not, add the column header
                listViewBlockTransactions.Columns.Add("Fee", 70);
            }

            if (listViewBlockTransactions.Columns.Count == 2)
            {
                // If not, add the column header
                listViewBlockTransactions.Columns.Add("I/P", 40);
            }
            if (listViewBlockTransactions.Columns.Count == 3)
            {
                // If not, add the column header
                listViewBlockTransactions.Columns.Add("O/P", 40);
            }
            if (listViewBlockTransactions.Columns.Count == 4)
            {
                // If not, add the column header
                listViewBlockTransactions.Columns.Add("Amount", 100);
            }
            // Add the items to the ListView
            int counter = 0; // used to count rows in list as they're added

            foreach (var blockTransaction in transactions)
            {
                ListViewItem item = new ListViewItem(blockTransaction.txid); // create new row
                item.SubItems.Add(blockTransaction.fee.ToString());
                item.SubItems.Add(blockTransaction.vin.Count.ToString()); // number of inputs
                item.SubItems.Add(blockTransaction.vout.Count.ToString()); // number of outputs
                decimal totalValue = blockTransaction.vout.Sum(v => decimal.Parse(v.value)); // sum of outputs
                totalValue = ConvertSatsToBitcoin(totalValue.ToString());
                item.SubItems.Add(totalValue.ToString());
                listViewBlockTransactions.Items.Add(item); // add row

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
                lblBlockTXPositionInList.Text = "Transactions " + (TotalBlockTransactionRowsAdded - counter + 1) + " - " + (TotalBlockTransactionRowsAdded) + " of " + lblNumberOfTXInBlock.Text;
            }
            else
            {
                lblBlockTXPositionInList.Text = "No transactions to display"; // this can't really happen as there will always be a coinbase transaction
            }
        }

        private async void btnNextBlockTransactions_Click(object sender, EventArgs e)
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

        private async void btnPreviousBlockTransactions_Click(object sender, EventArgs e)
        {
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            var blockHash = lblBlockHash.Text; // Get the blockHash from the label again
            // Get the last seen transaction ID from the list view
            TotalBlockTransactionRowsAdded = TotalBlockTransactionRowsAdded - 50;
            var lastSeenBlockTransaction = Convert.ToString(TotalBlockTransactionRowsAdded); // the JSON uses the count to restart fetching, rather than txid.
            // Call the GetConfirmedTransactionsForBlock method with the updated lastSeenTxId
            await GetTransactionsForBlock(blockHash, lastSeenBlockTransaction);
            DisableEnableButtons("enable"); // enable the buttons that were previously enabled again
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
            btnViewTransactionFromBlock.Visible = false;
        }

        private void btnPreviousBlock_Click(object sender, EventArgs e) // decrease block number by 1 and populate block data
        {
            long CurrentSubmittedBlockNumber = Convert.ToInt32(textBoxSubmittedBlockNumber.Text);
            textBoxSubmittedBlockNumber.Text = Convert.ToString(CurrentSubmittedBlockNumber - 1);
            LookupBlock();
        }

        private void btnNextBlock_Click(object sender, EventArgs e) // increase block number by 1 and populate block data
        {
            long CurrentSubmittedBlockNumber = Convert.ToInt32(textBoxSubmittedBlockNumber.Text);
            textBoxSubmittedBlockNumber.Text = Convert.ToString(CurrentSubmittedBlockNumber + 1);
            LookupBlock();
        }

        private void listViewBlockTransactions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool anySelected = false;
            foreach (ListViewItem item in listViewBlockTransactions.Items)
            {
                if (item.Selected)
                {
                    item.ForeColor = Color.White; // txID
                    anySelected = true;
                    btnViewTransactionFromBlock.Location = new Point(item.Position.X + listViewBlockTransactions.Location.X + listViewBlockTransactions.Columns[0].Width - btnViewTransactionFromBlock.Width - 8, item.Position.Y + listViewBlockTransactions.Location.Y - 2);
                }
                else
                {
                    item.ForeColor = Color.FromArgb(255, 153, 0); //txID
                }
            }
            btnViewTransactionFromBlock.Visible = anySelected;
        }

        private void listViewBlockTransactions_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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
                btnViewTransactionFromBlock.Location = new Point(listViewBlockTransactions.Columns[0].Width + listViewBlockTransactions.Location.X - btnViewTransactionFromBlock.Width - 6, btnViewTransactionFromBlock.Location.Y);
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

        private void listViewBlockTransactions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
        }

        private void listViewBlockTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        private void btnViewTransactionFromBlock_Click(object sender, EventArgs e)
        {
            //assign TX ID to text box on transaction panel
            // Get the selected item
            ListViewItem selectedItem = listViewBlockTransactions.SelectedItems[0];
            // Get the first subitem in the selected item 
            string TransactionIDFromRow = selectedItem.SubItems[0].Text;
            // Set the text of the textBoxTransactionID control
            textBoxTransactionID.Text = TransactionIDFromRow;
            LookupTransaction();
            //show the transaction screen
            btnMenuTransaction_Click(sender, e);
        }

        #endregion

#region TRANSACTION STUFF

        private void textBoxTransactionID_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void LookupTransaction()
        {
            string submittedTransactionID = textBoxTransactionID.Text;
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation
            await GetTransaction(submittedTransactionID);
            DisableEnableLoadingAnimation("disable"); // stop the loading animation
            DisableEnableButtons("enable"); // enable buttons after operation is complete

        }

        private async Task GetTransaction(string submittedTransactionID) 
        {

            //panelTransactionDiagram.Invalidate();
            var TransactionJson = await _transactionService.GetTransactionAsync(submittedTransactionID);
            var transaction = JsonConvert.DeserializeObject<Transaction>(TransactionJson);
            lblTransactionVersion.Text = Convert.ToString(transaction.version);
            lblTransactionLockTime.Text = Convert.ToString(transaction.locktime);
            lblTransactionSize.Text = Convert.ToString(transaction.size) + " bytes";
            lblTransactionWeight.Text = Convert.ToString(transaction.weight) + " MWU";
            lblTransactionFee.Text = Convert.ToString(transaction.fee);

            lblTransactionBlockHeight.Text = Convert.ToString(transaction.status.block_height);
            long unixTimestamp = Convert.ToInt64(transaction.status.block_time);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
            lblTransactionBlockTime.Text = dateTime.ToString("yyyyMMdd-HH:mm");
            if (transaction.vin.Count() == 1)
            {
                lblTransactionInputCount.Text = Convert.ToString(transaction.vin.Count()) + " input";
            }
            else
            {
                lblTransactionInputCount.Text = Convert.ToString(transaction.vin.Count()) + " inputs";
            }
            if (transaction.vout.Count() == 1)
            {
                lblTransactionOutputCount.Text = Convert.ToString(transaction.vout.Count()) + " output";
            }
            else
            {
                lblTransactionOutputCount.Text = Convert.ToString(transaction.vout.Count()) + " outputs";
            }
            
            // inputs 
            int NumberOfInputLines = Convert.ToInt32(transaction.vin.Count());
            int YInputsStep = 0;
            int YInputsPos = 0;
            if (NumberOfInputLines > 1)
            {
                YInputsStep = (panelTransactionDiagram.Size.Height - 20) / (NumberOfInputLines - 1);
                YInputsPos = 10;
            }
            else
            {
                YInputsStep = (panelTransactionDiagram.Size.Height / 2) - 20;
                YInputsPos = (panelTransactionDiagram.Size.Height / 2);
            }
                        
            panelTransactionMiddle.Location = new Point((panelTransactionDiagram.Width / 2) - (panelTransactionMiddle.Width / 2), (panelTransactionDiagram.Height / 2) - (panelTransactionMiddle.Height / 2)); //move middle panel to centre
            lblTransactionInputCount.Location = new Point((panelTransactionDiagram.Size.Width / 2) - 130, (panelTransactionDiagram.Size.Height / 2) - 15);
            foreach (var vin in transaction.vin)
            {
                using (Pen pen = new Pen(Color.FromArgb(106, 72, 9), 1))
                {
                    using (var g = panelTransactionDiagram.CreateGraphics())
                    {
                        g.DrawLine(pen, 10, YInputsPos, 100, YInputsPos);
                        g.DrawLine(pen, 100, YInputsPos, (panelTransactionDiagram.Size.Width / 2) - 150, panelTransactionDiagram.Size.Height / 2);
                        YInputsPos += YInputsStep;
                    }
                }
            }
            // outputs
            int NumberOfOutputLines = Convert.ToInt32(transaction.vout.Count());
            int YOutputsStep = 0;
            int YOutputsPos = 0;
            if (NumberOfOutputLines > 1)
            {
                YOutputsStep = (panelTransactionDiagram.Size.Height - 20) / (NumberOfOutputLines - 1);
                YOutputsPos = 10;
            }
            else
            {
                YOutputsStep = (panelTransactionDiagram.Size.Height / 2) - 20;
                YOutputsPos = (panelTransactionDiagram.Size.Height / 2);
            }

            lblTransactionOutputCount.Location = new Point((panelTransactionDiagram.Size.Width / 2) + 130 - lblTransactionOutputCount.Width, (panelTransactionDiagram.Size.Height / 2) - 15);
            foreach (var vout in transaction.vout)
            {
                using (Pen pen = new Pen(Color.FromArgb(106, 72, 9), 1))
                {
                    using (var g = panelTransactionDiagram.CreateGraphics())
                    {
                        g.DrawLine(pen, panelTransactionDiagram.Size.Width - 10, YOutputsPos, panelTransactionDiagram.Size.Width - 100, YOutputsPos);
                        g.DrawLine(pen, panelTransactionDiagram.Size.Width - 100, YOutputsPos, (panelTransactionDiagram.Size.Width / 2) + 150, panelTransactionDiagram.Size.Height / 2);
                        YOutputsPos += YOutputsStep;

                    }
                }
            }

            // central bit
            
            using (Pen pen = new Pen(Color.FromArgb(106, 72, 9), 1))
            {
                using (var g = panelTransactionDiagram.CreateGraphics())
                {
                    g.DrawLine(pen, (panelTransactionDiagram.Size.Width / 2) - 150, panelTransactionDiagram.Size.Height / 2, (panelTransactionDiagram.Size.Width / 2) + 150, panelTransactionDiagram.Size.Height / 2); // central horizontal
                    g.DrawLine(pen, panelTransactionDiagram.Size.Width / 2, panelTransactionDiagram.Size.Height / 2 - panelTransactionMiddle.Height / 2, panelTransactionDiagram.Size.Width / 2, panelTransactionDiagram.Size.Height / 2 - 100); // vertical line up to fees

                }
            }
            lblTransactionFee.Location = new Point((panelTransactionDiagram.Size.Width / 2) - (lblTransactionFee.Width / 2), panelTransactionDiagram.Size.Height / 2 - 120);
            label104.Location = new Point ((panelTransactionDiagram.Size.Width / 2) - (label104.Width / 2), panelTransactionDiagram.Size.Height / 2 - 135);


      
        }


#endregion

#region BLOCK LIST STUFF

        private void textBoxBlockHeightToStartListFrom_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(start, length);
                    textBoxBlockHeightToStartListFrom.SelectionStart = start;
                }
                // If the cursor is not at the beginning, delete the character to the left of the cursor
                else if (textBoxBlockHeightToStartListFrom.SelectionStart > 0)
                {
                    int pos = textBoxBlockHeightToStartListFrom.SelectionStart - 1;
                    textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(pos, 1);
                    textBoxBlockHeightToStartListFrom.SelectionStart = pos;
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
                    textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(start, length);
                    textBoxBlockHeightToStartListFrom.SelectionStart = start;
                }
                // If the cursor is not at the end, delete the character to the right of the cursor
                else if (textBoxBlockHeightToStartListFrom.SelectionStart < textBoxBlockHeightToStartListFrom.Text.Length)
                {
                    int pos = textBoxBlockHeightToStartListFrom.SelectionStart;
                    textBoxBlockHeightToStartListFrom.Text = textBoxBlockHeightToStartListFrom.Text.Remove(pos, 1);
                    textBoxBlockHeightToStartListFrom.SelectionStart = pos;
                }

                e.Handled = true;
                return;
            }

            // Handle enter
            if (e.KeyChar == '\r')
            {
                // Submit button was pressed
                DisableEnableLoadingAnimation("enable"); // start the loading animation
                DisableEnableButtons("disable"); // disable buttons during operation
                LookupBlockList();
                DisableEnableLoadingAnimation("disable"); // stop the loading animation
                DisableEnableButtons("enable"); // enable buttons after operation is complete
                e.Handled = true;
                return;
            }

            // Construct the new value of the textbox by appending the pressed character
            string valueString = textBoxBlockHeightToStartListFrom.Text + e.KeyChar.ToString();

            // Handle the case where the textbox is empty by setting it to 0
            if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
            {
                textBoxBlockHeightToStartListFrom.Text = "0";
                textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
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
                textBoxBlockHeightToStartListFrom.Text = "0";
                textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                e.Handled = true;
                return;
            }

            // Handle input that exceeds the maximum allowed value by setting the textbox to the maximum value
            if (value > maxValue)
            {
                textBoxBlockHeightToStartListFrom.Text = maxValue.ToString();
                textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
                e.Handled = true;
                return;
            }

            textBoxBlockHeightToStartListFrom.Text = value.ToString();
            textBoxBlockHeightToStartListFrom.SelectionStart = textBoxBlockHeightToStartListFrom.Text.Length;
            e.Handled = true;

        }

        private void textBoxBlockHeightToStartListFrom_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBoxBlockHeightToStartListFrom.Text.Trim()))
            {
                textBoxBlockHeightToStartListFrom.Text = "0";
            }
            if (textBoxBlockHeightToStartListFrom.Text == lblBlockNumber.Text)
            {
            }
            
        }

        private async void LookupBlockList()
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

        private async Task GetFifteenBlocksForBlockList(string lastSeenBlockNumber)
        {
            
            DisableEnableLoadingAnimation("enable"); // start the loading animation
            DisableEnableButtons("disable"); // disable buttons during operation

            var blocksJson = await _blockService.GetBlockDataAsync(lastSeenBlockNumber);

            DisableEnableLoadingAnimation("disable"); // stop the loading animation
            DisableEnableButtons("enable"); // enable buttons after operation is complete

            var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
            List<string> blocklist = blocks.Select(t => t.height).ToList();

            // Update lastSeenBlockNumber if this isn't our first fetch of blocks to restart from the right place
            if (blocklist.Count > 0)
            {
                lastSeenBlockNumber = blocklist.Last();
                storedLastSeenBlockNumber = blocklist.Last();
            }

            //LIST VIEW
            listViewBlockList.Items.Clear(); // remove any data that may be there already
            listViewBlockList.GetType().InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewBlockList, new object[] { true });

            // Check if the column header already exists
            if (listViewBlockList.Columns.Count == 0)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add(" Date / time", 115);
            }

            if (listViewBlockList.Columns.Count == 1)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("Height", 65);
            }

            if (listViewBlockList.Columns.Count == 2)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("TX count", 60);
            }
            if (listViewBlockList.Columns.Count == 3)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("Size", 50);
            }
            if (listViewBlockList.Columns.Count == 4)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("Fee range", 70);
            }
            if (listViewBlockList.Columns.Count == 5)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("Med.", 50);
            }
            if (listViewBlockList.Columns.Count == 6)
            {
                // If not, add the column header
                listViewBlockList.Columns.Add("Reward (BTC)", 90);
            }
            // Add the items to the ListView
            int counter = 0; // used to count rows in list as they're added

            foreach (var block in blocks)
            {
                long unixTimestamp = Convert.ToInt64(block.timestamp);
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
                string formattedDateTime = dateTime.ToString("yyyyMMdd-HH:mm");
                ListViewItem item = new ListViewItem(formattedDateTime); // create new row
                item.SubItems.Add(block.height.ToString());
                item.SubItems.Add(block.tx_count.ToString());
                decimal sizeInMB = block.size;
                sizeInMB = sizeInMB / 1000000;
                item.SubItems.Add(sizeInMB.ToString("0.00")); // number of outputs
                string feerange = Convert.ToString(block.extras.feeRange[0]) + "-" + Convert.ToString(block.extras.feeRange[6]);
                item.SubItems.Add(feerange.ToString());
                string medFee = "~" + block.extras.medianFee;
                item.SubItems.Add(medFee.ToString());
                string RewardInSats = Convert.ToString(block.extras.reward);
                decimal RewardInBTC = ConvertSatsToBitcoin(RewardInSats);
                item.SubItems.Add(RewardInBTC.ToString());
                listViewBlockList.Items.Add(item); // add row

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
                lblBlockListPositionInList.Text = "Blocks " + blocklist.Last() + " - " + blocklist.First() + " of " + lblBlockNumber.Text;
            }
            else
            {
                lblBlockListPositionInList.Text = "No blocks to display"; // this can't really happen as there will always be a coinbase transaction
            }
            
        }

        private async void btnOlder15Blocks_Click(object sender, EventArgs e)
        {
            int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) - 1);
            string blockNumber = Convert.ToString(blockheight);
            // Get 15 more blocks starting from the current block height minus the number we've already seen
            await GetFifteenBlocksForBlockList(blockNumber);
            btnViewBlockFromBlockList.Visible = false;
            btnViewTransactionsFromBlockList.Visible = false;
        }

        private async void btnNewer15Blocks_Click(object sender, EventArgs e)
        {
            int blockheight = (Convert.ToInt32(storedLastSeenBlockNumber) + 29);
            string blockNumber = Convert.ToString(blockheight);
            // Get 15 more blocks starting from the current block height minus the number we've already seen
            await GetFifteenBlocksForBlockList(blockNumber);
            btnViewBlockFromBlockList.Visible = false;
            btnViewTransactionsFromBlockList.Visible = false;
        }

        private void listViewBlockList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            
            Color headerColor = Color.FromArgb(50, 50, 50);
            SolidBrush brush = new SolidBrush(headerColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            // Change text color and alignment
            SolidBrush textBrush = new SolidBrush(Color.Silver);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, format);
            
        }

        private void listViewBlockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listViewBlockList.SelectedItems.Count > 0)
            {
                Rectangle itemRect = listViewBlockList.GetItemRect(listViewBlockList.SelectedIndices[0]);
                panel14.Top = itemRect.Top + 8;
                panel19.Height = panel17.Top - panel14.Top;
                panel19.Top = panel14.Top;
            }
            
        }

        private async void listViewBlockList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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
                    btnViewBlockFromBlockList.Location = new Point(item.Position.X + listViewBlockList.Location.X + listViewBlockList.Columns[0].Width + listViewBlockList.Columns[1].Width - btnViewBlockFromBlockList.Width - 3, item.Position.Y + listViewBlockList.Location.Y - 1);
                    btnViewTransactionsFromBlockList.Location = new Point(item.Position.X + listViewBlockList.Location.X + listViewBlockList.Columns[0].Width + listViewBlockList.Columns[1].Width + listViewBlockList.Columns[2].Width - btnViewBlockFromBlockList.Width - 10, item.Position.Y + listViewBlockList.Location.Y - 1);
                    // display block hash
                    using (WebClient client = new WebClient())
                    {
                        string BlockHashURL = NodeURL + "block-height/" + item.SubItems[1].Text;
                        string BlockHash = client.DownloadString(BlockHashURL); // get hash of provided block
                        lblBlockListBlockHash.Text = BlockHash;
                    }
                    string blockNumber = item.SubItems[1].Text;
                    DisableEnableLoadingAnimation("enable"); // start the loading animation
                    DisableEnableButtons("disable"); // disable buttons during operation
                    var blocksJson = await _blockService.GetBlockDataAsync(blockNumber);
                    var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksJson);
                    List<string> blocklist = blocks.Select(t => t.height).ToList();
                    lblBlockListBlockTime.Text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(blocks[0].timestamp)).ToString("yyyy-MM-dd HH:mm");
                    long sizeInBytes = blocks[0].size;
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
                    lblBlockListBlockSize.Text = sizeString;
                    string strWeight = Convert.ToString(blocks[0].weight);
                    decimal decWeight = decimal.Parse(strWeight) / 1000000m; // convert to MWU
                    string strFormattedWeight = decWeight.ToString("N2"); // Display to 2 decimal places
                    lblBlockListBlockWeight.Text = strFormattedWeight;
                    long nonceLong = Convert.ToInt64(blocks[0].nonce);
                    lblBlockListNonce.Text = "0x" + nonceLong.ToString("X");
                    lblBlockListMiner.Text = Convert.ToString(blocks[0].extras.pool.name);
                    lblBlockListTransactionCount.Text = Convert.ToString(blocks[0].tx_count);
                    string TotalBlockFees = Convert.ToString(blocks[0].extras.totalFees);
                    TotalBlockFees = Convert.ToString(ConvertSatsToBitcoin(TotalBlockFees));
                    lblBlockListTotalFees.Text = TotalBlockFees;
                    string Reward = Convert.ToString(blocks[0].extras.reward);
                    lblBlockListReward.Text = Convert.ToString(ConvertSatsToBitcoin(Reward));
                    lblBlockListBlockFeeRangeAndMedianFee.Text = Convert.ToString(blocks[0].extras.feeRange[0]) + "-" + Convert.ToString(blocks[0].extras.feeRange[6]) + " / " + Convert.ToString(blocks[0].extras.medianFee);
                    lblBlockListAverageFee.Text = Convert.ToString(blocks[0].extras.avgFee);
                    lblBlockListTotalInputs.Text = Convert.ToString(blocks[0].extras.totalInputs);
                    lblBlockListTotalOutputs.Text = Convert.ToString(blocks[0].extras.totalOutputs);
                    lblBlockListAverageTransactionSize.Text = Convert.ToString(blocks[0].extras.avgTxSize);
                    lblBlockListVersion.Text = Convert.ToString(blocks[0].version);
                    lblBlockListBlockHeight.Text = "Block height: " + Convert.ToString(blocks[0].height);
                    DisableEnableLoadingAnimation("disable"); // stop the loading animation
                    DisableEnableButtons("enable"); // enable buttons after operation is complete
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

        private void btnViewTransactionsFromBlockList_Click(object sender, EventArgs e)  // this and btnViewBlockFromBlockList_Click do exactly the same. They both exist for UI only
        {
            //assign block number to text box on block panel
            // Get the selected item
            ListViewItem selectedItem = listViewBlockList.SelectedItems[0];
            // Get the second subitem in the selected item (index 1)
            string submittedBlockNumber = selectedItem.SubItems[1].Text;
            // Set the text of the textBoxSubmittedBlockNumber control
            textBoxSubmittedBlockNumber.Text = submittedBlockNumber;
            LookupBlock();
            //show the block screen
            btnMenuBlock_Click(sender, e);
        }

        private void btnViewBlockFromBlockList_Click(object sender, EventArgs e)  // this and btnViewTransactionsFromBlockList_Click do exactly the same. They both exist for UI only
        {
            //assign block number to text box on block panel
            // Get the selected item
            ListViewItem selectedItem = listViewBlockList.SelectedItems[0];
            // Get the second subitem in the selected item (index 1)
            string submittedBlockNumber = selectedItem.SubItems[1].Text;
            // Set the text of the textBoxSubmittedBlockNumber control
            textBoxSubmittedBlockNumber.Text = submittedBlockNumber;
            LookupBlock();
            //show the block screen
            btnMenuBlock_Click(sender, e);
        }

        private void listViewBlockList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
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

        private void listViewBlockList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

        //=============================================================================================================
        //--------------------COUNTDOWN, ERROR MESSAGES AND STATUS LIGHTS----------------------------------------------
        private void UpdateOnScreenCountdownAndFlashLights()
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
            lblElapsedSinceUpdate.Location = new Point(lblStatusMessPart1.Location.X + lblStatusMessPart1.Width, lblElapsedSinceUpdate.Location.Y);
        }

        private void ChangeStatusLights()
        {
            if (lblStatusLight.ForeColor != Color.IndianRed && lblStatusLight.ForeColor != Color.OliveDrab) // check whether a data refresh has just occured to see if a status light flash needs dimming
            {
                if (lblStatusLight.ForeColor == Color.Lime) // successful data refresh has occured
                {
                    lblStatusLight.ForeColor = Color.OliveDrab; // reset the colours to a duller version to give appearance of a flash
                }
                else // an error must have just occured
                {
                    lblStatusLight.ForeColor = Color.IndianRed; // reset the colours to a duller version to give appearance of a flash
                }
            }
        }

        private void ClearAlertAndErrorMessage()
        {
            lblAlert.Text = ""; // clear any error message
            lblErrorMessage.Text = ""; // clear any error message
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
            using (var client = new HttpClient())
            {
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
                        lblNodeStatusLight.ForeColor = Color.OliveDrab;
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

#endregion

#region GENERAL FORM NAVIGATION AND CONTROLS
        //=============================================================================================================        
        //-------------------------- GENERAL FORM NAVIGATION/BUTTON CONTROLS-------------------------------------------

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
            if (panelMenu.Height == 24)
            {
                panelMenu.Height = 216;
            }
            else
            {
                panelMenu.Height = 24;
            }
        }

        private void BtnMenuSplash_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
            splash splash = new splash(); // invoke the about/splash screen
            splash.ShowDialog();
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
            panelMenu.Height = 24; //close menu
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMoveWindow_MouseUp(object sender, MouseEventArgs e) // reset colour of the move form control
        {
            btnMoveWindow.BackColor = System.Drawing.ColorTranslator.FromHtml("#1D1D1D");
        }

        private void btnMoveWindow_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24; //close menu
        }

        private void BtnMenuBitcoinDashboard_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
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
            panelMenu.Height = 24;
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
            panelMenu.Height = 24;
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

        private void btnMenuBlock_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
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
                textBoxSubmittedBlockNumber.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                LookupBlock(); // fetch all the block data automatically for the initial view. 
            }
        }

        private void lblBlockNumber_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
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

        private void btnMenuBlockList_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
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
                textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                LookupBlockList(); // fetch the first 15 blocks automatically for the initial view. 
            }
        }

        private void btnMenuTransaction_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
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
                textBoxBlockHeightToStartListFrom.Text = lblBlockNumber.Text; // pre-populate the block field on the Block screen)
                LookupBlockList(); // fetch the first 15 blocks automatically for the initial view. 
            }
        }

        private void BtnMenuSettings_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 24;
            settingsScreen.CreateInstance();
            settingsScreen.Instance.ShowDialog();
            // read all fields from the settings screen and set variables for use on the main form
            if (settingsScreen.Instance.BitcoinExplorerEndpointsEnabled)
            {
                RunBitcoinExplorerEndpointAPI = true;
            }
            else
            {
                RunBitcoinExplorerEndpointAPI = false;
            }
            if (settingsScreen.Instance.BlockchainInfoEndpointsEnabled)
            {
                RunBlockchainInfoEndpointAPI = true;
            }
            else
            {
                RunBlockchainInfoEndpointAPI = false;
            }
            if (settingsScreen.Instance.BitcoinExplorerOrgJSONEnabled)
            {
                RunBitcoinExplorerOrgJSONAPI = true;
            }
            else
            {
                RunBitcoinExplorerOrgJSONAPI = false;
            }
            if (settingsScreen.Instance.BlockchainInfoJSONEnabled)
            {
                RunBlockchainInfoJSONAPI = true;
            }
            else
            {
                RunBlockchainInfoJSONAPI = false;
            }
            if (settingsScreen.Instance.CoingeckoComJSONEnabled)
            {
                RunCoingeckoComJSONAPI = true;
            }
            else
            {
                RunCoingeckoComJSONAPI = false;
            }
            if (settingsScreen.Instance.BlockchairComJSONEnabled)
            {
                RunBlockchairComJSONAPI = true;
            }
            else
            {
                RunBlockchairComJSONAPI = false;
            }
            if (settingsScreen.Instance.MempoolSpaceLightningJSONEnabled)
            {
                RunMempoolSpaceLightningAPI = true;
            }
            else
            {
                RunMempoolSpaceLightningAPI = false;
            }
            if (settingsScreen.Instance.NodeURL != NodeURL)
            {
                NodeURL = settingsScreen.Instance.NodeURL;
                _transactionsForAddressService = new TransactionsForAddressService(NodeURL);
            }
            CheckBlockchainExplorerApiStatus();

            if (APIGroup1DisplayTimerIntervalSecsConstant != (settingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60)) // if user has changed refresh frequency
            {
                APIGroup1DisplayTimerIntervalSecsConstant = settingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60;
                intAPIGroup1TimerIntervalMillisecsConstant = ((settingsScreen.Instance.APIGroup1RefreshInMinsSelection * 60) * 1000);
                intDisplayCountdownToRefresh = APIGroup1DisplayTimerIntervalSecsConstant;
                timerAPIGroup1.Stop();
                timerAPIGroup1.Interval = intAPIGroup1TimerIntervalMillisecsConstant;
                timerAPIGroup1.Start();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e) // help screen
        {
            var modalWindow = new helpScreen();
            modalWindow.Owner = this; // Set the parent window as the owner of the modal window
            modalWindow.StartPosition = FormStartPosition.CenterParent; // Set the start position to center of parent
            modalWindow.ShowDialog();
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
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSeconds.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
            lblSeconds.Location = new Point(lblTime.Location.X + lblTime.Width - 10, lblSeconds.Location.Y); // place the seconds according to the width of the minutes/seconds (lblTime)
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
                using (var client = new HttpClient())
                {
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
                    catch (HttpRequestException ex)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
            }
            return string.Empty;
        }
    }

    public class AddressTransactions
    {
        public string txid { get; set; }
        public Status_AddressTransactions status { get; set; }
        public List<Vout_AddressTransactions> vout { get; set; }
        public List<Vin_AddressTransactions> vin { get; set; }
    }

    public class Vin_AddressTransactions
    {
        public Prevout_AddressTransactions prevout { get; set; }
        public decimal value { get; set; }
        public decimal amount { get; set; }
    }

    public class Prevout_AddressTransactions
    {
        public string scriptpubkey_address { get; set; }
        public decimal value { get; set; }
    }

    public class Vout_AddressTransactions
    {
        public double value { get; set; }
        public decimal amount { get; set; }
        public string scriptpubkey_address { get; set; }
    }

    public class Status_AddressTransactions
    {
        public int block_height { get; set; }
        public string confirmed { get; set; }
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
                using (var client = new HttpClient())
                {
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
                    catch (HttpRequestException ex)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
            }
            return string.Empty;
        }
    }

    public class Block
    {
        public Block_extras extras { get; set; }
        public string Id { get; set; }
        public string height { get; set; }
        public string version { get; set; }
        public string timestamp { get; set; }
        public string bits { get; set; }
        public string nonce { get; set; }
        public string difficulty { get; set; }
        public string merkle_root { get; set; }
        public int tx_count { get; set; }
        public int size { get; set; }
        public string weight { get; set; }
        public string previousblockhash { get; set; }
    }

    public class Block_extras
    {
        public string reward { get; set; }
        public string medianFee { get; set; }
        public int[] feeRange { get; set; }
        public int totalFees { get; set; }
        public string avgFee { get; set; }
        public string avgFeeRate { get; set; }
        public string avgTxSize { get; set; }
        public string totalInputs { get; set; }
        public string totalOutputs { get; set; }
        public string totalOutputAmt { get; set; }
        public Block_pool pool { get; set; }

    }

    public class Block_pool
    {
        public string name { get; set; }
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
                using (var client = new HttpClient())
                {
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
                    catch (HttpRequestException ex)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
            }
            return string.Empty;
        }
    }

    public class Transaction
    {
        public string txid { get; set; }
        public int version { get; set; }
        public int locktime { get; set; }
        public TransactionVin[] vin { get; set; }
        public TransactionVout[] vout { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public int fee { get; set; }
        public TransactionStatus status { get; set; }
    }

    public class TransactionStatus
    {
        public bool confirmed { get; set; }
        public int block_height { get; set; }
        public string block_hash { get; set; }
        public int block_time { get; set; }
    }

    public class TransactionVin
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public TransactionVinPrevout prevout { get; set; }
        public string scriptsig { get; set; }
        public string scriptsig_asm { get; set; }
        public string[] witness { get; set; }
        public bool is_coinbase { get; set; }
        public long sequence { get; set; }
        public string inner_redeemscript_asm { get; set; }
    }

    public class TransactionVinPrevout
    {
        public string scriptpubkey { get; set; }
        public string scriptpubkey_asm { get; set; }
        public string scriptpubkey_type { get; set; }
        public string scriptpubkey_address { get; set; }
        public long value { get; set; }
    }

    public class TransactionVout
    {
        public string scriptpubkey { get; set; }
        public string scriptpubkey_asm { get; set; }
        public string scriptpubkey_type { get; set; }
        public string scriptpubkey_address { get; set; }
        public long value { get; set; }
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
                using (var client = new HttpClient())
                {
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
                    catch (HttpRequestException ex)
                    {
                        retryCount--;
                        await Task.Delay(3000);
                    }
                }
            }
            return null;
        }
    }


    public class Block_Transactions
    {
        public string txid { get; set; }
        //      public string version { get; set; }
        //     public string locktime { get; set; }
        public List<Vin_BlockTransactions> vin { get; set; }
        public List<Vout_BlockTransactions> vout { get; set; }
        //      public string size { get; set; }
        //      public string weight { get; set; }
        public string fee { get; set; }
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
        public string is_coinbase { get; set; }
        //   public string sequence { get; set; }
    }


    public class Prevout_BlockTransactions
    {
        public string scriptpubkey { get; set; }
        public string scriptpubkey_asm { get; set; }
        public string scriptpubkey_type { get; set; }
        public string scriptpubkey_address { get; set; }
        public string value { get; set; }
    }

    public class Status_BlockTransactions
    {
        public string confirmed { get; set; }
        public string block_height { get; set; }
        public string block_hash { get; set; }
        public string block_time { get; set; }
    }

    public class Vout_BlockTransactions
    {
        //     public string scriptpubkey { get; set; }
        //     public string scriptpubkey_asm { get; set; }
        //    public string scriptpubkey_type { get; set; }
        //    public string scriptpubkey_address { get; set; }
        public string value { get; set; }
    }
    #endregion

}
//==================================================================================================================================================================================================
//======================================================================================== END =====================================================================================================
//==================================================================================================================================================================================================


