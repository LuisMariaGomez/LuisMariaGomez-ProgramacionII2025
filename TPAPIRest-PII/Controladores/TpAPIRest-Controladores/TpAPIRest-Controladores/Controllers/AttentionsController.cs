using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpAPIRestControladores.Models.Entities;
using TpAPIRest_Controladores.Models.Entities;

namespace TpAPIRest_Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionsController : ControllerBase
    {
        private readonly VetContext _context;

        public AttentionsController(VetContext context)
        {
            _context = context;
        }

        // GET: api/Attentions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attentions>>> GetAttentions()
        {
            return await _context.Attentions.ToListAsync();
        }

        // GET: api/Attentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attentions>> GetAttentions(long id)
        {
            var attentions = await _context.Attentions.FindAsync(id);

            if (attentions == null)
            {
                return NotFound();
            }

            return attentions;
        }
        // GET: api/Attentions/ByAnimal/{idAnimal}
        [HttpGet("ByAnimal/{idAnimal}")]
        public async Task<ActionResult<IEnumerable<Attentions>>> GetAttentionsOfAnimal(long idAnimal)
        {
            var attentions = await _context.Attentions
                                           .Where(a => a.AnimalId == idAnimal)
                                           .ToListAsync();

            if (!attentions.Any())
            {
                return NotFound();
            }

            return attentions;
        }

        // PUT: api/Attentions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttentions(long id, Attentions attentions)
        {
            if (id != attentions.Id)
            {
                return BadRequest();
            }

            _context.Entry(attentions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttentionsExists(id))
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

        // POST: api/Attentions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attentions>> PostAttentions(Attentions attentions)
        {
            _context.Attentions.Add(attentions);
            await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetAttentions", new { id = attentions.Id }, attentions);
            return CreatedAtAction(nameof(GetAttentions), new { id = attentions.Id }, attentions);
        }

        // DELETE: api/Attentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttentions(long id)
        {
            var attentions = await _context.Attentions.FindAsync(id);
            if (attentions == null)
            {
                return NotFound();
            }

            _context.Attentions.Remove(attentions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttentionsExists(long id)
        {
            return _context.Attentions.Any(e => e.Id == id);
        }
    }
}
