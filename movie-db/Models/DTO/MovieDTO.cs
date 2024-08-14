using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movie_db.Models.DTO
{
    public class BelongsToCollectionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Poster_Path { get; set; }
        public string? Backdrop_Path { get; set; }
    }

    public class MovieDTO
    {
        public int Id { get; set; }
        public bool? Adult { get; set; }
        public string? Backdrop_Path { get; set; }
        public BelongsToCollectionDTO? Belongs_To_Collection { get; set; }
        public int? Budget { get; set; }
        public List<GenreDTO>? Genres { get; set; }
        public string? Homepage { get; set; }
        public string? Imdb_Id { get; set; }
        public string? Original_Language { get; set; }
        public string? Original_Title { get; set; }

        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? Poster_Path { get; set; }
        public List<ProductionCompanyDTO>? Production_Companies { get; set; }
        public List<ProductionCountryDTO>? Production_Countries { get; set; }
        public DateTime? Release_Date { get; set; }
        public int? Revenue { get; set; }
        public int? Runtime { get; set; }
        public List<SpokenLanguageDTO>? Spoken_Languages { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public bool? Video { get; set; }
        public double? Vote_Average { get; set; }
        public int? Vote_Count { get; set; }
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
        public string? Logo_Path { get; set; }
        public string Origin_Country { get; set; }
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
        public string English_Name { get; set; }
    }
}
