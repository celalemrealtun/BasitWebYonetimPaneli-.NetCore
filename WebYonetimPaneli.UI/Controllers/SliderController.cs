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
    public class SliderController : Controller
    {
        private readonly IUnitOfWork uow;
        public SliderController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            var Data = uow.Slider.TumVerileriGetir().Where(ce => ce.KayitSilindi == false);
            return View(Data);
        }

        [HttpGet]
        public IActionResult EkleDuzenle(int? ID)
        {
            if (ID == null)
            {
                return View(new Slider());
            }
            else
            {
                return View(uow.Slider.VeriGetir((int)ID));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EkleDuzenle(Slider slider, IFormFile Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\slider", Resim.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Resim.CopyToAsync(stream);

                        slider.URL = Resim.FileName;
                    }
                }

                if (slider.ID>0)
                {
                    uow.Slider.Duzenle(slider);
                }
                else
                {
                    slider.KayitSilindi = false;
                    uow.Slider.Ekle(slider);
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
                    var data = uow.Slider.VeriGetir(ID);
                    data.KayitSilindi = true;
                    
                    string stryol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\slider", data.URL);
                    if (System.IO.File.Exists(stryol))
                    {
                        System.IO.File.Delete(stryol);
                    }

                    uow.Slider.Duzenle(data);
                    uow.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
 
    }
}