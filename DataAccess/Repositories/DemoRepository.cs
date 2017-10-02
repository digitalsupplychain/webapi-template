using DataAccess.Base;
using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Queries.Demo;

namespace DataAccess.Repositories
{
    public class DemoRepository : BaseRepository<DemoEntity>, IDemoRepository
    {
        public DemoEntity Add(DemoEntity entity)
        {
            entity.Id = Insert(new InsertStatementSource(entity));
            return entity;
        }

        public List<DemoEntity> GetAll()
        {
            List<DemoEntity> entities = new List<DemoEntity>();
            DataTable dt = Select(new SelectAllStatementSource());
            foreach(DataRow dr in dt.Rows)
            {
                entities.Add(Map(dr));
            }
            return entities;
        }

        public DemoEntity GetById(int id)
        {
            DataTable dt = Select(new SelectByIdStatementSource(id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Modify(int id, DemoEntity entity)
        {
            Update(new UpdateStatementSource(id, entity));
        }

        public void Remove(int id)
        {
            Delete(new DeleteStatementSource(id));
        }

        protected override DemoEntity Map(DataRow row)
        {
            DemoEntity entity = new DemoEntity {
                Id = int.Parse(row["Id"].ToString()),
                DemoString = row["DemoString"].ToString(),
                DemoBool = bool.Parse(row["DemoBool"].ToString()),
                DemoDate = DateTime.Parse(row["DemoDate"].ToString())
            };

            return entity;
        }
    }
}
