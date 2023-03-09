using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetListAsync(QueryOptions<T> options);
    Task<T> GetAsync(QueryOptions<T> options);
    Task<T> GetAsync(int? id);
    Task<T> GetAsync(string id);


    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task<int> SaveAsync();
}