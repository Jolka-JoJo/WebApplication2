using System.Collections.Generic;
using System.Linq;
using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication2.Shared;

namespace WebApplication2.Data
{
    public class Employees : ITableData
    {
        public Employees() {}
        public Employees(List<Employee> employees) { this.employees = employees; }

        private List<Employee> employees { get; set; }

        public int getTotalRecordsNumber()
        {
            return employees.Count;
        }

        public Dictionary<string, int> getOfficeEmployeeCount(List<Office> offices)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var rez = employees
                .GroupBy(x => x.OfficeCode)
                
                .Select(y => new { OfficeCode = y.Key, Count = y.Count() })
                .ToList();

            //var rez2 = from employee in employees
            //           join office in offices
            //           on employee.OfficeCode equals office.OfficeCode into emplOffice
            //           from e in emplOffice
            //           group e by e.OfficeCode into emplOffice
            //           select new { emplOffice };

            ////var rez3 = from office in offices
            ////           join employee in employees
            ////           on office.OfficeCode equals employee.OfficeCode into emplOffice
            ////           from e in emplOffice
            ////           group e by e.City into emplOffice  
            ////           select new { City = emplOffice.City, Count = emplOffice.Count() };
            rez.ForEach(x =>
            {
                var city = offices.Find(y => x.OfficeCode == y.OfficeCode).City;
                result.Add(city, x.Count);
            });
            return result;
        }

        public Dictionary<string, int> getOfficeEmployeeCount(Office office)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var rez = employees
                .GroupBy(x => x.OfficeCode)
                .Select(y => new { OfficeCode = office.City, Count = y.Count() })
                .Where(z => z.OfficeCode == office.OfficeCode).First();
            
            result.Add(office.City, rez.Count);
            return result;
        }
    }
}
