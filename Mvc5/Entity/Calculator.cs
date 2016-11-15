using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum CalculatorOperation { Add, Subtract, Multiply, Divide }

    public class Calculator
    {
        private int num1;

        private int num2;

        public Calculator(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public string ExecuteOperation(CalculatorOperation operation)
        {
            var result = "";
            switch (operation)
            {
                case CalculatorOperation.Add:
                    result = (num1 + num2).ToString("0.00");
                    break;
                case CalculatorOperation.Subtract:
                    result = (num1 - num2).ToString("0.00");
                    break;
                case CalculatorOperation.Multiply:
                    result = (num1 * num2).ToString("0.00");
                    break;
                case CalculatorOperation.Divide:
                    if (num2 == 0)
                    {
                        result = "Invalid operation";
                    }
                    else
                    {
                        result = (num1 / num2).ToString("0.00");
                    }
                    
                    break;
            }

            return result;
        }
    }
}
