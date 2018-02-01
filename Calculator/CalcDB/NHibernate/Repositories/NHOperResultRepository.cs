using CalcDB.Models;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.NHibernate.Repositories
{
    public class NHOperResultRepository : BaseRepository<OperationResult>, IOperResultRepository
    {
        public IEnumerable<OperationResult> GetByOperation(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationResult> GetByUserId(long id)
        {
            using(var session = Helper.OpenSession())
            {
                return session.QueryOver<OperationResult>()
                    .JoinQueryOver(it => it.Author)
                        .And(it => it.Id == id)
                    .List();
            }
        }
    }
}
