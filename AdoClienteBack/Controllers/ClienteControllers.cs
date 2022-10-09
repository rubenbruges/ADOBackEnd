using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoClienteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteControllers : ControllerBase
    {
        public static List<Cliente> clientes = new List<Cliente>
        {
           new Cliente {
               TipoIdentificacíon = 1,
               NumeroIdentificacion = 123456,
               Nombre = "Ruben",
               Apellido = "Barbosa",
               Direccion = "Calle 41",
               Genero = "M",
               EstadoDelSistema = 1
                }
        };
        
        // Mostrar datos Cliente--GET: api/<Cliente>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(clientes);
        }

        //Buscar datos Cliente por numeroDocumento-- GET api/<Cliente>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = clientes.Find(x => x.NumeroIdentificacion == id);
            if (cliente == null)
                return BadRequest("Cliente no encontrado.");
            return Ok(cliente);
        }


        //Agregar dato Cliente--POST api/<Cliente>
        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AddCliente (Cliente cliente)
        {
            clientes.Add(cliente);
            return Ok(clientes);

        }

        //Modificar dato Cliente por numeroDocumento--PUT api/<Cliente>/5
        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente request)
        {
            var cliente = clientes.Find(x => x.NumeroIdentificacion == request.NumeroIdentificacion);
            if (cliente == null)
                return BadRequest("Cliente no encontrado.");
            cliente.TipoIdentificacíon = request.TipoIdentificacíon;
            cliente.NumeroIdentificacion = request.NumeroIdentificacion;
            cliente.Nombre = request.Nombre;
            cliente.Apellido = request.Apellido;
            cliente.Direccion = request.Direccion;
            cliente.Genero = request.Genero;
            cliente.EstadoDelSistema = request.EstadoDelSistema;           

            return Ok(clientes);

        }

        //Eliminar dato Cliente por numeroDocumento--DELETE api/<Cliente>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var cliente = clientes.Find(x => x.NumeroIdentificacion == id);
            if (cliente == null)
                return BadRequest("Cliente no encontrado.");
            clientes.Remove(cliente);
            return Ok(cliente);
        }
    }
}
