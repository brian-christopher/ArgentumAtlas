using DomainModels;
using System.Threading.Tasks;

namespace DataLayer.Repositories;

class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private Repository<Platform> _platforms;
    private Repository<Server> _servers;

    public IRepository<Platform> Platforms
    {
        get
        {
            _platforms ??= new Repository<Platform>(_context);
            return _platforms;
        }
    }

    public IRepository<Server> Servers
    {
        get
        {
            _servers ??= new Repository<Server>(_context);
            return _servers;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
