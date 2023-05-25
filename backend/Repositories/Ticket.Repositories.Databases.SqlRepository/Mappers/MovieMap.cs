using Ticket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticket.Repositories.Databases.SqlRepository.Mappers;

public class MovieMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        //builder
        //    .Property(prop => prop.Id)
        //    .HasColumnType("uuid")
        //    .HasDefaultValueSql("uuid_generate_v4()")
        //    .IsRequired();

        builder
            .Property(prop => prop.Deleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(prop => prop.Title)
            .IsRequired();

        builder
            .Property(prop => prop.Description)
            .IsRequired();

        builder
            .Property(prop => prop.Duration)
            .HasDefaultValue(new TimeSpan())
            .IsRequired();

        builder
            .Property(prop => prop.BannerSrc)
            .IsRequired();
    }
}
