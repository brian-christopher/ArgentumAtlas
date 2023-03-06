using System;
using System.Reflection;
using System.Reflection.Metadata;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer;

public static class DataLaterExtensions
{
    public static void AddDataLayerServices(this IServiceCollection service, IConfiguration configuration)
    {
        //var assemblyName = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name;
        
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DbContext"),b => b.MigrationsAssembly("Web"));
        });

        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}