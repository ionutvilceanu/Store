using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int NoProducts { get; set; }
        public float TotalPrice { get; set; }


        //public int UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<ProductCart> ProductCarts { get; set; }
    }
}
