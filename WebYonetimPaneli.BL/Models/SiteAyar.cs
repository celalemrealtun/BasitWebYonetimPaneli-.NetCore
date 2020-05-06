using System;
using System.Collections.Generic;
using System.Text;

namespace WebYonetimPaneli.BL.Models
{
    public class SiteAyar
    {
        public int ID { get; set; }
        public string SiteLogo { get; set; }
        public string SiteAdi { get; set; }
        public string SiteAnahtar { get; set; }
        public string SiteAciklama { get; set; }
        public string SiteURL { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string HaritaKonum { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string OrtaBaslik { get; set; }
        public string OrtaIcerik { get; set; }
        public string Hakkimizda { get; set; }
        public string VizyonMisyon { get; set; }
        public string Iletisim { get; set; }

    }
}
