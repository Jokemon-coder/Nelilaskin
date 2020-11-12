using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nelilaskin
{
    public partial class Nelilaskin : Form
    {
        public Nelilaskin()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nappiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tekstiLoota.Text);
        }

        private void nappiReset_Click(object sender, EventArgs e)
        {
            tekstiLoota.Clear();
        }

        private void nappiClear_Click(object sender, EventArgs e)
        {
            if (tekstiLoota.Text.Length > 0)
            {
                tekstiLoota.Text = tekstiLoota.Text.Remove(tekstiLoota.Text.Length - 1, 1);
            }
        }


        private void nappiJako_Click(object sender, EventArgs e)
        {

        }

        private void nappiKerto_Click(object sender, EventArgs e)
        {

        }

        private void nappiMiinus_Click(object sender, EventArgs e)
        {

        }

        private void nappiPlus_Click(object sender, EventArgs e)
        {

        }

        private void NappiNum_Click(object sender, EventArgs e)
        {
            tekstiLoota.Text += (Nappi as Button).Text;

            try
            {
                tekstiLoota.Text += (Nappi as Button).Text;
            }

            catch
            {

            }
        }
    }
}
