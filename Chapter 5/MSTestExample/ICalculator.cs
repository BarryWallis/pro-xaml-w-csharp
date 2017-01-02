using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestExample
{
    /// <summary>
    /// An interface for a simple integer calculator.
    /// </summary>
    public interface ICalculator : IDisposable
    {
        /// <summary>
        /// Add two integers together.
        /// </summary>
        /// <param name="firstNumber">The addend.</param>
        /// <param name="secondNumber">The augend.</param>
        /// <returns>The sum of the two numbers.</returns>
        int Add(int firstNumber, int secondNumber);

        /// <summary>
        /// Subtract the first integer from the second integer.
        /// </summary>
        /// <param name="firstNumber">The minuend.</param>
        /// <param name="secondNumber">The subtrahend.</param>
        /// <returns>The difference between the first number and the second number.</returns>
        int Subtract(int firstNumber, int secondNumber);

        /// <summary>
        /// Multiply the two integers together.
        /// </summary>
        /// <param name="firstNumber">The multiplicand.</param>
        /// <param name="secondNumber">The multiplier.</param>
        /// <returns>The product of the two numbers.</returns>
        int Multiply(int firstNumber, int secondNumber);

        /// <summary>
        /// Divide the first integer by the second.
        /// </summary>
        /// <param name="firstNumber">The dividend.</param>
        /// <param name="secondNumber">The divisor.</param>
        /// <returns>The quotient of dividing the first number by the secind number.</returns>
        int Divide(int firstNumber, int secondNumber);
    }
}
