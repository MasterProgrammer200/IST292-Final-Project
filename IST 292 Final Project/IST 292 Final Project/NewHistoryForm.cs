using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            // validate user input

            // CHECK 1 - path is a directory
            if (!Directory.Exists(tbxPath.Text))
            {
                erp.SetError(tbxPath, "Invalid Directory.");
                return;
            }

            // CHECK 2 - success is a bool
            if (!(tbxSuccess.Text == "0" || tbxSuccess.Text == "1"))
            {
                erp.SetError(tbxPath, "Success must be one or zero.");
                return;
            }

            try
            {
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
