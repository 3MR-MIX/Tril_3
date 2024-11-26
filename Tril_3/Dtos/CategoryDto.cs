using System.ComponentModel.DataAnnotations;
using Tril_3.Models;

namespace Tril_3.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
