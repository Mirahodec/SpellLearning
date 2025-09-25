using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class UserUpgradeRepository : RepositoryBase<UserUpgrade>, IUserUpgradeRepository
    {
        public UserUpgradeRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}

