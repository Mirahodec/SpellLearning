using Domain.Interfaces;
using Domain.Models;

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