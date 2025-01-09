using Library_System.AppDbContext;
using Library_System.Dtos;
using Library_System.Models;

namespace Library_System.Repositorys.IdentityCardRepo
{
    public class IdentityRepo : IRepoIdentityCard
    {
        private readonly dbcontext _context;

        public IdentityRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddIdentityCard(IdentityCardDto dto)
        {
            var result = new IdentityCard
            {
                ExpiryDate = dto.ExpiryDate,
                AuthorsId = dto.AuthorId,
            };
            _context.IdentityCards.Add(result);
            _context.SaveChanges();
        }

        public void DeleteIdentityCard(int id)
        {
            var result = _context.IdentityCards.
                FirstOrDefault(x=>x.IdentityCardId == id);
            if (result != null)
            {
                _context.IdentityCards.Remove(result);
            }
            else
            {
                throw new Exception($"Id Not Found{id}");
            }
            _context.SaveChanges();
        }

        public IdentityCardDto GetIdentityCardById(int id)
        {
            var result = _context.IdentityCards.FirstOrDefault(x=>x.IdentityCardId == id);

            return new IdentityCardDto
            {
                ExpiryDate = result.ExpiryDate,
                AuthorId = result.AuthorsId,
            };
        }

        public List<IdentityCardDto> GetIdentityCards()
        {
            var result = _context.IdentityCards.
                Select(x=> new IdentityCardDto
                {
                    ExpiryDate= x.ExpiryDate,
                    AuthorId = x.AuthorsId
                }).ToList();
            return result;
        }

        public void UpdateIdentityCard(IdentityCardDto dto, int id)
        {
            var result = _context.IdentityCards.
                FirstOrDefault(x=>x.IdentityCardId == id);  
            if(result != null)
            {
                result.ExpiryDate = dto.ExpiryDate;
                result.AuthorsId = dto.AuthorId;
            }
            else
            {
                throw new Exception($"Id Not Found{id}");
            }
            _context.IdentityCards.Update(result);
            _context.SaveChanges();
        }
    }
}
