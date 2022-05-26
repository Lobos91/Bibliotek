using Bibliotek.Data;
using Bibliotek.Models;
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


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            if (product.Id == 0)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ResetProduct(List<ProductModel> Products)
        {
            foreach (var item in Products)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
           
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
