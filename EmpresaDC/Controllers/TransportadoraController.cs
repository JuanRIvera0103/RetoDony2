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

namespace ImportacionesDC.Controllers
{
    public class TransportadorasController : Controller
    {
        private readonly ITransportadoraBusiness _context;

        public TransportadorasController(ITransportadoraBusiness context)
        {
            _context = context;
        }

        // GET: Transportadoras/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            if (id == 0)
                return View(new Transportadora());
            else
                return View(await _context.ObtenerTransportadoraPorId(id));
        }

        // POST: Transportadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdTransportadora,Nombre")] Transportadora transportadora)
        {

            if (ModelState.IsValid)
            {
                await _context.CrearEditarTransportadora(transportadora);
                return RedirectToAction(nameof(Index));
            }
            return View(transportadora);
        }
        // GET: Transportadoras/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.ObtenerTransportadoraPorId(id);
            if (transportadora == null)
            {
                return NotFound();
            }

            await _context.EliminarTransportadora(transportadora);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ListarTodasTransportadoras());
        }

        // GET: Transportadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.ObtenerTransportadoraPorId(id);

            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }


    }
}
