using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class Stock3Controller : Controller
    {
        private readonly StockContext _context;

        public Stock3Controller(StockContext context)
        {
            _context = context;
        }

        // GET: Stock3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stocks3.ToListAsync());
        }

        // GET: Stock3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock3 = await _context.Stocks3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock3 == null)
            {
                return NotFound();
            }

            return View(stock3);
        }

        // GET: Stock3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stock3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Open,Close,High,Low,Type")] Stock3 stock3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock3);
        }

        // GET: Stock3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock3 = await _context.Stocks3.FindAsync(id);
            if (stock3 == null)
            {
                return NotFound();
            }
            return View(stock3);
        }

        // POST: Stock3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Open,Close,High,Low,Type")] Stock3 stock3)
        {
            if (id != stock3.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Stock3Exists(stock3.ID))
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
            return View(stock3);
        }

        // GET: Stock3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock3 = await _context.Stocks3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock3 == null)
            {
                return NotFound();
            }

            return View(stock3);
        }

        // POST: Stock3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock3 = await _context.Stocks3.FindAsync(id);
            _context.Stocks3.Remove(stock3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Stock3Exists(string id)
        {
            return _context.Stocks3.Any(e => e.ID == id);
        }
    }
}
