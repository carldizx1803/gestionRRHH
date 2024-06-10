using AutoMapper;
using gestionRRHH.dbContext;
using gestionRRHH.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gestionRRHH.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartamentoController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<DepartamentoReadDTO>>> GetEmpleados()
        {
            var departamento = await _context.Departamento.ToListAsync();
            var departamentoDTO = _mapper.Map<List<DepartamentoReadDTO>>(departamento);
            return Ok(departamentoDTO);
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoReadDTO>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var departamentoDTO = _mapper.Map<DepartamentoReadDTO>(departamento);
            return Ok(departamentoDTO);
        }

        // POST: api/Departamentos
        [HttpPost]
        public async Task<ActionResult<DepartamentoReadDTO>> CrearDepartamento(DepartamentoCreateDTO departamentoCreateDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoCreateDTO);
            _context.Departamento.Add(departamento);
            await _context.SaveChangesAsync();

            var departamentoDTO = _mapper.Map<DepartamentoReadDTO>(departamento);

            return CreatedAtAction(nameof(GetDepartamento), new { id = departamento.DepartamentoId }, departamentoDTO);
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDepartamento(int id, DepartamentoUpdateDTO departamentoUpdateDTO)
        {
            var departamentoExistente = await _context.Departamento.FindAsync(id);
            if (departamentoExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(departamentoUpdateDTO, departamentoExistente);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDepartamento(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
