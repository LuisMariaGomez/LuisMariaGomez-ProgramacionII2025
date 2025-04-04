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
    [Route("api/Animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly VetContext _context;

        public AnimalsController(VetContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animals>>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animals>> GetAnimals(long id)
        {
            var animals = await _context.Animals.FindAsync(id);

            if (animals == null)
            {
                return NotFound();
            }

            return animals;
        }
        // GET: api/Animals/ByOwner/{OwnerDni}
        [HttpGet("ByOwner/{OwnerDni}")]
        public async Task<ActionResult<IEnumerable<Animals>>> GetAnimalOfOwner(string OwnerDni)
        {
            var animals = await _context.Animals
                                           .Where(a => a.OwnerDni == OwnerDni)
                                           .ToListAsync();

            if (!animals.Any())
            {
                return NotFound();
            }

            return animals;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimals(long id, Animals animals)
        {
            if (id != animals.Id)
            {
                return BadRequest();
            }

            _context.Entry(animals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalsExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animals>> PostAnimals(Animals animals)
        {
            _context.Animals.Add(animals);
            await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetAnimals", new { id = animals.Id }, animals);
            return CreatedAtAction(nameof(GetAnimals), new { id = animals.Id }, animals);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimals(long id)
        {
            var animals = await _context.Animals.FindAsync(id);
            if (animals == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalsExists(long id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
