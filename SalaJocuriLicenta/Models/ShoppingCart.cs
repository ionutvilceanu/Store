using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int TotalCost { get; set; }
        

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

     
    }
}
