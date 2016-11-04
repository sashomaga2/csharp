using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 reate a Complex class which represents a complex number, it should have 2 public properties, Real and Imaginary. 
 The numbers should be able to be added with + or subtracted with -, using the rules for addition ((m + ni) + (p + qi) = (m + p) + (n+q)i) and subtraction ((m + ni) - (p + qi) = (m - p) + (n - q)i) . 
 When converted to a string, the number should return “{real} + {imaginary}i”.
Input:
On the first 2 lines, 2 complex numbers are entered in the format {real} {imaginary}.
On the next line, add or sub is entered, which picks the action that should be executed.

Output:
Print the result of the addition or subtraction in the format {real} +/- {imaginary}i
Example
Input
Output
3 4
2 6
add
5 + 10i

     */

namespace ClassesLesson.Complex
{
    public class Complex
    {

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int Real { get; set; }
        public int Imaginary { get; set; }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public override string ToString()
        {
            var imaginaryPart = "";
            if (Imaginary != 0)
            {
                imaginaryPart = Imaginary > 0 ? $"+{Imaginary}i" : $"{Imaginary}i";
            }
           
            return $"{Real} {imaginaryPart}";
        }
    }

    
}
