using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImportacionesDC.Models.DAL;
using ImportacionesDC.Models.Entities;
using ImportacionesDC.Clases;
using ImportacionesDC.Models.Abstract;

namespace ImportacionesDC.Controllers
{
    public class PaqueteController : Controller
    {
        private readonly IPaqueteBusiness _context;
        public PaqueteController(IPaqueteBusiness context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.ObtenerPaquetes());
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.ObtenerPaqueteId(id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            IEnumerable<Cliente> listaclientes = await _context.ObtenerClientes();
            ViewBag.Clientes = listaclientes;
            if (id == 0)
                return View(new Paquete());
            else
                return View(await _context.ObtenerPaqueteId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("Codigo,Peso,Casillero,Estado,Tracking,Empresa,Tipo,Guia,Valor")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                await _context.GuardarEditarPaquete(paquete);
                return RedirectToAction(nameof(Index));
            }
            return View(paquete);
        }

        // GET: Paquete/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.EliminarPaquete(await _context.ObtenerPaqueteId(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
