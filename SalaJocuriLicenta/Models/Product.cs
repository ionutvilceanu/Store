using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string AvatarProduct { get; set; }
        public int ProductHours { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Favorit> Favorits { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }


    }
}
