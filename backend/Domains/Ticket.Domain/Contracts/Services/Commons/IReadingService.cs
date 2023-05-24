using Ticket.Domain.Constants;
using System.Linq.Expressions;

namespace Ticket.Domain.Contracts.Services.Commons;

public interface IReadingService<TEntity, TEntityKey>
{
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<bool> ExistAsync(TEntityKey id, CancellationToken cancellationToken = default);
    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity?> FindByIdAsync(TEntityKey id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, object> orderBy, bool ascending, int page = 1, int pageSize = PageSize.Size, CancellationToken cancellationToken = default);
}
