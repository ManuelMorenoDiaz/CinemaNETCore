using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialVistoController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public HistorialVistoController(ApiProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialVisto>>> GetHistorialVistos()
        {
            return await _context.HistorialVistos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialVisto>> GetHistorialVisto(int id)
        {
            var historialVisto = await _context.HistorialVistos.FindAsync(id);
            if (historialVisto == null)
            {
                return NotFound();
            }
            return historialVisto;
        }

        [HttpPost]
        public async Task<ActionResult<HistorialVisto>> PostHistorialVisto(HistorialVisto historialVisto)
        {
            _context.HistorialVistos.Add(historialVisto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHistorialVisto", new { id = historialVisto.ID_Historial }, historialVisto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialVisto(int id, HistorialVisto historialVisto)
        {
            if (id != historialVisto.ID_Historial)
            {
                return BadRequest();
            }
            _context.Entry(historialVisto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialVisto(int id)
        {
            var historialVisto = await _context.HistorialVistos.FindAsync(id);
            if (historialVisto == null)
            {
                return NotFound();
            }
            _context.HistorialVistos.Remove(historialVisto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

