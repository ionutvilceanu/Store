﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalaJocuriLicenta.Models
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public int NumberOfHours { get; set; } 


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        
    }
}
