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
    public partial class frmFolderTerminator : Form
    {

        // 
        // private fields
        //
        private String FolderPath = "";     // holds the path of the folder to be deleted

        public frmFolderTerminator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// File -> Close
        /// user clicks the close menu strip item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit the application
            Application.Exit();
        }

        /// <summary>
        /// View History
        /// user clicks the view history menu strip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open the history form
            frmHistory form = new frmHistory();
            form.Show();
        }

        /// <summary>
        /// user clicks the browse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // show the folder dialog
            if (fbdMain.ShowDialog() == DialogResult.OK)
            {
                // set the folder path to the path the user selected
                 FolderPath = fbdMain.SelectedPath;
            }

            // display the folder path in the text box
            tbxDirectory.Text = FolderPath;

        }

        /// <summary>
        /// user clicks the terminate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnTerminate_Click(object sender, EventArgs e)
        {
            // create a spinner
            frmSpinner spinner = new frmSpinner();

            // show the spinner
            spinner.Show();

            bool result = await DeleteFilesAsync();

            // todo: handle result

            // close the spinner
            spinner.Close();

        }

        // todo: document
        // todo: create error log
        // todo: log in database
        private async Task<bool> DeleteFilesAsync()
        {
            bool error = false;

            // wait at least 3 seconds so user doesn't get flashed with spinner
            await Task.Delay(3000);

            return error;
        }

    }
}
