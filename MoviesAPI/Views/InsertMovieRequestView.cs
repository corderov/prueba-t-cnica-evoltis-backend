namespace MoviesAPI.Views
{
    public class InsertMovieRequestView
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
    }
}
