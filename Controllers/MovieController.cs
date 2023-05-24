using Api_movie.Models;
using Api_movie.Repositories.Interfaces;
using Api_movie.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_movie.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync([FromBody] Movie movie)
        {
            movie = await _movieService.AddMovieAsync(movie);
            return Ok($"Filme adicionado com sucesso!" + movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieService.DeleteMovieAsync(movie);
            return Ok($"Filme deletado com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movies = await _movieService.GetAllMoviesAsync(); 
            return Ok(movies.ToList()); 
        }
    }
}
