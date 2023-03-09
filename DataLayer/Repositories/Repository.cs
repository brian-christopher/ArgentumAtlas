using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories;
class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetListAsync(QueryOptions<T> options)
    {
        return await BuildQuery(options).ToListAsync();
    }
    public async Task<T> GetAsync(QueryOptions<T> options)
    {
        return await BuildQuery(options).FirstOrDefaultAsync();
    }

    public async Task<T> GetAsync(int? id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> GetAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<int> SaveAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result;
    }

    private IQueryable<T> BuildQuery(QueryOptions<T> options)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in options.GetIncludes())
        {
            query = query.Include(include);
        }

        if (options.HasWhere)
        {
            foreach (var where in options.WhereClauses)
            {
                query = query.Where(where); 
            } 
        }

        if (options.HasOrderBy)
        {
            if (options.OrderByDirection == "asc")
                query = query.OrderBy(options.OrderBy);
            else
                query = query.OrderByDescending(options.OrderBy);
        }

        return query;
    }
}