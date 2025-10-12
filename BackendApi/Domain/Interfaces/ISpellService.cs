using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISpellService
    {
        Task<List<Spell>> GetAll();
        Task<Spell> GetById(int id);
        Task Create(Spell model);
        Task Update(Spell model);
        Task Delete(int id);
    }
}