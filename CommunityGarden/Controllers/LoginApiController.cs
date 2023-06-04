using CommunityGarden.Data;
using CommunityGarden.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginApiController : ControllerBase

    {
        private readonly CommunityGardenContext _context;

        public LoginApiController(CommunityGardenContext context)
        {
            _context = context;
        }


        [HttpGet("{Email}")]
        public async Task<ActionResult<User>> Authenticate(string email)
        {
            var str = email.Split("@@@");

            if (_context.User == null)
            {
                return NotFound();
            }
            var user =  _context.Users.FirstOrDefault(x => x.Email == str[0]);

            if (user == null)
            {
                return NotFound();
            }

            if (IsValidUser(str[0], str[1], user))
            {
                return user;
            }
            else
            {
                return Unauthorized();
            }

        }

        private bool IsValidUser(string mail, string password, User user)
        {

            

            if (mail == user.Email && password == user.PasswordHash)
            {
                return true;
            }

            return false;
        }
    }

    public class LoginModel
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}

