using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Entities
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        [DisplayName("Estado")]
        [Column("NombreEstado", TypeName = "nvarchar(50)")]
        [Required]
        public string Nombre { get; set; }
    }
}
