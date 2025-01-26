using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Interfaces;

public interface IBreedService
{
    Breed? GetBreed(Guid id);
}

public class FakeBreedService : IBreedService
{
    public readonly List<Breed> Breeds =
    [
        new Breed(Guid.NewGuid(), "Beagle", new WeightRange(10m, 20m), new WeightRange(11m, 18m)),
        new Breed(Guid.NewGuid(), "Staffordshire Terrier", new WeightRange(208m, 20m), new WeightRange(11m, 18m)),
    ];
    
    
    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Breed id is not valid");
        }
        var breed = Breeds.SingleOrDefault(b => b.Id == id);
        return breed ?? throw new ArgumentException("Breed not found");
    }
}