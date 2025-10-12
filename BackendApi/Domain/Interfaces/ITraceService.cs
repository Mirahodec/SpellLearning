using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITraceService
    {
        Task<List<Trace>> GetAll();
        Task<Trace> GetById(int id);
        Task Create(Trace model);
        Task Update(Trace model);
        Task Delete(int id);
    }
}