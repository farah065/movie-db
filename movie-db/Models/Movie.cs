using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace movie_db.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public string? BelongsToCollection { get; set; }
        public int? Budget { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Genres { get; set; }

        public string? Homepage { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }

        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ProductionCompanies { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ProductionCountries { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? Revenue { get; set; }
        public int? Runtime { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? SpokenLanguages { get; set; }

        public string? Status { get; set; }
        public string? Tagline { get; set; }
        [Required]
        public string? Title { get; set; } = null!;
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
    }
}
