using Library_System.Dtos;

namespace Library_System.Repositorys.CreditCardRepo
{
    public interface ICreditRepo
    {
        public void AddCreditCard(CreditCardDto dto);
        public List<CreditCardDto> GetAllCreditCard();
        public CreditCardDto GetCreditCardById(int CreditId);
        public void UpdateCreditCard(CreditCardDto dto, int CreditId);
        public void DeleteCreditCard(int CreditId);
    }
}
