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
    public class PlotUsersController : Controller
    {
        private readonly CommunityGardenContext _context;

        public PlotUsersController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: PlotUsers
        public async Task<IActionResult> Index()
        {
              return _context.PlotUser != null ? 
                          View(await _context.PlotUser.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.PlotUser'  is null.");
        }

        // GET: PlotUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlotUser == null)
            {
                return NotFound();
            }

            var plotUser = await _context.PlotUser
                .FirstOrDefaultAsync(m => m.PlotUserId == id);
            if (plotUser == null)
            {
                return NotFound();
            }

            return View(plotUser);
        }

        // GET: PlotUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlotUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlotUserId,PlotId,GardenUserId")] PlotUser plotUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plotUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plotUser);
        }

        // GET: PlotUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlotUser == null)
            {
                return NotFound();
            }

            var plotUser = await _context.PlotUser.FindAsync(id);
            if (plotUser == null)
            {
                return NotFound();
            }
            return View(plotUser);
        }

        // POST: PlotUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlotUserId,PlotId,GardenUserId")] PlotUser plotUser)
        {
            if (id != plotUser.PlotUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plotUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlotUserExists(plotUser.PlotUserId))
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
            return View(plotUser);
        }

        // GET: PlotUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlotUser == null)
            {
                return NotFound();
            }

            var plotUser = await _context.PlotUser
                .FirstOrDefaultAsync(m => m.PlotUserId == id);
            if (plotUser == null)
            {
                return NotFound();
            }

            return View(plotUser);
        }

        // POST: PlotUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlotUser == null)
            {
                return Problem("Entity set 'CommunityGardenContext.PlotUser'  is null.");
            }
            var plotUser = await _context.PlotUser.FindAsync(id);
            if (plotUser != null)
            {
                _context.PlotUser.Remove(plotUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlotUserExists(int id)
        {
          return (_context.PlotUser?.Any(e => e.PlotUserId == id)).GetValueOrDefault();
        }
    }
}
