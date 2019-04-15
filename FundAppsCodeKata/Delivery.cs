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

        private List<Parcel> _parcels = new List<Parcel>();

        public void AddParcelToDelivery(Parcel parcel)
        {
            ParcelDeliveryItem parcelDeliveryItem = new ParcelDeliveryItem(parcel);
            DeliveryItems.Add(parcelDeliveryItem);
            TotalCost += parcelDeliveryItem.Cost;
            _parcels.Add(parcel);
        }

        public void ApplyDiscounts()
        {
            var parcelDefaultValues = ParcelRepository.GetParcelDefaultValues();

            Dictionary<ParcelSize, int> currentParcels = new Dictionary<ParcelSize, int>() { { ParcelSize.Small, 0 }, { ParcelSize.Medium, 0 } };
            int count = 1;
            foreach(Parcel parcel in _parcels)
            {
                decimal currentMinDiscount = Int32.MaxValue;
                if (currentParcels.ContainsKey(parcel.Size))
                {
                    currentParcels[parcel.Size]++;
                    if(parcel.Size == ParcelSize.Small)
                    {
                        int currentParcelCount = currentParcels[parcel.Size];
                        if(currentParcelCount % 4 == 0)
                        {
                            currentMinDiscount = 3;
                            count -= 4;
                        }
                    }
                    else if (parcel.Size == ParcelSize.Medium)
                    {
                        int currentParcelCount = currentParcels[parcel.Size];
                        if (currentParcelCount % 3 == 0)
                        {
                            currentMinDiscount = 8;
                            count -= 3;
                        }
                    }
                }

                if(count % 5 == 0)
                {
                    decimal currentParcelCost = parcelDefaultValues[parcel.Size].Cost;
                    if(currentParcelCost < currentMinDiscount)
                    {
                        currentMinDiscount = currentParcelCost;
                    }
                }
                
                HandleDiscountUpdate(currentMinDiscount);
                count++;
            }
        }

        private void HandleDiscountUpdate(decimal amount)
        {
            if (amount < Int32.MaxValue)
            {
                TotalCost -= amount;
                DeliveryItems.Add(new DiscountDeliveryItem(amount));
            }
        }

        public void AddSpeedyDelivery()
        {
            SpeedyDeliveryItem speedyDeliveryItem = new SpeedyDeliveryItem(TotalCost);
            DeliveryItems.Add(speedyDeliveryItem);
            TotalCost *= 2;
        }
    }
}
