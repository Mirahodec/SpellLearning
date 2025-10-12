using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class SpellRepository : RepositoryBase<Spell>, ISpellRepository
    {
        public SpellRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}