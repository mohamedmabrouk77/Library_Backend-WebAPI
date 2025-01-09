using System.ComponentModel.DataAnnotations;

namespace Library_System.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public DateTime PublishedYear { get; set; }
        public List<Authors> Author { get; set; }
        public List<Genre> Genre { get; set; }
    }
}
