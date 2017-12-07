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
    public partial class EditHistoryForm : Form
    {

        /// 
        /// private fileds
        /// 
        private long mHistoryID;
        private TerminatorDBUtils dbUtils = new TerminatorDBUtils();


        public EditHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditHistoryForm_Load(object sender, EventArgs e)
        {
            // try to load the history item
            try
            {
                DataTable table;
                table = dbUtils.GetById(mHistoryID);
                tbxPath.Text = table.Rows[0].ItemArray[1].ToString();
                dtpDateDeleted.Text = table.Rows[0].ItemArray[2].ToString();
                tbxSuccess.Text = table.Rows[0].ItemArray[3].ToString();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading history information";
            }
        }

        /// <summary>
        /// user clicks the update button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // for valid input update history in the database
            try
            {
                dbUtils.EditHistory(mHistoryID, tbxPath.Text, dtpDateDeleted.Value, tbxSuccess.Text == "1");
                lblStatus.Text = "History Updated";
            }
            catch
            {
                lblStatus.Text = "Error updating history.";
            }
        }

        ///
        /// SETTER
        /// 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        public void SetHistoryID(long pId)
        {
            mHistoryID = pId;
        }

    }
}
