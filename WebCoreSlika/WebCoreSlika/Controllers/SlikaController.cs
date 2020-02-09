using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreSlika.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WebCoreSlika.Controllers
{
    public class SlikaController : Controller
    {
        private readonly SlikaContext db;

        public SlikaController(SlikaContext context)
        {
            db = context;
        }

        public FileContentResult CitajSliku(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Slika sl = db.Slike.Find(id);

            if (id == null)
            {
                return null;
            }

            return File(sl.BinarniPodaci, sl.TipFajla);

        }

        // GET: Slika
        public async Task<IActionResult> Index()
        {
            return View(await db.Slike.ToListAsync());
        }

        // GET: Slika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slika = await db.Slike
                .FirstOrDefaultAsync(m => m.SlikaId == id);
            if (slika == null)
            {
                return NotFound();
            }

            return View(slika);
        }

        // GET: Slika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slika/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlikaId,Naziv,BinarniPodaci,TipFajla,Opis")] Slika slika, IFormFile odabrabaSlika)
        {
            if (odabrabaSlika == null)
            {
                ModelState.AddModelError("BinarniPodaci", "Niste odabrali sliku");
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await odabrabaSlika.CopyToAsync(ms);
                        slika.BinarniPodaci = ms.ToArray();
                    }
                    slika.TipFajla = odabrabaSlika.ContentType;

                    db.Add(slika);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewBag.Greska = "Greska pri cuvanju slike";
                    
                }
                
            }
            return View(slika);
        }

        // GET: Slika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slika = await db.Slike.FindAsync(id);
            if (slika == null)
            {
                return NotFound();
            }
            return View(slika);
        }

        // POST: Slika/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlikaId,Naziv,BinarniPodaci,TipFajla,Opis")] Slika slika, IFormFile odabranaSlika, int promjena=0 )
        {
            Slika sl = db.Slike.Find(slika.SlikaId);
            if (odabranaSlika != null && promjena == 1)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await odabranaSlika.CopyToAsync(ms);
                    slika.BinarniPodaci = ms.ToArray();
                    sl.TipFajla = odabranaSlika.ContentType;
                }
            }

            

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(slika);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlikaExists(slika.SlikaId))
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
            return View(slika);
        }

        // GET: Slika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slika = await db.Slike
                .FirstOrDefaultAsync(m => m.SlikaId == id);
            if (slika == null)
            {
                return NotFound();
            }

            return View(slika);
        }

        // POST: Slika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slika = await db.Slike.FindAsync(id);
            db.Slike.Remove(slika);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlikaExists(int id)
        {
            return db.Slike.Any(e => e.SlikaId == id);
        }
    }
}
