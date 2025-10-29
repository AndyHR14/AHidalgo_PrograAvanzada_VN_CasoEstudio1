using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1.Data;
using CasoEstudio1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasoEstudio1.Controllers
{
    public class CitasController : Controller
    {

        //Invocar o hacer una instancia
        private readonly AppDbContext _context;

        //Instanciarme
        public CitasController(AppDbContext context)
        {
            _context = context;
        }


        //Los metodos ahora son asyncronicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SERVICIOS.ToListAsync());
        }

        public async Task<IActionResult> Reservar(int? IdServicio)
        {
            ViewBag.IdServicio = new SelectList(await _context.SERVICIOS.ToListAsync(), "Id", "Nombre", IdServicio);

            var cita = new Citas
            {
                IdServicio = IdServicio.GetValueOrDefault()
            };

            return View(cita);
        }

        private string ObtenerNombreEspecialidad(int id)
        {
            return id switch
            {
                1 => "Medicina General",
                2 => "Imagenología",
                3 => "Microbiología",
                _ => "Desconocida"
            };
        }

        [HttpPost]
        public async Task<IActionResult> Reservar([Bind("NombreDeLaPersona,Identificacion,Telefono,Correo,FechaNacimiento,Direccion,FechaDeLaCita,IdServicio")] Citas _Cita)
        {
            _Cita.FechaDeRegistro = DateTime.Now;

            var servicio = await _context.SERVICIOS.FindAsync(_Cita.IdServicio);

            if (servicio == null)
            {
                ModelState.AddModelError("IdServicio", "El servicio seleccionado no es válido.");
            }
            else
            {
                _Cita.MontoTotal = (servicio.Monto * servicio.IVA) + servicio.Monto;
            }

            if (ModelState.IsValid)
            {
                _context.Add(_Cita);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdServicio = new SelectList(await _context.SERVICIOS.ToListAsync(), "Id", "Nombre", _Cita.IdServicio);
            return View(_Cita);
        }


        //Get /Editar/Id

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Citas itemCitas = await _context.CITAS.FindAsync(id);
            if (itemCitas == null)
            {
                return NotFound();
            }
            return View(itemCitas);
        }


        //Post
        [HttpPost]
        public async Task<IActionResult> Editar(Citas _Cita)
        {

            //ProductoModel itemProducto = await _context.Producto.FindAsync(_producto.Id);
            //if (itemProducto == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {

                _context.Update(_Cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(_Cita);
        }




        //Get /Eliminar/Id

        public async Task<IActionResult> Eliminar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Citas itemCitas = await _context.CITAS.FindAsync(id);

            if (itemCitas == null)
            {
                return NotFound();
            }
            return View(itemCitas);
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            Citas itemCitas = await _context.CITAS.FindAsync(Id);

            if (itemCitas == null)
            {
                return NotFound();
            }
            else
            {
                _context.CITAS.Remove(itemCitas);
                await _context.SaveChangesAsync();
            }




            return RedirectToAction(nameof(Index));
        }

    }
}
