using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaWebApi.Models;

namespace AgendaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaDetailContext _context;

        public AgendaController(AgendaDetailContext context)
        {
            _context = context;
        }


        // GET: api/Agenda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendaDetail>>> GetAgendaDetails()
        {
            return await _context.AgendaDetails.ToListAsync();
        }

        // PUT: api/Agenda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendaDetail(int id, AgendaDetail agendaDetail)
        {
            if (id != agendaDetail.AgendaId)
            {
                return BadRequest();
            }

            _context.Entry(agendaDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaDetailExists(id))
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

        // GET: api/Agenda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaDetail>> GetAgendaDetail(int id)
        {
            var agendaDetail = await _context.AgendaDetails.FindAsync(id);

            if (agendaDetail == null)
            {
                return NotFound();
            }

            return agendaDetail;
        }

        // POST: api/Agenda
        [HttpPost]
        public async Task<ActionResult<AgendaDetail>> PostAgendaDetail(AgendaDetail agendaDetail)
        {
            _context.AgendaDetails.Add(agendaDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendaDetail", new { id = agendaDetail.AgendaId }, agendaDetail);
        }

        // DELETE: api/Agenda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgendaDetail>> DeleteAgendaDetail(int id)
        {
            var agendaDetail = await _context.AgendaDetails.FindAsync(id);
            if (agendaDetail == null)
            {
                return NotFound();
            }

            _context.AgendaDetails.Remove(agendaDetail);
            await _context.SaveChangesAsync();

            return agendaDetail;
        }

        private bool AgendaDetailExists(int id)
        {
            return _context.AgendaDetails.Any(e => e.AgendaId == id);
        }
    }
}
