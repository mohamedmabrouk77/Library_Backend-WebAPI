using System.ComponentModel.DataAnnotations;

namespace Library_System.Models
{
    public class Authors
    {
        public int AuthorsId { get; set; }
        [Required]
        public string AuthorsName { get; set; }
        [Phone]
        public string AuthorsPhone { get; set; }
        [EmailAddress]
        public string AuthorsEmail { get; set; }
        public List<Book> Book { get; set; }
        public List<CreditCard> CreditCard { get; set; }
        public IdentityCard IdentityCard { get; set; }
    }
}
