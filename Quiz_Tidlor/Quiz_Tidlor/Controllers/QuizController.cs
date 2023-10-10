using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Quiz_Tidlor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        public QuizController() { }

        [HttpPost("Validate/Input")]
        public IActionResult FunctionValidateString([FromBody] string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return BadRequest("Input not empty.");
            }

            if (input.Length < 4 || input.Length > 25)
            {
                return BadRequest("ความยาวต้องอยู่ระหว่าง 4 ถึง 25 ตัวอักษร");
            }

            if (!Regex.IsMatch(input, @"^[a-zA-Zก-ฮ]"))
            {
                return BadRequest("ต้องเริ่มต้นคำด้วยตัวอักษร (A-Z, a-z, ก-ฮ) เท่านั้น");
            }
            else if (!Regex.IsMatch(input, @"^[a-zA-Zก-๙0-9]+[_]?[a-zA-Zก-๙0-9]*$") || input.EndsWith("_"))
            {
                return BadRequest("ต้องประกอบไปด้วย ตัวอักษร ตัวเลข และ \"_\" เท่านั้น และห้ามลงท้ายด้วย \"_\"");
            }

            return Ok("Pass");
        }

        [HttpPost("Factorial")]
        public IActionResult FirstFactorial([FromBody] int num)
        {
            if (num < 1 || num > 18)
            {
                return BadRequest("Request number be between 1 and 18.");
            }
            int result = Factorial(num);
            return Ok(result);
        }

        private int Factorial(int num)
        {
            int fact = num;
            if (num == 0)
                return 1;
            else
                return fact * Factorial(num - 1);
        }
    }
}
