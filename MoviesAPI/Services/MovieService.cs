using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

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

        public async Task<IEnumerable<MovieViewModel>> GetAllMovies()
        {
           var movies = await _repository.GetAllMovies();
            return _mapper.Map<IEnumerable<MovieViewModel>>(movies);
        }

        public async Task<MovieViewModel> GetMovieById(int id)
        {
            var movie = await _repository.GetMovieById(id);
            return _mapper.Map<MovieViewModel>(movie);
        }

        public async Task<bool> InsertMovie(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            await _repository.InsertMovie(movie);
            return true;
        }

        public async  Task<bool> UpdateMovie(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            await _repository.UpdateMovie(movie);
            return true;
        }
    }
}
