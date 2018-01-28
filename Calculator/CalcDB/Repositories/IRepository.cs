using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public interface IRepository<T> where T: IEntity
    {
        T Get(long Id);

        void Save(T result);

        void Delete(long Id);

        IList<T> GetAll();
    }
}
