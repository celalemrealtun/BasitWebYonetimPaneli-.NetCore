using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebYonetimPaneli.BL.Models;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.UI.Controllers
{
    public class SiteAyarController : Controller
    {
        private readonly IUnitOfWork uow;
        public SiteAyarController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            var data = uow.SiteAyar.VeriGetir(1);
        
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSiteAyarAsync(SiteAyar Ayar, IFormFile Logo)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", Logo.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Logo.CopyToAsync(stream);

                        Ayar.SiteLogo = Logo.FileName;
                    }
                }

                uow.SiteAyar.Duzenle(Ayar);
                uow.SaveChanges();  
            }
             
            return RedirectToAction("Index");
        }
    }
}