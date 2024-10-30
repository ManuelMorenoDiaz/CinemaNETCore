using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ActoresController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public ActoresController(ApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Actores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActores()
        {
            return await _context.Actores.ToListAsync();
        }

        // GET: api/Actores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _context.Actores.FirstOrDefaultAsync(a => a.ID_Actor == id);
            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        // PUT: api/Actores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor)
        {
            if (id != actor.ID_Actor)
            {
                return BadRequest();
            }
            _context.Entry(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Actores
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _context.Actores.Add(actor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActor", new { id = actor.ID_Actor }, actor);

        }

        // DELETE: api/Actores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id)
        {
            var actor = await _context.Actores.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            _context.Actores.Remove(actor);
            await _context.SaveChangesAsync();
            return actor;

        }
    }
}