namespace Library_System.Models
{
    public class IdentityCard
    {
        public int IdentityCardId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AuthorsId { get; set; }
        public Authors Author { get; set; }
    }
}
