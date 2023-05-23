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

            var movieAdded = await _repository.GetAllMoviesAsync(movie.Name);
                
            if (movieAdded != null)
            {
                throw new Exception("O nome do filme já existe!");
            }
            return movie;

        }

        public async Task DeleteMovieAsync(Movie movie)
        {

        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {

        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {

        }
    }
}
