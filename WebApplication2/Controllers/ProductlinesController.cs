using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductlinesController : Controller
    {
        private readonly new_databaseContext _context;

        public ProductlinesController(new_databaseContext context)
        {
            _context = context;
        }

        // GET: Productlines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productlines.ToListAsync());
        }

        // GET: Productlines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productline = await _context.Productlines
                .FirstOrDefaultAsync(m => m.ProductLine1 == id);
            if (productline == null)
            {
                return NotFound();
            }

            return View(productline);
        }

        // GET: Productlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductLine1,TextDescription,HtmlDescription,Image")] Productline productline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productline);
        }

        // GET: Productlines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productline = await _context.Productlines.FindAsync(id);
            if (productline == null)
            {
                return NotFound();
            }
            return View(productline);
        }

        // POST: Productlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductLine1,TextDescription,HtmlDescription,Image")] Productline productline)
        {
            if (id != productline.ProductLine1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductlineExists(productline.ProductLine1))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productline);
        }

        // GET: Productlines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productline = await _context.Productlines
                .FirstOrDefaultAsync(m => m.ProductLine1 == id);
            if (productline == null)
            {
                return NotFound();
            }

            return View(productline);
        }

        // POST: Productlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productline = await _context.Productlines.FindAsync(id);
            _context.Productlines.Remove(productline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductlineExists(string id)
        {
            return _context.Productlines.Any(e => e.ProductLine1 == id);
        }
    }
}
