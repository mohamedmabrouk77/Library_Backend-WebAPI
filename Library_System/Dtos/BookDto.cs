using Library_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_System.Dtos
{
    public class BookDto
    {
        [Required]
        public string BookTitle { get; set; }
        public DateTime PublishedYear { get; set; }
        public List<GenreDto> GenreDto { get; set; }
    }
}
