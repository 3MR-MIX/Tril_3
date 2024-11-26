using Azure.Core.Pipeline;
using System.ComponentModel.DataAnnotations;
using Tril_3.Models;

namespace Tril_3.Dtos
{
    public class CinemaDto
    {
        [Required]
        public string? Name { get; set; }
        public int? PlaceHolder { get; set; }
    }
}
