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
    public partial class frmFolderTerminator : Form
    {
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
            ofdMain.ShowDialog();
        }

        /// <summary>
        /// user clicks the terminate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTerminate_Click(object sender, EventArgs e)
        {
            ShowSpinner();
        }

        private async void ShowSpinner()
        {
            // open the spinner
            frmSpinner form = new frmSpinner();
            form.Show();
            await Task.Delay(5000);
            form.Close();
        }

    }
}
