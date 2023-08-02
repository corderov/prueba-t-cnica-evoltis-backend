using MoviesAPI.Views;

namespace MoviesAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovieResponseView>> GetAllMovies();
        Task<GetMovieResponseView> GetMovieById(int id);
        Task<GetMovieResponseView> InsertMovie(InsertMovieRequestView movie);
        Task<GetMovieResponseView> UpdateMovie(UpdateMovieRequestView movie);
        Task<bool> DeleteMovie(int id);
    }
}
