using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://satsuma.btcdir.org/download/");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bxl909.github.io/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://satsuma.btcdir.org/tips/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BXL909/SATSuma");
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            BackColor = WindowBackgroundColor;
            label2.ForeColor = LabelColor;
            linkLabel1.ForeColor = LinksColor;
            linkLabel2.ForeColor = LinksColor; 
            linkLabel3.ForeColor = LinksColor;
            linkLabel4.ForeColor = LinksColor;
            btnExit.BackColor = ButtonBackColor;
            btnExit.ForeColor = ButtonTextColor;
        }
    }
}
