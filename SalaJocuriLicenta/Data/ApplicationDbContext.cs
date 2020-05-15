using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalaJocuriLicenta.Models;

namespace SalaJocuriLicenta.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorit> Favorits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Card { get; set; }
        
        public object Cards { get; internal set; }
        
        public DbSet<SalaJocuriLicenta.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
