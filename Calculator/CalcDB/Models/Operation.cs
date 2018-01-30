using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Models
{
    public class Operation : IEntity
    {
        #region IEntity

        public long Id { get; set; }

        public string TableName => "[dbo].[Operation]";

        #endregion

        public string Name { get; set; }

        public long OwnerId { get; set; }

        public string[] Columns => new string[] { "[Name]", "[OwnerId]" };

        public string SerialData => $"N'{Name}', {OwnerId}";

    }
}
