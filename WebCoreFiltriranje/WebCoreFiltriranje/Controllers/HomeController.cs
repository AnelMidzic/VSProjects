using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreFiltriranje.Models;

namespace WebCoreFiltriranje.Controllers
{
    public class HomeController : Controller
    {
        private readonly MagacinContext db;

        public HomeController(MagacinContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Kategorije.ToList());
        }

        public IActionResult VratiProizvode(int id = 0)
        {
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;

            if (id!=0)
            {
                Kategorija k1 = db.Kategorije.Find(id);

                if (k1 != null)
                {
                    ViewBag.Kategorija = k1.Naziv;
                    listaProizvoda = listaProizvoda
                        .Where(p => p.KategorijaId == id);
                }
                else
                {
                    ViewBag.Kategorija = "";
                    return View();
                }
            }
            else
            {
                ViewBag.Kategorija = "Svi proizvodi";
            }
            return View(listaProizvoda);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
