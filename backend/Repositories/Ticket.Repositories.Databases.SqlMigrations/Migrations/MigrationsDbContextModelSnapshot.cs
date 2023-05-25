﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ticket.Repositories.Databases.SqlMigrations.Contexts;

#nullable disable

namespace Ticket.Repositories.Databases.SqlMigrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    partial class MigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Ticket")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ticket.Domain.Entities.Movie", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BannerSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("interval")
                        .HasDefaultValue(new TimeSpan(0, 0, 0, 0, 0));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movie", "Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}