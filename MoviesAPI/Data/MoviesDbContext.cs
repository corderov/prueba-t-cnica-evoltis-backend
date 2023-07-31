using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using static Dapper.SqlMapper;

namespace MoviesAPI.Data;

public partial class MoviesDbContext : DbContext
{
    public MoviesDbContext()
    {
    }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var movies = modelBuilder.Entity<Movie>();

        movies.ToTable("Movies");

        movies.HasKey(m => m.Id);
        movies.Property(m => m.Title).IsRequired(); 
        movies.Property(m => m.Genre).IsRequired();
        movies.Property(m => m.Director).IsRequired(); 
        movies.Property(m => m.Year).IsRequired(); 
        movies.Property(m => m.Duration).IsRequired();

        movies.Property(m => m.Title).HasMaxLength(30);
        movies.Property(m => m.Synopsis).HasMaxLength(255);
    }

}
