using ImportacionesDC.Clases;
using ImportacionesDC.Models.Abstract;
using ImportacionesDC.Models.DAL;
using ImportacionesDC.Models.Entities;
using Libras.Models;
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
        public async Task<TipoMercancia> ObtenerMercanciaPorId(int? id)
        {
            Paquete paquete= await _context.paquetes.FirstOrDefaultAsync(x=>x.Codigo==id);
            
            TipoMercancia mercancia = await _context.mercancias.FirstOrDefaultAsync(x=>x.IdTipoMercancia==paquete.Tipo);
            return mercancia;
        }
        public async Task<Transportadora> ObtenerTransportadoraPorId(int? id)
        {
            Paquete paquete = await _context.paquetes.FirstOrDefaultAsync(x => x.Codigo == id);

            Transportadora transportadora = await _context.transportadoras.FirstOrDefaultAsync(x => x.IdTransportadora == paquete.Empresa);
            return transportadora;
        }
        public async Task<Estado> ObtenerEstadoPorId(int? id)
        {
            Paquete paquete = await _context.paquetes.FirstOrDefaultAsync(x => x.Codigo == id);

            Estado estado = await _context.estados.FirstOrDefaultAsync(x => x.IdEstado == paquete.Estado);
            return estado;
        }
        public async Task<Cliente> ObtenerClientePorId(int? id)
        {
            Paquete paquete = await _context.paquetes.FirstOrDefaultAsync(x => x.Codigo == id);

            Cliente cliente = await _context.clientes.FirstOrDefaultAsync(x => x.NumeroCasillero == paquete.Casillero);
            return cliente;
        }
        public Libra ObtenerUltimaLibra()
        {
            try
            {
                Libra libra = _context.Libra.OrderByDescending(x => x.IdLibra).First();
                return libra;

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }



    }
}
