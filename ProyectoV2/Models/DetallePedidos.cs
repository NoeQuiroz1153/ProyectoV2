using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoV2.Models
{
    public class DetallePedidos
    {
        [Key]
        [Required]
        [Display(Name = " Codigo del Pedido")]
        public int DetaPedidoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }


        [Required]
        public double Precio { get; set; }


        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double Descuento { get; set; }

        [Required]
        public double SubtotalLinea { get; set; }

        [Required]
        public double Total { get; set; }


        public Pedidos Pedidos { get; set; }

        public Productos Productos { get; set; }

    }
}