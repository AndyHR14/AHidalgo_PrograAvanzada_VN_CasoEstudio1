using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasoEstudio1.Models
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
    public DateTime FechaDeRegistro { get; set; }
    public DateTime? FechaDeModificacion { get; set; }
    public bool Estado { get; set; }

    public ICollection<Citas> Citas { get; } = new List<Citas>();
    }
}
