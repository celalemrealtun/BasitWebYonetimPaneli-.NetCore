using System;
using System.Collections.Generic;
using System.Text;

namespace WebYonetimPaneli.DAL.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ISiteAyarRepository SiteAyar { get; }
        ISliderRepository Slider { get; }
        IGaleriKategoriRepository GaleriKategori { get; }
        IGaleriRepository Galeri { get; }
 //Devami Yazılacak.
        int SaveChanges();
    }
}
