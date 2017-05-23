using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie1
{
    public class Calc
    {
        int liczbaPierwsza;
        int liczbaDruga;

        public Calc(int a, int b)
        {
            liczbaPierwsza = a;
            liczbaDruga = b;
        }
        public int Add()
        {
            return liczbaPierwsza + liczbaDruga;
        }

        public int Substract()
        {
            return liczbaPierwsza - liczbaDruga;
        }

        public int Multiply()
        {
            return liczbaPierwsza * liczbaDruga;
        }

        public double Divide()
       {
            return liczbaPierwsza / liczbaDruga;
       }
   }
}

