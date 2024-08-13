namespace movie_db.Models.DTO
{
    public class MovieResultsDTO
    {
        public int Page { get; set; }
        public List<ResultMovieDetailsDTO> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
    public class ResultMovieDetailsDTO
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
