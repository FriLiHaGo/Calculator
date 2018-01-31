using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    /// <summary>
    /// Подписки
    /// </summary>
    public class Subscription : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Limit { get; set; }
    }

    /// <summary>
    /// Подписки пользователя
    /// </summary>
    public class UserSubs : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long SubsId { get; set; }
    }

    /// <summary>
    /// Операции подписки
    /// </summary>
    public class SubsOperations : IEntity
    {
        public long Id { get; set; }

        public long SubsId { get; set; }

        public long OperationId { get; set; }
    }
}
