#region using
using CustomControls.RJControls;
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
        public bool OfflineMode { get; set; }
        public int ButtonRadius { get; set; }
        public int ButtonBorderSize { get; set; }
        public Color ButtonBorderColor { get; set; }
        #endregion
        #region initialize
        public Splash(double UIScale)
        {
            InitializeComponent();

            #region UIScale
            storeOriginalDimensions(this);

            btnScaleApply(this);

            void btnScaleApply(Control parentControl)
            {
                this.Width = (int)(378 * UIScale);
                this.Height = (int)(206 * UIScale);

                try
                {
                    // Resize each control within the provided parentControl
                    foreach (Control control in parentControl.Controls)
                    {
                        System.Windows.Size originalSize = ((Tuple<System.Windows.Size, Font>)control.Tag).Item1;

                        // apply a scaled radius to buttons to keep them fully rounded
                        if (control.GetType() == typeof(RJButton))
                        {
                            RJButton rjButton = (RJButton)control;
                            // Set the borderRadius to a different value for each RJButton
                            rjButton.BorderRadius = (int)(11 * UIScale);
                        }

                        control.Width = (int)(originalSize.Width * UIScale);
                        control.Left = (int)(control.Left * UIScale);
                        control.Top = (int)(control.Top * UIScale);
                        control.Height = (int)(originalSize.Height * UIScale);

                        // Resize font size
                        if (control.Font != null)
                        {
                            Font originalControlFont = ((Tuple<System.Windows.Size, Font>)control.Tag).Item2;
                            float scaledFontSize = (float)(originalControlFont.Size * UIScale);
                            control.Font = new Font(originalControlFont.FontFamily, scaledFontSize - 1, originalControlFont.Style);
                        }

                        // Recursively handle controls within panels
                        if (control.HasChildren)
                        {
                            btnScaleApply(control);
                        }
                    }

                    // Trigger layout update for child controls
                    parentControl.PerformLayout();
                    parentControl.Invalidate();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            void storeOriginalDimensions(Control parentControl)
            {
                try
                {
                    foreach (Control control in parentControl.Controls)
                    {
                        control.Tag = new System.Windows.Size(control.Width, control.Height);

                        // Store the original font size of each control
                        if (control.Font != null)
                        {
                            control.Tag = new Tuple<System.Windows.Size, Font>((System.Windows.Size)control.Tag, control.Font);
                        }

                        // Recursively handle controls within panels
                        if (control.HasChildren)
                        {
                            storeOriginalDimensions(control);
                        }
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            #endregion

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
                if (!OfflineMode)
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
            if (this.BackColor == Color.FromArgb(40, 40, 40) || this.BackColor == Color.FromArgb(51, 47, 45))
            {
                using var pen = new Pen(Color.DimGray, 1);
                var rect = ClientRectangle;
                rect.Inflate(-1, -1);
                e.Graphics.DrawPath(pen, GetRoundedRect(rect, 30));
            }
            else
            {
                using var pen = new Pen(WindowBackgroundColor, 3);
                var rect = ClientRectangle;
                rect.Inflate(-1, -1);
                e.Graphics.DrawPath(pen, GetRoundedRect(rect, 30));
            }
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
