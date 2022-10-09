using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoClienteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoClienteControllers : ControllerBase
    {
        public static List<EstadoCliente> estados = new List<EstadoCliente>
        {
           new EstadoCliente {
                CodigoEstadoCliente = 1,
                DescripcionEstadoCliente = "Activo",
            }
        };
        //Listar estados de sistema--GET: api/<EstadoClienteControllers>
        [HttpGet]
        public async Task<ActionResult<List<EstadoCliente>>> Get()
        {
            return Ok(estados);
        }

        //Buscar estado por codigoEstadoCliente--GET api/<EstadoClienteControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCliente>> Get(int id)
        {
            var estado = estados.Find(x => x.CodigoEstadoCliente == id);
            if (estado == null)
                return BadRequest("Estado no encontrado.");
            return Ok(estado);
        }

        //Agregar estado de sistema--POST api/<EstadoClienteControllers>
        [HttpPost]
        public async Task<ActionResult<List<EstadoCliente>>> AddEstadoCliente(EstadoCliente estado)
        {
            estados.Add(estado);
            return Ok(estado);
        }

        //Modificar estado de sistema--PUT api/<EstadoClienteControllers>/5
        [HttpPut]
        public async Task<ActionResult<List<EstadoCliente>>> UpdateEstadoCliente(EstadoCliente request)
        {
            var estado = estados.Find(x => x.CodigoEstadoCliente == request.CodigoEstadoCliente);
            if (estado == null)
                return BadRequest("Estado no encontrado.");
            estado.CodigoEstadoCliente = request.CodigoEstadoCliente;
            estado.DescripcionEstadoCliente = request.DescripcionEstadoCliente;
            return Ok(estados);

        }

        //Eliminar estado de sistema por código--DELETE api/<EstadoClienteControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoCliente>> Delete(int id)
        {
            var estado = estados.Find(x => x.CodigoEstadoCliente == id);
            if (estado == null)
                return BadRequest("Cliente no encontrado.");
            estados.Remove(estado);
            return Ok(estado);
        }
    }
}
