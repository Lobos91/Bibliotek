using Bibliotek.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotek.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EbookController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetEbooks()
        {
            var ebooks = _context.Ebooks.ToList();
                                    
            return Ok(ebooks);
        }

       
    }
}
