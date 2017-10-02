using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Base
{
    public class DataSourceBase : IDisposable
    {
        #region Properties

        public string Command
        {
            get { return _sqlComm; }
            set { _sqlComm = value; }
        }

        public IList<SqlParameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion Properties

        #region Attributes

        private string _sqlComm;
        private SqlConnection _sqlConnection;
        private IList<SqlParameter> _parameters;
        private bool disposedValue = false;

        #endregion Attributes

        private void GetConnection(string connString)
        {
            _sqlConnection = new SqlConnection(connString);
        }

        public DataSourceBase(string Connection)
        {
            GetConnection(Connection);
            _parameters = new List<SqlParameter>();
        }

        public DataSourceBase(string Connection, string Command) : this(Connection)
        {
            _sqlComm = Command;
        }

        public DataSourceBase(string Connection, string Command, IList<SqlParameter> _params) : this(Connection, Command)
        {
            _parameters = _params;
        }

        /// <summary>
        /// Executes the input command as-is and returns the DataTable
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable ExecuteCommand()
        {
            DataTable DataResult = new DataTable();

            using (_sqlConnection)
            {

                SqlCommand command = new SqlCommand(_sqlComm, _sqlConnection);

                if (_parameters.FirstOrDefault() != null)
                {
                    foreach (SqlParameter item in _parameters)
                        command.Parameters.Add(item);
                }

                _sqlConnection.Open();
                try
                {
                    var data = new SqlDataAdapter(command);
                    data.Fill(DataResult);
                    _sqlConnection.Close();
                }
                catch (Exception e)
                {
                    _sqlConnection.Close();
                    throw e;
                    //Config.Config.LogException(e);
                }
            }

            return DataResult;
        }

        public int ExecuteNonQuery()
        {
            int result = 0;

            using (_sqlConnection)
            {
                SqlCommand command = new SqlCommand(_sqlComm, _sqlConnection);

                if (_parameters.FirstOrDefault() != null)
                {
                    foreach (SqlParameter item in _parameters)
                        command.Parameters.Add(item);
                }

                _sqlConnection.Open();
                try
                {
                    result = command.ExecuteNonQuery();
                    _sqlConnection.Close();
                }
                catch (Exception e)
                {
                    _sqlConnection.Close();
                    throw e;
                    //Config.Config.LogException(e);
                }
            }
            return result;
        }

        public int ExecuteInsert()
        {
            int result = 0;

            using (_sqlConnection)
            {
                SqlCommand command = new SqlCommand(_sqlComm, _sqlConnection);

                if (_parameters.FirstOrDefault() != null)
                {
                    foreach (SqlParameter item in _parameters)
                        command.Parameters.Add(item);
                }

                _sqlConnection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    result = Int32.Parse(command.Parameters["@identity"].Value.ToString());
                    _sqlConnection.Close();
                }
                catch (Exception e)
                {
                    _sqlConnection.Close();
                    throw e;
                    //Config.Config.LogException(e);
                }
            }
            return result;
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (!disposing) return;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            if (_sqlConnection.State.GetHashCode() == ConnectionState.Open.GetHashCode())
                _sqlConnection.Close();
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable
    }
}