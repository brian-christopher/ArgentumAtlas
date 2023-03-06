using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
 
    public async Task<List<T>> GetListAsync()
    {
        return await _dbSet.ToListAsync();
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
}