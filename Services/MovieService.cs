using Api_movie.Models;
using Api_movie.Repositories.Interfaces;
using Api_movie.Services.Interfaces;

namespace Api_movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {

            var movieAdded = await _repository.GetMovieByNameAsync(movie.Name);
                
            if (movieAdded != null)
            {
                throw new Exception("Esse filme já foi cadastrado.");
            }
            return await _repository.AddMovieAsync(movie);

        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            await _repository.DeleteMovieAsync(movie);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _repository.GetAllMoviesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _repository.GetMovieByIdAsync(id);
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            return await _repository.UpdateMovieAsync(movie);
        }
    }
}
