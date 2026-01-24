using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<User> GetByIdWithToken(int userId) =>
            await RepositoryContext.Set<User>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        public async Task<User> GetByEmailWithToken(string email) =>
            await RepositoryContext.Set<User>().Include(x => x.RefreshTokens).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }
}