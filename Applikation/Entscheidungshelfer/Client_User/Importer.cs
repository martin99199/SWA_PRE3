//Fenster zum Importieren eines neuen Fragebogens
//Author: Reinhard Daum

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
using System.ServiceModel;

namespace Client_User
{
    public partial class Importer : Form
    {
        private RemoteFragebogen remoteFragebogen;
        private Fragebogen importierterFragebogen_;
        public Importer()
        {
            InitializeComponent();
            try
            {
                ChannelFactory<RemoteFragebogen> cFactory;
                cFactory = new ChannelFactory<RemoteFragebogen>("WsHttpBinding_RemoteFragebogen");
                remoteFragebogen = cFactory.CreateChannel();
            }
            catch
            {
                MessageBox.Show("Problem mit Verbindung! Bitte prüfen Sie die Verbindungsdaten und starten Sie die Anwendung erneut!");
                this.Close();
            }
        }

        public Fragebogen ImportierterFragebogen 
        {
            get { return this.importierterFragebogen_; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Versucht eine Verbindung zum Server aufzubauen (RPC)
        /// und stellt die verfügbaren Fragebögen in der 
        /// Kombobox dar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnfragen_Click(object sender, EventArgs e)
        {
            try
            {
                string fragebogenString = remoteFragebogen.pruefeVerfuegbareFrageboegen();
                string[] frageboegen = fragebogenString.Split(';');
                this.cbxFrageboegen.Items.Clear();
                int anzahlFrageboegen=0;
                foreach (string bogen in frageboegen)
                {
                    if (!string.IsNullOrEmpty(bogen))
                    {
                        this.cbxFrageboegen.Items.Add(bogen);
                        ++anzahlFrageboegen;
                    }
                }
                
                //MessageBox.Show(string.Format("Es sind {0} Frageboegen am Server verfuegbar! Bitte waehlen!", anzahlFrageboegen));
                if (anzahlFrageboegen > 0)
                {
                    this.btnImport.Enabled = true;
                    this.lblSupport.Visible = false;
                    this.btnImport.Enabled = true;
                    this.cbxFrageboegen.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Keine Fragebögen verfügbar, bitte versuchen Sie es später noch einmal!");
                    this.lblSupport.Visible = true;
                    this.btnImport.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Ein Fehler ist aufgetreten: " + ex.Message);
                MessageBox.Show("Es ist ein Fehler aufgetreten: Der Server konnte nicht gefunden werden! Prüfen Sie die IP-Adresse sowie ob der Server läuft und versuchen Sie die Anwendung neu zu starten");
                this.cbxFrageboegen.Items.Clear();
            }
        }

        /// <summary>
        /// Importiert den ausgewählten Fragebogen vom Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.importierterFragebogen_ = remoteFragebogen.importiereFragebogen(cbxFrageboegen.SelectedIndex);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Es ist ein Fehler aufgetreten: " + ex.Message);
            }
        }
    }
}
