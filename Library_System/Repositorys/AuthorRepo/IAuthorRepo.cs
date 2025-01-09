using Library_System.Dtos;

namespace Library_System.Repositorys.AuthorRepo
{
    public interface IAuthorRepo
    {
        public void AddAuthor(AuthorDto dto);
        public void AddAllDataAuthor(AddAllDataAuthor dto);
        public List<AddAllDataAuthor> GetAllDataAuthors();
        public AddAllDataAuthor GetById(int id);
        public void UpdateAuthor(AddAllDataAuthor dto, int id);
        public void DeleteAuthor(int id);
    }
}
