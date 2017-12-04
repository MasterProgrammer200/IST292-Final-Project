using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST_292_Final_Project
{
    class TerminatorDBUtils
    {

        ///
        /// private const fields
        /// 
        private const string CONNECTION_STRING = "Data Source = FolderTerminator.db";
        private const string HISTORY_TABLE = "TerminationHistory";
        private const string ID_COLUMN = "Id";
        private const string PATH_COLUMN = "Path";
        private const string DATE_DELETED_COLUMN = "DateDeleted";
        private const string SUCCESS_COLUMN = "Success";
        private const string ID_PARAMETER = "@id";
        private const string PATH_PARAMETER = "@path";
        private const string DATE_DELETED_PARAMETER = "@datedeleted";
        private const string SUCCESS_PARAMETER = "@success";
        private const string LOG_FILENAME = "log.error";

        ///
        /// private fields to hold database connection info
        /// 
        private SQLiteConnection conn;
        private SQLiteCommand comm;
        private SQLiteDataAdapter da;
        private DataSet ds;
        private string SQL;

        ///
        /// public field to hold database status
        /// 
        private string mLastStatus { get; set;  }

        /// <summary>
        /// CRUD - CREATE
        /// Creates a record in the history table
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pDate"></param>
        /// <param name="pSuccess"></param>
        /// <returns></returns>
        public bool AddHistory(string pPath, DateTime pDate, bool pSuccess)
        {
            // holds whether insert was successful
            bool result = true;

            // write the sql statement
            SQL = "INSERT INTO " + HISTORY_TABLE + "(" + PATH_COLUMN + ", " + DATE_DELETED_COLUMN + ", " + SUCCESS_COLUMN + ")"
                  + "VALUES(" + PATH_PARAMETER + "," + DATE_DELETED_PARAMETER + "," + SUCCESS_PARAMETER + ");";

            // try to insert into db
            try
            {
                // make the connection
                using (conn = new SQLiteConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (comm = new SQLiteCommand(SQL, conn))
                    {
                        // insert parameters
                        comm.Parameters.AddWithValue(PATH_PARAMETER, pPath);
                        comm.Parameters.AddWithValue(DATE_DELETED_PARAMETER, pDate);
                        comm.Parameters.AddWithValue(SUCCESS_PARAMETER, pSuccess);

                        // execute the query
                        comm.ExecuteNonQuery();
                        mLastStatus = "Record added to database";
                    }
                }
            }
            catch (Exception ex)
            {
                // log any errors
                result = false;
                LogError(ex.Message);
                mLastStatus = "Error adding to database, check " + LOG_FILENAME + " for details.";
            }

            return result;
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
