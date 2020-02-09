using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreVjezba02.Models;

namespace WebCoreVjezba02.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly MagacinContext _context;

        public ProizvodiController(MagacinContext context)
        {
            _context = context;
        }

        // GET: Proizvodi
        public async Task<IActionResult> Index()
        {
            var magacinContext = _context.Proizvodi.Include(p => p.Kategorija);
            return View(await magacinContext.ToListAsync());
        }

        // GET: Proizvodi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvodi
                .Include(p => p.Kategorija)
                .FirstOrDefaultAsync(m => m.ProizvodId == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // GET: Proizvodi/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "Naziv");
            return View();
        }

        // POST: Proizvodi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProizvodId,KategorijaId,Naziv,Cena,Opis")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }

        // GET: Proizvodi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvodi.FindAsync(id);
            if (proizvod == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }

        // POST: Proizvodi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProizvodId,KategorijaId,Naziv,Cena,Opis")] Proizvod proizvod)
        {
            if (id != proizvod.ProizvodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodExists(proizvod.ProizvodId))
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
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }

        // GET: Proizvodi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvodi
                .Include(p => p.Kategorija)
                .FirstOrDefaultAsync(m => m.ProizvodId == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // POST: Proizvodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);
            _context.Proizvodi.Remove(proizvod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodExists(int id)
        {
            return _context.Proizvodi.Any(e => e.ProizvodId == id);
        }
    }
}
