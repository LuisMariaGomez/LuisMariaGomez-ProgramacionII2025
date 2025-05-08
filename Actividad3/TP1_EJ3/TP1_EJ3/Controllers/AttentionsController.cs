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
    public class AttentionsController : ControllerBase
    {
        private readonly IAttentionsLogic _attentionlogic;
        public AttentionsController(IAttentionsLogic logic)
        {
            _attentionlogic = logic;
        }

        // GET: api/Attentions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttentionsDTO>>> GetAttentions()
        {
            return _attentionlogic.ObtenerAtenciones();
        }

        // GET: api/Attentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttentionsDTO>> GetAttentions(int id)
        {
            return _attentionlogic.ObtenerAtencion(id);
        }

        // PUT: api/Attentions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttentions(int id, AttentionsDTO attentions)
        {
            if (id != attentions.Id)
            {
                return BadRequest();
            }

            _attentionlogic.ActualizarAtencion(attentions);

            return NoContent();
        }

        // POST: api/Attentions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attentions>> PostAttentions(AttentionsDTO attentions)
        {
            _attentionlogic.AgregarAtencion(attentions);

            return CreatedAtAction("GetAttentions", new { id = attentions.Id }, attentions);
        }

        // DELETE: api/Attentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttentions(int id)
        {
            _attentionlogic.EliminarAtencion(id);
            return NoContent();

        }
    }
}
