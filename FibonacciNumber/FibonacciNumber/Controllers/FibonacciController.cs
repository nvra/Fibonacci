using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibonacciNumber.Common;
using FibonacciNumber.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciNumber.Controllers
{
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private IFibonacciService _service;

        public FibonacciController(IFibonacciService service)
        {
            _service = service;
        }

        [Route("fibonacci")]
        [HttpGet]
        public string Get()
        {
            return "Welcome to Fibonacci Programming";
        }

        [Route("api/fibonacci/{number}")]
        [HttpGet]
        public ActionResult<long> GetNextFibonacciNumber([FromRoute] long number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request.");
            }

            try
            {
                var response = _service.GetNextFibonacciNumber(number);

                if (response != 0)
                {
                    return Ok(response);
                }
                return NotFound("Next Fibonacci Number not found.");
            }
            catch(InvalidFibonacciNumberException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
