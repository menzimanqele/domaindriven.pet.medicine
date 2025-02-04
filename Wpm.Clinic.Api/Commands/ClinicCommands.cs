using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Api.Commands;

public record StartConsultationCommand(Guid PatientId);
public record EndConsultationCommand(Guid ConsultationId);
public record SetDiagnosisCommand(Guid ConsultationId, string Diagnosis);
public record SetTreatmentCommand(Guid ConsultationId, string Treatment);
public record SetWeightCommand(Guid ConsultationId, decimal Weight);
public record AdministerDrugCommand(Guid ConsultationId, DrugId DrugId, decimal Quantity, UnitOfMeasure UnitOfMeasure);
public record RegisterVitalSignsCommand(Guid ConsultationId, IEnumerable<VitalSignsReading> VitalSignReadings);
public record VitalSignsReading(DateTime ReadingDateTime,
    decimal Temperature,
    int HeartRate,
    int RespiratoryRate);