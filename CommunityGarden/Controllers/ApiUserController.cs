using CommunityGarden.Data;
using CommunityGarden.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunityGarden.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiUserController : ControllerBase
	{
		private readonly CommunityGardenContext _context;

		public ApiUserController(CommunityGardenContext context)
		{
			_context = context;
		}

		// GET: api/Users
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUser()
		{
			if (_context.User == null)
			{
				return NotFound();
			}
			return await _context.User.ToListAsync();
		}

		// GET: api/Users/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			if (_context.User == null)
			{
				return NotFound();
			}
			var grocery = await _context.User.FindAsync(id);

			if (grocery == null)
			{
				return NotFound();
			}

			return grocery;
		}

		// PUT: api/Users/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUsers(int id, User user)
		{
			if (id != user.UserId)
			{
				return BadRequest();
			}

			_context.Entry(user).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Users
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<User>> PostUser(User user)
		{
			if (_context.User == null)
			{
				return Problem("Entity set 'ShoppingListContext.Grocery'  is null.");
			}
			_context.User.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
		}

		// DELETE: api/Groceries/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			if (_context.User == null)
			{
				return NotFound();
			}
			var user = await _context.User.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			_context.User.Remove(user);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UserExists(int id)
		{
			return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
		}

	}
}