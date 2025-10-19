using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserInventoryService
    {
        Task<List<UserInventory>> GetAll();
        Task<UserInventory> GetById(int id);
        Task Create(UserInventory model);
        Task Update(UserInventory model);
        Task Delete(int id);
    }
}