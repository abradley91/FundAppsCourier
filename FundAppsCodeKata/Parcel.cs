using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public class Parcel
    {
        public Parcel(int x, int y, int z, int weight)
        {
            X = x;
            Y = y;
            Z = z;
            Size = CalculateParcelSize();
            Weight = weight;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public ParcelSize Size { get; private set; }
        public int Weight { get; private set; }

        private ParcelSize CalculateParcelSize()
        {
            if (ParcelIsSmall())
            {
                return ParcelSize.Small;
            }
            else if (ParcelIsMedium())
            {
                return ParcelSize.Medium;
            }
            else if (ParcelIsLarge())
            {
                return ParcelSize.Large;
            }
            else
            {
                return ParcelSize.XL;
            }
        }

        private bool ParcelIsSmall()
        {
            return X < 10 && Y < 10 && Z < 10;
        }

        private bool ParcelIsMedium()
        {
            return X < 50 && Y < 50 && Z < 50;
        }

        private bool ParcelIsLarge()
        {
            return X < 100 && Y < 100 && Z < 100;
        }
    }

    public enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL
    }
}
