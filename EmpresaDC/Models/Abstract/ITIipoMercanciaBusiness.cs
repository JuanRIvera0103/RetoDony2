using ImportacionesDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Abstract
{
    public interface ITipoMercanciaBusiness
    {
        Task<TipoMercancia> ObtenerTipoMercanciaPorId(int? id);
        Task<IEnumerable<TipoMercancia>> ObtenerTodosTiposMercancia();
        Task GuardarEditarTipoMercancia(TipoMercancia tipoMercancia);
        Task EliminarTipoMercancia(TipoMercancia tipoMercancia);

    }
}
