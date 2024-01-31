#region using
using CustomControls.RJControls;
using ScottPlot.Palettes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

#endregion

namespace SATSuma
{
    public partial class HelpScreen : Form
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
        public Color TextColor { get; set; }
        public Color HeadingTextColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor2 { get; set; }
        public Color ButtonBackColor2 { get; set; }
        public Color TextBoxBackColor { get; set; }
        public Color TextBoxForeColor { get; set; }
        public Color WindowBackgroundColor { get; set; }
        public int ButtonRadius { get; set; }
        public int ButtonBorderSize { get; set; }
        public Color ButtonBorderColor { get; set; }
        public Color DataFieldColor { get; set; }

        private bool linkClicked = false; // used to supress multiple events (and multiple browser tabs) when opening external link in default browser
        #endregion
        #region initialize
        public HelpScreen(double UIScale)
        {
            InitializeComponent();

            #region UIScale
            storeOriginalDimensions(this);

            btnScaleApply(this);

            void btnScaleApply(Control parentControl)
            {
                this.Width = (int)(474 * UIScale);
                this.Height = (int)(588 * UIScale);

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
                    //HandleException(ex, "btnScaleApply");
                }
            }
            #region apply UIScale to all controls
            #endregion

            #region restore UIScale


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
                    //        HandleException(ex, "storeOriginalDimensions");
                }
            }
            #endregion

            #endregion

            panelComboBoxDocumentationContainer.Paint += Panel_Paint;
            //panel1.Paint += Panel_Paint;
            #region rounded form
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            Padding = new Padding(1);
            #endregion
        }
        #region assign colours and determine which text to show

        public Color MakeColorLighter(Color color, double percentage)
        {
            int red = (int)Math.Min(255, color.R + 255 * percentage / 100);
            int green = (int)Math.Min(255, color.G + 255 * percentage / 100);
            int blue = (int)Math.Min(255, color.B + 255 * percentage / 100);

            return Color.FromArgb(color.A, red, green, blue);
        }

        private void HelpScreen_Load(object sender, EventArgs e)
        {


            lblHelpHeading.ForeColor = HeadingTextColor;
            btnExit.ForeColor = ButtonTextColor;
            btnHelpTextUp.ForeColor = ButtonTextColor;
            btnHelpTextDown.ForeColor = ButtonTextColor;
            btnExit.BackColor = ButtonBackColor;
            btnHelpTextUp.BackColor = ButtonBackColor;
            btnHelpTextDown.BackColor = ButtonBackColor;
            btnExit.BorderRadius = ButtonRadius;
            btnExit.BorderSize = ButtonBorderSize;
            btnExit.BorderColor = ButtonBorderColor;
            btnHelpTextUp.BorderRadius = ButtonRadius;
            btnHelpTextUp.BorderSize = ButtonBorderSize;
            btnHelpTextUp.BorderColor = ButtonBorderColor;
            btnHelpTextDown.BorderRadius = ButtonRadius;
            btnHelpTextDown.BorderSize = ButtonBorderSize;
            btnHelpTextDown.BorderColor = ButtonBorderColor;
            panelComboBoxDocumentationContainer.BackColor = TextBoxBackColor;
            comboBoxDocumentation.ForeColor = TextBoxForeColor;
            comboBoxDocumentation.ListBackColor = TextBoxBackColor;
            comboBoxDocumentation.ListTextColor = TextBoxForeColor;
            //panel1.BackColor = MakeColorLighter(WindowBackgroundColor, 5);
            panel1.BackColor = WindowBackgroundColor;
            this.BackColor = WindowBackgroundColor;

            panel1.VerticalScroll.Visible = false;
            if (((SATSuma)this.Owner).GetPanelMenu().Visible == true && ((SATSuma)this.Owner).GetPanelMenu().Height > 24) // menu is open so main help page has been requested
            {
                //((SATSuma)this.Owner).GetPanelMenu().Height = 0; // close menu on calling window
                lblHelpHeading.Text = "Documentation";
            }
            else
            if (((SATSuma)this.Owner).GetPanelBlock().Visible == true)
            {
                lblHelpHeading.Text = "Block";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-block/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelCharts().Visible == true)
            {
                lblHelpHeading.Text = "Charts";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-charts/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelBlockList().Visible == true)
            {
                lblHelpHeading.Text = "Blocks";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-blocks/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelAddress().Visible == true)
            {
                lblHelpHeading.Text = "Address";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-address/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelBitcoinDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-bitcoindashboard/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelLightningDashboard().Visible == true)
            {
                lblHelpHeading.Text = "Lightning dashboard";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-lightningdashboard/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelTransaction().Visible == true)
            {
                lblHelpHeading.Text = "Transaction";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-transaction/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelXpub().Visible == true)
            {
                lblHelpHeading.Text = "Xpub";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-xpub/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelBookmarks().Visible == true)
            {
                lblHelpHeading.Text = "Bookmarks";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-bookmarks/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelDirectory().Visible == true)
            {
                lblHelpHeading.Text = "Directory";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-directory/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelSettings().Visible == true)
            {
                lblHelpHeading.Text = "Settings";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-settings/");
            }
            else
            if (((SATSuma)this.Owner).GetPanelAppearance().Visible == true)
            {
                lblHelpHeading.Text = "Customize";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-themes/");
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

        private void HelpScreen_Paint(object sender, PaintEventArgs e)
        {
            if (this.BackColor == Color.FromArgb(40, 40, 40) || this.BackColor == Color.FromArgb(51,47,45))
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
        #region scroll help text
        private Timer scrollTimer;
        private readonly int scrollStep = 6;
        private void BtnHelpTextDown_MouseDown(object sender, MouseEventArgs e)
        {
            scrollTimer = new Timer
            {
                Interval = 1 // scrolling speed
            };
            scrollTimer.Tick += (s, ev) =>
            {
                // Inject JavaScript to scroll down
                InjectJavaScript($"window.scrollBy(0, {scrollStep});");
            };
            scrollTimer.Start();
        }

        private void BtnHelpTextUp_MouseDown(object sender, MouseEventArgs e)
        {
            scrollTimer = new Timer
            {
                Interval = 1 // scrolling speed
            };
            scrollTimer.Tick += (s, ev) =>
            {
                // Inject JavaScript to scroll up
                InjectJavaScript($"window.scrollBy(0, -{scrollStep});");
            };
            scrollTimer.Start();
        }

        private void BtnHelpTextDown_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop the timer when the mouse button is released
            scrollTimer.Stop();
            scrollTimer.Dispose();
        }

        private void BtnHelpTextUp_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop the timer when the mouse button is released
            scrollTimer.Stop();
            scrollTimer.Dispose();
        }
        #endregion
        #region handle combobox
        #endregion
        #region rounded panel
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)sender;
            // Create a GraphicsPath object with rounded corners
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int cornerRadius = ButtonRadius;
            cornerRadius *= 2;
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            // Set the panel's region to the rounded path
            panel.Region = new Region(path);
        }
        #endregion

        private void BtnHelpTextDown_Click(object sender, EventArgs e)
        {
            if (webBrowserDocumentation.Document != null)
            {
                InjectJavaScript("window.scrollBy(0, 4);");
            }
        }
        private void BtnHelpTextUp_Click(object sender, EventArgs e)
        {
            if (webBrowserDocumentation.Document != null)
            {
                InjectJavaScript("window.scrollBy(0, -4);");
            }
        }

        private void InjectJavaScript(string script)
        {
            
            if (webBrowserDocumentation.Document != null)
            {
                HtmlElement head = webBrowserDocumentation.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptElement = webBrowserDocumentation.Document.CreateElement("script");
                scriptElement.SetAttribute("text", script);
                head.AppendChild(scriptElement);
            }
        }

        private void ComboBoxDocumentation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDocumentation.SelectedIndex == 0)
            {
                lblHelpHeading.Text = "Blocks";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-blocks/");
            }
            if (comboBoxDocumentation.SelectedIndex == 1)
            {
                lblHelpHeading.Text = "Block";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-block/");
            }
            if (comboBoxDocumentation.SelectedIndex == 2)
            {
                lblHelpHeading.Text = "Address";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-address/");
            }
            if (comboBoxDocumentation.SelectedIndex == 3)
            {
                lblHelpHeading.Text = "Transaction";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-transaction/");
            }
            if (comboBoxDocumentation.SelectedIndex == 4)
            {
                lblHelpHeading.Text = "Xpub";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-xpub/");
            }
            if (comboBoxDocumentation.SelectedIndex == 5)
            {
                lblHelpHeading.Text = "Charts";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-charts/");
            }
            if (comboBoxDocumentation.SelectedIndex == 6)
            {
                lblHelpHeading.Text = "Bitcoin dashboard";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-bitcoindashboard/");
            }
            if (comboBoxDocumentation.SelectedIndex == 7)
            {
                lblHelpHeading.Text = "Lightning dashboard";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-lightningdashboard/");
            }
            if (comboBoxDocumentation.SelectedIndex == 8)
            {
                lblHelpHeading.Text = "Bookmarks";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-bookmarks/");
            }
            if (comboBoxDocumentation.SelectedIndex == 9)
            {
                lblHelpHeading.Text = "Directory";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-directory/");
            }
            if (comboBoxDocumentation.SelectedIndex == 10)
            {
                lblHelpHeading.Text = "Settings";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-settings/");
            }
            if (comboBoxDocumentation.SelectedIndex == 11)
            {
                lblHelpHeading.Text = "Themes";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-themes/");
            }
            if (comboBoxDocumentation.SelectedIndex == 13)
            {
                lblHelpHeading.Text = "Release notes";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-version-history/");
            }
            if (comboBoxDocumentation.SelectedIndex == 14)
            {
                lblHelpHeading.Text = "FAQ";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-faq/");
            }
            if (comboBoxDocumentation.SelectedIndex == 15)
            {
                lblHelpHeading.Text = "Source code";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-source-code/");
            }
            if (comboBoxDocumentation.SelectedIndex == 16)
            {
                lblHelpHeading.Text = "Support SATSuma";
                webBrowserDocumentation.Url = new Uri("https://satsuma.btcdir.org/help-support-satsuma/");
            }
        }

        private void WebBrowserDocumentation_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Get the page
            var document = webBrowserDocumentation.Document;

            // Modify background color
            var backgroundColor = MakeColorLighter(WindowBackgroundColor, 5); 
            var backgroundColorString = ColorTranslator.ToHtml(backgroundColor);
            document.Body.Style = $"background-color: {backgroundColorString};";

            // Change the color of all text
            var spanColor = TextColor;
            var spanColorString = ColorTranslator.ToHtml(spanColor);
            var spanElements = document.GetElementsByTagName("p");
            foreach (HtmlElement spanElement in spanElements)
            {
                spanElement.Style = $"color: {spanColorString}";
                if (spanElement.GetAttribute("className") == "breaklongword")
                {
                    spanElement.Style = $"word-wrap: break-word;";
                    
                }
            }

            // Change the color of all titles
            var titleColor = HeadingTextColor;
            var titleColorString = ColorTranslator.ToHtml(titleColor);
            var titleElements = document.GetElementsByTagName("h5");
            foreach (HtmlElement titleElement in titleElements)
            {
                if (titleElement.GetAttribute("className") == "wp-block-heading")
                {
                    titleElement.Style = $"color: {titleColorString}";
                }
            }

            // Change the color of all tables
            var tableColor = MakeColorLighter(WindowBackgroundColor, 10);
            var tableColorString = ColorTranslator.ToHtml(tableColor);
            var tableElements = document.GetElementsByTagName("table");
            foreach (HtmlElement tableElement in tableElements)
            {
               tableElement.Style = $"background-color: {tableColorString}";
            }

            var figureColor = MakeColorLighter(WindowBackgroundColor, 10);
            var figureColorString = ColorTranslator.ToHtml(figureColor);
            var figureElements = document.GetElementsByTagName("figure");
            foreach (HtmlElement figureElement in figureElements)
            {
                if (figureElement.GetAttribute("className") == "supportproject")
                {
                    figureElement.Style = $"font-size: 10px";
                }
            }

            // Change the color of all table cell text
            var cellColor = spanColor;
            var cellColorString = ColorTranslator.ToHtml(cellColor);
            var cellElements = document.GetElementsByTagName("td");
            foreach (HtmlElement cellElement in cellElements)
            {
                cellElement.Style = $"color: {cellColorString}";
            }
            // Change the color of all table column headings
            var cell2Color = spanColor;
            var cell2ColorString = ColorTranslator.ToHtml(cell2Color);
            var cell2Elements = document.GetElementsByTagName("th");
            foreach (HtmlElement cell2Element in cell2Elements)
            {
                cell2Element.Style = $"color: {cell2ColorString}";
            }

            // Change the color of all links
            var linkColor = DataFieldColor;
            var linkColorString = ColorTranslator.ToHtml(linkColor);
            var linkElements = document.GetElementsByTagName("a");
            foreach (HtmlElement linkElement in linkElements)
            {
                linkElement.Style = $"color: {linkColorString}";
            }
            // Attach a custom event handler to all anchor (<a>) elements in the loaded document
            // to enable links to open in default browser rather than IE
            foreach (HtmlElement linkElement in webBrowserDocumentation.Document.Links)
            {
                linkElement.Click += LinkElement_Click;
            }
            
        }
        private void LinkElement_Click(object sender, HtmlElementEventArgs e)
        {
            if (linkClicked) return; // If the link was already clicked less than a second ago, do nothing (linkClicked resets to false 1 sec after clicking link. Not doing this spawns multiple tabs)

            HtmlElement linkElement = sender as HtmlElement;
            if (linkElement != null)
            {
                string url = linkElement.GetAttribute("href");

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error opening link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Set the linkClicked flag to true to avoid multiple tabs for a single click
                linkClicked = true;
                externalLinksTimer.Start();

                // Cancel the default behavior for the link click to stop IE opening
                e.ReturnValue = false;
            }
        }

        private void ExternalLinksTimer_Tick(object sender, EventArgs e)
        {
            linkClicked = false;
            externalLinksTimer.Stop();
        }



    }
}
