using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Controllers
{
    public class CalendaryTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendaryTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TreatmentTimes
        public async Task<IActionResult> Index()
        {
            return _context.TreatmentTime != null ?
                        View(await _context.TreatmentTime.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.TreatmentTime'  is null.");
        }

        // GET: TreatmentTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TreatmentTime == null)
            {
                return NotFound();
            }

            var treatmentTime = await _context.TreatmentTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentTime == null)
            {
                return NotFound();
            }

            return View(treatmentTime);
        }

        // GET: TreatmentTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreatmentTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time")] CalendaryTime calendaryTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendaryTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendaryTime);
        }

        // GET: TreatmentTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalendaryTime == null)
            {
                return NotFound();
            }

            var calendaryTime = await _context.CalendaryTime.FindAsync(id);
            if (calendaryTime == null)
            {
                return NotFound();
            }
            return View(calendaryTime);
        }

        // POST: TreatmentTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time")] CalendaryTime calendaryTime)
        {
            if (id != calendaryTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendaryTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentTimeExists(calendaryTime.Id))
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
            return View(calendaryTime);
        }

        // GET: TreatmentTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalendaryTime == null)
            {
                return NotFound();
            }

            var calendaryTime = await _context.CalendaryTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendaryTime == null)
            {
                return NotFound();
            }

            return View(calendaryTime);
        }

        // POST: TreatmentTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalendaryTime == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TreatmentTime'  is null.");
            }
            var calendaryTime = await _context.CalendaryTime.FindAsync(id);
            if (calendaryTime != null)
            {
                _context.TreatmentTime.Remove(calendaryTime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentTimeExists(int id)
        {
            return (_context.TreatmentTime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
