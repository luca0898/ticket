namespace Ticket.Domain.Entities.Commons
{
    public interface IEntity<TKey>
    {
        TKey? Id { get; set; }
        bool Deleted { get; set; }
    }
}
