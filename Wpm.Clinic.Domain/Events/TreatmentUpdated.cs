using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;

public record TreatmentUpdated(Guid Id,string Treatment): IDomainEvents;