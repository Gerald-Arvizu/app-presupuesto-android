using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;
using API_App_Presupuesto.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CuentaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cuenta
        [HttpGet]
        public IActionResult GetCuentas()
        {
            var cuentas = _context.Cuentas.ToList();
            return Ok(cuentas);
        }

        // GET: api/Cuenta/{id}
        [HttpGet("{id}")]
        public IActionResult GetCuenta(int id)
        {
            var cuenta = _context.Cuentas.Find(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        // POST: api/Cuenta
        [HttpPost]
        public IActionResult CrearCuenta([FromBody] Cuenta cuenta)
        {
            _context.Cuentas.Add(cuenta);
            _context.SaveChanges();
            return Ok(cuenta);
        }

        // PUT: api/Cuenta/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarCuenta(int id, [FromBody] Cuenta cuentaActualizada)
        {
            var cuenta = _context.Cuentas.Find(id);
            if (cuenta == null) return NotFound();

            cuenta.Nombre = cuentaActualizada.Nombre;
            cuenta.PresupuestoAsignado = cuentaActualizada.PresupuestoAsignado;

            _context.SaveChanges();
            return Ok(cuenta);
        }

        // DELETE: api/Cuenta/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarCuenta(int id)
        {
            var cuenta = _context.Cuentas.Find(id);
            if (cuenta == null) return NotFound();

            _context.Cuentas.Remove(cuenta);
            _context.SaveChanges();
            return Ok(new { mensaje = "Cuenta eliminada" });
        }
    }
}
