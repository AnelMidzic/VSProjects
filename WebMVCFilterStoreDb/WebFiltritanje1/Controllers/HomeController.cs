using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFiltritanje1.Models;
using X.PagedList;

namespace WebFiltritanje1.Controllers
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
            ViewBag.Kategorije = new SelectList(db.Kategorije, "KategorijaId", "Naziv");
            return View();
        }

        public PartialViewResult _TraziProizvode(decimal? min, decimal? max, int KategorijaId=0)
        {
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;

            if (KategorijaId !=0)
            {
                Kategorija k1 = db.Kategorije.Find(KategorijaId);

                if (k1 != null)
                {
                    ViewBag.Kategorija = k1.Naziv;
                    listaProizvoda = listaProizvoda
                        .Where(p => p.KategorijaId == KategorijaId);
                }
                else
                {
                    ViewBag.Kategorija = "";
                    return PartialView();
                }
            }
            else
            {
                ViewBag.Kategorija = "Svi proizvodi";
            }

            if (min == null)
            {
                min = listaProizvoda.Min(p=>p.Cena);
            }

            if (max == null)
            {
                max = listaProizvoda.Max(p => p.Cena);
            }

            listaProizvoda = listaProizvoda
                .Where(p => p.Cena >= min && p.Cena <= max);
            return PartialView(listaProizvoda);
        }

        public IActionResult PrikaziProizvode(int? strana)
        {
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;

            int brojStrane = strana ?? 1;
            int brojRedova = 3;
            return View(listaProizvoda.ToPagedList(brojStrane, brojRedova));
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
