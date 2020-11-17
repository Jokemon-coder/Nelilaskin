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
        Double arvo = 0;
        String operaatio = "";
        bool operaatio_Click = false;
        public Nelilaskin()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nappiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tulos.Text);
        }

        private void nappiReset_Click(object sender, EventArgs e)
        {
            tulos.Clear();
        }

        private void nappiClear_Click(object sender, EventArgs e)
        {
            if (tulos.Text.Length > 0)
            {
                tulos.Text = tulos.Text.Remove(tulos.Text.Length - 1, 1);
            }
            
        }


        private void NappiNum_Click(object sender, EventArgs e)
        {
            if ((tulos.Text == "0") || (operaatio_Click))
                tulos.Clear();
            operaatio_Click = false;
            Button b = (Button)sender;
            tulos.Text = tulos.Text + b.Text;
        }

        private void tekstiLoota_TextChanged(object sender, EventArgs e)
        {

        }

        private void nappiOperaattori_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operaatio = b.Text;
            arvo = Double.Parse(tulos.Text);
            operaatio_Click = true;
            
        }

        private void nappiEqual_Click(object sender, EventArgs e) //Operaatiot otetaan mukaan laskuun ja yhteenlasku-painike laskee laskun ja antaa tuloksen
        {

            switch (operaatio)
            {
                case "+":
                    tulos.Text = (arvo + Double.Parse(tulos.Text)).ToString();
                    break;
                case "-":
                    tulos.Text = (arvo - Double.Parse(tulos.Text)).ToString();
                    break;
                case "*":
                    tulos.Text = (arvo * Double.Parse(tulos.Text)).ToString();
                    break;
                case ":":
                    tulos.Text = (arvo / Double.Parse(tulos.Text)).ToString();
                    break;
                default:
                    break;
            }//lopeta switch
        }
    }
}
