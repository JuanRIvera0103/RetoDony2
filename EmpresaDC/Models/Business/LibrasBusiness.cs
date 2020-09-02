using ImportacionesDC.Models.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libras.Models
{
    public class LibrasBusiness:ILibrasBussines
    {
        private readonly DbContextImportaciones _context;

        public LibrasBusiness(DbContextImportaciones context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Libra>> ObtenerTodasLasLibras() => await _context.Libra.ToListAsync();
        public async Task<Libra> ObtenerLibraPorId(int? id)
        {
            try
            {
                Libra libra = null;
                if (id == 0)
                    return libra;
                else
                {
                    libra = await _context.Libra.FirstOrDefaultAsync(x => x.IdLibra == id);
                    return libra;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
        public async Task CrearEditar(Libra libra)
        {
            try
            {
                if (libra.IdLibra == 0)
                {

                    Libra libreaAnterior = _context.Libra.OrderByDescending(x => x.IdLibra).First();
                    if (libreaAnterior != null)
                    {
                        libreaAnterior.FechaFinal = DateTime.Now.ToShortDateString();
                        libreaAnterior.HoraFinal = DateTime.Now.ToShortTimeString();
                        _context.Update(libreaAnterior);
                    }
                    libra.FechaInicio = DateTime.Now.ToShortDateString();
                    libra.HoraInicio = DateTime.Now.ToShortTimeString();
                    _context.Add(libra);
                }
                else
                    _context.Update(libra);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public async Task Eliminar(Libra libra)
        {
            try
            {
                _context.Remove(libra);
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

               throw new Exception();
            }
        }
        public async Task<Libra> ObtenerUltimaLibra()
        {
            try
            {
                Libra libra = await _context.Libra.MaxAsync();
                return libra;
               
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
       
        }
    }

