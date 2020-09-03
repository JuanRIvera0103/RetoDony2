using ImportacionesDC.Clases;
using ImportacionesDC.Models.Entities;
using Libras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Abstract
{
    public interface IPaqueteBusiness
    {
        Task<IEnumerable<PaqueteDetalle>> ObtenerPaquetes();
        Task<Paquete> ObtenerPaqueteId(int? codigo);
        Task GuardarEditarPaquete(Paquete paquete);
        Task EliminarPaquete(Paquete paquete);
        Task<IEnumerable<Cliente>> ObtenerClientes();
        Task<IEnumerable<Transportadora>> ObtenerTransportadoras();
        Task<IEnumerable<Estado>> ObtenerEstados();
        Task<IEnumerable<TipoMercancia>> ObtenerTiposMercancia();
        Libra ObtenerUltimaLibra();
        Task<Cliente> ObtenerClientePorId(int? id);
        Task<Estado> ObtenerEstadoPorId(int? id);
        Task<Transportadora> ObtenerTransportadoraPorId(int? id);
        Task<TipoMercancia> ObtenerMercanciaPorId(int? id);
    }
}
