using System.ComponentModel.DataAnnotations.Schema;

namespace API_App_Presupuesto.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; } = string.Empty;

        public string PasswordHash { get; set; }
        public string Rol { get; set; }// Admin / Empleado
    }
}
