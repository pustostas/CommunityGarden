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
    public class PlantsController : Controller
    {
        private readonly CommunityGardenContext _context;

        public PlantsController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index()
        {
              return _context.Plant != null ? 
                          View(await _context.Plant.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.Plant'  is null.");
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plant == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant
                .FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantId,PlotId,HerbId,PlantDate,LastWatered,LastFertilized")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        // GET: Plants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plant == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantId,PlotId,HerbId,PlantDate,LastWatered,LastFertilized")] Plant plant)
        {
            if (id != plant.PlantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.PlantId))
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
            return View(plant);
        }

        // GET: Plants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plant == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant
                .FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plant == null)
            {
                return Problem("Entity set 'CommunityGardenContext.Plant'  is null.");
            }
            var plant = await _context.Plant.FindAsync(id);
            if (plant != null)
            {
                _context.Plant.Remove(plant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
          return (_context.Plant?.Any(e => e.PlantId == id)).GetValueOrDefault();
        }
    }
}
