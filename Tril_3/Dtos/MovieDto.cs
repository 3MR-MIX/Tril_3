using System.ComponentModel.DataAnnotations;
using Tril_3.Models;

namespace Tril_3.Dtos
{
    public class MovieDto
    {
        [Required]
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public CinemaDto? CinemasDto { get; set; }
        public CategoryDto? CategoryDto { get; set; }
    }
}
