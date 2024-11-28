using Microsoft.AspNetCore.Mvc;

namespace RestWithAspnetUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult GetMulti(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(multi.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDiv(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(division.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mean")]
    public IActionResult GetMean([FromQuery] string[] numbers)
    {
        decimal sum = 0;
        int total = 0;

        foreach (var item in numbers)
        {
            if (!IsNumeric(item))
            {
                return BadRequest("Invalid Input");
            }

            sum += ConvertToDecimal(item);
            total++;
        }

        if (total > 0)
        {
            var average = sum / total;
            return Ok(average.ToString("F2")); // Formata o resultado com 2 casas decimais
        }

        return BadRequest("No valid numbers provided");
    }

    [HttpGet("square-root/{number}")]
    public IActionResult GetSqrt(string number)
    {
        if (IsNumeric(number))
        {
            var sqrt = Math.Sqrt(((double)ConvertToDecimal(number)));

            return Ok(sqrt.ToString("F2"));
        }

        return BadRequest("Invalid Input");

    }


    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                                        System.Globalization.NumberFormatInfo.InvariantInfo,
                                        out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;

        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }

}
