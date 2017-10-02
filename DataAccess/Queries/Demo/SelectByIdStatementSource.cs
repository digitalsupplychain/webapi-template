using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries.Demo
{
    public class SelectByIdStatementSource : QueryBase
    {
        public SelectByIdStatementSource(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELET * FROM [dbo].[Demo] ");
            sb.AppendLine("WHERE Id = @id ");
            sb.AppendLine("WITH (NOLOCK) ");
            
            _command = sb.ToString();

            _params.Add(new SqlParameter("@id", id));
        }
    }
}
