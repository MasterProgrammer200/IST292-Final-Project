using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST_292_Final_Project
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// File -> Close
        /// user clicks close menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the form
            Close();
        }
    }
}
