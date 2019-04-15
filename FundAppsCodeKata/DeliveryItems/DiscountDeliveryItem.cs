using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata.DeliveryItems
{
    public class DiscountDeliveryItem : IDeliveryItem
    {
        public DeliveryItemType Type { get; set; }
        public decimal Cost { get; set; }

        public DiscountDeliveryItem(decimal cost)
        {
            Type = DeliveryItemType.Discount;
            Cost = -cost;
        }
    }
}
