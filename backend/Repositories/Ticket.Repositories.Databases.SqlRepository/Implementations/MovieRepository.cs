using Ticket.Domain.Contracts.Repositories;
using Ticket.Domain.Entities;
using Ticket.Repositories.Databases.SqlRepository.Implementations.Commons;

namespace Ticket.Repositories.Databases.SqlRepository.Implementations;

public class MovieRepository : GenericRepository<Movie, string>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
