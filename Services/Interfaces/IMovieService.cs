using Api_movie.Models;

namespace Api_movie.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Movie movie);
    }
}
