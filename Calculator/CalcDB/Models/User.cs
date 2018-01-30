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

        public long Id { get; set; }

        public string TableName => "[dbo].[User]";

        #endregion
    }
}
