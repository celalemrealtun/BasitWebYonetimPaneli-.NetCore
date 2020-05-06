using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebYonetimPaneli.BL.Models;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    public static class DbData
    {
        public static void DbDataDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<EfContext>();
            context.Database.Migrate();

            if (!context.SiteAyar.Any()) //Site Genel ayarları
            {
                var SiteAyarlari = new[]
                {
                    new SiteAyar()
                    {

                        SiteLogo="",
                        SiteAdi = "kurumsal site",
                        SiteAnahtar ="www.kurumsalsite.com",
                        SiteAciklama ="www.kurumsalsite.com",
                        SiteURL ="www.kurumsalsite.com",
                        Telefon ="+90 530 330 30 30",
                        Email ="info@kurumsal.com",
                        Adres ="Nisbetiye, Aydın Sokağı No:7, 34340 Beşiktaş/İstanbul",
                        HaritaKonum ="@41.0723283,29.0144242,15.25z/data=!4m12!1m6!3m5!1s0x0:0xc09fa703bd286117!2s!8m2!3d41.0708535!4d29.0178792!3m4!1s0x0:0xc09fa703bd286117!8m2!3d41.0708535!4d29.0178792",
                        Facebook ="www.facebook.com",
                        Instagram ="www.instagram.com",
                        Twitter ="www.twitter.com",
                        OrtaBaslik ="Orta Başlık",
                        OrtaIcerik ="Orta İçerik",
                        Hakkimizda ="Hakkımızda içerik",
                        VizyonMisyon ="Vizyonumuz Misyonumuz",
                        Iletisim="",
                    }
                };
                context.SiteAyar.AddRange(SiteAyarlari);
                context.SaveChanges();
            }

            if (!context.Slider.Any()) //Slider ayarları
            {
                var SliderAyarlari = new[]
                {
                    new Slider()
                    {
                         
                        Baslik="",
                        Icerik="",
                        URL="",
                        KayitSilindi=false,
                    }
                };
                context.Slider.AddRange(SliderAyarlari);
                context.SaveChanges();
            }
            if (!context.GaleriKategori.Any())  
            {
                var GaleriKategori = new[]
                {
                    new GaleriKategori()
                    {
                         KategoriAdi="Galeri Kategori 1"
                    }
                };
                context.GaleriKategori.AddRange(GaleriKategori);
                context.SaveChanges();
            }
            if (!context.Galeri.Any()) 
            {
                var Galeri = new[]
                {
                    new Galeri()
                    {
                          Aciklama="YeniResim",
                          URL="",
                          GaleriKategoriID=1,
                    }
                };
                context.Galeri.AddRange(Galeri);
                context.SaveChanges();
            }
        }
    }
}
