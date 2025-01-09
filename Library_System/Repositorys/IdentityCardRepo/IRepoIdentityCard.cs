using Library_System.Dtos;

namespace Library_System.Repositorys.IdentityCardRepo
{
    public interface IRepoIdentityCard
    {
        public void AddIdentityCard(IdentityCardDto dto);
        public List<IdentityCardDto> GetIdentityCards();
        public IdentityCardDto GetIdentityCardById(int id);
        public void UpdateIdentityCard(IdentityCardDto dto, int id);
        public void DeleteIdentityCard(int id);
    }
}
