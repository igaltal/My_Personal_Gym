using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class Connect
    {
        // Use the absolute path for the SQLite database on a Mac
        private static readonly string filePath = "/Users/igaltal/Desktop/projects/gymigaltal/App_Data/Datatal.db";  // Adjust the file name as necessary

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
