using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class GenderService
    {
        private readonly SqliteConnection myConnection;

        public GenderService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves all genders from the database.
        /// </summary>
        /// <returns>A DataSet containing all genders.</returns>
        public DataSet GetGenders()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM Gender";
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
                throw new Exception("An error occurred while fetching genders", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }
    }
}
