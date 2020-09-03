using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImportacionesDC.Models.DAL;
using ImportacionesDC.Models.Entities;
using ImportacionesDC.Models.Abstract;
using ImportacionesDC.Clases;

namespace ImportacionesDC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteBusiness _context;

        public ClienteController(IClienteBusiness context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObtenerClientes());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.ObtenerClienteId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            IEnumerable<PaqueteDetalle> listapaquetes = await _context.ObtenerPaquetesClienteId(id);
            ViewBag.Paquetes = listapaquetes;
            return View(cliente);
        }

        // GET: Cliente/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            if (id == 0)
                return View(new Cliente());
            else
                return View(await _context.ObtenerClienteId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("NumeroCasillero,Nombre,Correo,Direccion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _context.GuardarEditarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.EliminarCliente(await _context.ObtenerClienteId(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
