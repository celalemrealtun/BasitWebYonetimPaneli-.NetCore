using System;
using System.Collections.Generic;
using System.Text;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EfContext dbContext;

        public EfUnitOfWork(EfContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("dbcontext bulunamadi.");
        }
        private ISiteAyarRepository _siteayar;
        private ISliderRepository _slider;
        private IGaleriKategoriRepository _galerikategori;
        private IGaleriRepository _galeri;


        public ISiteAyarRepository SiteAyar 
        {
            get
            {
                return _siteayar ?? (_siteayar = new  EfSiteAyarRepository(dbContext));
            }
        }

        public ISliderRepository Slider
        { 
            get
            {
                return _slider ?? (_slider = new EfSliderRepository(dbContext));
            }
        }

        public IGaleriKategoriRepository GaleriKategori
        {
            get
            {
                return _galerikategori ?? (_galerikategori = new EfGaleriKategoriRepository(dbContext));
            }
        }
        public IGaleriRepository Galeri
        {
            get
            {
                return _galeri ?? (_galeri = new EfGaleriRepository(dbContext));
            }
        }
        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
