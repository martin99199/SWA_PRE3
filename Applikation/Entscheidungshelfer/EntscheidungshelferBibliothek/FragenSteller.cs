using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntscheidungshelferBibliothek
{
    public partial class FragenSteller : Form
    {
        bool vertauscht_;
        public FragenSteller(int frageNummer, string frage,
                             string antwort1, string antwort2)
        {
            Random rand = new Random();
            int randZahl = rand.Next(2); //0 oder 1
            vertauscht_ = randZahl == 0;
            InitializeComponent();
            this.lblFrage.Text = frage;
            if (!vertauscht_)
            { 
                this.btnAntwort1.Text = antwort1;
                this.btnAntwort2.Text = antwort2;
            }
            else
            {
                this.btnAntwort1.Text = antwort2;
                this.btnAntwort2.Text = antwort1;
            }
            this.btnAbbruch.Text = "Befragung abbrechen";
            this.Text = "Frage " + frageNummer.ToString() + ":";
        }

        private void btnAntwort1_Click(object sender, EventArgs e)
        {
            if (!vertauscht_)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void btnAntwort2_Click(object sender, EventArgs e)
        {
            if (vertauscht_)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
