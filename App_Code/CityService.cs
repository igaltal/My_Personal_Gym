using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class CityService
    {
        private readonly SqliteConnection myConnection;

        public CityService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves all cities from the database.
        /// </summary>
        /// <returns>A DataTable containing all cities.</returns>
        public DataTable GetCities()
        {
            DataTable dataTable = new DataTable();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM Cities";
                using (var command = new SqliteCommand(sql, myConnection))
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching cities", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataTable;
        }
    }
}
