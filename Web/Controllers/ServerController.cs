using ArgentumAtlas.ViewModels;
using DataLayer;
using DataLayer.Repositories;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ArgentumAtlas.Controllers;

public class ServerController : Controller
{
    private readonly IRepository<Platform> _repository;
    private readonly IRepository<Server> _repoServer;

    public ServerController(IRepository<Platform> repository, IRepository<Server> repoServer)
    {
        _repository = repository;
        _repoServer = repoServer;

    }

    [HttpGet]
    public async Task<ViewResult> Add()
    {
        var checkBoxes = (await _repository.GetListAsync(new QueryOptions<Platform>()))
            .Select(p => new CheckBoxOption
            {
                IsCheck = false,
                Description = p.Name.ToLower(),
                Value = p.PlatformId.ToString()
            }).ToList();

        var model = new ServerCreateViewModel
        {
            CheckBoxes = checkBoxes
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ServerCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var imageName = Guid.NewGuid()
                .ToString()
                .Replace("-", "");
            var extension = Path.GetExtension(model.FileImage.FileName);

            var path = Path.Combine("wwwroot", "images", "server", imageName) + extension;

            var server = new Server
            {
                Name = model.Name,
                Content = model.Content,
                Website = model.Website,
                Discord = model.Discord,
                BannerURL = $"/images/server/{imageName}{extension}",
                ServerPlatforms = new Collection<ServerPlatform>()
            };

            foreach(var id in model.SelectedPlatforms)
            {
                server.ServerPlatforms.Add(new ServerPlatform
                {
                    PlatformId = id,
                });
            }

            //foreach (var id in model.SelectedPlatforms)
            //{
            //    server.Platforms.Add(new Platform
            //    {
            //        PlatformId = id,
            //    });
            //}

            _repoServer.Insert(server);
            await _repository.SaveAsync();

            await using var stream = new FileStream(path, FileMode.Create);
            await model.FileImage.CopyToAsync(stream);

            return RedirectToAction("Index", "Home");
        }

        var checkBoxes = (await _repository.GetListAsync(new QueryOptions<Platform>()))
            .Select(p => new CheckBoxOption
            {
                IsCheck = false,
                Description = p.Name.ToLower(),
                Value = p.PlatformId.ToString()
            }).ToList();

        if (model.SelectedPlatforms != null)
        {
            checkBoxes.ForEach(c =>
            {
                if (model.SelectedPlatforms.Contains(int.Parse(c.Value)))
                {
                    c.IsCheck = true;
                }
            });
        }

        model.CheckBoxes = checkBoxes;
        return View(model);
    }

    public ViewResult Details(int id)
    {
        return View();
    }
}