using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGameSafeService
    {
        Task<List<GameSafe>> GetAll();
        Task<GameSafe> GetById(int id);
        Task Create(GameSafe model);
        Task Update(GameSafe model);
        Task Delete(int id);
    }
}
