namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaPedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DescTotal = c.Double(nullable: false),
                        Subtotal = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Pedidos", new[] { "ClienteId" });
            DropTable("dbo.Pedidos");
        }
    }
}
