namespace Wpm.Management.Domain;

public class Pet :Entity
{
    public Pet(Guid id, string name, int age, string color, Weight weight, SexOfPet sexOfPet)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Weight Weight { get; set; }
    public SexOfPet SexOfPet { get; set; }
    public Pet(Guid id)
    {
        
    }
}

public enum SexOfPet
{
    Male,
    Female
}