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
            Weight = weight;
            
            ParcelSizeCalculator parcelSizeCalculator = new ParcelSizeCalculator();
            Size = parcelSizeCalculator.CalculateParcelSize(x, y, z, weight);
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public ParcelSize Size { get; private set; }
        public int Weight { get; private set; }
    }

    public enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL,
        Heavy
    }
}
