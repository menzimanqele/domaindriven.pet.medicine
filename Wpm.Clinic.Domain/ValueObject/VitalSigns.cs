namespace Wpm.Clinic.Domain.ValueObject;

public record VitalSigns
{
    public VitalSigns(decimal temparature, int heartRate, int respiratoryRate)
    {
        ReadingDateTime = DateTime.UtcNow;
        Temparature = temparature;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }

    public DateTime ReadingDateTime { get; init; }
    public decimal Temparature { get; set; }
    public int HeartRate { get; set; }
    public int RespiratoryRate { get; set; }
}