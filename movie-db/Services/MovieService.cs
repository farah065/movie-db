using movie_db.Models.DTO;
using movie_db.Models;
using Newtonsoft.Json;

namespace movie_db.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return null;

            return MapToDTO(movie);
        }

        private MovieDTO MapToDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id,
                Adult = movie.Adult,
                BackdropPath = movie.BackdropPath,
                BelongsToCollection = movie.BelongsToCollection,
                Budget = movie.Budget,
                Genres = movie.Genres != null ? JsonConvert.DeserializeObject<List<GenreDTO>>(movie.Genres) : null,
                Homepage = movie.Homepage,
                ImdbId = movie.ImdbId,
                OriginalLanguage = movie.OriginalLanguage,
                OriginalTitle = movie.OriginalTitle,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                PosterPath = movie.PosterPath,
                ProductionCompanies = movie.ProductionCompanies != null ? JsonConvert.DeserializeObject<List<ProductionCompanyDTO>>(movie.ProductionCompanies) : null,
                ProductionCountries = movie.ProductionCountries != null ? JsonConvert.DeserializeObject<List<ProductionCountryDTO>>(movie.ProductionCountries) : null,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                SpokenLanguages = movie.SpokenLanguages != null ? JsonConvert.DeserializeObject<List<SpokenLanguageDTO>>(movie.SpokenLanguages) : null,
                Status = movie.Status,
                Tagline = movie.Tagline,
                Title = movie.Title,
                Video = movie.Video,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount
            };
        }

        public async Task AddMovieAsync(MovieDTO movieDto)
        {
            var movieEntity = MapToEntity(movieDto);
            _context.Movies.Add(movieEntity);
            await _context.SaveChangesAsync();
        }

        private Movie MapToEntity(MovieDTO movieDto)
        {
            return new Movie
            {
                Id = movieDto.Id,
                Adult = movieDto.Adult,
                BackdropPath = movieDto.BackdropPath,
                BelongsToCollection = movieDto.BelongsToCollection,
                Budget = movieDto.Budget,
                Genres = movieDto.Genres != null ? JsonConvert.SerializeObject(movieDto.Genres) : null,
                Homepage = movieDto.Homepage,
                ImdbId = movieDto.ImdbId,
                OriginalLanguage = movieDto.OriginalLanguage,
                OriginalTitle = movieDto.OriginalTitle,
                Overview = movieDto.Overview,
                Popularity = movieDto.Popularity,
                PosterPath = movieDto.PosterPath,
                ProductionCompanies = movieDto.ProductionCompanies != null ? JsonConvert.SerializeObject(movieDto.ProductionCompanies) : null,
                ProductionCountries = movieDto.ProductionCountries != null ? JsonConvert.SerializeObject(movieDto.ProductionCountries) : null,
                ReleaseDate = movieDto.ReleaseDate,
                Revenue = movieDto.Revenue,
                Runtime = movieDto.Runtime,
                SpokenLanguages = movieDto.SpokenLanguages != null ? JsonConvert.SerializeObject(movieDto.SpokenLanguages) : null,
                Status = movieDto.Status,
                Tagline = movieDto.Tagline,
                Title = movieDto.Title,
                Video = movieDto.Video,
                VoteAverage = movieDto.VoteAverage,
                VoteCount = movieDto.VoteCount
            };
        }
    }
}
