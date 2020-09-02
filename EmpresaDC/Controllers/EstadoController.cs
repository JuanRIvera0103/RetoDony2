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
    public class EstadosController : Controller
    {
        private readonly IEstadosBusiness _context;

        public EstadosController(IEstadosBusiness context)
        {
            _context = context;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObtenerTodosLosEstados());
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.ObtenerEstadoPorId(id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: Estados/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            if (id == 0)
                return View(new Estado());
            else
                return View(await _context.ObtenerEstadoPorId(id));
        }

        // POST: Estados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdEstado,Nombre")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                await _context.CrearEditarEstado(estado);
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }



        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.ObtenerEstadoPorId(id);
            if (estado == null)
            {
                return NotFound();
            }

            await _context.EliminarEstado(estado);

            return RedirectToAction(nameof(Index));
        }


    }
}
