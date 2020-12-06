using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciNumber.Common
{
    public class InvalidFibonacciNumberException : ApplicationException
    {
        public InvalidFibonacciNumberException()
        {

        }

        public InvalidFibonacciNumberException(long number)
            : base($"{number} is not a Fibonacci number.")
        {

        }

        public InvalidFibonacciNumberException(string message)
            : base(message)
        {

        }

        public InvalidFibonacciNumberException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
