using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;
using API_App_Presupuesto.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimientoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovimientos([FromQuery] string tipo = "", [FromQuery] DateTime? desde = null, [FromQuery] DateTime? hasta = null)
        {
            var query = _context.Movimientos.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(m => m.Tipo == tipo);

            if (desde.HasValue)
                query = query.Where(m => m.Fecha >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(m => m.Fecha <= hasta.Value);

            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovimiento(int id)
        {
            var mov = _context.Movimientos.Find(id);
            if (mov == null) return NotFound();
            return Ok(mov);
        }

        [HttpPost]
        public IActionResult CrearMovimiento([FromBody] Movimiento mov)
        {
            _context.Movimientos.Add(mov);
            _context.SaveChanges();
            return Ok(mov);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarMovimiento(int id, [FromBody] Movimiento movActualizado)
        {
            var mov = _context.Movimientos.Find(id);
            if (mov == null) return NotFound();

            mov.Descripcion = movActualizado.Descripcion;
            mov.Monto = movActualizado.Monto;
            mov.Tipo = movActualizado.Tipo;
            mov.Fecha = movActualizado.Fecha;
            mov.IdCuenta = movActualizado.IdCuenta;
            mov.IdDepartamento = movActualizado.IdDepartamento;
            mov.IdResponsable = movActualizado.IdResponsable;

            _context.SaveChanges();
            return Ok(mov);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMovimiento(int id)
        {
            var mov = _context.Movimientos.Find(id);
            if (mov == null) return NotFound();

            _context.Movimientos.Remove(mov);
            _context.SaveChanges();
            return Ok(new { mensaje = "Movimiento eliminado" });
        }
    }
}
