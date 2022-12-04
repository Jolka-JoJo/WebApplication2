using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Shared;

namespace WebApplication2.Data
{
    public class Products:ITableData
    {
        public Products() { }
        public Products(List<Product> products) { this.products = products; }
        private List<Product> products { get; set; }

        public int getTotalRecordsNumber()
        {
            return products.Count;
        }

        public Dictionary<string, decimal> getLowestPriceProduct()
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            var temp = products.Where(y => y.BuyPrice == products.Min(x => x.BuyPrice));
            result.Add(temp.First().ProductName, temp.First().BuyPrice);
            return result;
        }

        public Dictionary<string, decimal> getHighestPriceProduct()
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            var temp = products.Where(y => y.BuyPrice == products.Max(x => x.BuyPrice));
            result.Add(temp.First().ProductName, temp.First().BuyPrice);
            return result;
        }
    }
}
