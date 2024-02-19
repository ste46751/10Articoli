using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10Articoli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invia_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            articoli.Codice=float.Parse(txt_cod.Text);
            articoli.Descrizione = txt_descr.Text;
            articoli.Prezzo = float.Parse(txt_prezzo.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class Articoli
    {
        public float _codice;
        public string _descrizione;
        public float _prezzo;
        public bool fedelta=false;
        public float Codice
        {
            get { return _codice; }
            set { _codice = value; }
        }

        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }
        public float Prezzo
        {
            get { return _prezzo; }
            set { _prezzo = value; }
        }
        public void sconto()
        {
            if(fedelta==true)
            {
                Prezzo = Prezzo / 100 * 5;
            }
            else
            {

            }
        }
    }
}
