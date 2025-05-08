using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Shared.Entities;
using CNegocio.Logica;
using CNegocio.Logica.ILogica;

namespace TP1_EJ3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        private readonly IAnimalsLogic _ianimallogic;

        public AnimalsController(IAnimalsLogic logica)
        {
            _ianimallogic = logica;
        }

        // GET: api/Animals  
        [HttpGet]
        public ActionResult<IEnumerable<AnimalsDTO>> GetAnimals()
        {
            return _ianimallogic.ObtenerAnimales();
        }

        // GET: api/Animals/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalsDTO>> GetAnimals(int id)
        {
            var animals = _ianimallogic.ObtenerAnimal(id);

            if (animals == null)
            {
                return NotFound();
            }

            return animals;
        }

        // PUT: api/Animals/5  
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimals(int id, AnimalsDTO animals)
        {
            if (id != animals.Id)
            {
                return BadRequest();
            }

            _ianimallogic.ActualizarAnimal(animals);

            return NoContent();
        }

        // POST: api/Animals  
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754  
        [HttpPost]
        public async Task<ActionResult<AnimalsDTO>> PostAnimals(AnimalsDTO animals)
        {
            _ianimallogic.AgregarAnimal(animals);

            return CreatedAtAction("GetAnimals", new { id = animals.Id }, animals);
        }

        // DELETE: api/Animals/5  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimals(int id)
        {
            _ianimallogic.EliminarAnimal(id);

            return NoContent();
        }
    }
}
