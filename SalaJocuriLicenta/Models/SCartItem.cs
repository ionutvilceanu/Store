using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class SCartItem
    {
        public int SCartItemId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
        public string SCartId { get; set; }
        public virtual SCart SCart { get; set; }
    }
}
