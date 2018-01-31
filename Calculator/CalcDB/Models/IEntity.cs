using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    /// <summary>
    /// Сущность, хранится в БВ
    /// </summary>
    public interface IEntity
    {
        long Id { get; set; }
    }
}
