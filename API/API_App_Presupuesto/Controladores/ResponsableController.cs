using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;
using API_App_Presupuesto.Modelos;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsableController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResponsableController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetResponsables() => Ok(_context.Responsables.ToList());

        [HttpGet("{id}")]
        public IActionResult GetResponsable(int id)
        {
            var res = _context.Responsables.Find(id);
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CrearResponsable([FromBody] Responsable res)
        {
            _context.Responsables.Add(res);
            _context.SaveChanges();
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarResponsable(int id, [FromBody] Responsable resActualizado)
        {
            var res = _context.Responsables.Find(id);
            if (res == null) return NotFound();

            res.Nombre = resActualizado.Nombre;

            _context.SaveChanges();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarResponsable(int id)
        {
            var res = _context.Responsables.Find(id);
            if (res == null) return NotFound();

            _context.Responsables.Remove(res);
            _context.SaveChanges();
            return Ok(new { mensaje = "Responsable eliminado" });
        }
    }
}
