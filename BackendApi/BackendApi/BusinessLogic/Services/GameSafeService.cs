using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GameSafeService : IGameSafeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GameSafeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GameSafe>> GetAll()
        {
            return await _repositoryWrapper.GameSafe.FindAll();
        }

        public async Task<GameSafe> GetById(int id)
        {
            var gameSafe = await _repositoryWrapper.GameSafe
                .FindByCondition(x => x.SaveId == id);
            return gameSafe.First();
        }

        public async Task Create(GameSafe model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.UserId <= 0)
                throw new ArgumentException("UserId must be greater than 0.", nameof(model.UserId));

            await _repositoryWrapper.GameSafe.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(GameSafe model)
        {
            await _repositoryWrapper.GameSafe.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var gameSafe = await _repositoryWrapper.GameSafe
                .FindByCondition(x => x.SaveId == id);

            await _repositoryWrapper.GameSafe.Delete(gameSafe.First());
            await _repositoryWrapper.Save();
        }
    }
}