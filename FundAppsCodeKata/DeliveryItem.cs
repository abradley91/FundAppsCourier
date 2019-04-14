using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL
    }

    public class DeliveryItem
    {
        public ParcelSize Size { get; set; }
        public decimal Cost { get; set; }

        public DeliveryItem(Parcel parcel)
        {
            SetSize(parcel);
        }

        private void SetSize(Parcel parcel)
        {
            if (ParcelIsSmall(parcel))
            {
                Size = ParcelSize.Small;
                Cost = 3;
            }
            else if (ParcelIsMedium(parcel))
            {
                Size = ParcelSize.Medium;
                Cost = 8;
            }
            else if (ParcelIsLarge(parcel))
            {
                Size = ParcelSize.Large;
                Cost = 15;
            }
            else
            {
                Size = ParcelSize.XL;
                Cost = 25;
            }
        }

        private static bool ParcelIsSmall(Parcel parcel)
        {
            return parcel.X < 10 && parcel.Y < 10 && parcel.Z < 10;
        }

        private static bool ParcelIsMedium(Parcel parcel)
        {
            return parcel.X < 50 && parcel.Y < 50 && parcel.Z < 50;
        }

        private static bool ParcelIsLarge(Parcel parcel)
        {
            return parcel.X < 100 && parcel.Y < 100 && parcel.Z < 100;
        }
    }
}
