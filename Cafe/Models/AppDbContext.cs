using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Cafe.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        public DbSet<CafeProduct> CafeProducts { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public DbSet<Sandwitch> Sandswitches { get; set; }

        public DbSet<Spicy> Spicys { get; set; }

        public DbSet<IceCream> iceCreams { get; set; }

        public DbSet<chocolate> chocolates { get; set; }



        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);

            //// تحديد المفتاح المركب (Composite Key) في IdentityUserLogin
            //modelbuilder.Entity<IdentityUserLogin<string>>()
            //    .HasKey(login => new { login.LoginProvider, login.ProviderKey });



            modelbuilder.Entity<Size>().HasData(

                new Size() { Id = 1, Name = "Small" },
                new Size() { Id = 2, Name = "Meduim" },
                new Size() { Id = 3, Name = "Big" }

                );


            modelbuilder.Entity<Spicy>().HasData(

                new Spicy() { SpicyId = 1, Name = "hot" },
                new Spicy() { SpicyId = 2, Name = "normal" }
                );
        }
        }
    }
