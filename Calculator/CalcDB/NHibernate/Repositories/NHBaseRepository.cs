using CalcDB.Models;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.NHibernate.Repositories
{
    public class NHBaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        public void Delete(long Id)
        {
            using (var session = Helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var obj = session.Get<User>(Id);
                    if(obj != null)
                    {
                        session.Delete(obj);
                        transaction.Commit();
                    }
                }
            }
        }

        public T Get(long Id)
        {
            using (var session = Helper.OpenSession())
            {
                return session.Get<T>(Id);
                //return session.Load<T>(Id);
            }
        }

        public IList<T> GetAll()
        {
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }

        public void Save(T result)
        {
            using (var session = Helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(result);
                    transaction.Commit();
                }
            }
        }
    }
}
