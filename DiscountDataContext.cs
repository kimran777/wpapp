using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Discount
{
    class DiscountDataContext : DataContext
    {
        public static string DBConnectionString =
        "Data Source=isostore:/localDB.sdf;";
        public DiscountDataContext(string connectionString)
            : base(connectionString)
        { }
        public DiscountDataContext()
            : base(DBConnectionString)
        { }
        public Table<StoresTable> Stores;
        public Table<ProductsTable> Products;
    }
}
