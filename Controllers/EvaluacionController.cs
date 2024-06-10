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
    public class EvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluacionReadDTO>>> GetEvaluaciones()
        {
            var evaluaciones = await _context.Evaluacion.ToListAsync();
            var evaluacionesDTO = _mapper.Map<List<EvaluacionReadDTO>>(evaluaciones);
            return Ok(evaluacionesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluacionReadDTO>> GetEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            var evaluacionDTO = _mapper.Map<EvaluacionReadDTO>(evaluacion);
            return Ok(evaluacionDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EvaluacionReadDTO>> CrearEvaluacion(EvaluacionCreateDTO evaluacionCreateDTO)
        {
            var evaluacion = _mapper.Map<Evaluacion>(evaluacionCreateDTO);
            _context.Evaluacion.Add(evaluacion);
            await _context.SaveChangesAsync();

            var evaluacionDTO = _mapper.Map<EvaluacionReadDTO>(evaluacion);

            return CreatedAtAction(nameof(GetEvaluacion), new { id = evaluacion.EvaluacionId }, evaluacionDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEvaluacion(int id, EvaluacionUpdateDTO evaluacionUpdateDTO)
        {
            var evaluacionExistente = await _context.Evaluacion.FindAsync(id);
            if (evaluacionExistente == null)
            {
                return NotFound();
            }
            _mapper.Map(evaluacionUpdateDTO, evaluacionExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            _context.Evaluacion.Remove(evaluacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}