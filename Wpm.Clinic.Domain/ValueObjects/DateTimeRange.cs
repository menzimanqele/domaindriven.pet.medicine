namespace Wpm.Clinic.Domain.ValueObjects;

public record DateTimeRange
{
    public DateTimeRange(DateTime startedAt, DateTime finishedAt)
    {
        ValidationRange(startedAt, finishedAt);
        StartedAt = startedAt;
        EndedAt = finishedAt;
    }

    public DateTimeRange(DateTime startedAt) 
    {
        StartedAt = startedAt;
    }
    public DateTime StartedAt { get; init; }
    public DateTime? EndedAt { get; set; }

    public void ValidationRange(DateTime startedAt, DateTime finishedAt)
    {
        if (startedAt > finishedAt)
        {
            throw new InvalidOperationException("invalid datetime range");
        }
    }

    public static implicit operator DateTimeRange(DateTime dateTime)
    {
        return new DateTimeRange(dateTime);
    }
    
    public string Duration
    {
        get
        {
            return EndedAt == default ? "Pending" : $"{(EndedAt.Value - StartedAt).Hours} hours, {(EndedAt.Value - StartedAt).Minutes} minutes, {(EndedAt.Value - StartedAt).Seconds} seconds";
        }
    }

    public void End(DateTime endAt)
    {
        EndedAt = endAt;
    }
}