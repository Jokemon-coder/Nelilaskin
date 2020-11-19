using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nelilaskin //koodi alkaa
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

        private void poistu_Click(object sender, EventArgs e) 
        {
            Application.Exit(); //Nappi jolla pääsee poistumaan ohjelmasta
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //About-osio, josta näkee tekijän ja ohjeet Copy-painikkeen käyttöön
        {
            MessageBox.Show("Tekijä: Joel", "About");
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nappiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tulos.Text); //Ottaa syöttökentästä siinä olevan luvun ja kopioi sen
        }

        private void nappiReset_Click(object sender, EventArgs e) 
        {
            tulos.Clear(); //Puhdistaa koko syöttökentän
        }

        private void nappiClear_Click(object sender, EventArgs e) //Saa poistettua numerot yksitellen syöttökentästä
        {
            if (tulos.Text.Length > 0) //Jos syöttökentässä olevat "teksti" on enemmän kuin yhden hahmon, 
            {
                tulos.Text = tulos.Text.Remove(tulos.Text.Length - 1, 1); //Otetaan "tekstin" perästä yksi hahmo pois
            }
            
        }


        private void NappiNum_Click(object sender, EventArgs e)
        {
            if ((tulos.Text == "0") || (operaatio_Click)) //Ei voi laittaa alusta enemmän kuin yksi nolla ensimmäisen nollan perään
                tulos.Clear();
            operaatio_Click = false; //bool operaatio_Click pistetään falseksi
            Button b = (Button)sender; //Muutetaan nappi lähettäjäksi
            
            if (tulos.Text == ",")
            {
                if (!tulos.Text.Contains(","))
                    tulos.Text = tulos.Text + b.Text;
            }
            else
            tulos.Text = tulos.Text + b.Text;
        }

        private void nappiOperaattori_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //Pistetään nappi lähettäjäksi
            operaatio = b.Text; //string operaatio pistetään samaksi kuin b.Text
            arvo = Double.Parse(tulos.Text); //arvo muutetaan luvuiksi
            operaatio_Click = true; //operaatio_Click laitetaan takaisin trueksi
            
        }

        private void nappiEqual_Click(object sender, EventArgs e) //Operaatiot otetaan mukaan laskuun ja yhteenlasku-painike laskee laskun ja antaa tuloksen
        {

            switch (operaatio) //Switch loop laskupainikkeille, jottei niille tarvitse jokaiselle tehdä erillistä metodia
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
                case "Mod":
                    tulos.Text = (arvo % Double.Parse(tulos.Text)).ToString();
                    break;
                case "Exp":
                    tulos.Text = Math.Pow(arvo, Double.Parse(tulos.Text)).ToString();
                    break;
                default:
                    break;
            } //lopeta switch

        }


        private void nelilaskinToolStripMenuItem_Click(object sender, EventArgs e) //Kun painaa "nelilaskin" painikkeesta, se säätä leveyden näyttämään vain nelilaskimen
        {
            this.Width = 414;
            tulos.Width = 374;
            tableLayoutPanel1.Width = 377;
        }

        private void funktiolaskinToolStripMenuItem_Click(object sender, EventArgs e) //Kun painaa "funktiolaskin" painikkeesta, se säätä leveyden näyttämään vain funktiolaskimen
        {
            this.Width = 828;
            tulos.Width = 786;
            tableLayoutPanel1.Width = 792;
        }

        private void pii_Click(object sender, EventArgs e) //Pii-painike
        {
            tulos.Text = Math.PI.ToString(); //Kun painaa Pii-painikkeesta, kenttään tulee esille laskettu pii
        }

        private void Log_Click(object sender, EventArgs e) //Logaritmi-painike
        {
            double ilog = Double.Parse(tulos.Text);
            ilog = Math.Log10(ilog);                    //Laskee logaritmin
            tulos.Text = System.Convert.ToString(ilog); //Kenttään tulee esille logaritmi
        }

        private void sqrt_Click(object sender, EventArgs e) //Neliöjuuri-painike
        {
            double sq = Double.Parse(tulos.Text);
            sq = Math.Sqrt(sq); //Laskee annetun luvun neliöjuuren
            tulos.Text = System.Convert.ToString(sq); //Tulostaa neliöjuuren kenttään
        }

        private void Sinh_Click(object sender, EventArgs e) //hyperbolinen sini
        {
            double qSinh = Double.Parse(tulos.Text);
            qSinh = Math.Sinh(qSinh); //laskee hyperbolisen sinin
            tulos.Text = System.Convert.ToString(qSinh); //tulostaa tuloksen kenttään
        }

        private void Sin_Click(object sender, EventArgs e) //sini
        {
            double qSin = Double.Parse(tulos.Text);
            qSin = Math.Sin(qSin); //laskee sinin
            tulos.Text = System.Convert.ToString(qSin); //tulostaa tuloksen kenttään
        }

        private void Cosh_Click(object sender, EventArgs e)
        {
            double qCosh = Double.Parse(tulos.Text);
            qCosh = Math.Cosh(qCosh);
            tulos.Text = System.Convert.ToString(qCosh); //tulostaa tuloksen kenttään
        }

        private void Cos_Click(object sender, EventArgs e)
        {
            double qCos = Double.Parse(tulos.Text);
            qCos = Math.Cos(qCos);
            tulos.Text = System.Convert.ToString(qCos); //tulostaa tuloksen kenttään
        }

        private void Tanh_Click(object sender, EventArgs e)
        {
            double qTanh = Double.Parse(tulos.Text);
            qTanh = Math.Tanh(qTanh);
            tulos.Text = System.Convert.ToString(qTanh); //tulostaa tuloksen kenttään
        }

        private void Tan_Click(object sender, EventArgs e)
        {
            double qTan = Double.Parse(tulos.Text);
            qTan = Math.Tan(qTan);
            tulos.Text = System.Convert.ToString(qTan); //tulostaa tuloksen kenttään
        }

        private void Bin_Click(object sender, EventArgs e)
        {
            int a = int.Parse(tulos.Text);
            tulos.Text = System.Convert.ToString(a, 2); //tulostaa tuloksen kenttään
        }

        private void Hex_Click(object sender, EventArgs e)
        {
            int a = int.Parse(tulos.Text);
            tulos.Text = System.Convert.ToString(a, 16); //tulostaa tuloksen kenttään
        }

        private void Oct_Click(object sender, EventArgs e)
        {
            int a = int.Parse(tulos.Text);
            tulos.Text = System.Convert.ToString(a, 8); //tulostaa tuloksen kenttään
        }

        private void Dec_Click(object sender, EventArgs e)
        {
            int a = int.Parse(tulos.Text);
            tulos.Text = System.Convert.ToString(a); //tulostaa tuloksen kenttään
        }

        private void X2_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(tulos.Text) * Convert.ToDouble(tulos.Text);
            tulos.Text = System.Convert.ToString(a); //tulostaa tuloksen kenttään
        }

        private void X3_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(tulos.Text) * Convert.ToDouble(tulos.Text) * Convert.ToDouble(tulos.Text);
            tulos.Text = System.Convert.ToString(a); //tulostaa tuloksen kenttään
        }

        private void button_X1_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(1.0 / Convert.ToDouble(tulos.Text));
            tulos.Text = System.Convert.ToString(a); //tulostaa tuloksen kenttään
        }

        private void button_InX_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(tulos.Text);
            ilog = Math.Log(ilog);
            tulos.Text = System.Convert.ToString(ilog); //tulostaa tuloksen kenttään
        }

        private void Rosentti_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(tulos.Text) / Convert.ToDouble(100);
            tulos.Text = System.Convert.ToString(a); //tulostaa tuloksen kenttään
        }
    }
} //koodi päättyy
