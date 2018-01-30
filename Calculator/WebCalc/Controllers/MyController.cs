using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult Index(long id)
        {
            ViewData.Model = id.ToString();

            ViewData["age"] = 21;
            ViewData.Add("isAdmin", false);

            ViewBag.lastname = "Погудин";
            ViewBag.Cities = new string[] { "Kirov", "Piter" };

            return View("Name");
        }

        [HttpPost]
        public ActionResult Index(string firstname)
        {
            ViewData["age"] = 21;
            ViewData.Add("isAdmin", false);

            ViewBag.lastname = "Погудин";
            ViewBag.Cities = new string[] { "Kirov", "Piter" };

            return View("Name", model: firstname);
        }

    }
}