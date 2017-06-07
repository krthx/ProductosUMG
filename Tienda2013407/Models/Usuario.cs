using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tienda2013407.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string nombre { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
        public string correo { get; set; }
    }
}