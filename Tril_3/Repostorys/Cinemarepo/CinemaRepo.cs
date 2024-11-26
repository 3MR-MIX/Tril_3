using Microsoft.EntityFrameworkCore;
using Tril_3.Data;
using Tril_3.Dtos;
using Tril_3.Models;
using Tril_3.Repostorys.Cinema;

namespace Tril_3.Repostorys.Cinemarepo
{
    public class CinemaRepo : ICinemaRepo
    {
        public readonly dbcontext _context;

        public CinemaRepo(dbcontext context)
        {
            _context = context;
        }
        public void AddAllCinema(CinemaDto2 dto)
        {
            var x = new Models.Cinema
            {
                Name = dto.Name,
                PlaceHolder = dto.PlaceHolder,
                Movies = dto.Movie.Select(x=> new Movie
                {
                    Category = new Category
                    {
                        Name = x.CategoryDto.Name
                    },
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                }).ToList()
            };
            _context.Cinemas.Add(x);
            _context.SaveChanges();
        }

        public List<CinemaDto2> GetAllCinema()
        {
            var x = _context.Cinemas.Include(x => x.Movies).ThenInclude(z => z.Category).Select(z => new CinemaDto2
            {
                Name = z.Name,
                PlaceHolder = z.PlaceHolder,
                Movie = z.Movies.Select(x => new MovieDto2
                {
                    CategoryDto = new CategoryDto
                    {
                        Name = x.Category.Name
                    },
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                }).ToList()
            }).ToList();
            return x;
        }

        public CinemaDto2 GetCinemaById(int id)
        {
            var z = _context.Cinemas.Include(x => x.Movies).ThenInclude(z => z.Category).FirstOrDefault(x=>x.Id== id);
            return new CinemaDto2
            {
                Name = z.Name,
                PlaceHolder = z.PlaceHolder,
                Movie = z.Movies.Select(x => new MovieDto2
                {
                    CategoryDto = new CategoryDto
                    {
                        Name = x.Category.Name
                    },
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                }).ToList()
            };
           
        }

        public void update(CinemaDto2 dto, int id)
        {
            var x = _context.Cinemas.Include(x => x.Movies).ThenInclude(z => z.Category).FirstOrDefault(x=>x.Id== id);
            if (x != null) 
            {

                x.Name = dto.Name;
                x.PlaceHolder = dto.PlaceHolder;
                x.Movies = dto.Movie.Select(x => new Movie
                {
                    Category = new Category
                    {
                        Name = x.CategoryDto.Name
                    },
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                }).ToList();
                _context.Cinemas.Update(x);
                _context.SaveChanges();
            }
        }
    }
}
