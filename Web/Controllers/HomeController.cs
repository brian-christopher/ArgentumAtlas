using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArgentumAtlas.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Server> _repository;

    public HomeController(IRepository<Server> repository)
    {
        _repository = repository;
    }

    public async Task<ViewResult> Index()
    {
        var model = await _repository.GetListAsync(new QueryOptions<Server>()
        {
            Includes = "ServerPlatforms.Platform",
            OrderBy = s => s.ServerId
        });

        return View(model); 
    }  
}