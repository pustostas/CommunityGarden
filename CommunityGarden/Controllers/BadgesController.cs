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
    public class BadgesController : Controller
    {
        private readonly CommunityGardenContext _context;

        public BadgesController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: Badges
        public async Task<IActionResult> Index()
        {
              return _context.Badge != null ? 
                          View(await _context.Badge.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.Badge'  is null.");
        }

        // GET: Badges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge
                .FirstOrDefaultAsync(m => m.BadgeID == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // GET: Badges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Badges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BadgeID,UserId,AchievmentId,Progress")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(badge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(badge);
        }

        // GET: Badges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }

        // POST: Badges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BadgeID,UserId,AchievmentId,Progress")] Badge badge)
        {
            if (id != badge.BadgeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(badge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BadgeExists(badge.BadgeID))
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
            return View(badge);
        }

        // GET: Badges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge
                .FirstOrDefaultAsync(m => m.BadgeID == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // POST: Badges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Badge == null)
            {
                return Problem("Entity set 'CommunityGardenContext.Badge'  is null.");
            }
            var badge = await _context.Badge.FindAsync(id);
            if (badge != null)
            {
                _context.Badge.Remove(badge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BadgeExists(int id)
        {
          return (_context.Badge?.Any(e => e.BadgeID == id)).GetValueOrDefault();
        }
    }
}
