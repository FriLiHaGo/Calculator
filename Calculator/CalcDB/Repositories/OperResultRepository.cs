using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public class OperResultRepository: BaseRepository<OperationResult>, IOperResultRepository
    {
        IEnumerable<OperationResult> IOperResultRepository.GetByOperation(long id)
        {
            return null;
        }

        public IEnumerable<OperationResult> GetByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
