using Domain.Interfaces;
using Domain.Models;

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