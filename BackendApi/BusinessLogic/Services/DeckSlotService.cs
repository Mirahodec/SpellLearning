using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class DeckSlotService : IDeckSlotService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DeckSlotService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<DeckSlot>> GetAll()
        {
            return await _repositoryWrapper.DeckSlot.FindAll();
        }

        public async Task<DeckSlot> GetById(int id)
        {
            var deckSlot = await _repositoryWrapper.DeckSlot
                .FindByCondition(x => x.SlotId == id);
            return deckSlot.First();
        }

        public async Task Create(DeckSlot model)
        {
            await _repositoryWrapper.DeckSlot.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(DeckSlot model)
        {
            await _repositoryWrapper.DeckSlot.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var deckSlot = await _repositoryWrapper.DeckSlot
                .FindByCondition(x => x.SlotId == id);

            await _repositoryWrapper.DeckSlot.Delete(deckSlot.First());
            await _repositoryWrapper.Save();
        }
    }
}