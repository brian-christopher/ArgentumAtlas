using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories;

public interface IUnitOfWork
{
    public IRepository<Platform> Platforms { get; }
    public IRepository<Server> Servers { get; }

    public Task SaveAsync();
}
