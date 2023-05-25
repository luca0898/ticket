using Microsoft.EntityFrameworkCore;
using Ticket.Repositories.Databases.SqlRepository.Contexts;

namespace Ticket.Repositories.Databases.SqlMigrations.Contexts;

public class MigrationsDbContext : ApplicationDbContext
{
    public MigrationsDbContext() : base(new DbContextOptions<ApplicationDbContext>())
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=mysecretpassword;");
    }
}
