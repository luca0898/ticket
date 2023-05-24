using Ticket.Domain.Contracts.Repositories.Commons;
using Ticket.Domain.Entities;

namespace Ticket.Domain.Contracts.Repositories;

public interface IMovieRepository : IGenericRepository<Movie, string>
{
}
