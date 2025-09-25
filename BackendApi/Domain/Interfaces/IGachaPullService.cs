using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGachaPullService
    {
        Task<List<GachaPull>> GetAll();
        Task<GachaPull> GetById(int id);
        Task Create(GachaPull model);
        Task Update(GachaPull model);
        Task Delete(int id);
    }
}
