using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserClickerUpgradeService : IUserClickerUpgradeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserClickerUpgradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserClickerUpgrade>> GetAll()
        {
            return await _repositoryWrapper.UserClickerUpgrade.FindAll();
        }

        public async Task<UserClickerUpgrade> GetById(int id)
        {
            var userClickerUpgrade = await _repositoryWrapper.UserClickerUpgrade
                .FindByCondition(x => x.UpgradeId == id);
            return userClickerUpgrade.First();
        }

        public async Task Create(UserClickerUpgrade model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.UserId <= 0)
                throw new ArgumentException("UserId must be greater than 0.", nameof(model.UserId));

            if (model.UpgradeId <= 0)
                throw new ArgumentException("UpgradeId must be greater than 0.", nameof(model.UpgradeId));

            await _repositoryWrapper.UserClickerUpgrade.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserClickerUpgrade model)
        {
            await _repositoryWrapper.UserClickerUpgrade.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userClickerUpgrade = await _repositoryWrapper.UserClickerUpgrade
                .FindByCondition(x => x.UpgradeId == id);

            await _repositoryWrapper.UserClickerUpgrade.Delete(userClickerUpgrade.First());
            await _repositoryWrapper.Save();
        }
    }
}