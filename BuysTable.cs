using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Discount
{
    [Table]
    public class BuysTable
    {
        [Column(IsPrimaryKey = true,
            DbType = "NVARCHAR(100) NOT NULL",
            CanBeNull = false)]
        public string productID { get; set; }
    }
}
