using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreControleri.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCoreControleri.Controllers
{
    public class OsobaController : Controller
    {
        private readonly OsobaContext db;
        public OsobaController(OsobaContext _db)
        {
            db = _db;
        }
        //public IActionResult Index()
        //{        
        //    return View(db.Osobe.ToList());
        //}
        public async Task<IActionResult> Index()
        {
            return View(await db.Osobe.ToListAsync());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Osoba osoba = db.Osobe
                .SingleOrDefault(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OsobaId,Ime,Prezime,Telefon")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Add(osoba);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewBag.Greska="Greska pri cuvanju podataka";
                }
                
            }
            return View(osoba);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Osoba osoba = db.Osobe.Find(id);
            if (osoba == null)
            {
                return NotFound();
            }
            return View(osoba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OsobaId,Ime,Prezime,Telefon")] Osoba osoba)
        {
            if (id != osoba.OsobaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(osoba);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewBag.Greska = "Greska pri promjeni";
                    return View(osoba);
                }
                
            }
            return View(osoba);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Osoba osoba = db.Osobe
                .FirstOrDefault(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Osoba osoba = db.Osobe.Find(id);
            try
            {
                db.Osobe.Remove(osoba);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Greska = "Greska pri brisanju podataka";
                return View(osoba);
            }

            
            
        }

       
    }
}