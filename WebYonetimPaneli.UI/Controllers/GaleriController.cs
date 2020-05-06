using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebYonetimPaneli.BL.Models;
using WebYonetimPaneli.BL.ViewModels;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.UI.Controllers
{
    public class GaleriController : Controller
    {
        private readonly IUnitOfWork uow;
        public GaleriController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            var Data = uow.Galeri.TumVerileriGetir()
                .Include(g => g.GaleriKategori);

            return View(Data);
        }
        [HttpGet]
        public IActionResult EkleDuzenle(int? ID)
        {
            if (ID == null)
            {
                var model = new GaleriKategori_Galeri()
                {
                    Galeri = new Galeri(),
                    GaleriKategoriler = uow.GaleriKategori.TumVerileriGetir().ToList()
                };
                return View(model);
            }
            else
            {
                var model = new GaleriKategori_Galeri()
                {
                    Galeri = uow.Galeri.VeriGetir((int)ID),
                    GaleriKategoriler = uow.GaleriKategori.TumVerileriGetir().ToList()
                };
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EkleDuzenle(Galeri Galeri, IFormFile Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\galeri", Resim.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Resim.CopyToAsync(stream);

                        Galeri.URL = Resim.FileName;
                    }
                }

                if (Galeri.ID > 0)
                {
                    uow.Galeri.Duzenle(Galeri);
                }
                else
                {
                    uow.Galeri.Ekle(Galeri);
                }
                uow.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("EkleDuzenle",Galeri.ID);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int ID)
        {
            if (ModelState.IsValid)
            {
                if (ID > 0)
                {
                    Galeri Data = uow.Galeri.VeriGetir(ID);
                    string stryol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\galeri", Data.URL);
                    if (System.IO.File.Exists(stryol))
                    {
                        System.IO.File.Delete(stryol);
                    }
                    uow.Galeri.Sil(Data);
                    uow.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}