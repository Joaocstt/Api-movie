using Api_movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_movie.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        {
        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
