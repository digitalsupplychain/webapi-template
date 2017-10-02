using DataAccess.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries.Demo
{
    public class UpdateStatementSource : QueryBase
    {
        public UpdateStatementSource(int id, DemoEntity entity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE [dbo].[Demo] ");
            sb.AppendLine("SET DemoString = @demoString ");
            sb.Append(",DemoBool = @demoBool ");
            sb.AppendLine("WHERE Id = @id ");

            _command = sb.ToString();

            _params.Add(new SqlParameter("@demoString", entity.DemoString));
            _params.Add(new SqlParameter("@demoBool", entity.DemoBool));
            _params.Add(new SqlParameter("@demoDate", entity.DemoBool));
        }
    }
}
