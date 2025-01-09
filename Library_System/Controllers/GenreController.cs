using Library_System.Dtos;
using Library_System.Repositorys.GenreRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo repo;

        public GenreController(IGenreRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public IActionResult AddGenre(GenreDto dto)
        {
            repo.AddGenre(dto);
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetGenre()
        {
            var result = repo.GetAllGenre();
            return Ok(result);
        } 

        [HttpGet ("GetGenreById")]
        public IActionResult GetGenreById(int id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateGenre(GenreDto dto, int id)
        {
            repo.UpdateGenreById(dto, id);
            return NoContent();
        } 

        [HttpDelete]
        public IActionResult DeleteGenreById(int id)
        {
            repo.DeleteGenreById(id);
            return Created();
        }
    }
}
