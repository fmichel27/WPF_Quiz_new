using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace WPF_Quiz
{
    public partial class Start_View : Form
    {
        Konfig konfig = new Konfig();
        BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();


        public Start_View()
        { 
            InitializeComponent();
            konfig.name_des_Programms = lbl_start_ueberschrift.Text;

            IQueryable<int> fragenQuery = binnenschifffahrt.T_Fragebogen_unter_Maschine.Select(d => d.FragebogenNr);

            // Ruekgabewert der Abfrage(alle FragebogenNr) gruppieren
            var fragebogen_Nrn = fragenQuery.ToList().GroupBy(x => x).Select(g => g.Key);
            //gruppierte FragebogenNrn in combobox anzeigen
            cbo_start_auswahl_fragebogen.DataSource = fragebogen_Nrn.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Konfiguration_View konf_view = new Konfiguration_View(konfig, this);
            this.Hide();
            konf_view.FormClosed += new FormClosedEventHandler(formClosed);
            konf_view.Show();
          
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void loslegen_Click(object sender, EventArgs e)
        {
            Frage_View frage_view = new Frage_View(Int32.Parse(cbo_start_auswahl_fragebogen.Text), konfig.name_des_Programms, binnenschifffahrt, this);
            this.Hide();
            frage_view.FormClosed += new FormClosedEventHandler(formClosed);
            frage_view.Show();    
        }
        public void up()
        {
             lbl_start_ueberschrift.Text = konfig.name_des_Programms;
        }

        private void Start_View_Load(object sender, EventArgs e)
        {

        }

   
    }
}
