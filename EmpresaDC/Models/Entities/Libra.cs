using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libras.Models
{
    public class Libra
    {
        [Key]
        public int IdLibra { get; set; }
        [DisplayName("Valor de la Libra")]
        [Required]
        public int ValorLibra { get; set; }

        [DisplayName("Fecha de Inicio")]
        [Column("FechaInicio", TypeName="nvarchar(12)")]
        public string FechaInicio { get; set; }
        [DisplayName("Hora de Inicio")]
        [Column("HoraInicio", TypeName = "nvarchar(12)")]
        public string HoraInicio { get; set; }

        [DisplayName("Fecha de Finalización")]
        [Column("FechaFinalizacion", TypeName = "nvarchar(12)")]
        public string FechaFinal { get; set; }
        [DisplayName("Hora de Finalización")]
        [Column("HoraFinal", TypeName = "nvarchar(10)")]
        public string HoraFinal { get; set; }

    }
}
