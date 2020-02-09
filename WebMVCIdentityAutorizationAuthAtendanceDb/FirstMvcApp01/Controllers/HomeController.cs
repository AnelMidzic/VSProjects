using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMvcApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstMvcApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public IStringLocalizer<Resource> localizer;


        public HomeController(IStringLocalizer<Resource> localizer)
        {
            this.localizer = localizer;
        }

        public IActionResult SetCulture(string culture, string sourceUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)
                ),
                new CookieOptions {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                }
            );

            return Redirect(sourceUrl);
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.teststring = localizer["DateOfBirthDateRange"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                Attendance.AddAttendant(person);
                TempData["FirstName"] = person.FirstName + " " + person.LastName;
                return RedirectToAction("Index");
            } else
            {
                return View();
            }
            
        } 

        public IActionResult AttendantDetails(string firstName, string lastName)
        {

            TestContext db = new TestContext();
            Person person = db.Person.Where(p => p.FirstName.ToLower().Equals(firstName.ToLower()) && p.LastName.ToLower().Equals(lastName.ToLower())).FirstOrDefault();

            if(person == null)
            {
                return NotFound();
            }

            return View("Attendant", person);
        }

    }
}
