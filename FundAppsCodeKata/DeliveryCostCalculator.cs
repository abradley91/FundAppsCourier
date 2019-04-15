using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public class DeliveryCostCalculator
    {
        public Delivery CalculateDeliveryCosts(IEnumerable<Parcel> parcels)
        {
            return CreateDelivery(parcels, false);
        }
        public Delivery CalculateDeliveryCosts(IEnumerable<Parcel> parcels, bool speedyDelivery)
        {
            return CreateDelivery(parcels, speedyDelivery);
        }

        private Delivery CreateDelivery(IEnumerable<Parcel> parcels, bool speedyDelivery)
        {
            Delivery delivery = new Delivery();

            foreach (Parcel parcel in parcels)
            {
                delivery.AddParcelToDelivery(parcel);
            }

            if (speedyDelivery)
            {
                delivery.AddSpeedyDelivery();
            }

            return delivery;
        }
    }
}
