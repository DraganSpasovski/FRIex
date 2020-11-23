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
    public class Stock2Controller : Controller
    {
        private readonly StockContext _context;

        public Stock2Controller(StockContext context)
        {
            _context = context;
        }

        // GET: Stock2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stocks2.ToListAsync());
        }

        // GET: Stock2/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock2 = await _context.Stocks2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock2 == null)
            {
                return NotFound();
            }

            return View(stock2);
        }

        // GET: Stock2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stock2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Open,Close,High,Low,Type")] Stock2 stock2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock2);
        }

        // GET: Stock2/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock2 = await _context.Stocks2.FindAsync(id);
            if (stock2 == null)
            {
                return NotFound();
            }
            return View(stock2);
        }

        // POST: Stock2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Open,Close,High,Low,Type")] Stock2 stock2)
        {
            if (id != stock2.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Stock2Exists(stock2.ID))
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
            return View(stock2);
        }

        // GET: Stock2/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock2 = await _context.Stocks2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock2 == null)
            {
                return NotFound();
            }

            return View(stock2);
        }

        // POST: Stock2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock2 = await _context.Stocks2.FindAsync(id);
            _context.Stocks2.Remove(stock2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Stock2Exists(string id)
        {
            return _context.Stocks2.Any(e => e.ID == id);
        }
    }
}
