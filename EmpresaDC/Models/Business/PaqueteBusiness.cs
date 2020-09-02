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
    public class PaqueteBusiness : IPaqueteBusiness
    {
        private readonly DbContextImportaciones _context;

        public PaqueteBusiness(DbContextImportaciones context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaqueteDetalle>> ObtenerPaquetes()
        {
            try
            {
                await using (_context)
                {
                    IEnumerable<PaqueteDetalle> listaPaqueteDetalle =
                        (from paquete in _context.paquetes
                         join cliente in _context.clientes 
                         on paquete.Casillero equals cliente.NumeroCasillero
                         join estado in _context.estados
                         on paquete.Estado equals estado.IdEstado
                         select new PaqueteDetalle
                         {
                             Codigo = paquete.Codigo,
                             Peso = paquete.Peso,
                             Casillero = paquete.Casillero,
                             Cliente = cliente.Nombre,
                             Estado = estado.Nombre
                         }).ToList();

                    return (listaPaqueteDetalle);
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<Paquete> ObtenerPaqueteId(int? codigo)
        {
            try
            {
                Paquete paquete;
                paquete = null;

                if (codigo == null)
                {
                    return paquete;
                }
                else
                {
                    paquete = await _context.paquetes.FirstOrDefaultAsync(e => e.Codigo == codigo);
                    return paquete;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task GuardarEditarPaquete(Paquete paquete)
        {

            try
            {
                if (paquete.Codigo == 0)
                    _context.Add(paquete);
                else
                    _context.Update(paquete);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task EliminarPaquete(Paquete paquete)
        {
            try
            {
                _context.paquetes.Remove(paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<IEnumerable<Cliente>> ObtenerClientes()
        {
            return await _context.clientes.ToArrayAsync(); 
        }
        public async Task<IEnumerable<Transportadora>> ObtenerTransportadoras()
        {
            return await _context.transportadoras.ToArrayAsync();
        }
        public async Task<IEnumerable<Estado>> ObtenerEstados()
        {
            return await _context.estados.ToArrayAsync();
        }
        public async Task<IEnumerable<TipoMercancia>> ObtenerTiposMercancia()
        {
            return await _context.mercancias.ToArrayAsync();
        }

    }
}
