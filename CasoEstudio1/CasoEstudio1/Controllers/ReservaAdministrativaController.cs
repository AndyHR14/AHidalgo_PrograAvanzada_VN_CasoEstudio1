using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1.Data;
using CasoEstudio1.Models;

namespace CasoEstudio1.Controllers
{
    public class ReservaAdministrativaController : Controller
    {
        private readonly AppDbContext _context;

        public ReservaAdministrativaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var citas = await _context.CITAS
                .Include(c => c.Servicio)
                .ToListAsync();

            return View(citas);
        }

        public IActionResult BuscarCita()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarCita(int idCita)
        {
            var cita = await _context.CITAS
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(c => c.Id == idCita);

            if (cita == null)
            {
                ViewBag.Mensaje = "Estimado usuario, no se ha encontrado la cita, favor realice una.";
                ViewBag.MostrarListar = true;
                return View();
            }

            return View("DetallesCita", cita);
        }
    }
}