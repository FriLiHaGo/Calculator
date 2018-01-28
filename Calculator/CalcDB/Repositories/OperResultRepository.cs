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
    public class OperResultRepository: BaseRepository<OperationResult>
    {
        public IList<OperationResult> GetByOperation(long Id)
        {
            return null;
        }
    }
}
