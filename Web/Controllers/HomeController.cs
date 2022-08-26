using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Intarfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        IUnitOfWork<Owner> _owner;
        IUnitOfWork<PortfolioItem> _portfolio;
        public HomeController(IUnitOfWork<Owner>owner , IUnitOfWork<PortfolioItem>portfolio)
        {
            _owner = owner;
            _portfolio = portfolio;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Owner = _owner.repo.getAll().First(),
                PortfolioItems = _portfolio.repo.getAll().ToList()
            };

            return View(homeViewModel);
        }
    }
}