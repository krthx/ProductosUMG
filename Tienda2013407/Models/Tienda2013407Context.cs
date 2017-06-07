﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tienda2013407.Models
{
    public class Tienda2013407Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Tienda2013407Context() : base("name=Tienda2013407Context")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Tienda2013407.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Tienda2013407.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<Tienda2013407.Models.Compra> Compras { get; set; }
    
    }
}
