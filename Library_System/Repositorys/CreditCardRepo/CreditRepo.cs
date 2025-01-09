using Library_System.AppDbContext;
using Library_System.Dtos;
using Library_System.Models;

namespace Library_System.Repositorys.CreditCardRepo
{
    public class CreditRepo : ICreditRepo
    {
        private readonly dbcontext _context;

        public CreditRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddCreditCard(CreditCardDto dto)
        {
            var result = new CreditCard
            {
                CardName = dto.CardName,
                CardType = dto.CardType,    
                AuthorId = dto.AuthorId,
            };
            _context.CreditCards.Add(result);
            _context.SaveChanges();
        }

        public void DeleteCreditCard(int CreditId)
        {
            var result = _context.CreditCards.FirstOrDefault(x=>x.CrediteCardId == CreditId);
            if (result != null)
            {
                _context.CreditCards.Remove(result);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<CreditCardDto> GetAllCreditCard()
        {
            var result = _context.CreditCards.Select(x => new CreditCardDto
            {
                AuthorId = x.AuthorId,
                CardName = x.CardName,
                CardType = x.CardType,
            }).ToList();
            return result;
        }

        public CreditCardDto GetCreditCardById(int CreditId)
        {
            var result = _context.CreditCards.FirstOrDefault(x=>x.CrediteCardId == CreditId);

            return new CreditCardDto
            {
                CardType = result.CardType,
                AuthorId = result.AuthorId,
                CardName = result.CardName,
            };
        }

        public void UpdateCreditCard(CreditCardDto dto, int CreditId)
        {
            var result = _context.CreditCards.FirstOrDefault(x => x.CrediteCardId == CreditId);

            if(result != null)
            {
                result.CardType = dto.CardType;
                result.AuthorId = dto.AuthorId;
                result.CardName = dto.CardName;
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.CreditCards.Update(result);
            _context.SaveChanges();
        }
    }
}
