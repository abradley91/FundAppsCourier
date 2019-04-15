using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FundAppsCodeKata.Tests
{
    [TestFixture]
    public class DeliveryCostCalculatorTests
    {
        private DeliveryCostCalculator _deliveryCostCalculator;

        [SetUp]
        public void SetUp()
        {
            _deliveryCostCalculator = new DeliveryCostCalculator();
        }

        [Test]
        public void Given1Parcel_WhenAllDimensionsLessThan10_CostIs3()
        {
            Parcel parcel = CreateParcel(1, 1, 1);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(3, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenAllDimensionsLessThan50_CostIs8()
        {
            Parcel parcel = CreateParcel(40, 10, 20);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(8, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenAllDimensionsLessThan100_CostIs15()
        {
            Parcel parcel = CreateParcel(60, 40, 5);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(15, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenAnyDimensionsGreater100_CostIs25()
        {
            Parcel parcel = CreateParcel(150, 40, 5);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(25, result.TotalCost);
        }

        [Test]
        public void GivenMultipleParcels_AllDeliveryItemsShouldHaveCorrectSizeAndCost()
        {
            Parcel smallParcel = CreateParcel(5, 5, 5);
            Parcel mediumParcel = CreateParcel(15, 15, 15);
            Parcel largeParcel = CreateParcel(55, 55, 55);
            Parcel xlParcel = CreateParcel(150, 5, 5);

            List<Parcel> parcels = new List<Parcel>() { smallParcel, mediumParcel, largeParcel, xlParcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels);

            Assert.AreEqual(4, result.DeliveryItems.Count);
            Assert.AreEqual(51, result.TotalCost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(3, result.DeliveryItems[0].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[1].Type);
            Assert.AreEqual(8, result.DeliveryItems[1].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[2].Type);
            Assert.AreEqual(15, result.DeliveryItems[2].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[3].Type);
            Assert.AreEqual(25, result.DeliveryItems[3].Cost);
        }

        private Parcel CreateParcel(int x, int y, int z)
        {
            return new Parcel(x, y, z);
        }
    }
}
