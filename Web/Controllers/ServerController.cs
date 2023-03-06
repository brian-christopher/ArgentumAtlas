using System;
using System.IO;
using System.Threading.Tasks;
using ArgentumAtlas.ViewModels;
using DataLayer.Repositories;
using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace ArgentumAtlas.Controllers;

public class ServerController : Controller
{
    private readonly IRepository<ServerInfo> _repository;

    public ServerController(IRepository<ServerInfo> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ViewResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddServerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var imageName = Guid.NewGuid()
                .ToString()
                .Replace("-", "");
            var extension = Path.GetExtension(model.FileImage.FileName);

            var path = Path.Combine("wwwroot", "images", "server", imageName) + extension;

            await using var stream = new FileStream(path, FileMode.Create);
            await model.FileImage.CopyToAsync(stream);
            
            var server = new ServerInfo
            {
                Name =  model.Name,
                Content = model.Content,
                BannerURL = $"/images/server/{imageName}{extension}"
            };
            
            _repository.Insert(server);
            await _repository.SaveAsync();

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
}