namespace Tril_3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Cinema? Cinemas { get; set; }
        public Category? Category { get; set; }
    }
}
