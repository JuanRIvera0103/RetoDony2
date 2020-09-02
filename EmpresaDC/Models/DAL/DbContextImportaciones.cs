using ImportacionesDC.Models.Entities;
using Libras.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Models.DAL
{
    public class DbContextImportaciones : DbContext
    {
        public DbContextImportaciones(DbContextOptions<DbContextImportaciones> options) :
            base(options)
        {
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Paquete> paquetes { get; set; }
        public DbSet<Transportadora> transportadoras { get; set; }
        public DbSet<TipoMercancia> mercancias { get; set; }
        public DbSet<Estado> estados { get; set; }    
        public DbSet<Libra> Libra { get; set; }
    }
}
