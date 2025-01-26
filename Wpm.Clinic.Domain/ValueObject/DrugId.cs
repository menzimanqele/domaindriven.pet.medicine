namespace Wpm.Clinic.Domain.ValueObject;

public record DrugId
{
    public Guid Value { get; init; }

    public DrugId(Guid value)
    {
        Value = value;
    }
}