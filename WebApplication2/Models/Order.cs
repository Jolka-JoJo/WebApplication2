using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; }
        public int CustomerNumber { get; set; }

        public virtual Customer CustomerNumberNavigation { get; set; }
    }
}
