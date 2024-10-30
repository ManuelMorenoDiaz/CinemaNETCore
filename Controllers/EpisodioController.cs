
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodiosController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public EpisodiosController(ApiProjectContext context)
        {
            _context = context;

        }

        // GET: api/Episodios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episodio>>> GetEpisodios()
        {
            return await _context.Episodios.ToListAsync();
        }

        // GET: api/Episodios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Episodio>> GetEpisodio(int id)
        {
            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio == null)
            {
                return NotFound();
            }
            return episodio;

        }

        // PUT: api/Episodios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisodio(int id, Episodio episodio)
        {
            if (id != episodio.ID_Episodio)
            {
                return BadRequest();
            }
            _context.Entry(episodio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Episodios
        [HttpPost]
        public async Task<ActionResult<Episodio>> PostEpisodio(Episodio
        episodio)
        {
            _context.Episodios.Add(episodio);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEpisodio", new { id = episodio.ID_Episodio }, episodio);
        }

        // DELETE: api/Episodios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisodio(int id)
        {
            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio == null)
            {
                return NotFound();
            }
            _context.Episodios.Remove(episodio);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}