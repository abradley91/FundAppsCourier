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
            Delivery delivery = new Delivery();

            foreach(Parcel parcel in parcels)
            {
                delivery.AddParcelToDelivery(parcel);
            }

            return delivery;
        }
    }
}
