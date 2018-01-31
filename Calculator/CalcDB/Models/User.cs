using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    public enum UserStatus
    {
        Active = 1,
        Blocked = 2,
        Deleted = 3,
        System = 4
    }

    public class User : IEntity
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserStatus Status { get; set; }
    }
}
