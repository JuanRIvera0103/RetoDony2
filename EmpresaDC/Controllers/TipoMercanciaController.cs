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
    public class TipoMercanciasController : Controller
    {
        private readonly ITipoMercanciaBusiness _context;

        public TipoMercanciasController(ITipoMercanciaBusiness context)
        {
            _context = context;
        }

        // GET: TipoMercancias
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObtenerTodosTiposMercancia());
        }

        // GET: TipoMercancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _context.ObtenerTipoMercanciaPorId(id);
            if (tipoMercancia == null)
            {
                return NotFound();
            }

            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            if (id == 0)
                return View(new TipoMercancia());
            else
                return View(await _context.ObtenerTipoMercanciaPorId(id));
        }

        // POST: TipoMercancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdTipoMercancia,Nombre")] TipoMercancia tipoMercancia)
        {

            if (ModelState.IsValid)
            {
                await _context.GuardarEditarTipoMercancia(tipoMercancia);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMercancia);
        }




        // GET: TipoMercancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _context.ObtenerTipoMercanciaPorId(id);
            if (tipoMercancia == null)
            {
                return NotFound();
            }

            await _context.EliminarTipoMercancia(tipoMercancia);
            return RedirectToAction(nameof(Index));

        }


    }
}
