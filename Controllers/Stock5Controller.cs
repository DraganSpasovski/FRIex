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
    public class Stock5Controller : Controller
    {
        private readonly StockContext _context;

        public Stock5Controller(StockContext context)
        {
            _context = context;
        }

        // GET: Stock5
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stocks5.ToListAsync());
        }

        // GET: Stock5/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock5 = await _context.Stocks5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock5 == null)
            {
                return NotFound();
            }

            return View(stock5);
        }

        // GET: Stock5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stock5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Open,Close,High,Low,Type")] Stock5 stock5)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock5);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock5);
        }

        // GET: Stock5/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock5 = await _context.Stocks5.FindAsync(id);
            if (stock5 == null)
            {
                return NotFound();
            }
            return View(stock5);
        }

        // POST: Stock5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Open,Close,High,Low,Type")] Stock5 stock5)
        {
            if (id != stock5.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock5);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Stock5Exists(stock5.ID))
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
            return View(stock5);
        }

        // GET: Stock5/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock5 = await _context.Stocks5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stock5 == null)
            {
                return NotFound();
            }

            return View(stock5);
        }

        // POST: Stock5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock5 = await _context.Stocks5.FindAsync(id);
            _context.Stocks5.Remove(stock5);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Stock5Exists(string id)
        {
            return _context.Stocks5.Any(e => e.ID == id);
        }
    }
}
