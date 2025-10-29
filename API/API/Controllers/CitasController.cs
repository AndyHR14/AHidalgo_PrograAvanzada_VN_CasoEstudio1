using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : Controller
    {
        private readonly CitasService _CitasService;


        public CitasController(CitasService _CitasService)
        {
            _CitasService = _CitasService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Citas>> GetCita()
        {
            return _CitasService.GetCita();
        }


        [HttpGet("{id}")]
        public ActionResult<Citas> GetByIdCita(int id)
        {
            return _CitasService.GetByIdCita(id);
        }

        [HttpPost]
        public ActionResult PostCita(Citas _CitaModel)
        {

            Citas newCitas = _CitasService.PostCita(_CitaModel);


            return CreatedAtAction(
                    nameof(GetCita),
                    new
                    {
                        id = newCitas.MontoTotal
                    },
                        newCitas);

        }

        [HttpPut]
        public ActionResult PutCita(Citas _CitaModel)
        {
            if (!_CitasService.PutCita(_CitaModel))
            {
                return NotFound(
                     new
                     {
                         Mensaje = "No se encontro el registro"
                     }
                    );
            }

            return NoContent();
        }


        [HttpDelete]
        public ActionResult DeleteCita(int _id)
        {
            if (!_CitasService.DeleteCita(_id))
            {
                return NotFound(
                     new
                     {
                         Mensaje = "No se encontro el registro"
                     }
                    );
            }

            return NoContent();

        }


    }
}
