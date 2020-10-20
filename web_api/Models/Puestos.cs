using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_db.Models{
public class Puestos{
        [Key]
        public int id_puestos { get; set; }
        public string puesto { get; set; }

}

}