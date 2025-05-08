using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace TP1_EJ3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersLogic _ownersLogic;
        public OwnersController(IOwnersLogic ownersLogic)
        {
            _ownersLogic = ownersLogic;
        }

        // GET: api/Owners
        [HttpGet]
        public ActionResult<IEnumerable<OwnersDTO>> GetOwners()
        {
            return _ownersLogic.ObtenerOwners();
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnersDTO>> GetOwners(int id)
        {

            var animals = _ownersLogic.ObtenerOwner(id);

            if (animals == null)
            {
                return NotFound();
            }

            return animals;
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwners(int id, OwnersDTO owners)
        {
            if (id != owners.Id)
            {
                return BadRequest();
            }

            _ownersLogic.ActualizarOwner(owners);

            return NoContent();
        }

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owners>> PostOwners(OwnersDTO owners)
        {
            _ownersLogic.AgregarOwner(owners);

            return CreatedAtAction("GetOwners", new { id = owners.Id }, owners);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwners(int id)
        {
            _ownersLogic.EliminarOwner(id);

            return NoContent();
        }
    }
}
