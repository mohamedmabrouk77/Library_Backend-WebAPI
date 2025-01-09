using Library_System.Models;

namespace Library_System.Dtos
{
    public class IdentityCardDto
    {
        public DateTime ExpiryDate { get; set; }
        public int AuthorId { get; set; }
    }
}
