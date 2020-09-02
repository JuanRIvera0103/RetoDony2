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
    public class EstadosBusiness:IEstadosBusiness
    {
        private readonly DbContextImportaciones _context;

        public EstadosBusiness(DbContextImportaciones context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estado>> ObtenerTodosLosEstados() => await _context.estados.ToListAsync();
        public async Task<Estado> ObtenerEstadoPorId(int? id)
        {
            try
            {
                Estado estado;
                estado = null;
                if (id == null)
                    return estado;
                else
                {
                     estado = await _context.estados.FirstOrDefaultAsync(x => x.IdEstado == id);
                    return estado;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public async Task CrearEditarEstado(Estado estado)
        {
            try
            {
                if (estado.IdEstado == 0)
                    _context.Add(estado);
                else
                    _context.Update(estado);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
        
        public async Task EliminarEstado(Estado estado)
        {
            try
            {
                 _context.Remove(estado);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
