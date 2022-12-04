using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Customer : Person
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? SalesRepEmployeeNumber { get; set; }

        public virtual Employee SalesRepEmployeeNumberNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
