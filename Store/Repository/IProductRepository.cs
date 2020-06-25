using SalaJocuriLicenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; set; }
        void SaveProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(long id);
        void DeleteProduct(long id);
        void UpdateProduct(Product product);
    }
}
