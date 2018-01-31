using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public interface IOperationRepository : IRepository<Operation>
    {
        Operation GetOrCreate(string name);
    }
}
