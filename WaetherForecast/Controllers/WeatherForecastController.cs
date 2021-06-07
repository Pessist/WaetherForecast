using Microsoft.AspNetCore.Mvc;
using System;

namespace WaetherForecast.Controllers
{
    [ApiController]
    [Route("api/crud")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public WeatherForecastController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime dateTime, [FromQuery] int temp)
        {
            _holder.CreateTemperature(dateTime, temp);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            return Ok(_holder.ReadTemperature(startTime, endTime));
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime dateTime, [FromQuery] int newTemp)
        {
            _holder.UpdateTemperature(dateTime, newTemp);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            _holder.DeleteTemperature(startTime, endTime);
            return Ok();
        }
    }
}
