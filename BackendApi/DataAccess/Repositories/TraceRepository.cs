using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class TraceRepository : RepositoryBase<Trace>, ITraceRepository
    {
        public TraceRepository(SpellLearningContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}

