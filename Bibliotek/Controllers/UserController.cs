using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Controllers
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
            var users = _context.Users.Include(x => x.Products)
                .ToList();
                                    
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =  await _context.Users.FindAsync(id);
            return Ok(user);
            
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserModel User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return Ok();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserModel User)
        {
            if (User.Id == 0)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
