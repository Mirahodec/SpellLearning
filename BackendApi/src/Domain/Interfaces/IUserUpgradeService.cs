using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserUpgradeService
    {
        Task<List<UserUpgrade>> GetAll();
        Task<UserUpgrade> GetById(int id);
        Task Create(UserUpgrade model);
        Task Update(UserUpgrade model);
        Task Delete(int id);
    }
}