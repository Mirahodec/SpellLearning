using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserDeckService
    {
        Task<List<UserDeck>> GetAll();
        Task<UserDeck> GetById(int id);
        Task Create(UserDeck model);
        Task Update(UserDeck model);
        Task Delete(int id);
    }
}
