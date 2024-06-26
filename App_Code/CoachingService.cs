using System;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class CoachingService
    {
        private readonly SqliteConnection myConnection;

        public CoachingService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }
    }
}
