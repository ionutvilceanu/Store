using Microsoft.EntityFrameworkCore;
using SalaJocuriLicenta.Data;
using SalaJocuriLicenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        private DbSet<Product> productEntity;

        IEnumerable<Product> IProductRepository.Products
        {
            get
            {
                return context.Products ;

            }
            set { }
        }


        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
            productEntity = context.Set<Product>();
        }


        public void SaveProduct(Product product)
        {
            context.Entry(product).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productEntity.AsEnumerable();
        }

        public Product GetProduct(long id)
        {
            return productEntity.SingleOrDefault(s => s.ProductId == id);
        }
        public void DeleteProduct(long id)
        {
            Product product = GetProduct(id);
            productEntity.Remove(product);
            context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            context.SaveChanges();
        }

    }
}
