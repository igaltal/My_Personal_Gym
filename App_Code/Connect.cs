using Microsoft.Data.Sqlite;
using System.IO;

namespace NewGymIgalTalProject.App_Code
{
    public class Connect
    {
        // Use a relative path for the SQLite database that works across platforms
        private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Datatal.db");

        public static string GetConnectionString()
        {
            string connectionString = $"Data Source={filePath}";
            return connectionString;
        }

        public Connect()
        {
            // TODO: Add constructor logic here
        }
    }
}
