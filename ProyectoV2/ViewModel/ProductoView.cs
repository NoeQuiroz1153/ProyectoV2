using ProyectoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoV2.ViewModel
{
    public class ProductoView
    {
        public Productos Productos { get; set; }
        public List<ClasiProductos> ClasiProductos { get; set; }
        public List<Unidad> Unidad { get; set; }

    }
}