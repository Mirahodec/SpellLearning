using Domain.Models;
using Domain.Interfaces;

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

