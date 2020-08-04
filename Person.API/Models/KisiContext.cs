using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Models
{
    public class KisiContext : DbContext
    {

        public KisiContext(DbContextOptions<KisiContext> options) : base(options)
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<PersonelBilgi> PersonelBilgileri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                   new Kisi { Id = 1, Ad = "AY", Soyad = "YILDIZ" },
                   new Kisi { Id = 2, Ad = "GÜNEŞ", Soyad = "MARS" },
                   new Kisi { Id = 3, Ad = "VENÜS", Soyad = "URANÜS" }
                   );
            modelBuilder.Entity<PersonelBilgi>().HasData(
                new PersonelBilgi { Id = 1, GirisTarihi = DateTime.Now, KisiId = 1 },
                new PersonelBilgi { Id = 2, GirisTarihi = DateTime.Now, KisiId = 2 },
                new PersonelBilgi { Id = 3, GirisTarihi = DateTime.Now, KisiId = 3 }
                );

            //base.OnModelCreating(modelBuilder);
        }
    }
}
