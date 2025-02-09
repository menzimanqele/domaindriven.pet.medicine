using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;

public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvents;