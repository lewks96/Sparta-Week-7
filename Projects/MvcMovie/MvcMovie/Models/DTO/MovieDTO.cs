using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace MvcMovie.Models.DTO
{
    public class MovieDTO
    {
        public MovieDTO() { }

        public MovieDTO(int id, string? title, DateTime releaseDate, string? genre, decimal price, string? rating, IFormFile image)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            Price = price;
            Rating = rating;
            Image = image;
        }
        public MovieDTO(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Genre = movie.Genre;
            Price = movie.Price;
            Rating = movie.Rating;
            Image = null!;
        }

        public Movie ToMovie()
        {
            return new Movie()
            {
                Id = Id,
                Title = Title,
                ReleaseDate = ReleaseDate,
                Genre = Genre,
                Price = Price,
                Rating = Rating,
            };
        }

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; }
        public IFormFile? Image { get; set; }
    }
}
