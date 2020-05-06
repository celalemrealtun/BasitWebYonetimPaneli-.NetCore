using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebYonetimPaneli.BL.Models
{
    public class GaleriKategori
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string KategoriAdi { get; set; }
        public List<Galeri> Galeri { get; set; }
    }
}
