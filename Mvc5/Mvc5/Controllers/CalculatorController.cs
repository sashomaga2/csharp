using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Entity;
using Mvc5.Models;

namespace Mvc5.Controllers
{
    public class CalculatorController : ApiController
    {
        private CalcDb db = new CalcDb();

        [ValidateAntiForgeryToken]
        public IHttpActionResult PostCalculate(CalculatorViewModel model)
        {
            var result = "Invalid data!";
            if (ModelState.IsValid)
            {
                var calc = new Calculator(model.Num1, model.Num2);
                result = calc.ExecuteOperation(model.Operation);

                var calculation = new Calculation
                {
                    Num1 = model.Num1,
                    Num2 = model.Num2,
                    Operation = model.Operation,
                    Result = result
                };
                db.Calculations.Add(calculation);
                db.SaveChanges();
            }

            return Ok(result);
        }

        public IHttpActionResult GetCalculate(CalculatorViewModel model)
        {
            var calc = new Calculator(model.Num1, model.Num2);
            var result = calc.ExecuteOperation(model.Operation);

            return Ok(result);
        }
    }
}
