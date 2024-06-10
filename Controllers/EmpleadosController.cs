using AutoMapper;
using gestionRRHH.dbContext;
using gestionRRHH.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gestionRRHH.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

namespace gestionRRHH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadosController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET01 Empleados BUSQUEDA TODOS
        // devuelve todos los empleados de la base de datos hace una consulta a la BD y los mapea devolviendo un 200
        [HttpGet]

        public async Task<ActionResult<IEnumerable<EmpleadoReadDTO>>> GetEmpleados()
        {
            var empleados = await _context.Empleado.ToListAsync();
            var empleadosDTO = _mapper.Map<List<EmpleadoReadDTO>>(empleados);
            return Ok(empleadosDTO);
        }

        // GET02 Empleados BUSQUEDA INDIVIDUAL
        // devuelve empleado especifico por el ID, lo busca lo mapea y si lo encuentra devuelve un 200
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoReadDTO>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            var empleadoDTO = _mapper.Map<EmpleadoReadDTO>(empleado);
            return Ok(empleadoDTO);
        }

        // POST01 AGREGAR EMPLEADO recibe un objeto de la bd, lo mapea y lo agrega nuevo,
        // lo devuelve con un 201 + location 
        [HttpPost]
        public async Task<ActionResult<EmpleadoReadDTO>> CrearEmpleado(EmpleadoCreateDTO empleadoCreateDTO)
        {
            var empleado = _mapper.Map<Empleado>(empleadoCreateDTO);
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            var empleadoDTO = _mapper.Map<EmpleadoReadDTO>(empleado);

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.EmpleadoId }, empleadoDTO);
        }

        // PUT01 ACTUALIZAR EMPLEADO solicita el ID como parámetro. Si no existe devuelve 404
        // Si existe lo mapea y actualiza en la base de datos devolviendo un 204
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEmpleado(int id, EmpleadoUpdateDTO empleadoUpdateDTO)
        {
            // Verificar si el ID proporcionado coincide con algún empleado en la base de datos
            var empleadoExistente = await _context.Empleado.FindAsync(id);
            if (empleadoExistente == null)
            {
                return NotFound(); 
            }
            _mapper.Map(empleadoUpdateDTO, empleadoExistente);

            await _context.SaveChangesAsync();

            return NoContent(); 
        }
        //DELETE elimina el empleado que se parametrice
        // si lo hizo devuelve un 204 si no devuelve un 404
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
      
    }


    
    


