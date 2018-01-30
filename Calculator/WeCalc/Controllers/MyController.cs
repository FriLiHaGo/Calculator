using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeCalc.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult Index(long id)
        {
            ViewData.Model = id.ToString();

            ViewBag.Lastname = "Погудин";

            return View("Name");
        }

        [HttpPost]
        public ActionResult Index(string firstname)
        {
            ViewBag.Lastname = "Погудин";

            return View("Name", model: firstname);
        }
    }
}