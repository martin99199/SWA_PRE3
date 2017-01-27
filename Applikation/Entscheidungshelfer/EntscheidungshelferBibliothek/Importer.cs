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
    public partial class Importer : Form
    {
        #region Membervariablen
        Fragebogen importierterFragebogen_;
        string[] verfuegbareFrageboegen_;
        //FactoryChanel....


        #endregion
        public Importer()
        {
            InitializeComponent();
        }
    }
}
