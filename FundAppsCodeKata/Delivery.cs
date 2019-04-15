using FundAppsCodeKata.DeliveryItems;
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
            DeliveryItems = new List<IDeliveryItem>();
            TotalCost = 0;
        }

        public List<IDeliveryItem> DeliveryItems { get; }
        public decimal TotalCost { get; private set; }

        public void AddParcelToDelivery(Parcel parcel)
        {
            ParcelDeliveryItem parcelDeliveryItem = new ParcelDeliveryItem(parcel);
            DeliveryItems.Add(parcelDeliveryItem);
            TotalCost += parcelDeliveryItem.Cost;
        }

        public void AddSpeedyDelivery()
        {
            SpeedyDeliveryItem speedyDeliveryItem = new SpeedyDeliveryItem(TotalCost);
            DeliveryItems.Add(speedyDeliveryItem);
            TotalCost *= 2;
        }
    }
}
