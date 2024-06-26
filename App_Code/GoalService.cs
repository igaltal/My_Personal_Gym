using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class GoalService
    {
        private readonly SqliteConnection myConnection;

        public GoalService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves all goals from the database.
        /// </summary>
        /// <returns>A DataSet containing all goals.</returns>
        public DataSet GetGoals()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM Goal";
                using (var command = new SqliteCommand(sql, myConnection))
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dataset.Tables.Add(table);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching goals", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }
    }
}
