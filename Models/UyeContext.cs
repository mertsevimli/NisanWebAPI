using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // bu class da EntitiyFrameworkCore kullanacağız.





namespace NisanWebAPI.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }
         public DbSet<Urun> Urunler { get; set; } // Terminalden yeni migration oluşturuyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(localdb)/MSSQLLocalDb; database=UyeDb; integrated security=true; TrustServerCertificate=True ");
            optionsBuilder.UseSqlServer("Server=localhost;Database=MVCEgitim;User Id=SA;Password=Lebron234gizem;TrustServerCertificate=True;");
        //    optionsBuilder.UseInMemoryDatabase("UyeDb"); // InMemoryDatebase kullanmak için 
        



            base.OnConfiguring(optionsBuilder);
        }

    }
}