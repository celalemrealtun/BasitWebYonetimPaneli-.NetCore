using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebYonetimPaneli.BL.Models
{
    public class Galeri
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen Resim Seçin.")]
        public string URL { get; set; }
     
        [Required(ErrorMessage = "Lütfen Açıklama Girin.")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Lütfen Kategori Seçin")]
        public int GaleriKategoriID { get; set; }
        public GaleriKategori GaleriKategori { get; set; }
    }
   
}
