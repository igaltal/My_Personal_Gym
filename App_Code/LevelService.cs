using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class LevelService
    {
        private readonly SqliteConnection myConnection;

        public LevelService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves all levels from the database.
        /// </summary>
        /// <returns>A DataSet containing all levels.</returns>
        public DataSet GetLevels()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM Levels";
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
                throw new Exception("An error occurred while fetching levels", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }
    }
}
