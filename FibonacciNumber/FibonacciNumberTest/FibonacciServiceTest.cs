using FibonacciNumber.Repository;
using FibonacciNumber.Services;
using Xunit;
using NSubstitute;
using FibonacciNumber.Common;

namespace FibonacciNumberTest
{
    public class FibonacciServiceTest
    {
        private IFibonacciService _service;
        private IFibonacciRepository _repository;

        public FibonacciServiceTest()
        {
            _repository = Substitute.For<IFibonacciRepository>();
            _service = new FibonacciService(_repository);
        }

        [Fact]
        public void GetNextFibonacciNumber_Success()
        {
            // Arrange
            var expectedResponse = 514229;
            _repository.IsFibonacciNumber(Arg.Any<long>()).Returns(true);
            _repository.GetNextFibonacciNumber(Arg.Any<long>()).Returns(expectedResponse);

            //Act
            var response = _service.GetNextFibonacciNumber(317811);

            //Assert
            Assert.Equal(514229, response);
        }

        [Fact]
        public void GetNextFibonacciNumber_NotFibonacciNumber()
        {
            // Arrange
            _repository.IsFibonacciNumber(Arg.Any<long>()).Returns(false);

            // Act & Assert
            Assert.Throws<InvalidFibonacciNumberException>(() => _service.GetNextFibonacciNumber(4));
        }

        [Fact]
        public void GetNextFibonacciNumber_NegativeNumber()
        {
            // Arrange
            _repository.When(x => x.IsFibonacciNumber(Arg.Any<long>())).Do(x => throw new InvalidFibonacciNumberException("Invalid Number"));

            // Act & Assert
            Assert.Throws<InvalidFibonacciNumberException>(() => _service.GetNextFibonacciNumber(-4));
        }
    }
}
