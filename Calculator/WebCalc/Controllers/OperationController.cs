using CalcDB.Repositories;
using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            var operationRepository = new BaseRepository<Operation>();
            var dbOperations = operationRepository.GetAll();
            var operations = dbOperations.Select(o => new OperationViewModel()
            {
                Id = o.Id,
                Name = o.Name,
                OwnerId = o.OwnerId
            });

            return View(operations);
        }
    }
}