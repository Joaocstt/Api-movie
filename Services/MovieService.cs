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
            var movie = await _repository.GetMovieByIdAsync(id);
            if (movie == null) 
            {
                throw new Exception("Filme não encontrado. Verifique o id informado");
            }
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            var existingMovie = await _repository.GetMovieByIdAsync(movie.Id);
            if (existingMovie == null)
            {
                throw new Exception("Filme não encontrado.");
            }

            existingMovie.Name = movie.Name;
            existingMovie.Category = movie.Category;
            existingMovie.DateRelease = movie.DateRelease;

            return await _repository.UpdateMovieAsync(existingMovie);
        }
    }
}
