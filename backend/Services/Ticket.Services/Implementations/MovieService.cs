using Ticket.Domain.Contracts.Repositories;
using Ticket.Domain.Contracts.Services;
using Ticket.Domain.Entities;
using Ticket.Services.Implementations.Commons;

namespace Ticket.Services.Implementations;

public class MovieService : GenericService<Movie, string>, IMovieService
{
    public MovieService(
        IMovieRepository repository)
        : base(repository)
    {
    }
}
