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
    public class GardenUsersController : Controller
    {
        private readonly CommunityGardenContext _context;

        public GardenUsersController(CommunityGardenContext context)
        {
            _context = context;
        }

        // GET: GardenUsers
        public async Task<IActionResult> Index()
        {
              return _context.GardenUser != null ? 
                          View(await _context.GardenUser.ToListAsync()) :
                          Problem("Entity set 'CommunityGardenContext.GardenUser'  is null.");
        }

        // GET: GardenUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GardenUser == null)
            {
                return NotFound();
            }

            var gardenUser = await _context.GardenUser
                .FirstOrDefaultAsync(m => m.GardenUserId == id);
            if (gardenUser == null)
            {
                return NotFound();
            }

            return View(gardenUser);
        }

        // GET: GardenUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GardenUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GardenUserId,UserId,GardenId,Role")] GardenUser gardenUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gardenUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gardenUser);
        }

        // GET: GardenUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GardenUser == null)
            {
                return NotFound();
            }

            var gardenUser = await _context.GardenUser.FindAsync(id);
            if (gardenUser == null)
            {
                return NotFound();
            }
            return View(gardenUser);
        }

        // POST: GardenUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GardenUserId,UserId,GardenId,Role")] GardenUser gardenUser)
        {
            if (id != gardenUser.GardenUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gardenUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenUserExists(gardenUser.GardenUserId))
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
            return View(gardenUser);
        }

        // GET: GardenUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GardenUser == null)
            {
                return NotFound();
            }

            var gardenUser = await _context.GardenUser
                .FirstOrDefaultAsync(m => m.GardenUserId == id);
            if (gardenUser == null)
            {
                return NotFound();
            }

            return View(gardenUser);
        }

        // POST: GardenUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GardenUser == null)
            {
                return Problem("Entity set 'CommunityGardenContext.GardenUser'  is null.");
            }
            var gardenUser = await _context.GardenUser.FindAsync(id);
            if (gardenUser != null)
            {
                _context.GardenUser.Remove(gardenUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenUserExists(int id)
        {
          return (_context.GardenUser?.Any(e => e.GardenUserId == id)).GetValueOrDefault();
        }
    }
}
