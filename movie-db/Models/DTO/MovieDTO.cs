using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movie_db.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public string? BelongsToCollection { get; set; }
        public int? Budget { get; set; }
        public List<GenreDTO>? Genres { get; set; }
        public string? Homepage { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }

        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public List<ProductionCompanyDTO>? ProductionCompanies { get; set; }
        public List<ProductionCountryDTO>? ProductionCountries { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Revenue { get; set; }
        public int? Runtime { get; set; }
        public List<SpokenLanguageDTO>? SpokenLanguages { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
    }

    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LogoPath { get; set; }
        public string OriginCountry { get; set; }
    }

    public class ProductionCountryDTO
    {
        public string Iso3166_1 { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguageDTO
    {
        public string Iso639_1 { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
    }
}
