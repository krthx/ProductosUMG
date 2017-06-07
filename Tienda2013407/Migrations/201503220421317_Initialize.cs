namespace Tienda2013407.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        detalle = c.String(),
                        idUsuario = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                        Producto_ID = c.Int(),
                        Usuario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Productoes", t => t.Producto_ID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_ID)
                .Index(t => t.Producto_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        precio = c.Int(nullable: false),
                        existencia = c.Int(nullable: false),
                        imagen = c.String(),
                        descripcion = c.String(),
                        categoria = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        nick = c.String(),
                        pass = c.String(),
                        correo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Compras", "Producto_ID", "dbo.Productoes");
            DropIndex("dbo.Compras", new[] { "Usuario_ID" });
            DropIndex("dbo.Compras", new[] { "Producto_ID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Productoes");
            DropTable("dbo.Compras");
        }
    }
}
