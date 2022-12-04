using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Shared;

namespace WebApplication2.Data
{
    public class Customers:ITableData
    {
        public Customers(List<Customer> customers) { this.customers = customers; }
        public Customers() { }
        private List<Customer> customers { get; set; }

        public int getTotalRecordsNumber()
        {
            return customers.Count;
        }

        public Dictionary<string, int> getCustomersCitiesCounts()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var rez  = customers.GroupBy(x => x.City).Select(y=> new { City = y.Key, Count = y.Count() }).OrderBy(x => x.Count).ToList();
            rez.ForEach(x =>
            {
                result.Add(x.City, x.Count);
            });
            return result;
        }

    }
}
