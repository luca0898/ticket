using Ticket.Repositories.Databases.SqlRepository.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ticket.Repositories.Databases.SqlRepository.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext Context => this;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Claim>();
        modelBuilder.HasDefaultSchema("Ticket");
        modelBuilder.HasPostgresExtension("uuid-ossp");

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MovieMap());
    }
}
