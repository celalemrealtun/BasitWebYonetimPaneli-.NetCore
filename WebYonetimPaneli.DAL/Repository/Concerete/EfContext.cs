using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebYonetimPaneli.BL.Models;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        { 
        
        }

        public DbSet<SiteAyar> SiteAyar { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<GaleriKategori> GaleriKategori { get; set; }
        public DbSet<Galeri> Galeri { get; set; }

        
    }
}

