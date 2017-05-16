using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y = a * (x * x) + b  * y + c");
            Console.Write("podaj wartośc a = ");
            var a = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc b = ");
            var b = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc c = ");
            var c = Convert.ToDouble(Console.ReadLine());

            Calculate(a, b, c);

        }

        private static void Calculate(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;
            double delta = (b * b) -(4 * a * c);

            if (delta > 0)

            {

                x1 = -b + Math.Sqrt(delta) / (2 * a);
                x2 = -b - Math.Sqrt(delta) / (2 * a);

                Console.WriteLine("x1 =" + x1 + "x2 =" + x2);
            }

            else if (delta == 0)

            {
                x1 = -b / (2 * a);

                Console.WriteLine("x1 =" + x1);
            }

            else

                Console.WriteLine("Delta jest mniejsza od zera. Brak miejsc zerowych");

            Console.ReadKey();

        }
    }
}