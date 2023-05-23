using Api_movie.Models;

namespace Api_movie.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Movie movie); 
    }
}
