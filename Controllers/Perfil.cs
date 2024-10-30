using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PerfilesController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public PerfilesController(ApiProjectContext context)
        {
            _context = context;
        }
        // GET: api/Perfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfiles()
        {
            return await _context.Perfiles.ToListAsync();
        }
        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfiles.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return perfil;

        }
        // PUT: api/Perfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.ID_Perfil)
            {
                return BadRequest();
            }
            _context.Entry(perfil).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/Perfiles
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfiles.Add(perfil);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerfil", new { id = perfil.ID_Perfil }, perfil);
        }
        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfiles.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            _context.Perfiles.Remove(perfil);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        private bool PerfilExists(int id)
        {
            return _context.Perfiles.Any(e => e.ID_Perfil == id);
        }

    }

}
