using CalcDB.Models;
using CalcDB.Repositories;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.NHibernate.Repositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepository
    {
        public bool Check(string login, string password)
        {
            using(var session = Helper.OpenSession())
            {
                var query = session.QueryOver<User>();
                //query.And(u => u.Password == password);
                //query.And(u => u.Status == UserStatus.Active || u.Status == UserStatus.System);
                //query.And(u => u.Login == login || u.Email == login);
                var t = query.List();
                return t.Count > 0;
            }
        }

        public User GetByLogin(string login)
        {
            using (var session = Helper.OpenSession())
            {
                var criteria = session.CreateCriteria<User>();
                criteria.Add(Restrictions.Or(
                    Restrictions.Eq("Email", login),
                    Restrictions.Eq("Login", login)
                    ));
                return criteria.UniqueResult<User>();
            }
        }
    }
}
