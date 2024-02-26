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

            bttn_alim.Visible = false;
            bttn_fresco.Visible = false;
            bttn_nonalim.Visible = false;  
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            pnl_nonalim.Visible=false;
        }
        List<ArticoliAlimentare> aliment = new List<ArticoliAlimentare>();
        List<ArticoliFresco> freschi = new List<ArticoliFresco>();
        List<ArticoliNonAlimentare> nonAliment = new List<ArticoliNonAlimentare>();

        private void btn_invia_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            string fed = txt_fed.Text;
            if (fed == "si")
            {
                articoli.fedelta = true;
            }
            else
            {
                articoli.fedelta = false;
            }
            pnl_fedelta.Visible=false;

            bttn_alim.Visible = true;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;

            /*
            articoli.Codice=txt_cod.Text;
            articoli.Descrizione = txt_descr.Text;
            articoli.Prezzo = float.Parse(txt_prezzo.Text);
            
            */
        }

        private void bttn_alim_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_alim.Visible = true;
            bttn_fresco.Visible=false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;
        }

        private void bttn_fresco_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_fresco.Visible = true;
            bttn_fresco.Visible = false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;
        }

        private void bttn_nonalim_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_nonalim.Visible = true;
            bttn_fresco.Visible = false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;
        }

        private void bttn_salvaalim_Click(object sender, EventArgs e)
        {
            ArticoliAlimentare articoliAlimentare = new ArticoliAlimentare();
            articoliAlimentare.Codice = txt_cod1.Text;
            articoliAlimentare.Descrizione = txt_descr1.Text;
            articoliAlimentare.Prezzo = int.Parse(txt_prezzo1.Text);
            articoliAlimentare.Anno = int.Parse(txt_scad.Text);

            articoliAlimentare.sconto();

            aliment.Add(articoliAlimentare);


            pnl_nonalim.Visible = false;
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;
            bttn_alim.Visible = true;

        }

        private void bttn_salvafresco_Click(object sender, EventArgs e)
        {
            ArticoliFresco articolifresco = new ArticoliFresco();
            articolifresco.Codice = txt_cod2.Text;
            articolifresco.Descrizione = txt_descr2.Text;
            articolifresco.Prezzo = int.Parse(txt_prez2.Text);
            articolifresco.Giorni = int.Parse(txt_scad.Text);

            articolifresco.sconto();

            freschi.Add(articolifresco);

            pnl_nonalim.Visible = false;
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;
            bttn_alim.Visible = true;
        }

        private void bttn_salvaNoNalim_Click(object sender, EventArgs e)
        {
            ArticoliNonAlimentare articoliNonAlimentare = new ArticoliNonAlimentare();
            articoliNonAlimentare.Codice = txt_cod3.Text;
            articoliNonAlimentare.Descrizione = txt_descr3.Text;
            articoliNonAlimentare.Prezzo = int.Parse(txt_prez3.Text);
            articoliNonAlimentare.Materiale = txt_mater.Text;
            if(checkSi.Checked.Equals(true) && checkNo.Checked.Equals(false))
            {
                articoliNonAlimentare.Reciclabile = true;
            }
            else if (checkSi.Checked.Equals(false) && checkNo.Checked.Equals(true))
            {
                articoliNonAlimentare.Reciclabile = false;
            }
            else
            { }

            articoliNonAlimentare.sconto();

            nonAliment.Add(articoliNonAlimentare);

            pnl_nonalim.Visible = false;
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;
            bttn_alim.Visible = true;
        }
    } 
    class Articoli
    {
        public string _codice;
        public string _descrizione;
        public float _prezzo;
        public bool fedelta=false;
        public string Codice
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
        public virtual void sconto()
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
    class ArticoliAlimentare : Articoli
    {
        public int _anno;
        public int Anno
        {
            get { return _anno; }
            
            set { _anno = value; }
        }
        public override void sconto()
        {
            if (Anno == DateTime.Today.Year)
            {
                Prezzo -= Prezzo / 100 * 20;
            }
            else
            {
            }
        }
    }
    class ArticoliNonAlimentare : Articoli
    {
        public string _materiale;
        public bool _reciclabile;
        public string Materiale
        {
            get { return _materiale; }
            set { _materiale = value; }
        }
        public bool Reciclabile
        {
            get { return _reciclabile; }
            set { _reciclabile = value; }
        }
        public override void sconto()
        {
            if (Reciclabile == true)
            {
                Prezzo -= Prezzo / 100 * 10;
            }
            else
            {

            }
        }
    }
    class ArticoliFresco : ArticoliAlimentare
    {
        public int _giorni;
        public int Giorni
        {
            get { return _giorni; }
            set { _giorni = value; }
        }
        public override void sconto()
        {
            int sco=0;
            for (int i=0;i<Giorni; i++) 
            {
                sco = 10 - 2 * i;
            }
            Prezzo -= Prezzo / 100 * sco;
        }
    }
}
