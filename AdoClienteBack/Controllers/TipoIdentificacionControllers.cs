using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoClienteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionControllers : ControllerBase
    {
        public static List<TipoIdentificacion> tipos = new List<TipoIdentificacion>
        {
           new TipoIdentificacion {
                CodTipoIdentificacion = 1,
                DescripcionIdentificacion = "Cédula de Ciudadania",
            }
        };


        //Listar tipos de identificaciones--GET: api/<TipoIdentificacionControllers>
        [HttpGet]
        public async Task<ActionResult<List<TipoIdentificacion>>> Get()
        {
            return Ok(tipos);
        }

        //Buscar dato TipoIdentificacion por CodTipoIdentificacion--GET api/<TipoIdentificacionControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> Get(int id)
        {
            var tipo = tipos.Find(x => x.CodTipoIdentificacion == id);
            if (tipo == null)
                return BadRequest("Tipo documento no encontrado.");
            return Ok(tipo);
        }

        //Agregar dato TipoIdentificacion--POST api/<TipoIdentificacionControllers>
        [HttpPost]
        public async Task<ActionResult<List<TipoIdentificacion>>> AddTipoIdentificacion(TipoIdentificacion tipo)
        {
            tipos.Add(tipo);
            return Ok(tipos);

        }

        //Modificar tipoIdentificacion--PUT api/<TipoIdentificacionControllers>/5
        [HttpPut]
        public async Task<ActionResult<List<TipoIdentificacion>>> UpdateTipoIdentificacion(TipoIdentificacion request)
        {
            var tipo = tipos.Find(x => x.CodTipoIdentificacion == request.CodTipoIdentificacion);
            if (tipo == null)
                return BadRequest("Cliente no encontrado.");
            tipo.CodTipoIdentificacion = request.CodTipoIdentificacion;
            tipo.DescripcionIdentificacion = request.DescripcionIdentificacion;
            return Ok(tipos);

        }

        //Eliminar tipoIdentificacion por codigo--DELETE api/<TipoIdentificacionControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> Delete(int id)
        {
            var tipo = tipos.Find(x => x.CodTipoIdentificacion == id);
            if (tipo == null)
                return BadRequest("Cliente no encontrado.");
            tipos.Remove(tipo);
            return Ok(tipo);
        }
    }
}
