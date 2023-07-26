using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appAUGEuropa2.Server;
using appAUGEuropa2.Shared;

namespace appAUGEuropa2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptDetallesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScriptDetallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScriptDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScriptDetalle>>> GetScriptDetalles()
        {
          if (_context.ScriptDetalles == null)
          {
              return NotFound();
          }
            return await _context.ScriptDetalles.ToListAsync();
        }

        // GET: api/ScriptDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScriptDetalle>> GetScriptDetalle(int id)
        {
          if (_context.ScriptDetalles == null)
          {
              return NotFound();
          }
            var scriptDetalle = await _context.ScriptDetalles.FindAsync(id);

            if (scriptDetalle == null)
            {
                return NotFound();
            }

            return scriptDetalle;
        }

        // PUT: api/ScriptDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScriptDetalle(int id, ScriptDetalle scriptDetalle)
        {
            if (id != scriptDetalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(scriptDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptDetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ScriptDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScriptDetalle>> PostScriptDetalle(ScriptDetalle scriptDetalle)
        {
          if (_context.ScriptDetalles == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ScriptDetalles'  is null.");
          }
            _context.ScriptDetalles.Add(scriptDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScriptDetalle", new { id = scriptDetalle.Id }, scriptDetalle);
        }

        // DELETE: api/ScriptDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScriptDetalle(int id)
        {
            if (_context.ScriptDetalles == null)
            {
                return NotFound();
            }
            var scriptDetalle = await _context.ScriptDetalles.FindAsync(id);
            if (scriptDetalle == null)
            {
                return NotFound();
            }

            _context.ScriptDetalles.Remove(scriptDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScriptDetalleExists(int id)
        {
            return (_context.ScriptDetalles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
