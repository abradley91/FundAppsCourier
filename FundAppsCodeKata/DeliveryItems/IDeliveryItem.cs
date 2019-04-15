using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppsCodeKata.DeliveryItems
{
    public enum DeliveryItemType
    {
        Parcel,
        SpeedyDelivery,
        Discount
    }

    public interface IDeliveryItem
    {
        DeliveryItemType Type { get; set; }
        decimal Cost { get; set; }
    }
}
