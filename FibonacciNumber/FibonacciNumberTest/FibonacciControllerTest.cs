using FibonacciNumber.Common;
using FibonacciNumber.Controllers;
using FibonacciNumber.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FibonacciNumberTest
{
    public class FibonacciControllerTest
    {
        private IFibonacciService _service;
        private FibonacciController _controller;

        public FibonacciControllerTest()
        {
            _service = Substitute.For<IFibonacciService>();
            _controller = new FibonacciController(_service);
        }

        [Fact]
        public void GetNextFibonacciNumber_Success()
        {
            // Arrange
            var expectedResponse = 514229;
            _service.GetNextFibonacciNumber(Arg.Any<long>()).Returns(expectedResponse);

            //Act
            var response = _controller.GetNextFibonacciNumber(317811);

            //Assert
            Assert.NotNull(response);
            var successReqResult = Assert.IsType<OkObjectResult>(response.Result);
            var apiResult = Assert.IsType<long>(successReqResult.Value);
            
            Assert.Equal(514229, apiResult);
        }

        [Fact]
        public void GetNextFibonacciNumber_NotFound()
        {
            // Arrange
            var expectedResponse = 0;
            _service.GetNextFibonacciNumber(Arg.Any<long>()).Returns(expectedResponse);

            //Act
            var response = _controller.GetNextFibonacciNumber(0);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response.Result);
        }

        [Fact]
        public void GetNextFibonacciNumber_BadRequest_NotFibonacci()
        {
            // Arrange
            var expectedMessage = "Not a Fibonacci number.";
            _service.When(x => x.GetNextFibonacciNumber(Arg.Any<long>())).Do(x => throw new InvalidFibonacciNumberException(expectedMessage));

            //Act
            var response = _controller.GetNextFibonacciNumber(31781);

            //Assert
            Assert.NotNull(response);
            var successReqResult = Assert.IsType<BadRequestObjectResult>(response.Result);
            Assert.Equal("Not a Fibonacci number.", successReqResult.Value);
        }

        [Fact]
        public void GetNextFibonacciNumber_BadRequest_NegativeNumber()
        {
            // Arrange
            var expectedMessage = "Number should be > 0.";
            _service.When(x => x.GetNextFibonacciNumber(Arg.Any<long>())).Do(x => throw new InvalidFibonacciNumberException(expectedMessage));

            //Act
            var response = _controller.GetNextFibonacciNumber(31781);

            //Assert
            Assert.NotNull(response);
            var successReqResult = Assert.IsType<BadRequestObjectResult>(response.Result);
            Assert.Equal(expectedMessage, successReqResult.Value);
        }
    }
}
