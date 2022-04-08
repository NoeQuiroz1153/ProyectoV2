namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        ClasiProducId = c.Int(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Precio = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.ClasiProductos", t => t.ClasiProducId)
                .ForeignKey("dbo.Unidad", t => t.UnidadMedidaId)
                .Index(t => t.ClasiProducId)
                .Index(t => t.UnidadMedidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "UnidadMedidaId", "dbo.Unidad");
            DropForeignKey("dbo.Productos", "ClasiProducId", "dbo.ClasiProductos");
            DropIndex("dbo.Productos", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Productos", new[] { "ClasiProducId" });
            DropTable("dbo.Productos");
        }
    }
}
