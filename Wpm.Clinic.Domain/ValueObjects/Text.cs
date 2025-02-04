namespace Wpm.Clinic.Domain.ValueObjects;

public record Text
{ 
    public string Value { get; set; }
    
    public Text(string value)
    {
        Validate(value);
        Value = value;
    }
    
    private void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));
        }

        if (value.Length > 500)
        {
            throw new ArgumentException("Text is too large", nameof(value));
        }
    }
    
    public static implicit operator Text(string vale) => new Text(vale);
}