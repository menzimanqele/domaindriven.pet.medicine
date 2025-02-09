using System.Security.AccessControl;

namespace Wpm.SharedKernel;

public abstract class AggregateRoot : Entity
{
    public readonly List<IDomainEvents> changes = new();
    public int Version { get; private set; }

    public IReadOnlyCollection<IDomainEvents> GetChanges()
    {
        return changes.AsReadOnly();
    }

    public void ClearChanges()
    {
        changes.Clear();
    }

    //Tracking domain event
    protected void ApplyDomainEvent(IDomainEvents @event)
    {
        ChangeStateByUsingDomainEvent(@event);
        changes.Add(@event);
        Version++;
    }

    public void Load(IEnumerable<IDomainEvents> @event)
    {
        foreach (var e in @event)
        {
            ApplyDomainEvent(e);
        }
        ClearChanges();
    }
    
    protected abstract void ChangeStateByUsingDomainEvent(IDomainEvents @event);
}