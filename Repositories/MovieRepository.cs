using Api_movie.Context;
using Api_movie.Models;
using Api_movie.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_movie.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context; 
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie); 
            await _context.SaveChangesAsync();  
            return movie;   
        }
        public async Task DeleteMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
           return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
