using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebYonetimPaneli.DAL.Repository.Abstract;
using WebYonetimPaneli.UI.Models;

namespace WebYonetimPaneli.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork uow;
        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }


        public IActionResult Index()
        {
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
