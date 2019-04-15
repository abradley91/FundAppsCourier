using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata
{
    public class ParcelSizeCalculator
    {
        public ParcelSize CalculateParcelSize(int x, int y, int z, int weight)
        {
            if (ParcelIsHeavy(weight))
            {
                return ParcelSize.Heavy;
            }
            else if (ParcelIsSmall(x, y, z))
            {
                return ParcelSize.Small;
            }
            else if (ParcelIsMedium(x, y, z))
            {
                return ParcelSize.Medium;
            }
            else if (ParcelIsLarge(x, y, z))
            {
                return ParcelSize.Large;
            }
            else
            {
                return ParcelSize.XL;
            }
        }

        private bool ParcelIsHeavy(int weight)
        {
            return weight > 10;
        }

        private bool ParcelIsSmall(int x, int y, int z)
        {
            return x < 10 && y < 10 && z < 10;
        }

        private bool ParcelIsMedium(int x, int y, int z)
        {
            return x < 50 && y < 50 && z < 50;
        }

        private bool ParcelIsLarge(int x, int y, int z)
        {
            return x < 100 && y < 100 && z < 100;
        }
    }
}
