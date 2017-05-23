using Cwiczenie1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Cwiczenie1.Calc(10,5);
            var result = calculator.Add();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
