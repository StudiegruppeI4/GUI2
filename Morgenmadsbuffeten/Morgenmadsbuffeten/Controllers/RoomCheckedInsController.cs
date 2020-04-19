using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    public class RoomCheckedInsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomCheckedInsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomCheckedIns
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomsCheckedIn.ToListAsync());
        }

        // GET: RoomCheckedIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomCheckedIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,Date,Children,Adults")] RoomCheckedIn roomCheckedIn)
        {
            roomCheckedIn.Date = DateTime.Today;
            _context.Add(roomCheckedIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(roomCheckedIn);
        }

        // GET: RoomCheckedIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCheckedIn = await _context.RoomsCheckedIn.FindAsync(id);
            if (roomCheckedIn == null)
            {
                return NotFound();
            }
            return View(roomCheckedIn);
        }

        // POST: RoomCheckedIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,RoomNumber,Children,Adults")] RoomCheckedIn roomCheckedIn)
        {
            if (id != roomCheckedIn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomCheckedIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomCheckedInExists(roomCheckedIn.Id))
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
            return View(roomCheckedIn);
        }

        // GET: RoomCheckedIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCheckedIn = await _context.RoomsCheckedIn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomCheckedIn == null)
            {
                return NotFound();
            }

            return View(roomCheckedIn);
        }

        // POST: RoomCheckedIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomCheckedIn = await _context.RoomsCheckedIn.FindAsync(id);
            _context.RoomsCheckedIn.Remove(roomCheckedIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomCheckedInExists(int id)
        {
            return _context.RoomsCheckedIn.Any(e => e.Id == id);
        }
    }
}
