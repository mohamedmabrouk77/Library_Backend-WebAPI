using System.ComponentModel.DataAnnotations;

namespace Library_System.Models
{
    public class CreditCard
    {
        [Key]
        public int CrediteCardId { get; set; }
        [Required]
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
    }
}
