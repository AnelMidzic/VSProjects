using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreControleri.Models;

namespace WebCoreControleri.Controllers
{
    public class OsobasController : Controller
    {
        private readonly OsobaContext _context;

        public OsobasController(OsobaContext context)
        {
            _context = context;
        }

        // GET: Osobas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Osobe.ToListAsync());
        }

        // GET: Osobas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osobe
                .FirstOrDefaultAsync(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // GET: Osobas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osobas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsobaId,Ime,Prezime,Telefon")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(osoba);
        }

        // GET: Osobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osobe.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }
            return View(osoba);
        }

        // POST: Osobas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OsobaId,Ime,Prezime,Telefon")] Osoba osoba)
        {
            if (id != osoba.OsobaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.OsobaId))
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
            return View(osoba);
        }

        // GET: Osobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osobe
                .FirstOrDefaultAsync(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // POST: Osobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osoba = await _context.Osobe.FindAsync(id);
            _context.Osobe.Remove(osoba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(int id)
        {
            return _context.Osobe.Any(e => e.OsobaId == id);
        }
    }
}
