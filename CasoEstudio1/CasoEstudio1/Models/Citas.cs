using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Mysqlx.Crud.Order.Types;

namespace CasoEstudio1.Models
{
    public class Citas
    {
        public int Id { get; set; }
        public string NombreDeLaPersona { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public decimal? MontoTotal { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeLaCita { get; set; }

    
        public int IdServicio { get; set; }

        [ForeignKey("IdServicio")]
        public Servicios? Servicio { get; set; }

    }
}
