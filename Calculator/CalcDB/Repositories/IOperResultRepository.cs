using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public interface IOperResultRepository : IRepository<OperationResult>
    {
        IEnumerable<OperationResult> GetByOperation(long id);

        IEnumerable<OperationResult> GetByUserId(long id);
    }
}
