using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cwiczenie1;
using Xunit;

namespace Cwiczenie.Tests
    
{
    public class CalcTests
    {
        [Fact]
        public void Dodawanie_Zwraca_Sume_Dwoch_Liczb()
        {
            var calculator = new Calc(10, 5);

            var result = calculator.Add();

            Assert.Equal(15, result);
        }
        [Fact]
        public void Odejmowanie_Zwraca_Roznice_Dwoch_Liczb()
        {
            var calculator = new Calc(10, 5);

            var result = calculator.Substract();

            Assert.Equal(5, result);
        }
        [Fact]
        public void Mnozenie_Zwraca_Wynik_Mnozenia_Dwoch_Liczb()
        {
            var calculator = new Calc(10, 5);

            var result = calculator.Multiply();

            Assert.Equal(50, result);
        }
        [Fact]
        public void Dzielenie_Zwraca_Wynik_Dzielenia_Dwoch_Liczb()
        {
            var calculator = new Calc(10, 5);

            var result = calculator.Divide();

            Assert.Equal(2, result);
        }
    }
}
