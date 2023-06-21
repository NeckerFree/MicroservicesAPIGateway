using Parser.Common.Entities;
using System.Linq.Expressions;
namespace Parser.Common.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T,bool>> filter);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
        Task UpdateAsync(Guid id, T entity);
    }
}