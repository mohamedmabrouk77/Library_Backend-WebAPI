using System.ComponentModel.DataAnnotations;

namespace Library_System.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        public List<Book> Book { get; set; }
    }
}
