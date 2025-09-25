using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserInventoryService : IUserInventoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserInventoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserInventory>> GetAll()
        {
            return await _repositoryWrapper.UserInventory.FindAll();
        }

        public async Task<UserInventory> GetById(int id)
        {
            var userInventory = await _repositoryWrapper.UserInventory
                .FindByCondition(x => x.InventoryId == id);
            return userInventory.First();
        }

        public async Task Create(UserInventory model)
        {
            await _repositoryWrapper.UserInventory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UserInventory model)
        {
            _repositoryWrapper.UserInventory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userInventory = await _repositoryWrapper.UserInventory
                .FindByCondition(x => x.InventoryId == id);

            _repositoryWrapper.UserInventory.Delete(userInventory.First());
            _repositoryWrapper.Save();
        }
    }
}

