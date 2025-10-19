using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserClickerUpgradeService
    {
        Task<List<UserClickerUpgrade>> GetAll();
        Task<UserClickerUpgrade> GetById(int id);
        Task Create(UserClickerUpgrade model);
        Task Update(UserClickerUpgrade model);
        Task Delete(int id);
    }
}