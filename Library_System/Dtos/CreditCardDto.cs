using System.ComponentModel.DataAnnotations;

namespace Library_System.Dtos
{
    public class CreditCardDto
    {
        [Required]
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int AuthorId { get; set; }
    }
}
