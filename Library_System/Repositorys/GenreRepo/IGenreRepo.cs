using Library_System.Dtos;

namespace Library_System.Repositorys.GenreRepo
{
    public interface IGenreRepo
    {
        public void AddGenre(GenreDto dto);
        public List<GenreDto> GetAllGenre();
        public GenreDto GetById(int id);
        public void UpdateGenreById(GenreDto dto, int id);
        public void DeleteGenreById(int id);
    }
}
