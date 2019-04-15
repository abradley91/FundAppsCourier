using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public enum DeliveryItemType
    {
        Parcel
    }

    public class DeliveryItem
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
}
