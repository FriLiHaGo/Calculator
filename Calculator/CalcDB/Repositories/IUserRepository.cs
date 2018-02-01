using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);

        bool Check(string login, string password);


    }
}
