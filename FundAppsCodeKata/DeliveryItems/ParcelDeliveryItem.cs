using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata.DeliveryItems
{
    public class ParcelDeliveryItem : IDeliveryItem
    {
        public ParcelDeliveryItem(Parcel parcel)
        {
            Type = DeliveryItemType.Parcel;
            Cost = GetParcelCost(parcel.Size, parcel.Weight);
        }

        public DeliveryItemType Type { get; set; }
        public decimal Cost { get; set; }

        private Dictionary<ParcelSize, ParcelDefaultValues> _parcelDefaultValues = new Dictionary<ParcelSize, ParcelDefaultValues>() {
            { ParcelSize.Small, new ParcelDefaultValues(3, 1) },
            { ParcelSize.Medium, new ParcelDefaultValues(8, 3) },
            { ParcelSize.Large, new ParcelDefaultValues(15, 6) },
            { ParcelSize.XL, new ParcelDefaultValues(25, 10) },
            { ParcelSize.Heavy, new ParcelDefaultValues(50, 50) } 
        };

        private decimal GetParcelCost(ParcelSize parcelSize, int weight)
        {
            ParcelDefaultValues defaultValues = _parcelDefaultValues[parcelSize];
            if (weight > defaultValues.Weight)
            {
                return defaultValues.Cost + CalculateExtraWeightCost(weight - defaultValues.Weight, parcelSize);
            }

            return defaultValues.Cost;
        }

        private decimal CalculateExtraWeightCost(int amountOverWeight, ParcelSize parcelSize)
        {
            if(parcelSize == ParcelSize.Heavy)
            {
                return amountOverWeight;
            }

            return 2 * amountOverWeight;
        }

        private struct ParcelDefaultValues
        {
            public ParcelDefaultValues(decimal cost, int weight)
            {
                Cost = cost;
                Weight = weight;
            }
            public decimal Cost { get; private set; }
            public int Weight { get; private set; }
        }
    }
}
