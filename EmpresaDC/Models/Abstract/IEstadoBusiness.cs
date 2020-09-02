using ImportacionesDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Abstract
{
    public interface IEstadosBusiness
    {
        Task<IEnumerable<Estado>> ObtenerTodosLosEstados();
        Task<Estado> ObtenerEstadoPorId(int? id);
        Task CrearEditarEstado(Estado estado);
        Task EliminarEstado(Estado estado);

    }
}
