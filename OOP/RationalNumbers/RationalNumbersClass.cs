using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public class RationalNumbersClass
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }


        public RationalNumbersClass(int numerator, int denominator = 1)
        {
            //добавить проверку на делитель = 0 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (numerator == denominator)
            {
                Numerator = 1;
                Denominator = 1;
            }
            else
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            FractionReduction();
        }

        private void FractionReduction()
        {
            int biggest = Numerator > Denominator ? Numerator : Denominator;
            for (int i = biggest; i >= 2; biggest--)
            {
                if (Numerator % biggest == 0 && Denominator % biggest == 0)
                {
                    Numerator /= biggest;
                    Denominator /= biggest;
                    break;
                }
            }
        }

        private static int CommonDenominator(int[] maxmin)
        {
            Array.Sort(maxmin);

            if (maxmin[1] % maxmin[0] == 0)
                return maxmin[1];

            else return maxmin[1] * maxmin[0];
        }


        public static bool operator ==(RationalNumbersClass a, RationalNumbersClass b)
        {
           return a.Numerator == b.Numerator & a.Denominator == b.Denominator;
        }


        public static bool operator !=(RationalNumbersClass a, RationalNumbersClass b)
        {
            return a.Numerator != b.Numerator && a.Denominator != b.Denominator;
        }


        public static RationalNumbersClass operator +(RationalNumbersClass a, RationalNumbersClass b)
        {
            int commonDenominator = CommonDenominator(new int[2] { a.Denominator, b.Denominator });
            int finalNumerator = (commonDenominator / a.Denominator * a.Numerator) + (commonDenominator / b.Denominator * b.Numerator);
            
            return new RationalNumbersClass(finalNumerator, commonDenominator);
        }

       
        public static RationalNumbersClass operator -(RationalNumbersClass a, RationalNumbersClass b)
        {
            int commonDenominator = CommonDenominator(new int[2] { a.Denominator, b.Denominator });
            int finalNumerator = (commonDenominator / a.Denominator * a.Numerator) - (commonDenominator / b.Denominator * b.Numerator);

            return new RationalNumbersClass(finalNumerator, commonDenominator);
        }

        
        public static RationalNumbersClass operator *(RationalNumbersClass a, RationalNumbersClass b)
        {
            return new RationalNumbersClass(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        
        public static RationalNumbersClass operator /(RationalNumbersClass a, RationalNumbersClass b)
        {
            return new RationalNumbersClass(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }


        public static int operator %(RationalNumbersClass a, RationalNumbersClass b)
        {
            RationalNumbersClass result = (a / b);
            return result.Numerator % result.Denominator;
        }


        public override string ToString()
        {
            return String.Format("{0}/{1}", Numerator, Denominator);;
        }


        public static explicit operator int(RationalNumbersClass fraction)
        {
            if (fraction.Numerator < fraction.Denominator || fraction.Denominator == 0)
                throw new ArgumentException();

            return (int)(fraction.Numerator / fraction.Denominator);
        }


        public static implicit operator double(RationalNumbersClass fraction)
        {
            return (double)fraction.Numerator / (double)fraction.Denominator;
        }


        public static implicit operator RationalNumbersClass(int fractionNumerator)
        {
            return new RationalNumbersClass(fractionNumerator);
        }

    }
}
