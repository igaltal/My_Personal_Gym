using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Data.Sqlite;
using NewGymIgalTalProject.App_Code;

public class UserService
{
    SqliteConnection myConnection;
    
    public UserService()
    {
        string connectionString = Connect.GetConnectionString();
        myConnection = new SqliteConnection(connectionString);
    }
    
    public Users ValidateUser(string username, string password)
    {
        Users user = null;
        try
        {
            myConnection.Open();
            string sSql = "SELECT * FROM Users WHERE UserName = @Username AND Password = @Password";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            myCmd.Parameters.AddWithValue("@Username", username);
            myCmd.Parameters.AddWithValue("@Password", password);
            
            using var reader = myCmd.ExecuteReader();
            if (reader.Read())
            {
                user = new Users
                {
                    GetId = reader.GetInt32(reader.GetOrdinal("Id")),
                    GetName = reader.GetString(reader.GetOrdinal("UserName"))
                };
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
        
        return user;
    }

    public void InsertPerson(Users u)
    {
        int Id = u.GetId;
        string Name = u.GetName;
        string LastName = u.GetLastName;
        string Phone = u.GetPhone;
        int NumCity = u.GetNumCity;
        string ThisDate = u.ThisDateGet;
        string Pass = u.GetPassword;
        string DateB = u.GetDateB;
        int Gender = u.GetGender;
        int Weight = u.GetWeight;
        int Height = u.GetHeight;
        int LevelStart = u.GetStartLevel;
        int goal = u.GetGoal;
        int TrainerCode = u.GetTrainer;
        int rank = u.GetRank;
        int itakdmot = u.GetItakdmot;

        try
        {
            myConnection.Open();
            string sSql = "INSERT INTO Users VALUES (" + Id + ",'" + Name + "','" + LastName + "','" + Phone + "'," + NumCity + ",'" + ThisDate + "','" + Pass + "','" + DateB + "'," + Gender + "," + Weight + "," + Height + "," + LevelStart + "," + LevelStart + "," + goal + "," + TrainerCode + "," + rank + "," + itakdmot + ")";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public DataSet cheakid(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * from Users WHERE Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public DataSet CheckPass(string pass, int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * FROM Users WHERE Password='" + pass + "' AND Id=" + id + "";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public int GetIdWhereIsPass(string pass)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Id from Users where password='" + pass + "'";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }

    public string GetUserName(int Id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Name from Users where Id=" + Id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset.Tables[0].Rows[0][0].ToString();
    }

    public string GetUserLevelNow(int Id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Levels.NameLevel from Users,Levels where Levels.CodeLevel=Users.LevelNow AND Users.Id=" + Id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset.Tables[0].Rows[0][0].ToString();
    }

    public int CodeCoachingWhereId(int id)
    {
        return id;
    }

    public int GetRank(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Rank from Users where Id =" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }

    public DataSet GetAll()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Users.Id,Users.Name,Users.LastName,Users.Pelepone,Cities.NameCity,Users.Thisdata,Users.Password,Users.Date,Gender.NameGender,Users.Weight,Users.Height,LevelStart.NameLevelStart,Levels.NameLevel,Users.Goal,Users.Trainer,Ranks.RankName From Users,Cities,Gender,Ranks,Levels,LevelStart  Where Users.NumCity=Cities.CodeCity AND Users.Gender=Gender.CodeGender AND Users.rank=Ranks.RankCode AND LevelStart.CodeLevelStart=Users.LevelStart AND Users.LevelNow=Levels.CodeLevel ";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public DataSet GetAllTrainer(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Users.Id,Users.Name,Users.LastName,Users.Thisdata,Levels.NameLevel,LevelStart.NameLevelStart From Users,levels,LevelStart Where LevelStart.CodeLevelStart=Users.LevelStart AND Users.LevelNow=Levels.CodeLevel AND Users.Trainer=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public DataSet GetTopFive()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT top 5 * FROM Users ORDER BY Itkadmot DESC ";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public DataSet UpdateLevel(int now, int id, int itkadmot)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET Users.LevelNow=" + now + ",Users.Itkadmot=" + itkadmot + " WHERE Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public int GetHeight(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Height FROM Users WHERE Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }

    public int GetWeight(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Weight FROM Users WHERE Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }

    public string GetGender(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Gender.NameGender FROM Users,Gender WHERE Users.Gender=Gender.CodeGender And Users.Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset.Tables[0].Rows[0][0].ToString();
    }

    public DataSet GetProfil(int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Users.Id,Users.Name,Users.LastName,Users.Pelepone,Levels.NameLevel,LevelStart.NameLevelStart,Cities.NameCity From Users,levels,LevelStart,Cities Where LevelStart.CodeLevelStart = Users.LevelStart AND Levels.CodeLevel = Users.LevelNow AND Users.NumCity=Cities.CodeCity AND Users.Id= " + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public void UpdateProfil(string name, int phone, int city, int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET Users.Name='" + name + "',Users.Pelepone=" + phone + ",Users.NumCity=" + city + " WHERE Users.Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public DataSet UpdateRank(int id, int rank)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET Users.Rank=" + rank + " WHERE Users.Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public DataSet UpdateTrainer(int id, int trinerid)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET Users.Trainer=" + trinerid + " WHERE Users.Id=" + id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return dataset;
    }

    public int GetNumUserLevelNow(int Id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT LevelNow from Users where Id=" + Id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }

    public int GetNumUserStartLevel(int Id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT LevelStart from Users where Id=" + Id;
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter();

            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
    }
}
