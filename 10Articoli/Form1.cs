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


            pnl_scontrino.Visible = true;
            bttn_alim.Visible = true;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;  
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            pnl_nonalim.Visible=false;
            pnl_fedelta.Visible = false;

        }
        List<ArticoliAlimentare> aliment = new List<ArticoliAlimentare>();
        List<ArticoliFresco> freschi = new List<ArticoliFresco>();
        List<ArticoliNonAlimentare> nonAliment = new List<ArticoliNonAlimentare>();
        

        

        private void bttn_alim_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_alim.Visible = true;
            bttn_fresco.Visible=false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;

            pnl_scontrino.Visible = false;
        }

        private void bttn_fresco_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_fresco.Visible = true;
            bttn_fresco.Visible = false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;

            pnl_scontrino.Visible = false;
        }

        private void bttn_nonalim_Click(object sender, EventArgs e)
        {
            Articoli articoli = new Articoli();
            pnl_nonalim.Visible = true;
            bttn_fresco.Visible = false;
            bttn_nonalim.Visible = false;
            bttn_alim.Visible = false;

            pnl_scontrino.Visible = false;
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

            pnl_scontrino.Visible = true;

        }

        private void bttn_salvafresco_Click(object sender, EventArgs e)
        {
            ArticoliFresco articolifresco = new ArticoliFresco();
            articolifresco.Codice = txt_cod2.Text;
            articolifresco.Descrizione = txt_descr2.Text;
            articolifresco.Prezzo = int.Parse(txt_prez2.Text);
            articolifresco.Giorni = int.Parse(txt_giorni.Text);

            articolifresco.sconto();

            freschi.Add(articolifresco);

            
            pnl_nonalim.Visible = false;
            pnl_alim.Visible = false;
            pnl_fresco.Visible = false;
            bttn_fresco.Visible = true;
            bttn_nonalim.Visible = true;
            bttn_alim.Visible = true;

            pnl_scontrino.Visible = true;

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

            pnl_scontrino.Visible = true;


        }



        private void bttn_scontrino_Click(object sender, EventArgs e)
        {
            pnl_fedelta.Visible = true;
        }

        private void btn_invia_Click(object sender, EventArgs e)
        {
            Articoli ali = new Articoli(); 
            ArticoliNonAlimentare nnalim = new ArticoliNonAlimentare();
            if (checkFedSi.Checked.Equals(true) && checkFedNo.Checked.Equals(false))
            {
                ali.fedelta = true;
            }
            else if (checkSi.Checked.Equals(false) && checkNo.Checked.Equals(true))
            {
                ali.fedelta = false;
            }
            else
            {
                ali.fedelta = false;
            }

            

            foreach (ArticoliAlimentare alim in aliment)
            {
                ali.sconto();
                lstbx_scontrino.Items.Add(alim.stampa());
                
                ali.totale += alim.Prezzo;
                
            }
            foreach(ArticoliNonAlimentare nonAl in nonAliment)
            {
                lstbx_scontrino.Items.Add(nonAl.stampa());
                ali.totale += nonAl.Prezzo;
            }
            foreach (ArticoliFresco fresc in freschi)
            {
                lstbx_scontrino.Items.Add(fresc.stampa());
                ali.totale += fresc.Prezzo;
            }
            lstbx_scontrino.Items.Add("totale:"+ali.totale);

            pnl_fedelta.Visible = false;
            bttn_alim.Visible = false;
            bttn_nonalim.Visible = false;   
            bttn_fresco.Visible = false;
            bttn_scontrino.Enabled = false;
        }
    }
    class Articoli
    {
        public string _codice;
        public string _descrizione;
        public float _prezzo;
        public float totale=0;
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
                totale = totale / 100 * 5;
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
        public ArticoliAlimentare()
        {

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
        public virtual string stampa()
        {
            return $"Nome:{Descrizione} Codice:{Codice} Scadenza:{Anno} Prezzo:{Prezzo}";
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
        public string stampa()
        {
            return $"Nome:{Descrizione} Codice:{Codice} Materiale:{Materiale} Prezzo:{Prezzo}";
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
        public override string stampa()
        {
            return $"Nome:{Descrizione} Codice:{Codice} Giorni:{Giorni} Prezzo:{Prezzo}";
        }
    }
}
