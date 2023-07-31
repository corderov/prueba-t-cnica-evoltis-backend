using MoviesAPI.Views;

namespace MoviesAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovieResponseView>> GetAllMovies();
        Task<GetMovieResponseView> GetMovieById(int id);
        Task<bool> InsertMovie(InsertMovieRequestView movie);
        Task<bool> UpdateMovie(UpdateMovieRequestView movie);
        Task<bool> DeleteMovie(int id);
    }
}
