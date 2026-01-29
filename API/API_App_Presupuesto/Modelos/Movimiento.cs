namespace API_App_Presupuesto.Modelos
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public int IdDepartamento { get; set; }
        public int IdResponsable { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // Ingreso / Gasto
        public string Descripcion { get; set; }
    }
}
