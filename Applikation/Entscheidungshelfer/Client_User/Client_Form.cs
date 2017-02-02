using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_User
{
    public partial class Client_Form : Form
    {
        private bool befragungGestartet;
        public Client_Form()
        {
            InitializeComponent();
        }

        private void btnImportieren_Click(object sender, EventArgs e)
        {
            Importer importerFenster = new Importer();
            DialogResult res = importerFenster.ShowDialog();
            if(res == DialogResult.OK)
            {

            }
            else
            {

            }
        }
    }
}
