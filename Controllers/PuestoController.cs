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

    public class PuestosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PuestosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET01 Puesto BUSQUEDA TODOS
        // devuelve todos los puestos de la base de datos hace una consulta a la BD y los mapea devolviendo un 200
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuestoReadDTO>>> GetPuesto()
        {
            var puestos = await _context.Puesto.ToListAsync();
            var puestoReadDTOs = puestos.Select(puesto => _mapper.Map<PuestoReadDTO>(puesto)).ToList();
            return Ok(puestoReadDTOs);
        }

        // GET02 Puesto BUSQUEDA INDIVIDUAL
        // devuelve puesto especifico por el ID, lo busca lo mapea y si lo encuentra devuelve un 200
        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoReadDTO>> GetPuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            var puestoDTO = _mapper.Map<PuestoReadDTO>(puesto);
            return Ok(puestoDTO);
        }

        // POST01 AGREGAR PUESTO recibe un objeto de la bd, lo mapea y lo agrega nuevo,
        // lo devuelve con un 201 + location 
        [HttpPost]
        public async Task<ActionResult<PuestoReadDTO>> CrearPuesto(PuestoCreateDTO puestoCreateDTO)
        {
            var puesto = _mapper.Map<Puesto>(puestoCreateDTO);
            _context.Puesto.Add(puesto);
            await _context.SaveChangesAsync();

            var puestoDTO = _mapper.Map<PuestoReadDTO>(puesto);

            return CreatedAtAction(nameof(GetPuesto), new { id = puesto.PuestoId }, puestoDTO);
        }

        // PUT01 ACTUALIZAR Puesto solicita el ID como parámetro. Si no existe devuelve 404
        // Si existe lo mapea y actualiza en la base de datos devolviendo un 204
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPuesto(int id, PuestoUpdateDTO puestoUpdateDTO)
        {
            var puestoExistente = await _context.Puesto.FindAsync(id);
            if (puestoExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(puestoUpdateDTO, puestoExistente);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE elimina puesto
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puesto.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}

