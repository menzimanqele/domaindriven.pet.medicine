using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;

public record DiagnosisUpdated(Guid DiagnosisId, string Diagnosis): IDomainEvents;