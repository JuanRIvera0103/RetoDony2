using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Entities
{
    public class Transportadora
    {
        [Key]
        public int IdTransportadora { get; set; }

        [DisplayName("Nombre Transportadora")]
        [Column("NombreTransportadora", TypeName = "nvarchar(50)")]
        [Required]
        public string Nombre { get; set; }
    }
}
