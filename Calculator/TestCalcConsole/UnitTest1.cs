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


    }
}
