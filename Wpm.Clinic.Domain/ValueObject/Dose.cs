namespace Wpm.Clinic.Domain.ValueObject;

public class Dose
{

    public decimal Quantity { get; set; }
    public UnitOfMeasure Unit { get; set; }

    public Dose(decimal quantity, UnitOfMeasure unit)
    {
        Quantity = quantity;
        Unit = unit;
    }
}

public enum UnitOfMeasure
{
    mq,
    ml,
    tablet
}