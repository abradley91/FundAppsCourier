using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata.DeliveryItems
{
    public class SpeedyDeliveryItem : IDeliveryItem
    {
        public SpeedyDeliveryItem(decimal cost)
        {
            Type = DeliveryItemType.SpeedyDelivery;
            Cost = cost;
        }

        public DeliveryItemType Type { get; set; }
        public decimal Cost { get; set; }
    }
}
