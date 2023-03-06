using System.Diagnostics;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
using DomainModels;
using Microsoft.AspNetCore.Mvc; 

namespace ArgentumAtlas.Controllers;

public class HomeController : Controller
{
    private IRepository<ServerInfo> _repository;

    public HomeController(IRepository<ServerInfo> repository)
    {
        _repository = repository;
    } 
    
    public async Task<ViewResult> Index()
    {
        var model = await _repository.GetListAsync(); 
        return View(model); 
    }

    public IActionResult Privacy()
    {
        return View();
    } 
}