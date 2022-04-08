namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        ClasificacionId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PorcDescuento = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Clasificacion", t => t.ClasificacionId)
                .Index(t => t.ClasificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "ClasificacionId", "dbo.Clasificacion");
            DropIndex("dbo.Clientes", new[] { "ClasificacionId" });
            DropTable("dbo.Clientes");
        }
    }
}
