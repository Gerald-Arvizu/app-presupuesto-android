using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;
using API_App_Presupuesto.Modelos;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDepartamentos() => Ok(_context.Departamentos.ToList());

        [HttpGet("{id}")]
        public IActionResult GetDepartamento(int id)
        {
            var dep = _context.Departamentos.Find(id);
            if (dep == null) return NotFound();
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult CrearDepartamento([FromBody] Departamento dep)
        {
            _context.Departamentos.Add(dep);
            _context.SaveChanges();
            return Ok(dep);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarDepartamento(int id, [FromBody] Departamento depActualizado)
        {
            var dep = _context.Departamentos.Find(id);
            if (dep == null) return NotFound();

            dep.Nombre = depActualizado.Nombre;

            _context.SaveChanges();
            return Ok(dep);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarDepartamento(int id)
        {
            var dep = _context.Departamentos.Find(id);
            if (dep == null) return NotFound();

            _context.Departamentos.Remove(dep);
            _context.SaveChanges();
            return Ok(new { mensaje = "Departamento eliminado" });
        }
    }
}
