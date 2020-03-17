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
    public class KundListasController : Controller
    {
        private readonly Releye_ListContext _context;

        public KundListasController(Releye_ListContext context)
        {
            _context = context;
        }

        // GET: KundListas
        public async Task<IActionResult> Index()
        {
            var releye_ListContext = _context.KundLista.Include(k => k.LandLista);
            return View(await releye_ListContext.ToListAsync());
        }

        // GET: KundListas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kundLista = await _context.KundLista
                .Include(k => k.LandLista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kundLista == null)
            {
                return NotFound();
            }

            return View(kundLista);
        }

        // GET: KundListas/Create
        public IActionResult Create()
        {
            ViewData["LandListaId"] = new SelectList(_context.Set<LandLista>(), "Id", "Namn");
            return View();
        }

        // POST: KundListas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn,LandListaId")] KundLista kundLista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kundLista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandListaId"] = new SelectList(_context.Set<LandLista>(), "Id", "Namn", kundLista.LandListaId);
            return View(kundLista);
        }

        // GET: KundListas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kundLista = await _context.KundLista.FindAsync(id);
            if (kundLista == null)
            {
                return NotFound();
            }
            ViewData["LandListaId"] = new SelectList(_context.Set<LandLista>(), "Id", "Namn", kundLista.LandListaId);
            return View(kundLista);
        }

        // POST: KundListas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn,LandListaId")] KundLista kundLista)
        {
            if (id != kundLista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kundLista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundListaExists(kundLista.Id))
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
            ViewData["LandListaId"] = new SelectList(_context.Set<LandLista>(), "Id", "Namn", kundLista.LandListaId);
            return View(kundLista);
        }

        // GET: KundListas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kundLista = await _context.KundLista
                .Include(k => k.LandLista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kundLista == null)
            {
                return NotFound();
            }

            return View(kundLista);
        }

        // POST: KundListas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kundLista = await _context.KundLista.FindAsync(id);
            _context.KundLista.Remove(kundLista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundListaExists(int id)
        {
            return _context.KundLista.Any(e => e.Id == id);
        }
    }
}
