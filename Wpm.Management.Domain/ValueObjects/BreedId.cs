using Wpm.Management.Domain.Interfaces;

namespace Wpm.Management.Domain.ValueObjects;

public record BreedId
{
    private readonly IBreedService _breedService;
    public Guid Value { get; set; }

    public BreedId(Guid value, IBreedService breedService)
    {
        _breedService = breedService;
        ValidateBreed(value);
        Value = value;
    }

    private void ValidateBreed(Guid value)
    {
        if (_breedService.GetBreed(value) is null)
        {
            throw new ArgumentException($"Breed with id {value} cannot be found");
        }
    }
}