using System;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortstrage)
        {
            var a = Summaries;
            if (sortstrage == 1)  a = Summaries.OrderBy(x =>x).ToList();
            if (sortstrage == -1) a = Summaries.OrderByDescending(x => x).ToList();
            if (sortstrage < -1 || sortstrage > 1)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }

            return Ok(a);
        }

        [HttpGet("Index")]
        public IActionResult GetIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }
             
            return Ok(Summaries[index]);
        }
        [HttpGet("find-by-name")]
        public int GetFind(string name)
        {

            return Summaries.Count(name1 => name1 ==name);
        }

        [HttpPost("Add")]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(int index,string name) 
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int index)
        {
             if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}