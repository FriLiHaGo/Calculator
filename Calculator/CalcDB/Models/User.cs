using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    public class User : IEntity
    {
        #region IEntity

        public long Id
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string TableName => throw new NotImplementedException();

        #endregion
    }
}
