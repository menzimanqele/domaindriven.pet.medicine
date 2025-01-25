namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_Should_Be_Equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(){Id = id};
        var pet2 = new Pet(){Id = id};
        Assert.True(pet1.Equals(pet2));
    }
    
    [Fact]
    public void Pet_Should_Be_Equal_Using_Operators()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(){Id = id};
        var pet2 = new Pet(){Id = id};
        Assert.True(pet1 == pet2);
    }
    
    [Fact]
    public void Pet_Should_Not_Be_Equal_Using_Operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var pet1 = new Pet(){Id = id1};
        var pet2 = new Pet(){Id = id2};
        Assert.True(pet1 != pet2);
    }
}