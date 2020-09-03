using ImportacionesDC.Clases;
using ImportacionesDC.Models.Abstract;
using ImportacionesDC.Models.DAL;
using ImportacionesDC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.Business
{
    public class ClienteBusiness:IClienteBusiness
    {
        private readonly DbContextImportaciones _context;

        public ClienteBusiness(DbContextImportaciones context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> ObtenerClientes()
        {
            return await _context.clientes.ToArrayAsync();
        }

        public async Task<Cliente> ObtenerClienteId(int? id)
        {
            try
            {
                Cliente cliente;
                cliente = null;

                if (id == null)
                {
                    return cliente;
                }
                else
                {
                    cliente = await _context.clientes.FirstOrDefaultAsync(e => e.NumeroCasillero == id);
                    return cliente;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task GuardarEditarCliente(Cliente cliente)
        {
            try
            {
                if (cliente.NumeroCasillero == 0)
                    _context.Add(cliente);
                else
                    _context.Update(cliente);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public async Task EliminarCliente(Cliente cliente)
        {
            try
            {
                _context.clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<IEnumerable<PaqueteDetalle>> ObtenerPaquetesClienteId(int? id)
        {
            try
            {
                IEnumerable<PaqueteDetalle> listaClienteDetalle;
                listaClienteDetalle = null;

                if (id == null)
                {
                    return listaClienteDetalle;
                }
                else
                {
                    await using (_context)
                    {
                        listaClienteDetalle =
                           (from client in _context.clientes
                            join paquete in _context.paquetes
                            on client.NumeroCasillero equals paquete.Casillero
                            where client.NumeroCasillero == id
                            join estado in _context.estados
                            on paquete.Estado equals estado.IdEstado                            
                            select new PaqueteDetalle
                            {                                
                                Codigo = paquete.Codigo,
                                Peso = paquete.Peso,
                                Casillero = paquete.Casillero,
                                Estado = estado.Nombre
                            }).ToList();

                        return listaClienteDetalle;
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
