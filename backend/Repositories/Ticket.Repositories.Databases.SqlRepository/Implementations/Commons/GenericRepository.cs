using Ticket.Domain.Constants;
using Ticket.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ticket.Repositories.Databases.SqlRepository.Implementations.Commons;

public abstract class GenericRepository<TEntity, TEntityKey> : IReadingRepository<TEntity, TEntityKey>, IWritingRepository<TEntity, TEntityKey> where TEntity : Entity<TEntityKey>
{
    private readonly ApplicationDbContext _dbContext;
    protected DbSet<TEntity> _entities;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<TEntity>();
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _entities.Where(filter).CountAsync(cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _entities.AddAsync(entity, cancellationToken);

        return result.Entity; // todo: testar se o método sobreescreve o parametro entity
    }

    public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _entities.AddRangeAsync(entities, cancellationToken);

        return entities; // todo: testar se o método sobreescreve o parametro entity
    }

    public async Task DeleteAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id));

        var entity = await _entities.FindAsync(new object[] { id }, cancellationToken);

        _ = entity ?? throw new TicketApplicationException("Registry not found", Domain.Enums.TicketApplicationExceptionTypes.NotFound);

        entity.Deleted = true;

        _entities.Update(entity);
    }

    public async Task<bool> ExistAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id));

        return await _entities.FindAsync(new object[] { id }, cancellationToken) != default;
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _entities.Where(filter).FirstOrDefaultAsync(cancellationToken) != default;
    }

    public async Task<TEntity?> FindByIdAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id));

        return await _entities.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task HardDeleteAsync(TEntityKey id, CancellationToken cancellationToken = default)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id));

        var entity = await _entities.FindAsync(new object[] { id }, cancellationToken);

        _ = entity ?? throw new TicketApplicationException("Registry not found", Domain.Enums.TicketApplicationExceptionTypes.NotFound);

        _entities.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, object> orderBy, bool ascending, int page = 1, int pageSize = PageSize.Size, CancellationToken cancellationToken = default)
    {
        var query = _entities.AsQueryable().Where(entity => !entity.Deleted);

        query = ascending
            ? query.OrderBy(orderBy).AsQueryable()
            : query.OrderByDescending(orderBy).AsQueryable();

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync(cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntityKey id, TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id));

        var entityToUpdate = await _entities.FindAsync(new object[] { id }, cancellationToken);

        _ = entityToUpdate ?? throw new TicketApplicationException("Entity not found", Domain.Enums.TicketApplicationExceptionTypes.NotFound);

        _entities.Update(entity);

        return entity;
    }

    public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        for (int page = 1; page <= (int)Math.Ceiling((double)entities.Count() / PageSize.Size); page++)
        {
            var query = await _entities
                .AsQueryable()
                .Where(entity => !entity.Deleted)
                .Skip((page - 1) * PageSize.Size)
                .Take(PageSize.Size)
                .ToListAsync(cancellationToken);

            query.ForEach(entry =>
            {
                TEntity? entity = entities.FirstOrDefault(e => e.Id?.Equals(entry.Id) ?? false);

                if (entity != default) _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return entities;
    }
}
