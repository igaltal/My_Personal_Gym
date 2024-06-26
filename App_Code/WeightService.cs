using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for CityService
/// </summary>
public class WeightService
{
    OleDbConnection myConnection;
    public WeightService()
    {
        string ConnectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(ConnectionString);
    }
    public DataSet GetAllWhight(int id)
    {
    
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * FROM WeightHeight WHERE Id="+id;
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
    public void InsertWei(int id, int we, int he, string date, int i)
    {
        try
        {
            myConnection.Open();
            string sSql = "INSERT INTO  WeightHeight VALUES (" + id + ",'" + date + "'," + i + "," + we + "," + he+ ")";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
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
    public DataSet cheakDate(string date)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT * from WeightHeight WHERE DateWeight='" + date+"'";
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
    public string GetWeight(int i,int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Weight from WeightHeight WHERE NumberOf=" + i+"AND Id="+id;
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

        return dataset.Tables[0].Rows[0][0].ToString();
    }
    public string Getheight(int i,int id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Height from WeightHeight WHERE NumberOf=" + i+" AND Id="+id;
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

        return dataset.Tables[0].Rows[0][0].ToString();
    }
    public string UpdateThem(int i)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT Height from WeightHeight WHERE NumberOf=" + i;
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

        return dataset.Tables[0].Rows[0][0].ToString();
    }
    public int GetLastCheak(int id)
    {
        int number = 0;
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "SELECT max(NumberOf) from WeightHeight WHERE Id="+id;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset);

            if (dataset.Tables[0].Rows.Count == 0)
                number = 0;
            else
                number = int.Parse(dataset.Tables[0].Rows[0][0].ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

        return number;
    }
}