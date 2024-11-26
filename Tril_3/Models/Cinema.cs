namespace Tril_3.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PlaceHolder { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
