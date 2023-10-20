using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly ApplicationDBContext _db;

        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }




        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Producto> p= await _db.Producto.ToListAsync();
            return Ok(p);
        }


        // GET api/<ProductoController>/5
        [HttpGet("{IdProducto}")]
        public async Task<IActionResult> Get(int IdProducto)
        {
            Producto p= await _db.Producto.FirstOrDefaultAsync(x=>x.IdProducto==IdProducto);
            if (p == null)
            {
                return BadRequest();
            }
            return Ok(p);
        }




        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            Producto p = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == producto.IdProducto);
            if(p == null && producto != null) {
                await _db.Producto.AddAsync(producto);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }

            return BadRequest("No existe el objeto");
        }




        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
