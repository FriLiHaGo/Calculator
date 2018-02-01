using CalcDB.Models;
using CalcDB.NHibernate.Repositories;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        protected IUserRepository UserRepository { get; set; }
        
        public AdminController()
        {
            UserRepository = new NHUserRepository(); 
        }

        // GET: Admin
        public ActionResult Index()
        {
            var users = UserRepository.GetAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password,
                    Status = UserStatus.Active
                };

                UserRepository.Save(user);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}