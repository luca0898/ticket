namespace Ticket.Domain.Entities.Commons;

public abstract class Entity<T> : Entity, IEntity<T>
{
    public T? Id { get; set; }

    public Entity()
    {
        
    }

    public Entity(T id, bool deleted) : base(deleted)
    {
        Id = id;
    }
}
public abstract class Entity
{
    public bool Deleted { get; set; }

    public Entity()
    {
        
    }

    public Entity(bool deleted)
    {
        Deleted = deleted;
    }
}