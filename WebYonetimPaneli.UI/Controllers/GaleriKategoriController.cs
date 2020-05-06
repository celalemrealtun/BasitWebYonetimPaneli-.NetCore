using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebYonetimPaneli.BL.Models;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.UI.Controllers
{
    public class GaleriKategoriController : Controller
    {
        private readonly IUnitOfWork uow;
        public GaleriKategoriController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            var Data = uow.GaleriKategori.TumVerileriGetir();
            return View(Data);
        }
        [HttpGet]
        public IActionResult EkleDuzenle(int? ID)
        {
            if (ID == null)
            {
                return View(new GaleriKategori());
            }
            else
            {
                return View(uow.GaleriKategori.VeriGetir((int)ID));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EkleDuzenle(GaleriKategori Kategori)
        {
            if (ModelState.IsValid)
            {
                if (Kategori.ID > 0)
                {
                    uow.GaleriKategori.Duzenle(Kategori);
                }
                else
                {
                    uow.GaleriKategori.Ekle(Kategori);
                }
                uow.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int ID)
        {
            if (ModelState.IsValid)
            {
                if (ID > 0)
                {
                    GaleriKategori Data = uow.GaleriKategori.VeriGetir(ID);
                    uow.GaleriKategori.Sil(Data);
                    uow.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }
       
    }
}