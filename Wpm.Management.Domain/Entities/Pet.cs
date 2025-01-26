using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public class Pet :Entity
{
    public Pet(Guid id, string name, int age, string color, SexOfPet sexOfPet, BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Weight Weight { get;private set; }
    public SexOfPet SexOfPet { get; set; }
    public BreedId BreedId { get; set; }
    public WeightClass WeightClass { get; private set; }    
    public Pet(Guid id)
    {
        
    }

    public void SetWeightClass(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Value);

        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
            SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
            _ => throw new NotImplementedException()
        };

        WeightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClass.Underweight,
            _ when Weight.Value > to => WeightClass.Overweight,
            _ => WeightClass.Ideal
        };


    }

    public void SetWeight(Weight weight, IBreedService breedService)
    {
        Weight = weight;
        SetWeightClass(breedService);
    }
}

public enum SexOfPet
{
    Male,
    Female
}

public enum WeightClass
{
    Unknown,
    Ideal,
    Underweight,
    Overweight
}