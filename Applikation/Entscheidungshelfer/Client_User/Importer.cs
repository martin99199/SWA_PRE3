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
        private RemoteFragebogen fragebogen;
        private Fragebogen importierterFragebogen;
        public Importer()
        {
            InitializeComponent();
            try
            {
                ChannelFactory<RemoteFragebogen> cFactory;
                cFactory = new ChannelFactory<RemoteFragebogen>("WsHttpBinding_RemoteFragebogen");
                fragebogen = cFactory.CreateChannel();
            }
            catch
            {
                MessageBox.Show("Problem mit Verbindung! Bitte prüfen Sie die Verbindungsdaten und starten Sie die Anwendung erneut!");
                this.Close();
            }
        }

        public Fragebogen ImportierterFragebogen
        {
            get { return this.importierterFragebogen; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAnfragen_Click(object sender, EventArgs e)
        {
            try
            {
                string fragebogenString = fragebogen.pruefeVerfuegbareFrageboegen();
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
                this.cbxFrageboegen.SelectedIndex = 0;
                MessageBox.Show(string.Format("Es wurden {0} Frageboegen erfolgreich importiert!", anzahlFrageboegen));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten: " + ex.Message);
                this.cbxFrageboegen.Items.Clear();
            }
        }
    }
}
