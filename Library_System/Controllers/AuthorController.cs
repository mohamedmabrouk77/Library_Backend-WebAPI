using Library_System.Dtos;
using Library_System.Repositorys.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorController(IAuthorRepo repo)
        {
            _repo = repo;
        }

        [HttpPost ("Add One Author")]
        public IActionResult PostAuthor(AuthorDto author)
        {
            _repo.AddAuthor(author);
            return Accepted();
        }

        [HttpPost("Add All Data Author")]
        public IActionResult PostAllDataAuthor(AddAllDataAuthor author)
        {
            _repo.AddAllDataAuthor(author);
            return Accepted();
        }

        [HttpPut]
        public IActionResult PutAuthor(AddAllDataAuthor dto, int id)
        {
            _repo.UpdateAuthor(dto,id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            _repo.DeleteAuthor(id);
            return Created();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllDataAuthors();
            return Ok(result);
        }
        [HttpGet("GetAllByID")]
        public IActionResult GetAllByID(int id)
        {
            var result = _repo.GetById(id);
            return Ok(result);
        }
    }
}
