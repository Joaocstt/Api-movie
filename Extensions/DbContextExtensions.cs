using Api_movie.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_movie.Extensions
{
    internal static class DbContextExtensions
    {
        internal static void AddMovieContext(this IServiceCollection services, IConfiguration configuration)

        {
            string connectionString = configuration.GetConnectionString("movieConnection");
            string serverVersion = "8.0.32";

            services.AddDbContext<MovieContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(serverVersion),
                    builder => builder.MigrationsAssembly(typeof(DbContextExtensions).Assembly.FullName)));
        }
    } 
}