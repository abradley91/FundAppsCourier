using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    //Created this class as I imagine these kinds of values would be kept in a database
    public static class ParcelRepository
    {
        public static Dictionary<ParcelSize, ParcelDefaultValues> GetParcelDefaultValues()
        {
            return new Dictionary<ParcelSize, ParcelDefaultValues>() {
                { ParcelSize.Small, new ParcelDefaultValues(3, 1) },
                { ParcelSize.Medium, new ParcelDefaultValues(8, 3) },
                { ParcelSize.Large, new ParcelDefaultValues(15, 6) },
                { ParcelSize.XL, new ParcelDefaultValues(25, 10) },
                { ParcelSize.Heavy, new ParcelDefaultValues(50, 50) }
            };
        }
    }

    public struct ParcelDefaultValues
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
