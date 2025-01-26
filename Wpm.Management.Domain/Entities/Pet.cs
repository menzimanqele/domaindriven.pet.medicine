using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public class Pet :Entity
{
    public Pet(Guid id, string name, int age, string color, Weight weight, SexOfPet sexOfPet, BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
        breedId = breedId;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Weight Weight { get; set; }
    public SexOfPet SexOfPet { get; set; }
    public BreedId BreedId { get; set; }
    public Pet(Guid id)
    {
        
    }
}

public enum SexOfPet
{
    Male,
    Female
}