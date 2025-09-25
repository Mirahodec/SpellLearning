using Domain.Models;
using Domain.Interfaces;

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

