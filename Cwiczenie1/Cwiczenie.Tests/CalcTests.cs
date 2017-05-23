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


        private Calc _calculator;

        public CalcTests()
        {
            _calculator = new Calc(10, 5);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(9000, 9000, 18000)]
        public void Dodawanie_Zwraca_Sume_Dwoch_Liczb(int x, int y, int expeted)
        {
            var _calculator = new Calc(x, y);

            _calculator.Add();

            Assert.Equal(15, 15);
        }
        [Fact]
        public void Odejmowanie_Zwraca_Roznice_Dwoch_Liczb()
        {
            _calculator.Substract();

            Assert.Equal(5, 5);
        }
        [Fact]
        public void Mnozenie_Zwraca_Wynik_Mnozenia_Dwoch_Liczb()
        {
            _calculator.Multiply();

            Assert.Equal(50, 50);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        public void Dzielenie_Zwraca_Wynik_Dzielenia_Dwoch_Liczb(int x, int y, double expeted)
        {
            var _calculator = new Calc(x, y);

            var result = _calculator.Divide();

            Assert.Equal(0, result);
        }
    }
}
