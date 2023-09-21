using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/Add?x=10 & y=20
        [HttpGet("/AddCalculator")]
        public int Add(int x, int y)
        {

            return x + y;

        }

        [HttpGet("/Sum")]
        public int Sum(int x, int y)
        {

            return x + y + 1000;

        }

        //api/calculator/Subtract? x = 100 & y = 20
        [HttpPost("/Subtract")]
        public int Subtract(int x, int y)
        {

            return x - y;

        }


        //api/calculator/Multiply?x=10 & y=20
        [HttpPut("/Multiply")]
        public int Multiply(int x, int y)
        {

            return x * y;

        }


        //api/calculator/Divide?x=10 & y=20
        [HttpDelete("/Divide")]
        public int Divide(int x, int y)
        {

            return x / y;

        }


    }
}
