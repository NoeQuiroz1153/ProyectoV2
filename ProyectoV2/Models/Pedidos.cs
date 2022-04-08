using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoV2.Models
{
    public class Pedidos
    {
        [Key]
        [Required]
        [Display(Name = " Codigo del Pedido")]
        public int PedidoId { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }


        [Required]
        public int ClienteId { get; set; }

        [Required]
        public double DescTotal { get; set; }

        [Required]
        public double Subtotal { get; set; }

        [Required]
        public double total { get; set; }


        [Required]
        public bool Estado { get; set; }


        public Clientes Clientes { get; set; }

    }
}