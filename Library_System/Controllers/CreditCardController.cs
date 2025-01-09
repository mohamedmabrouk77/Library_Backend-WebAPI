using Library_System.Dtos;
using Library_System.Repositorys.CreditCardRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditRepo _repo;
        public CreditCardController(ICreditRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddCreditCard(CreditCardDto dto)
        {
            _repo.AddCreditCard(dto);
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetAllCreditCard()
        {
            var result = _repo.GetAllCreditCard();
            return Ok(result);
        }

        [HttpGet ("GetAllById")]
        public IActionResult GetCreditCardById(int id)
        {
            var result = _repo.GetCreditCardById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCreditCard(CreditCardDto dto, int id)
        {
            _repo.UpdateCreditCard(dto, id);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteCreditCardById(int id)
        {
            _repo.DeleteCreditCard(id);
            return Created();
        }
    }
}
