using Microsoft.EntityFrameworkCore;
using Tril_3.Data;
using Tril_3.Dtos;
using Tril_3.Models;

namespace Tril_3.Repostorys.MoviesRepo
{
    public class MovieRepo : IMovieRepo
    {
        public readonly dbcontext _context;

        public MovieRepo(dbcontext context)
        {
            _context = context;
        }
        public void AddAllMovie(MovieDto dto)
        {
            Movie movie = new Movie
            {
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                Category = new Category
                {
                    Name = dto.CategoryDto.Name,
                },
                Cinemas = new Models.Cinema
                {
                    Name = dto.CinemasDto.Name,
                    PlaceHolder = dto.CinemasDto.PlaceHolder,
                }
            };
            _context.Movies.Add(movie);
            _context.SaveChanges(); 
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieDto> GetAllMovies()
        {
            var x = _context.Movies.Include(x=>x.Cinemas).Include(m=>m.Category).Select(z=>new MovieDto
            {
                Title=z.Title,
                ReleaseDate=z.ReleaseDate,
                CategoryDto=new CategoryDto { Name = z.Category.Name},
                CinemasDto=new CinemaDto
                {
                    Name = z.Cinemas.Name,
                    PlaceHolder=z.Cinemas.PlaceHolder,
                }
            }).ToList();
            return x;
        }

        public MovieDto GetMovieById(int id)
        {
            var result = _context.Movies.Include(x=>x.Category).Include(x=>x.Cinemas).
                FirstOrDefault(x=>x.Id == id);
            return new MovieDto
            {
                Title = result.Title,
                ReleaseDate = result.ReleaseDate,
                CategoryDto = new CategoryDto
                {
                    Name = result.Category.Name,
                },
                CinemasDto = new CinemaDto
                {
                    Name = result.Cinemas.Name,
                    PlaceHolder = result.Cinemas.PlaceHolder,
                },
            };
        }
        public void update(MovieDto dto,int id)
        {
            var result = _context.Movies.Include(x => x.Category).Include(x => x.Cinemas).
                            FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Title = dto.Title;
                result.ReleaseDate = dto.ReleaseDate;
                result.Category = new Category { Name = dto.CategoryDto.Name };
                result.Cinemas = new Models.Cinema { Name = dto.CinemasDto.Name , PlaceHolder= dto.CinemasDto.PlaceHolder };

                _context.Movies.Update(result);
                _context.SaveChanges();
            }
        }
    }
}
