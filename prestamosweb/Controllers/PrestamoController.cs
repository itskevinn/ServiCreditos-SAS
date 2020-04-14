using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace prestamosweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly ServicioDePrestamo _servicioDePrestamo;
        public IConfiguration Configuration { get; }
        public PrestamoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string cadenaDeConexión = Configuration["ConnectionStrings:DefaultConnection"];
            _servicioDePrestamo = new ServicioDePrestamo(cadenaDeConexión);
        }

        // GET: api/Prestamo
        [HttpGet]
        public IEnumerable<PrestamoViewModel> get()
        {
            var respuesta = _servicioDePrestamo.ConsultarPrestamos().Prestamos.Select(p => new PrestamoViewModel(p));
            return respuesta;
        }

        // POST: api/Prestamo
        [HttpPost]
        public ActionResult<PrestamoViewModel> Post(PrestamoInputModel prestamoInput)
        {
            Prestamo prestamo = MapearPrestamo(prestamoInput);
            var respuesta = _servicioDePrestamo.Guardar(prestamo);
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Prestamo);
        }
        private Prestamo MapearPrestamo(PrestamoInputModel prestamoInput)
        {
            var prestamo = new Prestamo
            {
                Identidad = prestamoInput.Identidad,
                Nombre = prestamoInput.Nombre,
                CapitalInicial = prestamoInput.CapitalInicial,
                TasaInteres = prestamoInput.TasaInteres,
                Tiempo = prestamoInput.Tiempo,                
            };
            return prestamo;
        }    
    }
}
