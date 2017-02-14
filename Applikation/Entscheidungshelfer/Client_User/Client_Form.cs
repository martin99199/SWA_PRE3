//Interaktionslogik für den User-Client
//Autor: Reinhard Daum

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntscheidungshelferBibliothek;

namespace Client_User
{
    public partial class Client_Form : Form
    {
        private bool befragungGestartet_; //Hilfsvariable
        private Fragebogen fragebogen_; //Fragebogen, der gerade aktuell ist
        public Client_Form()
        {
            InitializeComponent();
            this.pgbFortschritt.Maximum = 100;
        }

        /// <summary>
        /// öffnet ein Importerfenster und übernimmt
        /// den Fragebogen, wenn einer importiert wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportieren_Click(object sender, EventArgs e)
        {
            Importer importerFenster = new Importer();
            DialogResult res = importerFenster.ShowDialog();
            if(res == DialogResult.OK)
            {
                this.fragebogen_ = importerFenster.ImportierterFragebogen;
                this.pgbFortschritt.Value = (int)this.fragebogen_.Fortschritt;
                this.btnBefragungNaechsteFrage.Enabled = true;
                this.btnVisualisieren.Enabled = true;
                this.befragungGestartet_ = false;
            }
        }

        /// <summary>
        /// ruft die stelle Frage- Methode der Klasse Frage auf
        /// und handelt die Antwort bzw. das Ergebnis des Fragebogens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBefragungNaechsteFrage_Click(object sender, EventArgs e)
        {
            if (!befragungGestartet_)
            {
                this.befragungGestartet_ = true;
                this.lblErgebnis.Text = "Ergebnis: ";
                this.lblErgebnis.ForeColor = Color.Black;
            }

            this.fragebogen_.stelleFrage();
            this.pgbFortschritt.Value = (int)(this.fragebogen_.Fortschritt * 100);
            if (this.fragebogen_.FragebogenFertig)
            {
                if (fragebogen_.FinalesErgebnis)
                {
                    MessageBox.Show("Fragebogen fertig! Ihr ergebnis lautet: POSITIV");
                    this.lblErgebnis.Text += " POSITIV";
                    this.lblErgebnis.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Fragebogen fertig! Ihr ergebnis lautet: NEGATIV");
                    this.lblErgebnis.Text += " NEGATIV";
                    this.lblErgebnis.ForeColor = Color.Red;
                }
                this.btnBefragungNaechsteFrage.Text = "Erneut durchführen";
                this.befragungGestartet_ = false;
                this.fragebogen_.zuruecksetzen();
                this.btnBefragungAbbrechen.Enabled = false;
            }
            else
            {
                this.btnBefragungNaechsteFrage.Text = "Nächste Frage";
                this.btnBefragungAbbrechen.Enabled = true;
            }
        }

        /// <summary>
        /// öffnet ein Fenster, in dem der Fragebogen visualisiert wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisualisieren_Click(object sender, EventArgs e)
        {
            FragebogenViewer viewer = new FragebogenViewer(this.fragebogen_);
            viewer.ShowDialog();
        }

        /// <summary>
        /// stoppt eine Befragung und setzt den Fragebogen zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBefragungAbbrechen_Click(object sender, EventArgs e)
        {
            this.pgbFortschritt.Value = 0;
            this.befragungGestartet_ = false;
            this.btnBefragungNaechsteFrage.Text = "Befragung starten";
            if(this.fragebogen_ != null)
            {
                this.fragebogen_.zuruecksetzen();
            }
            this.btnBefragungAbbrechen.Enabled = false;
        }
    }
}
