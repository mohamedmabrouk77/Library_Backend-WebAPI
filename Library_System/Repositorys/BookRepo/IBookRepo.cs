using Library_System.Dtos;

namespace Library_System.Repositorys.BookRepo
{
    public interface IBookRepo
    {
        public List<GetAllBookDto> GetAllBooks();
        public GetAllBookDto GetAllBookById(int id);
        public void AddAllBook(GetAllBookDto dto);
        public void UpdateAllBook(GetAllBookDto dto, int id);
        public void DeleteAllBook(int id);
    }
}
