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
        private bool befragungGestartet_;
        private Fragebogen fragebogen_;
        public Client_Form()
        {
            InitializeComponent();
            this.pgbFortschritt.Maximum = 100;
        }

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

        private void btnBefragungNaechsteFrage_Click(object sender, EventArgs e)
        {
            if (!befragungGestartet_)
            {
                this.befragungGestartet_ = true;
                this.btnBefragungNaechsteFrage.Text = "Naechste Frage";
                this.btnBefragungAbbrechen.Enabled = true;
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
                this.btnBefragungNaechsteFrage.Text = "Befragung erneut durchführen";
                this.befragungGestartet_ = false;
                this.fragebogen_.zuruecksetzen();
            }
        }

        private void btnVisualisieren_Click(object sender, EventArgs e)
        {
            FragebogenViewer viewer = new FragebogenViewer(this.fragebogen_);
            viewer.ShowDialog();
        }

        #region Helfermethoden
        private void aktualisiereAnzeige()
        {
            if (this.fragebogen_ != null)
            {
                this.pgbFortschritt.Value = (int)this.fragebogen_.Fortschritt;
                if (this.befragungGestartet_)
                {
                    this.btnBefragungAbbrechen.Enabled = true;
                    this.btnImportieren.Enabled = true;
                    this.btnVisualisieren.Enabled = true;
                    if (!this.fragebogen_.FragebogenFertig)
                    {
                        this.btnBefragungNaechsteFrage.Text = "Nächste Frage";
                    }
                    else
                    {
                        this.btnBefragungNaechsteFrage.Text = "Erneute Befragung";
                    }
                }
                else //Befragung noch nicht gestartet
                {
                    this.btnBefragungAbbrechen.Enabled = false;
                    this.btnImportieren.Enabled = true;
                    this.btnVisualisieren.Enabled = true;
                    this.btnBefragungNaechsteFrage.Text = "Befragung starten";
                }
            }
            else //Fragebogen == null
            {
                this.btnBefragungNaechsteFrage.Enabled = false;
                this.btnBefragungAbbrechen.Enabled = false;
                this.btnVisualisieren.Enabled = false;
            }
        }
        #endregion //Helfermethoden
    }
}
