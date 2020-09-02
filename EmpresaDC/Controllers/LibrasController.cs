using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libras.Models;

namespace Libras.Controllers
{
    public class LibrasController : Controller
    {
        private readonly ILibrasBussines _context;

        public LibrasController(ILibrasBussines context)
        {
            _context = context;
        }

        // GET: Libras
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObtenerTodasLasLibras());
        }

        // GET: Libras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libra = await _context.ObtenerLibraPorId(id);
            if (libra == null)
            {
                return NotFound();
            }

            return View(libra);
        }

        // GET: Libras/Create
        public async Task<IActionResult> CrearEditar(int id=0)
        {
            if (id == 0)
                return View(new Libra());
            else
                return View(await _context.ObtenerLibraPorId(id));
        }

        // POST: Libras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdLibra,ValorLibra,FechaInicio,FechaFinal")] Libra libra)
        {
            if (ModelState.IsValid)
            {

                await _context.CrearEditar(libra);
                return RedirectToAction(nameof(Index));
            }
            return View(libra);
        }

      
        // GET: Libras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libra = await _context.ObtenerLibraPorId(id);
            await _context.Eliminar(libra);
            return RedirectToAction(nameof(Index));

            
        }
        

       
    }
}
