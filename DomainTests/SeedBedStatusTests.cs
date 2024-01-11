﻿using Bogus;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using FluentAssertions;
using Moq;
using System.Reflection;

namespace DomainTests;

public class SeedBedStatusTests
{
    [Fact]
    public void GetGreenHouses_ShouldReturnAllGreenHouses()
    {
        var collection = GenerateGreenHouses(5);
        Mock<IGreenHouseRepository> greenHouseRepository =
            new Mock<IGreenHouseRepository>();
        greenHouseRepository.Setup(x => x.GetAll()).Returns(collection);

        SeedBedStatus status = new SeedBedStatus(
            greenHouseRepo: greenHouseRepository.Object);

        MethodInfo methodInfo = typeof(SeedBedStatus)
            .GetMethod("GetGreenHouses",
            BindingFlags.NonPublic | BindingFlags.Instance);

        List<GreenHouseModel> actual =
            (List<GreenHouseModel>)methodInfo.Invoke(status, null);

        actual.Should().HaveCount(5);
        actual[0].Should().BeOfType(typeof(GreenHouseModel));
    }

    public IEnumerable<GreenHouse> GenerateGreenHouses(int count)
    {
        Randomizer.Seed = new Random(123);
        var fakeRecord = GetGreenHouseModelFaker();

        return fakeRecord.Generate(count);
    }
    //NEXT  - Round the decimal values to 2 precision digits.
    private Faker<GreenHouse> GetGreenHouseModelFaker()
    {
        byte index = 1;
        //return new Faker<GreenHouse>()
        //    .RuleFor(x => x.Id, f => index++)
        //    .RuleFor(x => x.Name, f => f.Commerce.Department())
        //    .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
        //    .RuleFor(x => x.Width, f => f.Random.Decimal(10, 25))
        //    .RuleFor(x => x.Length, f => f.Random.Decimal(20, 60))
        //    .RuleFor(x => x.GreenHouseArea, (f, x) => x.Width * x.Length)
        //    .RuleFor(x => x.SeedTrayArea,
        //        (f, x) => x.GreenHouseArea * f.Random.Decimal((decimal)0.7, (decimal)0.9))
        //    .RuleFor(x => x.AmountOfBlocks, f => f.Random.Byte(1, 4))
        //    .RuleFor(x => x.Active, f => f.Random.Bool());
        return new Faker<GreenHouse>()
            .RuleFor(x => x.Name, f => $"Casa {index}")
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Width, f => f.Random.Short(6, 20))
            .RuleFor(x => x.Length, f => f.Random.Short(50, 100))
            .RuleFor(x => x.GreenHouseArea, (f, u) => u.Width * u.Length)
            .RuleFor(x => x.SeedTrayArea, f => f.Random.Short(200, 1500))
            .RuleFor(x => x.AmountOfBlocks, f => f.Random.Byte(2, 4))
            .RuleFor(x => x.Active, f => f.Random.Bool());
    }

    [Fact]
    public void GetSeedTrays_ShouldReturnAllSeedTrays()
    {
        var collection = GenerateSeedTrays(5);
        Mock<ISeedTrayRepository> seedTrayRepository = new Mock<ISeedTrayRepository>();
        seedTrayRepository.Setup(x => x.GetAll()).Returns(collection);

        SeedBedStatus status = new SeedBedStatus(
            seedTrayRepo: seedTrayRepository.Object);

        MethodInfo methodInfo = typeof(SeedBedStatus)
            .GetMethod("GetSeedTrays",
            BindingFlags.NonPublic | BindingFlags.Instance);

        List<SeedTrayModel> actual = (List<SeedTrayModel>)methodInfo.Invoke(status, null);

        actual.Should().HaveCount(5);
        actual[0].Should().BeOfType(typeof(SeedTrayModel));
    }

    public IEnumerable<SeedTray> GenerateSeedTrays(int count)
    {
        Randomizer.Seed = new Random(123);
        var fakeRecord = GetSeedTrayFaker();

        return fakeRecord.Generate(count);
    }

    private Faker<SeedTray> GetSeedTrayFaker()
    {
        byte index = 1;
        byte preference = 1;
        return new Faker<SeedTray>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.AlveolusLength, f => f.Random.Byte(10, 20))
            .RuleFor(x => x.AlveolusWidth, f => f.Random.Byte(8, 14))
            .RuleFor(x => x.TotalAlveolus, (f, u) => Convert.ToInt16(u.AlveolusLength * u.AlveolusWidth))
            .RuleFor(x => x.Name, (f, u) => $"Badejas de {u.TotalAlveolus}")
            .RuleFor(x => x.TrayLength, f => Convert.ToDecimal(f.Random.Double(0.6, 1.0)))
            .RuleFor(x => x.TrayWidth, f => Convert.ToDecimal(f.Random.Double(0.3, 0.5)))
            .RuleFor(x => x.TrayArea, (f, u) => u.TrayLength * u.TrayWidth)
            .RuleFor(x => x.LogicalTrayArea, (f, u) => u.TrayArea * f.Random.Decimal(1, 1.2M))
            .RuleFor(x => x.TotalAmount, f => f.Random.Short(300, 1500))
            .RuleFor(x => x.Material, f => f.Vehicle.Type())
            .RuleFor(x => x.Preference, f => preference++)
            .RuleFor(x => x.Active, f => f.Random.Bool());
    }

    [Fact]
    public void GetMajorityDataOfOrders_ShouldRetrieveTheOrders()
    {
        var collection = GenerateOrders(200);

        DateOnly date = new DateOnly(2023, 7, 1);

        var filteredCollection = collection
            .Where(x => x.RealSowDate > date || x.RealSowDate == null);

        Mock<IOrderProcessor> orderProcessor = new Mock<IOrderProcessor>();

        orderProcessor.Setup(x => x.GetOrdersFromADateOn(It.IsAny<DateOnly>()))
            .Returns(filteredCollection);

        SeedBedStatus status = new SeedBedStatus(
            orderProcessor: orderProcessor.Object);

        MethodInfo methodInfo = typeof(SeedBedStatus)
            .GetMethod("GetMajorityDataOfOrders",
            BindingFlags.NonPublic | BindingFlags.Instance);

        LinkedList<OrderModel> actual =
            (LinkedList<OrderModel>)methodInfo.Invoke(status, null);

        int count = filteredCollection.Count();
        actual.Count.Should().Be(count);
        actual.First.Should().BeOfType(typeof(LinkedListNode<OrderModel>));

    }

    public IEnumerable<Order> GenerateOrders(int count)
    {
        Randomizer.Seed = new Random(123);
        var fakeRecord = GetOrderFaker();

        return fakeRecord.Generate(count);
    }

    private Faker<Order> GetOrderFaker()
    {
        int[] productionDays = new[] { 30, 45 };
        short index = 1;
        return new Faker<Order>()
            .RuleFor(x => x.Id, f => index++)
            .RuleFor(x => x.ClientId, f => f.Random.Short(1, 300))
            .RuleFor(x => x.ProductId, f => f.Random.Byte(1, 60))
            .RuleFor(x => x.AmountOfWishedSeedlings, f => f.Random.Int(20000, 80000))
            .RuleFor(x => x.AmountOfAlgorithmSeedlings, (f, u) => Convert.ToInt32(u.AmountOfWishedSeedlings * 1.2))
            .RuleFor(x => x.WishDate, f =>
                DateOnly.FromDateTime(
                    f.Date.Between(new DateTime(2023, 1, 1),
                        new DateTime(2023, 12, 31))
                    )
                )
            .RuleFor(x => x.DateOfRequest, (f, u) => u.WishDate.AddDays(-f.Random.Int(90, 180)))
            .RuleFor(x => x.EstimateSowDate, (f, u) => u.WishDate.AddDays(-f.PickRandom(productionDays)))
            .RuleFor(x => x.EstimateDeliveryDate, (f, u) => u.WishDate)
            .RuleFor(x => x.RealSowDate, (f, u) =>
                f.Random.Bool() ? u.EstimateSowDate : null
                )
            .RuleFor(x => x.RealDeliveryDate, (f, u) => u.EstimateDeliveryDate)
            .RuleFor(x => x.Complete, f => f.Random.Bool())
            .RuleFor(x => x.Client, f => new Client())
            .RuleFor(x => x.Product, f => new Product()
            { Specie = new Species() });
    }
}
