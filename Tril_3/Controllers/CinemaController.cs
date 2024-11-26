using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tril_3.Data;
using Tril_3.Dtos;
using Tril_3.Repostorys.Cinema;

namespace Tril_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaRepo context;
        public CinemaController(ICinemaRepo _context)
        {
            context= _context;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(context.GetCinemaById(id));
        }
        [HttpGet("all")]
        public IActionResult Getall()
        {
            return Ok(context.GetAllCinema());
        }
        [HttpPut]
        public IActionResult update(CinemaDto2 cinema,int id)
        {
            context.update(cinema, id);
            return Ok();
        }
        [HttpPost]
        public IActionResult post(CinemaDto2 dto)
        {
            context.AddAllCinema(dto);
            return Ok();
        }
    }
}
