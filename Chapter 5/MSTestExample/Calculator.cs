using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: CLSCompliant(true)]

namespace MSTestExample
{
    sealed public class Calculator : ICalculator
    {
        /// <summary>
        /// Add two integers together.
        /// </summary>
        /// <param name="firstNumber">The addend.</param>
        /// <param name="secondNumber">The augend.</param>
        /// <returns>The sum of the two numbers.</returns>
        public int Add(int firstNumber, int secondNumber) => firstNumber + secondNumber;

        /// <summary>
        /// Divide the first integer by the second.
        /// </summary>
        /// <param name="firstNumber">The dividend.</param>
        /// <param name="secondNumber">The divisor.</param>
        /// <returns>The quotient of dividing the first number by the secind number.</returns>
        public int Divide(int firstNumber, int secondNumber) => firstNumber / secondNumber;

        /// <summary>
        /// Multiply the two integers together.
        /// </summary>
        /// <param name="firstNumber">The multiplicand.</param>
        /// <param name="secondNumber">The multiplier.</param>
        /// <returns>The product of the two numbers.</returns>
        public int Multiply(int firstNumber, int secondNumber) => firstNumber * secondNumber;

        /// <summary>
        /// Subtract the first integer from the second integer.
        /// </summary>
        /// <param name="firstNumber">The minuend.</param>
        /// <param name="secondNumber">The subtrahend.</param>
        /// <returns>The difference between the first number and the second number.</returns>
        public int Subtract(int firstNumber, int secondNumber) => firstNumber - secondNumber;

        /// <summary>
        /// Provides a mechanism for releasing unmanaged resources.To browse the .NET Framework source code for this type, see the Reference Source.
        /// </summary>
        public void Dispose() => Console.WriteLine("Clean as a whistle.");
    }
}
