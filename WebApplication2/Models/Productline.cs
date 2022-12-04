using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Productline
    {
        public Productline()
        {
            Products = new HashSet<Product>();
        }

        public string ProductLine1 { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
