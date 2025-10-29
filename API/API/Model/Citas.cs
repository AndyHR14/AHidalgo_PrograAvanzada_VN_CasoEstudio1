namespace API.Model
{
    public class Citas
    {
        public int Id { get; set; }
        public string NombreDeLaPersona { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaDeRegistro { get; set; }
        public string FechaDeLaCita { get; set; }
        public int IdServicio { get; set; }

        /*
        CREATE TABLE CITAS(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreDeLaPersona VARCHAR(150) NOT NULL,
    Identificacion VARCHAR(30) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Correo VARCHAR(50) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    MontoTotal DECIMAL(18,2) NOT NULL,
    FechaDeLaCita DATETIME NOT NULL,
    FechaDeRegistro DATETIME NOT NULL,
    IdServicio INT NOT NULL,
    FOREIGN KEY(IdServicio) REFERENCES SERVICIOS(Id)
);
        */
    }
}
