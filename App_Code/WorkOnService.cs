using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Data.Sqlite;
using NewGymIgalTalProject.App_Code;

/// <summary>
/// Summary description for CityService
/// </summary>
public class WorkOnService
{ 
    SqliteConnection myConnection;
    public WorkOnService()
    {
        string ConnectionString = Connect.GetConnectionString();
        myConnection = new SqliteConnection(ConnectionString);
    }
    public DataSet GetWorkOn()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * from WorkOnTa";
            SqliteCommand myCmd = new SqliteCommand(sSql, myConnection);
            SqliteDataAdapter adapter = new SqliteDataAdapter(myCmd);
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
}