using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class ExercisesService
    {
        private readonly SqliteConnection myConnection;

        public ExercisesService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Retrieves an exercise by its code.
        /// </summary>
        /// <param name="codeEx">The exercise code.</param>
        /// <returns>A DataTable containing the exercise details.</returns>
        public DataTable GetExerciseByCode(int codeEx)
        {
            DataTable dataTable = new DataTable();
            try
            {
                myConnection.Open();
                string sql = $"SELECT * FROM Exercises WHERE NumberExercises={codeEx}";
                using (var command = new SqliteCommand(sql, myConnection))
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
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

            return dataTable;
        }

        /// <summary>
        /// Retrieves the exercise code by its name.
        /// </summary>
        /// <param name="name">The exercise name.</param>
        /// <returns>The exercise code.</returns>
        public int GetExerciseCodeByName(string name)
        {
            int exerciseCode = 0;
            try
            {
                myConnection.Open();
                string sql = $"SELECT NumberExercises FROM Exercises WHERE NameExercises='{name}'";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    exerciseCode = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the exercise code", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return exerciseCode;
        }

        /// <summary>
        /// Retrieves all exercises.
        /// </summary>
        /// <returns>A DataTable containing all exercises.</returns>
        public DataTable GetAllExercises()
        {
            DataTable dataTable = new DataTable();
            try
            {
                myConnection.Open();
                string sql = "SELECT Exercises.NumberExercises, Exercises.NameExercises, Exercises.Description, WorkOnTa.NameWork FROM Exercises, WorkOnTa WHERE Exercises.WorkOn=WorkOnTa.CodeWork";
                using (var command = new SqliteCommand(sql, myConnection))
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching all exercises", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Retrieves exercises and their levels.
        /// </summary>
        /// <param name="num">The exercise number.</param>
        /// <returns>A DataTable containing exercises and levels.</returns>
        public DataTable GetExercisesAndLevels(int num)
        {
            DataTable dataTable = new DataTable();
            try
            {
                myConnection.Open();
                string sql = "SELECT Exercises.NumberExercises, Exercises.NameExercises, Exercises.Description, WorkOnTa.NameWork, Levels.NameLevel FROM Exercises, WorkOnTa, Levels WHERE Exercises.WorkOn=WorkOnTa.CodeWork AND Exercises.levelThis=Levels.CodeLevel AND Exercises.NumberExercises=" + num;
                using (var command = new SqliteCommand(sql, myConnection))
                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching exercises and levels", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Inserts a new exercise.
        /// </summary>
        /// <param name="name">The exercise name.</param>
        /// <param name="desc">The exercise description.</param>
        /// <param name="work">The work code.</param>
        /// <param name="level">The level code.</param>
        public void InsertExercise(string name, string desc, int work, int level)
        {
            int max = GetMax() + 1;
            try
            {
                myConnection.Open();
                string sql = $"INSERT INTO Exercises (NumberExercises, NameExercises, Description, WorkOn, LevelThis) VALUES ({max}, '{name}', '{desc}', {work}, {level})";
                using (var command = new SqliteCommand(sql, myConnection))
                {
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
        /// Retrieves the maximum exercise code.
        /// </summary>
        /// <returns>The maximum exercise code.</returns>
        public int GetMax()
        {
            int maxNumber = 0;
            try
            {
                myConnection.Open();
                string sql = "SELECT MAX(NumberExercises) FROM Exercises";
                using (var command = new SqliteCommand(sql, myConnection))
                {
                    maxNumber = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the maximum exercise code", ex);
            }
            finally
            {
                myConnection.Close();
            }

            return maxNumber;
        }
    }
}
