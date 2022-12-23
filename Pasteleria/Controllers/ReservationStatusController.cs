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
    public class ReservationStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingStatus
        public async Task<IActionResult> Index()
        {
            return _context.ReservationStatus != null ?
                        View(await _context.ReservationStatus.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.ReservationStatus'  is null.");
        }

        // GET: BookingStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReservationStatus == null)
            {
                return NotFound();
            }

            var reservationStatus = await _context.ReservationStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationStatus == null)
            {
                return NotFound();
            }

            return View(reservationStatus);
        }

        // GET: BookingStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] ReservationStatus reservationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationStatus);
        }

        // GET: BookingStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReservationStatus == null)
            {
                return NotFound();
            }

            var reservationStatus = await _context.ReservationStatus.FindAsync(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }
            return View(reservationStatus);
        }

        // POST: BookingStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] ReservationStatus bookingStatus)
        {
            if (id != reservationStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationStatusExists(bookingStatus.Id))
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
            return View(reservationStatus);
        }

        // GET: BookingStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReservationStatus == null)
            {
                return NotFound();
            }

            var reservationStatus = await _context.ReservationStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationStatus == null)
            {
                return NotFound();
            }

            return View(reservationStatus);
        }

        // POST: BookingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservationStatus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookingStatus'  is null.");
            }
            var reservationStatus = await _context.ReservationStatus.FindAsync(id);
            if (reservationStatus != null)
            {
                _context.ReservationStatus.Remove(reservationStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationStatusExists(int id)
        {
            return (_context.ReservationStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}