using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TraceService : ITraceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TraceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Trace>> GetAll()
        {
            return await _repositoryWrapper.Trace.FindAll();
        }

        public async Task<Trace> GetById(int id)
        {
            var trace = await _repositoryWrapper.Trace
                .FindByCondition(x => x.TradeId == id);
            return trace.First();
        }

        public async Task Create(Trace model)
        {
            await _repositoryWrapper.Trace.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Trace model)
        {
            await _repositoryWrapper.Trace.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var trace = await _repositoryWrapper.Trace
                .FindByCondition(x => x.TradeId == id);

            await _repositoryWrapper.Trace.Delete(trace.First());
            await _repositoryWrapper.Save();
        }
    }
}