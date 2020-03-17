using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Releye_List.Data;
using Releye_List.Models;

namespace Releye_List.Controllers
{
    public class LandListasController : Controller
    {
        private readonly Releye_ListContext _context;

        public LandListasController(Releye_ListContext context)
        {
            _context = context;
        }

        // GET: LandListas
        public async Task<IActionResult> Index()
        {
            return View(await _context.LandLista.ToListAsync());
        }

        // GET: LandListas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landLista = await _context.LandLista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landLista == null)
            {
                return NotFound();
            }

            return View(landLista);
        }

        // GET: LandListas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LandListas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn")] LandLista landLista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landLista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landLista);
        }

        // GET: LandListas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landLista = await _context.LandLista.FindAsync(id);
            if (landLista == null)
            {
                return NotFound();
            }
            return View(landLista);
        }

        // POST: LandListas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn")] LandLista landLista)
        {
            if (id != landLista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landLista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandListaExists(landLista.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(landLista);
        }

        // GET: LandListas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landLista = await _context.LandLista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landLista == null)
            {
                return NotFound();
            }

            return View(landLista);
        }

        // POST: LandListas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landLista = await _context.LandLista.FindAsync(id);
            _context.LandLista.Remove(landLista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandListaExists(int id)
        {
            return _context.LandLista.Any(e => e.Id == id);
        }
    }
}
