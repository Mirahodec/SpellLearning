using DataAccess.Models;
using System.Linq.Expressions;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SpellLearningContext RepositiryContext { get; set; }
        public RepositoryBase(SpellLearningContext repositoryContext)
        {
            RepositiryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositiryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositiryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositiryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositiryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositiryContext.Set<T>().Remove(entity);
    }
}
