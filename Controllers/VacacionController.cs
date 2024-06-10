using AutoMapper;
using gestionRRHH.dbContext;
using gestionRRHH.DTO;
using gestionRRHH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VacacionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Vacacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacacionReadDTO>>> GetVacaciones()
        {
            var vacaciones = await _context.Vacacion.ToListAsync();
            var vacacionesDTO = _mapper.Map<List<VacacionReadDTO>>(vacaciones);
            return Ok(vacacionesDTO);
        }

        // GET: api/Vacacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacacionReadDTO>> GetVacacion(int id)
        {
            var vacacion = await _context.Vacacion.FindAsync(id);

            if (vacacion == null)
            {
                return NotFound();
            }

            var vacacionDTO = _mapper.Map<VacacionReadDTO>(vacacion);
            return Ok(vacacionDTO);
        }

        // POST: api/Vacacion
        [HttpPost]
        public async Task<ActionResult<VacacionReadDTO>> PostVacacion(VacacionCreateDTO vacacionCreateDTO)
        {
            var vacacion = _mapper.Map<Vacacion>(vacacionCreateDTO);
            _context.Vacacion.Add(vacacion);
            await _context.SaveChangesAsync();

            var vacacionDTO = _mapper.Map<VacacionReadDTO>(vacacion);

            return CreatedAtAction(nameof(GetVacacion), new { id = vacacion.VacacionId }, vacacionDTO);
        }

        // PUT: api/Vacacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacacion(int id, VacacionUpdateDTO vacacionUpdateDTO)
        {
            if (id != vacacionUpdateDTO.VacacionId)
            {
                return BadRequest();
            }

            var vacacion = _mapper.Map<Vacacion>(vacacionUpdateDTO);

            _context.Entry(vacacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacacionExists(id))
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

        // DELETE: api/Vacacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacacion(int id)
        {
            var vacacion = await _context.Vacacion.FindAsync(id);
            if (vacacion == null)
            {
                return NotFound();
            }

            _context.Vacacion.Remove(vacacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacacionExists(int id)
        {
            return _context.Vacacion.Any(e => e.VacacionId == id);
        }
    }
}
