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
                Backdrop_Path = movie.BackdropPath,
                Belongs_To_Collection = movie.BelongsToCollection != null ? JsonConvert.DeserializeObject<BelongsToCollectionDTO>(movie.BelongsToCollection) : null,
                Budget = movie.Budget,
                Genres = movie.Genres != null ? JsonConvert.DeserializeObject<List<GenreDTO>>(movie.Genres) : null,
                Homepage = movie.Homepage,
                Imdb_Id = movie.ImdbId,
                Original_Language = movie.OriginalLanguage,
                Original_Title = movie.OriginalTitle,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                Poster_Path = movie.PosterPath,
                Production_Companies = movie.ProductionCompanies != null ? JsonConvert.DeserializeObject<List<ProductionCompanyDTO>>(movie.ProductionCompanies) : null,
                Production_Countries = movie.ProductionCountries != null ? JsonConvert.DeserializeObject<List<ProductionCountryDTO>>(movie.ProductionCountries) : null,
                Release_Date = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Spoken_Languages = movie.SpokenLanguages != null ? JsonConvert.DeserializeObject<List<SpokenLanguageDTO>>(movie.SpokenLanguages) : null,
                Status = movie.Status,
                Tagline = movie.Tagline,
                Title = movie.Title,
                Video = movie.Video,
                Vote_Average = movie.VoteAverage,
                Vote_Count = movie.VoteCount
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
                BackdropPath = movieDto.Backdrop_Path,
                BelongsToCollection = movieDto.Belongs_To_Collection != null ? JsonConvert.SerializeObject(movieDto.Belongs_To_Collection) : null,
                Budget = movieDto.Budget,
                Genres = movieDto.Genres != null ? JsonConvert.SerializeObject(movieDto.Genres) : null,
                Homepage = movieDto.Homepage,
                ImdbId = movieDto.Imdb_Id,
                OriginalLanguage = movieDto.Original_Language,
                OriginalTitle = movieDto.Original_Title,
                Overview = movieDto.Overview,
                Popularity = movieDto.Popularity,
                PosterPath = movieDto.Poster_Path,
                ProductionCompanies = movieDto.Production_Companies != null ? JsonConvert.SerializeObject(movieDto.Production_Companies) : null,
                ProductionCountries = movieDto.Production_Countries != null ? JsonConvert.SerializeObject(movieDto.Production_Countries) : null,
                ReleaseDate = movieDto.Release_Date,
                Revenue = movieDto.Revenue,
                Runtime = movieDto.Runtime,
                SpokenLanguages = movieDto.Spoken_Languages != null ? JsonConvert.SerializeObject(movieDto.Spoken_Languages) : null,
                Status = movieDto.Status,
                Tagline = movieDto.Tagline,
                Title = movieDto.Title,
                Video = movieDto.Video,
                VoteAverage = movieDto.Vote_Average,
                VoteCount = movieDto.Vote_Count
            };
        }
    }
}
