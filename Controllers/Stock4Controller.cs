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
    public class Stock4Controller : Controller
    {
        private readonly StockContext _context;

        public Stock4Controller(StockContext context)
        {
            _context = context;
        }

        // GET: Stock4
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stocks4.ToListAsync());
        }

        // GET: Stock4/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock4 = await _context.Stocks4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock4 == null)
            {
                return NotFound();
            }

            return View(stock4);
        }

        // GET: Stock4/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stock4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Open,Close,High,Low,Type")] Stock4 stock4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock4);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock4);
        }

        // GET: Stock4/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock4 = await _context.Stocks4.FindAsync(id);
            if (stock4 == null)
            {
                return NotFound();
            }
            return View(stock4);
        }

        // POST: Stock4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Open,Close,High,Low,Type")] Stock4 stock4)
        {
            if (id != stock4.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock4);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Stock4Exists(stock4.ID))
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
            return View(stock4);
        }

        // GET: Stock4/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock4 = await _context.Stocks4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock4 == null)
            {
                return NotFound();
            }

            return View(stock4);
        }

        // POST: Stock4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock4 = await _context.Stocks4.FindAsync(id);
            _context.Stocks4.Remove(stock4);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Stock4Exists(string id)
        {
            return _context.Stocks4.Any(e => e.ID == id);
        }
    }
}
