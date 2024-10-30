using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProject.Controllers;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApiProjectContext _context;
        public PeliculasController(ApiProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.ID_Pelicula == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return pelicula;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula(int id, Pelicula pelicula)
        {
            if (id != pelicula.ID_Pelicula)
            {
                return BadRequest();
            }
            _context.Entry(pelicula).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPelicula", new { id = pelicula.ID_Pelicula }, pelicula);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.ID_Pelicula == id);
        }
    }
}
