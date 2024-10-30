using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeriesController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public SeriesController(ApiProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return serie;
        }
        [HttpPost]
        public async Task<ActionResult<Serie>> CreateSerie(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSerie), new { id = serie.ID_Serie }, serie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSerie(int id, Serie serie)
        {
            if (id != serie.ID_Serie)
            {
                return BadRequest();
            }
            _context.Entry(serie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.ID_Serie == id);
        }
    }
}
