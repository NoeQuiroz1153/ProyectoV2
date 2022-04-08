using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoV2.Models
{
    public class Productos
    {
        [Key]
        [Required]
        [Display(Name = "Codigo del Producto")]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]

        public int ClasiProducId { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public bool Estado { get; set; }



        public ClasiProductos ClasiProductos { get; set; }

        public Unidad Unidad { get; set; }


    }
}