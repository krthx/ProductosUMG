using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Tienda2013407.Models
{
    public class Compra
    {
        [Key]
        public int ID { get; set; }
        public string detalle { get; set; }
        
        //Llaves foraneas
        public int idUsuario { get; set; }
        public int idProducto { get; set; }

        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }
    }
}