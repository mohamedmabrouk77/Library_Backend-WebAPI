using Library_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_System.Dtos
{
    public class AuthorDto
    {
        [Required]
        public string AuthorsName { get; set; }
        [Phone]
        public string AuthorsPhone { get; set; }
        [EmailAddress]
        public string AuthorsEmail { get; set; }
        public List<CreditCardDto> CreditCardDto { get; set; }
        public IdentityCardDto IdentityCardDto { get; set; }
    }
}
