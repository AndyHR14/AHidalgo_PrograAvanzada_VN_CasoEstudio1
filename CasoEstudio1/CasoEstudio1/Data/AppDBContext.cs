using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1.Models;
using System;

namespace CasoEstudio1.Data
{
    public class AppDbContext : DbContext
    {
        //Creo un constructor vacio
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Citas> CITAS { get; set; }
        public DbSet<Servicios> SERVICIOS { get; set; }

    }
}
