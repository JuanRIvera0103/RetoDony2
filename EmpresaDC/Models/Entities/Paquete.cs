using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Entities
{
    public class Paquete
    {
        [Key]
        public int Codigo { get; set; }
        [DisplayName("Peso Libra")]        
        [Required]
        public float Peso { get; set; }      
        [Column("CasilleroCliente", TypeName = "int")]
        [Required]
        public int Casillero { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        public string Tracking { get; set; }
        [DisplayName("Empresa Transportadora")]
        [Column("EmpresaTransportadora", TypeName = "int")]
        [Required]
        public int Empresa { get; set; }        
        [Required]
        public int Tipo { get; set; }
        [DisplayName("Guia Colombia")]
        [Column("GuiaColombia", TypeName = "nvarchar(50)")]
        [Required]
        public string Guia { get; set; }
        [DisplayName("Valor Mercancia")]
        [Required]
        public float Valor { get; set; }        

    }
}
