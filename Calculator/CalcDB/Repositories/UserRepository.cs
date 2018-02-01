using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public User GetByLogin(string login)
        {
            if (!string.IsNullOrWhiteSpace(login))
            {
                var user = ExecQuery($"[Login] = N'{login}'");
                return user.ElementAtOrDefault(0);
            }
            return null;
        }

        public bool Check(string login, string password)
        {
            var result = ExecQuery($"[Password] = N'{password}' AND [Status] in (1, 4)  AND ([Login] = N'{login}' OR [Email] = N'{login}')");
            return result.Any();
        }
    }
}
