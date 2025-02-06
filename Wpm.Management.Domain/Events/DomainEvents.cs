using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Events;

public class DomainEvents
{
    public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdated = new();
}