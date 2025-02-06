namespace Wpm.SharedKernel;

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
    
    public static implicit operator Weight(decimal value) => new Weight(value);
    
    public static implicit operator decimal(Weight weight) => weight.Value;
}