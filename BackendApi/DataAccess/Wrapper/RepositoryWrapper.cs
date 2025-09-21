using DataAccess.Models;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SpellLearningContext _repoContext;

        private IUserRepository _user;
        public IUserRepository User
        {
            get 
            {
                if (User == null) {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(SpellLearningContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
