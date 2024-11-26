using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tril_3.Dtos;
using Tril_3.Repostorys.MoviesRepo;

namespace Tril_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAllController : ControllerBase
    {
        private readonly IMovieRepo _repo;

        public MovieAllController(IMovieRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetMovieById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAll(MovieDto dto)
        {
            _repo.AddAllMovie(dto);
            return Ok();
        }
        [HttpGet("All")]
        public IActionResult All()
        {

        return Ok(_repo.GetAllMovies()); 
        }
        [HttpPut]
        public IActionResult Put(MovieDto dto,int Id) 
        { 
            _repo.update(dto, Id);
            return Ok();
        }
    }
    
}
