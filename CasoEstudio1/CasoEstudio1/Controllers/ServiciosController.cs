using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1.Data;
using CasoEstudio1.Models;

namespace CasoEstudio1.Controllers
{
    public class ServiciosController : Controller
    {

        //Invocar o hacer una instancia
        private readonly AppDbContext _context;

        //Instanciarme
        public ServiciosController(AppDbContext context)
        {
            _context = context;
        }


        //Los metodos ahora son asyncronicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SERVICIOS.ToListAsync());
        }


        //Crear???

        public IActionResult Crear()
        {

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Crear(Servicios _servicio)
        {
            _servicio.FechaDeModificacion = DateTime.Now;

            if (ModelState.IsValid)
            {

                _context.Add(_servicio);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(_servicio);
        }


        //Get /Editar/Id

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servicios itemServicios = await _context.SERVICIOS.FindAsync(id);
            if (itemServicios == null)
            {
                return NotFound();
            }
            return View(itemServicios);
        }


        //Post
        [HttpPost]
        public async Task<IActionResult> Editar(Servicios _servicio)
        {

            //ProductoModel itemProducto = await _context.Producto.FindAsync(_producto.Id);
            //if (itemProducto == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {

                _context.Update(_servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(_servicio);
        }




        //Get /Eliminar/Id

        public async Task<IActionResult> Eliminar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Servicios itemServicios = await _context.SERVICIOS.FindAsync(id);

            if (itemServicios == null)
            {
                return NotFound();
            }
            return View(itemServicios);
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            Servicios itemServicios = await _context.SERVICIOS.FindAsync(Id);

            if (itemServicios == null)
            {
                return NotFound();
            }
            else
            {
                _context.SERVICIOS.Remove(itemServicios);
                await _context.SaveChangesAsync();
            }




            return RedirectToAction(nameof(Index));
        }

    }
}
