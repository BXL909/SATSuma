using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SATSuma
{
    public partial class FullSizeLoadingScreen : Form
    {
        #region rounded form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        public Color LabelColor { get; set; }
        public string Version { get; set; }
        public Color OtherText {  get; set; }

        public FullSizeLoadingScreen(double UIScale)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            // Retrieve the current DPI scale factor
            float scale = this.CreateGraphics().DpiX / 96.0f;
            this.Width = (int)(940 * scale * UIScale);
            this.Height = (int)(754 * scale * UIScale);

            // Create and set the rounded region
            GraphicsPath path = RoundedRectangle.Create(0, 0, Width, Height, 30);
            this.Region = new Region(path);
        }

        public static class RoundedRectangle
        {
            public static GraphicsPath Create(int x, int y, int width, int height, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(x, y, radius, radius, 180, 90);
                path.AddLine(x + radius, y, x + width - radius, y);
                path.AddArc(x + width - radius, y, radius, radius, 270, 90);
                path.AddLine(x + width, y + radius, x + width, y + height - radius);
                path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                path.AddLine(x + width - radius, y + height, x + radius, y + height);
                path.AddArc(x, y + height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                return path;
            }
        }

        public void SetLoadingText(string text, string headlineText)
        {
            lblCurrentVersion.Invoke((MethodInvoker)delegate
            {
                lblCurrentVersion.Text = Version;
                lblCurrentVersion.ForeColor = OtherText;
            });
            panel2.Invoke((MethodInvoker)delegate
            {
                panel2.Invalidate();
                panel2.Refresh();
            });

            if (this.Visible)
            {
                if (text == "" && headlineText == "")
                {
                    panel1.Invoke((MethodInvoker)delegate
                    {
                        panel1.Visible = false;
                    });
                }
                panel1.Invoke((MethodInvoker)delegate
                {
                    panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2), (this.Height / 2) - (panel1.Height / 2));
                });
                lblLoadingStatus.Invoke((MethodInvoker)delegate
                {
                    lblLoadingStatus.ForeColor = LabelColor;
                    lblLoadingStatus.Text = text;
                    lblLoadingStatus.Invalidate();
                    lblLoadingStatus.Refresh();
                    lblLoadingStatus.Location = new Point((panel1.Width / 2) - (lblLoadingStatus.Width / 2), (panel1.Height / 2) - (lblLoadingStatus.Height / 2));
                });
                lblLoadingStatusHeadline.Invoke((MethodInvoker)delegate
                {
                    lblLoadingStatusHeadline.ForeColor = LabelColor;
                    lblLoadingStatusHeadline.Text = headlineText;
                    lblLoadingStatusHeadline.Invalidate();
                    lblLoadingStatusHeadline.Refresh();
                    lblLoadingStatusHeadline.Location = new Point((panel1.Width / 2) - (lblLoadingStatusHeadline.Width / 2), (lblLoadingStatus.Location.Y - 33));
                });
            }
        }

    }
}