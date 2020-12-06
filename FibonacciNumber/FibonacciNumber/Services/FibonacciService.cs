using FibonacciNumber.Common;
using FibonacciNumber.Repository;
using System;

namespace FibonacciNumber.Services
{
    public interface IFibonacciService
    {
        long GetNextFibonacciNumber(long number);
    }

    public class FibonacciService : IFibonacciService
    {
        private IFibonacciRepository _repository;

        public FibonacciService(IFibonacciRepository repository)
        {
            _repository = repository;
        }
        public long GetNextFibonacciNumber(long number)
        {
            if(_repository.IsFibonacciNumber(number))
            {
                return _repository.GetNextFibonacciNumber(number);
            }
            else
            {
                throw new InvalidFibonacciNumberException(number);
            }
        }
    }
}
