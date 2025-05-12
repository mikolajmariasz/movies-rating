using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using movies_rating.Data;   

namespace movies_rating.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required, Range(1, 5)]
        public int Score { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
