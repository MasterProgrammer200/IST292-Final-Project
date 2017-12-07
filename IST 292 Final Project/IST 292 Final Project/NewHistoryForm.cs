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
    public partial class NewHistoryForm : Form
    {

        private TerminatorDBUtils dbUtils = new TerminatorDBUtils();

        public NewHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// user clicks the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {
                dbUtils.AddHistory(tbxPath.Text, dtpDateDeleted.Value, tbxSuccess.Text == "1");
                lblStatus.Text = "History added";
            }
            catch
            {
                lblStatus.Text = "Error adding history";
            }
    
        }
    }
}
