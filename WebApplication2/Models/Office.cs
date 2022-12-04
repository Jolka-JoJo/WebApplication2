using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Office
    {
        public Office()
        {
            Employees = new HashSet<Employee>();
        }

        public string OfficeCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
