using Bibliotek.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var prods = _context.Products.Include(p => p.Release).ToList();

            return Ok(prods);
        }

    }
}
