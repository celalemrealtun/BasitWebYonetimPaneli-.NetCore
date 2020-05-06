using System;
using System.Collections.Generic;
using System.Text;
using WebYonetimPaneli.BL.Models;

namespace WebYonetimPaneli.BL.ViewModels
{
    public class GaleriKategori_Galeri
    {
        public Galeri Galeri { get; set; }
        public List<GaleriKategori> GaleriKategoriler { get; set; }
    }
}
