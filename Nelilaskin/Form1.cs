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
            MessageBox.Show("Tekijä: Joel\nCopy-painikkeen käyttö:\nValitse luku, valitse laskutapa,\npaina 'Copy' ja paina yhtäsuuruusmerkkiä.", "Nelilaskin About");
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
            tulos.Text = tulos.Text + b.Text;
        }

        private void tekstiLoota_TextChanged(object sender, EventArgs e)
        {

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
                default:
                    break;
            } //lopeta switch
        }
    }
} //koodi päättyy
