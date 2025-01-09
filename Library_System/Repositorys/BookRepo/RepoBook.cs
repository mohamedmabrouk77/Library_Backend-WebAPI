using Library_System.AppDbContext;
using Library_System.Dtos;
using Library_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Library_System.Repositorys.BookRepo
{
    public class RepoBook : IBookRepo
    {
        private readonly dbcontext _context;

        public RepoBook(dbcontext context)
        {
            _context = context;
        }

        public void AddAllBook(GetAllBookDto dto)
        {
            var result = new Book
            {
                BookTitle = dto.BookTitle,
                PublishedYear = dto.PublishedYear,
                Genre = dto.GenreDto.Select(x=> new Genre
                {
                    GenreName = x.GenreName,
                }).ToList(),
                Author = dto.AuthorDto.Select(t => new Authors
                {
                    AuthorsEmail = t.AuthorsEmail,
                    AuthorsName = t.AuthorsName,
                    AuthorsPhone = t.AuthorsPhone,
                    IdentityCard = new IdentityCard
                    {
                        ExpiryDate = DateTime.UtcNow,
                    },
                    CreditCard = t.CreditCardDto.Select(i => new CreditCard
                    {
                        CardType = i.CardType,
                        CardName = i.CardName,
                    }).ToList(),
                }).ToList(),
            };
            _context.Books.Add(result);
            _context.SaveChanges();
        }

        public void DeleteAllBook(int id)
        {
            var result = _context.Books.
                Include(x => x.Genre).
                Include(x => x.Author).
                ThenInclude(x => x.CreditCard).
                FirstOrDefault(x => x.BookId == id);
            if(result != null)
            {
                _context.Books.Remove(result);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public GetAllBookDto GetAllBookById(int id)
        {
            var result = _context.Books.
                Include(x => x.Genre).
                Include(x => x.Author).
                ThenInclude(x => x.CreditCard).
                FirstOrDefault(x=>x.BookId == id);
            return new GetAllBookDto
            {
                BookTitle = result.BookTitle,
                PublishedYear = result.PublishedYear,
                AuthorDto = result.Author.Select(i => new AuthorDto
                {
                    AuthorsEmail = i.AuthorsEmail,
                    AuthorsName = i.AuthorsName,
                    AuthorsPhone = i.AuthorsPhone,
                    CreditCardDto = i.CreditCard.Select(t => new CreditCardDto
                    {
                        CardName = t.CardName,
                        CardType = t.CardType,
                    }).ToList(),
                    IdentityCardDto = new IdentityCardDto
                    {
                        ExpiryDate = i.IdentityCard.ExpiryDate,
                    }
                }).ToList(),
            };
        }

        public List<GetAllBookDto> GetAllBooks()
        {
            var result = _context.Books.
                Include(x => x.Genre).
                Include(x => x.Author).
                ThenInclude(x => x.CreditCard).
                Select(i => new GetAllBookDto
                {
                    BookTitle = i.BookTitle,
                    PublishedYear = i.PublishedYear,
                    AuthorDto = i.Author.Select(t => new AuthorDto
                    {
                        AuthorsEmail = t.AuthorsEmail,
                        AuthorsName = t.AuthorsName,
                        AuthorsPhone = t.AuthorsPhone,
                        CreditCardDto = t.CreditCard.Select(i => new CreditCardDto
                        {
                            CardName = i.CardName,
                            CardType = i.CardType,
                        }).ToList(),
                        IdentityCardDto = new IdentityCardDto
                        {
                            ExpiryDate = DateTime.UtcNow,
                        }
                    }).ToList(),
                }).ToList();

            return result;
        }

        public void UpdateAllBook(GetAllBookDto dto, int id)
        {
            var result = _context.Books.
                Include(x => x.Genre).
                Include(x => x.Author).
                ThenInclude(x => x.CreditCard).
                FirstOrDefault(x => x.BookId == id);
            if(result !=  null)
            {
                result.BookTitle = dto.BookTitle;
                result.PublishedYear = dto.PublishedYear;
                result.Author = dto.AuthorDto.Select(t => new Authors
                {
                    AuthorsEmail = t.AuthorsEmail,
                    AuthorsName = t.AuthorsName,
                    AuthorsPhone = t.AuthorsPhone,
                    CreditCard = t.CreditCardDto.Select(x => new CreditCard
                    {
                        CardName = x.CardName,
                        CardType = x.CardType,
                    }).ToList(),
                    IdentityCard = new IdentityCard
                    {
                        ExpiryDate = t.IdentityCardDto.ExpiryDate,
                    }
                }).ToList();
            }

            _context.Books.Update(result);
            _context.SaveChanges();
        }
    }
}
