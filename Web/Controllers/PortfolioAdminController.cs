using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Intarfaces;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PortfolioAdminController : Controller
    {
        private readonly IUnitOfWork<PortfolioItem> _portfolio;
        private readonly IHostingEnvironment _hosting;

        public PortfolioAdminController(IUnitOfWork<PortfolioItem> portfolio , IHostingEnvironment hosting)
        {
            _portfolio = portfolio;
            _hosting = hosting;
        }


        public IActionResult Index()
        {
            return View(_portfolio.repo.getAll());
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            PortfolioItem portfolio = _portfolio.repo.GetBYId(id);

            if(portfolio == null)
            {
                ModelState.AddModelError("", "not found");
            }

            PortfolioViewModel model = new PortfolioViewModel
            {
                ProjectName = portfolio.ProjectName,
                Description = portfolio.Description,
                Id = portfolio.Id,
                ImageUrl = portfolio.ImageUrl
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id , PortfolioViewModel model)
        {
            //save image
            if(model.file != null)
            {
                string path = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath = Path.Combine(path, model.file.FileName);
                model.file.CopyTo(new FileStream(fullPath, FileMode.Create));

            }

            PortfolioItem portfolio = new PortfolioItem
            {
                Description = model.Description,
                ImageUrl = model.file.FileName,
                ProjectName = model.ProjectName,
                Id = model.Id
            };
            _portfolio.repo.update(portfolio);
            _portfolio.save();

            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();


        }

        [HttpPost]
        public IActionResult Create(PortfolioViewModel portfolio)
        {

            if (ModelState.IsValid)
            {
                if(portfolio.file != null)
                {
                    string path = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(path, portfolio.file.FileName);
                    portfolio.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                PortfolioItem item = new PortfolioItem()
                {
                    Description = portfolio.Description,
                    ImageUrl = portfolio.file.FileName,
                    ProjectName = portfolio.ProjectName

                };

                _portfolio.repo.insert(item);
                _portfolio.save();

               
            }
            return Redirect("Index");
        }


        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View(_portfolio.repo.GetBYId(id));
        }

        [HttpPost]
        public IActionResult Delete(PortfolioItem item)
        {
            _portfolio.repo.delete(item);
            _portfolio.save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            
            return View(_portfolio.repo.GetBYId(id));

        }

    }
}