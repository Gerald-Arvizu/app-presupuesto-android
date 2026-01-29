using Microsoft.AspNetCore.Mvc;
using API_App_Presupuesto.Datos;
using API_App_Presupuesto.Modelos;
using BCrypt.Net;
using System.Linq;

namespace API_App_Presupuesto.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Usuario/Registrar
        [HttpPost("Registrar")]
        public IActionResult Registrar([FromBody] Usuario usuario)
        {
            // Verificar si ya existe un usuario con ese correo
            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
                return BadRequest(new { mensaje = "El usuario ya existe" });

            // Encriptar la contraseña
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.Password);

            // Guardar en la base de datos
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(new { mensaje = "Usuario registrado correctamente" });
        }

        // POST: api/Usuario/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            // Buscar el usuario por email
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            if (user == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            // Verificar contraseña
            bool valido = BCrypt.Net.BCrypt.Verify(usuario.Password, user.PasswordHash);
            if (!valido)
                return BadRequest(new { mensaje = "Contraseña incorrecta" });

            // Retornar datos del usuario (sin la contraseña)
            return Ok(new
            {
                mensaje = "Login exitoso",
                usuario = new
                {
                    user.IdUsuario,
                    user.Nombre,
                    user.Email,
                    user.Rol
                }
            });
        }
    }
}
