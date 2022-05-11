using Bibliotek.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotek.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetEbooks()
        {
            var movies = _context.Movies.ToList();
                                    
            return Ok(movies);
        }

       
    }
}
