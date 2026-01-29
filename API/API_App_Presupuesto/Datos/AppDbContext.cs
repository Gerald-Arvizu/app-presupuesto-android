using Microsoft.EntityFrameworkCore;
using API_App_Presupuesto.Modelos;
using System.Collections.Generic;

namespace API_App_Presupuesto.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Representación de las tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
    }
}
