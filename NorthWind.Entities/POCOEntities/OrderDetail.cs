using NorthWind.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.POCOEntities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Order Order { get; set; }
        public DiscountTypes DiscountType { get; set; }
        public double Discount { get; set; }
        public ShippingTypes ShippingType { get; set; }

    }
}
