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
    public class ServiciosController : Controller
    {
        private readonly ServiciosService _serviciosService;


        public ServiciosController(ServiciosService _serviciosService)
        {
            _serviciosService = _serviciosService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Servicios>> GetServicio()
        {
            return _serviciosService.GetServicio();
        }


        [HttpGet("{id}")]
        public ActionResult<Servicios> GetByIdServicio(int id)
        {
            return _serviciosService.GetByIdServicio(id);
        }

        [HttpPost]
        public ActionResult PostServicio(Servicios _servicioModel)
        {

            Servicios newServicios = _serviciosService.PostServicio(_servicioModel);


            return CreatedAtAction(
                    nameof(GetServicio),
                    new
                    {
                        id = newServicios.Monto
                    },
                        newServicios);

        }

        [HttpPut]
        public ActionResult PutServicio(Servicios _servicioModel)
        {
            if (!_serviciosService.PutServicio(_servicioModel))
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
        public ActionResult DeleteServicio(int _id)
        {
            if (!_serviciosService.DeleteServicio(_id))
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
