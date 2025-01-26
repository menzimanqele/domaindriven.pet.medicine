namespace Wpm.Management.Domain.Entities;

public class Breed : Entity
{
    public Breed(Guid id,string name, WeightRange maleIdealWeight, WeightRange femaleIdealWeight)
    {
        Id = id;
        Name = name;
        MaleIdealWeight = maleIdealWeight;
        FemaleIdealWeight = femaleIdealWeight;
    }

    public string Name { get; set; }
    public WeightRange MaleIdealWeight { get; set; }
    public WeightRange FemaleIdealWeight { get; set; }
    
}

public record class WeightRange
{
    public decimal From { get; init; }
    public decimal To { get; init; }
   

    public WeightRange(decimal from, decimal to)
    {
        From = from;
        To = to;
    }
}