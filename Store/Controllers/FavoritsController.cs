using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaJocuriLicenta.Data;
using SalaJocuriLicenta.Models;

namespace SalaJocuriLicenta.Controllers
{
    public class FavoritsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favorits
        public async Task<IActionResult> Index()
        {
            var favorits = from o in _context.Favorits
                         select o;
            favorits = _context.Favorits.Include(g => g.Product);
            return View(await favorits.ToListAsync());
        }

        

        // GET: Favorits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorit = await _context.Favorits
                .Include(f => f.Product)
                .SingleOrDefaultAsync(m => m.FavoritId == id);
            if (favorit == null)
            {
                return NotFound();
            }

            return View(favorit);
        }

        // GET: Favorits/Create
        public IActionResult Create(int? ProductId)
        {
            ViewData["ProductId"] = ProductId;
            return View();
        }

        // POST: Favorits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoritId,ProductId")] Favorit favorit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", favorit.ProductId);
            return View(favorit);
        }

        // GET: Favorits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorit = await _context.Favorits.SingleOrDefaultAsync(m => m.FavoritId == id);
            if (favorit == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", favorit.ProductId);
            return View(favorit);
        }

        // POST: Favorits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoritId,ProductId")] Favorit favorit)
        {
            if (id != favorit.FavoritId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritExists(favorit.FavoritId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", favorit.ProductId);
            return View(favorit);
        }

        // GET: Favorits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorit = await _context.Favorits
                .Include(f => f.Product)
                .SingleOrDefaultAsync(m => m.FavoritId == id);
            if (favorit == null)
            {
                return NotFound();
            }

            return View(favorit);
        }

        // POST: Favorits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorit = await _context.Favorits.SingleOrDefaultAsync(m => m.FavoritId == id);
            _context.Favorits.Remove(favorit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritExists(int id)
        {
            return _context.Favorits.Any(e => e.FavoritId == id);
        }
    }
}
