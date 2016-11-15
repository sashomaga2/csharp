using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace Mvc5.Models
{
    public class Calculation
    {
        public int Id { get; set; }

        public int Num1 { get; set; }

        public int Num2{ get; set; }

        public CalculatorOperation Operation { get; set; }

        public string Result { get; set; }
    }
}