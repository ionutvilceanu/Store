using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class ProductCart
    {
        public int ProductCartId { get; set; }
        public int CartId { get; set; }


        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
