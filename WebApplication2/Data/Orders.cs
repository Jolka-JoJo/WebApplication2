using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Shared;

namespace WebApplication2.Data
{
    public class Orders:ITableData
    {
        public Orders() { }
        public Orders(List<Order> orders) { this.orders = orders; }

        private List<Order> orders { get; set; }

        public int getTotalRecordsNumber()
        {
            return orders.Count;
        }

        

    }
}
