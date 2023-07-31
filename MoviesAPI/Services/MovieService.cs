using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories;
using MoviesAPI.Views;

namespace MoviesAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

           
        }

        public async Task<bool> DeleteMovie(int id)
        {
            await _repository.DeleteMovie(id);
            return true;
        }

        public async Task<IEnumerable<GetMovieResponseView>> GetAllMovies()
        {
           var movies = await _repository.GetAllMovies();
            return _mapper.Map<IEnumerable<GetMovieResponseView>>(movies);
        }

        public async Task<GetMovieResponseView> GetMovieById(int id)
        {
            var movie = await _repository.GetMovieById(id);
            return _mapper.Map<GetMovieResponseView>(movie);
        }

        public async Task<bool> InsertMovie(InsertMovieRequestView insertMovieView)
        {
            var movie = _mapper.Map<Movie>(insertMovieView);
            await _repository.InsertMovie(movie);
            return true;
        }

        public async  Task<bool> UpdateMovie(UpdateMovieRequestView updateMovieView)
        {
            var movie = _mapper.Map<Movie>(updateMovieView);
            await _repository.UpdateMovie(movie);
            return true;
        }
    }
}
