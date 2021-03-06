﻿//Darstellung des Fragebogens mit Hilfe der
//ToString Methode aus der Klasse Fragebogen
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

namespace Client_User
{
    public partial class FragebogenViewer : Form
    {
        public FragebogenViewer(Fragebogen bogen)
        {
            InitializeComponent();
            string anzeige = bogen.ToString();
            this.textBox1.Text = anzeige;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
