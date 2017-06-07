namespace Tienda2013407.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tienda2013407.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tienda2013407.Models.Tienda2013407Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tienda2013407.Models.Tienda2013407Context context)
        {
            context.Usuarios.AddOrUpdate(use => use.ID,
                new Usuario() {ID=1, nombre = "Ckoby", nick = "coco", pass = "123patito", correo="coco@gmail.com" }
                );
            context.Productoes.AddOrUpdate(pro => pro.ID,
                new Producto(){ID = 1, nombre="limon", precio = 5, existencia = 10, imagen = "limon.jpg", descripcion = "limon persy", categoria = "fruta"}

                );
            context.Compras.AddOrUpdate(com => com.ID,
                new Compra() {ID = 1, detalle = "venta de limon", idUsuario=1, idProducto=1 }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
