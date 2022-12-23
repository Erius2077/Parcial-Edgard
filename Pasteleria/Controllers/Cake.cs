using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;

namespace Cake.Controllers
{
    public class CakeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CakeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treatments
        public async Task<IActionResult> Index()
        {
            return _context.Cake != null ?
                        View(await _context.Cake.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cake'  is null.");
        }

        // GET: Treatments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var treatment = await _context.Cake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // GET: Treatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Image")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cake);
        }

        // GET: Treatments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Treatment.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            return View(cake);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Description,Image")] Cake cake)
        {
            if (id != cake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(cake.Id))
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
            return View(cake);
        }

        // GET: Treatments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cake == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cake == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Treatment'  is null.");
            }
            var cake = await _context.Cake.FindAsync(id);
            if (cake != null)
            {
                _context.Treatment.Remove(cake);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
