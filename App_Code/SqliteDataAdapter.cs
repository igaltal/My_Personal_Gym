using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace NewGymIgalTalProject.App_Code
{
    public class SqliteDataAdapter
    {
        private SqliteCommand _selectCommand;

        public SqliteDataAdapter()
        {
        }

        public SqliteDataAdapter(SqliteCommand selectCommand)
        {
            _selectCommand = selectCommand;
        }

        public SqliteCommand SelectCommand 
        { 
            get { return _selectCommand; }
            set { _selectCommand = value; }
        }

        public void Fill(DataSet dataSet)
        {
            if (_selectCommand == null)
            {
                throw new InvalidOperationException("SelectCommand property must be set before calling Fill.");
            }

            using var reader = _selectCommand.ExecuteReader();
            var dataTable = new DataTable();
            dataSet.Tables.Add(dataTable);
            dataTable.Load(reader);
        }
    }
} 