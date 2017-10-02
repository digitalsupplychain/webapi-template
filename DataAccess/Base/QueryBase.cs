using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class QueryBase
    {
        public string Command
        {
            get
            {
                return _command;
            }
        }

        public IList<SqlParameter> Parameters
        {
            get
            {
                return _params;
            }
        }

        protected string _command;
        protected IList<SqlParameter> _params;

        public QueryBase()
        {
            _params = new List<SqlParameter>();
        }
    }
}
