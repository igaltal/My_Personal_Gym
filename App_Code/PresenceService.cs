using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class PresenceService
    {
        private readonly SqliteConnection myConnection;

        public PresenceService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves presence records for a specific user.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>A DataSet containing the user's presence records.</returns>
        public DataSet GetPresence(int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM Presence WHERE UserID = @id";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataset.Tables.Add(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching presence records", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Inserts a new presence record.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="from">The start time of the presence.</param>
        /// <param name="to">The end time of the presence.</param>
        /// <param name="number">The presence number.</param>
        public void InsertPresence(int id, string from, string to, int number)
        {
            try
            {
                myConnection.Open();
                string sql = "INSERT INTO Presence (UserID, NumberOF, Froms, Tos) VALUES (@id, @number, @from, @to)";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@from", from);
                    command.Parameters.AddWithValue("@to", to);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the presence record", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Retrieves the maximum presence number for a specific user.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The maximum presence number.</returns>
        public int GetMaxPresenceNumber(int id)
        {
            int maxNumber = 0;
            try
            {
                myConnection.Open();
                string sql = "SELECT MAX(NumberOF) FROM Presence WHERE UserID = @id";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    maxNumber = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the maximum presence number", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return maxNumber;
        }
    }
}
