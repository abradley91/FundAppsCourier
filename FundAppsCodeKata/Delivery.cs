using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public class Delivery
    {
        public Delivery()
        {
            DeliveryItems = new List<DeliveryItem>();
            TotalCost = 0;
        }

        public List<DeliveryItem> DeliveryItems { get; }
        public decimal TotalCost { get; private set; }

        public void AddParcelToDelivery(Parcel parcel)
        {
            DeliveryItem deliveryItem = new DeliveryItem(parcel);
            DeliveryItems.Add(deliveryItem);
            TotalCost += deliveryItem.Cost;
        }
    }
}
