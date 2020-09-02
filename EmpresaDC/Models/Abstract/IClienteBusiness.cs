using ImportacionesDC.Clases;
using ImportacionesDC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Abstract
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<Cliente>> ObtenerClientes();
        Task<Cliente> ObtenerClienteId(int? id);
        Task GuardarEditarCliente(Cliente cliente);
        Task EliminarCliente(Cliente cliente);
        Task<IEnumerable<Paquete>> ObtenerPaquetesClienteId(int? id);
    }
}
