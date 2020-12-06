using FibonacciNumber.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciNumber.Repository
{
    public interface IFibonacciRepository
    {
        bool IsFibonacciNumber(long number);

        long GetNextFibonacciNumber(long number);
    }

    public class FibonacciRepository : IFibonacciRepository
    {
        public bool IsFibonacciNumber(long number)
        {
            if (number <= 0)
            {
                throw new InvalidFibonacciNumberException("Number must be greater than 0.", null);
            }

            return (isSquareNumber(5 * number * number + 4)
                    || isSquareNumber(5 * number * number - 4));
        }

        private bool isSquareNumber(long number)
        {
            long squareRoot = (long)Math.Sqrt(number);
            return (squareRoot * squareRoot == number);
        }

        public long GetNextFibonacciNumber(long number)
        {
            var next = number * (1 + Math.Sqrt(5)) / 2.0;
            return (long)Math.Round(next);
        }
    }
}
