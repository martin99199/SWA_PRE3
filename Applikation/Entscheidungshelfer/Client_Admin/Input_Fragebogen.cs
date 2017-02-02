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
    /// <summary>
    /// Die Form Input_Fragebogen wird von Form Client_Admin aufgerugen 
    /// um einen neuen Fragebogen zu erstellen.
    /// </summary>
    public partial class Input_Fragebogen : Form
    {
        #region Properties
        public TextBox TbxFragebogen
        {
            get
            {
                return (tbxFragebogen);
            }
        }
        #endregion

        /// <summary>
        /// Initialisierung der Forms Komponenten 
        /// </summary>
        public Input_Fragebogen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Überprüfung der Fragebogeneingabe 
        /// Auf Fehler wird mit MessageBoxen hingewiesen
        /// Bei richtiger Eingabe wird das DialogResult auf OK gesetzt und das Fenster geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] linien = tbxFragebogen.Text.Split('\n');
            bool eingabeOK = true;
            foreach(string linie in linien)
            {
                try
                {
                    if(linie != "\r" && linie != "")
                    {
                        Frage.parseFrage(linie);
                    }
                }
                catch
                {
                    eingabeOK = false;
                }
            }
            if(eingabeOK)
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
