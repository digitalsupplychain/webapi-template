using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries.Demo
{
    public class SelectAllStatementSource : QueryBase
    {
        public SelectAllStatementSource()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELET * FROM [dbo].[Demo] ");
            sb.AppendLine("WITH (NOLOCK) ");

            _command = sb.ToString();
        }
    }
}
