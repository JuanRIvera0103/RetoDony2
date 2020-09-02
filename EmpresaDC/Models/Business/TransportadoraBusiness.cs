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
    public class TransportadoraBusiness:ITransportadoraBusiness
    {
        private readonly DbContextImportaciones _context;
        public TransportadoraBusiness(DbContextImportaciones context)
        {
            _context = context;
        }
        public async Task<Transportadora> ObtenerTransportadoraPorId(int? id)
        {
            try
            {
                Transportadora transportadora;
                transportadora = null;
                if (id == null)
                    return transportadora;
                else
                {
                    transportadora = await _context.transportadoras.FirstOrDefaultAsync(x => x.IdTransportadora == id);
                    return transportadora;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
           

        }

        public async Task CrearEditarTransportadora(Transportadora transportadora)
        {
            try
            {
                if (transportadora.IdTransportadora == 0)
                    _context.Add(transportadora);
                else
                    _context.Update(transportadora);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
        public async Task EliminarTransportadora(Transportadora transportadora)
        {
            try
            {
                _context.transportadoras.Remove(transportadora);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Transportadora>> ListarTodasTransportadoras()
        {
            return await _context.transportadoras.ToListAsync();
        }
    }
}
