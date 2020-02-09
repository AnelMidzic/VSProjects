using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFiltriranje2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebFiltriranje2.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmoviContext db;

        public HomeController(FilmoviContext _db)
        {
            db = _db;
        }
     
        public IActionResult Index()
        {
            ViewBag.Zanrovi = new SelectList(db.Zanrovi, "ZanrId", "Naziv");
            return View();
        }

        public PartialViewResult _TraziFilmove(string dioNaslova, int id = 0)
        {
            IEnumerable<Film> listaFilmova = db.Filmovi;

            if (id != 0)
            {
                Zanr z1 = db.Zanrovi.Find(id);

                if (z1 != null)
                {
                    ViewBag.Zanr = z1.Naziv;
                    listaFilmova = listaFilmova
                        .Where(f => f.ZanrId == id);
                }
                else
                {
                    ViewBag.Zanr = "";
                    return PartialView();
                }
            }
            else
            {
                ViewBag.Zanr = "Svi filmovi";
            }

            if (!string.IsNullOrWhiteSpace(dioNaslova))
            {
                listaFilmova = listaFilmova
                    .Where(f => f.Naziv.ToLower().Contains(dioNaslova.ToLower()));
            }

            return PartialView(listaFilmova);
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
