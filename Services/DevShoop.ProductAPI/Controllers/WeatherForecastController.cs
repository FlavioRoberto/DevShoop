using Microsoft.AspNetCore.Mvc;

namespace DevShoop.ProductAPI;

[Route("Weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly string[] summaries;

    public WeatherForecastController()
    {
        summaries = new[]{
         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(summaries);
    }

}
