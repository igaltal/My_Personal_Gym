using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class TrainersService
    {
        private readonly SqliteConnection myConnection;

        public TrainersService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves all trainers from the database.
        /// </summary>
        /// <returns>A DataSet containing all trainers.</returns>
        public DataSet GetTrainers()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Trainers.Description, Trainers.Specialty, Users.Id FROM Users JOIN Trainers ON Users.Id = Trainers.CodeTrainer";
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
                throw new Exception("An error occurred while fetching trainers", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Retrieves a trainer by their ID.
        /// </summary>
        /// <param name="id">The trainer ID.</param>
        /// <returns>A DataSet containing the trainer's details.</returns>
        public DataSet GetTrainerById(int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Trainers.Description, Trainers.Specialty, Gender.NameGender, Users.Date, Cities.NameCity FROM Users JOIN Trainers ON Users.Id = Trainers.CodeTrainer JOIN Gender ON Users.Gender = Gender.CodeGender JOIN Cities ON Users.NumCity = Cities.CodeCity WHERE Users.Id = @id";
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
                throw new Exception("An error occurred while fetching the trainer's details", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Retrieves all trainers with additional details.
        /// </summary>
        /// <returns>A DataSet containing all trainers with additional details.</returns>
        public DataSet GetAllTrainers()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Trainers.Description, Trainers.Specialty, Gender.NameGender, Users.Date, Cities.NameCity, Users.Id FROM Users JOIN Trainers ON Users.Id = Trainers.CodeTrainer JOIN Gender ON Users.Gender = Gender.CodeGender JOIN Cities ON Users.NumCity = Cities.CodeCity";
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
                throw new Exception("An error occurred while fetching all trainers", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Retrieves trainers by their rank.
        /// </summary>
        /// <returns>A DataSet containing trainers by their rank.</returns>
        public DataSet GetTrainersByRank()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Users.Id FROM Users WHERE Rank = 1";
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
                throw new Exception("An error occurred while fetching trainers by rank", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Adds a new trainer.
        /// </summary>
        /// <param name="id">The trainer ID.</param>
        /// <param name="specialty">The trainer's specialty.</param>
        /// <param name="description">The trainer's description.</param>
        public void AddNewTrainer(int id, string specialty, string description)
        {
            try
            {
                myConnection.Open();
                string sql = "INSERT INTO Trainers (CodeTrainer, Specialty, Description) VALUES (@id, @specialty, @description)";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@specialty", specialty);
                    command.Parameters.AddWithValue("@description", description);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the new trainer", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Retrieves trainers for messaging purposes.
        /// </summary>
        /// <returns>A DataSet containing trainers for messaging.</returns>
        public DataSet GetTrainersForMessaging()
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Users.Name, Users.Id FROM Users WHERE Rank = 1";
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
                throw new Exception("An error occurred while fetching trainers for messaging", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }
    }
}
