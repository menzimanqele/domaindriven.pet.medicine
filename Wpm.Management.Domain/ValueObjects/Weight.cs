namespace Wpm.Management.Domain.ValueObjects;

public record Weight
{
    public decimal Value { get; init; }

    public Weight(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Weight cannot be negative", nameof(value));
        }
        Value = value;
    }
}