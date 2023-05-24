namespace Ticket.Domain.Contracts.Services.Commons;

public interface IGenericService<TEntity, TEntityKey> : IReadingService<TEntity, TEntityKey>, IWritingService<TEntity, TEntityKey> where TEntity : IEntity<TEntityKey>
{
}