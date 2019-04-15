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

        

        private decimal GetParcelCost(ParcelSize parcelSize, int weight)
        {
            var parcelDefaultValues = ParcelRepository.GetParcelDefaultValues();
            ParcelDefaultValues defaultValues = parcelDefaultValues[parcelSize];
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
    }
}
