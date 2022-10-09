using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoClienteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        public static List<Genero> generos = new List<Genero>
        {
           new Genero {
                CodigoGenero = 1,
                DescripcionGenero = "Masculino",
            }
        };

        //Listar generos--GET: api/<GeneroController>
        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return Ok(generos);
        }

        //Buscar genero por codigoGenero GET api/<GeneroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = generos.Find(x => x.CodigoGenero == id);
            if (genero == null)
                return BadRequest("Genero no encontrado.");
            return Ok(genero);
        }

        //Agregar genero--POST api/<GeneroController>
        [HttpPost]
        public async Task<ActionResult<List<Genero>>> AddGenero(Genero genero)
        {
            generos.Add(genero);
            return Ok(genero);
        }

        //Modificar genero--PUT api/<GeneroController>/5
        [HttpPut]
        public async Task<ActionResult<List<Genero>>> UpdateGenero(Genero request)
        {
            var genero = generos.Find(x => x.CodigoGenero == request.CodigoGenero);
            if (genero == null)
                return BadRequest("Genero no encontrado.");
            genero.CodigoGenero = request.CodigoGenero;
            genero.DescripcionGenero = request.DescripcionGenero;
            return Ok(generos);

        }

        //Eliminar genero por codigoGeneroDELETE api/<GeneroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genero>> Delete(int id)
        {
            var genero = generos.Find(x => x.CodigoGenero == id);
            if (genero == null)
                return BadRequest("Cliente no encontrado.");
            generos.Remove(genero);
            return Ok(genero);
        }
    }
}
