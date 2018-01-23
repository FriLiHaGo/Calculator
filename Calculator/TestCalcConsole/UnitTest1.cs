using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalcConsole
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //arrange
            var x = 10;
            var y = 1;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Sum(x, y);
            //assert
            Assert.AreEqual(result, 11);
        }

        [TestMethod]
        public void TestSub()
        {
            //arrange
            var x = 10;
            var y = 1;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Sub(x, y);
            //assert
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestSumDouble()
        {
            //arrange
            var x = 1.2;
            var y = 1.1;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Sum(x, y);
            //assert
            Assert.AreEqual(result, 2.3);
        }

        [TestMethod]
        public void TestSubDouble()
        {
            //arrange
            var x = 1;
            var y = 0.5;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Sub(x, y);
            //assert
            Assert.AreEqual(result, 0.5);
        }

        [TestMethod]
        public void TestMulDouble()
        {
            //arrange
            var x = 0.25;
            var y = 4.0;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Mul(x, y);
            //assert
            Assert.AreEqual(result, 1.0);
        }

        [TestMethod]
        public void TestDivDouble()
        {
            //arrange
            var x = 1;
            var y = 4;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Div(x, y);
            //assert
            Assert.AreEqual(result, 0.25);
        }

        [TestMethod]
        public void TestSquareDouble()
        {
            //arrange
            var x = 2.0;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Square(x);
            //assert
            Assert.AreEqual(result, 4.0);
        }

        [TestMethod]
        public void TestSqrtDouble()
        {
            //arrange
            var x = 4.0;
            var calc = new CalcConsole.Calc();
            //act
            var result = calc.Sqrt(x);
            //assert
            Assert.AreEqual(result, 2.0);
        }
    }
}
