using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_db.Models;
namespace web_api_db.Controllers{

    [Route("api/[controller]")]
    public class EmpleadosController : Controller {
        private Conexion dbConexion;
        public EmpleadosController(){
            dbConexion = Conectar.Create();

        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(dbConexion.Empleados.ToArray());

        }
        
        [HttpGet("{id}")]
         public ActionResult Get(int id) {
             var empleados = dbConexion.Empleados.SingleOrDefault(a => a.id_empleados == id);
            if (empleados != null) {
                return Ok(empleados);
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Empleados empleados){
            if (!ModelState.IsValid)
            return BadRequest();
             dbConexion.Empleados.Add(empleados);
             dbConexion.SaveChanges();
             return Created("api/empleados",empleados);
        }

    [HttpPut]
    public ActionResult Put(int id,[FromBody] Empleados empleados){
        var v_empleados = dbConexion.Empleados.SingleOrDefault(a => a.id_empleados == empleados.id_empleados);
        if (v_empleados != null && ModelState.IsValid) {
            dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleados);
            dbConexion.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
    }

[HttpDelete("{id}")]
public ActionResult Delete(int id) {
    var empleados = dbConexion.Empleados.SingleOrDefault(a => a.id_empleados == id);
    if(empleados!= null) {
        dbConexion.Empleados.Remove(empleados);
        dbConexion.SaveChanges();
                return Ok();
        } 
        else {    
            return NotFound();
        }
}

}

}