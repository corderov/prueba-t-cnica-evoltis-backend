using AutoMapper;
using MoviesAPI.Models;
using MoviesAPI.Views;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {

        public MovieProfile() {
            CreateMap<Movie, GetMovieResponseView>();
            CreateMap<InsertMovieRequestView, Movie>();
            CreateMap<UpdateMovieRequestView, Movie>();
        }
    }
}
