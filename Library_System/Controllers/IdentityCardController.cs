using Library_System.Dtos;
using Library_System.Repositorys.IdentityCardRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityCardController : ControllerBase
    {
        private readonly IRepoIdentityCard repo;
        public IdentityCardController(IRepoIdentityCard repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public IActionResult AddIdentityCard(IdentityCardDto dto)
        {
            repo.AddIdentityCard(dto);
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetIdentityCard()
        {
            var result = repo.GetIdentityCards();
            return Ok(result);
        }

        [HttpGet ("GetIdentityCardById")]
        public IActionResult GetIdentityCardById(int id)
        {
            var result = repo.GetIdentityCardById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult PutIdentityCard(IdentityCardDto dto, int id)
        {
            repo.UpdateIdentityCard(dto, id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteIdentityCard(int id)
        {
            repo.DeleteIdentityCard(id);
            return Created();
        }
    }
}
