using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllMovies();
        Task<MovieViewModel> GetMovieById(int id);
        Task<bool> InsertMovie(MovieViewModel movie);
        Task<bool> UpdateMovie(MovieViewModel movie);
        Task<bool> DeleteMovie(int id);
    }
}
