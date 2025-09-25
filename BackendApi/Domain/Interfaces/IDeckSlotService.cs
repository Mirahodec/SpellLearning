using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDeckSlotService
    {
        Task<List<DeckSlot>> GetAll();
        Task<DeckSlot> GetById(int id);
        Task Create(DeckSlot model);
        Task Update(DeckSlot model);
        Task Delete(int id);
    }
}
