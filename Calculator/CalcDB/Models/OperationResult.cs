using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    public class OperationResult: IEntity
    {
        #region IEntity

        public virtual long Id { get; set; }

        #endregion

        public virtual long OperationId { get; set; }

        public virtual User Author { get; set; }

        public virtual long UserId { get; set; }

        public virtual string Args { get; set; }

        public virtual double? Result { get; set; }

        public virtual long ExecutionTime { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual string Error { get; set; }
                
    }
}
