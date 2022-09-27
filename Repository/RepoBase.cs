using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repository;

public class RepoBase<T> : IRepoBase<T> where T : class
{
    public RepoContext _context { get; set; }
    public RepoBase(RepoContext context)
    {
        _context = context;
    }
    
    public IQueryable<T> FindAll() => _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);

    public void Create(T entity) => _context.Add(entity);

    public void Update(T entity) => _context.Update(entity);

    public void Delete(T entity) => _context.Remove(entity);
}