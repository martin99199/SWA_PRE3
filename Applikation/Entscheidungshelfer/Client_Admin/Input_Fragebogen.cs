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

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] linien = tbxFragebogen.Text.Split('\n');
            bool eingabeOK = true;
            if (linien.Length > 1)
            {
                for (int ii = 1; ii < linien.Length; ++ii)
                {
                    string linie = linien[ii];
                    try
                    {
                        if (linie != "\r" && linie != "")
                        {
                            Frage.parseFrage(linie);
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
                eingabeOK = false;
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
