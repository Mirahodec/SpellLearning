using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserUpgradeService : IUserUpgradeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserUpgradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserUpgrade>> GetAll()
        {
            return await _repositoryWrapper.UserUpgrade.FindAll();
        }

        public async Task<UserUpgrade> GetById(int id)
        {
            var userUpgrade = await _repositoryWrapper.UserUpgrade
                .FindByCondition(x => x.UpgradeId == id);
            return userUpgrade.First();
        }

        public async Task Create(UserUpgrade model)
        {
            await _repositoryWrapper.UserUpgrade.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserUpgrade model)
        {
            await _repositoryWrapper.UserUpgrade.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userUpgrade = await _repositoryWrapper.UserUpgrade
                .FindByCondition(x => x.UpgradeId == id);

            await _repositoryWrapper.UserUpgrade.Delete(userUpgrade.First());
            await _repositoryWrapper.Save();
        }
    }
}