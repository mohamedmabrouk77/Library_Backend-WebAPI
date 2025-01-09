using Library_System.Dtos;
using Library_System.Repositorys.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _repo;

        public BookController(IBookRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllBooks();
            return Ok(result);
        }
        [HttpGet ("GetAllById")]
        public IActionResult Get(int id)
        {
            var result = _repo.GetAllBookById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAll(GetAllBookDto dto)
        {
            _repo.AddAllBook(dto);
            return Accepted();
        }

        [HttpPut]
        public IActionResult UpdateAll(GetAllBookDto dto, int id)
        {
            _repo.UpdateAllBook(dto, id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteAllBook(id);
            return Created();
        }
    }
}
