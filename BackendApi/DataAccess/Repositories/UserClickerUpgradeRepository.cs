using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserClickerUpgradeRepository : RepositoryBase<UserClickerUpgrade>, IUserClickerUpgradeRepository
    {
        public UserClickerUpgradeRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}