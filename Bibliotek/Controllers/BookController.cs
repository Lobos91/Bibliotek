using Bibliotek.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = _context.Books.ToList();
                                    
            return Ok(books);
        }

    
    }
}
