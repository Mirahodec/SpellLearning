using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class GachaPullRepository : RepositoryBase<GachaPull>, IGachaPullRepository
    {
        public GachaPullRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}

