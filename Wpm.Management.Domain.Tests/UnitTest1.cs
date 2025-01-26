using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_Should_Be_Equal()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet1 = new Pet(id, "Giann", 13, "Breed", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Niaan", 13, "Breed", SexOfPet.Male, breedId);
        /*pet1.SetWeight(new Weight(20.9m),breedService);
        pet2.SetWeight(new Weight(20.9m),breedService);*/
        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_Should_Be_Equal_Using_Operators()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet1 = new Pet(id, "Giann", 13, "Breed", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Niaan", 13, "Breed", SexOfPet.Male, breedId);
        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_Should_Not_Be_Equal_Using_Operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.Breeds[0].Id, breedService);
        var pet1 = new Pet(id1, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        var pet2 = new Pet(id2, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        Assert.True(pet1 != pet2);
    }
    

    [Fact]
    public void Weight_Should_Be_Equal()
    {
        var weight1 = new Weight(20.9m);
        var weight2 = new Weight(20.9m);

        Assert.True(weight1 == weight2);
    }

    [Fact]
    public void WeightRange_Should_Be_Equal()
    {
        var weightRange1 = new WeightRange(20.9m, 10.6m);
        var weightRange2 = new WeightRange(20.9m, 10.6m);

        Assert.True(weightRange1 == weightRange2);
    }

    [Fact]
    public void Breed_Should_Be_Valid()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        Assert.NotNull(breedId);
    }

    [Fact]
    public void Breed_Should_Not_BeValid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentException>(() =>
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_Should_Be_Ideal()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet = new Pet(id, "Giann", 13, "Breed", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(10.9m), breedService);
        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_Should_Be_UnderWeight()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet = new Pet(id, "Giann", 13, "Breed", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(8), breedService);
        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }

    [Fact]
    public void WeightClass_Should_Be_OverWeight()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet = new Pet(id, "Giann", 13, "Breed", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(25), breedService);
        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }
}