using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KalenderController : ControllerBase
    {

        private readonly AppDbContext _context;
        public KalenderController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var evnts = _context.Kalendars.ToList();

            return Ok(evnts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(KalenderModel NewEvent)
        {
            await _context.Kalendars.AddAsync(NewEvent);
           await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(KalenderModel EventToUpdate)
        {
            if (EventToUpdate.Id == 0)
            {
                return BadRequest();
            }

            _context.Entry(EventToUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task< IActionResult> DeleteEvent(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }
            var eventToDelete = _context.Kalendars.FirstOrDefault(ev => ev.Id == id);
            _context.Kalendars.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
