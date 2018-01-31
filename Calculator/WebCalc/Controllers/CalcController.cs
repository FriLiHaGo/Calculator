using CalcDB.Models;
using CalcDB.Repositories;
using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {

        #region Protected Members

        protected IOperationRepository OperationRepository { get; set; }

        protected IOperResultRepository OperationResultRepository { get; set; }

        protected Calc Calc { get; set; }

        #endregion

        public CalcController()
        {
            OperationRepository = new OperationRepository();
            OperationResultRepository = new OperResultRepository();
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

            var or = new OperationResult()
            {
                OperationId = oper.Id,
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

            return View(OperationResultRepository.GetAll());
        }
    }
}