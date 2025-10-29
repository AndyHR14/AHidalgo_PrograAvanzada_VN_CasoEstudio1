namespace API.Model
{
    public class Servicios
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public decimal IVA { get; set; }
        public int Especialidad { get; set; }
        public string Especialista { get; set; }
        public string Clinica { get; set; }
        public string FechaDeRegistro { get; set; }
        public string FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}

