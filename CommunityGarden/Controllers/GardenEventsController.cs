using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommunityGarden.Data;
using CommunityGarden.Models;

namespace CommunityGarden.Controllers
{
    public class GardenEventsController : Controller
    {
        private readonly CommunityGardenContext _context;

        public GardenEventsController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: GardenEvents
        public async Task<IActionResult> Index()
        {
              return _context.GardenEvent != null ? 
                          View(await _context.GardenEvent.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.GardenEvent'  is null.");
        }

        // GET: GardenEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GardenEvent == null)
            {
                return NotFound();
            }

            var gardenEvent = await _context.GardenEvent
                .FirstOrDefaultAsync(m => m.GardenEventId == id);
            if (gardenEvent == null)
            {
                return NotFound();
            }

            return View(gardenEvent);
        }

        // GET: GardenEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GardenEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GardenEventId,GardenUserId,Date,Description")] GardenEvent gardenEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gardenEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gardenEvent);
        }

        // GET: GardenEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GardenEvent == null)
            {
                return NotFound();
            }

            var gardenEvent = await _context.GardenEvent.FindAsync(id);
            if (gardenEvent == null)
            {
                return NotFound();
            }
            return View(gardenEvent);
        }

        // POST: GardenEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GardenEventId,GardenUserId,Date,Description")] GardenEvent gardenEvent)
        {
            if (id != gardenEvent.GardenEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gardenEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenEventExists(gardenEvent.GardenEventId))
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
            return View(gardenEvent);
        }

        // GET: GardenEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GardenEvent == null)
            {
                return NotFound();
            }

            var gardenEvent = await _context.GardenEvent
                .FirstOrDefaultAsync(m => m.GardenEventId == id);
            if (gardenEvent == null)
            {
                return NotFound();
            }

            return View(gardenEvent);
        }

        // POST: GardenEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GardenEvent == null)
            {
                return Problem("Entity set 'CommunityGardenContext.GardenEvent'  is null.");
            }
            var gardenEvent = await _context.GardenEvent.FindAsync(id);
            if (gardenEvent != null)
            {
                _context.GardenEvent.Remove(gardenEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenEventExists(int id)
        {
          return (_context.GardenEvent?.Any(e => e.GardenEventId == id)).GetValueOrDefault();
        }
    }
}
