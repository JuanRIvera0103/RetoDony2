using ImportacionesDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Abstract
{
    public interface ITransportadoraBusiness
    {

        Task<Transportadora> ObtenerTransportadoraPorId(int? id);
        Task CrearEditarTransportadora(Transportadora transportadora);
        Task EliminarTransportadora(Transportadora transportadora);
        Task<IEnumerable<Transportadora>> ListarTodasTransportadoras();


    }
}
