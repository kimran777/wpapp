using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discount
{
    public class CProductLocal
    {
        public string productID { get; set; }
        public int storeID { get; set; }
        public string productName { get; set; }
        public int discount { get; set; }
        public string oldPrice { get; set; }
        public string newPrice { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string imageURL { get; set; }
    }
}
