using System.ComponentModel.DataAnnotations;

namespace Library_System.Dtos
{
    public class GenreDto
    {
        [Required]
        public string GenreName { get; set; }
    }
}
