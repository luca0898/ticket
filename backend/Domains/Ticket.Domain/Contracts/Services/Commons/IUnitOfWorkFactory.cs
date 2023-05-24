namespace Ticket.Domain.Contracts.Services.Commons;

public interface IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork
{
    IUnitOfWork Create();
}