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
    public class GardenExpertsController : Controller
    {
        private readonly CommunityGardenContext _context;

        public GardenExpertsController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: GardenExperts
        public async Task<IActionResult> Index()
        {
              return _context.GardenExpert != null ? 
                          View(await _context.GardenExpert.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.GardenExpert'  is null.");
        }

        // GET: GardenExperts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GardenExpert == null)
            {
                return NotFound();
            }

            var gardenExpert = await _context.GardenExpert
                .FirstOrDefaultAsync(m => m.GardenExpertId == id);
            if (gardenExpert == null)
            {
                return NotFound();
            }

            return View(gardenExpert);
        }

        // GET: GardenExperts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GardenExperts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GardenExpertId,ExpertBio,PriceList")] GardenExpert gardenExpert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gardenExpert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gardenExpert);
        }

        // GET: GardenExperts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GardenExpert == null)
            {
                return NotFound();
            }

            var gardenExpert = await _context.GardenExpert.FindAsync(id);
            if (gardenExpert == null)
            {
                return NotFound();
            }
            return View(gardenExpert);
        }

        // POST: GardenExperts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GardenExpertId,ExpertBio,PriceList")] GardenExpert gardenExpert)
        {
            if (id != gardenExpert.GardenExpertId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gardenExpert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenExpertExists(gardenExpert.GardenExpertId))
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
            return View(gardenExpert);
        }

        // GET: GardenExperts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GardenExpert == null)
            {
                return NotFound();
            }

            var gardenExpert = await _context.GardenExpert
                .FirstOrDefaultAsync(m => m.GardenExpertId == id);
            if (gardenExpert == null)
            {
                return NotFound();
            }

            return View(gardenExpert);
        }

        // POST: GardenExperts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GardenExpert == null)
            {
                return Problem("Entity set 'CommunityGardenContext.GardenExpert'  is null.");
            }
            var gardenExpert = await _context.GardenExpert.FindAsync(id);
            if (gardenExpert != null)
            {
                _context.GardenExpert.Remove(gardenExpert);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenExpertExists(int id)
        {
          return (_context.GardenExpert?.Any(e => e.GardenExpertId == id)).GetValueOrDefault();
        }
    }
}
