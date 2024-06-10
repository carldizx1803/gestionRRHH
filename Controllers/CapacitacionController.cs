using AutoMapper;
using gestionRRHH.dbContext;
using gestionRRHH.DTO;
using gestionRRHH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestionRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CapacitacionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Capacitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacitacionReadDTO>>> GetCapacitaciones()
        {
            var capacitaciones = await _context.Capacitacion.ToListAsync();
            var capacitacionDTOs = _mapper.Map<List<CapacitacionReadDTO>>(capacitaciones);
            return Ok(capacitacionDTOs);
        }

        // GET: api/Capacitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacitacionReadDTO>> GetCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitacion.FindAsync(id);

            if (capacitacion == null)
            {
                return NotFound();
            }

            var capacitacionDTO = _mapper.Map<CapacitacionReadDTO>(capacitacion);
            return Ok(capacitacionDTO);
        }

        // POST: api/Capacitacion
        [HttpPost]
        public async Task<ActionResult<CapacitacionReadDTO>> CrearCapacitacion(CapacitacionCreateDTO capacitacionCreateDTO)
        {
            var capacitacion = _mapper.Map<Capacitacion>(capacitacionCreateDTO);
            _context.Capacitacion.Add(capacitacion);
            await _context.SaveChangesAsync();

            var capacitacionDTO = _mapper.Map<CapacitacionReadDTO>(capacitacion);

            return CreatedAtAction(nameof(GetCapacitacion), new { id = capacitacion.CapacitacionId }, capacitacionDTO);
        }

        // PUT: api/Capacitacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCapacitacion(int id, CapacitacionUpdateDTO capacitacionUpdateDTO)
        {
            var capacitacionExistente = await _context.Capacitacion.FindAsync(id);
            if (capacitacionExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(capacitacionUpdateDTO, capacitacionExistente);

            await _context.SaveChangesAsync();

            return NoContent();

        }
        // DELETE: api/Capacitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitacion.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            _context.Capacitacion.Remove(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
        

        // DELETE: api/Cap