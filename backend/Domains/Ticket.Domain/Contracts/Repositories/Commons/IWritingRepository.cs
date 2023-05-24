namespace Ticket.Domain.Contracts.Repositories.Commons;

public interface IWritingRepository<TEntity, TEntityKey> where TEntity : IEntity<TEntityKey>
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntityKey id, CancellationToken cancellationToken = default);
    Task HardDeleteAsync(TEntityKey id, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntityKey id, TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
