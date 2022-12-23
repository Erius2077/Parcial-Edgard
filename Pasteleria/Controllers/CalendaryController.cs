using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;

namespace Pasteleria.Controllers
{
    public class CalendaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            return _context.Calendary != null ?
                        View(await _context.Calendary.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Schedule'  is null.");
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _context.Calendary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendary == null)
            {
                return NotFound();
            }

            return View(calendary);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Calendary calendary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendary);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _context.Calendary.FindAsync(id);
            if (calendary == null)
            {
                return NotFound();
            }
            return View(calendary);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] Calendary calendary)
        {
            if (id != calendary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(calendary.Id))
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
            return View(calendary);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calendary == null)
            {
                return NotFound();
            }

            var calendary = await _context.Calendary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendary == null)
            {
                return NotFound();
            }

            return View(calendary);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendary == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calendary'  is null.");
            }
            var calendary = await _context.Calendary.FindAsync(id);
            if (calendary != null)
            {
                _context.Schedule.Remove(calendary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendaryExists(int id)
        {
            return (_context.Calendary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}