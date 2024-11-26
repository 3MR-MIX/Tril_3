using System.ComponentModel.DataAnnotations;

namespace Tril_3.Dtos
{
    public class CinemaDto2
    {
        [Required]
        public string? Name { get; set; }
        public int? PlaceHolder { get; set; }
        public List<MovieDto2>? Movie { get; set; }
    }
}
