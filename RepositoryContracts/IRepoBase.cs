using System.Linq.Expressions;

namespace RepositoryContracts;

/// <summary>
/// This interface contains common methods for all entity repositories.
/// </summary>
public interface IRepoBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
