using FibonacciNumber.Common;
using FibonacciNumber.Repository;
using Xunit;

namespace FibonacciNumberTest
{
    public class FibonacciRepositoryTest
    {
        private IFibonacciRepository _repository;

        public FibonacciRepositoryTest()
        {
            _repository = new FibonacciRepository();
        }

        [Fact]
        public void IsFibonacciNumber_True()
        {
            // Act
            var response = _repository.IsFibonacciNumber(5);

            // Assert
            Assert.True(response);
        }

        [Fact]
        public void IsFibonacciNumber_False()
        {
            // Act
            var response = _repository.IsFibonacciNumber(4);

            // Assert
            Assert.False(response);
        }

        [Fact]
        public void IsFibonacciNumber_InvalidNumber()
        {
            // Act & Assert
            Assert.Throws<InvalidFibonacciNumberException>(() => _repository.IsFibonacciNumber(-4));
        }

        [Fact]
        public void GetNextFibonacciNumber_Success()
        {
            // Arrange
            var expected = 8;

            // Act
            var response = _repository.GetNextFibonacciNumber(5);

            // Assert
            Assert.Equal(expected, response);
        }
    }
}
