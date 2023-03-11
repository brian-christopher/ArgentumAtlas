using DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DataLayer;

public static class DataLayerExtensions
{
    public static void AddDataLayerServices(this IServiceCollection service, IConfiguration configuration)
    {
        //var assemblyName = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name;

        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DbContext"), b => b.MigrationsAssembly("Web"));
        });

        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork)); 
    } 
}