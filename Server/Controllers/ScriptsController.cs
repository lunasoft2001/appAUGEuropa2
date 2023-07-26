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
    public class ScriptsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScriptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Scripts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Script>>> GetScripts()
        {
          if (_context.Scripts == null)
          {
              return NotFound();
          }
            return await _context.Scripts
                .Include(x => x.Usuario)
                .Include(x => x.ScriptDetalles)
                .ToListAsync();
        }

        // GET: api/Scripts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Script>> GetScript(int id)
        {
          if (_context.Scripts == null)
          {
              return NotFound();
          }
            var script = await _context.Scripts.FindAsync(id);

            if (script == null)
            {
                return NotFound();
            }

            return script;
        }

        // PUT: api/Scripts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScript(int id, Script script)
        {
            if (id != script.Id)
            {
                return BadRequest();
            }

            _context.Entry(script).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptExists(id))
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

        // POST: api/Scripts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Script>> PostScript(Script script)
        {
          if (_context.Scripts == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Scripts'  is null.");
          }
            _context.Scripts.Add(script);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScript", new { id = script.Id }, script);
        }

        // DELETE: api/Scripts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript(int id)
        {
            if (_context.Scripts == null)
            {
                return NotFound();
            }
            var script = await _context.Scripts.FindAsync(id);
            if (script == null)
            {
                return NotFound();
            }

            _context.Scripts.Remove(script);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScriptExists(int id)
        {
            return (_context.Scripts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
