//Eingabefenster für einen neuen Fragebogen
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
using EntscheidungshelferBibliothek;

namespace Client_Admin
{
    public partial class Input_Fragebogen : Form
    {
        #region Properties
        /// <summary>
        /// Eigenschaft um später
        /// den Text extrahieren zu 
        /// können (statt public - Variable)
        /// </summary>
        public TextBox TbxFragebogen
        {
            get
            {
                return (tbxFragebogen);
            }
        }
        #endregion

        public Input_Fragebogen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prüft Eingabe und erstellt bei passender
        /// Eingabe einen Fragebogen. Ist die Eingabe
        /// nicht ok wird dem Benutzer eine Meldung 
        /// angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] linien = tbxFragebogen.Text.Split('\n');
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
            if (fragenNum == 0)
            {
                eingabeOK = false;
            }
            if (eingabeOK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bitte Eingabe auf richtiges Format prüfen");
            }
        }

    }
}
