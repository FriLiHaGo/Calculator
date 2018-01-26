using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public interface IRepository
    {
        OperationResult Get(long Id);

        void Save(OperationResult result);

        void Delete(long Id);

        IList<OperationResult> GetByOperation(long Id);

        IList<OperationResult> GetAll();
    }
}
