using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for CityService
/// </summary>
public class WorkOnService
{ 
    OleDbConnection myConnection;
    public WorkOnService()
    {
        string ConnectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(ConnectionString);
    }
    public DataSet GetWorkOn()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * from WorkOnTa";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();

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
}