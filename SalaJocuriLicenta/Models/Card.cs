using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }

        
    }
}
