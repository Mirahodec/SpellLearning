﻿using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}
