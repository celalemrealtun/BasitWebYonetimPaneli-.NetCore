using System;
using System.Collections.Generic;
using System.Text;
using WebYonetimPaneli.BL.Models;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    class EfGaleriKategoriRepository : EfGenericRepository<GaleriKategori>, IGaleriKategoriRepository
    {
        public EfGaleriKategoriRepository(EfContext context) : base(context)
        {
        }

        public EfContext EfContext
        {
            get { return context as EfContext; }
        }
   
    }
}
