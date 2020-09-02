using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Entities
{
    public class Cliente
    {
        [Key]        
        public int NumeroCasillero { get; set; }
        [DisplayName("Nombre Completo")]
        [Column("NombreCliente", TypeName ="nvarchar(50)")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [DisplayName("Dirección de Entrega")]
        [Column("DireccionEntrega", TypeName = "nvarchar(50)")]
        [Required]
        public string Direccion { get; set; }
    }
}
