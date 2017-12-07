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

        private TerminatorDBUtils dbUtils = new TerminatorDBUtils();

        public frmHistory()
        {
            InitializeComponent();
            DisplayTable();
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

        

        /// <summary>
        /// user clicks the show all button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslShowAll_Click(object sender, EventArgs e)
        {
            DisplayTable();
        }

        /// <summary>
        /// user clicks the edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslEdit_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            if (dgvHistory.SelectedRows.Count > 0)
            {
                // pass the id to the edit from and show it
                long Id = (long)(dgvHistory.SelectedRows[0].Cells[0].Value);
                EditHistoryForm frmEdit = new EditHistoryForm();
                frmEdit.SetHistoryID(Id);
                frmEdit.ShowDialog();
                DisplayTable();
            }
            else
            {
                lblStatus.Text = "Click on a history item to select it";
            }
        }

        /// <summary>
        /// user clicks the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslDelete_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            if (dgvHistory.SelectedRows.Count > 0)
            {
                // confirm that user wants to delete
                DialogResult dr =
                    MessageBox.Show("Deleting the selected history will permanently remove. Do you want to continue?",
                        "Confirm Delete", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    long selectedId = (long)dgvHistory.SelectedRows[0].Cells[0].Value;

                    // delete the selected item and reload the data if successful
                    if (dbUtils.DeleteHistory(selectedId) == true)
                    {
                        DisplayTable();
                        lblStatus.Text = "History deleted";

                    }
                    else
                    {
                        lblStatus.Text = "Error deleting history";
                    }
                }
            }
            else
            {
                lblStatus.Text = "No history selected";
            }
        }

        /// <summary>
        /// user clicks the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslAdd_Click(object sender, EventArgs e)
        {
            // display the new history form
            NewHistoryForm form = new NewHistoryForm();
            form.ShowDialog();
            DisplayTable();
        }

        /// <summary>
        /// user clicks the close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslClose_Click(object sender, EventArgs e)
        {
            // close the form
            Close();
        }

        private void DisplayTable()
        {
            dgvHistory.DataSource = dbUtils.GetAllHistory();
            dgvHistory.ClearSelection();
        }

        
    }
}
