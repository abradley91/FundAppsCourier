using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public enum DeliveryItemType
    {
        Parcel,
        SpeedyDelivery
    }

    public interface IDeliveryItem
    {
        DeliveryItemType Type { get; set; }
        decimal Cost { get; set; }
    }

    public class DeliveryItem : IDeliveryItem
    {
        public DeliveryItemType Type { get; set; }
        public decimal Cost { get; set; }

        public DeliveryItem(Parcel parcel)
        {
            Type = DeliveryItemType.Parcel;
            Cost = GetParcelCost(parcel.Size);
        }

        private decimal GetParcelCost(ParcelSize parcelSize)
        {
            if (parcelSize == ParcelSize.Small)
            {
                return 3;
            }
            else if (parcelSize == ParcelSize.Medium)
            {
                return 8;
            }
            else if (parcelSize == ParcelSize.Large)
            {
                return 15;
            }
            else
            {
                return 25;
            }
        }
    }

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
