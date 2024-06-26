using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class ProgramService
    {
        private readonly SqliteConnection myConnection;

        public ProgramService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves program exercises for a specific coaching program.
        /// </summary>
        /// <param name="number">The coaching program number.</param>
        /// <returns>A DataSet containing the program exercises.</returns>
        public DataSet GetProgram(int number)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT Exercises.NameExercises, ExercisesTrain.NumBack, ExercisesTrain.RetaNumber, WorkOnTa.NameWork FROM Exercises JOIN ExercisesTrain ON ExercisesTrain.CodeExercises = Exercises.NumberExercises JOIN WorkOnTa ON Exercises.WorkOn = WorkOnTa.CodeWork WHERE ExercisesTrain.CodeCoaching = @number";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@number", number);
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
                throw new Exception("An error occurred while fetching the program", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Inserts a new exercise into the program.
        /// </summary>
        /// <param name="coaching">The coaching program ID.</param>
        /// <param name="exercises">The exercise ID.</param>
        /// <param name="retu2">The second return value.</param>
        /// <param name="retu">The first return value.</param>
        /// <param name="workon">The work on value.</param>
        public void InsertExercise(int coaching, int exercises, string retu2, string retu, int workon)
        {
            try
            {
                myConnection.Open();
                string sql = "INSERT INTO ExercisesTrain (CodeCoaching, CodeExercises, RetaNumber, NumBack, WorkOn) VALUES (@coaching, @exercises, @retu2, @retu, @workon)";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@coaching", coaching);
                    command.Parameters.AddWithValue("@exercises", exercises);
                    command.Parameters.AddWithValue("@retu2", retu2);
                    command.Parameters.AddWithValue("@retu", retu);
                    command.Parameters.AddWithValue("@workon", workon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the exercise", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Updates an exercise in the program.
        /// </summary>
        /// <param name="coaching">The coaching program ID.</param>
        /// <param name="exercises">The exercise ID.</param>
        /// <param name="retu2">The second return value.</param>
        /// <param name="retu">The first return value.</param>
        public void UpdateExercise(int coaching, int exercises, string retu2, string retu)
        {
            try
            {
                myConnection.Open();
                string sql = "UPDATE ExercisesTrain SET RetaNumber = @retu2, NumBack = @retu WHERE CodeCoaching = @coaching AND CodeExercises = @exercises";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@coaching", coaching);
                    command.Parameters.AddWithValue("@exercises", exercises);
                    command.Parameters.AddWithValue("@retu2", retu2);
                    command.Parameters.AddWithValue("@retu", retu);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the exercise", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Checks if an exercise exists in the program.
        /// </summary>
        /// <param name="name">The exercise name.</param>
        /// <param name="id">The coaching program ID.</param>
        /// <returns>A DataSet containing the exercise details.</returns>
        public DataSet CheckExercise(int name, int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM ExercisesTrain WHERE CodeExercises = @name AND CodeCoaching = @id";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@name", name);
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
                throw new Exception("An error occurred while checking the exercise", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Retrieves the number of a specific coaching program.
        /// </summary>
        /// <param name="name">The exercise name.</param>
        /// <returns>The number of the coaching program.</returns>
        public int GetCoachingProgramNumber(int name)
        {
            int number = 0;
            try
            {
                myConnection.Open();
                string sql = "SELECT CodeCoaching FROM ExercisesTrain WHERE CodeExercises = @name";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    number = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the coaching program number", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return number;
        }

        /// <summary>
        /// Retrieves a specific exercise from the program.
        /// </summary>
        /// <param name="id">The coaching program ID.</param>
        /// <param name="exerciseNum">The exercise number.</param>
        /// <returns>A DataSet containing the exercise details.</returns>
        public DataSet GetExercise(int id, int exerciseNum)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM ExercisesTrain WHERE CodeCoaching = @id AND CodeExercises = @exerciseNum";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@exerciseNum", exerciseNum);
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
                throw new Exception("An error occurred while fetching the exercise", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Retrieves all exercises in a specific coaching program.
        /// </summary>
        /// <param name="id">The coaching program ID.</param>
        /// <returns>A DataSet containing all exercises in the program.</returns>
        public DataSet GetAllExercises(int id)
        {
            DataSet dataset = new DataSet();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM ExercisesTrain WHERE CodeCoaching = @id";
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
                throw new Exception("An error occurred while fetching all exercises in the program", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataset;
        }

        /// <summary>
        /// Deletes an exercise from the program.
        /// </summary>
        /// <param name="id">The coaching program ID.</param>
        /// <param name="exerciseNum">The exercise number.</param>
        public void DeleteExercise(int id, int exerciseNum)
        {
            try
            {
                myConnection.Open();
                string sql = "DELETE FROM ExercisesTrain WHERE CodeCoaching = @id AND CodeExercises = @exerciseNum";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@exerciseNum", exerciseNum);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the exercise", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
