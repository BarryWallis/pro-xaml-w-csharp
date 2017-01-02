using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[assembly: CLSCompliant(true)]

namespace MSTestExample
{
    [TestClass]
    sealed public class CalculatorTestFixture : IDisposable
    {
        private ICalculator calculator;

        [TestInitialize]
        public void InitializeTest() => calculator = new Calculator();

        [TestMethod]
        public void AddTwoIntegersReturnTheSum()
        {
            int firstNumber = 8;
            int secondNumber = 10;
            Assert.AreEqual(18, calculator.Add(firstNumber, secondNumber));
        }

        [TestMethod]
        public void SubtractTwoIntegersReturnTheDifference()
        {
            int firstNumber = 8;
            int secondNumber = 10;
            Assert.AreEqual(-2, calculator.Subtract(firstNumber, secondNumber));
        }

        [TestMethod]
        public void MultiplyTwoIntegersReturnTheProduct()
        {
            int firstNumber = 8;
            int secondNumber = 10;
            Assert.AreEqual(80, calculator.Multiply(firstNumber, secondNumber));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroThrowDivideByZeroException()
        {
            int firstNumber = 8;
            int secondNumber = 0;
            calculator.Divide(firstNumber, secondNumber);
        }

        [TestMethod]
        public void DivideTwoIntegersReturnTheQuotient()
        {
            int firstNumber = 8;
            int secondNumber = 4;
            Assert.AreEqual(2, calculator.Divide(firstNumber, secondNumber));
        }

        [TestCleanup]
        public void TeardownTest() => calculator.Dispose();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (calculator != null)
                {
                    calculator.Dispose();
                    calculator = null;
                }
            }
        }
    }
}
