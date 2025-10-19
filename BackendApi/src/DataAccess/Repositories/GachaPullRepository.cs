using Domain.Interfaces;
using Domain.Models;

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