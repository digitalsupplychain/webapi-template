using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDemoRepository
    {
        List<DemoEntity> GetAll();

        DemoEntity GetById(int id);

        void Modify(int id, DemoEntity entity);

        void Remove(int id);

        DemoEntity Add(DemoEntity entity);
    }
}
