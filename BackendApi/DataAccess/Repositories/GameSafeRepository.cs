using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class GameSafeRepository : RepositoryBase<GameSafe>, IGameSafeRepository
    {
        public GameSafeRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}

