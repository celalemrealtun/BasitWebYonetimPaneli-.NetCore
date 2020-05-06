using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebYonetimPaneli.BL.Models
{
    public class Slider
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }
        [Required]
        public string Icerik { get; set; }
        [Required]
        public string URL { get; set; }
        public bool KayitSilindi { get; set; }
    }
}
