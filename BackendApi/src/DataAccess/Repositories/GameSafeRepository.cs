using Domain.Interfaces;
using Domain.Models;

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