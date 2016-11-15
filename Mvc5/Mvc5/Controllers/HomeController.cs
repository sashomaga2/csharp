using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Mvc5.Models;

namespace Mvc5.Controllers
{
    public class HomeController : Controller
    {
        private CalcDb db = new CalcDb();

        public ActionResult Index(CalculatorViewModel model)
        {
            return View();
        }

        public ActionResult Calculations()
        {
            var model = db.Set<Calculation>();

            return View("Calculations", model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculate(CalculatorViewModel model)
        {
            var calc = new Calculator(model.Num1, model.Num2);
            var result = calc.ExecuteOperation(model.Operation);

            return Json(result);
        }


    }
}