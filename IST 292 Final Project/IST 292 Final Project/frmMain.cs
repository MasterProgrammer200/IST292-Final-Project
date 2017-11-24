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
        // private consts
        //
        private const string LOG_FILENAME = "log.error";

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

            // delete the folder and get the result
            bool result = await DeleteFolderAsync(FolderPath);

            // check if there was an error and if so notify the user
            if (result) MessageBox.Show(@"Error deleteing folder. Check " + LOG_FILENAME + @" for details.");

            // close the spinner
            spinner.Close();

        }

        /// <summary>
        /// asynchronously deletes the specified folder
        /// </summary>
        /// <param name="folderToDelete">the path of the folder to delete</param>
        /// <returns>error: whether the folder was successfully deleted</returns>
        private async Task<bool> DeleteFolderAsync(String folderToDelete)
        {

            //
            // local variables
            //
            bool error = false; // holds whether folder was deleted successfully

            // wait at least 3 seconds so user doesn't get flashed with spinner
            await Task.Delay(3000);

            // try to delete the specified folder
            try
            {
                // get the directory info of the path the user selected
                DirectoryInfo di = new DirectoryInfo(folderToDelete);

                // loop through all the files in the directory
                foreach (FileInfo file in di.GetFiles())
                {
                    // delete the file
                    await Task.Run(() => { file.Delete(); });
                }

                // loop through all the folders in the directory
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    // delete the directory
                    await Task.Run(() => { dir.Delete(true); });
                }
            }
            catch (Exception ex)
            {
                // log the exception and set the error flag to true
                LogError(ex.Message);
                error = true;
            }

            // return whether the folder was deleted
            return error;
        }

        /// <summary>
        /// writes the specified string to the log file
        /// </summary>
        /// <param name="error">error: the error to log</param>
        private void LogError(String error)
        {
            // write to file
            StreamWriter outputFile;
            outputFile = File.AppendText(LOG_FILENAME);
            outputFile.WriteLine("[ERROR " + DateTime.Now + "]: " + error);

            // close the file
            outputFile.Close();
        }

    }
}
