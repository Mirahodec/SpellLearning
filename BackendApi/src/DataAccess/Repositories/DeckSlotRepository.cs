using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class DeckSlotRepository : RepositoryBase<DeckSlot>, IDeckSlotRepository
    {
        public DeckSlotRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}