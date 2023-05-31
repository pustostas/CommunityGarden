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
    public class PlotsController : Controller
    {
        private readonly CommunityGardenContext _context;

        public PlotsController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: Plots
        public async Task<IActionResult> Index()
        {
              return _context.Plot != null ? 
                          View(await _context.Plot.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.Plot'  is null.");
        }

        // GET: Plots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot
                .FirstOrDefaultAsync(m => m.PlotId == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // GET: Plots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlotId,GardenId,SuperviserId,Shape")] Plot plot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plot);
        }

        // GET: Plots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot.FindAsync(id);
            if (plot == null)
            {
                return NotFound();
            }
            return View(plot);
        }

        // POST: Plots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlotId,GardenId,SuperviserId,Shape")] Plot plot)
        {
            if (id != plot.PlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlotExists(plot.PlotId))
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
            return View(plot);
        }

        // GET: Plots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot
                .FirstOrDefaultAsync(m => m.PlotId == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // POST: Plots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plot == null)
            {
                return Problem("Entity set 'CommunityGardenContext.Plot'  is null.");
            }
            var plot = await _context.Plot.FindAsync(id);
            if (plot != null)
            {
                _context.Plot.Remove(plot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlotExists(int id)
        {
          return (_context.Plot?.Any(e => e.PlotId == id)).GetValueOrDefault();
        }
    }
}
