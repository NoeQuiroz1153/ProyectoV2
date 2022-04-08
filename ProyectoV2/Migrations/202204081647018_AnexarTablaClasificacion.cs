namespace ProyectoV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaClasificacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clasificacion",
                c => new
                    {
                        ClasificacionId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClasificacionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clasificacion");
        }
    }
}
