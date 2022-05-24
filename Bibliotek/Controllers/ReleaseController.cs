using Bibliotek.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReleaseController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetAllReleases()
        {
            var releases = _context.Releases.ToList();
                                    
            return Ok(releases);
        }



    }
}
