using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libras.Models
{
    public interface ILibrasBussines
    {
        Task<Libra> ObtenerUltimaLibra();
        Task Eliminar(Libra libra);
        Task CrearEditar(Libra libra);
        Task<Libra> ObtenerLibraPorId(int? id);
        Task<IEnumerable<Libra>> ObtenerTodasLasLibras();
        
    }
}
