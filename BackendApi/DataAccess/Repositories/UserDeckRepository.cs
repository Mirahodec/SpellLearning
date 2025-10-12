using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserDeckRepository : RepositoryBase<UserDeck>, IUserDeckRepository
    {
        public UserDeckRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}