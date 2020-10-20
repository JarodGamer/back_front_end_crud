using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_db.Models;
namespace web_api_db.Controllers{

[Route("api/[controller]")]
    public class ClientesController : Controller {
        private Conexion dbConexion;
        public ClientesController(){
            dbConexion = Conectar.Create();

        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(dbConexion.Clientes.ToArray());

        }

        [HttpGet("{id}")]
         public ActionResult Get(int id) {
             var clientes = dbConexion.Clientes.SingleOrDefault(a => a.id_cliente == id);
            if (clientes != null) {
                return Ok(clientes);
            } else {
                return NotFound();
            }
        }

         [HttpPost]
        public ActionResult Post([FromBody] Clientes clientes){
            if (!ModelState.IsValid)
            return BadRequest();
             dbConexion.Clientes.Add(clientes);
             dbConexion.SaveChanges();
             return Created("api/clientes",clientes);
        }

    [HttpPut]
    public ActionResult Put(int id,[FromBody] Clientes clientes){
        var v_clientes = dbConexion.Clientes.SingleOrDefault(a => a.id_cliente == clientes.id_cliente);
        if (v_clientes != null && ModelState.IsValid) {
            dbConexion.Entry(v_clientes).CurrentValues.SetValues(clientes);
            dbConexion.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
    }

[HttpDelete("{id}")]
public ActionResult Delete(int id) {
    var clientes = dbConexion.Clientes.SingleOrDefault(a => a.id_cliente == id);
    if(clientes!= null) {
        dbConexion.Clientes.Remove(clientes);
        dbConexion.SaveChanges();
                return Ok();
        } 
        else {    
            return NotFound();
        }
}

}

}