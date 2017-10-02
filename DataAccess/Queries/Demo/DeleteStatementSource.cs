using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries.Demo
{
    public class DeleteStatementSource : QueryBase
    {
        public DeleteStatementSource(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DELETE FROM [dbo].[Demo] ");
            sb.AppendLine("WHERE Id = @id ");

            _command = sb.ToString();

            Parameters.Add(new SqlParameter("@id", id));
        }
    }
}
