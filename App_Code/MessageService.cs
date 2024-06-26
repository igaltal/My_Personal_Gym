using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class MessageService
    {
        private readonly SqliteConnection myConnection;

        public MessageService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves messages for a specific user.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>A DataSet containing the user's messages.</returns>
        public DataSet GetMessages(int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Messages.TheMessage, Messages.Froms, Messages.Date FROM Messages JOIN Users ON Users.Id = Messages.Froms WHERE Messages.To = @id";
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
                throw new Exception("An error occurred while fetching messages", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Inserts a new message into the database.
        /// </summary>
        /// <param name="idFrom">The ID of the sender.</param>
        /// <param name="idTo">The ID of the receiver.</param>
        /// <param name="message">The message content.</param>
        /// <param name="date">The date the message was sent.</param>
        public void InsertMessage(int idFrom, int idTo, string message, string date)
        {
            try
            {
                myConnection.Open();
                string sql = "INSERT INTO Messages (Froms, To, Date, TheMessage) VALUES (@idFrom, @idTo, @date, @message)";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@idFrom", idFrom);
                    command.Parameters.AddWithValue("@idTo", idTo);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@message", message);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the message", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Retrieves messages sent by a specific user.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>A DataSet containing the messages sent by the user.</returns>
        public DataSet GetSentMessages(int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Messages.TheMessage, Messages.Date FROM Messages JOIN Users ON Users.Id = Messages.To WHERE Messages.Froms = @id";
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
                throw new Exception("An error occurred while fetching sent messages", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }
    }
}
