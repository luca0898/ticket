using Ticket.Domain.Contracts.Repositories.Commons;
using Ticket.Domain.Contracts.Services.Commons;
using System.Linq.Expressions;

namespace Ticket.Services.Implementations.Commons;

public abstract class GenericService<TEntity, TEntityKey> : IGenericService<TEntity, TEntityKey> where TEntity : IEntity<TEntityKey>
{
    protected readonly IGenericRepository<TEntity, TEntityKey> _repository;

    public GenericService(IGenericRepository<TEntity, TEntityKey> repository)
    {
        _repository = repository;
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _repository.CountAsync(filter, cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await _repository.CreateAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return await _repository.CreateAsync(entities, cancellationToken);
    }

    public async Task DeleteAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(id, cancellationToken);
    }

    public async Task<bool> ExistAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        return await _repository.ExistAsync(id, cancellationToken);
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _repository.ExistAsync(filter, cancellationToken);
    }

    public async Task<TEntity?> FindByIdAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        return await _repository.FindByIdAsync(id, cancellationToken);
    }

    public async Task HardDeleteAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        await _repository.HardDeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, object> orderBy, bool ascending, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        return await _repository.ListAsync(orderBy, ascending, page, pageSize, cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntityKey id, TEntity entity, CancellationToken cancellationToken = default)
    {
        return await _repository.UpdateAsync(id, entity, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return await _repository.UpdateAsync(entities, cancellationToken);
    }
}
