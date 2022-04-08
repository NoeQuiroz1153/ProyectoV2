using ProyectoV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoV2.DBContext
{
    public class LaBodegaContext : DbContext
    {
        public LaBodegaContext() : base("LaBodega")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }

        public DbSet<Clasificacion> Clasificacion { get; set; }

        public DbSet<ClasiProductos> ClasiProductos { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<DetallePedidos> DetallePedidos { get; set; }



    }
}