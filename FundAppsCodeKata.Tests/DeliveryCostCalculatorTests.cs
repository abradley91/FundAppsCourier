using FundAppsCodeKata.DeliveryItems;
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

        [Test]
        public void Given1Parcel_WhenParcelIsSmallAndSpeedyDelivery_CostIs6()
        {
            Parcel parcel = CreateParcel(1, 1, 1);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, true);

            Assert.AreEqual(2, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(DeliveryItemType.SpeedyDelivery, result.DeliveryItems[1].Type);
            Assert.AreEqual(6, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelIsMediumAndSpeedyDelivery_CostIs16()
        {
            Parcel parcel = CreateParcel(40, 10, 10);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, true);

            Assert.AreEqual(2, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(DeliveryItemType.SpeedyDelivery, result.DeliveryItems[1].Type);
            Assert.AreEqual(16, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelIsLargeAndSpeedyDelivery_CostIs30()
        {
            Parcel parcel = CreateParcel(60, 60, 50);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, true);

            Assert.AreEqual(2, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(DeliveryItemType.SpeedyDelivery, result.DeliveryItems[1].Type);
            Assert.AreEqual(30, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelIsXLAndSpeedyDelivery_CostIs50()
        {
            Parcel parcel = CreateParcel(150, 30, 50);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, true);

            Assert.AreEqual(2, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(DeliveryItemType.SpeedyDelivery, result.DeliveryItems[1].Type);
            Assert.AreEqual(50, result.TotalCost);
        }

        [Test]
        public void GivenMultipleParcels_WhenSpeedyDelivery_ThenTotalCostIsDoubled()
        {
            Parcel smallParcel = CreateParcel(5, 5, 5);
            Parcel mediumParcel = CreateParcel(15, 15, 15);
            Parcel largeParcel = CreateParcel(55, 55, 55);
            Parcel xlParcel = CreateParcel(150, 5, 5);

            List<Parcel> parcels = new List<Parcel>() { smallParcel, mediumParcel, largeParcel, xlParcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, true);

            Assert.AreEqual(5, result.DeliveryItems.Count);
            Assert.AreEqual(102, result.TotalCost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[0].Type);
            Assert.AreEqual(3, result.DeliveryItems[0].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[1].Type);
            Assert.AreEqual(8, result.DeliveryItems[1].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[2].Type);
            Assert.AreEqual(15, result.DeliveryItems[2].Cost);
            Assert.AreEqual(DeliveryItemType.Parcel, result.DeliveryItems[3].Type);
            Assert.AreEqual(25, result.DeliveryItems[3].Cost);
            Assert.AreEqual(DeliveryItemType.SpeedyDelivery, result.DeliveryItems[4].Type);
            Assert.AreEqual(51, result.DeliveryItems[4].Cost);
        }

        [Test]
        public void Given1Parcel_WhenParcelIsSmallAndWeightIsExceededBy1_CostIs5()
        {
            Parcel parcel = CreateParcel(1, 1, 1, 2);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(5, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelIsSmallAndWeightIsExceededBy2_CostIs7()
        {
            Parcel parcel = CreateParcel(1, 1, 1, 3);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(7, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelWeightIsGreaterThan10_CostIs50()
        {
            Parcel parcel = CreateParcel(1, 1, 1, 15);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(50, result.TotalCost);
        }

        [Test]
        public void Given1Parcel_WhenParcelWeightIs55_CostIs55()
        {
            Parcel parcel = CreateParcel(1, 1, 1, 55);

            List<Parcel> parcels = new List<Parcel>() { parcel };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(1, result.DeliveryItems.Count);
            Assert.AreEqual(55, result.TotalCost);
        }

        [Test]
        public void Given4SmallParcels_When4thSmallParcelIsAdded_4thParcelShouldBeFree()
        {
            List<Parcel> parcels = new List<Parcel>() { CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1) };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(5, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[4].Type);
            Assert.AreEqual(9, result.TotalCost);
        }

        [Test]
        public void Given8SmallParcels_WhenEach4thSmallParcelIsAdded_Each4thParcelShouldBeFree()
        {
            List<Parcel> parcels = new List<Parcel>() { CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1),
            CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1)};

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(10, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[8].Type);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[9].Type);
            Assert.AreEqual(18, result.TotalCost);
        }

        [Test]
        public void Given3MediumParcels_When3rdMediumParcelIsAdded_3rdParcelShouldBeFree()
        {
            List<Parcel> parcels = new List<Parcel>() { CreateParcel(15, 15, 15), CreateParcel(15, 15, 15), CreateParcel(15, 15, 15) };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(4, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[3].Type);
            Assert.AreEqual(16, result.TotalCost);
        }

        [Test]
        public void GivenAny5Parcels_When5thMediumParcelIsAdded_5thParcelShouldBeFreeAsLongAsNoCheaperDiscountApplies()
        {
            List<Parcel> parcels = new List<Parcel>() { CreateParcel(60, 60, 60), CreateParcel(60, 60, 60), CreateParcel(60, 60, 60), CreateParcel(60, 60, 60), CreateParcel(60, 60, 60) };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(6, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[5].Type);
            Assert.AreEqual(60, result.TotalCost);
        }

        [Test]
        public void Given5Parcels_When5thParcelHas2Discounts_TheBestDiscountShouldApply()
        {
            List<Parcel> parcels = new List<Parcel>() { CreateParcel(60, 60, 60), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1), CreateParcel(1, 1, 1) };

            var result = _deliveryCostCalculator.CalculateDeliveryCosts(parcels, false);

            Assert.AreEqual(6, result.DeliveryItems.Count);
            Assert.AreEqual(DeliveryItemType.Discount, result.DeliveryItems[5].Type);
            Assert.AreEqual(24, result.TotalCost);
        }

        private Parcel CreateParcel(int x, int y, int z)
        {
            return new Parcel(x, y, z, 1);
        }

        private Parcel CreateParcel(int x, int y, int z, int weight)
        {
            return new Parcel(x, y, z, weight);
        }
    }
}
