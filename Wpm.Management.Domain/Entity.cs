namespace Wpm.Management.Domain;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public static bool operator == (Entity? left, Entity? right)
    {
        return left?.Id == right?.Id;
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return left?.Id != right?.Id;
    }
}