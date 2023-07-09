using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATSuma
{
    public partial class Splash : Form
    {
        public Color WindowBackgroundColor { get; set; }
        public Color LabelColor { get; set; }
        public Color LinksColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public string CurrentVersion { get; set; }
        public bool PrivacyMode { get; set; }

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            BackColor = WindowBackgroundColor;
            lblVersion.ForeColor = LabelColor;
            lblUpToDate.ForeColor = LabelColor;
            lblVersionAvailable.ForeColor = LabelColor;
            lblErrorMessage.ForeColor = LabelColor;
            linkLabelDownloadUpdate.ForeColor = LinksColor;
            linkLabelSupportProject.ForeColor = LinksColor;
            linkLabelSourceCode.ForeColor = LinksColor;
            btnExit.BackColor = ButtonBackColor;
            btnExit.ForeColor = ButtonTextColor;
            lblVersion.Text = "SATSuma v" + CurrentVersion;
            CheckForUpdates();
        }

        private void Splash_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void LinkLabelDownloadUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://satsuma.btcdir.org/download/");
        }

        private void LinkLabelSupportProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://satsuma.btcdir.org/support/");
        }

        private void LinkLabelSourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BXL909/SATSuma");
        }

        private void CheckForUpdates()
        {
            try
            {
                if (!PrivacyMode)
                { 
                    using WebClient client = new WebClient();
                    string VersionURL = "https://satsuma.btcdir.org/SATSumaVersion.txt";
                    string LatestVersion = client.DownloadString(VersionURL);

                    if (LatestVersion != CurrentVersion)
                    {
                        lblUpToDate.Visible = false;
                        lblVersionAvailable.Invoke((MethodInvoker)delegate
                        {
                            lblVersionAvailable.Text = "v" + LatestVersion + " available";
                            lblVersionAvailable.Visible = true;
                        });
                        linkLabelDownloadUpdate.Invoke((MethodInvoker)delegate
                        {
                            linkLabelDownloadUpdate.Text = "download update";
                            linkLabelDownloadUpdate.Visible = true;
                        });
                        
                    }
                    else
                    {
                        lblUpToDate.Visible = true;
                        linkLabelDownloadUpdate.Visible = false;
                    }
                }
                else
                {
                    lblVersionAvailable.Visible = false;
                    lblUpToDate.Visible = false;
                    linkLabelDownloadUpdate.Invoke((MethodInvoker)delegate
                    {
                        linkLabelDownloadUpdate.Text = "check for update";
                        linkLabelDownloadUpdate.Visible = true;
                    });
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            string errorMessage;
            if (ex is WebException)
            {
                errorMessage = "Web exception occurred";
            }
            else if (ex is HttpRequestException)
            {
                errorMessage = "HTTP Request error";
            }
            else
            {
                errorMessage = "Error occurred";
            }

            lblErrorMessage.Invoke((MethodInvoker)delegate
            {
                lblErrorMessage.Text = errorMessage;
                lblErrorMessage.Visible = true;
            });
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bxl909.github.io/");
        }
    }
}
