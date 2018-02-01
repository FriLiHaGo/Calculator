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

        public long Id { get; set; }

        #endregion

        public long OperationId { get; set; }

        public long UserId { get; set; }

        public string Args { get; set; }

        public double? Result { get; set; }

        public long ExecutionTime { get; set; }

        public DateTime CreationDate { get; set; }

        public string Error { get; set; }
                
    }
}
