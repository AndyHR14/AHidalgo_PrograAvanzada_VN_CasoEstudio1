using Microsoft.EntityFrameworkCore;
using API.Model;


namespace API.Data
{
    public class AppDbContext : DbContext
    {
        //Creo un constructor vacio
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Citas> Cita { get; set; }
        public DbSet<Servicios> Servicio { get; set; }

    }
}



