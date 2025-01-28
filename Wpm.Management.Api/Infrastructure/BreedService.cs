using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Interfaces;

namespace Wpm.Management.Api.Infrastructure;


public class BreedService : IBreedService
{
    public readonly List<Breed> Breeds =
    [
        new Breed( Guid.Parse("1D8F64CF-39F8-4B9B-A6A1-BB28C1C778BA"), "Beagle", new WeightRange(10m, 20m), new WeightRange(11m, 18m)),
        new Breed(Guid.Parse("E8BF7AAE-85C5-4203-8DB0-CB68F18F9864"), "Staffordshire Terrier", new WeightRange(20m, 50m), new WeightRange(24m, 34m)),
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
