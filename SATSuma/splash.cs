#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace SATSuma
{
    public partial class Splash : Form
    {
        #region rounded form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
         );
        #endregion
        #region variable declaration
        public Color WindowBackgroundColor { get; set; }
        public Color LabelColor { get; set; }
        public Color LinksColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public string CurrentVersion { get; set; }
        public bool PrivacyMode { get; set; }
        public int ButtonRadius { get; set; }
        public int ButtonBorderSize { get; set; }
        public Color ButtonBorderColor { get; set; }
        #endregion
        #region initialize
        public Splash()
        {
            InitializeComponent();
            #region rounded form
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            #endregion
        }
        #region assign colors & check for updates
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
            btnExit.BorderRadius = ButtonRadius;
            btnExit.BorderSize = ButtonBorderSize;
            btnExit.BorderColor = ButtonBorderColor;
            CheckForUpdates();
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
        #endregion
        #endregion
        #region rounded form
        private GraphicsPath GetRoundedRect(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            path.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            path.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
                
        private void Splash_Paint(object sender, PaintEventArgs e)
        {
            // Paint the border with a 1-pixel width
            using var pen = new Pen(BackColor, 3);
            var rect = ClientRectangle;
            rect.Inflate(-1, -1);
            e.Graphics.DrawPath(pen, GetRoundedRect(rect, 30));
        }
        #endregion
        #region handle links
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bxl909.github.io/");
        }
        #endregion
        #region error handler

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
        #endregion
    }
}
