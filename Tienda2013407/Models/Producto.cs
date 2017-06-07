using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Tienda2013407.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int existencia { get; set; }
        public string imagen { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }

    }
}