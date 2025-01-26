using Wpm.Clinic.Domain.ValueObject;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class Consultation : AggregateRoot
{
    public DateTime StartedAt { get; init; }
    public DateTime EndedAt { get; private set; }   
    public Text Diagnosis { get; private set; }
    public Text Treatment { get; private set; }
    public PatientId PatientId { get; init; }
    public Weight CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; set; }

    public Consultation(PatientId patientId)
    {
        Id = Guid.NewGuid();
        this.PatientId = patientId;
        Status = ConsultationStatus.Open;
        StartedAt = DateTime.Now;
    }

    public void End()
    {
        ValidateConsultationStatus();

        if (Diagnosis == null || Treatment == null || CurrentWeight == null)
        {
            throw new InvalidOperationException("The consultation do not have any diagnosis or treatments.");
        }
        Status = ConsultationStatus.Closed;
        EndedAt = DateTime.Now;
    }
    

    public void SetWeight(Weight weight)
    {
        this.CurrentWeight = weight;
    }

    public void SetTreatment(Text diagnosis)
    {
        ValidateConsultationStatus();
        this.Treatment = diagnosis;
    }
    
    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        this.Diagnosis = diagnosis;
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Closed)
        {
            throw new InvalidOperationException("Consultation is closed");  
        }
    }
    
}

public enum ConsultationStatus
{
    Open,
    Closed
}