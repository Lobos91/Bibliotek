using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotek.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _context.Users.ToList();
                                    
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserModel User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
