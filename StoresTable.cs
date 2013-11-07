using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Discount
{
    [Table]
    public class StoresTable
    {
        [Column(IsPrimaryKey = true,
            DbType = "INT NOT NULL",
            CanBeNull = false)]
        public int storeID { get; set; }

        [Column]
        public string storeName { get; set; }
    }
}
