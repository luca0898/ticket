namespace Ticket.Domain.Contracts.Repositories.Commons;

public interface IGenericRepository<TEntity, TEntityKey> : IReadingRepository<TEntity, TEntityKey>, IWritingRepository<TEntity, TEntityKey> where TEntity : IEntity<TEntityKey>
{
}
