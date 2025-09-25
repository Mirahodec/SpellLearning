using Domain.Models;
using Domain.Interfaces;

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

