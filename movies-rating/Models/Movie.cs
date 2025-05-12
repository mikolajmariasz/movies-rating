using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movies_rating.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [NotMapped]
        public double AverageRating
            => Ratings != null && Ratings.Count > 0
                ? Math.Round(Ratings.Average(r => r.Score), 2)
                : 0.0;

        public virtual ICollection<Rating> Ratings { get; set; }
            = new List<Rating>();

        [Column(TypeName = "varbinary(max)")]
        public byte[]? PosterImageData { get; set; }

        [StringLength(100)]
        public string? PosterImageContentType { get; set; }
    }
}
