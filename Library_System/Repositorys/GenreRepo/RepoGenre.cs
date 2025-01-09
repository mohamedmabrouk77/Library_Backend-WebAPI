using Library_System.AppDbContext;
using Library_System.Dtos;
using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repositorys.GenreRepo
{
    public class RepoGenre : IGenreRepo
    {
        private readonly dbcontext _context;

        public RepoGenre(dbcontext context)
        {
            _context = context;
        }

        public void AddGenre(GenreDto dto)
        {
            bool exitingGenre = _context.Genres.Any(x=>x.GenreName == dto.GenreName);
            if (exitingGenre)
            {
                throw new Exception("Genre Already Found");
            }
            var result = new Genre
            {
                GenreName = dto.GenreName,
            };
            _context.Genres.Add(result);
            _context.SaveChanges(); 
        }

        public void DeleteGenreById(int id)
        {
            var result = _context.Genres.
                Include(x=>x.Book)
                .FirstOrDefault(x => x.GenreId == id);
            if (result != null)
            {
                _context.Genres.Remove(result);
            }
            else
            {
                throw new Exception($"Could not find {id}");
            }
            _context.SaveChanges();
        }

        public List<GenreDto> GetAllGenre()
        {
            var result = _context.Genres.
                Select(x=> new GenreDto
                {
                    GenreName = x.GenreName,
                    
                }).ToList();
            return result;
        }

        public GenreDto GetById(int id)
        {
            var result = _context.Genres.FirstOrDefault(x=>x.GenreId==id);
            return new GenreDto
            {
                GenreName = result.GenreName,
            };
        }

        public void UpdateGenreById(GenreDto dto, int id)
        {
            var result = _context.Genres.FirstOrDefault(x => x.GenreId == id);
            if (result != null)
            {
                result.GenreName = dto.GenreName;
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Genres.Update(result);
            _context.SaveChanges();
        }
    }
}
