﻿//Implementierung der Interaktionslogik für den Admin-Client
//Author: Tobias Müller

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
    public partial class Client_Admin : Form
    {
        private RemoteFragebogen remoteFragebogen; 

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
        /// Öffnet das Dialogfenster zum
        /// Erstellen eines Fragebogens
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
        /// Versucht einen Fragebogen an den Server zu senden
        /// Vor dem Senden wird die Eingabe geprüft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportieren_Click(object sender, EventArgs e)
        {
            Fragebogen neuerFragebogen = new Fragebogen();

            string linien_sp = tbxVorschau.Text.Replace(System.Environment.NewLine, "$");
            string[] linien = linien_sp.Split('$');
            bool eingabeOK = true;
            try
            {
                if (linien[0] != "")
                {
                    neuerFragebogen.Titel = linien[0];
                    for (int ii = 1; ii < linien.Length; ++ii)
                    {
                        string linie = linien[ii];
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
                }
                else
                {
                    MessageBox.Show("Title des Fragebogens muss mindestens ein Zeichen lang sein!");
                    eingabeOK = false;
                }
            }
            catch
            {
                eingabeOK = false;
            }
            if (eingabeOK)
            {
                try
                {
                    Fragebogen tmpFragebogen = neuerFragebogen;
                    bool fragebogenGesendet = remoteFragebogen.sendeFragebogen(tmpFragebogen);
                    if (fragebogenGesendet)
                    {
                        MessageBox.Show("Fragebogen an Server gesendet!");
                        MessageBox.Show(neuerFragebogen.vorschau());
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
        /// Ruft einen Dialog auf, der es ermöglicht
        /// einen eingegebenen Fragebogen zu speichern.
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
        /// Lädt einen gespeicherten Fragebogen
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
                tbxVorschau.Text = test_Fragebogen(tbxVorschau.Text);
            }
        }

        /// <summary>
        /// Testet Fragebogen auf Gültigkeit
        /// </summary>
        /// <param name="Fragebogen"></param>
        /// <returns></returns>
        private string test_Fragebogen(string Fragebogen)
        {
            string[] linien = Fragebogen.Split('\n');
            bool eingabeOK = true;
            int fragenNum = 0;
            if (linien.Length > 1)
            {
                if (linien[0].Contains(';'))
                {
                    MessageBox.Show("Bitte keine ';' im Titel verwenden!");
                    eingabeOK = false;
                }
                else
                {
                    for (int ii = 1; ii < linien.Length; ++ii)
                    {
                        string linie = linien[ii];
                        try
                        {
                            if (linie != "\r" && linie != "")
                            {
                                Frage.parseFrage(linie);
                                fragenNum++;
                            }
                        }
                        catch
                        {
                            eingabeOK = false;
                        }
                    }
                }
            }
            else
            {
                eingabeOK = false;
            }
            if(fragenNum == 0)
            {
                eingabeOK = false;
            }
            if (!eingabeOK)
            {
                Fragebogen = "";
                MessageBox.Show("Bitte Eingabe auf richtiges Format prüfen");
            }

            return Fragebogen;         
        }
    }
}
