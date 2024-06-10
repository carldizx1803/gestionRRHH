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
    public class BeneficiosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BeneficiosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Beneficios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficioReadDTO>>> GetBeneficios()
        {
            var beneficios = await _context.Beneficio.ToListAsync();
            var beneficioDTOs = _mapper.Map<List<BeneficioReadDTO>>(beneficios);
            return Ok(beneficioDTOs);
        }

        // GET: api/Beneficios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficioReadDTO>> GetBeneficio(int id)
        {
            var beneficio = await _context.Beneficio.FindAsync(id);

            if (beneficio == null)
            {
                return NotFound();
            }

            var beneficioDTO = _mapper.Map<BeneficioReadDTO>(beneficio);
            return Ok(beneficioDTO);
        }

        // POST: api/Beneficios
        [HttpPost]
        public async Task<ActionResult<BeneficioReadDTO>> CrearBeneficio(BeneficioCreateDTO beneficioCreateDTO)
        {
            var beneficio = _mapper.Map<Beneficio>(beneficioCreateDTO);
            _context.Beneficio.Add(beneficio);
            await _context.SaveChangesAsync();

            var beneficioDTO = _mapper.Map<BeneficioReadDTO>(beneficio);

            return CreatedAtAction(nameof(GetBeneficio), new { id = beneficio.BeneficioId }, beneficioDTO);
        }

        // PUT: api/Beneficios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarBeneficio(int id, BeneficioUpdateDTO beneficioUpdateDTO)
        {
            var beneficioExistente = await _context.Beneficio.FindAsync(id);
            if (beneficioExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(beneficioUpdateDTO, beneficioExistente);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Beneficios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarBeneficio(int id)
        {
            var beneficio = await _context.Beneficio.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }

            _context.Beneficio.Remove(beneficio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
