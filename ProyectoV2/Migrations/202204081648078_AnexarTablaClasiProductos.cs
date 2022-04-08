namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaClasiProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasiProductos",
                c => new
                    {
                        ClasiProducId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClasiProducId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClasiProductos");
        }
    }
}
