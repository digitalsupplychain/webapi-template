using DataAccess.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries.Demo
{
    public class InsertStatementSource : QueryBase
    {
        public InsertStatementSource(DemoEntity entity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [dbo].[DistanceReports] ");
            sb.AppendLine("(DemoString, DemoBool, DemoDate) ");
            sb.AppendLine("VALUES ");
            sb.AppendLine("(@demoString, @demoBool, @demoDate) ");
            sb.AppendLine("SET @identity = SCOPE_IDENTITY() ");

            _command = sb.ToString();

            Parameters.Add(new SqlParameter("@demoString", entity.DemoString));
            Parameters.Add(new SqlParameter("@demoBool", entity.DemoBool));
            Parameters.Add(new SqlParameter("@demoDate", entity.DemoDate));

            SqlParameter identity = new SqlParameter("@identity", SqlDbType.Int, 4);
            identity.Direction = ParameterDirection.Output;
            Parameters.Add(identity);
        }
    }
}
