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
        var pet1 = new Pet(id, "Giann", 13,"Breed", new Weight(20.9m),SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Niaan", 13,"Breed", new Weight(20.9m),SexOfPet.Male,breedId);
        Assert.True(pet1.Equals(pet2));
    }
    
    [Fact]
    public void Pet_Should_Be_Equal_Using_Operators()
    {
        var breedService = new FakeBreedService();
        var id = breedService.Breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        var pet1 = new Pet(id, "Giann", 13,"Breed", new Weight(20.9m),SexOfPet.Male,breedId);
        var pet2 = new Pet(id, "Niaan", 13,"Breed", new Weight(20.9m),SexOfPet.Male,breedId);
        Assert.True(pet1 == pet2);
    }
    
    /*[Fact]
    public void Pet_Should_Not_Be_Equal_Using_Operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var pet1 = new Pet(id1, "Giann", 13,"Breed", new Weight(20.9m),SexOfPet.Male);
        var pet2 = new Pet(id2, "Niaan", 13,"Breed", new Weight(20.9m),SexOfPet.Male);
        Assert.True(pet1 != pet2);
    }
    */
    
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
        var weightRange1 = new WeightRange(20.9m,10.6m);
        var weightRange2 = new WeightRange(20.9m,10.6m);
        
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
}