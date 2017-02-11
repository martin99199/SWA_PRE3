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
    public partial class FragebogenViewer : Form
    {
        public FragebogenViewer(Fragebogen bogen)
        {
            string anzeige = bogen.ToString();
            InitializeComponent();
            this.textBox1.Text = anzeige;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
