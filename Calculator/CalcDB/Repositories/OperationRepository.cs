using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public Operation GetOrCreate(string name)
        {
            var oper = ExecQuery($"[Name] = N'{name}'").FirstOrDefault();
            if (oper == null)
            {
                oper = new Operation()
                {
                    Name = name,
                    OwnerId = 1
                };
                Save(oper);
            }
            return oper;
        }
    }
}
