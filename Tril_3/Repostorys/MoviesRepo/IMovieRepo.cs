using Tril_3.Dtos;

namespace Tril_3.Repostorys.MoviesRepo
{
    public interface IMovieRepo
    {
        public void AddAllMovie(MovieDto dto);
        public List<MovieDto> GetAllMovies();
        public MovieDto GetMovieById(int id);
        public void update(MovieDto dto, int id);


    }
}
