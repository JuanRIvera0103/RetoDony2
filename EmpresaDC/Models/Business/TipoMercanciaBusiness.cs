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
    public class TipoMercanciaBusiness:ITipoMercanciaBusiness
    {
        private readonly DbContextImportaciones _context;
        public TipoMercanciaBusiness(DbContextImportaciones context)
        {
            _context = context;
        }
        public async Task<TipoMercancia> ObtenerTipoMercanciaPorId(int? id)
        {
            try
            {
                TipoMercancia tipoMercancia;
                tipoMercancia = null;
                if (id == null)
                    return tipoMercancia;
                else
                {
                    tipoMercancia = await _context.mercancias.FirstOrDefaultAsync(x => x.IdTipoMercancia == id);
                    return tipoMercancia;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
        public async Task<IEnumerable<TipoMercancia>> ObtenerTodosTiposMercancia()
        {
            return await _context.mercancias.ToListAsync();
        }
        public async Task GuardarEditarTipoMercancia(TipoMercancia tipoMercancia)
        {
            try
            {
                if (tipoMercancia.IdTipoMercancia == 0)
                    _context.Add(tipoMercancia);
                else
                    _context.Update(tipoMercancia);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
        public async Task EliminarTipoMercancia(TipoMercancia tipoMercancia)
        {
            try
            {
                _context.mercancias.Remove(tipoMercancia);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
