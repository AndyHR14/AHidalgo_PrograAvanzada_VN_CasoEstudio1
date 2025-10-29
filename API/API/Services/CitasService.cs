using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CitasService
    {
        private readonly AppDbContext _context;


        //El iniciador???
        public CitasService(AppDbContext context)
        {
            _context = context;
        }

        //Funcion de obtener datos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Producto.ToListAsync());
        //}
        //GET
        public List<Citas> GetCita()
        {
            return _context.Cita.ToList();
        }


        //GET/ID
        public Citas GetByIdCita(int _id)
        {
            return _context.Cita.FirstOrDefault(p => p.Id == _id);
        }


        //POST
        public Citas PostCita(Citas _Citas)
        {
            //                 _context.Add(_producto);
            //await _context.SaveChangesAsync();
            _context.Cita.Add(_Citas);
            _context.SaveChanges();

            return _Citas;

        }

        //PUT
        public bool PutCita(Citas _Citas)
        {

            var entidad = _context.Cita.FirstOrDefault(p => p.Id == _Citas.Id);

            if (entidad == null)
            {
                return false;
            }

            entidad.NombreDeLaPersona = _Citas.NombreDeLaPersona;
            entidad.Identificacion = _Citas.Identificacion;
            entidad.Telefono = _Citas.Telefono;
            entidad.Correo = _Citas.Correo;
            entidad.FechaNacimiento = _Citas.FechaNacimiento;
            entidad.Direccion = _Citas.Direccion;
            entidad.MontoTotal = _Citas.MontoTotal;
            entidad.FechaDeLaCita = _Citas.FechaDeLaCita;
            entidad.FechaDeRegistro = _Citas.FechaDeRegistro;           
            entidad.IdServicio = _Citas.IdServicio;

            _context.SaveChanges();

            return true;
        }


        //DELETE
        public bool DeleteCita(int _id)
        {

            var entidad = _context.Cita.FirstOrDefault(p => p.Id == _id);

            if (entidad == null)
            {
                return false;
            }

            _context.Cita.Remove(entidad);
            _context.SaveChanges();

            return true;
        }
    }
}