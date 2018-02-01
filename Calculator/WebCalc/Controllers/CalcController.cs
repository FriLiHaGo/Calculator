using CalcDB.Models;
using CalcDB.Repositories;
using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Web.Security;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {

        #region Protected Members

        protected IOperationRepository OperationRepository { get; set; }

        protected IOperResultRepository OperationResultRepository { get; set; }

        protected IUserRepository UserRepository { get; set; }

        protected Calc Calc { get; set; }

        protected User CurrentUser { get; set; }
        

        #endregion

        public CalcController()
        {
            OperationRepository = new OperationRepository();
            OperationResultRepository = new OperResultRepository();
            UserRepository = new UserRepository();
            Calc = new Calc();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CalcModel()
            {
                Operations = Calc.GetOperations()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Exec(string operation, string args)
        {
            // серверная валидация
            if (string.IsNullOrEmpty(args))
            {
                return Content("Введите данные");
            }

            var result = Calc.Exec(operation, args.Split(new[] { ' ', ',' }));

            #region Сохранение в БД
            var oper = OperationRepository.GetOrCreate(operation);
            CurrentUser = UserRepository.GetByLogin(User.Identity.Name);

            var or = new OperationResult()
            {
                OperationId = oper.Id,
                UserId = CurrentUser.Id,
                Result = result,
                ExecutionTime = new Random().Next(100, 4000),
                Error = "",
                Args = args.Trim(),
                CreationDate = DateTime.Now
            };

            OperationResultRepository.Save(or);

            #endregion

            return PartialView("Result", result);
        }

        public ActionResult History()
        {
            CurrentUser = UserRepository.GetByLogin(User.Identity.Name);
            return View(OperationResultRepository.GetByUserId(CurrentUser.Id));
        }
    }
}