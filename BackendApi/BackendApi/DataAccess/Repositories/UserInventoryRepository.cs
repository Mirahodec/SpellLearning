using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserInventoryRepository : RepositoryBase<UserInventory>, IUserInventoryRepository
    {
        public UserInventoryRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}