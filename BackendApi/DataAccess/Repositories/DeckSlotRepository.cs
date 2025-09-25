using Domain.Models;
using Domain.Interfaces;

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

