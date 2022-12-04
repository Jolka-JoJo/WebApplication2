using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly new_databaseContext _context;
        private readonly ILogger _logger;

        public CustomersController(new_databaseContext context, ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var new_databaseContext = _context.Customers.Include(c => c.SalesRepEmployeeNumberNavigation);
            _logger.LogInformation("Completed GET customers request");
            return View(await new_databaseContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.SalesRepEmployeeNumberNavigation)
                .FirstOrDefaultAsync(m => m.CustomerNumber == id);
            if (customer == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Completed GET customer request");

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["SalesRepEmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "Email");
            _logger.LogInformation("Completed GET customers create request");

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerNumber,LastName,FirstName,Phone,Address,City,Country,SalesRepEmployeeNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesRepEmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "Email", customer.SalesRepEmployeeNumber);
            _logger.LogInformation("Completed POST customer request");

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["SalesRepEmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "Email", customer.SalesRepEmployeeNumber);
            _logger.LogInformation("Completed GET customer  edit request");
            _logger.LogWarning("Completed GET customer  edit request");

            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerNumber,LastName,FirstName,Phone,Address,City,Country,SalesRepEmployeeNumber")] Customer customer)
        {
            if (id != customer.CustomerNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerNumber))
                    {
                        _logger.LogError("Customer not found");

                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError("Customer has no CustomerNumber");

                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesRepEmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "Email", customer.SalesRepEmployeeNumber);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.SalesRepEmployeeNumberNavigation)
                .FirstOrDefaultAsync(m => m.CustomerNumber == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerNumber == id);
        }
    }
}
