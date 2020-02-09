using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Areas.Preview.Controllers
{
    [Area("Preview")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}