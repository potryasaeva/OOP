using System;

namespace RationalNumbers
{
    class Program
    {
        private static void Print(string text, object result)
        {
            Console.WriteLine(text + result);
        }

        static void Main()
        {
            RationalNumbersClass fraction = new RationalNumbersClass(4, 1);
            RationalNumbersClass fraction1 = new RationalNumbersClass(1, 3);
            RationalNumbersClass fraction2 = new RationalNumbersClass(-2, 6);
            RationalNumbersClass fraction3 = new RationalNumbersClass(4, 4);
            RationalNumbersClass fraction4 = new RationalNumbersClass(2, -7);
            RationalNumbersClass fraction5 = new RationalNumbersClass(8, 2);


            
            Print($" {fraction1} + {fraction2} = ", fraction1 + fraction2);
            Print($" {fraction2} - {fraction3} = ", fraction2 - fraction3);
            Print($" {fraction} * {fraction1} = ", fraction * fraction1);
            Print($" {fraction3} / {fraction4} = ", fraction3 / fraction4);
            Print($" {fraction2} % {fraction4} = ", fraction2 % fraction4);
            Print($" {fraction} == {fraction5} = ", fraction == fraction5);
            Print($" {fraction} != {fraction5} = ", fraction != fraction5);


            int rational = (int)new RationalNumbersClass(4, 2);
            Print($"Convert to int: ", rational);

            double rational1 = new RationalNumbersClass(5, 10);
            Print($"Convert to double: ", rational1);

            RationalNumbersClass rational2 = 7;
            Print($"Convert int to rational: ", rational2);
        }
    }
}
