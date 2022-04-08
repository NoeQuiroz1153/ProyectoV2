using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoV2.Models
{
    public class Clientes
    {
        [Key]
        [Required]
        [Display(Name = " Codigo del Cliente")]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        public int ClasificacionId { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]

        public int PorcDescuento { get; set; }

        [Required]
        public bool Estado { get; set; }

        public Clasificacion Clasificacion { get; set; }

    }
}