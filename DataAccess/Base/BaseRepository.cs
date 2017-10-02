using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public abstract class BaseRepository<T>
    {
        private string _dbconn;

        public BaseRepository()
        {
            _dbconn = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public DataTable Select(QueryBase query)
        {
            using (var conn = new DataSourceBase(_dbconn, query.Command, query.Parameters))
            {
                return conn.ExecuteCommand();
            }
        }

        public int Insert(QueryBase query)
        {
            using (var conn = new DataSourceBase(_dbconn, query.Command, query.Parameters))
            {
                return conn.ExecuteInsert();
            }
        }

        public void Update(QueryBase query)
        {
            using (var conn = new DataSourceBase(_dbconn, query.Command, query.Parameters))
            {
                conn.ExecuteNonQuery();
            }
        }

        public void Delete(QueryBase query)
        {
            using (var conn = new DataSourceBase(_dbconn, query.Command, query.Parameters))
            {
                conn.ExecuteNonQuery();
            }
        }

        protected abstract T Map(DataRow row);
    }
}
