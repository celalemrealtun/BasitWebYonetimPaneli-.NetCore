using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebYonetimPaneli.BL.Models;

namespace WebYonetimPaneli.DAL.Repository.Abstract
{
   public interface ISliderRepository: IGenericRepository<Slider>
    {
        List<Slider> Top5Slider();
    }
}
