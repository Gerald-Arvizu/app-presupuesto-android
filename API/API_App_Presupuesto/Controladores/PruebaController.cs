using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PruebaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Prueba/Conexion
        [HttpGet("Conexion")]
        public IActionResult ProbarConexion()
        {
            try
            {
                // Intentar leer la tabla Usuarios
                var usuarios = _context.Usuarios.Take(1).ToList();
                return Ok(new { mensaje = "Conexión exitosa a SQL Server", cantidad = usuarios.Count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
