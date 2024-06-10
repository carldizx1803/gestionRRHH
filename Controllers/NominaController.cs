using AutoMapper;
using gestionRRHH.dbContext;
using gestionRRHH.DTO;
using gestionRRHH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NominaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Nomina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominaReadDTO>>> GetNominas()
        {
            var nominas = await _context.Nomina.ToListAsync();
            var nominasDTO = _mapper.Map<List<NominaReadDTO>>(nominas);
            return Ok(nominasDTO);
        }

        // GET: api/Nomina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominaReadDTO>> GetNomina(int id)
        {
            var nomina = await _context.Nomina.FindAsync(id);

            if (nomina == null)
            {
                return NotFound();
            }

            var nominaDTO = _mapper.Map<NominaReadDTO>(nomina);
            return nominaDTO;
        }

        // POST: api/Nomina
        [HttpPost]
        public async Task<ActionResult<NominaReadDTO>> PostNomina(NominaCreateDTO nominaCreateDTO)
        {
            var nomina = _mapper.Map<Nomina>(nominaCreateDTO);
            _context.Nomina.Add(nomina);
            await _context.SaveChangesAsync();

            var nominaDTO = _mapper.Map<NominaReadDTO>(nomina);

            return CreatedAtAction(nameof(GetNomina), new { id = nomina.NominaId }, nominaDTO);
        }

        // PUT: api/Nomina/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomina(int id, NominaUpdateDTO nominaUpdateDTO)
        {
            if (id != nominaUpdateDTO.NominaId)
            {
                return BadRequest();
            }

            var nomina = _mapper.Map<Nomina>(nominaUpdateDTO);

            _context.Entry(nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(id))
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

        // DELETE: api/Nomina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomina(int id)
        {
            var nomina = await _context.Nomina.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }

            _context.Nomina.Remove(nomina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NominaExists(int id)
        {
            return _context.Nomina.Any(e => e.NominaId == id);
        }
    }
}