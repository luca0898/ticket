namespace Ticket.Domain.Contracts.Services.Commons;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken = default);
}
