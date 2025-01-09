using Library_System.AppDbContext;
using Library_System.Dtos;
using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repositorys.AuthorRepo
{
    public class RepoAuthor : IAuthorRepo
    {
        private readonly dbcontext _context;

        public RepoAuthor(dbcontext context)
        {
            _context = context;
        }

        public void AddAllDataAuthor(AddAllDataAuthor dto)
        {
            var result = new Authors
            {
                AuthorsName = dto.AuthorsName,
                AuthorsEmail = dto.AuthorsEmail,
                AuthorsPhone = dto.AuthorsPhone,
                Book = dto.BookDto.Select(x=> new Book
                {
                    BookTitle = x.BookTitle,
                    PublishedYear = x.PublishedYear,
                    Genre = x.GenreDto.Select(i => new Genre
                    {
                        GenreName = i.GenreName,
                    }).ToList(),
                }).ToList(),
                CreditCard = dto.CreditCardDto.Select(t => new CreditCard
                {
                    CardName = t.CardName,
                    CardType = t.CardType,
                }).ToList(),
                IdentityCard = new IdentityCard
                {
                    ExpiryDate = dto.IdentityCardDto.ExpiryDate,
                    
                }
            };
            _context.Authors.Add(result);
            _context.SaveChanges();
        }

        public void AddAuthor(AuthorDto dto)
        {
            var result = new Authors
            {
                AuthorsName = dto.AuthorsName,
                AuthorsEmail = dto.AuthorsEmail,
                AuthorsPhone = dto.AuthorsPhone,
            };
            _context.Authors.Add(result);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var result = _context.Authors.
                Include(x => x.CreditCard).
                Include(x => x.Book).
                ThenInclude(x=>x.Genre).
                Include(x => x.IdentityCard).
                FirstOrDefault(x=>x.AuthorsId == id);
            if (result != null)
            {
                _context.Authors.Remove(result);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<AddAllDataAuthor> GetAllDataAuthors()
        {
            var result = _context.Authors.
                Include(x=>x.CreditCard).
                Include(x=>x.Book).
                ThenInclude(x=>x.Genre).
                Include(x=>x.IdentityCard).
                Where(x=>x.IdentityCard != null).
                Select(i => new AddAllDataAuthor
                {
                    AuthorsEmail=i.AuthorsEmail,
                    AuthorsPhone=i.AuthorsPhone,
                    AuthorsName=i.AuthorsName,  
                    BookDto = i.Book.Select(t => new BookDto
                    {
                        BookTitle = t.BookTitle,
                        PublishedYear = t.PublishedYear,
                        GenreDto = t.Genre.Select(c => new GenreDto
                        {
                            GenreName = c.GenreName,
                        }).ToList(),
                    }).ToList(),
                    CreditCardDto = i.CreditCard.Select(m => new CreditCardDto
                    {
                        CardName = m.CardName,
                        CardType = m.CardType,
                    }).ToList(),
                    IdentityCardDto = new IdentityCardDto
                    {
                        ExpiryDate = i.IdentityCard.ExpiryDate,
                    }
                }).ToList();
            return result;
        }

        public AddAllDataAuthor GetById(int id)
        {
            var result = _context.Authors.
                Include(x => x.CreditCard).
                Include(x => x.Book).
                ThenInclude(x=>x.Genre).
                Include(x => x.IdentityCard).
                FirstOrDefault(x => x.AuthorsId == id);
            return new AddAllDataAuthor
            {
                AuthorsEmail = result.AuthorsEmail,
                AuthorsPhone = result.AuthorsPhone,
                AuthorsName = result.AuthorsName,
                BookDto = result.Book.Select(i => new BookDto
                {
                    BookTitle= i.BookTitle,
                    PublishedYear = i.PublishedYear,
                    GenreDto = i.Genre.Select(b => new GenreDto
                    {
                        GenreName = b.GenreName,
                    }).ToList(),
                }).ToList(),
                CreditCardDto = result.CreditCard.Select(m => new CreditCardDto
                {
                    CardName= m.CardName,
                    CardType= m.CardType,
                }).ToList(),
                IdentityCardDto = new IdentityCardDto
                {
                    ExpiryDate = result.IdentityCard.ExpiryDate,
                }
            };
        }

        public void UpdateAuthor(AddAllDataAuthor dto, int id)
        {
            var result = _context.Authors.
                Include(x => x.CreditCard).
                Include(x => x.Book).
                ThenInclude(x => x.Genre).
                Include(x => x.IdentityCard).
                FirstOrDefault(x=>x.AuthorsId==id);
            if(result != null)
            {
                result.AuthorsEmail = dto.AuthorsEmail;
                result.AuthorsPhone = dto.AuthorsPhone;
                result.AuthorsName = dto.AuthorsName;
                result.Book = dto.BookDto.Select(i => new Book
                {
                    BookTitle = i.BookTitle,
                    PublishedYear = i.PublishedYear,
                    Genre = i.GenreDto.Select(b => new Genre    
                    {
                        GenreName = b.GenreName,
                    }).ToList(),
                }).ToList();
                result.CreditCard = dto.CreditCardDto.Select(m => new CreditCard
                {
                    CardName = m.CardName,
                    CardType= m.CardType,
                }).ToList();
                result.IdentityCard = new IdentityCard
                {
                    ExpiryDate = dto.IdentityCardDto.ExpiryDate,
                };
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Authors.Update(result);
            _context.SaveChanges();
        }
    }
}
