using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebYonetimPaneli.BL.Models;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    public class EfSliderRepository : EfGenericRepository<Slider>, ISliderRepository
    {
        public EfSliderRepository(EfContext context) : base(context)
        {
        }

        public EfContext EfContext
        {
            get { return context as EfContext; }
        }
        public List<Slider> Top5Slider()
        {
            return EfContext.Slider
              .OrderByDescending(i => i.ID)
              .Take(5)
              .ToList();
        }
    }
}
