using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;
        

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if (movieToDelete == null)
                return false;

            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {

             return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<bool> InsertMovie(Movie movie)
        {
            
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movie.Id);
            if (existingMovie == null)
                return false;
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Director = movie.Director;
            existingMovie.Year = movie.Year;
            existingMovie.Synopsis = movie.Synopsis;
            existingMovie.Duration = movie.Duration;
            existingMovie.Country = movie.Country;
            existingMovie.Language = movie.Language;
            existingMovie.Image = movie.Image;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
