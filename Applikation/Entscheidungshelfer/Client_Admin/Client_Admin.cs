using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.IO;
using EntscheidungshelferBibliothek;

namespace Client_Admin
{
    /// <summary>
    /// Die Form Client_Admin wird verwendet um Fragebögen zu ändern oder neue zu erstellen.
    /// Der aktuelle Fragebogen kann gespeichert werden und auch an den Server gesendet werden.
    /// </summary>
    public partial class Client_Admin : Form
    {
        private RemoteFragebogen remoteFragebogen;

        /// <summary>
        /// Initialisierung der Forms Komponenten 
        /// Initialisierung des Servers
        /// </summary>
        public Client_Admin()
        {
            InitializeComponent();

            try
            {
                // connect to the service - using channel        
                ChannelFactory<RemoteFragebogen> cFactory;
                cFactory = new ChannelFactory<RemoteFragebogen>("WsHttpBinding_RemoteFragebogen");
                remoteFragebogen = cFactory.CreateChannel();      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem initializing service (general):\n" + ex.Message);
            }
        }

        /// <summary>
        /// Dialogaufbau mit Form Input_Fragebogen
        /// nach korrekter Fragebogenerstellung, Textübernahme auf tbxVorschau
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnErstellen_Click(object sender, EventArgs e)
        {
            Input_Fragebogen form2InputFragebogen = new Input_Fragebogen();

            DialogResult res = form2InputFragebogen.ShowDialog();
            if (res == DialogResult.OK)
            {
                tbxVorschau.Text = form2InputFragebogen.TbxFragebogen.Text;
            }
        }

        /// <summary>
        /// Konvertierung von Text in Fragebogen und senden an den Server
        /// Auf Fehler wird mit MessageBoxen hingewiesen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportieren_Click(object sender, EventArgs e)
        {
            Fragebogen neuerFragebogen = new Fragebogen();

            string[] linien = tbxVorschau.Text.Split('\n');
            bool eingabeOK = true;
            foreach (string linie in linien)
            {
                try
                {
                    if (linie != "\r" && linie != "")
                    {
                        string[] linieElemente = linie.Split(';');
                        string[] zwErg = linieElemente[2].Split('\r');
                        linieElemente[2] = zwErg[0];
                        neuerFragebogen.fuegeFrageHinzu(linieElemente[0], linieElemente[1], linieElemente[2]);
                    }
                }
                catch
                {
                    eingabeOK = false;
                }
            }

            if (eingabeOK)
            {
                try
                {
                    bool fragebogenGesendet = remoteFragebogen.sendeFragebogen(neuerFragebogen);
                    if (fragebogenGesendet)
                    {
                        MessageBox.Show("Fragebogen an Server gesendet!");
                    }
                    else
                    {
                        MessageBox.Show("Senden fehlgeschlagen! Bitte versuchen Sie es später erneut.");
                    }
                }
                catch
                {
                    MessageBox.Show("Server nicht erreichbar. Bitte stellen Sie sicher, dass die Verbindungsdaten stimmen und starten Sie das Programm erneut.");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe auf richtiges Format prüfen");
            }
        }

        /// <summary>
        /// Dialogaufbau mit SaveFileDialog um Speicherposition für Fragebogen zu wählen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            // SaveFileDialog Anzeigen
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Fragebogen Speichern";
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != "")
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (string line in tbxVorschau.Lines)
                            sw.Write(line + sw.NewLine);
                    }
                }
            }
        }

        /// <summary>
        /// Dialogaufbau mit OpenFileDialog um Fragebogen zu laden
        /// Anzeige des Fragebogens in tbxVorschau
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLaden_Click(object sender, EventArgs e)
        {
            // SaveFileDialog Anzeigen
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Fragebogen Öffnen";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                StreamReader datei = new StreamReader(openFileDialog1.FileName);
                string zeilen = "";
                while (datei.Peek() > -1)
                {
                    zeilen += datei.ReadLine() + "\r\n";                   
                }
                tbxVorschau.Text = zeilen;
            }
        }
    }
}
