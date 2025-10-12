using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GachaPullService : IGachaPullService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GachaPullService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GachaPull>> GetAll()
        {
            return await _repositoryWrapper.GachaPull.FindAll();
        }

        public async Task<GachaPull> GetById(int id)
        {
            var gachaPull = await _repositoryWrapper.GachaPull
                .FindByCondition(x => x.PullId == id);
            return gachaPull.First();
        }

        public async Task Create(GachaPull model)
        {
            await _repositoryWrapper.GachaPull.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(GachaPull model)
        {
            await _repositoryWrapper.GachaPull.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var gachaPull = await _repositoryWrapper.GachaPull
                .FindByCondition(x => x.PullId == id);

            await _repositoryWrapper.GachaPull.Delete(gachaPull.First());
            await _repositoryWrapper.Save();
        }
    }
}