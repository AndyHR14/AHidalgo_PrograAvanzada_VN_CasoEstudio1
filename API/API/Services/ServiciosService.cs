using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ServiciosService
    {
        private readonly AppDbContext _context;


        //El iniciador???
        public ServiciosService(AppDbContext context)
        {
            _context = context;
        }

        //Funcion de obtener datos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Producto.ToListAsync());
        //}
        //GET
        public List<Servicios> GetServicio()
        {
            return _context.Servicio.ToList();
        }


        //GET/ID
        public Servicios GetByIdServicio(int _id)
        {
            return _context.Servicio.FirstOrDefault(p => p.Id == _id);
        }


        //POST
        public Servicios PostServicio(Servicios _servicios)
        {
            //                 _context.Add(_producto);
            //await _context.SaveChangesAsync();
            _context.Servicio.Add(_servicios);
            _context.SaveChanges();

            return _servicios;

        }

        //PUT
        public bool PutServicio(Servicios _servicios)
        {

            var entidad = _context.Servicio.FirstOrDefault(p => p.Id == _servicios.Id);

            if (entidad == null)
            {
                return false;
            }

            entidad.Nombre = _servicios.Nombre;
            entidad.Descripcion = _servicios.Descripcion;
            entidad.Monto = _servicios.Monto;
            entidad.IVA = _servicios.IVA;
            entidad.Especialidad = _servicios.Especialidad;
            entidad.Especialista = _servicios.Especialista;
            entidad.Clinica = _servicios.Clinica;
            entidad.FechaDeRegistro = _servicios.FechaDeRegistro;
            entidad.FechaDeModificacion = _servicios.FechaDeModificacion;
            entidad.Estado = _servicios.Estado;

            _context.SaveChanges();

            return true;
        }


        //DELETE
        public bool DeleteServicio(int _id)
        {

            var entidad = _context.Servicio.FirstOrDefault(p => p.Id == _id);

            if (entidad == null)
            {
                return false;
            }

            _context.Servicio.Remove(entidad);
            _context.SaveChanges();

            return true;
        }
    }
}
