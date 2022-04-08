namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaDetallePedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallePedidos",
                c => new
                    {
                        DetaPedidoId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Descuento = c.Double(nullable: false),
                        SubtotalLinea = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetaPedidoId)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId)
                .ForeignKey("dbo.Productos", t => t.ProductoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePedidos", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.DetallePedidos", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.DetallePedidos", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidos", new[] { "PedidoId" });
            DropTable("dbo.DetallePedidos");
        }
    }
}
