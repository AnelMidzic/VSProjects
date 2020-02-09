using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreWcfKlijent.Models;
using MagacinServiceReference;

namespace WebCoreWcfKlijent.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            MagacinServiceClient klijent = new MagacinServiceClient();
            KategorijaCon[] kategorije = await klijent.VratiKategorijeAsync();
            await klijent.CloseAsync();
            if (kategorije != null)
            {
                ViewBag.Porukua = "";
                return View(kategorije);
            }

            ViewBag.Poruka = "Greska";
            return View();
            
        }

        public async Task<IActionResult> VratiProizvode(int id = 0)
        {
            MagacinServiceClient klijent = new MagacinServiceClient();

            ProizvodCon[] listaProizvoda = await klijent.VratiProizvodeAsync(id);
            KategorijaCon k = await klijent.VratiKategorijuAsync(id);
            ViewBag.Kategorija = k.NazivKategorije;
            await klijent.CloseAsync();

            if (listaProizvoda != null)
            {
                ViewBag.Poruka = "";
                return View(listaProizvoda);
            }

            ViewBag.Poruka = "Greska";
            return View();
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
