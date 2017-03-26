using System.ComponentModel.DataAnnotations;

namespace ValueVideo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
        [Display(Name="Number Available")]
        public byte NumberAvailable { get; set; }
        public Genre Genre { get; set; }
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
    }

    public class Genre
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}