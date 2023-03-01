using Microsoft.EntityFrameworkCore;
using MVCMovieBase.Infrasctructure.Entities;
using System.Reflection;

namespace MVCMovieBase.Infrasctructure
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
