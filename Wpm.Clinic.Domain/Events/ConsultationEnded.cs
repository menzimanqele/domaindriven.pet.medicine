using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;

public record ConsultationEnded(Guid Id, DateTime EndedAt) : IDomainEvents;