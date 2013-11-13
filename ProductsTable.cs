using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Discount
{
    [Table]
    public class ProductsTable
    {
        [Column(IsPrimaryKey = true,
            DbType = "NVARCHAR(100) NOT NULL",
            CanBeNull = false)]
        public string productID { get; set; }
        [Column]
        public int storeID { get; set; }
        [Column]
        public string storeName { get; set; }
        [Column]
        public string productName { get; set; }
        [Column]
        public int productTypeID { get; set; }
        [Column]
        public string productType { get; set; }
        [Column]
        public int discount { get; set; }
        [Column]
        public string oldPrice { get; set; }
        [Column]
        public string newPrice { get; set; }
        [Column]
        public string startDate { get; set; }
        [Column]
        public string endDate { get; set; }
        [Column]
        public string imageURL { get; set; }
    }
}
